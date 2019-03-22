using BigFootVentures.Application.Web.Models.Security;
using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System;
using System.Web.Mvc;
using static BigFootVentures.Application.Web.Models.VMEnums;

namespace BigFootVentures.Application.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Account")]
    public class AccountController : Controller
    {
        #region "Private Members"

        private readonly IManagementService<UserAccount> _service = null;

        #endregion

        #region "Constructors"

        public AccountController(IManagementService<UserAccount> service)
        {
            this._service = service;
        }

        #endregion

        #region "Action Results"

        public ActionResult Index()
        {
            return View();
        }

        [Route("AccountInformation", Name = "AccountInformationView")]
        public ActionResult AccountInformation()
        {
            var session = SessionUtils.GetUserAccount();

            var userAccount = this._service.Get(session.ID);
            var model = new VMModel<UserAccount>
            {
                Record = userAccount,
                PageMode = PageMode.View
            };

            return View("AccountInformationView", model);
        }

        [Route("ChangePassword", Name = "ChangePassword")]
        public ActionResult ChangePassword()
        {
            return View("ChangePassword");
        }

        [HttpPost]
        [Route("ChangePasswordPost", Name = "ChangePasswordPost")]
        public ActionResult ChangePasswordPost(string currentPassword, string newPassword, string confirmPassword)
        {
            bool isSuccess = true;

            try
            {
                if (string.Equals(currentPassword, newPassword))
                    throw new Exception("New password should not be the same as current password.");

                if (!string.Equals(newPassword, confirmPassword))
                    throw new Exception("Password does not matched.");

                var session = SessionUtils.GetUserAccount();
                var account = this._service.Get(session.ID);

                if (!string.Equals(currentPassword, PasswordEncryption.Decrypt(account.Password)))
                    throw new Exception("Current password is incorrect.");

                account.Password = PasswordEncryption.Encrypt(newPassword);

                this._service.UpdateUserAccount(account);
            }
            catch (Exception ex)
            {
                TempData.Add("ErrorMessage", ex.Message);
                isSuccess = false;
            }
            finally
            {
                TempData.Add("IsSuccess", isSuccess);
            }
            
            return RedirectToRoute("ChangePassword");
        }

        #endregion
    }
}
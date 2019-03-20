using BigFootVentures.Application.Web.Models.Security;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using BigFootVentures.Service.BusinessService.Validators;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace BigFootVentures.Application.Web.Controllers
{
    [AllowAnonymous]
    [RoutePrefix("Public")]
    public class PublicController : Controller
    {
        #region "Private Members"

        private readonly IManagementService<UserAccount> _managementUserAccountService = null;

        #endregion

        #region "Constructors"

        public PublicController(IManagementService<UserAccount> managementUserAccountService)
        {
            this._managementUserAccountService = managementUserAccountService;
        }

        #endregion

        #region "Login"

        [Route("~/")]
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [Route("Login", Name = "LoginPost")]
        public ActionResult Login(string username, string password)
        {
            try
            {
                if (Membership.ValidateUser(username, password))
                {
                    var userAccount = this._managementUserAccountService.GetByUsername(username).FirstOrDefault();

                    FormsAuthentication.SetAuthCookie($"{userAccount.ID} {username} {userAccount.FirstName} {userAccount.LastName} {userAccount.Roles}", false);

                    return RedirectToAction("Index", "Home");
                }

                throw new ApplicationException(ValidationMessages.USERACCOUNT_INVALID);
            }
            catch (ApplicationException appEx)
            {
                if (TempData.ContainsKey("username"))
                    TempData.Remove("username");

                if (TempData.ContainsKey("errorMessage"))
                    TempData.Remove("errorMessage");

                TempData.Add("username", username);
                TempData.Add("errorMessage", appEx.Message);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //write exception

                return RedirectToAction("Index");
            }
        }

        [Authorize]
        [Route("Logout")]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index");
        }

        #endregion

        #region "Action Results"

        [Route("UserAccountVerification/{id}", Name = "UserAccountVerificationView")]
        public ActionResult UserAccountVerification(int id)
        {
            var userAccount = this._managementUserAccountService.Get(id);

            if (userAccount == null || userAccount.IsActive)
            {
                return HttpNotFound();
            }

            userAccount.Password = string.Empty;

            var model = new VMModel<UserAccount>();
            model.Record = userAccount;

            return View(model);
        }

        [HttpPost]
        [Route("UserAccountVerification", Name = "UserAccountVerificationPost")]
        public ActionResult UserAccountVerification(VMModel<UserAccount> model)
        {
            var userAccount = this._managementUserAccountService.Get(model.Record.ID);

            if (userAccount == null || userAccount.IsActive)
            {
                return HttpNotFound();
            }

            if (string.IsNullOrWhiteSpace(model.Record.Password) || string.IsNullOrWhiteSpace(model.Record.ConfirmPassword))
            {
                TempData.Add("NoPasswordError", true);
                return View(model);
            }

            if (!string.Equals(model.Record.Password, model.Record.ConfirmPassword))
            {
                TempData.Add("NotEqualPasswordError", true);
                return View(model);
            }

            var newPassword = model.Record.Password;
            model.Record = userAccount;
            model.Record.IsActive = true;
            model.Record.Password = PasswordEncryption.Encrypt(newPassword);
            this._managementUserAccountService.UpdateUserAccount(model.Record);

            TempData.Add("UserActivatedInfo", true);
            return RedirectToAction("Index", "Public");
        }

        #endregion
    }
}
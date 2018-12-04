using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using BigFootVentures.Service.BusinessService.Validators;
using System;
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
                    FormsAuthentication.SetAuthCookie(username, false);

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
    }
}
using BigFootVentures.Application.Web.Models.Security;
using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.EmailTemplates.Management;
using BigFootVentures.Business.Objects.Logs;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using BigFootVentures.Service.BusinessService.Validators;
using System;
using System.Configuration;
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

        private readonly EmailAutomationService _emailAutomationService = null;

        private readonly IAuditTrailService _auditTrailService = null;

        #endregion

        #region "Constructors"

        public PublicController(
            IManagementService<UserAccount> managementUserAccountService,
            
            IAuditTrailService auditTrailService)
        {
            this._managementUserAccountService = managementUserAccountService;

            this._emailAutomationService = new EmailAutomationService(
                ConfigurationManager.AppSettings["SMTP_Host"],
                Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]),
                ConfigurationManager.AppSettings["SMTP_FromEmail"],
                ConfigurationManager.AppSettings["SMTP_Username"],
                ConfigurationManager.AppSettings["SMTP_Password"]);

            this._auditTrailService = auditTrailService;
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

                    this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = userAccount.ID,
                                Message = "User Account logged in.",
                                UserAccount = new UserAccount
                                {
                                    ID = userAccount.ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });

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
            this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = SessionUtils.GetUserAccount().ID,
                                Message = "User Account logged out.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });

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

            this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = model.Record.ID,
                                Message = "User Account was verified successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = model.Record.ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });

            TempData.Add("UserActivatedInfo", true);

            return RedirectToAction("Index", "Public");
        }

        [Route("ForgotPassword", Name = "ForgotPasswordView")]
        public ActionResult ForgotPassword()
        {
            var model = new VMModel<UserAccount>();

            return View(model);
        }

        [HttpPost]
        [Route("ForgotPassword", Name = "ForgotPasswordPost")]
        public ActionResult ForgotPassword(VMModel<UserAccount> model)
        {
            var userAccount = this._managementUserAccountService.GetByEmailAddress(model.Record.EmailAddress);

            if (userAccount == null)
            {
                return HttpNotFound();
            }

            var securityKey = ConfigurationManager.AppSettings["PasswordSecurityKey"];
            var encryptedID = PasswordEncryption.Encrypt($"{securityKey}_{userAccount.FirstOrDefault().ID}");

            this._emailAutomationService.SendEmail(
                            to: model.Record.EmailAddress,
                            subject: $"Recover Account - {model.Record.EmailAddress}",
                            body: UserAccountTemplate.GetForgotPasswordTemplate(
                                encryptedID,
                                ConfigurationManager.AppSettings["Host"],
                                userAccount.FirstOrDefault().FirstName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

            TempData.Add("ForgotPasswordInfo", model.Record.EmailAddress);

            return RedirectToAction("Index", "Public");
        }

        [Route("ForgotPasswordSet", Name = "ForgotPasswordSetView")]
        public ActionResult ForgotPasswordSet(string q)
        {
            var decryptedID = PasswordEncryption.Decrypt(q);
            var splitID = decryptedID.Split(new char[] { '_' }, 2);

            var userAccount = this._managementUserAccountService.Get(Convert.ToInt32(splitID.Last()));

            if (userAccount == null)
            {
                return HttpNotFound();
            }

            userAccount.Password = string.Empty;

            var model = new VMModel<UserAccount>();
            model.Record = userAccount;

            return View(model);
        }

        [HttpPost]
        [Route("ForgotPasswordSet", Name = "ForgotPasswordSetPost")]
        public ActionResult ForgotPasswordSet(VMModel<UserAccount> model)
        {
            var userAccount = this._managementUserAccountService.Get(model.Record.ID);

            if (userAccount == null)
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
            model.Record.Password = PasswordEncryption.Encrypt(newPassword);
            this._managementUserAccountService.UpdateUserAccount(model.Record);

            this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = userAccount.ID,
                                Message = "User Account reset password successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = userAccount.ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });

            TempData.Add("ForgotPasswordSetInfo", true);

            return RedirectToAction("Index", "Public");
        }

        #endregion
    }
}
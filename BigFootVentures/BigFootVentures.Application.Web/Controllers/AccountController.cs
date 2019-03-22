using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
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

        #endregion
    }
}
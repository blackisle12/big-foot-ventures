using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System.Web.Mvc;

namespace BigFootVentures.Application.Web.Controllers
{
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
            return View();
        }

        #endregion
    }
}
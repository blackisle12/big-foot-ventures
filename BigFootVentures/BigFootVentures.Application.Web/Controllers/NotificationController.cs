using BigFootVentures.Service.BusinessService.Notifications;
using System;
using System.Web.Mvc;

namespace BigFootVentures.Application.Web.Controllers
{
    [RoutePrefix("Notification")]
    public class NotificationController : Controller
    {
        #region Private Members

        private readonly INotificationTrademarkService _notificationTrademarkService = null;

        private readonly string _username = "sa";
        private readonly string _password = "FxWaWJ3csC58k";

        #endregion

        #region Constructors

        public NotificationController(INotificationTrademarkService notificationTrademarkService)
        {
            _notificationTrademarkService = notificationTrademarkService;
        }

        #endregion

        #region Action Results

        public ActionResult Index()
        {
            return null;
        }

        [Route("TrademarkGetProofOfUse", Name = "TrademarkGetProofOfUse")]
        public ActionResult TrademarkGetProofOfUse(string username, string password)
        {
            if (string.Equals(username, _username, StringComparison.InvariantCulture) && string.Equals(password, _password, StringComparison.InvariantCulture))
            {
                var list = _notificationTrademarkService.GetProofOfUse();
            }

            return null;
        }

        #endregion
    }
}
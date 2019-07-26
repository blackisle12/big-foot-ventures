using BigFootVentures.Business.DataAccess.Notifications;
using BigFootVentures.Business.Objects.Notifications.Trademark;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService.Notifications
{
    public interface INotificationTrademarkService
    {
        ICollection<ProofOfUse> GetProofOfUse();
    }

    public sealed class NotificationTrademarkService :INotificationTrademarkService
    {
        #region "Private Members"

        private readonly string _connectionString = null;

        #endregion

        #region "Constructors"

        public NotificationTrademarkService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region "Factory Methods"

        public ICollection<ProofOfUse> GetProofOfUse()
        {
            using (var notificationTrademarkDataAccess = new NotificationTrademarkDataAccess(this._connectionString))
            {
                return notificationTrademarkDataAccess.GetProofOfUse();
            }
        }

        #endregion
    }
}

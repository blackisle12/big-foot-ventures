using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.Objects.Logs;

namespace BigFootVentures.Service.BusinessService
{
    public interface IAuditTrailService
    {
        #region "Persistence"

        void Insert(AuditTrail model);

        #endregion
    }

    public class AuditTrailService : IAuditTrailService
    {
        #region "Private Members"

        private readonly string _connectionString = null;

        #endregion

        #region "Constructors"

        public AuditTrailService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region "Persistence"

        public void Insert(AuditTrail model)
        {
            using (var dataAccess = new AuditTrailDataAccess(_connectionString))
            {
                dataAccess.Insert(model);
            }
        }

        #endregion
    }
}

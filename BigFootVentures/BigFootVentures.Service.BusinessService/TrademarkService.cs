using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Business.Objects.Wrapper;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface ITrademarkService
    {
        #region "Factory Methods"

        Trademark Get(int ID);

        #endregion
    }

    public sealed class TrademarkService : ITrademarkService
    {
        #region "Private Members"

        private readonly string _connectionString = null;

        #endregion

        #region "Constructors"

        public TrademarkService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region "Factory Methods"

        public Trademark Get(int ID)
        {
            using (var trademarkDataAccess = new TrademarkDataAccess(this._connectionString))
            {
                return trademarkDataAccess.Get(ID);
            }
        }

        #endregion
    }
}

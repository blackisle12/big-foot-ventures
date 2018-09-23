using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class CompanyMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            throw new NotImplementedException();
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

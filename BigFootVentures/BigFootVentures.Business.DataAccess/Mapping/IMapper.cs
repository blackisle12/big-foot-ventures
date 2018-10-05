using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BigFootVentures.Business.DataAccess.Mapping
{
    public interface IMapper
    {
        #region "Public Methods"

        ICollection<object> ParseData(MySqlDataReader dataReader);

        MySqlParameter[] CreateParameters(object model);

        #endregion
    }
}

using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping
{
    public interface IMapper
    {
        #region "Public Methods"

        ICollection<object> ParseData(MySqlDataReader dataReader);

        ICollection<object> ParseDataMin(MySqlDataReader dataReader);

        StringBuilder ExportData(MySqlDataReader dataReader);

        MySqlParameter[] CreateParameters(object model);

        #endregion
    }
}

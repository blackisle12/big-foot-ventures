using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace BigFootVentures.Business.DataAccess.Mapping
{
    public interface IEmailNotificationMapper
    {
        #region "Public Methods"

        ICollection<object> ParseData(MySqlDataReader dataReader);

        #endregion
    }
}

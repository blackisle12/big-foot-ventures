using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class RegisterMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Register
                {
                    ID = (int)dataReader["ID"],
                    Name = dataReader["Name"] as string,
                    RAAYear = dataReader["RAA Year"] as string,
                    Country = dataReader["Country"] as string,
                    AccreditedTLDs = dataReader["Accredited TLDs"] as string,
                    OwnerName = dataReader["Owner Name"] as string
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Register)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pRAAYear", MySqlDbType.VarChar, 100) { Value = entity.RAAYear, Direction = ParameterDirection.Input },
                new MySqlParameter("pCountry", MySqlDbType.VarChar, 100) { Value = entity.Country, Direction = ParameterDirection.Input },
                new MySqlParameter("pAccreditedTLDs", MySqlDbType.VarChar, 255) { Value = entity.AccreditedTLDs, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

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
                entities.Add(new Register
                {
                    ID = (int)dataReader["ID"],
                    Name = dataReader["Name"] as string,
                    RAAYear = dataReader["RAA Year"] as string,
                    Country = dataReader["Country"] as string,
                    AccreditedTLDs = dataReader["Accredited TLDs"] as string,
                    OwnerName = dataReader["Owner Name"] as string
                });
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            var register = (Register)entity;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = register.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pRAAYear", MySqlDbType.VarChar, 100) { Value = register.RAAYear, Direction = ParameterDirection.Input },
                new MySqlParameter("pCountry", MySqlDbType.VarChar, 100) { Value = register.Country, Direction = ParameterDirection.Input },
                new MySqlParameter("pAccreditedTLDs", MySqlDbType.VarChar, 255) { Value = register.AccreditedTLDs, Direction = ParameterDirection.Input },
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = register.OwnerName, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

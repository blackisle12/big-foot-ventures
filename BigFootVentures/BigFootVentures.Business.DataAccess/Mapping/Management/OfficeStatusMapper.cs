using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class OfficeStatusMapper : IMapper
    {
        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                entities.Add(new OfficeStatus
                {
                    ID = (int)dataReader["ID"],
                    Name = dataReader["Name"] as string,
                    StatusDescription = dataReader["StatusDescription"] as string,
                    StatusGrouping = dataReader["StatusGrouping"] as string,
               
                    OwnerName = dataReader["OwnerName"] as string
                });
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            var officeStatus = (OfficeStatus)entity;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = officeStatus.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatusDescription", MySqlDbType.VarChar, 255) { Value = officeStatus.StatusDescription, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatusGrouping", MySqlDbType.VarChar, 100) { Value = officeStatus.StatusGrouping, Direction = ParameterDirection.Input },
                
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = officeStatus.OwnerName, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }
    }
}

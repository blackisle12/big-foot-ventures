using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class OfficeStatusMapper : IMapper
    {
        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new OfficeStatus
                {
                    ID = (int)dataReader["ID"],

                    Name = dataReader["Name"] as string,
                    StatusDescription = dataReader["StatusDescription"] as string,
                    StatusGrouping = dataReader["StatusGrouping"] as string,

                    OwnerName = dataReader["OwnerName"] as string
                };

                if (int.TryParse((dataReader["OfficeID"] as int?)?.ToString(), out int officeID))
                {
                    entity.Office = new Office { ID = officeID };
                }

                entities.Add(entity);
            }

            return entities;
        }

        public ICollection<object> ParseDataMin(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new OfficeStatus
                {
                    ID = (int)dataReader["ID"],

                    Name = dataReader["Name"] as string,
                    StatusGrouping = dataReader["StatusGrouping"] as string,

                    OwnerName = dataReader["OwnerName"] as string
                };

                entities.Add(entity);
            }

            return entities;
        }

        public StringBuilder ExportData(MySqlDataReader dataReader)
        {
            var file = new StringBuilder();

            while (dataReader.Read())
            {
                //file.AppendLine($@"{dataReader["Name"] as string} 
                //    {(dataReader["BigFootOwned"] as sbyte? ?? 0) == 1} 
                //    {dataReader["RegistrantName"] as string} 
                //    {dataReader["ExpirationDate"] as string} 
                //    {dataReader["RegistrarName"] as string}");
            }

            return file;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (OfficeStatus)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatusDescription", MySqlDbType.VarChar, 255) { Value = entity.StatusDescription, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatusGrouping", MySqlDbType.VarChar, 100) { Value = entity.StatusGrouping, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeID", MySqlDbType.Int32) { Value = entity.Office?.ID, Direction = ParameterDirection.Input },

                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }
    }
}

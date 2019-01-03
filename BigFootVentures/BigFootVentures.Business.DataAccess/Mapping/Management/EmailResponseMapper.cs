using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class EmailResponseMapper: IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new EmailResponse
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    Name = dataReader["Name"] as string,
                    Description = dataReader["Description"] as string,
                    Email = dataReader["Email"] as string,
                    Status = dataReader["Status"] as string,
                    Subject = dataReader["Subject"] as string,
                    MessageDate = dataReader["MessageDate"] as string
                };

                if (int.TryParse((dataReader["EnquiryID"] as int?)?.ToString(), out int enquiryID))
                {
                    entity.Enquiry = new Enquiry { ID = enquiryID };
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
                var entity = new EmailResponse
                {
                    ID = (int)dataReader["ID"],

                    Name = dataReader["Name"] as string,
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
            var entity = (EmailResponse)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pName", MySqlDbType.VarChar, 100) { Value = entity.Name, Direction = ParameterDirection.Input },
                new MySqlParameter("pEnquiryID", MySqlDbType.Int32) { Value = entity.Enquiry?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pDescription", MySqlDbType.VarChar, 100) { Value = entity.Description, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmail", MySqlDbType.VarChar, 255) { Value = entity.Email, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 100) { Value = entity.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pSubject", MySqlDbType.VarChar, 100) { Value = entity.Subject, Direction = ParameterDirection.Input },
                new MySqlParameter("pMessageDate", MySqlDbType.VarChar, 100) { Value = entity.MessageDate, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

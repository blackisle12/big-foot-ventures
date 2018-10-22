using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class LeadMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Lead
                {
                    ID = (int)dataReader["ID"],

                    OwnerName = dataReader["OwnerName"] as string,

                    Status = dataReader["Status"] as string,
                    Salutation = dataReader["Salutation"] as string,
                    FirstName = dataReader["FirstName"] as string,
                    MiddleName = dataReader["MiddleName"] as string,
                    LastName = dataReader["LastName"] as string,
                    Suffix = dataReader["Suffix"] as string,
                    Title = dataReader["Title"] as string,
                    Email = dataReader["Email"] as string,
                    Phone = dataReader["Phone"] as string,
                    Company = dataReader["Company"] as string,
                    Industry = dataReader["Industry"] as string,
                    NoOfEmployees = dataReader["NoOfEmployees"] as string,
                    Source = dataReader["Source"] as string,

                    Country = dataReader["Country"] as string,
                    Street = dataReader["Street"] as string,
                    City = dataReader["City"] as string,
                    State = dataReader["State"] as string,
                    PostalCode = dataReader["PostalCode"] as string,

                    AssignUsingActiveAssignmentRule = (dataReader["AssignUsingActiveAssignmentRule"] as sbyte? ?? 0) == 1
                };

                entities.Add(entity);
            }

            return entities;
        }

        public ICollection<object> ParseDataMin(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Lead
                {
                    ID = (int)dataReader["ID"],
                    
                    Status = dataReader["Status"] as string,
                    FirstName = dataReader["FirstName"] as string,
                    LastName = dataReader["LastName"] as string,
                    Company = dataReader["Company"] as string,
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Lead)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pStatus", MySqlDbType.VarChar, 45) { Value = entity.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pSalutation", MySqlDbType.VarChar, 45) { Value = entity.Salutation, Direction = ParameterDirection.Input },
                new MySqlParameter("pFirstName", MySqlDbType.VarChar, 100) { Value = entity.FirstName, Direction = ParameterDirection.Input },
                new MySqlParameter("pMiddleName", MySqlDbType.VarChar, 100) { Value = entity.MiddleName, Direction = ParameterDirection.Input },
                new MySqlParameter("pLastName", MySqlDbType.VarChar, 100) { Value = entity.LastName, Direction = ParameterDirection.Input },
                new MySqlParameter("pSuffix", MySqlDbType.VarChar, 45) { Value = entity.Suffix, Direction = ParameterDirection.Input },
                new MySqlParameter("pTitle", MySqlDbType.VarChar, 45) { Value = entity.Title, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmail", MySqlDbType.VarChar, 100) { Value = entity.Email, Direction = ParameterDirection.Input },
                new MySqlParameter("pPhone", MySqlDbType.VarChar, 100) { Value = entity.Phone, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompany", MySqlDbType.VarChar, 100) { Value = entity.Company, Direction = ParameterDirection.Input },
                new MySqlParameter("pIndustry", MySqlDbType.VarChar, 45) { Value = entity.Industry, Direction = ParameterDirection.Input },
                new MySqlParameter("pNoOfEmployees", MySqlDbType.VarChar, 45) { Value = entity.NoOfEmployees, Direction = ParameterDirection.Input },
                new MySqlParameter("pSource", MySqlDbType.VarChar, 45) { Value = entity.Source, Direction = ParameterDirection.Input },

                new MySqlParameter("pCountry", MySqlDbType.VarChar, 100) { Value = entity.Country, Direction = ParameterDirection.Input },
                new MySqlParameter("pStreet", MySqlDbType.VarChar, 255) { Value = entity.Street, Direction = ParameterDirection.Input },
                new MySqlParameter("pCity", MySqlDbType.VarChar, 100) { Value = entity.City, Direction = ParameterDirection.Input },
                new MySqlParameter("pState", MySqlDbType.VarChar, 100) { Value = entity.State, Direction = ParameterDirection.Input },
                new MySqlParameter("pPostalCode", MySqlDbType.VarChar, 45) { Value = entity.PostalCode, Direction = ParameterDirection.Input },

                new MySqlParameter("pAssignUsingActiveAssignmentRule", entity.AssignUsingActiveAssignmentRule ? 1 : 0) { Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

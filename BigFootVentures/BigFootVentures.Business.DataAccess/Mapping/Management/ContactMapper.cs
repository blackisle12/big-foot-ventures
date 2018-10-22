using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class ContactMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Contact
                {
                    ID = (int)dataReader["ID"],
                    
                    OwnerName = dataReader["OwnerName"] as string,

                    FirstName = dataReader["FirstName"] as string,
                    MiddleName = dataReader["MiddleName"] as string,
                    LastName = dataReader["LastName"] as string,
                    Salutation = dataReader["Salutation"] as string,
                    Suffix = dataReader["Suffix"] as string,
                    Title = dataReader["Title"] as string,
                    Email = dataReader["Email"] as string,
                    Phone = dataReader["Phone"] as string,
                    Mobile = dataReader["Mobile"] as string,
                    Fax = dataReader["Fax"] as string,
                    Department = dataReader["Department"] as string,
                    OHIMOwnerID = dataReader["OHIMOwnerID"] as string,
                    OHIMNumTrademarks = dataReader["OHIMNumTrademarks"] as string,

                    MailingCountry = dataReader["MailingCountry"] as string,
                    MailingStreet = dataReader["MailingStreet"] as string,
                    MailingCity = dataReader["MailingCity"] as string,
                    MailingState = dataReader["MailingState"] as string,
                    MailingPostalCode = dataReader["MailingPostalCode"] as string
                };

                if (int.TryParse((dataReader["CompanyID"] as int?)?.ToString(), out int companyID))
                {
                    entity.Company = new Company { ID = companyID };
                }

                if (int.TryParse((dataReader["WebsiteIndividualID"] as int?)?.ToString(), out int websiteIndividualID))
                {
                    entity.WebsiteIndividual = new DomainN { ID = websiteIndividualID };
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
                var entity = new Contact
                {
                    ID = (int)dataReader["ID"],

                    FirstName = dataReader["FirstName"] as string,
                    LastName = dataReader["LastName"] as string,
                    Department = dataReader["Department"] as string,
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Contact)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pFirstName", MySqlDbType.VarChar, 100) { Value = entity.FirstName, Direction = ParameterDirection.Input },
                new MySqlParameter("pMiddleName", MySqlDbType.VarChar, 100) { Value = entity.MiddleName, Direction = ParameterDirection.Input },
                new MySqlParameter("pLastName", MySqlDbType.VarChar, 100) { Value = entity.LastName, Direction = ParameterDirection.Input },
                new MySqlParameter("pSalutation", MySqlDbType.VarChar, 45) { Value = entity.Salutation, Direction = ParameterDirection.Input },
                new MySqlParameter("pSuffix", MySqlDbType.VarChar, 45) { Value = entity.Suffix, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanyID", MySqlDbType.Int32) { Value = entity.Company?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pTitle", MySqlDbType.VarChar, 100) { Value = entity.Title, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmail", MySqlDbType.VarChar, 100) { Value = entity.Email, Direction = ParameterDirection.Input },
                new MySqlParameter("pPhone", MySqlDbType.VarChar, 100) { Value = entity.Phone, Direction = ParameterDirection.Input },
                new MySqlParameter("pMobile", MySqlDbType.VarChar, 100) { Value = entity.Mobile, Direction = ParameterDirection.Input },
                new MySqlParameter("pFax", MySqlDbType.VarChar, 45) { Value = entity.Fax, Direction = ParameterDirection.Input },
                new MySqlParameter("pDepartment", MySqlDbType.VarChar, 100) { Value = entity.Department, Direction = ParameterDirection.Input },
                new MySqlParameter("pOHIMOwnerID", MySqlDbType.VarChar, 100) { Value = entity.OHIMOwnerID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOHIMNumTrademarks", MySqlDbType.VarChar, 100) { Value = entity.OHIMNumTrademarks, Direction = ParameterDirection.Input },
                new MySqlParameter("pWebsiteIndividualID", MySqlDbType.Int32) { Value = entity.WebsiteIndividual?.ID, Direction = ParameterDirection.Input },

                new MySqlParameter("pMailingCountry", MySqlDbType.VarChar, 100) { Value = entity.MailingCountry, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingStreet", MySqlDbType.VarChar, 100) { Value = entity.MailingStreet, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingCity", MySqlDbType.VarChar, 100) { Value = entity.MailingCity, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingState", MySqlDbType.VarChar, 100) { Value = entity.MailingState, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingPostalCode", MySqlDbType.VarChar, 45) { Value = entity.MailingPostalCode, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

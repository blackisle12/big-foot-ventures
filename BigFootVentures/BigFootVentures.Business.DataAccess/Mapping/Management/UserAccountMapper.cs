using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class UserAccountMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new UserAccount
                {
                    ID = (int)dataReader["ID"],

                    FirstName = dataReader["FirstName"] as string,
                    LastName = dataReader["LastName"] as string,
                    EmailAddress = dataReader["EmailAddress"] as string,
                    Username = dataReader["Username"] as string,
                    Password = dataReader["Password"] as string,
                    IsActive = (dataReader["IsActive"] as sbyte? ?? 0) == 1,
                    Title = dataReader["Title"] as string,
                    Company = dataReader["Company"] as string,
                    Department = dataReader["Department"] as string,
                    Division = dataReader["Division"] as string,
                    EmployeeNumber = dataReader["EmployeeNumber"] as string,

                    MailingCountry = dataReader["MailingCountry"] as string,
                    MailingStreet = dataReader["MailingStreet"] as string,
                    MailingCity = dataReader["MailingCity"] as string,
                    MailingState = dataReader["MailingState"] as string,
                    MailingZipCode = dataReader["MailingZipCode"] as string,

                    CreatedDate = Convert.ToDateTime(dataReader["CreatedDate"])
                };

                if (int.TryParse((dataReader["CreatedBy"] as int?)?.ToString(), out int createdBy))
                {
                    entity.CreatedBy = createdBy;
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
                var entity = new UserAccount
                {
                    ID = (int)dataReader["ID"],

                    FirstName = dataReader["FirstName"] as string,
                    LastName = dataReader["LastName"] as string,
                    EmailAddress = dataReader["EmailAddress"] as string,
                    Username = dataReader["Username"] as string,
                    IsActive = (dataReader["IsActive"] as sbyte? ?? 0) == 1
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (UserAccount)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pFirstName", MySqlDbType.VarChar, 45) { Value = entity.FirstName, Direction = ParameterDirection.Input },
                new MySqlParameter("pLastName", MySqlDbType.VarChar, 45) { Value = entity.LastName, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmailAddress", MySqlDbType.VarChar, 100) { Value = entity.EmailAddress, Direction = ParameterDirection.Input },
                new MySqlParameter("pUsername", MySqlDbType.VarChar, 45) { Value = entity.Username, Direction = ParameterDirection.Input },
                new MySqlParameter("pPassword", MySqlDbType.VarChar, 100) { Value = entity.Password, Direction = ParameterDirection.Input },
                new MySqlParameter("pIsActive", entity.IsActive ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pCompany", MySqlDbType.VarChar, 100) { Value = entity.Company, Direction = ParameterDirection.Input },
                new MySqlParameter("pDepartment", MySqlDbType.VarChar, 100) { Value = entity.Department, Direction = ParameterDirection.Input },
                new MySqlParameter("pDivision", MySqlDbType.VarChar, 100) { Value = entity.Division, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmployeeNumber", MySqlDbType.VarChar, 45) { Value = entity.EmployeeNumber, Direction = ParameterDirection.Input },

                new MySqlParameter("pMailingCountry", MySqlDbType.VarChar, 100) { Value = entity.MailingCountry, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingStreet", MySqlDbType.VarChar, 100) { Value = entity.MailingStreet, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingCity", MySqlDbType.VarChar, 100) { Value = entity.MailingCity, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingState", MySqlDbType.VarChar, 45) { Value = entity.MailingState, Direction = ParameterDirection.Input },
                new MySqlParameter("pMailingZipCode", MySqlDbType.VarChar, 100) { Value = entity.MailingZipCode, Direction = ParameterDirection.Input },

                new MySqlParameter("pCreatedBy", MySqlDbType.Int32) { Value = entity.CreatedBy, Direction = ParameterDirection.Input },
                new MySqlParameter("pCreatedDate", MySqlDbType.DateTime) { Value = entity.CreatedDate, Direction = ParameterDirection.Input }
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

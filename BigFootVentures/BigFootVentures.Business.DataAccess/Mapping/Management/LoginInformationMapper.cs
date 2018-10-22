using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class LoginInformationMapper: IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new LoginInformation
                {
                    ID = (int)dataReader["ID"],
                    OwnerName = dataReader["OwnerName"] as string,

                    Country = dataReader["Country"] as string,
                    Office = dataReader["Office"] as string,
                    Url = dataReader["Url"] as string,
                    LoginInformationID = dataReader["LoginInformationID"] as string,
                    PW = dataReader["PW"] as string,
                    AccountName = dataReader["AccountName"] as string,
                    CurrentAccount = dataReader["CurrentAccount"] as string,
                    SecretPhase = dataReader["SecretPhase"] as string,
                    MonitoringStaff = dataReader["MonitoringStaff"] as string,
                    OfficeID = dataReader["OfficeID"] as string,
                    CompanyRegistrationNo = dataReader["CompanyRegistrationNo"] as string,
                    Balance = dataReader["Balance"] as string,
                    EmailAddress = dataReader["EmailAddress"] as string,
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
                var entity = new LoginInformation
                {
                    ID = (int)dataReader["ID"],
                                        
                    LoginInformationID = dataReader["LoginInformationID"] as string,
                    AccountName = dataReader["AccountName"] as string,
                    EmailAddress = dataReader["EmailAddress"] as string,
                };

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (LoginInformation)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pOwnerName", MySqlDbType.VarChar, 100) { Value = entity.OwnerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pCountry", MySqlDbType.VarChar, 100) { Value = entity.Country, Direction = ParameterDirection.Input },
                new MySqlParameter("pOffice", MySqlDbType.VarChar, 100) { Value = entity.Office, Direction = ParameterDirection.Input },
                new MySqlParameter("pUrl", MySqlDbType.VarChar, 255) { Value = entity.Url, Direction = ParameterDirection.Input },
                new MySqlParameter("pLoginInformationID", MySqlDbType.VarChar, 100) { Value = entity.LoginInformationID, Direction = ParameterDirection.Input },
                new MySqlParameter("pPW", MySqlDbType.VarChar, 100) { Value = entity.PW, Direction = ParameterDirection.Input },
                new MySqlParameter("pAccountName", MySqlDbType.VarChar, 100) { Value = entity.AccountName, Direction = ParameterDirection.Input },
                new MySqlParameter("pCurrentAccount", MySqlDbType.VarChar, 100) { Value = entity.CurrentAccount, Direction = ParameterDirection.Input },
                new MySqlParameter("pSecretPhase", MySqlDbType.VarChar, 100) { Value = entity.SecretPhase, Direction = ParameterDirection.Input },
                new MySqlParameter("pMonitoringStaff", MySqlDbType.VarChar, 100) { Value = entity.MonitoringStaff, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeID", MySqlDbType.VarChar, 100) { Value = entity.OfficeID, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanyRegistrationNo", MySqlDbType.VarChar, 100) { Value = entity.CompanyRegistrationNo, Direction = ParameterDirection.Input },
                new MySqlParameter("pBalance", MySqlDbType.VarChar, 100) { Value = entity.Balance, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmailAddress", MySqlDbType.VarChar, 100) { Value = entity.EmailAddress, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

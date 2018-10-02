using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class DomainEnquiryMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                entities.Add(new DomainEnquiry
                {
                    ID = (int)dataReader["ID"],

                    RecordType = dataReader["RecordType"] as string,
                    OwnerName = dataReader["OwnerName"] as string,

                    NegotiationBFAmount = dataReader["NegotiationBFAmount"] as string,
                    Negotiation3rdPartyAmount = dataReader["Negotiation3rdPartyAmount"] as string,
                    OldCaseNumber = dataReader["OldCaseNumber"] as string,
                    Priority = dataReader["Priority"] as string,
                    Status = dataReader["Status"] as string,
                    SendEmail = (Convert.ToSByte(dataReader["SendEmail"]) == 1),
                    UnreadEmail = (Convert.ToSByte(dataReader["UnreadEmail"]) == 1),
                    DoNotContact = (Convert.ToSByte(dataReader["DoNotContact"]) == 1),
                    Subject = dataReader["Subject"] as string,
                    PercentOfCompletion = dataReader["PercentOfCompletion"] as string,
                    CaseAssign = dataReader["CaseAssign"] as string,

                    PrivateRegistrationEmail = dataReader["PrivateRegistrationEmail"] as string,
                    Registrant = dataReader["Registrant"] as string,
                    CaseOrigin = dataReader["CaseOrigin"] as string,
                    ReferenceNumber = dataReader["ReferenceNumber"] as string,

                    DomainName = dataReader["DomainName"] as string,
                    RegistrantCompanyID = dataReader["RegistrantCompanyID"] as int?,
                    RegistrantID = dataReader["RegistrantID"] as int?,
                    RegistrantEmail = dataReader["RegistrantEmail"] as string,
                    Street = dataReader["Street"] as string,
                    City = dataReader["City"] as string,
                    State = dataReader["State"] as string,
                    Country = dataReader["Country"] as string,
                    PostalCode = dataReader["PostalCode"] as string,
                    Phone = dataReader["Phone"] as string,
                    Fax = dataReader["Fax"] as string,
                    Description = dataReader["Description"] as string,

                    FieldNames = dataReader["FieldNames"] as string,
                    InternalComments = dataReader["InternalComments"] as string,
                    ObjectNames = dataReader["ObjectNames"] as string,
                    TechnicalAssessment = dataReader["TechnicalAssessment"] as string,

                    TestPlan = dataReader["TestPlan"] as string,
                    StepsToTest = dataReader["StepsToTest"] as string,
                    TestOutcome = dataReader["TestOutcome"] as string
                });
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            var domainEnquiry = (DomainEnquiry)entity;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pRecordType", MySqlDbType.VarChar, 100) { Value = domainEnquiry.RecordType, Direction = ParameterDirection.Input },

                new MySqlParameter("pNegotiationBFAmount", MySqlDbType.VarChar, 100) { Value = domainEnquiry.NegotiationBFAmount, Direction = ParameterDirection.Input },
                new MySqlParameter("pNegotiation3rdPartyAmount", MySqlDbType.VarChar, 100) { Value = domainEnquiry.Negotiation3rdPartyAmount, Direction = ParameterDirection.Input },
                new MySqlParameter("pOldCaseNumber", MySqlDbType.VarChar, 100) { Value = domainEnquiry.OldCaseNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pPriority", MySqlDbType.VarChar, 45) { Value = domainEnquiry.Priority, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 100) { Value = domainEnquiry.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pSendEmail", domainEnquiry.SendEmail ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pUnreadEmail", domainEnquiry.UnreadEmail ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDoNotContact", domainEnquiry.DoNotContact ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pSubject", MySqlDbType.VarChar, 100) { Value = domainEnquiry.Subject, Direction = ParameterDirection.Input },
                new MySqlParameter("pPercentOfCompletion", MySqlDbType.VarChar, 100) { Value = domainEnquiry.PercentOfCompletion, Direction = ParameterDirection.Input },
                new MySqlParameter("pCaseAssign", MySqlDbType.VarChar, 45) { Value = domainEnquiry.CaseAssign, Direction = ParameterDirection.Input },

                new MySqlParameter("pPrivateRegistrationEmail", MySqlDbType.VarChar, 100) { Value = domainEnquiry.PrivateRegistrationEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrant", MySqlDbType.VarChar, 100) { Value = domainEnquiry.Registrant, Direction = ParameterDirection.Input },
                new MySqlParameter("pCaseOrigin", MySqlDbType.VarChar, 45) { Value = domainEnquiry.CaseOrigin, Direction = ParameterDirection.Input },
                new MySqlParameter("pReferenceNumber", MySqlDbType.VarChar, 100) { Value = domainEnquiry.ReferenceNumber, Direction = ParameterDirection.Input },

                new MySqlParameter("pDomainName", MySqlDbType.VarChar, 100) { Value = domainEnquiry.DomainName, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantCompanyID", MySqlDbType.Int32) { Value = domainEnquiry.RegistrantCompanyID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantID", MySqlDbType.Int32) { Value = domainEnquiry.RegistrantID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantEmail", MySqlDbType.VarChar, 100) { Value = domainEnquiry.RegistrantEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pStreet", MySqlDbType.VarChar, 100) { Value = domainEnquiry.Street, Direction = ParameterDirection.Input },
                new MySqlParameter("pCity", MySqlDbType.VarChar, 100) { Value = domainEnquiry.City, Direction = ParameterDirection.Input },
                new MySqlParameter("pState", MySqlDbType.VarChar, 100) { Value = domainEnquiry.State, Direction = ParameterDirection.Input },
                new MySqlParameter("pCountry", MySqlDbType.VarChar, 100) { Value = domainEnquiry.Country, Direction = ParameterDirection.Input },
                new MySqlParameter("pPostalCode", MySqlDbType.VarChar, 45) { Value = domainEnquiry.PostalCode, Direction = ParameterDirection.Input },
                new MySqlParameter("pPhone", MySqlDbType.VarChar, 45) { Value = domainEnquiry.Phone, Direction = ParameterDirection.Input },
                new MySqlParameter("pFax", MySqlDbType.VarChar, 45) { Value = domainEnquiry.Fax, Direction = ParameterDirection.Input },
                new MySqlParameter("pDescription", MySqlDbType.VarChar, 255) { Value = domainEnquiry.Description, Direction = ParameterDirection.Input },

                new MySqlParameter("pFieldNames", MySqlDbType.VarChar, 255) { Value = domainEnquiry.FieldNames, Direction = ParameterDirection.Input },
                new MySqlParameter("pInternalComments", MySqlDbType.VarChar, 255) { Value = domainEnquiry.InternalComments, Direction = ParameterDirection.Input },
                new MySqlParameter("pObjectNames", MySqlDbType.VarChar, 255) { Value = domainEnquiry.ObjectNames, Direction = ParameterDirection.Input },
                new MySqlParameter("pTechnicalAssessment", MySqlDbType.VarChar, 255) { Value = domainEnquiry.TechnicalAssessment, Direction = ParameterDirection.Input },

                new MySqlParameter("pTestPlan", MySqlDbType.VarChar, 255) { Value = domainEnquiry.TestPlan, Direction = ParameterDirection.Input },
                new MySqlParameter("pStepsToTest", MySqlDbType.VarChar, 255) { Value = domainEnquiry.StepsToTest, Direction = ParameterDirection.Input },
                new MySqlParameter("pTestOutcome", MySqlDbType.VarChar, 255) { Value = domainEnquiry.TestOutcome, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

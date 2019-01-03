using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class EnquiryMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Enquiry
                {
                    ID = (int)dataReader["ID"],

                    RecordType = dataReader["RecordType"] as string,
                    OwnerName = dataReader["OwnerName"] as string,

                    NegotiationBFAmount = dataReader["NegotiationBFAmount"] as string,
                    Negotiation3rdPartyAmount = dataReader["Negotiation3rdPartyAmount"] as string,
                    OldCaseNumber = dataReader["OldCaseNumber"] as string,
                    Priority = dataReader["Priority"] as string,
                    Status = dataReader["Status"] as string,
                    SendEmail = (dataReader["SendEmail"] as sbyte? ?? 0) == 1,
                    UnreadEmail = (dataReader["UnreadEmail"] as sbyte? ?? 0) == 1,
                    DoNotContact = (dataReader["DoNotContact"] as sbyte? ?? 0) == 1,
                    Subject = dataReader["Subject"] as string,
                    PercentOfCompletion = dataReader["PercentOfCompletion"] as string,
                    CaseAssign = dataReader["CaseAssign"] as string,

                    PrivateRegistrationEmail = dataReader["PrivateRegistrationEmail"] as string,
                    Registrant = dataReader["Registrant"] as string,
                    CaseOrigin = dataReader["CaseOrigin"] as string,
                    ReferenceNumber = dataReader["ReferenceNumber"] as string,

                    DomainName = dataReader["DomainName"] as string,                    
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
                };

                if (int.TryParse((dataReader["RegistrantCompanyID"] as int?)?.ToString(), out int registrantCompanyID))
                {
                    entity.RegistrantCompany = new Company { ID = registrantCompanyID };
                }

                if (int.TryParse((dataReader["RegistrantID"] as int?)?.ToString(), out int registrantID))
                {
                    entity.Registrar = new Register { ID = registrantID };
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
                var entity = new Enquiry
                {
                    ID = (int)dataReader["ID"],
                    
                    OldCaseNumber = dataReader["OldCaseNumber"] as string,
                    DoNotContact = (dataReader["DoNotContact"] as sbyte? ?? 0) == 1,
                    
                    ReferenceNumber = dataReader["ReferenceNumber"] as string,

                    DomainName = dataReader["DomainName"] as string,
                    Description = dataReader["Description"] as string,
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
            var entity  = (Enquiry)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pRecordType", MySqlDbType.VarChar, 100) { Value = entity.RecordType, Direction = ParameterDirection.Input },

                new MySqlParameter("pNegotiationBFAmount", MySqlDbType.VarChar, 100) { Value = entity.NegotiationBFAmount, Direction = ParameterDirection.Input },
                new MySqlParameter("pNegotiation3rdPartyAmount", MySqlDbType.VarChar, 100) { Value = entity.Negotiation3rdPartyAmount, Direction = ParameterDirection.Input },
                new MySqlParameter("pOldCaseNumber", MySqlDbType.VarChar, 100) { Value = entity.OldCaseNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pPriority", MySqlDbType.VarChar, 45) { Value = entity.Priority, Direction = ParameterDirection.Input },
                new MySqlParameter("pStatus", MySqlDbType.VarChar, 100) { Value = entity.Status, Direction = ParameterDirection.Input },
                new MySqlParameter("pSendEmail", entity.SendEmail ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pUnreadEmail", entity.UnreadEmail ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pDoNotContact", entity.DoNotContact ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pSubject", MySqlDbType.VarChar, 100) { Value = entity.Subject, Direction = ParameterDirection.Input },
                new MySqlParameter("pPercentOfCompletion", MySqlDbType.VarChar, 100) { Value = entity.PercentOfCompletion, Direction = ParameterDirection.Input },
                new MySqlParameter("pCaseAssign", MySqlDbType.VarChar, 45) { Value = entity.CaseAssign, Direction = ParameterDirection.Input },

                new MySqlParameter("pPrivateRegistrationEmail", MySqlDbType.VarChar, 100) { Value = entity.PrivateRegistrationEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrant", MySqlDbType.VarChar, 100) { Value = entity.Registrant, Direction = ParameterDirection.Input },
                new MySqlParameter("pCaseOrigin", MySqlDbType.VarChar, 45) { Value = entity.CaseOrigin, Direction = ParameterDirection.Input },
                new MySqlParameter("pReferenceNumber", MySqlDbType.VarChar, 100) { Value = entity.ReferenceNumber, Direction = ParameterDirection.Input },

                new MySqlParameter("pDomainName", MySqlDbType.VarChar, 100) { Value = entity.DomainName, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantCompanyID", MySqlDbType.Int32) { Value = entity.RegistrantCompany?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantID", MySqlDbType.Int32) { Value = entity.Registrar?.ID, Direction = ParameterDirection.Input },
                new MySqlParameter("pRegistrantEmail", MySqlDbType.VarChar, 100) { Value = entity.RegistrantEmail, Direction = ParameterDirection.Input },
                new MySqlParameter("pStreet", MySqlDbType.VarChar, 100) { Value = entity.Street, Direction = ParameterDirection.Input },
                new MySqlParameter("pCity", MySqlDbType.VarChar, 100) { Value = entity.City, Direction = ParameterDirection.Input },
                new MySqlParameter("pState", MySqlDbType.VarChar, 100) { Value = entity.State, Direction = ParameterDirection.Input },
                new MySqlParameter("pCountry", MySqlDbType.VarChar, 100) { Value = entity.Country, Direction = ParameterDirection.Input },
                new MySqlParameter("pPostalCode", MySqlDbType.VarChar, 45) { Value = entity.PostalCode, Direction = ParameterDirection.Input },
                new MySqlParameter("pPhone", MySqlDbType.VarChar, 45) { Value = entity.Phone, Direction = ParameterDirection.Input },
                new MySqlParameter("pFax", MySqlDbType.VarChar, 45) { Value = entity.Fax, Direction = ParameterDirection.Input },
                new MySqlParameter("pDescription", MySqlDbType.VarChar, 255) { Value = entity.Description, Direction = ParameterDirection.Input },

                new MySqlParameter("pFieldNames", MySqlDbType.VarChar, 255) { Value = entity.FieldNames, Direction = ParameterDirection.Input },
                new MySqlParameter("pInternalComments", MySqlDbType.VarChar, 255) { Value = entity.InternalComments, Direction = ParameterDirection.Input },
                new MySqlParameter("pObjectNames", MySqlDbType.VarChar, 255) { Value = entity.ObjectNames, Direction = ParameterDirection.Input },
                new MySqlParameter("pTechnicalAssessment", MySqlDbType.VarChar, 255) { Value = entity.TechnicalAssessment, Direction = ParameterDirection.Input },

                new MySqlParameter("pTestPlan", MySqlDbType.VarChar, 255) { Value = entity.TestPlan, Direction = ParameterDirection.Input },
                new MySqlParameter("pStepsToTest", MySqlDbType.VarChar, 255) { Value = entity.StepsToTest, Direction = ParameterDirection.Input },
                new MySqlParameter("pTestOutcome", MySqlDbType.VarChar, 255) { Value = entity.TestOutcome, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

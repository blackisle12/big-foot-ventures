using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace BigFootVentures.Business.DataAccess.Mapping.Management
{
    public sealed class CompanyMapper : IMapper
    {
        #region "Public Methods"

        public ICollection<object> ParseData(MySqlDataReader dataReader)
        {
            var entities = new List<object>();

            while (dataReader.Read())
            {
                var entity = new Company
                {
                    ID = (int)dataReader["ID"],

                    AccountRecordType = dataReader["AccountRecordType"] as string,
                    AccountOwner = dataReader["AccountOwner"] as string,
                    
                    DisplayName = dataReader["DISPLAYNAME"] as string,

                    CompanyName = dataReader["NAME"] as string,
                    FormerName = dataReader["FORMER NAME"] as string,

                    LastName = dataReader["LASTNAME"] as string,
                    FirstName = dataReader["FIRSTNAME"] as string,
                    MiddleName = dataReader["MIDDLENAME"] as string,
                    Suffix = dataReader["SUFFIX"] as string,
                    Title = dataReader["PERSONTITLE"] as string,
                    Salutation = dataReader["SALUTATION"] as string,

                    Type = dataReader["TYPE"] as string,
                    Description = dataReader["DESCRIPTION"] as string,

                    Phone = dataReader["PHONE"] as string,
                    Mobile = dataReader["PERSONMOBILEPHONE"] as string,
                    Fax = dataReader["FAX"] as string,
                    Email = dataReader["EMAIL"] as string,

                    Industry = dataReader["INDUSTRY"] as string,
                    Employees = dataReader["NUMBEROFEMPLOYEES"] as string,

                    NameID = dataReader["NAME ID"] as string,
                    OfficeIDOHIM = dataReader["OFFICE ID OHIM"] as string,
                    OfficeIDGB = dataReader["OFFICE ID"] as string,
                    OHIMNumTrademarks = dataReader["OHIM NUM TRADEMARKS"] as string,
                    OHIMNUMOppositions = dataReader["OHIM NUM OPPOSITIONS"] as string,
                    OHIMOwnerID = dataReader["OHIM OWNER ID"] as string,
                    AddressType = dataReader["ADDRESS TYPE"] as string,
                    CompanySize = dataReader["COMPANY SIZE"] as string,
                    EscrowAgent = (dataReader["ESCROW AGENT"] as sbyte? ?? 0) == 1,
                    Broker = (dataReader["BROKER"] as sbyte? ?? 0) == 1,

                    DeletionRequest = dataReader["DELETION REQUEST"] as string,
                    DeletionRequestReason = dataReader["DELETION REQUEST REASOND"] as string,

                    CompanyRegistrationNumber = dataReader["COMPANY REGISTRATION NUMBER"] as string,
                    CountryOfIncorporation = dataReader["COUNTRY OF INCORPORATION"] as string,
                    DateOfIncorporation = dataReader["DATE OF INCORPORATION"] as string,
                    TaxNumber = dataReader["TAX NUMBER"] as string,
                    Officers = dataReader["OFFICERS"] as string,

                    TMFilingCost = dataReader["TM FILING COST"] as string,
                    TMCancellationCost = dataReader["TM CANCELLATION COST"] as string,
                    TMOppositionCost = dataReader["TM OPPOSITION COST"] as string,
                    TMPriorityCost = dataReader["TM PRIORITY COST"] as string,
                    TMRegistrationCertificateCost = dataReader["TM REGISTRATION CERTIFICATE COST"] as string,
                    TMResearchCost = dataReader["TM RESEARCH COST"] as string,
                    OtherCosts = dataReader["OTHER COSTS"] as string,
                    
                    BigFootAccredited = (dataReader["BIGFOOT ACCREDITED"] as sbyte? ?? 0) == 1,
                    BigFootGroup = (dataReader["BIGFOOT GROUP"] as sbyte? ?? 0) == 1,

                    ShippingCountry = dataReader["SHIPPINGCOUNTRY"] as string,
                    ShippingStreet = dataReader["SHIPPINGSTREET"] as string,
                    ShippingCity = dataReader["SHIPPINGCITY"] as string,
                    ShippingState = dataReader["SHIPPINGSTATE"] as string,
                    ShippingPostalCode = dataReader["SHIPPINGPOSTALCODE"] as string
                };

                if (int.TryParse((dataReader["ParentAccountID"] as int?)?.ToString(), out int parentAccountID))
                {
                    entity.ParentAccount = new Company { ID = parentAccountID };
                }

                entities.Add(entity);
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object model)
        {
            var entity = (Company)model;
            var parameters = new List<MySqlParameter>();

            parameters.AddRange(new MySqlParameter[]
            {
                new MySqlParameter("pAccountRecordType", MySqlDbType.VarChar, 100) { Value = entity.AccountRecordType, Direction = ParameterDirection.Input },

                new MySqlParameter("pCompanyName", MySqlDbType.VarChar, 100) { Value = entity.CompanyName, Direction = ParameterDirection.Input },
                new MySqlParameter("pFormerName", MySqlDbType.VarChar, 100) { Value = entity.FormerName, Direction = ParameterDirection.Input },

                new MySqlParameter("pParentAccountID", MySqlDbType.Int32) { Value = entity.ParentAccount?.ID, Direction = ParameterDirection.Input },

                new MySqlParameter("pLastName", MySqlDbType.VarChar, 100) { Value = entity.LastName, Direction = ParameterDirection.Input },
                new MySqlParameter("pFirstName", MySqlDbType.VarChar, 100) { Value = entity.FirstName, Direction = ParameterDirection.Input },
                new MySqlParameter("pMiddleName", MySqlDbType.VarChar, 100) { Value = entity.MiddleName, Direction = ParameterDirection.Input },
                new MySqlParameter("pSuffix", MySqlDbType.VarChar, 100) { Value = entity.Suffix, Direction = ParameterDirection.Input },
                new MySqlParameter("pTitle", MySqlDbType.VarChar, 100) { Value = entity.Title, Direction = ParameterDirection.Input },
                new MySqlParameter("pSalutation", MySqlDbType.VarChar, 100) { Value = entity.Salutation, Direction = ParameterDirection.Input },

                new MySqlParameter("pType", MySqlDbType.VarChar, 100) { Value = entity.Type, Direction = ParameterDirection.Input },
                new MySqlParameter("pDescription", MySqlDbType.VarChar, 255) { Value = entity.Description, Direction = ParameterDirection.Input },

                new MySqlParameter("pPhone", MySqlDbType.VarChar, 100) { Value = entity.Phone, Direction = ParameterDirection.Input },
                new MySqlParameter("pMobile", MySqlDbType.VarChar, 100) { Value = entity.Mobile, Direction = ParameterDirection.Input },
                new MySqlParameter("pFax", MySqlDbType.VarChar, 100) { Value = entity.Fax, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmail", MySqlDbType.VarChar, 100) { Value = entity.Email, Direction = ParameterDirection.Input },

                new MySqlParameter("pIndustry", MySqlDbType.VarChar, 100) { Value = entity.Industry, Direction = ParameterDirection.Input },
                new MySqlParameter("pEmployees", MySqlDbType.VarChar, 100) { Value = entity.Employees, Direction = ParameterDirection.Input },

                new MySqlParameter("pNameID", MySqlDbType.VarChar, 100) { Value = entity.NameID, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeIDOHIM", MySqlDbType.VarChar, 100) { Value = entity.OfficeIDOHIM, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficeIDGB", MySqlDbType.VarChar, 100) { Value = entity.OfficeIDGB, Direction = ParameterDirection.Input },
                new MySqlParameter("pOHIMNumTrademarks", MySqlDbType.VarChar, 100) { Value = entity.OHIMNumTrademarks, Direction = ParameterDirection.Input },
                new MySqlParameter("pOHIMNumOppositions", MySqlDbType.VarChar, 100) { Value = entity.OHIMNUMOppositions, Direction = ParameterDirection.Input },
                new MySqlParameter("pOHIMOwnerID", MySqlDbType.VarChar, 100) { Value = entity.OHIMOwnerID, Direction = ParameterDirection.Input },
                new MySqlParameter("pAddressType", MySqlDbType.VarChar, 100) { Value = entity.AddressType, Direction = ParameterDirection.Input },
                new MySqlParameter("pCompanySize", MySqlDbType.VarChar, 100) { Value = entity.CompanySize, Direction = ParameterDirection.Input },
                new MySqlParameter("pEscrowAgent", entity.EscrowAgent ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pBroker", entity.Broker ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pDeletionRequest", MySqlDbType.VarChar, 100) { Value = entity.DeletionRequestChk, Direction = ParameterDirection.Input },
                new MySqlParameter("pDeletionRequestReason", MySqlDbType.VarChar, 255) { Value = entity.DeletionRequestReason, Direction = ParameterDirection.Input },

                new MySqlParameter("pCompanyRegistrationNumber", MySqlDbType.VarChar, 100) { Value = entity.CompanyRegistrationNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pCountryOfIncorporation", MySqlDbType.VarChar, 100) { Value = entity.CountryOfIncorporation, Direction = ParameterDirection.Input },
                new MySqlParameter("pDateOfIncorporation", MySqlDbType.VarChar, 100) { Value = entity.DateOfIncorporation, Direction = ParameterDirection.Input },
                new MySqlParameter("pTaxNumber", MySqlDbType.VarChar, 100) { Value = entity.TaxNumber, Direction = ParameterDirection.Input },
                new MySqlParameter("pOfficers", MySqlDbType.VarChar, 100) { Value = entity.Officers, Direction = ParameterDirection.Input },

                new MySqlParameter("pTMFilingCost", MySqlDbType.VarChar, 100) { Value = entity.TMFilingCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMCancellationCost", MySqlDbType.VarChar, 100) { Value = entity.TMCancellationCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMOppositionCost", MySqlDbType.VarChar, 100) { Value = entity.TMOppositionCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMPriorityCost", MySqlDbType.VarChar, 100) { Value = entity.TMPriorityCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMRegistrationCertificateCost", MySqlDbType.VarChar, 100) { Value = entity.TMRegistrationCertificateCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pTMResearchCost", MySqlDbType.VarChar, 100) { Value = entity.TMResearchCost, Direction = ParameterDirection.Input },
                new MySqlParameter("pOtherCosts", MySqlDbType.VarChar, 255) { Value = entity.OtherCosts, Direction = ParameterDirection.Input },

                new MySqlParameter("pBigFootAccredited", entity.BigFootAccredited ? 1 : 0) { Direction = ParameterDirection.Input },
                new MySqlParameter("pBigFootGroup", entity.BigFootGroup ? 1 : 0) { Direction = ParameterDirection.Input },

                new MySqlParameter("pShippingCountry", MySqlDbType.VarChar, 100) { Value = entity.ShippingCountry, Direction = ParameterDirection.Input },
                new MySqlParameter("pShippingStreet", MySqlDbType.VarChar, 255) { Value = entity.ShippingStreet, Direction = ParameterDirection.Input },
                new MySqlParameter("pShippingCity", MySqlDbType.VarChar, 100) { Value = entity.ShippingCity, Direction = ParameterDirection.Input },
                new MySqlParameter("pShippingState", MySqlDbType.VarChar, 100) { Value = entity.ShippingState, Direction = ParameterDirection.Input },
                new MySqlParameter("pShippingPostalCode", MySqlDbType.VarChar, 100) { Value = entity.ShippingPostalCode, Direction = ParameterDirection.Input },
            });

            return parameters.ToArray();
        }

        #endregion
    }
}

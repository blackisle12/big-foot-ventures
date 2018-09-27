using BigFootVentures.Business.Objects.Management;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

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
                entities.Add(new Company
                {
                    ID = (int)dataReader["ID"],
                    AccountRecordType = dataReader["AccountRecordType"] as string,
                    AccountOwner = dataReader["AccountOwner"] as string,
                    //ParentAccountID

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
                    //EscrowAgent = ((sbyte)dataReader["ESCROW AGENT"] == 1)
                    //Broker

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
                    //bigfootaccredited
                    //bigfootgroup

                    ShippingCountry = dataReader["SHIPPINGCOUNTRY"] as string,
                    ShippingStreet = dataReader["SHIPPINGSTREET"] as string,
                    ShippingCity = dataReader["SHIPPINGCITY"] as string,
                    ShippingState = dataReader["SHIPPINGSTATE"] as string,
                    ShippingPostalCode = dataReader["SHIPPINGPOSTALCODE"] as string
                });
            }

            return entities;
        }

        public MySqlParameter[] CreateParameters(object entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

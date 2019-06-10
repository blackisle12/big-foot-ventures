using System;
using System.Linq;
using System.Text;
using TinyCsvParser;
using TinyCsvParser.Mapping;

namespace BigFootVentures.Application.CSVParser
{
    public class Account
    {
        public string AccountID { get; set; }

        public string Salutation { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Suffix { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }
        public string RecordTypeID { get; set; }
        public string ParentID { get; set; }

        public string BillingStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        public string BillingStateCode { get; set; }
        public string BillingCountryCode { get; set; }

        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        public string ShippingStateCode { get; set; }
        public string ShippingCountryCode { get; set; }

        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }

        public string OwnerID { get; set; }

        public DateTime CreateDate { get; set; }
        public string CreatedByID { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string LastModifiedByID { get; set; }

        public string PersonContactID { get; set; }

        public int? OfficeIDOHIM { get; set; }
        public int? OHIMNumTrademarks { get; set; }
        public string AddressType { get; set; }
        public string NameID { get; set; }
        public int? CompanySize { get; set; }
        public string FormerName { get; set; }
        public int? OHIMNumOppositions { get; set; }
        public string OfficeIDGB { get; set; }
        public string CompanyRegistrationNumber { get; set; }
        public string Email { get; set; }
        public bool? BigfootGroup { get; set; }
        public DateTime? DateOfIncorporation { get; set; }
        public bool? EscrowAgent { get; set; }
        public bool? BigfootGroupOwned { get; set; }
        public bool? Broker { get; set; }
        public string CountryOfIncorporation { get; set; }
        public string TaxNumber { get; set; }
        public string Officers { get; set; }

        public string TMFilingCost { get; set; }
        public string TMResearchCost { get; set; }
        public string TMRegistrationCertificateCost { get; set; }
        public string TMPriorityCost { get; set; }
        public string TMOppositionCost { get; set; }
        public string TMCancellationCost { get; set; }
        public string OtherCosts { get; set; }

        public bool? BigfootAccredited { get; set; } = false;

        public bool? IsPersonAccount { get; set; } = false;

        public bool? DeletionRequest { get; set; }
        public string DeletionRequestReason { get; set; }
    }

    public class CsvAccountMapping : CsvMapping<Account>
    {
        public CsvAccountMapping() : base()
        {
            MapProperty(0, a => a.AccountID);

            MapProperty(3, a => a.Salutation);
            MapProperty(4, a => a.FirstName);
            MapProperty(5, a => a.LastName);
            MapProperty(6, a => a.MiddleName);
            MapProperty(7, a => a.Suffix);

            MapProperty(8, a => a.Name);

            MapProperty(9, a => a.Type);
            MapProperty(10, a => a.RecordTypeID);
            MapProperty(11, a => a.ParentID);

            MapProperty(12, a => a.BillingStreet);
            MapProperty(13, a => a.BillingCity);
            MapProperty(14, a => a.BillingState);
            MapProperty(15, a => a.BillingPostalCode);
            MapProperty(16, a => a.BillingCountry);
            MapProperty(17, a => a.BillingStateCode);
            MapProperty(18, a => a.BillingCountryCode);

            MapProperty(22, a => a.ShippingStreet);
            MapProperty(23, a => a.ShippingCity);
            MapProperty(24, a => a.ShippingState);
            MapProperty(25, a => a.ShippingPostalCode);
            MapProperty(26, a => a.ShippingCountry);
            MapProperty(27, a => a.ShippingStateCode);
            MapProperty(28, a => a.ShippingCountryCode);

            MapProperty(32, a => a.Phone);
            MapProperty(33, a => a.Fax);
            MapProperty(37, a => a.Industry);
            MapProperty(42, a => a.Description);

            MapProperty(45, a => a.OwnerID);

            MapProperty(46, a => a.CreateDate);
            MapProperty(47, a => a.CreatedByID);
            MapProperty(48, a => a.LastModifiedDate);
            MapProperty(49, a => a.LastModifiedByID);

            MapProperty(52, a => a.PersonContactID);

            MapProperty(57, a => a.OfficeIDOHIM);
            MapProperty(58, a => a.OHIMNumTrademarks);
            MapProperty(59, a => a.AddressType);
            MapProperty(61, a => a.NameID);
            MapProperty(62, a => a.CompanySize);
            MapProperty(64, a => a.FormerName);
            MapProperty(65, a => a.OHIMNumOppositions);
            MapProperty(66, a => a.OfficeIDGB);
            MapProperty(67, a => a.CompanyRegistrationNumber);
            MapProperty(68, a => a.Email);
            MapProperty(69, a => a.BigfootGroup);
            MapProperty(70, a => a.DateOfIncorporation);
            MapProperty(71, a => a.EscrowAgent);
            MapProperty(72, a => a.BigfootGroupOwned);
            MapProperty(73, a => a.Broker);
            MapProperty(74, a => a.CountryOfIncorporation);
            MapProperty(75, a => a.TaxNumber);
            MapProperty(76, a => a.Officers);

            MapProperty(77, a => a.TMFilingCost);
            MapProperty(78, a => a.TMResearchCost);
            MapProperty(79, a => a.TMRegistrationCertificateCost);
            MapProperty(80, a => a.TMPriorityCost);
            MapProperty(81, a => a.TMOppositionCost);
            MapProperty(82, a => a.TMCancellationCost);
            MapProperty(83, a => a.OtherCosts);

            MapProperty(84, a => a.BigfootAccredited);

            MapProperty(85, a => a.IsPersonAccount);

            MapProperty(60, a => a.DeletionRequest);
            MapProperty(63, a => a.DeletionRequestReason);
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var csvParser = new CsvParser<Account>(
                new CsvParserOptions(true, ','), 
                new CsvAccountMapping());

            var records = csvParser.ReadFromFile("C:\\Users\\angelo.tupaz\\Downloads\\bigfoot-data\\Account.csv", Encoding.UTF8);
            var count = 0;

            foreach(var record in records)
            {
                //Console.WriteLine(record.Result.Name);
                count += 1;
            }

            Console.WriteLine(count);

            Console.ReadKey(true);
        }
    }
}

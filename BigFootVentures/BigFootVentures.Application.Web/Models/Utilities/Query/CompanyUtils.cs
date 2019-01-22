using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class CompanyUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string name = null, string accountRecordType = null, string formerName = null, string type = null, string parentAccount = null, string phone = null, string fax = null, string email = null,
            string companySize = null, string industry = null, string nameID = null, string employees = null, string officeIDGB = null, string OHIMNumOppositions = null, string escrowAgent = null,
            string broker = null, string companyRegistrationNumber = null, string countryOfIncorporation = null, string officers = null, string taxNumber = null, string bigFootAccredited = null,
            string shippingCountry = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount,
                name, accountRecordType, formerName, type, parentAccount, phone, fax, email,
                companySize, industry, nameID, employees, officeIDGB, OHIMNumOppositions, escrowAgent,
                broker, companyRegistrationNumber, countryOfIncorporation, officers, taxNumber, bigFootAccredited, shippingCountry);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                name, accountRecordType, formerName, type, parentAccount, phone, fax, email,
                companySize, industry, nameID, employees, officeIDGB, OHIMNumOppositions, escrowAgent,
                broker, companyRegistrationNumber, countryOfIncorporation, officers, taxNumber, bigFootAccredited, shippingCountry);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string name = null, string accountRecordType = null, string formerName = null, string type = null, string parentAccount = null, string phone = null,
            string fax = null, string email = null, string companySize = null, string industry = null, string nameID = null, string employees = null, string officeIDGB = null, string OHIMNumOppositions = null, 
            string escrowAgent = null, string broker = null, string companyRegistrationNumber = null, string countryOfIncorporation = null, string officers = null, string taxNumber = null, 
            string bigFootAccredited = null, string shippingCountry = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("C.*, ");
            query.Append("CASE WHEN C.NAME IS NOT NULL THEN C.NAME ELSE CONCAT_WS('''' '''', C.LASTNAME, C.FIRSTNAME) END AS DISPLAYNAME ");
            query.Append("FROM Company C ");
            query.Append("LEFT JOIN Company CP ON C.ParentAccountID = CP.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND C.NAME LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(accountRecordType))
            {
                query.Append($"AND C.AccountRecordType LIKE '%{accountRecordType}%' ");
            }

            if (!string.IsNullOrWhiteSpace(formerName))
            {
                query.Append($"AND C.`FORMER NAME` LIKE '%{formerName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND C.TYPE LIKE '%{type}%' ");
            }

            if (!string.IsNullOrWhiteSpace(parentAccount))
            {
                query.Append($"AND CP.NAME LIKE '%{parentAccount}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.PHONE LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.FAX LIKE '%{fax}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.EMAIL LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companySize))
            {
                query.Append($"AND C.`COMPANY SIZE` LIKE '%{companySize}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND C.INDUSTRY LIKE '%{industry}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nameID))
            {
                query.Append($"AND C.`NAME ID` LIKE '%{nameID}%' ");
            }

            if (!string.IsNullOrWhiteSpace(employees))
            {
                query.Append($"AND C.EMPLOYEES LIKE '%{employees}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeIDGB))
            {
                query.Append($"AND C.`OFFICE ID OHIM` LIKE '%{officeIDGB}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumOppositions))
            {
                query.Append($"AND C.`OHIM NUM OPPOSITIONS` LIKE '%{OHIMNumOppositions}%' ");
            }

            if (!string.IsNullOrWhiteSpace(escrowAgent))
            {
                query.Append($"AND C.`ESCROW AGENT` = {escrowAgent} ");
            }

            if (!string.IsNullOrWhiteSpace(broker))
            {
                query.Append($"AND C.BROKER = {broker} ");
            }

            if (!string.IsNullOrWhiteSpace(companyRegistrationNumber))
            {
                query.Append($"AND C.`COMPANY REGISTRATION NUMBER` LIKE '%{companyRegistrationNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(countryOfIncorporation))
            {
                query.Append($"AND C.`COUNTRY OF INCORPORATION` LIKE '%{countryOfIncorporation}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officers))
            {
                query.Append($"AND C.OFFICERS LIKE '%{officers}%' ");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber))
            {
                query.Append($"AND C.`TAX NUMBER` LIKE '%{taxNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootAccredited))
            {
                query.Append($"AND C.`BIGFOOT ACCREDITED` = {bigFootAccredited} ");
            }

            if (!string.IsNullOrWhiteSpace(shippingCountry))
            {
                query.Append($"AND C.SHIPPINGCOUNTRY LIKE '%{shippingCountry}%' ");
            }

            query.Append("ORDER BY C.NAME");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string accountRecordType = null, string formerName = null, string type = null, string parentAccount = null, string phone = null,
            string fax = null, string email = null, string companySize = null, string industry = null, string nameID = null, string employees = null, string officeIDGB = null, string OHIMNumOppositions = null,
            string escrowAgent = null, string broker = null, string companyRegistrationNumber = null, string countryOfIncorporation = null, string officers = null, string taxNumber = null,
            string bigFootAccredited = null, string shippingCountry = null)
        {
            query.Append("C.*, ");
            query.Append("CASE WHEN C.NAME IS NOT NULL THEN C.NAME ELSE CONCAT_WS('''' '''', C.LASTNAME, C.FIRSTNAME) END AS DISPLAYNAME ");
            query.Append("FROM Company C ");
            query.Append("LEFT JOIN Company CP ON C.ParentAccountID = CP.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND C.NAME LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(accountRecordType))
            {
                query.Append($"AND C.AccountRecordType LIKE '%{accountRecordType}%' ");
            }

            if (!string.IsNullOrWhiteSpace(formerName))
            {
                query.Append($"AND C.`FORMER NAME` LIKE '%{formerName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND C.TYPE LIKE '%{type}%' ");
            }

            if (!string.IsNullOrWhiteSpace(parentAccount))
            {
                query.Append($"AND CP.NAME LIKE '%{parentAccount}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.PHONE LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.FAX LIKE '%{fax}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.EMAIL LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companySize))
            {
                query.Append($"AND C.`COMPANY SIZE` LIKE '%{companySize}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND C.INDUSTRY LIKE '%{industry}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nameID))
            {
                query.Append($"AND C.`NAME ID` LIKE '%{nameID}%' ");
            }

            if (!string.IsNullOrWhiteSpace(employees))
            {
                query.Append($"AND C.EMPLOYEES LIKE '%{employees}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeIDGB))
            {
                query.Append($"AND C.`OFFICE ID OHIM` LIKE '%{officeIDGB}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumOppositions))
            {
                query.Append($"AND C.`OHIM NUM OPPOSITIONS` LIKE '%{OHIMNumOppositions}%' ");
            }

            if (!string.IsNullOrWhiteSpace(escrowAgent))
            {
                query.Append($"AND C.`ESCROW AGENT` = {escrowAgent} ");
            }

            if (!string.IsNullOrWhiteSpace(broker))
            {
                query.Append($"AND C.BROKER = {broker} ");
            }

            if (!string.IsNullOrWhiteSpace(companyRegistrationNumber))
            {
                query.Append($"AND C.`COMPANY REGISTRATION NUMBER` LIKE '%{companyRegistrationNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(countryOfIncorporation))
            {
                query.Append($"AND C.`COUNTRY OF INCORPORATION` LIKE '%{countryOfIncorporation}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officers))
            {
                query.Append($"AND C.OFFICERS LIKE '%{officers}%' ");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber))
            {
                query.Append($"AND C.`TAX NUMBER` LIKE '%{taxNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootAccredited))
            {
                query.Append($"AND C.`BIGFOOT ACCREDITED` = {bigFootAccredited} ");
            }

            if (!string.IsNullOrWhiteSpace(shippingCountry))
            {
                query.Append($"AND C.SHIPPINGCOUNTRY LIKE '%{shippingCountry}%' ");
            }

            query.Append($"ORDER BY C.NAME LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string name = null, string accountRecordType = null, string formerName = null, string type = null, string parentAccount = null, string phone = null,
            string fax = null, string email = null, string companySize = null, string industry = null, string nameID = null, string employees = null, string officeIDGB = null, string OHIMNumOppositions = null,
            string escrowAgent = null, string broker = null, string companyRegistrationNumber = null, string countryOfIncorporation = null, string officers = null, string taxNumber = null,
            string bigFootAccredited = null, string shippingCountry = null)
        {
            query.Append("COUNT(C.ID) INTO @total ");
            query.Append("FROM Company C ");
            query.Append("LEFT JOIN Company CP ON C.ParentAccountID = CP.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND C.NAME LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(accountRecordType))
            {
                query.Append($"AND C.AccountRecordType LIKE '%{accountRecordType}%' ");
            }

            if (!string.IsNullOrWhiteSpace(formerName))
            {
                query.Append($"AND C.`FORMER NAME` LIKE '%{formerName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND C.TYPE LIKE '%{type}%' ");
            }

            if (!string.IsNullOrWhiteSpace(parentAccount))
            {
                query.Append($"AND CP.NAME LIKE '%{parentAccount}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.PHONE LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.FAX LIKE '%{fax}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.EMAIL LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companySize))
            {
                query.Append($"AND C.`COMPANY SIZE` LIKE '%{companySize}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND C.INDUSTRY LIKE '%{industry}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nameID))
            {
                query.Append($"AND C.`NAME ID` LIKE '%{nameID}%' ");
            }

            if (!string.IsNullOrWhiteSpace(employees))
            {
                query.Append($"AND C.EMPLOYEES LIKE '%{employees}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeIDGB))
            {
                query.Append($"AND C.`OFFICE ID OHIM` LIKE '%{officeIDGB}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumOppositions))
            {
                query.Append($"AND C.`OHIM NUM OPPOSITIONS` LIKE '%{OHIMNumOppositions}%' ");
            }

            if (!string.IsNullOrWhiteSpace(escrowAgent))
            {
                query.Append($"AND C.`ESCROW AGENT` = {escrowAgent} ");
            }

            if (!string.IsNullOrWhiteSpace(broker))
            {
                query.Append($"AND C.BROKER = {broker} ");
            }

            if (!string.IsNullOrWhiteSpace(companyRegistrationNumber))
            {
                query.Append($"AND C.`COMPANY REGISTRATION NUMBER` LIKE '%{companyRegistrationNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(countryOfIncorporation))
            {
                query.Append($"AND C.`COUNTRY OF INCORPORATION` LIKE '%{countryOfIncorporation}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officers))
            {
                query.Append($"AND C.OFFICERS LIKE '%{officers}%' ");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber))
            {
                query.Append($"AND C.`TAX NUMBER` LIKE '%{taxNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootAccredited))
            {
                query.Append($"AND C.`BIGFOOT ACCREDITED` = {bigFootAccredited} ");
            }

            if (!string.IsNullOrWhiteSpace(shippingCountry))
            {
                query.Append($"AND C.SHIPPINGCOUNTRY LIKE '%{shippingCountry}%' ");
            }

            return query;
        }

        #endregion
    }
}
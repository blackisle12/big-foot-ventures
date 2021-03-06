﻿using System;
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
            query.Append("CONCAT(IFNULL(C.NAME, ''), IFNULL(C.FIRSTNAME, ''), ' ', IFNULL(C.LASTNAME, '')) AS DISPLAYNAME ");
            query.Append("FROM Company C ");
            query.Append("LEFT JOIN Company CP ON C.ParentAccountID = CP.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND (C.NAME LIKE '%{name.Replace("'", "''")}%' OR C.FIRSTNAME LIKE '%{name.Replace("'", "''")}%' OR C.LASTNAME LIKE '%{name.Replace("'", "''")}%' OR CONCAT(C.FIRSTNAME, ' ', C.LASTNAME) LIKE '%{name.Replace("'", "''")}%') ");
            }

            if (!string.IsNullOrWhiteSpace(accountRecordType))
            {
                query.Append($"AND C.AccountRecordType LIKE '%{accountRecordType.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(formerName))
            {
                query.Append($"AND C.`FORMER NAME` LIKE '%{formerName.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND C.TYPE LIKE '%{type.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(parentAccount))
            {
                query.Append($"AND CP.NAME LIKE '%{parentAccount.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.PHONE LIKE '%{phone.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.FAX LIKE '%{fax.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.EMAIL LIKE '%{email.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companySize))
            {
                query.Append($"AND C.`COMPANY SIZE` LIKE '%{companySize.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND C.INDUSTRY LIKE '%{industry.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nameID))
            {
                query.Append($"AND C.`NAME ID` LIKE '%{nameID.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(employees))
            {
                query.Append($"AND C.EMPLOYEES LIKE '%{employees.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeIDGB))
            {
                query.Append($"AND C.`OFFICE ID OHIM` LIKE '%{officeIDGB.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumOppositions))
            {
                query.Append($"AND C.`OHIM NUM OPPOSITIONS` LIKE '%{OHIMNumOppositions.Replace("'", "''")}%' ");
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
                query.Append($"AND C.`COMPANY REGISTRATION NUMBER` LIKE '%{companyRegistrationNumber.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(countryOfIncorporation))
            {
                query.Append($"AND C.`COUNTRY OF INCORPORATION` LIKE '%{countryOfIncorporation.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officers))
            {
                query.Append($"AND C.OFFICERS LIKE '%{officers.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber))
            {
                query.Append($"AND C.`TAX NUMBER` LIKE '%{taxNumber.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootAccredited))
            {
                query.Append($"AND C.`BIGFOOT ACCREDITED` = {bigFootAccredited} ");
            }

            if (!string.IsNullOrWhiteSpace(shippingCountry))
            {
                query.Append($"AND C.SHIPPINGCOUNTRY LIKE '%{shippingCountry.Replace("'", "''")}%' ");
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
            query.Append("CONCAT(IFNULL(C.NAME, ''), IFNULL(C.FIRSTNAME, ''), ' ', IFNULL(C.LASTNAME, '')) AS DISPLAYNAME ");
            query.Append("FROM Company C ");
            query.Append("LEFT JOIN Company CP ON C.ParentAccountID = CP.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND (C.NAME LIKE '%{name.Replace("'", "''")}%' OR C.FIRSTNAME LIKE '%{name.Replace("'", "''")}%' OR C.LASTNAME LIKE '%{name.Replace("'", "''")}%' OR CONCAT(C.FIRSTNAME, ' ', C.LASTNAME) LIKE '%{name.Replace("'", "''")}%') ");
            }

            if (!string.IsNullOrWhiteSpace(accountRecordType))
            {
                query.Append($"AND C.AccountRecordType LIKE '%{accountRecordType.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(formerName))
            {
                query.Append($"AND C.`FORMER NAME` LIKE '%{formerName.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND C.TYPE LIKE '%{type.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(parentAccount))
            {
                query.Append($"AND CP.NAME LIKE '%{parentAccount.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.PHONE LIKE '%{phone.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.FAX LIKE '%{fax.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.EMAIL LIKE '%{email.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companySize))
            {
                query.Append($"AND C.`COMPANY SIZE` LIKE '%{companySize.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND C.INDUSTRY LIKE '%{industry.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nameID))
            {
                query.Append($"AND C.`NAME ID` LIKE '%{nameID.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(employees))
            {
                query.Append($"AND C.EMPLOYEES LIKE '%{employees.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeIDGB))
            {
                query.Append($"AND C.`OFFICE ID OHIM` LIKE '%{officeIDGB.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumOppositions))
            {
                query.Append($"AND C.`OHIM NUM OPPOSITIONS` LIKE '%{OHIMNumOppositions.Replace("'", "''")}%' ");
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
                query.Append($"AND C.`COMPANY REGISTRATION NUMBER` LIKE '%{companyRegistrationNumber.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(countryOfIncorporation))
            {
                query.Append($"AND C.`COUNTRY OF INCORPORATION` LIKE '%{countryOfIncorporation.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officers))
            {
                query.Append($"AND C.OFFICERS LIKE '%{officers.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber))
            {
                query.Append($"AND C.`TAX NUMBER` LIKE '%{taxNumber.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootAccredited))
            {
                query.Append($"AND C.`BIGFOOT ACCREDITED` = {bigFootAccredited} ");
            }

            if (!string.IsNullOrWhiteSpace(shippingCountry))
            {
                query.Append($"AND C.SHIPPINGCOUNTRY LIKE '%{shippingCountry.Replace("'", "''")}%' ");
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
                query.Append($"AND (C.NAME LIKE '%{name.Replace("'", "''")}%' OR C.FIRSTNAME LIKE '%{name.Replace("'", "''")}%' OR C.LASTNAME LIKE '%{name.Replace("'", "''")}%' OR CONCAT(C.FIRSTNAME, ' ', C.LASTNAME) LIKE '%{name.Replace("'", "''")}%') ");
            }

            if (!string.IsNullOrWhiteSpace(accountRecordType))
            {
                query.Append($"AND C.AccountRecordType LIKE '%{accountRecordType.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(formerName))
            {
                query.Append($"AND C.`FORMER NAME` LIKE '%{formerName.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND C.TYPE LIKE '%{type.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(parentAccount))
            {
                query.Append($"AND CP.NAME LIKE '%{parentAccount.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.PHONE LIKE '%{phone.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.FAX LIKE '%{fax.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.EMAIL LIKE '%{email.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companySize))
            {
                query.Append($"AND C.`COMPANY SIZE` LIKE '%{companySize.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND C.INDUSTRY LIKE '%{industry.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nameID))
            {
                query.Append($"AND C.`NAME ID` LIKE '%{nameID.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(employees))
            {
                query.Append($"AND C.EMPLOYEES LIKE '%{employees.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeIDGB))
            {
                query.Append($"AND C.`OFFICE ID OHIM` LIKE '%{officeIDGB.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumOppositions))
            {
                query.Append($"AND C.`OHIM NUM OPPOSITIONS` LIKE '%{OHIMNumOppositions.Replace("'", "''")}%' ");
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
                query.Append($"AND C.`COMPANY REGISTRATION NUMBER` LIKE '%{companyRegistrationNumber.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(countryOfIncorporation))
            {
                query.Append($"AND C.`COUNTRY OF INCORPORATION` LIKE '%{countryOfIncorporation.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officers))
            {
                query.Append($"AND C.OFFICERS LIKE '%{officers.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(taxNumber))
            {
                query.Append($"AND C.`TAX NUMBER` LIKE '%{taxNumber.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootAccredited))
            {
                query.Append($"AND C.`BIGFOOT ACCREDITED` = {bigFootAccredited} ");
            }

            if (!string.IsNullOrWhiteSpace(shippingCountry))
            {
                query.Append($"AND C.SHIPPINGCOUNTRY LIKE '%{shippingCountry.Replace("'", "''")}%' ");
            }

            return query;
        }

        #endregion
    }
}
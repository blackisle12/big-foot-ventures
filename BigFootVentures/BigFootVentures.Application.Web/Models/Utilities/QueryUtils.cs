using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class QueryUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildSearchAdvanceDomainQuery(int startIndex, int rowCount,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildSearchDomainQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, name, bigFootOwned, websiteCurrent, locked, websiteUse,
                    BFStrategy, buySideFunnel, FMVOrderOfMagnitude, companyWebsite, status, autoRenew, version, WHOIS, category);
            queryTotal = BuildSearchDomainTotalQuery(new StringBuilder().Append("SELECT "), name, bigFootOwned, websiteCurrent, locked, websiteUse,
                BFStrategy, buySideFunnel, FMVOrderOfMagnitude, companyWebsite, status, autoRenew, version, WHOIS, category);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildSearchDomainQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            query.Append("d.ID, d.Name, d.BigFootOwned, d.ExpirationDate, c.ID AS RegistrantID, c.NAME AS RegistrantName, ");
            query.Append("r.ID AS RegistrarID, r.Name AS RegistrarName ");
            query.Append("FROM DomainN d ");
            query.Append("LEFT JOIN Company c ON d.RegistrantID = c.ID ");
            query.Append("LEFT JOIN Register r ON d.RegistrarID = r.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND d.Name LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                query.Append($"AND d.BigFootOwned = {bigFootOwned} ");
            }

            if (!string.IsNullOrWhiteSpace(websiteCurrent))
            {
                query.Append($"AND d.WebsiteCurrent = {websiteCurrent} ");
            }

            if (!string.IsNullOrWhiteSpace(locked))
            {
                query.Append($"AND d.Locked = {locked} ");
            }

            if (!string.IsNullOrWhiteSpace(websiteUse))
            {
                query.Append($"AND d.WebsiteUse LIKE '%{websiteUse}%' ");
            }

            if (!string.IsNullOrWhiteSpace(BFStrategy))
            {
                query.Append($"AND d.BFStrategy LIKE '%{BFStrategy}%' ");
            }

            if (!string.IsNullOrWhiteSpace(buySideFunnel))
            {
                query.Append($"AND d.BuySideFunnel LIKE '%{buySideFunnel}%' ");
            }

            if (!string.IsNullOrWhiteSpace(FMVOrderOfMagnitude))
            {
                query.Append($"AND d.FMVOrderOfMagnitude LIKE '%{FMVOrderOfMagnitude}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companyWebsite))
            {
                query.Append($"AND d.CompanyWebsite = {companyWebsite} ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND d.Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(autoRenew))
            {
                query.Append($"AND d.AutoRenew = {autoRenew} ");
            }

            if (!string.IsNullOrWhiteSpace(version))
            {
                query.Append($"AND d.Version LIKE '%{version}%' ");
            }

            if (!string.IsNullOrWhiteSpace(WHOIS))
            {
                query.Append($"AND d.WHOIS LIKE '%{WHOIS}%' ");
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query.Append($"AND d.Category LIKE '%{category}%' ");
            }

            query.Append($"ORDER BY d.Name LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildSearchDomainTotalQuery(StringBuilder query,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM DomainN ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND Name LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                query.Append($"AND BigFootOwned = {bigFootOwned} ");
            }

            if (!string.IsNullOrWhiteSpace(websiteCurrent))
            {
                query.Append($"AND WebsiteCurrent = {websiteCurrent} ");
            }

            if (!string.IsNullOrWhiteSpace(locked))
            {
                query.Append($"AND Locked = {locked} ");
            }

            if (!string.IsNullOrWhiteSpace(websiteUse))
            {
                query.Append($"AND WebsiteUse LIKE '%{websiteUse}%' ");
            }

            if (!string.IsNullOrWhiteSpace(BFStrategy))
            {
                query.Append($"AND BFStrategy LIKE '%{BFStrategy}%' ");
            }

            if (!string.IsNullOrWhiteSpace(buySideFunnel))
            {
                query.Append($"AND BuySideFunnel LIKE '%{buySideFunnel}%' ");
            }

            if (!string.IsNullOrWhiteSpace(FMVOrderOfMagnitude))
            {
                query.Append($"AND FMVOrderOfMagnitude LIKE '%{FMVOrderOfMagnitude}%' ");
            }

            if (!string.IsNullOrWhiteSpace(companyWebsite))
            {
                query.Append($"AND CompanyWebsite = {companyWebsite} ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(autoRenew))
            {
                query.Append($"AND AutoRenew = {autoRenew} ");
            }

            if (!string.IsNullOrWhiteSpace(version))
            {
                query.Append($"AND Version LIKE '%{version}%' ");
            }

            if (!string.IsNullOrWhiteSpace(WHOIS))
            {
                query.Append($"AND WHOIS LIKE '%{WHOIS}%' ");
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query.Append($"AND Category LIKE '%{category}%' ");
            }

            return query;
        }

        #endregion
    }
}
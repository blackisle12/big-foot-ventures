using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class DomainUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, name, bigFootOwned, websiteCurrent, locked, websiteUse,
                    BFStrategy, buySideFunnel, FMVOrderOfMagnitude, companyWebsite, status, autoRenew, version, WHOIS, category);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "), name, bigFootOwned, websiteCurrent, locked, websiteUse,
                BFStrategy, buySideFunnel, FMVOrderOfMagnitude, companyWebsite, status, autoRenew, version, WHOIS, category);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("d.*, c.ID AS RegistrantID, CONCAT(IFNULL(c.NAME,''), IFNULL(c.FIRSTNAME,''), ' ', IFNULL(c.LASTNAME,'')) AS RegistrantName, c.`BIGFOOT GROUP` AS RegistrantBigFootGroup, p.NAME AS RegistrantParentAccountName, ");
            query.Append("r.ID AS RegistrarID, r.Name AS RegistrarName ");
            query.Append("FROM DomainN d ");
            query.Append("LEFT JOIN Company c ON d.RegistrantID = c.ID ");
            query.Append("LEFT JOIN Company p ON c.ParentAccountID = p.ID ");
            query.Append("LEFT JOIN Register r ON d.RegistrarID = r.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND d.Name LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                if (bigFootOwned == "1")
                {
                    query.Append("AND (c.`BIGFOOT GROUP` = 1 OR p.NAME = 'Bigfoot Group') ");
                }
                else
                {
                    query.Append("AND c.`BIGFOOT GROUP` = 0 AND p.NAME != 'Bigfoot Group' ");
                }
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

            query.Append("ORDER BY d.Name");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            query.Append("d.*, c.ID AS RegistrantID, CONCAT(IFNULL(c.NAME,''), IFNULL(c.FIRSTNAME,''), ' ', IFNULL(c.LASTNAME,'')) AS RegistrantName, c.`BIGFOOT GROUP` AS RegistrantBigFootGroup, p.NAME AS RegistrantParentAccountName, ");
            query.Append("r.ID AS RegistrarID, r.Name AS RegistrarName ");
            query.Append("FROM DomainN d ");
            query.Append("LEFT JOIN Company c ON d.RegistrantID = c.ID ");
            query.Append("LEFT JOIN Company p ON c.ParentAccountID = p.ID ");
            query.Append("LEFT JOIN Register r ON d.RegistrarID = r.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND d.Name LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                if (bigFootOwned == "1")
                {
                    query.Append("AND (c.`BIGFOOT GROUP` = 1 OR p.NAME = 'Bigfoot Group') ");
                }
                else
                {
                    query.Append("AND c.`BIGFOOT GROUP` = 0 AND p.NAME != 'Bigfoot Group' ");
                }
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

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            query.Append("COUNT(d.ID) INTO @total ");
            query.Append("FROM DomainN d ");
            query.Append("LEFT JOIN Company c ON d.RegistrantID = c.ID ");
            query.Append("LEFT JOIN Company p ON c.ParentAccountID = p.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND d.Name LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                if (bigFootOwned == "1")
                {
                    query.Append("AND (c.`BIGFOOT GROUP` = 1 OR p.NAME = 'Bigfoot Group') ");
                }
                else
                {
                    query.Append("AND c.`BIGFOOT GROUP` = 0 AND p.NAME != 'Bigfoot Group' ");
                }
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

            return query;
        }

        #endregion
    }
}
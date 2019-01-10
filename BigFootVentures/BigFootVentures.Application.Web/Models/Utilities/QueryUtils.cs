using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class QueryUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildSearchAdvanceQuery(string obj, int startIndex, int rowCount, string keyword = null,
            string bigFootOwned = null) //Domain
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            if (obj == "Domain")
            {
                query = BuildSearchDomainQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, keyword, bigFootOwned);
                queryTotal = BuildSearchDomainTotalQuery(new StringBuilder().Append("SELECT "), keyword, bigFootOwned);
            }

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildSearchDomainQuery(StringBuilder query, int startIndex, int rowCount, string keyword = null, string bigFootOwned = null)
        {
            query.Append("d.ID, d.Name, d.BigFootOwned, d.ExpirationDate, c.ID AS RegistrantID, c.NAME AS RegistrantName, ");
            query.Append("r.ID AS RegistrarID, r.Name AS RegistrarName ");
            query.Append("FROM DomainN d ");
            query.Append("LEFT JOIN Company c ON d.RegistrantID = c.ID ");
            query.Append("LEFT JOIN Register r ON d.RegistrarID = r.ID ");
            query.Append($"WHERE d.Name LIKE '%{keyword}%' ");

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                query.Append($"AND d.BigFootOwned = {bigFootOwned} ");
            }

            query.Append($"ORDER BY d.Name LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildSearchDomainTotalQuery(StringBuilder query, string keyword = null, string bigFootOwned = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM DomainN ");
            query.Append($"WHERE Name LIKE '%{keyword}%' ");

            if (!string.IsNullOrWhiteSpace(bigFootOwned))
            {
                query.Append($"AND BigFootOwned = {bigFootOwned} ");
            }

            return query;
        }

        #endregion
    }
}
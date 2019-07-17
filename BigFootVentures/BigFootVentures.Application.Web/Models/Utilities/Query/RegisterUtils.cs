using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class RegisterUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string name = null, string RAAYear = null, string country = null, string accreditedTLDs = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount,
                name, RAAYear, country, accreditedTLDs);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                name, RAAYear, country, accreditedTLDs);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string name = null, string RAAYear = null, string country = null, string accreditedTLDs = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("* ");
            query.Append("FROM Register ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND Name LIKE '%{name.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(RAAYear))
            {
                query.Append($"AND `RAA Year` LIKE '%{RAAYear.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                query.Append($"AND Country LIKE '%{country.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(accreditedTLDs))
            {
                query.Append($"AND `Accredited TLDs` LIKE '%{accreditedTLDs.Replace("'", "''")}%' ");
            }

            query.Append("ORDER BY Name");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string RAAYear = null, string country = null, string accreditedTLDs = null)
        {
            query.Append("* ");
            query.Append("FROM Register ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND Name LIKE '%{name.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(RAAYear))
            {
                query.Append($"AND `RAA Year` LIKE '%{RAAYear.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                query.Append($"AND Country LIKE '%{country.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(accreditedTLDs))
            {
                query.Append($"AND `Accredited TLDs` LIKE '%{accreditedTLDs.Replace("'", "''")}%' ");
            }

            query.Append($"ORDER BY Name LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string name = null, string RAAYear = null, string country = null, string accreditedTLDs = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM Register ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND Name LIKE '%{name.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(RAAYear))
            {
                query.Append($"AND `RAA Year` LIKE '%{RAAYear.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(country))
            {
                query.Append($"AND Country LIKE '%{country.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(accreditedTLDs))
            {
                query.Append($"AND `Accredited TLDs` LIKE '%{accreditedTLDs.Replace("'", "''")}%' ");
            }

            return query;
        }

        #endregion
    }
}
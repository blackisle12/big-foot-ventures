using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class BrandUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string name = null, string purpose = null, string value = null, string category = null, string HVT = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, name, purpose, value, category, HVT);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "), name, purpose, value, category, HVT);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string name = null, string purpose = null, string value = null, string category = null, string HVT = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("* ");
            query.Append("FROM Brand ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND NAME LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(purpose))
            {
                query.Append($"AND PURPOSE LIKE '%{purpose}%' ");
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                query.Append($"AND VALUE LIKE '%{value}%' ");
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query.Append($"AND CATEGORY LIKE '%{category}%' ");
            }

            if (!string.IsNullOrWhiteSpace(HVT))
            {
                query.Append($"AND HVT = {HVT} ");
            }

            query.Append("ORDER BY NAME");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string purpose = null, string value = null, string category = null, string HVT = null)
        {
            query.Append("* ");
            query.Append("FROM Brand ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND NAME LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(purpose))
            {
                query.Append($"AND PURPOSE LIKE '%{purpose}%' ");
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                query.Append($"AND VALUE LIKE '%{value}%' ");
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query.Append($"AND CATEGORY LIKE '%{category}%' ");
            }

            if (!string.IsNullOrWhiteSpace(HVT))
            {
                query.Append($"AND HVT = {HVT} ");
            }

            query.Append($"ORDER BY NAME LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string name = null, string purpose = null, string value = null, string category = null, string HVT = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM Brand ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND NAME LIKE '%{name}%' ");
            }

            if (!string.IsNullOrWhiteSpace(purpose))
            {
                query.Append($"AND PURPOSE LIKE '%{purpose}%' ");
            }

            if (!string.IsNullOrWhiteSpace(value))
            {
                query.Append($"AND VALUE LIKE '%{value}%' ");
            }

            if (!string.IsNullOrWhiteSpace(category))
            {
                query.Append($"AND CATEGORY LIKE '%{category}%' ");
            }

            if (!string.IsNullOrWhiteSpace(HVT))
            {
                query.Append($"AND HVT = {HVT} ");
            }

            return query;
        }

        #endregion
    }
}
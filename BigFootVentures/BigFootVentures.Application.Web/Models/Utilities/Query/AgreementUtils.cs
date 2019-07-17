using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class AgreementUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string name = null, string BFCompany = null, string counterpart = null, string objectOfAgreement = null, string type = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, name, BFCompany, counterpart, objectOfAgreement, type);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "), name, BFCompany, counterpart, objectOfAgreement, type);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string name = null, string BFCompany = null, string counterpart = null, string objectOfAgreement = null, string type = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("A.*, CA.NAME AS BFCompanyName, CB.NAME AS CounterpartCompanyName ");
            query.Append("FROM AgreementT A ");
            query.Append("LEFT JOIN Company CA ON A.BFCompanyID = CA.ID ");
            query.Append("LEFT JOIN Company CB ON A.CounterpartID = CB.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND A.Name LIKE '%{name.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(BFCompany))
            {
                query.Append($"AND CA.NAME LIKE '%{BFCompany.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(counterpart))
            {
                query.Append($"AND CB.NAME LIKE '%{counterpart.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(objectOfAgreement))
            {
                query.Append($"AND A.ObjectOfAgreement LIKE '%{objectOfAgreement.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND A.Type LIKE '%{type.Replace("'", "''")}%' ");
            }

            query.Append("ORDER BY A.Name");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string BFCompany = null, string counterpart = null, string objectOfAgreement = null, string type = null)
        {
            query.Append("A.*, CA.NAME AS BFCompanyName, CB.NAME AS CounterpartCompanyName ");
            query.Append("FROM AgreementT A ");
            query.Append("LEFT JOIN Company CA ON A.BFCompanyID = CA.ID ");
            query.Append("LEFT JOIN Company CB ON A.CounterpartID = CB.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND A.Name LIKE '%{name.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(BFCompany))
            {
                query.Append($"AND CA.NAME LIKE '%{BFCompany.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(counterpart))
            {
                query.Append($"AND CB.NAME LIKE '%{counterpart.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(objectOfAgreement))
            {
                query.Append($"AND A.ObjectOfAgreement LIKE '%{objectOfAgreement.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND A.Type LIKE '%{type.Replace("'", "''")}%' ");
            }

            query.Append($"ORDER BY A.Name LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string name = null, string BFCompany = null, string counterpart = null, string objectOfAgreement = null, string type = null)
        {
            query.Append("COUNT(A.ID) INTO @total ");
            query.Append("FROM AgreementT A ");
            query.Append("LEFT JOIN Company CA ON A.BFCompanyID = CA.ID ");
            query.Append("LEFT JOIN Company CB ON A.CounterpartID = CB.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
            {
                query.Append($"AND A.Name LIKE '%{name.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(BFCompany))
            {
                query.Append($"AND CA.NAME LIKE '%{BFCompany.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(counterpart))
            {
                query.Append($"AND CB.NAME LIKE '%{counterpart.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(objectOfAgreement))
            {
                query.Append($"AND A.ObjectOfAgreement LIKE '%{objectOfAgreement.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                query.Append($"AND A.Type LIKE '%{type.Replace("'", "''")}%' ");
            }

            return query;
        }

        #endregion
    }
}
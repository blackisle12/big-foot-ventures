using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class LeadUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string status = null, string firstName = null, string middleName = null, string lastName = null, string email = null, string phone = null,
            string company = null, string industry = null, string source = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount,
                status, firstName, middleName, lastName, email, phone, company, industry, source);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                status, firstName, middleName, lastName, email, phone, company, industry, source);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string status = null, string firstName = null, string middleName = null, string lastName = null, string email = null, string phone = null,
            string company = null, string industry = null, string source = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("* ");
            query.Append("FROM Lead ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query.Append($"AND FirstName LIKE '%{firstName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                query.Append($"AND MiddleName LIKE '%{middleName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query.Append($"AND LastName LIKE '%{lastName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND Email LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND Phone LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(company))
            {
                query.Append($"AND Company LIKE '%{company}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND Industry LIKE '%{industry}%' ");
            }

            if (!string.IsNullOrWhiteSpace(source))
            {
                query.Append($"AND Source LIKE '%{source}%' ");
            }

            query.Append("ORDER BY Status");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string status = null, string firstName = null, string middleName = null, string lastName = null, string email = null, string phone = null,
            string company = null, string industry = null, string source = null)
        {
            query.Append("* ");
            query.Append("FROM Lead ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query.Append($"AND FirstName LIKE '%{firstName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                query.Append($"AND MiddleName LIKE '%{middleName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query.Append($"AND LastName LIKE '%{lastName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND Email LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND Phone LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(company))
            {
                query.Append($"AND Company LIKE '%{company}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND Industry LIKE '%{industry}%' ");
            }

            if (!string.IsNullOrWhiteSpace(source))
            {
                query.Append($"AND Source LIKE '%{source}%' ");
            }

            query.Append($"ORDER BY Status LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string status = null, string firstName = null, string middleName = null, string lastName = null, string email = null, string phone = null,
            string company = null, string industry = null, string source = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM Lead ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query.Append($"AND FirstName LIKE '%{firstName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                query.Append($"AND MiddleName LIKE '%{middleName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query.Append($"AND LastName LIKE '%{lastName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND Email LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND Phone LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(company))
            {
                query.Append($"AND Company LIKE '%{company}%' ");
            }

            if (!string.IsNullOrWhiteSpace(industry))
            {
                query.Append($"AND Industry LIKE '%{industry}%' ");
            }

            if (!string.IsNullOrWhiteSpace(source))
            {
                query.Append($"AND Source LIKE '%{source}%' ");
            }

            return query;
        }

        #endregion
    }
}
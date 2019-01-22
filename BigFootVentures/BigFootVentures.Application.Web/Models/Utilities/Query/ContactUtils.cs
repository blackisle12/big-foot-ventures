using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class ContactUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string firstName = null, string middleName = null, string lastName = null, string department = null, string fax = null, string email = null,
            string phone = null, string mobile = null, string OHIMOwnerID = null, string OHIMNumTrademarks = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount,
                firstName, middleName, lastName, department, fax, email, phone, mobile, OHIMOwnerID, OHIMNumTrademarks);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                firstName, middleName, lastName, department, fax, email, phone, mobile, OHIMOwnerID, OHIMNumTrademarks);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string firstName = null, string middleName = null, string lastName = null, string department = null, string fax = null, string email = null,
            string phone = null, string mobile = null, string OHIMOwnerID = null, string OHIMNumTrademarks = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("C.*, CO.NAME AS CompanyName ");
            query.Append("FROM Contact C ");
            query.Append("LEFT JOIN Company CO ON C.CompanyID = CO.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query.Append($"AND C.FirstName LIKE '%{firstName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                query.Append($"AND C.MiddleName LIKE '%{middleName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query.Append($"AND C.LastName LIKE '%{lastName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(department))
            {
                query.Append($"AND C.Department LIKE '%{department}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.Fax LIKE '%{fax}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.Email LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.Phone LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(mobile))
            {
                query.Append($"AND C.Mobile LIKE '%{mobile}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMOwnerID))
            {
                query.Append($"AND C.OHIMOwnerID LIKE '%{OHIMOwnerID}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumTrademarks))
            {
                query.Append($"AND C.OHIMNumTrademarks LIKE '%{OHIMNumTrademarks}%' ");
            }

            query.Append("ORDER BY C.FirstName");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string firstName = null, string middleName = null, string lastName = null, string department = null, string fax = null, string email = null,
            string phone = null, string mobile = null, string OHIMOwnerID = null, string OHIMNumTrademarks = null)
        {
            query.Append("C.*, CO.NAME AS CompanyName ");
            query.Append("FROM Contact C ");
            query.Append("LEFT JOIN Company CO ON C.CompanyID = CO.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query.Append($"AND C.FirstName LIKE '%{firstName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                query.Append($"AND C.MiddleName LIKE '%{middleName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query.Append($"AND C.LastName LIKE '%{lastName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(department))
            {
                query.Append($"AND C.Department LIKE '%{department}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.Fax LIKE '%{fax}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.Email LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.Phone LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(mobile))
            {
                query.Append($"AND C.Mobile LIKE '%{mobile}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMOwnerID))
            {
                query.Append($"AND C.OHIMOwnerID LIKE '%{OHIMOwnerID}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumTrademarks))
            {
                query.Append($"AND C.OHIMNumTrademarks LIKE '%{OHIMNumTrademarks}%' ");
            }

            query.Append($"ORDER BY C.FirstName LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string firstName = null, string middleName = null, string lastName = null, string department = null, string fax = null, string email = null,
            string phone = null, string mobile = null, string OHIMOwnerID = null, string OHIMNumTrademarks = null)
        {
            query.Append("COUNT(C.ID) INTO @total ");
            query.Append("FROM Contact C ");
            query.Append("LEFT JOIN Company CO ON C.CompanyID = CO.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(firstName))
            {
                query.Append($"AND C.FirstName LIKE '%{firstName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(middleName))
            {
                query.Append($"AND C.MiddleName LIKE '%{middleName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                query.Append($"AND C.LastName LIKE '%{lastName}%' ");
            }

            if (!string.IsNullOrWhiteSpace(department))
            {
                query.Append($"AND C.Department LIKE '%{department}%' ");
            }

            if (!string.IsNullOrWhiteSpace(fax))
            {
                query.Append($"AND C.Fax LIKE '%{fax}%' ");
            }

            if (!string.IsNullOrWhiteSpace(email))
            {
                query.Append($"AND C.Email LIKE '%{email}%' ");
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                query.Append($"AND C.Phone LIKE '%{phone}%' ");
            }

            if (!string.IsNullOrWhiteSpace(mobile))
            {
                query.Append($"AND C.Mobile LIKE '%{mobile}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMOwnerID))
            {
                query.Append($"AND C.OHIMOwnerID LIKE '%{OHIMOwnerID}%' ");
            }

            if (!string.IsNullOrWhiteSpace(OHIMNumTrademarks))
            {
                query.Append($"AND C.OHIMNumTrademarks LIKE '%{OHIMNumTrademarks}%' ");
            }

            return query;
        }

        #endregion
    }
}
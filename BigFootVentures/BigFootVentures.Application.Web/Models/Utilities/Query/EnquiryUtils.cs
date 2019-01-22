using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class EnquiryUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string oldCaseNumber = null, string status = null, string caseAssign = null, string priority = null, string subject = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, 
                oldCaseNumber, status, caseAssign, priority, subject);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "), 
                oldCaseNumber, status, caseAssign, priority, subject);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string oldCaseNumber = null, string status = null, string caseAssign = null, string priority = null, string subject = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("* ");
            query.Append("FROM Enquiry ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(oldCaseNumber))
            {
                query.Append($"AND OldCaseNumber LIKE '%{oldCaseNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(caseAssign))
            {
                query.Append($"AND CaseAssign LIKE '%{caseAssign}%' ");
            }

            if (!string.IsNullOrWhiteSpace(priority))
            {
                query.Append($"AND Priority LIKE '%{priority}%' ");
            }

            if (!string.IsNullOrWhiteSpace(subject))
            {
                query.Append($"AND Subject LIKE '%{subject}%' ");
            }

            query.Append("ORDER BY OldCaseNumber");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string oldCaseNumber = null, string status = null, string caseAssign = null, string priority = null, string subject = null)
        {
            query.Append("* ");
            query.Append("FROM Enquiry ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(oldCaseNumber))
            {
                query.Append($"AND OldCaseNumber LIKE '%{oldCaseNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(caseAssign))
            {
                query.Append($"AND CaseAssign LIKE '%{caseAssign}%' ");
            }

            if (!string.IsNullOrWhiteSpace(priority))
            {
                query.Append($"AND Priority LIKE '%{priority}%' ");
            }

            if (!string.IsNullOrWhiteSpace(subject))
            {
                query.Append($"AND Subject LIKE '%{subject}%' ");
            }

            query.Append($"ORDER BY OldCaseNumber LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string oldCaseNumber = null, string status = null, string caseAssign = null, string priority = null, string subject = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM Enquiry ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(oldCaseNumber))
            {
                query.Append($"AND OldCaseNumber LIKE '%{oldCaseNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(caseAssign))
            {
                query.Append($"AND CaseAssign LIKE '%{caseAssign}%' ");
            }

            if (!string.IsNullOrWhiteSpace(priority))
            {
                query.Append($"AND Priority LIKE '%{priority}%' ");
            }

            if (!string.IsNullOrWhiteSpace(subject))
            {
                query.Append($"AND Subject LIKE '%{subject}%' ");
            }

            return query;
        }

        #endregion
    }
}
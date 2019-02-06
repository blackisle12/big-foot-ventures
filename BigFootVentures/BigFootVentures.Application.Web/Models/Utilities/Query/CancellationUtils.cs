using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class CancellationUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string referenceInternal = null, string referenceExternal = null, string sentOrigin = null, string internalCaseNumber = null, string submissionMethod = null, string applicant = null,
            string trademark = null, string researchPerformance = null, string status = null, string acquisitionLetterSentOrigin = null, string acquisitionLetterSentMethod = null, string UDRPStrategy = null,
            string ownerResponseAcquisitionLetter = null, string domainEnquiry = null, string outcome = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount, 
                referenceInternal, referenceExternal, sentOrigin, internalCaseNumber, submissionMethod, applicant, trademark, researchPerformance, status, acquisitionLetterSentOrigin,
                acquisitionLetterSentMethod, UDRPStrategy, ownerResponseAcquisitionLetter, domainEnquiry, outcome);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                referenceInternal, referenceExternal, sentOrigin, internalCaseNumber, submissionMethod, applicant, trademark, researchPerformance, status, acquisitionLetterSentOrigin,
                acquisitionLetterSentMethod, UDRPStrategy, ownerResponseAcquisitionLetter, domainEnquiry, outcome);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string referenceInternal = null, string referenceExternal = null, string sentOrigin = null, string internalCaseNumber = null, string submissionMethod = null, 
            string applicant = null, string trademark = null, string researchPerformance = null, string status = null, string acquisitionLetterSentOrigin = null, string acquisitionLetterSentMethod = null,
            string UDRPStrategy = null, string ownerResponseAcquisitionLetter = null, string domainEnquiry = null, string outcome = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("C.*, ");
            query.Append("T.Name AS TrademarkName, ");
            query.Append("CASE WHEN CO.NAME IS NOT NULL THEN CO.NAME ELSE CONCAT_WS('''' '''', CO.LASTNAME, CO.FIRSTNAME) END AS ApplicantName ");
            query.Append("FROM Cancellation C ");
            query.Append("LEFT JOIN Trademark T ON C.TrademarkID = T.ID ");
            query.Append("LEFT JOIN Company CO ON C.ApplicantID = CO.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(referenceInternal))
            {
                query.Append($"AND C.ReferenceInternal LIKE '%{referenceInternal}%' ");
            }

            if (!string.IsNullOrWhiteSpace(referenceExternal))
            {
                query.Append($"AND C.ReferenceExternal LIKE '%{referenceExternal}%' ");
            }

            if (!string.IsNullOrWhiteSpace(sentOrigin))
            {
                query.Append($"AND C.SentOrigin LIKE '%{sentOrigin}%' ");
            }

            if (!string.IsNullOrWhiteSpace(internalCaseNumber))
            {
                query.Append($"AND C.InternalCaseNumber LIKE '%{internalCaseNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(submissionMethod))
            {
                query.Append($"AND C.SubmissionMethod LIKE '%{submissionMethod}%' ");
            }

            if (!string.IsNullOrWhiteSpace(applicant))
            {
                query.Append($"AND CO.NAME LIKE '%{applicant}%' ");
            }

            if (!string.IsNullOrWhiteSpace(trademark))
            {
                query.Append($"AND T.Name LIKE '%{trademark}%' ");
            }

            if (!string.IsNullOrWhiteSpace(researchPerformance))
            {
                query.Append($"AND C.ResearchPerformance LIKE '%{researchPerformance}%' ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND C.Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(acquisitionLetterSentOrigin))
            {
                query.Append($"AND C.AcquisitionLetterSentOrigin LIKE '%{acquisitionLetterSentOrigin}%' ");
            }

            if (!string.IsNullOrWhiteSpace(acquisitionLetterSentMethod))
            {
                query.Append($"AND C.AcquisitionLetterSentMethod LIKE '%{acquisitionLetterSentMethod}%' ");
            }

            if (!string.IsNullOrWhiteSpace(UDRPStrategy))
            {
                query.Append($"AND C.UDRPStrategy LIKE '%{UDRPStrategy}%' ");
            }

            if (!string.IsNullOrWhiteSpace(ownerResponseAcquisitionLetter))
            {
                query.Append($"AND C.OwnerResponseAcquisitionLetter LIKE '%{ownerResponseAcquisitionLetter}%' ");
            }

            if (!string.IsNullOrWhiteSpace(domainEnquiry))
            {
                query.Append($"AND C.DomainEnquiry = {domainEnquiry} ");
            }

            query.Append("ORDER BY C.ReferenceInternal");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string referenceInternal = null, string referenceExternal = null, string sentOrigin = null, string internalCaseNumber = null, string submissionMethod = null, string applicant = null,
            string trademark = null, string researchPerformance = null, string status = null, string acquisitionLetterSentOrigin = null, string acquisitionLetterSentMethod = null, string UDRPStrategy = null,
            string ownerResponseAcquisitionLetter = null, string domainEnquiry = null, string outcome = null)
        {
            query.Append("C.*, ");
            query.Append("T.Name AS TrademarkName, ");
            query.Append("CASE WHEN CO.NAME IS NOT NULL THEN CO.NAME ELSE CONCAT_WS('''' '''', CO.LASTNAME, CO.FIRSTNAME) END AS ApplicantName ");
            query.Append("FROM Cancellation C ");
            query.Append("LEFT JOIN Trademark T ON C.TrademarkID = T.ID ");
            query.Append("LEFT JOIN Company CO ON C.ApplicantID = CO.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(referenceInternal))
            {
                query.Append($"AND C.ReferenceInternal LIKE '%{referenceInternal}%' ");
            }

            if (!string.IsNullOrWhiteSpace(referenceExternal))
            {
                query.Append($"AND C.ReferenceExternal LIKE '%{referenceExternal}%' ");
            }

            if (!string.IsNullOrWhiteSpace(sentOrigin))
            {
                query.Append($"AND C.SentOrigin LIKE '%{sentOrigin}%' ");
            }

            if (!string.IsNullOrWhiteSpace(internalCaseNumber))
            {
                query.Append($"AND C.InternalCaseNumber LIKE '%{internalCaseNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(submissionMethod))
            {
                query.Append($"AND C.SubmissionMethod LIKE '%{submissionMethod}%' ");
            }

            if (!string.IsNullOrWhiteSpace(applicant))
            {
                query.Append($"AND CO.NAME LIKE '%{applicant}%' ");
            }

            if (!string.IsNullOrWhiteSpace(trademark))
            {
                query.Append($"AND T.Name LIKE '%{trademark}%' ");
            }

            if (!string.IsNullOrWhiteSpace(researchPerformance))
            {
                query.Append($"AND C.ResearchPerformance LIKE '%{researchPerformance}%' ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND C.Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(acquisitionLetterSentOrigin))
            {
                query.Append($"AND C.AcquisitionLetterSentOrigin LIKE '%{acquisitionLetterSentOrigin}%' ");
            }

            if (!string.IsNullOrWhiteSpace(acquisitionLetterSentMethod))
            {
                query.Append($"AND C.AcquisitionLetterSentMethod LIKE '%{acquisitionLetterSentMethod}%' ");
            }

            if (!string.IsNullOrWhiteSpace(UDRPStrategy))
            {
                query.Append($"AND C.UDRPStrategy LIKE '%{UDRPStrategy}%' ");
            }

            if (!string.IsNullOrWhiteSpace(ownerResponseAcquisitionLetter))
            {
                query.Append($"AND C.OwnerResponseAcquisitionLetter LIKE '%{ownerResponseAcquisitionLetter}%' ");
            }

            if (!string.IsNullOrWhiteSpace(domainEnquiry))
            {
                query.Append($"AND C.DomainEnquiry = {domainEnquiry} ");
            }

            query.Append($"ORDER BY C.ReferenceInternal LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string referenceInternal = null, string referenceExternal = null, string sentOrigin = null, string internalCaseNumber = null, string submissionMethod = null, string applicant = null,
            string trademark = null, string researchPerformance = null, string status = null, string acquisitionLetterSentOrigin = null, string acquisitionLetterSentMethod = null, string UDRPStrategy = null,
            string ownerResponseAcquisitionLetter = null, string domainEnquiry = null, string outcome = null)
        {
            query.Append("COUNT(C.ID) INTO @total ");
            query.Append("FROM Cancellation C ");
            query.Append("LEFT JOIN Trademark T ON C.TrademarkID = T.ID ");
            query.Append("LEFT JOIN Company CO ON C.ApplicantID = CO.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(referenceInternal))
            {
                query.Append($"AND C.ReferenceInternal LIKE '%{referenceInternal}%' ");
            }

            if (!string.IsNullOrWhiteSpace(referenceExternal))
            {
                query.Append($"AND C.ReferenceExternal LIKE '%{referenceExternal}%' ");
            }

            if (!string.IsNullOrWhiteSpace(sentOrigin))
            {
                query.Append($"AND C.SentOrigin LIKE '%{sentOrigin}%' ");
            }

            if (!string.IsNullOrWhiteSpace(internalCaseNumber))
            {
                query.Append($"AND C.InternalCaseNumber LIKE '%{internalCaseNumber}%' ");
            }

            if (!string.IsNullOrWhiteSpace(submissionMethod))
            {
                query.Append($"AND C.SubmissionMethod LIKE '%{submissionMethod}%' ");
            }

            if (!string.IsNullOrWhiteSpace(applicant))
            {
                query.Append($"AND CO.NAME LIKE '%{applicant}%' ");
            }

            if (!string.IsNullOrWhiteSpace(trademark))
            {
                query.Append($"AND T.Name LIKE '%{trademark}%' ");
            }

            if (!string.IsNullOrWhiteSpace(researchPerformance))
            {
                query.Append($"AND C.ResearchPerformance LIKE '%{researchPerformance}%' ");
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                query.Append($"AND C.Status LIKE '%{status}%' ");
            }

            if (!string.IsNullOrWhiteSpace(acquisitionLetterSentOrigin))
            {
                query.Append($"AND C.AcquisitionLetterSentOrigin LIKE '%{acquisitionLetterSentOrigin}%' ");
            }

            if (!string.IsNullOrWhiteSpace(acquisitionLetterSentMethod))
            {
                query.Append($"AND C.AcquisitionLetterSentMethod LIKE '%{acquisitionLetterSentMethod}%' ");
            }

            if (!string.IsNullOrWhiteSpace(UDRPStrategy))
            {
                query.Append($"AND C.UDRPStrategy LIKE '%{UDRPStrategy}%' ");
            }

            if (!string.IsNullOrWhiteSpace(ownerResponseAcquisitionLetter))
            {
                query.Append($"AND C.OwnerResponseAcquisitionLetter LIKE '%{ownerResponseAcquisitionLetter}%' ");
            }

            if (!string.IsNullOrWhiteSpace(domainEnquiry))
            {
                query.Append($"AND C.DomainEnquiry = {domainEnquiry} ");
            }

            return query;
        }

        #endregion
    }
}
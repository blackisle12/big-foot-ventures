using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class TrademarkUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string name = null, string office = null, string officeStatus = null, string trademarkNumber = null, string figurative = null, string brand = null,
            string figurativeURL = null, string originalOffice = null, string languageFiling = null, string languageSecond = null, string geography = null,
            string involvedInRevocation = null, string bigFootGroupOwned = null, string seniorityUsed = null, string revocationTarget = null, string openSimilarityResearchTask = null,
            string oppositionResearch = null, string researcherName = null, string markUse = null, string TMWebsite = null, string competingMarks = null,
            string ownerWebsite = null, string cancellationStrategy = null, string comWebsite = null, string ownerDefense = null, string BFStrategy = null,
            string nameValue = null, string invalidityNumber = null, string invalidityApplicant = null, string invalidityActionOutcome = null, string letterReference = null,
            string letterOrigin = null, string letterSendingMethod = null, string letterOutcome = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount,
                name, office, officeStatus, trademarkNumber, figurative, brand, figurativeURL, originalOffice, languageFiling, languageSecond, geography,
                involvedInRevocation, bigFootGroupOwned, seniorityUsed, revocationTarget, openSimilarityResearchTask, oppositionResearch, researcherName,
                markUse, TMWebsite, competingMarks, ownerWebsite, cancellationStrategy, comWebsite, ownerDefense, BFStrategy, nameValue, invalidityNumber,
                invalidityApplicant, invalidityActionOutcome, letterReference, letterOrigin, letterSendingMethod, letterOutcome);
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                name, office, officeStatus, trademarkNumber, figurative, brand, figurativeURL, originalOffice, languageFiling, languageSecond, geography,
                involvedInRevocation, bigFootGroupOwned, seniorityUsed, revocationTarget, openSimilarityResearchTask, oppositionResearch, researcherName,
                markUse, TMWebsite, competingMarks, ownerWebsite, cancellationStrategy, comWebsite, ownerDefense, BFStrategy, nameValue, invalidityNumber,
                invalidityApplicant, invalidityActionOutcome, letterReference, letterOrigin, letterSendingMethod, letterOutcome);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string name = null, string office = null, string officeStatus = null, string trademarkNumber = null, string figurative = null, string brand = null,
            string figurativeURL = null, string originalOffice = null, string languageFiling = null, string languageSecond = null, string geography = null,
            string involvedInRevocation = null, string bigFootGroupOwned = null, string seniorityUsed = null, string revocationTarget = null, string openSimilarityResearchTask = null,
            string oppositionResearch = null, string researcherName = null, string markUse = null, string TMWebsite = null, string competingMarks = null,
            string ownerWebsite = null, string cancellationStrategy = null, string comWebsite = null, string ownerDefense = null, string BFStrategy = null,
            string nameValue = null, string invalidityNumber = null, string invalidityApplicant = null, string invalidityActionOutcome = null, string letterReference = null,
            string letterOrigin = null, string letterSendingMethod = null, string letterOutcome = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("T.* ");
            //query.Append("T6.ResearcherName, T6.TMWebsiteID, T6.OwnerWebsiteID, T6.ComWebsiteID, T6.CancellationStrategy, T6.MarkUse, ");
            //query.Append("T6.CompetingMarks, T6.CompetingMark, T6.CancelResearcherComments, T6.OwnerDefense, T6.SourceName, T6.BFStrategy, ");
            //query.Append("T6.StrategyNotes, T6.NameValue, T6.CancelBuyBudget, T6.RevocationReferenceExternal, T6.InvalidityNumber, ");
            //query.Append("T6.InvalidityApplicantID, T6.InvalidityInvokedGround, T6.InvalidityDate, T6.InvalidityActionOutcome, ");
            //query.Append("T6.LetterReference, T6.LetterOrigin, T6.LetterSendingMethod, T6.LetterSentOn, T6.OwnerResponseDeadline, T6.LetterOutcome, ");
            query.Append(",O.OfficeName AS OfficeName ");
            query.Append(",B.NAME AS BrandName ");
            //query.Append(",OO.OfficeName AS OriginalOfficeName ");
            //query.Append(",D.Name AS TMWebsiteName ");
            //query.Append(",DD.Name AS OwnerWebsiteName ");
            //query.Append(",DDD.Name AS ComWebsiteName ");
            query.Append("FROM Trademark T ");
            //query.Append("LEFT JOIN TrademarkExtra6 T6 ON T.ID = T6.ID ");
            query.Append("LEFT JOIN Office O ON T.OfficeID = O.ID ");
            query.Append("LEFT JOIN Brand B ON T.BrandID = B.ID ");
            //query.Append("LEFT JOIN Office OO ON T.OriginalOfficeID = OO.ID ");
            //query.Append("LEFT JOIN DomainN D ON T6.TMWebsiteID = D.ID ");
            //query.Append("LEFT JOIN DomainN DD ON T6.OwnerWebsiteID = DD.ID ");
            //query.Append("LEFT JOIN DomainN DDD ON T6.ComWebsiteID = DDD.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
                query.Append($"AND T.Name LIKE '%{name.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(office.Replace("'", "''")))
                query.Append($"AND O.OfficeName LIKE '%{office.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(officeStatus))
                query.Append($"AND T.OfficeStatus LIKE '%{officeStatus.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(trademarkNumber))
                query.Append($"AND T.TrademarkNumber LIKE '%{trademarkNumber.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(figurative))
                query.Append($"AND T.Figurative = {figurative} ");
            if (!string.IsNullOrWhiteSpace(brand))
                query.Append($"AND B.NAME LIKE '%{brand.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(figurativeURL))
                query.Append($"AND T.FigurativeURL LIKE '%{figurativeURL.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(originalOffice))
                query.Append($"AND T.OriginalOffice LIKE '%{originalOffice.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(languageFiling))
                query.Append($"AND T.LanguageFiling LIKE '%{languageFiling.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(languageSecond))
                query.Append($"AND T.LanguageSecond LIKE '%{languageSecond.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(geography))
                query.Append($"AND T.Geography LIKE '%{geography.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(involvedInRevocation))
                query.Append($"AND T.InvolvedInRevocation = {involvedInRevocation} ");
            if (!string.IsNullOrWhiteSpace(bigFootGroupOwned))
                query.Append($"AND T.BigFootGroupOwned LIKE '%{bigFootGroupOwned.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(seniorityUsed))
                query.Append($"AND T.SeniorityUsed = {seniorityUsed} ");
            if (!string.IsNullOrWhiteSpace(revocationTarget))
                query.Append($"AND T.RevocationTarget = {revocationTarget} ");

            if (!string.IsNullOrWhiteSpace(openSimilarityResearchTask))
                query.Append($"AND T.OpenSimilarityResearchTask LIKE '%{openSimilarityResearchTask.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(oppositionResearch))
                query.Append($"AND T.OppositionResearch LIKE '%{oppositionResearch.Replace("'", "''")}%' ");

            //if (!string.IsNullOrWhiteSpace(researcherName))
            //    query.Append($"AND T6.ResearcherName LIKE '%{researcherName}%' ");
            //if (!string.IsNullOrWhiteSpace(markUse))
            //    query.Append($"AND T6.MarkUse LIKE '%{markUse}%' ");
            //if (!string.IsNullOrWhiteSpace(TMWebsite))
            //    query.Append($"AND T6.TMWebsite LIKE '%{TMWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(competingMarks))
            //    query.Append($"AND T6.CompetingMarks = {competingMarks} ");
            //if (!string.IsNullOrWhiteSpace(ownerWebsite))
            //    query.Append($"AND T6.OwnerWebsite LIKE '%{ownerWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(cancellationStrategy))
            //    query.Append($"AND T6.CancellationStrategy LIKE '%{cancellationStrategy}%' ");
            //if (!string.IsNullOrWhiteSpace(comWebsite))
            //    query.Append($"AND T6.ComWebsite LIKE '%{comWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(ownerDefense))
            //    query.Append($"AND T6.OwnerDefense LIKE '%{ownerDefense}%' ");

            //if (!string.IsNullOrWhiteSpace(BFStrategy))
            //    query.Append($"AND T6.BFStrategy LIKE '%{BFStrategy}%' ");
            //if (!string.IsNullOrWhiteSpace(nameValue))
            //    query.Append($"AND T6.NameValue LIKE '%{nameValue}%' ");

            //if (!string.IsNullOrWhiteSpace(invalidityNumber))
            //    query.Append($"AND T6.InvalidityNumber LIKE '%{invalidityNumber}%' ");
            //if (!string.IsNullOrWhiteSpace(invalidityActionOutcome))
            //    query.Append($"AND T6.InvalidityActionOutcome LIKE '%{invalidityActionOutcome}%' ");

            //if (!string.IsNullOrWhiteSpace(letterReference))
            //    query.Append($"AND T6.LetterReference LIKE '%{letterReference}%' ");
            //if (!string.IsNullOrWhiteSpace(letterOrigin))
            //    query.Append($"AND T6.LetterOrigin LIKE '%{letterOrigin}%' ");
            //if (!string.IsNullOrWhiteSpace(letterSendingMethod))
            //    query.Append($"AND T6.LetterSendingMethod LIKE '%{letterSendingMethod}%' ");
            //if (!string.IsNullOrWhiteSpace(letterOutcome))
            //    query.Append($"AND T6.LetterOutcome LIKE '%{letterOutcome}%' ");

            query.Append("ORDER BY T.Name");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string name = null, string office = null, string officeStatus = null, string trademarkNumber = null, string figurative = null, string brand = null,
            string figurativeURL = null, string originalOffice = null, string languageFiling = null, string languageSecond = null, string geography = null,
            string involvedInRevocation = null, string bigFootGroupOwned = null, string seniorityUsed = null, string revocationTarget = null, string openSimilarityResearchTask = null,
            string oppositionResearch = null, string researcherName = null, string markUse = null, string TMWebsite = null, string competingMarks = null,
            string ownerWebsite = null, string cancellationStrategy = null, string comWebsite = null, string ownerDefense = null, string BFStrategy = null,
            string nameValue = null, string invalidityNumber = null, string invalidityApplicant = null, string invalidityActionOutcome = null, string letterReference = null,
            string letterOrigin = null, string letterSendingMethod = null, string letterOutcome = null)
        {
            query.Append("T.* ");

            if (!string.IsNullOrWhiteSpace(office))
                query.Append(",O.OfficeName AS OfficeName ");

            if (!string.IsNullOrWhiteSpace(brand))
                query.Append(",B.NAME AS BrandName ");

            //query.Append(",OO.OfficeName AS OriginalOfficeName ");
            //query.Append(",D.Name AS TMWebsiteName ");
            //query.Append(",DD.Name AS OwnerWebsiteName ");
            //query.Append(",DDD.Name AS ComWebsiteName ");
            query.Append("FROM Trademark T ");
            //query.Append("LEFT JOIN TrademarkExtra6 T6 ON T.ID = T6.ID ");
            query.Append("LEFT JOIN Office O ON T.OfficeID = O.ID ");
            query.Append("LEFT JOIN Brand B ON T.BrandID = B.ID ");
            //query.Append("LEFT JOIN Office OO ON T.OriginalOfficeID = OO.ID ");
            //query.Append("LEFT JOIN DomainN D ON T6.TMWebsiteID = D.ID ");
            //query.Append("LEFT JOIN DomainN DD ON T6.OwnerWebsiteID = DD.ID ");
            //query.Append("LEFT JOIN DomainN DDD ON T6.ComWebsiteID = DDD.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
                query.Append($"AND T.Name LIKE '%{name.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(office))
                query.Append($"AND O.OfficeName LIKE '%{office.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(officeStatus))
                query.Append($"AND T.OfficeStatus LIKE '%{officeStatus.Replace("'", "''")}%' ");

            if (!string.IsNullOrWhiteSpace(trademarkNumber))
                query.Append($"AND T.TrademarkNumber LIKE '%{trademarkNumber.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(figurative))
                query.Append($"AND T.Figurative = {figurative} ");
            if (!string.IsNullOrWhiteSpace(brand))
                query.Append($"AND B.NAME LIKE '%{brand.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(figurativeURL))
                query.Append($"AND T.FigurativeURL LIKE '%{figurativeURL.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(originalOffice))
                query.Append($"AND T.OriginalOffice LIKE '%{originalOffice.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(languageFiling))
                query.Append($"AND T.LanguageFiling LIKE '%{languageFiling.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(languageSecond))
                query.Append($"AND T.LanguageSecond LIKE '%{languageSecond.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(geography))
                query.Append($"AND T.Geography LIKE '%{geography.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(involvedInRevocation))
                query.Append($"AND T.InvolvedInRevocation = {involvedInRevocation} ");
            if (!string.IsNullOrWhiteSpace(bigFootGroupOwned))
                query.Append($"AND T.BigFootGroupOwned LIKE '%{bigFootGroupOwned.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(seniorityUsed))
                query.Append($"AND T.SeniorityUsed = {seniorityUsed} ");
            if (!string.IsNullOrWhiteSpace(revocationTarget))
                query.Append($"AND T.RevocationTarget = {revocationTarget} ");

            if (!string.IsNullOrWhiteSpace(openSimilarityResearchTask))
                query.Append($"AND T.OpenSimilarityResearchTask LIKE '%{openSimilarityResearchTask.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(oppositionResearch))
                query.Append($"AND T.OppositionResearch LIKE '%{oppositionResearch.Replace("'", "''")}%' ");

            //if (!string.IsNullOrWhiteSpace(researcherName))
            //    query.Append($"AND T6.ResearcherName LIKE '%{researcherName}%' ");
            //if (!string.IsNullOrWhiteSpace(markUse))
            //    query.Append($"AND T6.MarkUse LIKE '%{markUse}%' ");
            //if (!string.IsNullOrWhiteSpace(TMWebsite))
            //    query.Append($"AND T6.TMWebsite LIKE '%{TMWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(competingMarks))
            //    query.Append($"AND T6.CompetingMarks = {competingMarks} ");
            //if (!string.IsNullOrWhiteSpace(ownerWebsite))
            //    query.Append($"AND T6.OwnerWebsite LIKE '%{ownerWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(cancellationStrategy))
            //    query.Append($"AND T6.CancellationStrategy LIKE '%{cancellationStrategy}%' ");
            //if (!string.IsNullOrWhiteSpace(comWebsite))
            //    query.Append($"AND T6.ComWebsite LIKE '%{comWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(ownerDefense))
            //    query.Append($"AND T6.OwnerDefense LIKE '%{ownerDefense}%' ");

            //if (!string.IsNullOrWhiteSpace(BFStrategy))
            //    query.Append($"AND T6.BFStrategy LIKE '%{BFStrategy}%' ");
            //if (!string.IsNullOrWhiteSpace(nameValue))
            //    query.Append($"AND T6.NameValue LIKE '%{nameValue}%' ");

            //if (!string.IsNullOrWhiteSpace(invalidityNumber))
            //    query.Append($"AND T6.InvalidityNumber LIKE '%{invalidityNumber}%' ");
            //if (!string.IsNullOrWhiteSpace(invalidityActionOutcome))
            //    query.Append($"AND T6.InvalidityActionOutcome LIKE '%{invalidityActionOutcome}%' ");

            //if (!string.IsNullOrWhiteSpace(letterReference))
            //    query.Append($"AND T6.LetterReference LIKE '%{letterReference}%' ");
            //if (!string.IsNullOrWhiteSpace(letterOrigin))
            //    query.Append($"AND T6.LetterOrigin LIKE '%{letterOrigin}%' ");
            //if (!string.IsNullOrWhiteSpace(letterSendingMethod))
            //    query.Append($"AND T6.LetterSendingMethod LIKE '%{letterSendingMethod}%' ");
            //if (!string.IsNullOrWhiteSpace(letterOutcome))
            //    query.Append($"AND T6.LetterOutcome LIKE '%{letterOutcome}%' ");

            query.Append($"ORDER BY T.Name LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string name = null, string office = null, string officeStatus = null, string trademarkNumber = null, string figurative = null, string brand = null,
            string figurativeURL = null, string originalOffice = null, string languageFiling = null, string languageSecond = null, string geography = null,
            string involvedInRevocation = null, string bigFootGroupOwned = null, string seniorityUsed = null, string revocationTarget = null, string openSimilarityResearchTask = null,
            string oppositionResearch = null, string researcherName = null, string markUse = null, string TMWebsite = null, string competingMarks = null,
            string ownerWebsite = null, string cancellationStrategy = null, string comWebsite = null, string ownerDefense = null, string BFStrategy = null,
            string nameValue = null, string invalidityNumber = null, string invalidityApplicant = null, string invalidityActionOutcome = null, string letterReference = null,
            string letterOrigin = null, string letterSendingMethod = null, string letterOutcome = null)
        {
            query.Append("COUNT(T.ID) INTO @total ");
            query.Append("FROM Trademark T ");
            //query.Append("LEFT JOIN TrademarkExtra6 T6 ON T.ID = T6.ID ");
            query.Append("LEFT JOIN Office O ON T.OfficeID = O.ID ");
            query.Append("LEFT JOIN Brand B ON T.BrandID = B.ID ");
            //query.Append("LEFT JOIN Office OO ON T.OriginalOfficeID = OO.ID ");
            //query.Append("LEFT JOIN DomainN D ON T6.TMWebsiteID = D.ID ");
            //query.Append("LEFT JOIN DomainN DD ON T6.OwnerWebsiteID = DD.ID ");
            //query.Append("LEFT JOIN DomainN DDD ON T6.ComWebsiteID = DDD.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
                query.Append($"AND T.Name LIKE '%{name.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(office))
                query.Append($"AND O.OfficeName LIKE '%{office.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(officeStatus))
                query.Append($"AND T.OfficeStatus LIKE '%{officeStatus.Replace("'", "''")}%' ");

            if (!string.IsNullOrWhiteSpace(trademarkNumber))
                query.Append($"AND T.TrademarkNumber LIKE '%{trademarkNumber.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(figurative))
                query.Append($"AND T.Figurative = {figurative} ");
            if (!string.IsNullOrWhiteSpace(brand))
                query.Append($"AND B.NAME LIKE '%{brand.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(figurativeURL))
                query.Append($"AND T.FigurativeURL LIKE '%{figurativeURL.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(originalOffice))
                query.Append($"AND T.OriginalOffice LIKE '%{originalOffice.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(languageFiling))
                query.Append($"AND T.LanguageFiling LIKE '%{languageFiling.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(languageSecond))
                query.Append($"AND T.LanguageSecond LIKE '%{languageSecond.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(geography))
                query.Append($"AND T.Geography LIKE '%{geography.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(involvedInRevocation))
                query.Append($"AND T.InvolvedInRevocation = {involvedInRevocation} ");
            if (!string.IsNullOrWhiteSpace(bigFootGroupOwned))
                query.Append($"AND T.BigFootGroupOwned LIKE '%{bigFootGroupOwned.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(seniorityUsed))
                query.Append($"AND T.SeniorityUsed = {seniorityUsed} ");
            if (!string.IsNullOrWhiteSpace(revocationTarget))
                query.Append($"AND T.RevocationTarget = {revocationTarget} ");

            if (!string.IsNullOrWhiteSpace(openSimilarityResearchTask))
                query.Append($"AND T.OpenSimilarityResearchTask LIKE '%{openSimilarityResearchTask.Replace("'", "''")}%' ");
            if (!string.IsNullOrWhiteSpace(oppositionResearch))
                query.Append($"AND T.OppositionResearch LIKE '%{oppositionResearch.Replace("'", "''")}%' ");

            //if (!string.IsNullOrWhiteSpace(researcherName))
            //    query.Append($"AND T6.ResearcherName LIKE '%{researcherName}%' ");
            //if (!string.IsNullOrWhiteSpace(markUse))
            //    query.Append($"AND T6.MarkUse LIKE '%{markUse}%' ");
            //if (!string.IsNullOrWhiteSpace(TMWebsite))
            //    query.Append($"AND T6.TMWebsite LIKE '%{TMWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(competingMarks))
            //    query.Append($"AND T6.CompetingMarks = {competingMarks} ");
            //if (!string.IsNullOrWhiteSpace(ownerWebsite))
            //    query.Append($"AND T6.OwnerWebsite LIKE '%{ownerWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(cancellationStrategy))
            //    query.Append($"AND T6.CancellationStrategy LIKE '%{cancellationStrategy}%' ");
            //if (!string.IsNullOrWhiteSpace(comWebsite))
            //    query.Append($"AND T6.ComWebsite LIKE '%{comWebsite}%' ");
            //if (!string.IsNullOrWhiteSpace(ownerDefense))
            //    query.Append($"AND T6.OwnerDefense LIKE '%{ownerDefense}%' ");

            //if (!string.IsNullOrWhiteSpace(BFStrategy))
            //    query.Append($"AND T6.BFStrategy LIKE '%{BFStrategy}%' ");
            //if (!string.IsNullOrWhiteSpace(nameValue))
            //    query.Append($"AND T6.NameValue LIKE '%{nameValue}%' ");

            //if (!string.IsNullOrWhiteSpace(invalidityNumber))
            //    query.Append($"AND T6.InvalidityNumber LIKE '%{invalidityNumber}%' ");
            //if (!string.IsNullOrWhiteSpace(invalidityActionOutcome))
            //    query.Append($"AND T6.InvalidityActionOutcome LIKE '%{invalidityActionOutcome}%' ");

            //if (!string.IsNullOrWhiteSpace(letterReference))
            //    query.Append($"AND T6.LetterReference LIKE '%{letterReference}%' ");
            //if (!string.IsNullOrWhiteSpace(letterOrigin))
            //    query.Append($"AND T6.LetterOrigin LIKE '%{letterOrigin}%' ");
            //if (!string.IsNullOrWhiteSpace(letterSendingMethod))
            //    query.Append($"AND T6.LetterSendingMethod LIKE '%{letterSendingMethod}%' ");
            //if (!string.IsNullOrWhiteSpace(letterOutcome))
            //    query.Append($"AND T6.LetterOutcome LIKE '%{letterOutcome}%' ");

            return query;
        }

        #endregion
    }
}
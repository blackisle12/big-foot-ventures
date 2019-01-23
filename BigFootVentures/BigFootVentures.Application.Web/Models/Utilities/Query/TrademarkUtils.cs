﻿using System;
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

            query.Append("T.*, ");
            query.Append("O.OfficeName AS OfficeName, ");
            query.Append("B.NAME AS BrandName, ");
            query.Append("OO.OfficeName AS OriginalOfficeName, ");
            query.Append("D.Name AS TMWebsiteName, ");
            query.Append("DD.Name AS OwnerWebsiteName, ");
            query.Append("DDD.Name AS ComWebsiteName ");
            query.Append("FROM Trademark T ");
            query.Append("LEFT JOIN Office O ON T.OfficeID = O.ID ");
            query.Append("LEFT JOIN Brand B ON T.BrandID = B.ID ");
            query.Append("LEFT JOIN Office OO ON T.OriginalOfficeID = OO.ID ");
            query.Append("LEFT JOIN DomainN D ON T.TMWebsiteID = D.ID ");
            query.Append("LEFT JOIN DomainN DD ON T.OwnerWebsiteID = DD.ID ");
            query.Append("LEFT JOIN DomainN DDD ON T.ComWebsiteID = DDD.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
                query.Append($"AND T.Name LIKE '%{name}%' ");
            if (!string.IsNullOrWhiteSpace(office))
                query.Append($"AND O.OfficeName LIKE '%{office}%' ");
            if (!string.IsNullOrWhiteSpace(officeStatus))
                query.Append($"AND T.OfficeStatus LIKE '%{officeStatus}%' ");

            if (!string.IsNullOrWhiteSpace(trademarkNumber))
                query.Append($"AND T.TrademarkNumber LIKE '%{trademarkNumber}%' ");
            if (!string.IsNullOrWhiteSpace(figurative))
                query.Append($"AND T.Figurative = {figurative} ");
            if (!string.IsNullOrWhiteSpace(brand))
                query.Append($"AND B.NAME LIKE '%{brand}%' ");
            if (!string.IsNullOrWhiteSpace(figurativeURL))
                query.Append($"AND T.FigurativeURL LIKE '%{figurativeURL}%' ");
            if (!string.IsNullOrWhiteSpace(originalOffice))
                query.Append($"AND T.OriginalOffice LIKE '%{originalOffice}%' ");
            if (!string.IsNullOrWhiteSpace(languageFiling))
                query.Append($"AND T.LanguageFiling LIKE '%{languageFiling}%' ");
            if (!string.IsNullOrWhiteSpace(languageSecond))
                query.Append($"AND T.LanguageSecond LIKE '%{languageSecond}%' ");
            if (!string.IsNullOrWhiteSpace(geography))
                query.Append($"AND T.Geography LIKE '%{geography}%' ");
            if (!string.IsNullOrWhiteSpace(involvedInRevocation))
                query.Append($"AND T.InvolvedInRevocation = {involvedInRevocation} ");
            if (!string.IsNullOrWhiteSpace(bigFootGroupOwned))
                query.Append($"AND T.BigFootGroupOwned LIKE '%{bigFootGroupOwned}%' ");
            if (!string.IsNullOrWhiteSpace(seniorityUsed))
                query.Append($"AND T.SeniorityUsed = {seniorityUsed} ");
            if (!string.IsNullOrWhiteSpace(revocationTarget))
                query.Append($"AND T.RevocationTarget = {revocationTarget} ");

            if (!string.IsNullOrWhiteSpace(openSimilarityResearchTask))
                query.Append($"AND T.OpenSimilarityResearchTask LIKE '%{openSimilarityResearchTask}%' ");
            if (!string.IsNullOrWhiteSpace(oppositionResearch))
                query.Append($"AND T.OppositionResearch LIKE '%{oppositionResearch}%' ");

            if (!string.IsNullOrWhiteSpace(researcherName))
                query.Append($"AND T.ResearcherName LIKE '%{researcherName}%' ");
            if (!string.IsNullOrWhiteSpace(markUse))
                query.Append($"AND T.MarkUse LIKE '%{markUse}%' ");
            if (!string.IsNullOrWhiteSpace(TMWebsite))
                query.Append($"AND T.TMWebsite LIKE '%{TMWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(competingMarks))
                query.Append($"AND T.CompetingMarks = {competingMarks} ");
            if (!string.IsNullOrWhiteSpace(ownerWebsite))
                query.Append($"AND T.OwnerWebsite LIKE '%{ownerWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(cancellationStrategy))
                query.Append($"AND T.CancellationStrategy LIKE '%{cancellationStrategy}%' ");
            if (!string.IsNullOrWhiteSpace(comWebsite))
                query.Append($"AND T.ComWebsite LIKE '%{comWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(ownerDefense))
                query.Append($"AND T.OwnerDefense LIKE '%{ownerDefense}%' ");

            if (!string.IsNullOrWhiteSpace(BFStrategy))
                query.Append($"AND T.BFStrategy LIKE '%{BFStrategy}%' ");
            if (!string.IsNullOrWhiteSpace(nameValue))
                query.Append($"AND T.NameValue LIKE '%{nameValue}%' ");

            if (!string.IsNullOrWhiteSpace(invalidityNumber))
                query.Append($"AND T.InvalidityNumber LIKE '%{invalidityNumber}%' ");
            if (!string.IsNullOrWhiteSpace(invalidityActionOutcome))
                query.Append($"AND T.InvalidityActionOutcome LIKE '%{invalidityActionOutcome}%' ");

            if (!string.IsNullOrWhiteSpace(letterReference))
                query.Append($"AND T.LetterReference LIKE '%{letterReference}%' ");
            if (!string.IsNullOrWhiteSpace(letterOrigin))
                query.Append($"AND T.LetterOrigin LIKE '%{letterOrigin}%' ");
            if (!string.IsNullOrWhiteSpace(letterSendingMethod))
                query.Append($"AND T.LetterSendingMethod LIKE '%{letterSendingMethod}%' ");
            if (!string.IsNullOrWhiteSpace(letterOutcome))
                query.Append($"AND T.LetterOutcome LIKE '%{letterOutcome}%' ");

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
            query.Append("T.*, ");
            query.Append("O.OfficeName AS OfficeName, ");
            query.Append("B.NAME AS BrandName, ");
            query.Append("OO.OfficeName AS OriginalOfficeName, ");
            query.Append("D.Name AS TMWebsiteName, ");
            query.Append("DD.Name AS OwnerWebsiteName, ");
            query.Append("DDD.Name AS ComWebsiteName ");
            query.Append("FROM Trademark T ");
            query.Append("LEFT JOIN Office O ON T.OfficeID = O.ID ");
            query.Append("LEFT JOIN Brand B ON T.BrandID = B.ID ");
            query.Append("LEFT JOIN Office OO ON T.OriginalOfficeID = OO.ID ");
            query.Append("LEFT JOIN DomainN D ON T.TMWebsiteID = D.ID ");
            query.Append("LEFT JOIN DomainN DD ON T.OwnerWebsiteID = DD.ID ");
            query.Append("LEFT JOIN DomainN DDD ON T.ComWebsiteID = DDD.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
                query.Append($"AND T.Name LIKE '%{name}%' ");
            if (!string.IsNullOrWhiteSpace(office))
                query.Append($"AND O.OfficeName LIKE '%{office}%' ");
            if (!string.IsNullOrWhiteSpace(officeStatus))
                query.Append($"AND T.OfficeStatus LIKE '%{officeStatus}%' ");

            if (!string.IsNullOrWhiteSpace(trademarkNumber))
                query.Append($"AND T.TrademarkNumber LIKE '%{trademarkNumber}%' ");
            if (!string.IsNullOrWhiteSpace(figurative))
                query.Append($"AND T.Figurative = {figurative} ");
            if (!string.IsNullOrWhiteSpace(brand))
                query.Append($"AND B.NAME LIKE '%{brand}%' ");
            if (!string.IsNullOrWhiteSpace(figurativeURL))
                query.Append($"AND T.FigurativeURL LIKE '%{figurativeURL}%' ");
            if (!string.IsNullOrWhiteSpace(originalOffice))
                query.Append($"AND T.OriginalOffice LIKE '%{originalOffice}%' ");
            if (!string.IsNullOrWhiteSpace(languageFiling))
                query.Append($"AND T.LanguageFiling LIKE '%{languageFiling}%' ");
            if (!string.IsNullOrWhiteSpace(languageSecond))
                query.Append($"AND T.LanguageSecond LIKE '%{languageSecond}%' ");
            if (!string.IsNullOrWhiteSpace(geography))
                query.Append($"AND T.Geography LIKE '%{geography}%' ");
            if (!string.IsNullOrWhiteSpace(involvedInRevocation))
                query.Append($"AND T.InvolvedInRevocation = {involvedInRevocation} ");
            if (!string.IsNullOrWhiteSpace(bigFootGroupOwned))
                query.Append($"AND T.BigFootGroupOwned LIKE '%{bigFootGroupOwned}%' ");
            if (!string.IsNullOrWhiteSpace(seniorityUsed))
                query.Append($"AND T.SeniorityUsed = {seniorityUsed} ");
            if (!string.IsNullOrWhiteSpace(revocationTarget))
                query.Append($"AND T.RevocationTarget = {revocationTarget} ");

            if (!string.IsNullOrWhiteSpace(openSimilarityResearchTask))
                query.Append($"AND T.OpenSimilarityResearchTask LIKE '%{openSimilarityResearchTask}%' ");
            if (!string.IsNullOrWhiteSpace(oppositionResearch))
                query.Append($"AND T.OppositionResearch LIKE '%{oppositionResearch}%' ");

            if (!string.IsNullOrWhiteSpace(researcherName))
                query.Append($"AND T.ResearcherName LIKE '%{researcherName}%' ");
            if (!string.IsNullOrWhiteSpace(markUse))
                query.Append($"AND T.MarkUse LIKE '%{markUse}%' ");
            if (!string.IsNullOrWhiteSpace(TMWebsite))
                query.Append($"AND T.TMWebsite LIKE '%{TMWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(competingMarks))
                query.Append($"AND T.CompetingMarks = {competingMarks} ");
            if (!string.IsNullOrWhiteSpace(ownerWebsite))
                query.Append($"AND T.OwnerWebsite LIKE '%{ownerWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(cancellationStrategy))
                query.Append($"AND T.CancellationStrategy LIKE '%{cancellationStrategy}%' ");
            if (!string.IsNullOrWhiteSpace(comWebsite))
                query.Append($"AND T.ComWebsite LIKE '%{comWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(ownerDefense))
                query.Append($"AND T.OwnerDefense LIKE '%{ownerDefense}%' ");

            if (!string.IsNullOrWhiteSpace(BFStrategy))
                query.Append($"AND T.BFStrategy LIKE '%{BFStrategy}%' ");
            if (!string.IsNullOrWhiteSpace(nameValue))
                query.Append($"AND T.NameValue LIKE '%{nameValue}%' ");

            if (!string.IsNullOrWhiteSpace(invalidityNumber))
                query.Append($"AND T.InvalidityNumber LIKE '%{invalidityNumber}%' ");
            if (!string.IsNullOrWhiteSpace(invalidityActionOutcome))
                query.Append($"AND T.InvalidityActionOutcome LIKE '%{invalidityActionOutcome}%' ");

            if (!string.IsNullOrWhiteSpace(letterReference))
                query.Append($"AND T.LetterReference LIKE '%{letterReference}%' ");
            if (!string.IsNullOrWhiteSpace(letterOrigin))
                query.Append($"AND T.LetterOrigin LIKE '%{letterOrigin}%' ");
            if (!string.IsNullOrWhiteSpace(letterSendingMethod))
                query.Append($"AND T.LetterSendingMethod LIKE '%{letterSendingMethod}%' ");
            if (!string.IsNullOrWhiteSpace(letterOutcome))
                query.Append($"AND T.LetterOutcome LIKE '%{letterOutcome}%' ");

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
            query.Append("LEFT JOIN Office O ON T.OfficeID = O.ID ");
            query.Append("LEFT JOIN Brand B ON T.BrandID = B.ID ");
            query.Append("LEFT JOIN Office OO ON T.OriginalOfficeID = OO.ID ");
            query.Append("LEFT JOIN DomainN D ON T.TMWebsiteID = D.ID ");
            query.Append("LEFT JOIN DomainN DD ON T.OwnerWebsiteID = DD.ID ");
            query.Append("LEFT JOIN DomainN DDD ON T.ComWebsiteID = DDD.ID ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(name))
                query.Append($"AND T.Name LIKE '%{name}%' ");
            if (!string.IsNullOrWhiteSpace(office))
                query.Append($"AND O.OfficeName LIKE '%{office}%' ");
            if (!string.IsNullOrWhiteSpace(officeStatus))
                query.Append($"AND T.OfficeStatus LIKE '%{officeStatus}%' ");

            if (!string.IsNullOrWhiteSpace(trademarkNumber))
                query.Append($"AND T.TrademarkNumber LIKE '%{trademarkNumber}%' ");
            if (!string.IsNullOrWhiteSpace(figurative))
                query.Append($"AND T.Figurative = {figurative} ");
            if (!string.IsNullOrWhiteSpace(brand))
                query.Append($"AND B.NAME LIKE '%{brand}%' ");
            if (!string.IsNullOrWhiteSpace(figurativeURL))
                query.Append($"AND T.FigurativeURL LIKE '%{figurativeURL}%' ");
            if (!string.IsNullOrWhiteSpace(originalOffice))
                query.Append($"AND T.OriginalOffice LIKE '%{originalOffice}%' ");
            if (!string.IsNullOrWhiteSpace(languageFiling))
                query.Append($"AND T.LanguageFiling LIKE '%{languageFiling}%' ");
            if (!string.IsNullOrWhiteSpace(languageSecond))
                query.Append($"AND T.LanguageSecond LIKE '%{languageSecond}%' ");
            if (!string.IsNullOrWhiteSpace(geography))
                query.Append($"AND T.Geography LIKE '%{geography}%' ");
            if (!string.IsNullOrWhiteSpace(involvedInRevocation))
                query.Append($"AND T.InvolvedInRevocation = {involvedInRevocation} ");
            if (!string.IsNullOrWhiteSpace(bigFootGroupOwned))
                query.Append($"AND T.BigFootGroupOwned LIKE '%{bigFootGroupOwned}%' ");
            if (!string.IsNullOrWhiteSpace(seniorityUsed))
                query.Append($"AND T.SeniorityUsed = {seniorityUsed} ");
            if (!string.IsNullOrWhiteSpace(revocationTarget))
                query.Append($"AND T.RevocationTarget = {revocationTarget} ");

            if (!string.IsNullOrWhiteSpace(openSimilarityResearchTask))
                query.Append($"AND T.OpenSimilarityResearchTask LIKE '%{openSimilarityResearchTask}%' ");
            if (!string.IsNullOrWhiteSpace(oppositionResearch))
                query.Append($"AND T.OppositionResearch LIKE '%{oppositionResearch}%' ");

            if (!string.IsNullOrWhiteSpace(researcherName))
                query.Append($"AND T.ResearcherName LIKE '%{researcherName}%' ");
            if (!string.IsNullOrWhiteSpace(markUse))
                query.Append($"AND T.MarkUse LIKE '%{markUse}%' ");
            if (!string.IsNullOrWhiteSpace(TMWebsite))
                query.Append($"AND T.TMWebsite LIKE '%{TMWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(competingMarks))
                query.Append($"AND T.CompetingMarks = {competingMarks} ");
            if (!string.IsNullOrWhiteSpace(ownerWebsite))
                query.Append($"AND T.OwnerWebsite LIKE '%{ownerWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(cancellationStrategy))
                query.Append($"AND T.CancellationStrategy LIKE '%{cancellationStrategy}%' ");
            if (!string.IsNullOrWhiteSpace(comWebsite))
                query.Append($"AND T.ComWebsite LIKE '%{comWebsite}%' ");
            if (!string.IsNullOrWhiteSpace(ownerDefense))
                query.Append($"AND T.OwnerDefense LIKE '%{ownerDefense}%' ");

            if (!string.IsNullOrWhiteSpace(BFStrategy))
                query.Append($"AND T.BFStrategy LIKE '%{BFStrategy}%' ");
            if (!string.IsNullOrWhiteSpace(nameValue))
                query.Append($"AND T.NameValue LIKE '%{nameValue}%' ");

            if (!string.IsNullOrWhiteSpace(invalidityNumber))
                query.Append($"AND T.InvalidityNumber LIKE '%{invalidityNumber}%' ");
            if (!string.IsNullOrWhiteSpace(invalidityActionOutcome))
                query.Append($"AND T.InvalidityActionOutcome LIKE '%{invalidityActionOutcome}%' ");

            if (!string.IsNullOrWhiteSpace(letterReference))
                query.Append($"AND T.LetterReference LIKE '%{letterReference}%' ");
            if (!string.IsNullOrWhiteSpace(letterOrigin))
                query.Append($"AND T.LetterOrigin LIKE '%{letterOrigin}%' ");
            if (!string.IsNullOrWhiteSpace(letterSendingMethod))
                query.Append($"AND T.LetterSendingMethod LIKE '%{letterSendingMethod}%' ");
            if (!string.IsNullOrWhiteSpace(letterOutcome))
                query.Append($"AND T.LetterOutcome LIKE '%{letterOutcome}%' ");

            return query;
        }

        #endregion
    }
}
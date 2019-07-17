using System;
using System.Text;

namespace BigFootVentures.Application.Web.Models.Utilities.Query
{
    public static class OfficeUtils
    {
        #region "Public Methods"

        public static Tuple<string, string> BuildQuery(int startIndex, int rowCount,
            string officeName = null, string state = null, string officeURL = null, string online = null, string officeNameArchive = null, string PCT = null, string WTO = null,
            string geographyType = null, string office = null, string officeValueCategory = null, string searchURL = null, string nationalNumberAssigned = null, string paris = null)
        {
            StringBuilder query = null;
            StringBuilder queryTotal = null;

            query = BuildQuery(new StringBuilder().Append("SELECT "), startIndex, rowCount,
                officeName, state, officeURL, online, officeNameArchive, PCT, WTO, geographyType, office, officeValueCategory, searchURL, nationalNumberAssigned, paris);
                
            queryTotal = BuildTotalQuery(new StringBuilder().Append("SELECT "),
                officeName, state, officeURL, online, officeNameArchive, PCT, WTO, geographyType, office, officeValueCategory, searchURL, nationalNumberAssigned, paris);

            return new Tuple<string, string>(query.ToString(), queryTotal.ToString());
        }

        public static string BuildExportQuery(string officeName = null, string state = null, string officeURL = null, string online = null, string officeNameArchive = null, string PCT = null, string WTO = null,
            string geographyType = null, string office = null, string officeValueCategory = null, string searchURL = null, string nationalNumberAssigned = null, string paris = null)
        {
            var query = new StringBuilder().Append("SELECT ");

            query.Append("* ");
            query.Append("FROM Office ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(officeName))
            {
                query.Append($"AND OfficeName LIKE '%{officeName.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                query.Append($"AND State LIKE '%{state.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeURL))
            {
                query.Append($"AND OfficeURL LIKE '%{officeURL.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(online))
            {
                query.Append($"AND Online = {online} ");
            }

            if (!string.IsNullOrWhiteSpace(officeNameArchive))
            {
                query.Append($"AND OfficeNameArchive LIKE '%{officeNameArchive.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(PCT))
            {
                query.Append($"AND PCT = {PCT} ");
            }

            if (!string.IsNullOrWhiteSpace(WTO))
            {
                query.Append($"AND WTO = {WTO} ");
            }

            if (!string.IsNullOrWhiteSpace(geographyType))
            {
                query.Append($"AND GeographyType LIKE '%{geographyType.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(office))
            {
                query.Append($"AND Office LIKE '%{office.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeValueCategory))
            {
                query.Append($"AND OfficeValueCategory LIKE '%{officeValueCategory.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(searchURL))
            {
                query.Append($"AND SearchURL LIKE '%{searchURL.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nationalNumberAssigned))
            {
                query.Append($"AND NationalNumberAssigned = {nationalNumberAssigned} ");
            }

            if (!string.IsNullOrWhiteSpace(paris))
            {
                query.Append($"AND Paris = {paris} ");
            }

            query.Append("ORDER BY OfficeName");

            return query.ToString();
        }

        #endregion

        #region "Private Methods"

        private static StringBuilder BuildQuery(StringBuilder query, int startIndex, int rowCount,
            string officeName = null, string state = null, string officeURL = null, string online = null, string officeNameArchive = null, string PCT = null, string WTO = null,
            string geographyType = null, string office = null, string officeValueCategory = null, string searchURL = null, string nationalNumberAssigned = null, string paris = null)
        {
            query.Append("* ");
            query.Append("FROM Office ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(officeName))
            {
                query.Append($"AND OfficeName LIKE '%{officeName.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                query.Append($"AND State LIKE '%{state.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeURL))
            {
                query.Append($"AND OfficeURL LIKE '%{officeURL.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(online))
            {
                query.Append($"AND Online = {online} ");
            }

            if (!string.IsNullOrWhiteSpace(officeNameArchive))
            {
                query.Append($"AND OfficeNameArchive LIKE '%{officeNameArchive.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(PCT))
            {
                query.Append($"AND PCT = {PCT} ");
            }

            if (!string.IsNullOrWhiteSpace(WTO))
            {
                query.Append($"AND WTO = {WTO} ");
            }

            if (!string.IsNullOrWhiteSpace(geographyType))
            {
                query.Append($"AND GeographyType LIKE '%{geographyType.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(office))
            {
                query.Append($"AND Office LIKE '%{office.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeValueCategory))
            {
                query.Append($"AND OfficeValueCategory LIKE '%{officeValueCategory.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(searchURL))
            {
                query.Append($"AND SearchURL LIKE '%{searchURL.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nationalNumberAssigned))
            {
                query.Append($"AND NationalNumberAssigned = {nationalNumberAssigned} ");
            }

            if (!string.IsNullOrWhiteSpace(paris))
            {
                query.Append($"AND Paris = {paris} ");
            }

            query.Append($"ORDER BY OfficeName LIMIT {startIndex},{rowCount}");

            return query;
        }

        private static StringBuilder BuildTotalQuery(StringBuilder query,
            string officeName = null, string state = null, string officeURL = null, string online = null, string officeNameArchive = null, string PCT = null, string WTO = null,
            string geographyType = null, string office = null, string officeValueCategory = null, string searchURL = null, string nationalNumberAssigned = null, string paris = null)
        {
            query.Append("COUNT(ID) INTO @total ");
            query.Append("FROM Office ");
            query.Append($"WHERE 0 = 0 ");

            if (!string.IsNullOrWhiteSpace(officeName))
            {
                query.Append($"AND OfficeName LIKE '%{officeName.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(state))
            {
                query.Append($"AND State LIKE '%{state.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeURL))
            {
                query.Append($"AND OfficeURL LIKE '%{officeURL.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(online))
            {
                query.Append($"AND Online = {online} ");
            }

            if (!string.IsNullOrWhiteSpace(officeNameArchive))
            {
                query.Append($"AND OfficeNameArchive LIKE '%{officeNameArchive.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(PCT))
            {
                query.Append($"AND PCT = {PCT} ");
            }

            if (!string.IsNullOrWhiteSpace(WTO))
            {
                query.Append($"AND WTO = {WTO} ");
            }

            if (!string.IsNullOrWhiteSpace(geographyType))
            {
                query.Append($"AND GeographyType LIKE '%{geographyType.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(office))
            {
                query.Append($"AND Office LIKE '%{office.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(officeValueCategory))
            {
                query.Append($"AND OfficeValueCategory LIKE '%{officeValueCategory.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(searchURL))
            {
                query.Append($"AND SearchURL LIKE '%{searchURL.Replace("'", "''")}%' ");
            }

            if (!string.IsNullOrWhiteSpace(nationalNumberAssigned))
            {
                query.Append($"AND NationalNumberAssigned = {nationalNumberAssigned} ");
            }

            if (!string.IsNullOrWhiteSpace(paris))
            {
                query.Append($"AND Paris = {paris} ");
            }

            return query;
        }

        #endregion
    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;

namespace BigFootVentures.Application.Web.Models.Utilities
{
    public static class StringUtils
    {
        #region "Public Methods"

        public static ICollection<string> GetCountries()
        {
            var countries = new List<string> { string.Empty };
            var query = from ri in
                        from ci in CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                        select new RegionInfo(ci.LCID)
                        group ri by ri.TwoLetterISORegionName into g
                        select g.First().DisplayName;

            countries.AddRange(query.OrderBy(i => i).ToList());

            return countries;
        }

        public static string GenerateRandomString()
        {
            try
            {
                var length = Convert.ToInt32(ConfigurationManager.AppSettings["PasswordDefaultLength"]);
                var result = new char[length];
                var random = new Random();
                var allowedCharacters = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789!@$?_";

                for (int i = 0; i < length; i++)
                {
                    result[i] = allowedCharacters[random.Next(0, allowedCharacters.Length)];
                }

                return new string(result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static string GetCurrentDateTimeAsString()
        {
            return SessionUtils.GetCurrentDateTime().ToString("yyyyMMdd-HHmmss");
        }

        #endregion
    }
}
using System.Collections.Generic;
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

        #endregion
    }
}
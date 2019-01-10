using System.Collections.Generic;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMSearchAdvanceFilters
    {
        #region "Properties"

        public string Key { get; set; }
        public string Value { get; set; }

        #endregion
    }

    public sealed class VMSearchAdvance
    {
        #region "Properties"

        public string Object { get; set; }
        public ICollection<VMSearchAdvanceFilters> Filters { get; set; }

        #endregion
    }
}
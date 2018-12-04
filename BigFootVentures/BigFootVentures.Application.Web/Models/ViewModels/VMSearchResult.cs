using BigFootVentures.Business.Objects.Wrapper;
using System.Collections.Generic;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMSearchResult
    {
        #region "Properties"

        public ICollection<SearchResultWrapper> Table { get; set; }

        #endregion
    }
}
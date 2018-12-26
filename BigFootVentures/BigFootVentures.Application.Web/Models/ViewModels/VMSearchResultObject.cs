using BigFootVentures.Business.Objects;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMSearchResultObject<TModel> where TModel : BusinessBase
    {
        #region "Properties"

        public string Caption { get; set; }

        public VMSearchResult SearchResult { get; set; }

        public VMPageResult<TModel> ObjectResult { get; set; }

        #endregion
    }
}
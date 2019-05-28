using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Business.Objects;
using System.Collections.Generic;

namespace BigFootVentures.Application.Web.Models.ViewModels
{
    public sealed class VMPageResult<TModel> where TModel : BusinessBase
    {
        #region "Properties"

        public ICollection<TModel> Records { get; set; }
        public int StartIndex { get; set; } = 0;
        public int RowCount { get; set; }
        public int Page { get; set; } = 1;
        public int Pages { get { return PageUtils.GetPageCount(this.Total, this.RowCount); } }
        public int Total { get; set; }

        public bool IsRedirectFromDelete { get; set; } = false;
        public string DeleteMessage { get { return $"{typeof(TModel).Name} have been removed successfully."; } }

        public string Name { get { return typeof(TModel).Name; } }
        public string Header { get; set; }

        public string SortBy { get; set; }
        public string SortOrder { get; set; }

        #endregion
    }
}
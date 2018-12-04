using System.Collections.Generic;

namespace BigFootVentures.Business.Objects.Wrapper
{
    public sealed class SearchResultWrapper
    {
        #region "Properties"

        public int ID { get; set; }
        public string Caption { get; set; }
        public ICollection<string> Header { get; set; }
        public ICollection<List<string>> Rows { get; set; }

        #endregion
    }
}

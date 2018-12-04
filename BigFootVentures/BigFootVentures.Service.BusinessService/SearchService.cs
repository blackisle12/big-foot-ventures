using BigFootVentures.Business.DataAccess;
using BigFootVentures.Business.Objects.Wrapper;
using System.Collections.Generic;

namespace BigFootVentures.Service.BusinessService
{
    public interface ISearchService
    {
        #region "Factory Methods"

        ICollection<SearchResultWrapper> Search(string keyword);

        #endregion
    }

    public sealed class SearchService : ISearchService
    {
        #region "Private Members"

        private readonly string _connectionString = null;

        #endregion

        #region "Constructors"

        public SearchService(string connectionString)
        {
            this._connectionString = connectionString;
        }

        #endregion

        #region "Factory Methods"

        public ICollection<SearchResultWrapper> Search(string keyword)
        {
            using (var searchDataAccess = new SearchDataAccess(this._connectionString))
            {
                return searchDataAccess.Search(keyword);
            }
        }

        #endregion
    }
}

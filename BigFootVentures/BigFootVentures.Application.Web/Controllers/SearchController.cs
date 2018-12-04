using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Wrapper;
using BigFootVentures.Service.BusinessService;
using System.Collections.Generic;
using System.Web.Mvc;

namespace BigFootVentures.Application.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Search")]
    public class SearchController : Controller
    {
        #region "Private Members"

        private readonly ISearchService _searchService = null;

        #endregion

        #region "Constructors"

        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }

        #endregion

        #region "Action Methods"

        [Route("Index/{keyword}", Name = "Search")]
        public ActionResult Index(string keyword)
        {
            var searchResultWrapperList = this._searchService.Search(keyword);
            var searchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResult);
        }

        #endregion
    }
}
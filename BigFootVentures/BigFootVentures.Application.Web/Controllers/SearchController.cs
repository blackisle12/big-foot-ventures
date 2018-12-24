using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System.Web.Mvc;

namespace BigFootVentures.Application.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Search")]
    public class SearchController : Controller
    {
        #region "Private Members"

        private readonly ISearchService _searchService = null;

        private readonly IManagementService<AgreementT> _managementAgreementService = null;
        private readonly IManagementService<Brand> _managementBrandService = null;

        #endregion

        #region "Constructors"

        public SearchController(ISearchService searchService,
            IManagementService<AgreementT> managementAgreementService,
            IManagementService<Brand> managementBrandService)
        {
            this._searchService = searchService;

            this._managementAgreementService = managementAgreementService;
            this._managementBrandService = managementBrandService;
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

        [Route("Agreement/{rowCount?}/{page?}/{keyword?}", Name = "SearchAgreement")]
        public ActionResult Agreement(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<AgreementT>();
            var startIndex = (page - 1) * rowCount;
            var agreements = string.IsNullOrWhiteSpace(keyword) ?
                this._managementAgreementService.Get(startIndex, rowCount, out int total) :
                this._managementAgreementService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<AgreementT>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = agreements
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Brand/{rowCount?}/{page?}/{keyword?}", Name = "SearchBrand")]
        public ActionResult Brand(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Brand>();
            var startIndex = (page - 1) * rowCount;
            var brands = string.IsNullOrWhiteSpace(keyword) ?
                this._managementBrandService.Get(startIndex, rowCount, out int total) :
                this._managementBrandService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Brand>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = brands
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        #endregion
    }
}
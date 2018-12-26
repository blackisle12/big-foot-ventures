﻿using BigFootVentures.Application.Web.Models.ViewModels;
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
        private readonly IManagementService<Cancellation> _managementCancellationService = null;
        private readonly IManagementService<Company> _managementCompanyService = null;
        private readonly IManagementService<Contact> _managementContactService = null;
        private readonly IManagementService<DomainN> _managementDomainService = null;
        private readonly IManagementService<Enquiry> _managementEnquiryService = null;
        private readonly IManagementService<Lead> _managementLeadService = null;
        private readonly IManagementService<LegalCase> _managementLegalCaseService = null;
        private readonly IManagementService<Office> _managementOfficeService = null;
        private readonly IManagementService<Register> _managementRegisterService = null;
        private readonly IManagementService<Trademark> _managementTrademarkService = null;

        #endregion

        #region "Constructors"

        public SearchController(ISearchService searchService,
            IManagementService<AgreementT> managementAgreementService,
            IManagementService<Brand> managementBrandService,
            IManagementService<Cancellation> managementCancellationService,
            IManagementService<Company> managementCompanyService,
            IManagementService<Contact> managementContactService,
            IManagementService<DomainN> managementDomainService,
            IManagementService<Enquiry> managementEnquiryService,
            IManagementService<Lead> managementLeadService,
            IManagementService<LegalCase> managementLegalCaseService,
            IManagementService<Office> managementOfficeService,
            IManagementService<Register> managementRegisterService,
            IManagementService<Trademark> managementTrademarkService)
        {
            this._searchService = searchService;

            this._managementAgreementService = managementAgreementService;
            this._managementBrandService = managementBrandService;
            this._managementCancellationService = managementCancellationService;
            this._managementCompanyService = managementCompanyService;
            this._managementContactService = managementContactService;
            this._managementDomainService = managementDomainService;
            this._managementEnquiryService = managementEnquiryService;
            this._managementLeadService = managementLeadService;
            this._managementLegalCaseService = managementLegalCaseService;
            this._managementOfficeService = managementOfficeService;
            this._managementRegisterService = managementRegisterService;
            this._managementTrademarkService = managementTrademarkService;
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
            var searchResultObject = new VMSearchResultObject<AgreementT> { Caption = "Agreement" };
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
            var searchResultObject = new VMSearchResultObject<Brand> { Caption = "Brand" };
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

        [Route("Cancellation/{rowCount?}/{page?}/{keyword?}", Name = "SearchCancellation")]
        public ActionResult Cancellation(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Cancellation> { Caption = "Cancellation" };
            var startIndex = (page - 1) * rowCount;
            var cancellations = string.IsNullOrWhiteSpace(keyword) ?
                this._managementCancellationService.Get(startIndex, rowCount, out int total) :
                this._managementCancellationService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Cancellation>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = cancellations
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Company/{rowCount?}/{page?}/{keyword?}", Name = "SearchCompany")]
        public ActionResult Company(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Company> { Caption = "Company" };
            var startIndex = (page - 1) * rowCount;
            var companies = string.IsNullOrWhiteSpace(keyword) ?
                this._managementCompanyService.Get(startIndex, rowCount, out int total) :
                this._managementCompanyService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Company>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = companies
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Contact/{rowCount?}/{page?}/{keyword?}", Name = "SearchContact")]
        public ActionResult Contact(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Contact> { Caption = "Contact" };
            var startIndex = (page - 1) * rowCount;
            var contacts = string.IsNullOrWhiteSpace(keyword) ?
                this._managementContactService.Get(startIndex, rowCount, out int total) :
                this._managementContactService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Contact>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = contacts
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Domain/{rowCount?}/{page?}/{keyword?}", Name = "SearchDomain")]
        public ActionResult Domain(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<DomainN> { Caption = "Domain" };
            var startIndex = (page - 1) * rowCount;
            var domains = string.IsNullOrWhiteSpace(keyword) ?
                this._managementDomainService.Get(startIndex, rowCount, out int total) :
                this._managementDomainService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<DomainN>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = domains
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Enquiry/{rowCount?}/{page?}/{keyword?}", Name = "SearchEnquiry")]
        public ActionResult Enquiry(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Enquiry> { Caption = "Enquiry" };
            var startIndex = (page - 1) * rowCount;
            var enquiries = string.IsNullOrWhiteSpace(keyword) ?
                this._managementEnquiryService.Get(startIndex, rowCount, out int total) :
                this._managementEnquiryService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Enquiry>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = enquiries
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Lead/{rowCount?}/{page?}/{keyword?}", Name = "SearchLead")]
        public ActionResult Lead(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Lead> { Caption = "Lead" };
            var startIndex = (page - 1) * rowCount;
            var leads = string.IsNullOrWhiteSpace(keyword) ?
                this._managementLeadService.Get(startIndex, rowCount, out int total) :
                this._managementLeadService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Lead>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = leads
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("LegalCase/{rowCount?}/{page?}/{keyword?}", Name = "SearchLegalCase")]
        public ActionResult LegalCase(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<LegalCase> { Caption = "Legal Case" };
            var startIndex = (page - 1) * rowCount;
            var legalCases = string.IsNullOrWhiteSpace(keyword) ?
                this._managementLegalCaseService.Get(startIndex, rowCount, out int total) :
                this._managementLegalCaseService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<LegalCase>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = legalCases
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Office/{rowCount?}/{page?}/{keyword?}", Name = "SearchOffice")]
        public ActionResult Office(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Office> { Caption = "Office" };
            var startIndex = (page - 1) * rowCount;
            var offices = string.IsNullOrWhiteSpace(keyword) ?
                this._managementOfficeService.Get(startIndex, rowCount, out int total) :
                this._managementOfficeService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Office>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = offices
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Register/{rowCount?}/{page?}/{keyword?}", Name = "SearchRegister")]
        public ActionResult Register(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Register> { Caption = "Registrar" };
            var startIndex = (page - 1) * rowCount;
            var registers = string.IsNullOrWhiteSpace(keyword) ?
                this._managementRegisterService.Get(startIndex, rowCount, out int total) :
                this._managementRegisterService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Register>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = registers
            };

            var searchResultWrapperList = this._searchService.Search(keyword);

            searchResultObject.SearchResult = new VMSearchResult
            {
                Table = searchResultWrapperList
            };

            ViewBag.Keyword = keyword;

            return View(searchResultObject);
        }

        [Route("Trademark/{rowCount?}/{page?}/{keyword?}", Name = "SearchTrademark")]
        public ActionResult Trademark(int rowCount = 25, int page = 1, string keyword = "")
        {
            var searchResultObject = new VMSearchResultObject<Trademark> { Caption = "Trademark" };
            var startIndex = (page - 1) * rowCount;
            var trademarks = string.IsNullOrWhiteSpace(keyword) ?
                this._managementTrademarkService.Get(startIndex, rowCount, out int total) :
                this._managementTrademarkService.GetByKeyword(keyword, startIndex, rowCount, out total);

            searchResultObject.ObjectResult = new VMPageResult<Trademark>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = trademarks
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
using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.Utilities.Query;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System.Text;
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

        #region "Agreement"

        [Route("Agreement/{rowCount?}/{page?}/{keyword?}", Name = "SearchAgreement")]
        public ActionResult Agreement(int rowCount = 25, int page = 1, string keyword = null,
            string name = null, string BFCompany = null, string counterpart = null, string objectOfAgreement = null, string type = null)
        {
            var searchResultObject = new VMSearchResultObject<AgreementT> { Caption = "Agreement" };
            var startIndex = (page - 1) * rowCount;

            var query = AgreementUtils.BuildQuery(startIndex, rowCount, keyword ?? name, BFCompany, counterpart, objectOfAgreement, type);
            var agreements = this._managementAgreementService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<AgreementT>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = agreements
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(name ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? name;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Agreement/Export/{keyword}", Name = "AgreementExportWithKeyword")]
        [Route("Agreement/Export", Name = "AgreementExport")]
        public FileContentResult AgreementExport(string keyword = null, string name = null, string BFCompany = null, string counterpart = null, string objectOfAgreement = null, string type = null)
        {
            var query = AgreementUtils.BuildExportQuery(keyword ?? name, BFCompany, counterpart, objectOfAgreement, type);
            var file = this._managementAgreementService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Agreement-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Brand"

        [Route("Brand/{rowCount?}/{page?}/{keyword?}", Name = "SearchBrand")]
        public ActionResult Brand(int rowCount = 25, int page = 1, string keyword = null,
            string name = null, string purpose = null, string value = null, string category = null, string HVT = null)
        {
            var searchResultObject = new VMSearchResultObject<Brand> { Caption = "Brand" };
            var startIndex = (page - 1) * rowCount;

            var query = BrandUtils.BuildQuery(startIndex, rowCount, keyword ?? name, purpose, value, category, HVT);
            var brands = this._managementBrandService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Brand>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = brands
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(name ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? name;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Brand/Export/{keyword}", Name = "BrandExportWithKeyword")]
        [Route("Brand/Export", Name = "BrandExport")]
        public FileContentResult BrandExport(string keyword = null, string name = null, string purpose = null, string value = null, string category = null, string HVT = null)
        {
            var query = BrandUtils.BuildExportQuery(keyword ?? name, purpose, value, category, HVT);
            var file = this._managementBrandService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Brand-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Cancellation"

        [Route("Cancellation/{rowCount?}/{page?}/{keyword?}", Name = "SearchCancellation")]
        public ActionResult Cancellation(int rowCount = 25, int page = 1, string keyword = null,
            string referenceInternal = null, string referenceExternal = null, string sentOrigin = null, string internalCaseNumber = null,
            string submissionMethod = null, string applicant = null, string trademark = null, string researchPerformance = null, string status = null, string acquisitionLetterSentOrigin = null,
            string acquisitionLetterSentMethod = null, string UDRPStrategy = null, string ownerResponseAcquisitionLetter = null, string domainEnquiry = null, string outcome = null)
        {
            var searchResultObject = new VMSearchResultObject<Cancellation> { Caption = "Cancellation" };
            var startIndex = (page - 1) * rowCount;

            var query = CancellationUtils.BuildQuery(startIndex, rowCount,
                keyword ?? referenceInternal, referenceExternal, sentOrigin, internalCaseNumber,
                submissionMethod, applicant, trademark, researchPerformance, status, acquisitionLetterSentOrigin,
                acquisitionLetterSentMethod, UDRPStrategy, ownerResponseAcquisitionLetter, domainEnquiry, outcome);

            var cancellations = this._managementCancellationService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Cancellation>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = cancellations
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(referenceInternal ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? referenceInternal;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Cancellation/Export/{keyword}", Name = "CancellationExportWithKeyword")]
        [Route("Cancellation/Export", Name = "CancellationExport")]
        public FileContentResult CancellationExport(string keyword = null, 
            string referenceInternal = null, string referenceExternal = null, string sentOrigin = null, string internalCaseNumber = null, 
            string submissionMethod = null, string applicant = null, string trademark = null, string researchPerformance = null, string status = null, string acquisitionLetterSentOrigin = null, 
            string acquisitionLetterSentMethod = null, string UDRPStrategy = null, string ownerResponseAcquisitionLetter = null, string domainEnquiry = null, string outcome = null)
        {
            var query = CancellationUtils.BuildExportQuery(keyword ?? referenceInternal, referenceExternal, sentOrigin, internalCaseNumber,
                submissionMethod, applicant, trademark, researchPerformance, status, acquisitionLetterSentOrigin,
                acquisitionLetterSentMethod, UDRPStrategy, ownerResponseAcquisitionLetter, domainEnquiry, outcome);
            var file = this._managementCancellationService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Cancellation-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Company"

        [Route("Company/{rowCount?}/{page?}/{keyword?}", Name = "SearchCompany")]
        public ActionResult Company(int rowCount = 25, int page = 1, string keyword = null,
            string name = null, string accountRecordType = null, string formerName = null, string type = null, string parentAccount = null, string phone = null,
            string fax = null, string email = null, string companySize = null, string industry = null, string nameID = null, string employees = null, string officeIDGB = null, string OHIMNumOppositions = null,
            string escrowAgent = null, string broker = null, string companyRegistrationNumber = null, string countryOfIncorporation = null, string officers = null, string taxNumber = null,
            string bigFootAccredited = null, string shippingCountry = null)
        {
            var searchResultObject = new VMSearchResultObject<Company> { Caption = "Company" };
            var startIndex = (page - 1) * rowCount;

            var query = CompanyUtils.BuildQuery(startIndex, rowCount,
                keyword ?? name, accountRecordType, formerName, type, parentAccount, phone,
                fax, email, companySize, industry, nameID, employees, officeIDGB, OHIMNumOppositions,
                escrowAgent, broker, companyRegistrationNumber, countryOfIncorporation, officers, taxNumber,
                bigFootAccredited, shippingCountry);

            var companies = this._managementCompanyService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Company>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = companies
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(name ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? name;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Company/Export/{keyword}", Name = "CompanyExportWithKeyword")]
        [Route("Company/Export", Name = "CompanyExport")]
        public FileContentResult CompanyExport(string keyword = null, 
            string name = null, string accountRecordType = null, string formerName = null, string type = null, string parentAccount = null, string phone = null,
            string fax = null, string email = null, string companySize = null, string industry = null, string nameID = null, string employees = null, string officeIDGB = null, string OHIMNumOppositions = null,
            string escrowAgent = null, string broker = null, string companyRegistrationNumber = null, string countryOfIncorporation = null, string officers = null, string taxNumber = null,
            string bigFootAccredited = null, string shippingCountry = null)
        {
            var query = CompanyUtils.BuildExportQuery(keyword ?? name, accountRecordType, formerName, type, parentAccount, phone,
                fax, email, companySize, industry, nameID, employees, officeIDGB, OHIMNumOppositions,
                escrowAgent, broker, companyRegistrationNumber, countryOfIncorporation, officers, taxNumber,
                bigFootAccredited, shippingCountry);
            var file = this._managementCompanyService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Company-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Contact"

        [Route("Contact/{rowCount?}/{page?}/{keyword?}", Name = "SearchContact")]
        public ActionResult Contact(int rowCount = 25, int page = 1, string keyword = null,
            string firstName = null, string middleName = null, string lastName = null, string department = null, string fax = null,
            string email = null, string phone = null, string mobile = null, string OHIMOwnerID = null, string OHIMNumTrademarks = null)
        {
            var searchResultObject = new VMSearchResultObject<Contact> { Caption = "Contact" };
            var startIndex = (page - 1) * rowCount;

            var query = ContactUtils.BuildQuery(startIndex, rowCount, keyword ??
                firstName, middleName, lastName, department, fax, email, phone, mobile, OHIMOwnerID, OHIMNumTrademarks);
            var contacts = this._managementContactService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Contact>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = contacts
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(firstName ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? firstName;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Contact/Export/{keyword}", Name = "ContactExportWithKeyword")]
        [Route("Contact/Export", Name = "ContactExport")]
        public FileContentResult ContactExport(string keyword = null,
            string firstName = null, string middleName = null, string lastName = null, string department = null, string fax = null,
            string email = null, string phone = null, string mobile = null, string OHIMOwnerID = null, string OHIMNumTrademarks = null)
        {
            var query = ContactUtils.BuildExportQuery(keyword ??
                firstName, middleName, lastName, department, fax, email, phone, mobile, OHIMOwnerID, OHIMNumTrademarks);
            var file = this._managementContactService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Contact-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Domain"

        [Route("Domain/{rowCount?}/{page?}/{keyword?}", Name = "SearchDomain")]
        public ActionResult Domain(int rowCount = 25, int page = 1, string keyword = null,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            var searchResultObject = new VMSearchResultObject<DomainN> { Caption = "Domain" };
            var startIndex = (page - 1) * rowCount;

            var query = DomainUtils.BuildQuery(startIndex, rowCount, keyword ?? name, bigFootOwned, websiteCurrent, locked, websiteUse, BFStrategy,
                buySideFunnel, FMVOrderOfMagnitude, companyWebsite, status, autoRenew, version, WHOIS, category);
            var domains = this._managementDomainService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<DomainN>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = domains
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(name ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? name;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Domain/Export/{keyword}", Name = "DomainExportWithKeyword")]
        [Route("Domain/Export", Name = "DomainExport")]
        public FileContentResult DomainExport(string keyword = null,
            string name = null, string bigFootOwned = null, string websiteCurrent = null, string locked = null, string websiteUse = null, string BFStrategy = null,
            string buySideFunnel = null, string FMVOrderOfMagnitude = null, string companyWebsite = null, string status = null, string autoRenew = null,
            string version = null, string WHOIS = null, string category = null)
        {
            var query = DomainUtils.BuildExportQuery(keyword ?? name, bigFootOwned, websiteCurrent, locked, websiteUse, BFStrategy,
                buySideFunnel, FMVOrderOfMagnitude, companyWebsite, status, autoRenew, version, WHOIS, category);
            var file = this._managementDomainService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Domain-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Enquiry"

        [Route("Enquiry/{rowCount?}/{page?}/{keyword?}", Name = "SearchEnquiry")]
        public ActionResult Enquiry(int rowCount = 25, int page = 1, string keyword = null,
            string caseNumber = null, string status = null, string caseAssign = null, string priority = null, string subject = null)
        {
            var searchResultObject = new VMSearchResultObject<Enquiry> { Caption = "Enquiry" };
            var startIndex = (page - 1) * rowCount;

            var query = EnquiryUtils.BuildQuery(startIndex, rowCount, keyword ??
                caseNumber, status, caseAssign, priority, subject);
            var enquiries = this._managementEnquiryService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Enquiry>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = enquiries
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(caseNumber ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? caseNumber;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Enquiry/Export/{keyword}", Name = "EnquiryExportWithKeyword")]
        [Route("Enquiry/Export", Name = "EnquiryExport")]
        public FileContentResult EnquiryExport(string keyword = null,
            string caseNumber = null, string status = null, string caseAssign = null, string priority = null, string subject = null)
        {
            var query = EnquiryUtils.BuildExportQuery(keyword ??
                caseNumber, status, caseAssign, priority, subject);
            var file = this._managementEnquiryService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Enquiry-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Lead"

        [Route("Lead/{rowCount?}/{page?}/{keyword?}", Name = "SearchLead")]
        public ActionResult Lead(int rowCount = 25, int page = 1, string keyword = null,
            string status = null, string firstName = null, string middleName = null, string lastName = null, string email = null, string phone = null,
            string company = null, string industry = null, string source = null)
        {
            var searchResultObject = new VMSearchResultObject<Lead> { Caption = "Lead" };
            var startIndex = (page - 1) * rowCount;

            var query = LeadUtils.BuildQuery(startIndex, rowCount, keyword ??
                status, firstName, middleName, lastName, email, phone, company, industry, source);
            var leads = this._managementLeadService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Lead>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = leads
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(firstName ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? firstName;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Lead/Export/{keyword}", Name = "LeadExportWithKeyword")]
        [Route("Lead/Export", Name = "LeadExport")]
        public FileContentResult AgreementExport(string keyword = null,
            string status = null, string firstName = null, string middleName = null, string lastName = null, string email = null, string phone = null,
            string company = null, string industry = null, string source = null)
        {
            var query = LeadUtils.BuildExportQuery(keyword ??
                status, firstName, middleName, lastName, email, phone, company, industry, source);
            var file = this._managementLeadService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Lead-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Legal Case"
        #endregion

        #region "Office"

        [Route("Office/{rowCount?}/{page?}/{keyword?}", Name = "SearchOffice")]
        public ActionResult Office(int rowCount = 25, int page = 1, string keyword = null,
            string officeName = null, string state = null, string officeURL = null, string online = null, string officeNameArchive = null, string PCT = null, string WTO = null,
            string geographyType = null, string office = null, string officeValueCategory = null, string searchURL = null, string nationalNumberAssigned = null, string paris = null)
        {
            var searchResultObject = new VMSearchResultObject<Office> { Caption = "Office" };
            var startIndex = (page - 1) * rowCount;

            var query = OfficeUtils.BuildQuery(startIndex, rowCount, keyword ??
                officeName, state, officeURL, online, officeNameArchive, PCT, WTO, geographyType, office, officeValueCategory, searchURL, nationalNumberAssigned, paris);
            var offices = this._managementOfficeService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Office>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = offices
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(officeName ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? officeName;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Office/Export/{keyword}", Name = "OfficeExportWithKeyword")]
        [Route("Office/Export", Name = "OfficeExport")]
        public FileContentResult OfficeExport(string keyword = null,
            string officeName = null, string state = null, string officeURL = null, string online = null, string officeNameArchive = null, string PCT = null, string WTO = null,
            string geographyType = null, string office = null, string officeValueCategory = null, string searchURL = null, string nationalNumberAssigned = null, string paris = null)
        {
            var query = OfficeUtils.BuildExportQuery(keyword ??
                officeName, state, officeURL, online, officeNameArchive, PCT, WTO, geographyType, office, officeValueCategory, searchURL, nationalNumberAssigned, paris);
            var file = this._managementOfficeService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Office-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Register"

        [Route("Register/{rowCount?}/{page?}/{keyword?}", Name = "SearchRegister")]
        public ActionResult Register(int rowCount = 25, int page = 1, string keyword = null,
            string name = null, string RAAYear = null, string country = null, string accreditedTLDs = null)
        {
            var searchResultObject = new VMSearchResultObject<Register> { Caption = "Registrar" };
            var startIndex = (page - 1) * rowCount;

            var query = RegisterUtils.BuildQuery(startIndex, rowCount, keyword ??
                name, RAAYear, country, accreditedTLDs);
            var registers = this._managementRegisterService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Register>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = registers
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(name ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? name;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Register/Export/{keyword}", Name = "RegisterExportWithKeyword")]
        [Route("Register/Export", Name = "RegisterExport")]
        public FileContentResult RegisterExport(string keyword = null, 
            string name = null, string RAAYear = null, string country = null, string accreditedTLDs = null)
        {
            var query = RegisterUtils.BuildExportQuery(keyword ?? name, RAAYear, country, accreditedTLDs);
            var file = this._managementRegisterService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Registrar-{StringUtils.GetCurrentDateTimeAsString()}.csv");
        }

        #endregion

        #region "Trademark"

        [Route("Trademark/{rowCount?}/{page?}/{keyword?}", Name = "SearchTrademark")]
        public ActionResult Trademark(int rowCount = 25, int page = 1, string keyword = null,
            string name = null, string office = null, string officeStatus = null, string trademarkNumber = null, string figurative = null, string brand = null,
            string figurativeURL = null, string originalOffice = null, string languageFiling = null, string languageSecond = null, string geography = null,
            string involvedInRevocation = null, string bigFootGroupOwned = null, string seniorityUsed = null, string revocationTarget = null, string openSimilarityResearchTask = null,
            string oppositionResearch = null, string researcherName = null, string markUse = null, string TMWebsite = null, string competingMarks = null,
            string ownerWebsite = null, string cancellationStrategy = null, string comWebsite = null, string ownerDefense = null, string BFStrategy = null,
            string nameValue = null, string invalidityNumber = null, string invalidityApplicant = null, string invalidityActionOutcome = null, string letterReference = null,
            string letterOrigin = null, string letterSendingMethod = null, string letterOutcome = null)
        {
            var searchResultObject = new VMSearchResultObject<Trademark> { Caption = "Trademark" };
            var startIndex = (page - 1) * rowCount;

            var query = TrademarkUtils.BuildQuery(startIndex, rowCount, keyword ??
                name, office, officeStatus, trademarkNumber, figurative, brand, figurativeURL, originalOffice, languageFiling, languageSecond, geography,
                involvedInRevocation, bigFootGroupOwned, seniorityUsed, revocationTarget, openSimilarityResearchTask, oppositionResearch, researcherName,
                markUse, TMWebsite, competingMarks, ownerWebsite, cancellationStrategy, comWebsite, ownerDefense, BFStrategy, nameValue, invalidityNumber,
                invalidityApplicant, invalidityActionOutcome, letterReference, letterOrigin, letterSendingMethod, letterOutcome);
            var trademarks = this._managementTrademarkService.GetByQuery(query.Item1, query.Item2, out int total);

            searchResultObject.ObjectResult = new VMPageResult<Trademark>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = trademarks
            };

            if (!string.IsNullOrWhiteSpace(keyword))
            {
                var searchResultWrapperList = this._searchService.Search(name ?? keyword);

                searchResultObject.SearchResult = new VMSearchResult
                {
                    Table = searchResultWrapperList
                };
            }

            ViewBag.Keyword = keyword ?? name;
            ViewBag.IsAdvanceSearch = string.IsNullOrWhiteSpace(keyword);

            return View(searchResultObject);
        }

        [HttpGet]
        [Route("Trademark/Export/{keyword}", Name = "TrademarkExportWithKeyword")]
        [Route("Trademark/Export", Name = "TrademarkExport")]
        public FileContentResult TrademarkExport(string keyword = null,
            string name = null, string office = null, string officeStatus = null, string trademarkNumber = null, string figurative = null, string brand = null,
            string figurativeURL = null, string originalOffice = null, string languageFiling = null, string languageSecond = null, string geography = null,
            string involvedInRevocation = null, string bigFootGroupOwned = null, string seniorityUsed = null, string revocationTarget = null, string openSimilarityResearchTask = null,
            string oppositionResearch = null, string researcherName = null, string markUse = null, string TMWebsite = null, string competingMarks = null,
            string ownerWebsite = null, string cancellationStrategy = null, string comWebsite = null, string ownerDefense = null, string BFStrategy = null,
            string nameValue = null, string invalidityNumber = null, string invalidityApplicant = null, string invalidityActionOutcome = null, string letterReference = null,
            string letterOrigin = null, string letterSendingMethod = null, string letterOutcome = null)
        {
            var query = TrademarkUtils.BuildExportQuery(keyword ??
                name, office, officeStatus, trademarkNumber, figurative, brand, figurativeURL, originalOffice, languageFiling, languageSecond, geography,
                involvedInRevocation, bigFootGroupOwned, seniorityUsed, revocationTarget, openSimilarityResearchTask, oppositionResearch, researcherName,
                markUse, TMWebsite, competingMarks, ownerWebsite, cancellationStrategy, comWebsite, ownerDefense, BFStrategy, nameValue, invalidityNumber,
                invalidityApplicant, invalidityActionOutcome, letterReference, letterOrigin, letterSendingMethod, letterOutcome);
            var file = this._managementTrademarkService.ExportByQuery(query);

            return File(new UTF8Encoding().GetBytes(file.ToString()), "text/csv", $"Export-Trademark-{StringUtils.GetCurrentDateTimeAsString()}.csv");
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

        #endregion
    }
}
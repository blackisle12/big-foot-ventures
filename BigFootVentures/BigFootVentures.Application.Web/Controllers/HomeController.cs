using BigFootVentures.Application.Web.Models.Extensions;
using BigFootVentures.Application.Web.Models.Security;
using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.EmailTemplates.Management;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Enumerators;
using BigFootVentures.Business.Objects.Logs;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using BigFootVentures.Service.BusinessService.Validators;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BigFootVentures.Application.Web.Models.VMEnums;
using static BigFootVentures.Business.Objects.Enumerators.ManagementEnums.Company;

namespace BigFootVentures.Application.Web.Controllers
{
    [Authorize]
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        #region "Private Members"

        private readonly IManagementService<AgreementT> _managementAgreementService = null;
        private readonly IManagementService<Brand> _managementBrandService = null;
        private readonly IManagementService<Cancellation> _managementCancellationService = null;
        private readonly IManagementService<Company> _managementCompanyService = null;
        private readonly IManagementService<Contact> _managementContactService = null;
        private readonly IManagementService<DomainN> _managementDomainService = null;
        private readonly IManagementService<EmailResponse> _managementEmailResponseService = null;
        private readonly IManagementService<Enquiry> _managementEnquiryService = null;
        private readonly IManagementService<Lead> _managementLeadService = null;
        private readonly IManagementService<LegalCase> _managementLegalCaseService = null;
        private readonly IManagementService<LoginInformation> _managementLoginInformationService = null;
        private readonly IManagementService<Office> _managementOfficeService = null;
        private readonly IManagementService<OfficeStatus> _managementOfficeStatusService = null;
        private readonly IManagementService<Opposition> _managementOppositionService = null;
        private readonly IManagementService<PreFilingSimilarityResearch> _managementPreFilingSimilarityResearchService = null;
        private readonly IManagementService<Register> _managementRegisterService = null;
        private readonly IManagementService<SimilarTrademark> _managementSimilarTrademarkService = null;
        private readonly IManagementService<Task> _managementTaskService = null;
        private readonly IManagementService<TMRepresentative> _managementTMRepresentativeService = null;
        private readonly IManagementService<Trademark> _managementTrademarkService = null;
        private readonly IManagementService<TrademarkOwner> _managementTrademarkOwnerService = null;
        private readonly IManagementService<UserAccount> _managementUserAccountService = null;

        private readonly EmailAutomationService _emailAutomationService = null;

        private readonly ITrademarkService _trademarkService = null;

        private readonly ITaskService _taskService = null;

        private readonly IAuditTrailService _auditTrailService = null;

        private readonly IFileAttachmentService _fileAttachmentService = null;

        #endregion

        #region "Constructors"

        public HomeController(IManagementService<AgreementT> managementAgreementService,
            IManagementService<Brand> managementBrandService,
            IManagementService<Cancellation> managementCancellationService,
            IManagementService<Company> managementCompanyService,
            IManagementService<Contact> managementContactService,
            IManagementService<DomainN> managementDomainService,
            IManagementService<EmailResponse> managementEmailResponseService,
            IManagementService<Enquiry> managementEnquiryService,
            IManagementService<Lead> managementLeadService,
            IManagementService<LegalCase> managementLegalCaseService,
            IManagementService<LoginInformation> managementLoginInformationService,
            IManagementService<Office> managementOfficeService,
            IManagementService<OfficeStatus> managementOfficeStatusService,
            IManagementService<Opposition> managementOppositionService,
            IManagementService<PreFilingSimilarityResearch> managementPreFilingSimilarityResearchService,
            IManagementService<Register> managementRegisterService,
            IManagementService<SimilarTrademark> managementSimilarTrademarkService,
            IManagementService<Task> managementTaskService,
            IManagementService<TMRepresentative> managementTMRepresentativeService,
            IManagementService<Trademark> managementTrademarkService,
            IManagementService<TrademarkOwner> managementTrademarkOwnerService,
            IManagementService<UserAccount> managementUserAccountService,

            ITrademarkService trademarkService,

            ITaskService taskService,

            IAuditTrailService auditTrailService,
            
            IFileAttachmentService fileAttachmentService)
        {
            this._managementAgreementService = managementAgreementService;
            this._managementBrandService = managementBrandService;
            this._managementCancellationService = managementCancellationService;
            this._managementCompanyService = managementCompanyService;
            this._managementContactService = managementContactService;
            this._managementDomainService = managementDomainService;
            this._managementEmailResponseService = managementEmailResponseService;
            this._managementEnquiryService = managementEnquiryService;
            this._managementLeadService = managementLeadService;
            this._managementLegalCaseService = managementLegalCaseService;
            this._managementLoginInformationService = managementLoginInformationService;
            this._managementOfficeService = managementOfficeService;
            this._managementOfficeStatusService = managementOfficeStatusService;
            this._managementOppositionService = managementOppositionService;
            this._managementPreFilingSimilarityResearchService = managementPreFilingSimilarityResearchService;
            this._managementRegisterService = managementRegisterService;            
            this._managementSimilarTrademarkService = managementSimilarTrademarkService;
            this._managementTaskService = managementTaskService;
            this._managementTMRepresentativeService = managementTMRepresentativeService;
            this._managementTrademarkService = managementTrademarkService;
            this._managementTrademarkOwnerService = managementTrademarkOwnerService;
            this._managementUserAccountService = managementUserAccountService;

            this._emailAutomationService = new EmailAutomationService(
                ConfigurationManager.AppSettings["SMTP_Host"],
                Convert.ToInt32(ConfigurationManager.AppSettings["SMTP_Port"]),
                ConfigurationManager.AppSettings["SMTP_FromEmail"],
                ConfigurationManager.AppSettings["SMTP_Username"],
                ConfigurationManager.AppSettings["SMTP_Password"]);

            this._trademarkService = trademarkService;

            this._taskService = taskService;

            this._auditTrailService = auditTrailService;

            this._fileAttachmentService = fileAttachmentService;
        }

        #endregion

        #region "Default"
        
        [Route("")]
        [Route("Index/{rowCount?}/{page?}", Name = "Dashboard")]
        public ActionResult Index(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var tasks = this._managementTaskService.GetAssigned(SessionUtils.GetUserAccount().ID, startIndex, rowCount, out int total);
            var model = new VMDashboard
            {
                Tasks = new VMPageResult<Task>
                {
                    StartIndex = startIndex,
                    RowCount = rowCount,
                    Page = page,
                    Total = total,
                    Records = tasks
                }
            };

            return View(model);
        }

        #endregion

        #region "Agreement"

        [Route("Agreements/{rowCount?}/{page?}/{keyword?}", Name = "Agreements")]
        public ActionResult Agreements(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var agreements = string.IsNullOrWhiteSpace(keyword) ?
                this._managementAgreementService.Get(startIndex, rowCount, out int total) :
                this._managementAgreementService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<AgreementT>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = agreements,
                Header = "Agreements"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Agreement/{ID:int}", Name = "AgreementTView")]
        public ActionResult Agreement(int ID)
        {
            var agreement = this._managementAgreementService.Get(ID);

            if (agreement.BFCompany != null)
            {
                agreement.BFCompany = this._managementCompanyService.Get(agreement.BFCompany.ID);
            }

            if (agreement.Counterpart != null)
            {
                agreement.Counterpart = this._managementCompanyService.Get(agreement.Counterpart.ID);
            }

            var model = new VMModel<AgreementT>
            {
                Record = agreement,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("AgreementView", model);
        }

        [Route("Agreement/New", Name = "AgreementTNew")]
        public ActionResult AgreementNew()
        {
            VMModel<AgreementT> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<AgreementT>();
            }
            else
            {
                model = new VMModel<AgreementT>
                {
                    Record = new AgreementT(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Agreement", model);
        }

        [Route("Agreement/Edit/{ID:int}", Name = "AgreementTEdit")]
        public ActionResult AgreementEdit(int ID)
        {
            VMModel<AgreementT> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<AgreementT>();
            }
            else
            {
                var agreement = this._managementAgreementService.Get(ID);

                if (agreement.BFCompany != null)
                {
                    agreement.BFCompany = this._managementCompanyService.Get(agreement.BFCompany.ID);
                }

                if (agreement.Counterpart != null)
                {
                    agreement.Counterpart = this._managementCompanyService.Get(agreement.Counterpart.ID);
                }

                model = new VMModel<AgreementT>
                {
                    Record = agreement,
                    PageMode = PageMode.Edit
                };
            }

            return View("Agreement", model);
        }

        [HttpPost]
        [Route("Agreement", Name = "AgreementTPost")]
        public ActionResult Agreement(VMModel<AgreementT> model)
        {
            Func<int> postModel = () =>
            {                
                var validationResult = new Dictionary<string, string>();

                if (AgreementValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementAgreementService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Agreement",
                                ObjectID = model.Record.ID,
                                Message = "Agreement was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementAgreementService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Agreement",
                                ObjectID = model.Record.ID,
                                Message = "Agreement was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<AgreementT>(model, postModel);
        }

        [HttpGet]
        [Route("Agreement/Delete/{ID:int}", Name = "AgreementTDelete")]
        public ActionResult AgreementDelete(int ID)
        {
            try
            {
                this._managementAgreementService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Agreements");
        }

        [HttpGet]
        [Route("Agreement/Autocomplete/{keyword}", Name = "AgreementAutocomplete")]
        public ActionResult AgreementAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementAgreementService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Brand"

        [Route("Brands/{rowCount?}/{page?}/{keyword?}", Name = "Brands")]
        public ActionResult Brands(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var brands = string.IsNullOrWhiteSpace(keyword) ? 
                this._managementBrandService.Get(startIndex, rowCount, out int total) :
                this._managementBrandService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Brand>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = brands,
                Header = "Brands"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Brand/{ID:int}", Name = "BrandView")]
        public ActionResult Brand(int ID)
        {
            var brand = this._managementBrandService.Get(ID);
            var model = new VMModel<Brand>
            {
                Record = brand,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("BrandView", model);
        }

        [Route("Brand/New", Name = "BrandNew")]
        public ActionResult BrandNew()
        {
            VMModel<Brand> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Brand>();
            }
            else
            {
                model = new VMModel<Brand>
                {
                    Record = new Brand(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Brand", model);
        }

        [Route("Brand/Edit/{ID:int}", Name = "BrandEdit")]
        public ActionResult BrandEdit(int ID)
        {
            VMModel<Brand> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Brand>();
            }
            else
            {
                model = new VMModel<Brand>
                {
                    Record = this._managementBrandService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("Brand", model);
        }        

        [HttpPost]
        [Route("Brand", Name = "BrandPost")]
        public ActionResult Brand(VMModel<Brand> model)
        {
            Func<int> postModel = () =>
            {
                if (model.Record.CategoriesSelected != null)
                    model.Record.Category = string.Join(";", model.Record.CategoriesSelected);

                var validationResult = new Dictionary<string, string>();

                if (BrandValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementBrandService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Brand",
                                ObjectID = model.Record.ID,
                                Message = "Brand was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementBrandService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Brand",
                                ObjectID = model.Record.ID,
                                Message = "Brand was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Brand>(model, postModel);
        }

        [HttpGet]
        [Route("Brand/Delete/{ID:int}", Name = "BrandDelete")]
        public ActionResult BrandDelete(int ID)
        {
            try
            {
                this._managementBrandService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Brands");
        }

        [HttpGet]
        [Route("Brand/Autocomplete/{keyword}", Name = "BrandAutocomplete")]
        public ActionResult BrandAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementBrandService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Cancellation"

        [Route("Cancellations/{rowCount?}/{page?}/{keyword?}", Name = "Cancellations")]
        public ActionResult Cancellations(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var cancellations = string.IsNullOrWhiteSpace(keyword) ? 
                this._managementCancellationService.Get(startIndex, rowCount, out int total) :
                this._managementCancellationService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Cancellation>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = cancellations,
                Header = "Cancellations"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Cancellation/{ID:int}", Name = "CancellationView")]
        public ActionResult Cancellation(int ID)
        {
            var cancellation = this._managementCancellationService.Get(ID);
            var model = new VMModel<Cancellation>
            {
                Record = cancellation,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("CancellationView", model);
        }

        [Route("Cancellation/New", Name = "CancellationNew")]
        public ActionResult CancellationNew()
        {
            VMModel<Cancellation> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Cancellation>();
            }
            else
            {
                model = new VMModel<Cancellation>
                {
                    Record = new Cancellation(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Cancellation", model);
        }

        [Route("Cancellation/Edit/{ID:int}", Name = "CancellationEdit")]
        public ActionResult CancellationEdit(int ID)
        {
            VMModel<Cancellation> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Cancellation>();
            }
            else
            {
                model = new VMModel<Cancellation>
                {
                    Record = this._managementCancellationService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("Cancellation", model);
        }

        [HttpPost]
        [Route("Cancellation", Name = "CancellationPost")]
        public ActionResult Cancellation(VMModel<Cancellation> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (CancellationValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementCancellationService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Cancellation",
                                ObjectID = model.Record.ID,
                                Message = "Cancellation was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementCancellationService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Cancellation",
                                ObjectID = model.Record.ID,
                                Message = "Cancellation was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Cancellation>(model, postModel);
        }

        [HttpGet]
        [Route("Cancellation/Delete/{ID:int}", Name = "CancellationDelete")]
        public ActionResult CancellationDelete(int ID)
        {
            try
            {
                this._managementCancellationService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Cancellations");
        }

        #endregion

        #region "Company"

        [Route("Companies/{rowCount?}/{page?}/{keyword?}", Name = "Companies")]
        public ActionResult Companies(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var companies = string.IsNullOrWhiteSpace(keyword) ?
                this._managementCompanyService.Get(startIndex, rowCount, out int total) :
                this._managementCompanyService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Company>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = companies,
                Header = "Companies"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Company/{ID:int}", Name = "CompanyView")]
        public ActionResult Company(int ID)
        {
            var company = this._managementCompanyService.Get(ID);

            if (company.ParentAccount != null)
            {
                company.ParentAccount = this._managementCompanyService.Get(company.ParentAccount.ID);
            }

            var model = new VMModel<Company>
            {
                Record = company,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            if (company.AccountRecordType == AccountRecordType.PersonAccount.ToDescription())
            {
                return View("CompanyPersonView", model);
            }
            else
            {
                return View("CompanyBusinessExternalView", model);
            }
        }

        [Route("Company/New/{recordType}", Name = "CompanyNew")]
        public ActionResult CompanyNew(string recordType)
        {
            if (!(string.Equals(recordType, ManagementEnums.Company.AccountRecordType.BusinessAccount.ToDescription(), StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(recordType, ManagementEnums.Company.AccountRecordType.ExternalClient.ToDescription(), StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(recordType, ManagementEnums.Company.AccountRecordType.PersonAccount.ToDescription(), StringComparison.InvariantCultureIgnoreCase)))
                throw new Exception(); //throw to error 500

            VMModel<Company> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Company>();
            }
            else
            {
                model = new VMModel<Company>
                {
                    Record = new Company { AccountRecordType = recordType },
                    PageMode = PageMode.Edit
                };
            }

            return View("Company", model);
        }

        [Route("Company/Edit/{ID:int}", Name = "CompanyEdit")]
        public ActionResult CompanyEdit(int ID)
        {
            VMModel<Company> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Company>();
            }
            else
            {
                var company = this._managementCompanyService.Get(ID);

                if (company.ParentAccount != null)
                {
                    company.ParentAccount = this._managementCompanyService.Get(company.ParentAccount.ID);
                }

                model = new VMModel<Company>
                {
                    Record = company,
                    PageMode = PageMode.Edit
                };
            }

            return View("Company", model);
        }

        [Route("Company/New/SelectRecordType", Name = "CompanyNewSelectRecordType")]
        public ActionResult CompanyNewSelectRecordType()
        {
            return View();
        }

        [HttpPost]
        [Route("CompanyNewSelectRecordType", Name = "CompanyNewSelectRecordTypePost")]
        public ActionResult CompanyNewSelectRecordType(string recordType)
        {
            return RedirectToRoute("CompanyNew", new { recordType });
        }        

        [HttpPost]
        [Route("Company", Name = "CompanyPost")]
        public ActionResult Company(VMModel<Company> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (CompanyValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementCompanyService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Company",
                                ObjectID = model.Record.ID,
                                Message = "Company was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementCompanyService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Company",
                                ObjectID = model.Record.ID,
                                Message = "Company was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Company>(model, postModel);
        }        

        [HttpGet]
        [Route("Company/Delete/{ID:int}", Name = "CompanyDelete")]
        public ActionResult CompanyDelete(int ID)
        {
            try
            {
                this._managementCompanyService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Companies");
        }

        [HttpGet]
        [Route("Company/Autocomplete/{keyword}", Name = "CompanyAutocomplete")]
        public ActionResult CompanyAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementCompanyService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Contact"

        [Route("Contacts/{rowCount?}/{page?}/{keyword?}", Name = "Contacts")]
        public ActionResult Contacts(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var contacts = string.IsNullOrWhiteSpace(keyword) ? 
                this._managementContactService.Get(startIndex, rowCount, out int total) :
                this._managementContactService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Contact>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = contacts,
                Header = "Contacts"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Contact/{ID:int}", Name = "ContactView")]
        public ActionResult Contact(int ID)
        {
            var contact = this._managementContactService.Get(ID);

            if (contact.Company != null)
            {
                contact.Company = this._managementCompanyService.Get(contact.Company.ID);
            }

            if (contact.WebsiteIndividual != null)
            {
                contact.WebsiteIndividual = this._managementDomainService.Get(contact.WebsiteIndividual.ID);
            }

            var model = new VMModel<Contact>
            {
                Record = contact,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("ContactView", model);
        }

        [Route("Contact/New", Name = "ContactNew")]
        public ActionResult ContactNew()
        {
            VMModel<Contact> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Contact>();
            }
            else
            {
                model = new VMModel<Contact>
                {
                    Record = new Contact(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Contact", model);
        }

        [Route("Contact/Edit/{ID:int}", Name = "ContactEdit")]
        public ActionResult ContactEdit(int ID)
        {
            VMModel<Contact> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Contact>();
            }
            else
            {
                var contact = this._managementContactService.Get(ID);

                if (contact.Company != null)
                {
                    contact.Company = this._managementCompanyService.Get(contact.Company.ID);
                }

                if (contact.WebsiteIndividual != null)
                {
                    contact.WebsiteIndividual = this._managementDomainService.Get(contact.WebsiteIndividual.ID);
                }

                model = new VMModel<Contact>
                {
                    Record = contact,
                    PageMode = PageMode.Edit
                };
            }

            return View("Contact", model);
        }

        [HttpPost]
        [Route("Contact", Name = "ContactPost")]
        public ActionResult Contact(VMModel<Contact> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (ContactValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementContactService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Contact",
                                ObjectID = model.Record.ID,
                                Message = "Contact was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementContactService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Contact",
                                ObjectID = model.Record.ID,
                                Message = "Contact was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Contact>(model, postModel);
        }

        [HttpGet]
        [Route("Contact/Delete/{ID:int}", Name = "ContactDelete")]
        public ActionResult ContactDelete(int ID)
        {
            try
            {
                this._managementContactService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Contacts");
        }

        [HttpGet]
        [Route("Contact/Autocomplete/{keyword}", Name = "ContactAutocomplete")]
        public ActionResult ContactAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementContactService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Domain"

        [Route("Domains/{rowCount?}/{page?}/{keyword?}", Name = "Domains")]
        public ActionResult Domains(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var domains = string.IsNullOrWhiteSpace(keyword) ?
                this._managementDomainService.Get(startIndex, rowCount, out int total) :
                this._managementDomainService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<DomainN>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = domains,
                Header = "Domains"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Domain/{ID:int}", Name = "DomainNView")]
        public ActionResult Domain(int ID)
        {
            var domain = this._managementDomainService.Get(ID);

            if (domain.RegistrantCompany != null)
                domain.RegistrantCompany = this._managementCompanyService.Get(domain.RegistrantCompany.ID);

            if (domain.DomainEnquiry != null)
                domain.DomainEnquiry = this._managementEnquiryService.Get(domain.DomainEnquiry.ID);

            if (domain.Brand != null)
                domain.Brand = this._managementBrandService.Get(domain.Brand.ID);

            if (domain.Registrar != null)
                domain.Registrar = this._managementRegisterService.Get(domain.Registrar.ID);

            if (domain.PreviousRegistrant != null)
                domain.PreviousRegistrant = this._managementCompanyService.Get(domain.PreviousRegistrant.ID);

            var model = new VMModel<DomainN>
            {
                Record = domain,
                PageMode = PageMode.View,
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            model.Record.RelatedContacts = this._managementDomainService.GetRelated<Contact>(ID);
            model.Record.RelatedTrademarks = this._managementDomainService.GetRelated<Trademark>(ID);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("DomainView", model);
        }

        [Route("Domain/New", Name = "DomainNNew")]
        public ActionResult DomainNew(string recordType)
        {            
            VMModel<DomainN> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<DomainN>();
            }
            else
            {
                model = new VMModel<DomainN>
                {
                    Record = new DomainN(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Domain", model);
        }

        [Route("Domain/Edit/{ID:int}", Name = "DomainNEdit")]
        public ActionResult DomainEdit(int ID)
        {
            VMModel<DomainN> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<DomainN>();
            }
            else
            {
                var domain = this._managementDomainService.Get(ID);

                if (domain.RegistrantCompany != null)
                    domain.RegistrantCompany = this._managementCompanyService.Get(domain.RegistrantCompany.ID);

                if (domain.DomainEnquiry != null)
                    domain.DomainEnquiry = this._managementEnquiryService.Get(domain.DomainEnquiry.ID);

                if (domain.Brand != null)
                    domain.Brand = this._managementBrandService.Get(domain.Brand.ID);

                if (domain.Registrar != null)
                    domain.Registrar = this._managementRegisterService.Get(domain.Registrar.ID);

                if (domain.PreviousRegistrant != null)
                    domain.PreviousRegistrant = this._managementCompanyService.Get(domain.PreviousRegistrant.ID);

                model = new VMModel<DomainN>
                {
                    Record = domain,
                    PageMode = PageMode.Edit
                };
            }

            return View("Domain", model);
        }

        [HttpPost]
        [Route("Domain", Name = "DomainPost")]
        public ActionResult Domain(VMModel<DomainN> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (DomainValidator.IsValid(model.Record, out validationResult))
                {
                    model.Record.RegistrantEmail = "Email not found!";

                    if (model.Record.RegistrantCompany != null && model.Record.RegistrantCompany.ID > 0)
                    {
                        if (!string.IsNullOrWhiteSpace(model.Record.RegistrantCompany.Email))
                        {
                            model.Record.RegistrantEmail = model.Record.RegistrantCompany.Email;
                        }
                    }

                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementDomainService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Domain",
                                ObjectID = model.Record.ID,
                                Message = "Domain was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementDomainService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Domain",
                                ObjectID = model.Record.ID,
                                Message = "Domain was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach(var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<DomainN>(model, postModel);
        }

        [HttpGet]
        [Route("Domain/Delete/{ID:int}", Name = "DomainNDelete")]
        public ActionResult DomainNDelete(int ID)
        {
            try
            {
                this._managementDomainService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Domains");
        }

        [HttpGet]
        [Route("DomainN/Autocomplete/{keyword}", Name = "DomainAutocomplete")]
        public ActionResult DomainNAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementDomainService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Email Response"

        [Route("EmailResponses/{rowCount?}/{page?}", Name = "EmailResponses")]
        public ActionResult EmailResponses(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var emailResponse = this._managementEmailResponseService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<EmailResponse>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = emailResponse,
                Header = "Email Responses"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("EmailResponse/{ID:int}", Name = "EmailResponseView")]
        public ActionResult EmailResponse(int ID)
        {
            var emailResponse = this._managementEmailResponseService.Get(ID);

            if (emailResponse.Enquiry != null)
            {
                emailResponse.Enquiry = this._managementEnquiryService.Get(emailResponse.Enquiry.ID);
            }

            var model = new VMModel<EmailResponse>
            {
                Record = emailResponse,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("EmailResponseView", model);
        }

        [Route("EmailResponse/New", Name = "EmailResponseNew")]
        public ActionResult EmailResponseNew()
        {
            VMModel<EmailResponse> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<EmailResponse>();
            }
            else
            {
                model = new VMModel<EmailResponse>
                {
                    Record = new EmailResponse(),
                    PageMode = PageMode.Edit
                };
            }

            return View("EmailResponse", model);
        }

        [Route("EmailResponse/Edit/{ID:int}", Name = "EmailResponseEdit")]
        public ActionResult EmailResponseEdit(int ID)
        {
            VMModel<EmailResponse> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<EmailResponse>();
            }
            else
            {
                var emailResponse = this._managementEmailResponseService.Get(ID);

                if (emailResponse.Enquiry != null)
                {
                    emailResponse.Enquiry = this._managementEnquiryService.Get(emailResponse.Enquiry.ID);
                }

                model = new VMModel<EmailResponse>
                {
                    Record = emailResponse,
                    PageMode = PageMode.Edit
                };
            }

            return View("EmailResponse", model);
        }

        [HttpPost]
        [Route("EmailResponse", Name = "EmailResponsePost")]
        public ActionResult EmailResponse(VMModel<EmailResponse> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (EmailResponseValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementEmailResponseService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "EmailResponse",
                                ObjectID = model.Record.ID,
                                Message = "Email Response was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementEmailResponseService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "EmailResponse",
                                ObjectID = model.Record.ID,
                                Message = "Email Response was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<EmailResponse>(model, postModel);
        }

        [HttpGet]
        [Route("EmailResponse/Delete/{ID:int}", Name = "EmailResponseDelete")]
        public ActionResult EmailResponseDelete(int ID)
        {
            try
            {
                this._managementEmailResponseService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("EmailResponses");
        }

        #endregion

        #region "Enquiry"

        [Route("Enquiries/{rowCount?}/{page?}/{keyword?}", Name = "Enquiries")]
        public ActionResult Enquiries(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var enquiries = string.IsNullOrWhiteSpace(keyword) ? 
                this._managementEnquiryService.Get(startIndex, rowCount, out int total) :
                this._managementEnquiryService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Enquiry>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = enquiries,
                Header = "Enquiries"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Enquiry/{ID:int}", Name = "EnquiryView")]
        public ActionResult Enquiry(int ID)
        {
            var enquiry = this._managementEnquiryService.Get(ID);

            if (enquiry.Registrar != null)
            {
                enquiry.Registrar = this._managementRegisterService.Get(enquiry.Registrar.ID);
            }

            if (enquiry.RegistrantCompany != null)
            {
                enquiry.RegistrantCompany = this._managementCompanyService.Get(enquiry.RegistrantCompany.ID);
            }

            var model = new VMModel<Enquiry>
            {
                Record = enquiry,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);
            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            if (enquiry.RecordType == ManagementEnums.Enquiry.RecordType.DomainEnquiry.ToString())
            {
                return View("EnquiryDomainView", model);
            }
            else
            {
                return View("EnquiryITSupportView", model);
            }
        }

        [Route("Enquiry/New/{recordType}", Name = "EnquiryNew")]
        public ActionResult EnquiryNew(string recordType)
        {
            if (!(string.Equals(recordType, ManagementEnums.Enquiry.RecordType.DomainEnquiry.ToDescription(), StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(recordType, ManagementEnums.Enquiry.RecordType.ITSupport.ToDescription(), StringComparison.InvariantCultureIgnoreCase)))
                throw new Exception(); //throw to error 500

            VMModel<Enquiry> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Enquiry>();
            }
            else
            {
                model = new VMModel<Enquiry>
                {
                    Record = new Enquiry { RecordType = recordType },
                    PageMode = PageMode.Edit
                };
            }

            return View("Enquiry", model);
        }

        [Route("Enquiry/Edit/{ID:int}", Name = "EnquiryEdit")]
        public ActionResult EnquiryEdit(int ID)
        {
            VMModel<Enquiry> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Enquiry>();
            }
            else
            {
                var enquiry = this._managementEnquiryService.Get(ID);

                if (enquiry.Registrar != null)
                {
                    enquiry.Registrar = this._managementRegisterService.Get(enquiry.Registrar.ID);
                }

                if (enquiry.RegistrantCompany != null)
                {
                    enquiry.RegistrantCompany = this._managementCompanyService.Get(enquiry.RegistrantCompany.ID);
                }

                model = new VMModel<Enquiry>
                {
                    Record = enquiry,
                    PageMode = PageMode.Edit
                };
            }

            return View("Enquiry", model);
        }

        [Route("Enquiry/New/SelectRecordType", Name = "EnquiryNewSelectRecordType")]
        public ActionResult EnquiryNewSelectRecordType()
        {
            return View();
        }

        [HttpPost]
        [Route("EnquiryNewSelectRecordType", Name = "EnquiryNewSelectRecordTypePost")]
        public ActionResult EnquiryNewSelectRecordType(string recordType)
        {
            return RedirectToRoute("EnquiryNew", new { recordType });
        }

        [HttpPost]
        [Route("Enquiry", Name = "EnquiryPost")]
        public ActionResult Enquiry(VMModel<Enquiry> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (EnquiryValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementEnquiryService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Enquiry",
                                ObjectID = model.Record.ID,
                                Message = "Enquiry was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementEnquiryService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Enquiry",
                                ObjectID = model.Record.ID,
                                Message = "Enquiry was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Enquiry>(model, postModel);
        }

        [HttpGet]
        [Route("Enquiry/Delete/{ID:int}", Name = "EnquiryDelete")]
        public ActionResult EnquiryDelete(int ID)
        {
            try
            {
                this._managementEnquiryService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Enquiries");
        }

        [HttpGet]
        [Route("Enquiry/Autocomplete/{keyword}", Name = "EnquiryAutocomplete")]
        public ActionResult EnquiryAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementEnquiryService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Lead"

        [Route("Leads/{rowCount?}/{page?}/{keyword?}", Name = "Leads")]
        public ActionResult Leads(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var leads = string.IsNullOrWhiteSpace(keyword) ?
                this._managementLeadService.Get(startIndex, rowCount, out int total) :
                this._managementLeadService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Lead>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = leads,
                Header = "Leads"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Lead/{ID:int}", Name = "LeadView")]
        public ActionResult Lead(int ID)
        {
            var lead = this._managementLeadService.Get(ID);
            var model = new VMModel<Lead>
            {
                Record = lead,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("LeadView", model);
        }

        [Route("Lead/New", Name = "LeadNew")]
        public ActionResult LeadNew()
        {
            VMModel<Lead> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Lead>();
            }
            else
            {
                model = new VMModel<Lead>
                {
                    Record = new Lead(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Lead", model);
        }

        [Route("Lead/Edit/{ID:int}", Name = "LeadEdit")]
        public ActionResult LeadEdit(int ID)
        {
            VMModel<Lead> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Lead>();
            }
            else
            {
                var lead = this._managementLeadService.Get(ID);
                
                model = new VMModel<Lead>
                {
                    Record = lead,
                    PageMode = PageMode.Edit
                };
            }

            return View("Lead", model);
        }

        [HttpPost]
        [Route("Lead", Name = "LeadPost")]
        public ActionResult Lead(VMModel<Lead> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (LeadValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementLeadService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Lead",
                                ObjectID = model.Record.ID,
                                Message = "Lead was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementLeadService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Lead>(model, postModel);
        }

        [HttpGet]
        [Route("Lead/Delete/{ID:int}", Name = "LeadDelete")]
        public ActionResult LeadDelete(int ID)
        {
            try
            {
                this._managementLeadService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Leads");
        }

        [HttpGet]
        [Route("Lead/Autocomplete/{keyword}", Name = "LeadAutocomplete")]
        public ActionResult LeadAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementLeadService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Legal Case"

        [Route("LegalCases/{rowCount?}/{page?}/{keyword?}", Name = "LegalCases")]
        public ActionResult LegalCases(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var legalCases = string.IsNullOrWhiteSpace(keyword) ?
                this._managementLegalCaseService.Get(startIndex, rowCount, out int total) :
                this._managementLegalCaseService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<LegalCase>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = legalCases,
                Header = "Legal Cases"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("LegalCase/{ID:int}", Name = "LegalCaseView")]
        public ActionResult LegalCase(int ID)
        {
            var legalCase = this._managementLegalCaseService.Get(ID);
            var model = new VMModel<LegalCase>
            {
                Record = legalCase,
                PageMode = PageMode.View
            };

            model.Tasks = this._taskService.Get(ID, model.Name);
            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("LegalCaseView", model);
        }

        [Route("LegalCase/New", Name = "LegalCaseNew")]
        public ActionResult LegalCaseNew()
        {
            VMModel<LegalCase> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<LegalCase>();
            }
            else
            {
                model = new VMModel<LegalCase>
                {
                    Record = new LegalCase(),
                    PageMode = PageMode.Edit
                };
            }

            return View("LegalCase", model);
        }

        [Route("LegalCase/Edit/{ID:int}", Name = "LegalCaseEdit")]
        public ActionResult LegalCaseEdit(int ID)
        {
            VMModel<LegalCase> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<LegalCase>();
            }
            else
            {
                model = new VMModel<LegalCase>
                {
                    Record = this._managementLegalCaseService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("LegalCase", model);
        }

        [HttpPost]
        [Route("LegalCase", Name = "LegalCasePost")]
        public ActionResult LegalCase(VMModel<LegalCase> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (LegalCaseValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        var legalCaseLast = this._managementLegalCaseService.GetLast();

                        if (legalCaseLast == null)
                        {
                            model.Record.LegalProceedingName = $"001/{SessionUtils.GetCurrentDateTime().Year}";
                        }
                        else
                        {
                            var legalProceedingNameArray = legalCaseLast.LegalProceedingName.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                            var legalProceedingNameNumber = Convert.ToInt32(legalProceedingNameArray[0]) + 1;

                            model.Record.LegalProceedingName = $"{legalProceedingNameNumber}/{SessionUtils.GetCurrentDateTime().Year}";
                        }

                        this._managementLegalCaseService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "LegalCase",
                                ObjectID = model.Record.ID,
                                Message = "Legal Case was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementLegalCaseService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "LegalCase",
                                ObjectID = model.Record.ID,
                                Message = "Legal Case was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<LegalCase>(model, postModel);
        }

        [HttpGet]
        [Route("LegalCase/Delete/{ID:int}", Name = "LegalCaseDelete")]
        public ActionResult LegalCaseDelete(int ID)
        {
            try
            {
                this._managementLegalCaseService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("LegalCases");
        }

        #endregion

        #region "Login Information"

        [Route("LoginInformations/{rowCount?}/{page?}", Name = "LoginInformations")]
        public ActionResult LoginInformations(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var loginInformations = this._managementLoginInformationService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<LoginInformation>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = loginInformations,
                Header = "Login Information"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }
        
        [Route("LoginInformation/{ID:int}", Name = "LoginInformationView")]
        public ActionResult LoginInformation(int ID)
        {
            var loginInformation = this._managementLoginInformationService.Get(ID);
            var model = new VMModel<LoginInformation>
            {
                Record = loginInformation,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("LoginInformationView", model);
        }
        
        [Route("LoginInformation/New", Name = "LoginInformationNew")]
        public ActionResult LoginInformationNew()
        {
            VMModel<LoginInformation> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<LoginInformation>();
            }
            else
            {
                model = new VMModel<LoginInformation>
                {
                    Record = new LoginInformation(),
                    PageMode = PageMode.Edit
                };
            }
            
            return View("LoginInformation", model);
        }
        
        [Route("LoginInformation/Edit/{ID:int}", Name = "LoginInformationEdit")]
        public ActionResult LoginInformationEdit(int ID)
        {
            VMModel<LoginInformation> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<LoginInformation>();
            }
            else
            {
                model = new VMModel<LoginInformation>
                {
                    Record = this._managementLoginInformationService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }
            
            return View("LoginInformation", model);
        }
        
        [HttpPost]
        [Route("LoginInformation", Name = "LoginInformationPost")]
        public ActionResult LoginInformation(VMModel<LoginInformation> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (LoginInformationValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementLoginInformationService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "LoginInformation",
                                ObjectID = model.Record.ID,
                                Message = "Login Information was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementLoginInformationService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "LoginInformation",
                                ObjectID = model.Record.ID,
                                Message = "Login Information was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<LoginInformation>(model, postModel);
        }
        
        [HttpGet]
        [Route("LoginInformation/Delete/{ID:int}", Name = "LoginInformationDelete")]
        public ActionResult LoginInformationDelete(int ID)
        {
            try
            {
                this._managementLoginInformationService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("LoginInformations");
        }

        #endregion

        #region "Office"

        [Route("Offices/{rowCount?}/{page?}/{keyword?}", Name = "Offices")]
        public ActionResult Offices(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var offices = string.IsNullOrWhiteSpace(keyword) ? 
                this._managementOfficeService.Get(startIndex, rowCount, out int total) :
                this._managementOfficeService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Office>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = offices,
                Header = "Offices"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Office/{ID:int}", Name = "OfficeView")]
        public ActionResult Office(int ID)
        {
            var office = this._managementOfficeService.Get(ID);
            var model = new VMModel<Office>
            {
                Record = office,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("OfficeView", model);
        }

        [Route("Office/New", Name = "OfficeNew")]
        public ActionResult OfficeNew()
        {
            VMModel<Office> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Office>();
            }
            else
            {
                model = new VMModel<Office>
                {
                    Record = new Office(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Office", model);
        }

        [Route("Office/Edit/{ID:int}", Name = "OfficeEdit")]
        public ActionResult OfficeEdit(int ID)
        {
            VMModel<Office> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Office>();
            }
            else
            {
                model = new VMModel<Office>
                {
                    Record = this._managementOfficeService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("Office", model);
        }

        [HttpPost]
        [Route("Office", Name = "OfficePost")]
        public ActionResult Office(VMModel<Office> model)
        {
            Func<int> postModel = () =>
            {
                if (model.Record.RegistrationPaymentNotificationsSelected != null)
                    model.Record.RegistrationPaymentNotification = string.Join(";", model.Record.RegistrationPaymentNotificationsSelected);

                if (model.Record.RegistrationPaymentMethodsSelected != null)
                    model.Record.RegistrationPaymentMethod = string.Join(";", model.Record.RegistrationPaymentMethodsSelected);

                if (model.Record.OppositionPaymentNotificationsSelected != null)
                    model.Record.OppositionPaymentNotification = string.Join(";", model.Record.OppositionPaymentNotificationsSelected);

                if (model.Record.OppositionPaymentMethodsSelected != null)
                    model.Record.OppositionPaymentMethod = string.Join(";", model.Record.OppositionPaymentMethodsSelected);

                var validationResult = new Dictionary<string, string>();

                if (OfficeValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementOfficeService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Office",
                                ObjectID = model.Record.ID,
                                Message = "Office was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementOfficeService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Office",
                                ObjectID = model.Record.ID,
                                Message = "Office was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Office>(model, postModel);
        }

        [HttpGet]
        [Route("Office/Delete/{ID:int}", Name = "OfficeDelete")]
        public ActionResult OfficeDelete(int ID)
        {
            try
            {
                this._managementOfficeService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Offices");
        }

        [HttpGet]
        [Route("Office/Autocomplete/{keyword}", Name = "OfficeAutocomplete")]
        public ActionResult OfficeAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementOfficeService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Office Status"

        [Route("OfficeStatuses/{rowCount?}/{page?}", Name = "OfficeStatuses")]
        public ActionResult OfficeStatuses(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var officeStatuses = this._managementOfficeStatusService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<OfficeStatus>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = officeStatuses,
                Header = "Office Statuses"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }        
        
        [Route("OfficeStatus/{ID:int}", Name = "OfficeStatusView")]
        public ActionResult OfficeStatus(int ID)
        {
            var officeStatus = this._managementOfficeStatusService.Get(ID);

            if (officeStatus.Office != null)
            {
                officeStatus.Office = this._managementOfficeService.Get(officeStatus.Office.ID);
            }

            var model = new VMModel<OfficeStatus>
            {
                Record = officeStatus,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("OfficeStatusView", model);
        }

        [Route("OfficeStatus/New", Name = "OfficeStatusNew")]
        public ActionResult OfficeStatusNew()
        {
            VMModel<OfficeStatus> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<OfficeStatus>();
            }
            else
            {
                model = new VMModel<OfficeStatus>
                {
                    Record = new OfficeStatus(),
                    PageMode = PageMode.Edit
                };
            }
            
            return View("OfficeStatus", model);
        }

        [Route("OfficeStatus/Edit/{ID:int}", Name = "OfficeStatusEdit")]
        public ActionResult OfficeStatusEdit(int ID)
        {
            VMModel<OfficeStatus> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<OfficeStatus>();
            }
            else
            {
                var officeStatus = this._managementOfficeStatusService.Get(ID);

                if (officeStatus.Office != null)
                {
                    officeStatus.Office = this._managementOfficeService.Get(officeStatus.Office.ID);
                }

                model = new VMModel<OfficeStatus>
                {
                    Record = officeStatus,
                    PageMode = PageMode.Edit
                };
            }
            
            return View("OfficeStatus", model);
        }

        [HttpPost]
        [Route("OfficeStatus", Name = "OfficeStatusPost")]
        public ActionResult OfficeStatus(VMModel<OfficeStatus> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (OfficeStatusValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementOfficeStatusService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "OfficeStatus",
                                ObjectID = model.Record.ID,
                                Message = "Office Status was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementOfficeStatusService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "OfficeStatus",
                                ObjectID = model.Record.ID,
                                Message = "Office Status was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<OfficeStatus>(model, postModel);
        }

        [HttpGet]
        [Route("OfficeStatus/Delete/{ID:int}", Name = "OfficeStatusDelete")]
        public ActionResult OfficeStatusDelete(int ID)
        {
            try
            {
                this._managementOfficeStatusService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("OfficeStatuses");
        }

        #endregion

        #region "Opposition"

        [Route("Oppositions/{rowCount?}/{page?}/{keyword?}", Name = "Oppositions")]
        public ActionResult Oppositions(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var oppositions = string.IsNullOrWhiteSpace(keyword) ?
                this._managementOppositionService.Get(startIndex, rowCount, out int total) :
                this._managementOppositionService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Opposition>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = oppositions,
                Header = "Oppositions"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Opposition/{ID:int}", Name = "OppositionView")]
        public ActionResult Opposition(int ID)
        {
            var opposition = this._managementOppositionService.Get(ID);
            var model = new VMModel<Opposition>
            {
                Record = opposition,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "Opposition")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("OppositionView", model);
        }

        [Route("Opposition/New", Name = "OppositionNew")]
        public ActionResult OppositionNew()
        {
            VMModel<Opposition> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Opposition>();
            }
            else
            {
                model = new VMModel<Opposition>
                {
                    Record = new Opposition(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Opposition", model);
        }

        [Route("Opposition/Edit/{ID:int}", Name = "OppositionEdit")]
        public ActionResult OppositionEdit(int ID)
        {
            VMModel<Opposition> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Opposition>();
            }
            else
            {
                model = new VMModel<Opposition>
                {
                    Record = this._managementOppositionService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("Opposition", model);
        }

        [HttpPost]
        [Route("Opposition", Name = "OppositionPost")]
        public ActionResult Opposition(VMModel<Opposition> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (OppositionValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        var oppositionLast = this._managementOppositionService.GetLast();

                        if (oppositionLast == null)
                        {
                            model.Record.OppositionName = "A-0001";
                        }
                        else
                        {
                            var oppositionNameArray = oppositionLast.OppositionName.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                            var oppositionNameNumber = Convert.ToInt32(oppositionNameArray[1]) + 1;

                            model.Record.OppositionName = $"A-{oppositionNameNumber}";
                        }

                        this._managementOppositionService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Opposition",
                                ObjectID = model.Record.ID,
                                Message = "Opposition was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementOppositionService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Opposition",
                                ObjectID = model.Record.ID,
                                Message = "Opposition was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Opposition>(model, postModel);
        }

        [HttpGet]
        [Route("Opposition/Delete/{ID:int}", Name = "OppositionDelete")]
        public ActionResult OppositionDelete(int ID)
        {
            try
            {
                this._managementOppositionService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Oppositions");
        }

        #endregion

        #region "Pre-Filing Similarity Research"

        [Route("PreFilingSimilarityResearchs/{rowCount?}/{page?}", Name = "PreFilingSimilarityResearchs")]
        public ActionResult PreFilingSimilarityResearchs(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var preFilingSimilarityResearchs = this._managementPreFilingSimilarityResearchService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<PreFilingSimilarityResearch>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = preFilingSimilarityResearchs,
                Header = "Pre-Filing Similarity Research"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("PreFilingSimilarityResearch/{ID:int}", Name = "PreFilingSimilarityResearchView")]
        public ActionResult PreFilingSimilarityResearch(int ID)
        {
            var preFilingSimilarityResearch = this._managementPreFilingSimilarityResearchService.Get(ID);
          
            var model = new VMModel<PreFilingSimilarityResearch>
            {
                Record = preFilingSimilarityResearch,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "PreFilingSimilarityResearch")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("PreFilingSimilarityResearch", model);
        }

        [Route("PreFilingSimilarityResearch/New", Name = "PreFilingSimilarityResearchNew")]
        public ActionResult PreFilingSimilarityResearchNew()
        {
            VMModel<PreFilingSimilarityResearch> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<PreFilingSimilarityResearch>();
            }
            else
            {
                model = new VMModel<PreFilingSimilarityResearch>
                {
                    Record = new PreFilingSimilarityResearch(),
                    PageMode = PageMode.Edit
                };
            }

            return View("PreFilingSimilarityResearch", model);
        }

        [Route("PreFilingSimilarityResearch/Edit/{ID:int}", Name = "PreFilingSimilarityResearchEdit")]
        public ActionResult PreFilingSimilarityResearchEdit(int ID)
        {
            VMModel<PreFilingSimilarityResearch> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<PreFilingSimilarityResearch>();
            }
            else
            {
                var preFilingSimilarityResearch = this._managementPreFilingSimilarityResearchService.Get(ID);
               
                model = new VMModel<PreFilingSimilarityResearch>
                {
                    Record = preFilingSimilarityResearch,
                    PageMode = PageMode.Edit
                };
            }

            return View("PreFilingSimilarityResearch", model);
        }

        [HttpPost]
        [Route("PreFilingSimilarityResearch", Name = "PreFilingSimilarityResearchPost")]
        public ActionResult PreFilingSimilarityResearch(VMModel<PreFilingSimilarityResearch> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (PreFilingSimilarityResearchValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementPreFilingSimilarityResearchService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "PreFilingSimilarityResearch",
                                ObjectID = model.Record.ID,
                                Message = "Pre-Filing Similarity Research was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementPreFilingSimilarityResearchService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "PreFilingSimilarityResearch",
                                ObjectID = model.Record.ID,
                                Message = "Pre-Filing Similarity Research was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<PreFilingSimilarityResearch>(model, postModel);
        }

        [HttpGet]
        [Route("PreFilingSimilarityResearch/Delete/{ID:int}", Name = "PreFilingSimilarityResearchDelete")]
        public ActionResult PreFilingSimilarityResearchDelete(int ID)
        {
            try
            {
                this._managementPreFilingSimilarityResearchService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("PreFilingSimilarityResearchs");
        }

        #endregion

        #region "Register"

        [Route("Registers/{rowCount?}/{page?}/{keyword?}", Name = "Registers")]
        public ActionResult Registers(int rowCount = 25, int page = 1, string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var registers = string.IsNullOrWhiteSpace(keyword) ?
                this._managementRegisterService.Get(startIndex, rowCount, out int total) :
                this._managementRegisterService.GetByKeyword(keyword, startIndex, rowCount, out total);
            var pageResult = new VMPageResult<Register>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = registers,
                Header = "Registers"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Register/{ID:int}", Name = "RegisterView")]
        public ActionResult Register(int ID)
        {
            var register = this._managementRegisterService.Get(ID);
            var model = new VMModel<Register>
            {
                Record = register,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "Register")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("RegisterView", model);
        }

        [Route("Register/New", Name = "RegisterNew")]
        public ActionResult RegisterNew()
        {
            VMModel<Register> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Register>();
            }
            else
            {
                model = new VMModel<Register>
                {
                    Record = new Register(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Register", model);
        }

        [Route("Register/Edit/{ID:int}", Name = "RegisterEdit")]
        public ActionResult RegisterEdit(int ID)
        {
            VMModel<Register> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Register>();
            }
            else
            {
                model = new VMModel<Register>
                {
                    Record = this._managementRegisterService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("Register", model);
        }        

        [HttpPost]
        [Route("Register", Name = "RegisterPost")]
        public ActionResult Register(VMModel<Register> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (RegisterValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementRegisterService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Register",
                                ObjectID = model.Record.ID,
                                Message = "Register was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementRegisterService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Register",
                                ObjectID = model.Record.ID,
                                Message = "Register was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Register>(model, postModel);
        }

        [HttpGet]
        [Route("Register/Delete/{ID:int}", Name = "RegisterDelete")]
        public ActionResult RegisterDelete(int ID)
        {
            try
            {
                this._managementRegisterService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Registers");
        }

        [HttpGet]
        [Route("Register/Autocomplete/{keyword}", Name = "RegisterAutocomplete")]
        public ActionResult RegisterAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementRegisterService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Similar Trademark"

        [Route("SimilarTrademarks/{rowCount?}/{page?}", Name = "SimilarTrademarks")]
        public ActionResult SimilarTrademarks(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var similarTrademarks = this._managementSimilarTrademarkService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<SimilarTrademark>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = similarTrademarks,
                Header = "Similar Trademarks"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("SimilarTrademark/{ID:int}", Name = "SimilarTrademarkView")]
        public ActionResult SimilarTrademark(int ID)
        {
            var similarTrademark = this._managementSimilarTrademarkService.Get(ID);

            var model = new VMModel<SimilarTrademark>
            {
                Record = similarTrademark,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "SimilarTrademark")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("SimilarTrademarkView", model);
        }

        [Route("SimilarTrademark/New", Name = "SimilarTrademarkNew")]
        public ActionResult SimilarTrademarkNew()
        {
            VMModel<SimilarTrademark> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<SimilarTrademark>();
            }
            else
            {
                model = new VMModel<SimilarTrademark>
                {
                    Record = new SimilarTrademark(),
                    PageMode = PageMode.Edit
                };
            }

            return View("SimilarTrademark", model);
        }

        [Route("SimilarTrademark/Edit/{ID:int}", Name = "SimilarTrademarkEdit")]
        public ActionResult SimilarTrademarkEdit(int ID)
        {
            VMModel<SimilarTrademark> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<SimilarTrademark>();
            }
            else
            {
                var similarTrademark = this._managementSimilarTrademarkService.Get(ID);

                model = new VMModel<SimilarTrademark>
                {
                    Record = similarTrademark,
                    PageMode = PageMode.Edit
                };
            }

            return View("SimilarTrademark", model);
        }

        [HttpPost]
        [Route("SimilarTrademark", Name = "SimilarTrademarkPost")]
        public ActionResult SimilarTrademark(VMModel<SimilarTrademark> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (SimilarTrademarkValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementSimilarTrademarkService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "SimilarTrademark",
                                ObjectID = model.Record.ID,
                                Message = "Similar Trademark was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementSimilarTrademarkService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "SimilarTrademark",
                                ObjectID = model.Record.ID,
                                Message = "Similar Trademark was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<SimilarTrademark>(model, postModel);
        }

        [HttpGet]
        [Route("SimilarTrademark/Delete/{ID:int}", Name = "SimilarTrademarkDelete")]
        public ActionResult SimilarTrademarkDelete(int ID)
        {
            try
            {
                this._managementSimilarTrademarkService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("SimilarTrademarks");
        }

        #endregion

        #region "Task"

        [Route("Tasks/{rowCount?}/{page?}/{sortBy?}/{sortOrder?}", Name = "Tasks")]
        public ActionResult Tasks(int rowCount = 25, int page = 1, string sortBy = "Subject", string sortOrder = "asc")
        {
            var startIndex = (page - 1) * rowCount;
            var tasks = this._managementTaskService.Get(startIndex, rowCount, sortBy, sortOrder, out int total);
            var pageResult = new VMPageResult<Task>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = tasks,
                Header = "Tasks",
                SortBy = sortBy,
                SortOrder = sortOrder
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("Task/{ID:int}", Name = "TaskView")]
        public ActionResult Task(int ID)
        {
            var task = this._managementTaskService.Get(ID);

            task.AssignedTo = this._managementUserAccountService.Get(task.AssignedTo.ID);
            task.AssignedTo.DisplayName = $"{task.AssignedTo.FirstName} {task.AssignedTo.LastName}";
            
            var model = new VMModel<Task>
            {
                Record = task,
                PageMode = PageMode.View
            };

            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("TaskView", model);
        }

        [Route("Task/New", Name = "TaskNew")]
        public ActionResult TaskNew()
        {
            VMModel<Task> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Task>();
            }
            else
            {
                model = new VMModel<Task>
                {
                    Record = new Task(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Task", model);
        }

        [Route("Task/Edit/{ID:int}", Name = "TaskEdit")]
        public ActionResult TaskEdit(int ID)
        {
            VMModel<Task> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Task>();
            }
            else
            {
                var task = this._managementTaskService.Get(ID);

                task.AssignedTo = this._managementUserAccountService.Get(task.AssignedTo.ID);
                task.AssignedTo.DisplayName = $"{task.AssignedTo.FirstName} {task.AssignedTo.LastName}";

                model = new VMModel<Task>
                {
                    Record = task,
                    PageMode = PageMode.Edit
                };
            }

            return View("Task", model);
        }

        [HttpPost]
        [Route("Task", Name = "TaskPost")]
        public ActionResult Task(VMModel<Task> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (TaskValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementTaskService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Task",
                                ObjectID = model.Record.ID,
                                Message = "Task was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementTaskService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Task",
                                ObjectID = model.Record.ID,
                                Message = "Task was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Task>(model, postModel);
        }

        [HttpGet]
        [Route("Task/Delete/{ID:int}", Name = "TaskDelete")]
        public ActionResult TaskDelete(int ID)
        {
            try
            {
                this._managementTaskService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Tasks");
        }

        #endregion

        #region "TM Representative"

        [Route("TMRepresentatives/{rowCount?}/{page?}", Name = "TMRepresentatives")]
        public ActionResult TMRepresentatives(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var TMRepresentatives = this._managementTMRepresentativeService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<TMRepresentative>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = TMRepresentatives,
                Header = "TM Representatives"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("TMRepresentative/{ID:int}", Name = "TMRepresentativeView")]
        public ActionResult TMRepresentative(int ID)
        {
            var TMRepresentative = this._managementTMRepresentativeService.Get(ID);
            var model = new VMModel<TMRepresentative>
            {
                Record = TMRepresentative,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "TMRepresentative")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("TMRepresentativeView", model);
        }

        [Route("TMRepresentative/New", Name = "TMRepresentativeNew")]
        public ActionResult TMRepresentativeNew()
        {
            VMModel<TMRepresentative> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<TMRepresentative>();
            }
            else
            {
                model = new VMModel<TMRepresentative>
                {
                    Record = new TMRepresentative(),
                    PageMode = PageMode.Edit
                };
            }

            return View("TMRepresentative", model);
        }

        [Route("TMRepresentative/Edit/{ID:int}", Name = "TMRepresentativeEdit")]
        public ActionResult TMRepresentativeEdit(int ID)
        {
            VMModel<TMRepresentative> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<TMRepresentative>();
            }
            else
            {
                model = new VMModel<TMRepresentative>
                {
                    Record = this._managementTMRepresentativeService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("TMRepresentative", model);
        }

        [HttpPost]
        [Route("TMRepresentative", Name = "TMRepresentativePost")]
        public ActionResult TMRepresentative(VMModel<TMRepresentative> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (TMRepresentativeValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        var TMRepresentativeLast = this._managementTMRepresentativeService.GetLast();

                        if (TMRepresentativeLast == null)
                        {
                            model.Record.TMRepresentativeName = $"TM-0001";
                        }
                        else
                        {
                            var TMRepresentativeNameArray = TMRepresentativeLast.TMRepresentativeName.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries);
                            var TMRepresentativeNameNumber = Convert.ToInt32(TMRepresentativeNameArray[1]) + 1;

                            model.Record.TMRepresentativeName = $"TM-{TMRepresentativeNameNumber}";
                        }

                        this._managementTMRepresentativeService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "TMRepresentative",
                                ObjectID = model.Record.ID,
                                Message = "TM Representative was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementTMRepresentativeService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "TMRepresentative",
                                ObjectID = model.Record.ID,
                                Message = "TM Representative was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<TMRepresentative>(model, postModel);
        }

        [HttpGet]
        [Route("TMRepresentative/Delete/{ID:int}", Name = "TMRepresentativeDelete")]
        public ActionResult TMRepresentativeDelete(int ID)
        {
            try
            {
                this._managementTMRepresentativeService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("TMRepresentatives");
        }

        #endregion

        #region "Trademark"

        [Route("Trademarks/{rowCount?}/{page?}/{sortBy?}/{sortOrder?}/{keyword?}", Name = "Trademarks")]
        public ActionResult Trademarks(int rowCount = 25, int page = 1, string sortBy = "Name", string sortOrder = "asc", string keyword = "")
        {
            var startIndex = (page - 1) * rowCount;
            var trademarks = string.IsNullOrWhiteSpace(keyword) ?
                this._managementTrademarkService.Get(startIndex, rowCount, sortBy, sortOrder, out int total) :
                this._managementTrademarkService.GetByKeyword(keyword, startIndex, rowCount, sortBy, sortOrder, out total);
            var pageResult = new VMPageResult<Trademark>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = trademarks,
                Header = "Trademarks",
                SortBy = sortBy,
                SortOrder = sortOrder
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            ViewBag.Keyword = keyword;

            return View(pageResult);
        }

        [Route("Trademark/{ID:int}", Name = "TrademarkView")]
        public ActionResult Trademark(int ID)
        {
            var trademark = this._trademarkService.Get(ID);

            trademark.Office = this._managementOfficeService.Get(trademark.Office.ID);
            trademark.Brand = this._managementBrandService.Get(trademark.Brand.ID);

            if (trademark.OriginalOffice != null)
            {
                trademark.OriginalOffice = this._managementOfficeService.Get(trademark.OriginalOffice.ID);
            }

            if (trademark.TMWebsite != null)
            {
                trademark.TMWebsite = this._managementDomainService.Get(trademark.TMWebsite.ID);
            }

            if (trademark.OwnerWebsite != null)
            {
                trademark.OwnerWebsite = this._managementDomainService.Get(trademark.OwnerWebsite.ID);
            }

            if (trademark.ComWebsite != null)
            {
                trademark.ComWebsite = this._managementDomainService.Get(trademark.ComWebsite.ID);
            }

            if (trademark.InvalidityApplicant != null)
            {
                trademark.InvalidityApplicant = this._managementCompanyService.Get(trademark.InvalidityApplicant.ID);
            }

            var model = new VMModel<Trademark>
            {
                Record = trademark,
                PageMode = PageMode.View,
            };

            model.Record.RelatedLegalCases = this._managementTrademarkService.GetRelated<LegalCase>(ID);

            model.Tasks = this._taskService.Get(ID, model.Name);
            model.FileAttachments = this._fileAttachmentService.Get(ID, model.Name);
            model.AuditTrails = this._auditTrailService.Get(ID, model.Name);

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("TrademarkView", model);
        }

        [Route("Trademark/New", Name = "TrademarkNew")]
        public ActionResult TrademarkNew()
        {
            VMModel<Trademark> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Trademark>();
            }
            else
            {
                model = new VMModel<Trademark>
                {
                    Record = new Trademark(),
                    PageMode = PageMode.Edit
                };
            }

            return View("Trademark", model);
        }

        [Route("Trademark/Edit/{ID:int}", Name = "TrademarkEdit")]
        public ActionResult TrademarkEdit(int ID)
        {
            VMModel<Trademark> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<Trademark>();
            }
            else
            {
                var trademark = this._trademarkService.Get(ID);

                trademark.Office = this._managementOfficeService.Get(trademark.Office.ID);
                trademark.Brand = this._managementBrandService.Get(trademark.Brand.ID);

                if (trademark.OriginalOffice != null)
                {
                    trademark.OriginalOffice = this._managementOfficeService.Get(trademark.OriginalOffice.ID);
                }

                if (trademark.TMWebsite != null)
                {
                    trademark.TMWebsite = this._managementDomainService.Get(trademark.TMWebsite.ID);
                }

                if (trademark.OwnerWebsite != null)
                {
                    trademark.OwnerWebsite = this._managementDomainService.Get(trademark.OwnerWebsite.ID);
                }

                if (trademark.ComWebsite != null)
                {
                    trademark.ComWebsite = this._managementDomainService.Get(trademark.ComWebsite.ID);
                }

                if (trademark.InvalidityApplicant != null)
                {
                    trademark.InvalidityApplicant = this._managementCompanyService.Get(trademark.InvalidityApplicant.ID);
                }

                model = new VMModel<Trademark>
                {
                    Record = trademark,
                    PageMode = PageMode.Edit
                };
            }

            return View("Trademark", model);
        }

        [HttpPost]
        [Route("Trademark", Name = "TrademarkPost")]
        public ActionResult Trademark(VMModel<Trademark> model)
        {
            Func<int> postModel = () =>
            {
                if (model.Record.ARIPODesignatedStatesSelected != null)
                    model.Record.ARIPODesignatedState = string.Join(";", model.Record.ARIPODesignatedStatesSelected);

                if (model.Record.WIPOBasicApplicationISOsSelected != null)
                    model.Record.WIPOBasicApplicationISO = string.Join(";", model.Record.WIPOBasicApplicationISOsSelected);

                if (model.Record.WIPODesignatedProtectionsSelected != null)
                    model.Record.WIPODesignatedProtection = string.Join(";", model.Record.WIPODesignatedProtectionsSelected);

                var validationResult = new Dictionary<string, string>();

                if (TrademarkValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.OwnerName = SessionUtils.GetUserAccount().DisplayName;

                        this._managementTrademarkService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Trademark",
                                ObjectID = model.Record.ID,
                                Message = "Trademark was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementTrademarkService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "Trademark",
                                ObjectID = model.Record.ID,
                                Message = "Trademark was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Trademark>(model, postModel);
        }

        [HttpGet]
        [Route("Trademark/Delete/{ID:int}", Name = "TrademarkDelete")]
        public ActionResult TrademarkDelete(int ID)
        {
            try
            {
                this._managementTrademarkService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("Trademarks");
        }

        [HttpGet]
        [Route("Trademark/Autocomplete/{keyword}", Name = "TrademarkAutocomplete")]
        public ActionResult TrademarkAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementTrademarkService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Trademark Owner"

        [Route("TrademarkOwners/{rowCount?}/{page?}", Name = "TrademarkOwners")]
        public ActionResult TrademarkOwners(int rowCount = 25, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var trademarkOwners = this._managementTrademarkOwnerService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<TrademarkOwner>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = trademarkOwners,
                Header = "Trademark Owners"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("TrademarkOwner/{ID:int}", Name = "TrademarkOwnerView")]
        public ActionResult TrademarkOwner(int ID)
        {
            var trademarkOwner = this._managementTrademarkOwnerService.Get(ID);

            if (trademarkOwner != null)
            {
                var trademark = this._trademarkService.Get(trademarkOwner.Trademark.ID);

                if(trademark != null)
                {
                    trademark.Office = this._managementOfficeService.Get(trademark.Office.ID);
                    trademark.Brand = this._managementBrandService.Get(trademark.Brand.ID);

                    if (trademark.OriginalOffice != null)
                    {
                        trademark.OriginalOffice = this._managementOfficeService.Get(trademark.OriginalOffice.ID);
                    }

                    if (trademark.TMWebsite != null)
                    {
                        trademark.TMWebsite = this._managementDomainService.Get(trademark.TMWebsite.ID);
                    }

                    if (trademark.OwnerWebsite != null)
                    {
                        trademark.OwnerWebsite = this._managementDomainService.Get(trademark.OwnerWebsite.ID);
                    }

                    if (trademark.ComWebsite != null)
                    {
                        trademark.ComWebsite = this._managementDomainService.Get(trademark.ComWebsite.ID);
                    }

                    if (trademark.InvalidityApplicant != null)
                    {
                        trademark.InvalidityApplicant = this._managementCompanyService.Get(trademark.InvalidityApplicant.ID);
                    }
                }

                trademarkOwner.Trademark = trademark;
                trademarkOwner.Company = this._managementCompanyService.Get(trademarkOwner.Company.ID);
            }

            var model = new VMModel<TrademarkOwner>
            {
                Record = trademarkOwner,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "TrademarkOwner")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("TrademarkOwnerView", model);
        }

        [Route("TrademarkOwner/New", Name = "TrademarkOwnerNew")]
        public ActionResult TrademarkOwnerNew()
        {
            VMModel<TrademarkOwner> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<TrademarkOwner>();
            }
            else
            {
                model = new VMModel<TrademarkOwner>
                {
                    Record = new TrademarkOwner(),
                    PageMode = PageMode.Edit
                };
            }

            return View("TrademarkOwner", model);
        }

        [Route("TrademarkOwner/Edit/{ID:int}", Name = "TrademarkOwnerEdit")]
        public ActionResult TrademarkOwnerEdit(int ID)
        {
            VMModel<TrademarkOwner> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<TrademarkOwner>();
            }
            else
            {
                model = new VMModel<TrademarkOwner>
                {
                    Record = this._managementTrademarkOwnerService.Get(ID),
                    PageMode = PageMode.Edit
                };
            }

            return View("TrademarkOwner", model);
        }

        [HttpPost]
        [Route("TrademarkOwner", Name = "TrademarkOwnerPost")]
        public ActionResult TrademarkOwner(VMModel<TrademarkOwner> model)
        {
            Func<int> postModel = () =>
            {
                var validationResult = new Dictionary<string, string>();

                if (TrademarkOwnerValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementTrademarkOwnerService.Insert(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "TrademarkOwner",
                                ObjectID = model.Record.ID,
                                Message = "Trademark Owner was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }
                    else
                    {
                        this._managementTrademarkOwnerService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "TrademarkOwner",
                                ObjectID = model.Record.ID,
                                Message = "Trademark Owner was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<TrademarkOwner>(model, postModel);
        }

        [HttpGet]
        [Route("TrademarkOwner/Delete/{ID:int}", Name = "TrademarkOwnerDelete")]
        public ActionResult TrademarkOwnerDelete(int ID)
        {
            try
            {
                this._managementTrademarkOwnerService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("TrademarkOwners");
        }

        #endregion

        #region "User Account"

        [Route("UserAccounts/{rowCount?}/{page?}", Name = "UserAccounts")]
        public ActionResult UserAccounts(int rowCount = 25, int page = 1)
        {
            if (!SessionUtils.GetUserAccount().Roles.Contains("Administrator"))
                return RedirectToAction("Index");

            var startIndex = (page - 1) * rowCount;
            var userAccounts = this._managementUserAccountService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<UserAccount>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = userAccounts,
                Header = "User Accounts"
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("UserAccount/{ID:int}", Name = "UserAccountView")]
        public ActionResult UserAccount(int ID)
        {
            if (!SessionUtils.GetUserAccount().Roles.Contains("Administrator"))
                return RedirectToAction("Index");

            var userAccount = this._managementUserAccountService.Get(ID);
            var model = new VMModel<UserAccount>
            {
                Record = userAccount,
                PageMode = PageMode.View,
                AuditTrails = _auditTrailService.Get(ID, "UserAccount")
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("UserAccountView", model);
        }

        [Route("UserAccount/New", Name = "UserAccountNew")]
        public ActionResult UserAccountNew()
        {
            if (!SessionUtils.GetUserAccount().Roles.Contains("Administrator"))
                return RedirectToAction("Index");

            VMModel<UserAccount> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<UserAccount>();
            }
            else
            {
                model = new VMModel<UserAccount>
                {
                    Record = new UserAccount(),
                    PageMode = PageMode.Edit,
                    AuditTrails = new List<AuditTrail>()
                };
            }

            return View("UserAccount", model);
        }

        [Route("UserAccount/Edit/{ID:int}", Name = "UserAccountEdit")]
        public ActionResult UserAccountEdit(int ID)
        {
            if (!SessionUtils.GetUserAccount().Roles.Contains("Administrator"))
                return RedirectToAction("Index");

            VMModel<UserAccount> model = null;

            if (TempData.ContainsKey("ModelPosted"))
            {
                model = this.GetValidationErrors<UserAccount>();
            }
            else
            {
                model = new VMModel<UserAccount>
                {
                    Record = this._managementUserAccountService.Get(ID),
                    PageMode = PageMode.Edit,
                    AuditTrails = new List<AuditTrail>()
                };
            }

            return View("UserAccount", model);
        }

        [HttpGet]
        [Route("UserAccount/Delete/{ID:int}", Name = "UserAccountDelete")]
        public ActionResult UserAccountDelete(int ID)
        {
            try
            {
                this._managementUserAccountService.Delete(ID);

                TempData.Add("IsRedirectFromDelete", true);
            }
            catch (Exception ex)
            {
                //log exception here
            }

            return RedirectToAction("UserAccounts");
        }

        [HttpPost]
        [Route("UserAccount", Name = "UserAccountPost")]
        public ActionResult UserAccount(VMModel<UserAccount> model)
        {
            if (!SessionUtils.GetUserAccount().Roles.Contains("Administrator"))
                return RedirectToAction("Index");

            Func<int> postModel = () =>
            {
                if (model.Record.RolesSelected != null)
                    model.Record.Roles = string.Join(";", model.Record.RolesSelected);

                var validationResult = new Dictionary<string, string>();

                if (UserAccountValidator.IsValid(model.Record, this._managementUserAccountService, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        model.Record.Username = model.Record.EmailAddress;
                        model.Record.Password = PasswordEncryption.Encrypt(StringUtils.GenerateRandomString());
                        model.Record.CreatedBy = SessionUtils.GetUserAccount().ID;
                        model.Record.CreatedDate = SessionUtils.GetCurrentDateTime();

                        this._managementUserAccountService.Insert(model.Record);

                        this._emailAutomationService.SendEmail(
                            to: model.Record.Username,
                            subject: "Account Verification",
                            body: UserAccountTemplate.GetEmailVerificationTemplate(
                                model.Record.ID,
                                ConfigurationManager.AppSettings["Host"],
                                model.Record.FirstName),
                            fromName: "Trademarkers LLC.",
                            isHtml: true);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = model.Record.ID,
                                Message = "User Account was created successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = model.Record.ID,
                                Message = $"An e-mail account verification was sent to {model.Record.Username}",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });

                        TempData.Add("UserAccountInserted", true);
                    }
                    else
                    {
                        var userAccount = this._managementUserAccountService.Get(model.Record.ID);

                        if (model.Record.IsActive && model.Record.IsActive != userAccount.IsActive)
                        {
                            var securityKey = ConfigurationManager.AppSettings["PasswordSecurityKey"];
                            var encryptedID = PasswordEncryption.Encrypt($"{securityKey}_{userAccount.ID}");

                            this._emailAutomationService.SendEmail(
                                to: model.Record.EmailAddress,
                                subject: $"Reactivate Account - {model.Record.EmailAddress}",
                                body: UserAccountTemplate.GetReactivateAccountTemplate(
                                    encryptedID,
                                    ConfigurationManager.AppSettings["Host"],
                                    userAccount.FirstName),
                                fromName: "Trademarkers LLC.",
                                isHtml: true);

                            this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = model.Record.ID,
                                Message = $"An e-mail account reactivation was sent to {model.Record.EmailAddress}.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                        }

                        if (!model.Record.IsActive && userAccount.IsActive)
                        {
                            this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = model.Record.ID,
                                Message = "User Account was deactivated.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                        }

                        this._managementUserAccountService.Update(model.Record);

                        this._auditTrailService.Insert(
                            new AuditTrail
                            {
                                ObjectName = "UserAccount",
                                ObjectID = model.Record.ID,
                                Message = "User Account was updated successfully.",
                                UserAccount = new UserAccount
                                {
                                    ID = SessionUtils.GetUserAccount().ID
                                },
                                CreateDate = SessionUtils.GetCurrentDateTime()
                            });
                    }

                    return model.Record.ID;
                }
                else
                {
                    foreach (var item in validationResult)
                    {
                        ModelState.AddModelError(item.Key, item.Value);
                    }

                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<UserAccount>(model, postModel);
        }

        [HttpGet]
        [Route("UserAccount/Autocomplete/{keyword}", Name = "UserAccountAutocomplete")]
        public ActionResult UserAccountAutocomplete(string keyword)
        {
            VMJsonResult result = null;

            try
            {
                result = new VMJsonResult
                {
                    IsSuccess = true,
                    Result = this._managementUserAccountService.GetAutocomplete(keyword)
                };
            }
            catch (Exception ex)
            {
                result = new VMJsonResult
                {
                    IsSuccess = false,
                    ErrorMessage = ex.Message
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region "Shared Action Results"

        [HttpPost]
        [Route("FileAttachment/Upload", Name = "FileAttachmentUpload")]
        public ActionResult FileAttachmentUpload(int ID, string objectName, HttpPostedFileBase file)
        {
            byte[] fileContent = null;

            using (var binaryReader = new BinaryReader(file.InputStream))
            {
                fileContent = binaryReader.ReadBytes(file.ContentLength);
            }

            var fileAttachment = new FileAttachment
            {
                ObjectID = ID,
                FileName = file.FileName,
                File = fileContent,

                CreateDate = SessionUtils.GetCurrentDateTime()
            };

            this._fileAttachmentService.Insert(fileAttachment, objectName);

            TempData.Add("IsPostedFile", fileAttachment.FileName);

            return RedirectToRoute(objectName + "View", new { ID = ID });
        }

        [HttpGet]
        [Route("FileAttachment/Download", Name = "FileAttachmentDownload")]
        public ActionResult FileAttachmentDownload(int ID, string objectName)
        {
            var fileAttachment = this._fileAttachmentService.GetByID(ID, objectName);

            return File(fileAttachment.File, "application/octet-stream", fileAttachment.FileName);
        }

        [HttpGet]
        [Route("FileAttachment/Delete", Name = "FileAttachmentDelete")]
        public ActionResult FileAttachmentDelete(int ID, string objectName)
        {
            var fileAttachment = this._fileAttachmentService.GetByID(ID, objectName);

            this._fileAttachmentService.Delete(ID, objectName);

            TempData.Add("IsDeletedFile", fileAttachment.FileName);

            return RedirectToRoute(objectName + "View", new { ID = fileAttachment.ObjectID });
        }

        #endregion

        #region "Private Methods"

        private ActionResult RedirectPost<TModel>(VMModel<TModel> model, Func<int> postModel) where TModel : BusinessBase
        {
            var routeName = model.Name;

            try
            {
                model.Record.ID = postModel();
                routeName += "View";

                TempData.Add("IsPosted", true);
            }
            catch (Exception ex)
            {
                //log exception here
                
                model.PageMode = PageMode.PersistError;
                routeName += model.Record.ID > 0 ? "Edit" : "New";

                TempData.Add("ModelPosted", model);
                TempData.Add("ModelPostedState", ModelState);
            }

            return RedirectToRoute(routeName, RouteUtils.GetRouteMapping(typeof(TModel), model.Record));
        }

        private VMModel<TModel> GetValidationErrors<TModel>() where TModel : BusinessBase
        {
            var model = (VMModel<TModel>)TempData["ModelPosted"];
            TempData.Remove("ModelPosted");

            var modelState = (ModelStateDictionary)TempData["ModelPostedState"];

            for (var i = 0; i < modelState.Values.Count; i++)
            {
                foreach (var error in modelState.Values.ElementAt(i).Errors)
                {
                    ModelState.AddModelError(modelState.Keys.ElementAt(i), error.ErrorMessage);
                }
            }

            return model;
        }

        #endregion
    }
}
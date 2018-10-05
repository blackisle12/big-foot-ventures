using BigFootVentures.Application.Web.Models.Extensions;
using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Enumerators;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System;
using System.Linq;
using System.Web.Mvc;
using static BigFootVentures.Application.Web.Models.VMEnums;

namespace BigFootVentures.Application.Web.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        #region "Private Members"

        private readonly IManagementService<Brand> _managementBrandService = null;
        private readonly IManagementService<Company> _managementCompanyService = null;        
        private readonly IManagementService<DomainN> _managementDomainService = null;
        private readonly IManagementService<Enquiry> _managementEnquiryService = null;
        private readonly IManagementService<LoginInformation> _managementLoginInformationService = null;
        private readonly IManagementService<OfficeStatus> _managementOfficeStatusService = null;
        private readonly IManagementService<Register> _managementRegisterService = null;

        #endregion

        #region "Constructors"

        public HomeController(IManagementService<Brand> managementBrandService,
            IManagementService<Company> managementCompanyService,
            IManagementService<DomainN> managementDomainService,
            IManagementService<Enquiry> managementEnquiryService,
            IManagementService<LoginInformation> managementLoginInformationService,
            IManagementService<OfficeStatus> managementOfficeStatusService,
            IManagementService<Register> managementRegisterService)
        {
            this._managementBrandService = managementBrandService;
            this._managementCompanyService = managementCompanyService;
            this._managementDomainService = managementDomainService;
            this._managementEnquiryService = managementEnquiryService;
            this._managementLoginInformationService = managementLoginInformationService;
            this._managementOfficeStatusService = managementOfficeStatusService;
            this._managementRegisterService = managementRegisterService;
        }

        #endregion

        #region "Default"

        [Route("~/")]
        [Route("")]
        [Route("Index")]
        public ActionResult Index()
        {
            return View();
        }

        #endregion

        #region "Brands"

        [Route("Brands/{rowCount?}/{page?}", Name = "Brands")]
        public ActionResult Brands(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var brands = this._managementBrandService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Brand>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = brands
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

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

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Brand", model);
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

                if (ModelState.IsValid)
                {                    
                    if (model.Record.ID == 0)
                    {
                        this._managementBrandService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementBrandService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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

        #region "Companies"

        [Route("Companies/{rowCount?}/{page?}", Name = "Companies")]
        public ActionResult Companies(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var companies = this._managementCompanyService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Company>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = companies
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("Company/{ID:int}", Name = "CompanyView")]
        public ActionResult Company(int ID)
        {
            var company = this._managementCompanyService.Get(ID);

            if (company.ParentAccountID != null)
            {
                company.ParentAccountName = this._managementCompanyService.Get(company.ParentAccountID.Value)?.DisplayName;
            }

            var model = new VMModel<Company>
            {
                Record = company,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Company", model);
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

                if (company.ParentAccountID != null)
                {
                    company.ParentAccountName = this._managementCompanyService.Get(company.ParentAccountID.Value)?.DisplayName;
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
                if (string.Equals(model.Record.AccountRecordType, ManagementEnums.Company.AccountRecordType.BusinessAccount.ToDescription(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(model.Record.CompanyName))
                    {
                        ModelState.AddModelError("Record.CompanyName", "This field is required");
                    }
                }
                else if (string.Equals(model.Record.AccountRecordType, ManagementEnums.Company.AccountRecordType.ExternalClient.ToDescription(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(model.Record.CompanyName))
                    {
                        ModelState.AddModelError("Record.CompanyName", "This field is required");
                    }
                }
                else if (string.Equals(model.Record.AccountRecordType, ManagementEnums.Company.AccountRecordType.PersonAccount.ToDescription(), StringComparison.InvariantCultureIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(model.Record.LastName))
                    {
                        ModelState.AddModelError("Record.LastName", "This field is required");
                    }
                }

                if (ModelState.IsValid)
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementCompanyService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementCompanyService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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

        #region "Domains"

        [Route("Domains/{rowCount?}/{page?}", Name = "Domains")]
        public ActionResult Domains(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var domains = this._managementDomainService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<DomainN>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = domains
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("Domain/{ID:int}", Name = "DomainNView")]
        public ActionResult Domain(int ID)
        {
            var domain = this._managementDomainService.Get(ID);

            if (domain.RegistrantCompanyID != null)
            {
                domain.RegistrantCompanyName = this._managementCompanyService.Get(domain.RegistrantCompanyID.Value)?.DisplayName;
            }

            if (domain.DomainEnquiryID != null)
            {
                domain.DomainEnquiryCaseNumber = this._managementEnquiryService.Get(domain.RegistrantCompanyID.Value)?.OldCaseNumber;
            }

            domain.BrandName = this._managementBrandService.Get(domain.BrandID.Value).Name;

            if (domain.RegistrarID != null)
            {
                domain.RegistrarName = this._managementRegisterService.Get(domain.RegistrarID.Value).Name;
            }

            if (domain.RegistrantID != null)
            {
                domain.RegistrantName = this._managementCompanyService.Get(domain.RegistrantID.Value)?.DisplayName;
            }

            if (domain.PreviousRegistrantID != null)
            {
                domain.PreviousRegistrantName = this._managementCompanyService.Get(domain.PreviousRegistrantID.Value)?.DisplayName;
            }

            var model = new VMModel<DomainN>
            {
                Record = domain,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Domain", model);
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

                if (domain.RegistrantCompanyID != null)
                {
                    domain.RegistrantCompanyName = this._managementCompanyService.Get(domain.RegistrantCompanyID.Value)?.DisplayName;
                }

                if (domain.DomainEnquiryID != null)
                {
                    domain.DomainEnquiryCaseNumber = this._managementEnquiryService.Get(domain.RegistrantCompanyID.Value)?.OldCaseNumber;
                }

                domain.BrandName = this._managementBrandService.Get(domain.BrandID.Value).Name;

                if (domain.RegistrarID != null)
                {
                    domain.RegistrarName = this._managementRegisterService.Get(domain.RegistrarID.Value).Name;
                }

                if (domain.RegistrantID != null)
                {
                    domain.RegistrantName = this._managementCompanyService.Get(domain.RegistrantID.Value)?.DisplayName;
                }

                if (domain.PreviousRegistrantID != null)
                {
                    domain.PreviousRegistrantName = this._managementCompanyService.Get(domain.PreviousRegistrantID.Value)?.DisplayName;
                }

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
                if (string.IsNullOrWhiteSpace(model.Record.BrandName))
                {
                    ModelState.AddModelError("Record.BrandName", "This field is required");
                }

                if (ModelState.IsValid)
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementDomainService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementDomainService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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


        #endregion

        #region "Enquiries"

        [Route("Enquiries/{rowCount?}/{page?}", Name = "Enquiries")]
        public ActionResult Enquiries(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var enquiries = this._managementEnquiryService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Enquiry>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = enquiries
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("Enquiry/{ID:int}", Name = "EnquiryView")]
        public ActionResult Enquiry(int ID)
        {
            var enquiry = this._managementEnquiryService.Get(ID);

            if (enquiry.RegistrantID != null)
            {
                enquiry.RegistrantName = this._managementRegisterService.Get(enquiry.RegistrantID.Value)?.Name;
            }

            if (enquiry.RegistrantCompanyID != null)
            {
                enquiry.RegistrantCompanyName = this._managementCompanyService.Get(enquiry.RegistrantCompanyID.Value)?.DisplayName;
            }

            var model = new VMModel<Enquiry>
            {
                Record = enquiry,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Enquiry", model);
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

                if (enquiry.RegistrantID != null)
                {
                    enquiry.RegistrantName = this._managementRegisterService.Get(enquiry.RegistrantID.Value)?.Name;
                }

                if (enquiry.RegistrantCompanyID != null)
                {
                    enquiry.RegistrantCompanyName = this._managementCompanyService.Get(enquiry.RegistrantCompanyID.Value)?.DisplayName;
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
                if (ModelState.IsValid)
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementEnquiryService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementEnquiryService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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

        #endregion

        #region "Login Information"

        [Route("LoginInformations/{rowCount?}/{page?}", Name = "LoginInformations")]
        public ActionResult LoginInformations(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var loginInformations = this._managementLoginInformationService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<LoginInformation>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = loginInformations
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
            
            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("LoginInformation", model);
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
                if (ModelState.IsValid)
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementLoginInformationService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementLoginInformationService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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
            
        #region "Office Status"

        [Route("OfficeStatuses/{rowCount?}/{page?}", Name = "OfficeStatuses")]
        public ActionResult OfficeStatuses(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var officeStatuses = this._managementOfficeStatusService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<OfficeStatus>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = officeStatuses
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
            var model = new VMModel<OfficeStatus>
            {
                Record = officeStatus,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("OfficeStatus", model);
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
                model = new VMModel<OfficeStatus>
                {
                    Record = this._managementOfficeStatusService.Get(ID),
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
                if (ModelState.IsValid)
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementOfficeStatusService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementOfficeStatusService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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

        #region "Registers"

        [Route("Registers/{rowCount?}/{page?}", Name = "Registers")]
        public ActionResult Registers(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var registers = this._managementRegisterService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Register>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = registers
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("Register/{ID:int}", Name = "RegisterView")]
        public ActionResult Register(int ID)
        {
            var register = this._managementRegisterService.Get(ID);
            var model = new VMModel<Register>
            {
                Record = register,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Register", model);
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
                if (ModelState.IsValid)
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementRegisterService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementRegisterService.Update(model.Record);
                    }

                    return model.Record.ID;
                }
                else
                {
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
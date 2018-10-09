using BigFootVentures.Application.Web.Models.Extensions;
using BigFootVentures.Application.Web.Models.Utilities;
using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects;
using BigFootVentures.Business.Objects.Enumerators;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using BigFootVentures.Service.BusinessService.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static BigFootVentures.Application.Web.Models.VMEnums;

namespace BigFootVentures.Application.Web.Controllers
{
    [RoutePrefix("Home")]
    public class HomeController : Controller
    {
        #region "Private Members"

        private readonly IManagementService<AgreementT> _managementAgreementService = null;
        private readonly IManagementService<Brand> _managementBrandService = null;
        private readonly IManagementService<Company> _managementCompanyService = null;
        private readonly IManagementService<Contact> _managementContactService = null;
        private readonly IManagementService<DomainN> _managementDomainService = null;
        private readonly IManagementService<Enquiry> _managementEnquiryService = null;
        private readonly IManagementService<Lead> _managementLeadService = null;
        private readonly IManagementService<LoginInformation> _managementLoginInformationService = null;
        private readonly IManagementService<Office> _managementOfficeService = null;
        private readonly IManagementService<OfficeStatus> _managementOfficeStatusService = null;
        private readonly IManagementService<Register> _managementRegisterService = null;

        #endregion

        #region "Constructors"

        public HomeController(IManagementService<AgreementT> managementAgreementService,
            IManagementService<Brand> managementBrandService,
            IManagementService<Company> managementCompanyService,
            IManagementService<Contact> managementContactService,
            IManagementService<DomainN> managementDomainService,
            IManagementService<Enquiry> managementEnquiryService,
            IManagementService<Lead> managementLeadService,
            IManagementService<LoginInformation> managementLoginInformationService,
            IManagementService<Office> managementOfficeService,
            IManagementService<OfficeStatus> managementOfficeStatusService,
            IManagementService<Register> managementRegisterService)
        {
            this._managementAgreementService = managementAgreementService;
            this._managementBrandService = managementBrandService;
            this._managementCompanyService = managementCompanyService;
            this._managementContactService = managementContactService;
            this._managementDomainService = managementDomainService;
            this._managementEnquiryService = managementEnquiryService;
            this._managementLeadService = managementLeadService;
            this._managementLoginInformationService = managementLoginInformationService;
            this._managementOfficeService = managementOfficeService;
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

        #region "Agreement"

        [Route("Agreements/{rowCount?}/{page?}", Name = "Agreements")]
        public ActionResult Agreements(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var agreements = this._managementAgreementService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<AgreementT>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = agreements
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

            return View(pageResult);
        }

        [Route("Agreement/{ID:int}", Name = "AgreementTView")]
        public ActionResult Agreement(int ID)
        {
            var agreement = this._managementAgreementService.Get(ID);
            var model = new VMModel<AgreementT>
            {
                Record = agreement,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Agreement", model);
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
                model = new VMModel<AgreementT>
                {
                    Record = this._managementAgreementService.Get(ID),
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
                        this._managementAgreementService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementAgreementService.Update(model.Record);
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

                var validationResult = new Dictionary<string, string>();

                if (BrandValidator.IsValid(model.Record, out validationResult))
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

        #region "Company"

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

            if (company.ParentAccount != null)
            {
                company.ParentAccount = this._managementCompanyService.Get(company.ParentAccount.ID);
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
                    }
                    else
                    {
                        this._managementCompanyService.Update(model.Record);
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

        [Route("Contacts/{rowCount?}/{page?}", Name = "Contacts")]
        public ActionResult Contacts(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var contacts = this._managementContactService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Contact>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = contacts
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

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

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Contact", model);
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
                        this._managementContactService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementContactService.Update(model.Record);
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

            if (domain.RegistrantCompany != null)
            {
                domain.RegistrantCompany = this._managementCompanyService.Get(domain.RegistrantCompany.ID);
            }

            if (domain.DomainEnquiry != null)
            {
                domain.DomainEnquiry = this._managementEnquiryService.Get(domain.DomainEnquiry.ID);
            }

            if (domain.Brand != null)
            {
                domain.Brand = this._managementBrandService.Get(domain.Brand.ID);
            }

            if (domain.Registrar != null)
            {
                domain.Registrar = this._managementRegisterService.Get(domain.Registrar.ID);
            }

            if (domain.Registrant != null)
            {
                domain.Registrant = this._managementCompanyService.Get(domain.Registrant.ID);
            }

            if (domain.PreviousRegistrant != null)
            {
                domain.PreviousRegistrant = this._managementCompanyService.Get(domain.PreviousRegistrant.ID);
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

                if (domain.RegistrantCompany != null)
                {
                    domain.RegistrantCompany = this._managementCompanyService.Get(domain.RegistrantCompany.ID);
                }

                if (domain.DomainEnquiry != null)
                {
                    domain.DomainEnquiry = this._managementEnquiryService.Get(domain.DomainEnquiry.ID);
                }

                if (domain.Brand != null)
                {
                    domain.Brand = this._managementBrandService.Get(domain.Brand.ID);
                }

                if (domain.Registrar != null)
                {
                    domain.Registrar = this._managementRegisterService.Get(domain.Registrar.ID);
                }

                if (domain.Registrant != null)
                {
                    domain.Registrant = this._managementCompanyService.Get(domain.Registrant.ID);
                }

                if (domain.PreviousRegistrant != null)
                {
                    domain.PreviousRegistrant = this._managementCompanyService.Get(domain.PreviousRegistrant.ID);
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
                var validationResult = new Dictionary<string, string>();

                if (DomainValidator.IsValid(model.Record, out validationResult))
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

        #region "Enquiry"

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

        #endregion

        #region "Lead"

        [Route("Leads/{rowCount?}/{page?}", Name = "Leads")]
        public ActionResult Leads(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var leads = this._managementLeadService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Lead>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = leads
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

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

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Lead", model);
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
                        this._managementLeadService.Insert(model.Record);
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
                var validationResult = new Dictionary<string, string>();

                if (LoginInformationValidator.IsValid(model.Record, out validationResult))
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

        [Route("Offices/{rowCount?}/{page?}", Name = "Offices")]
        public ActionResult Offices(int rowCount = 10, int page = 1)
        {
            var startIndex = (page - 1) * rowCount;
            var offices = this._managementOfficeService.Get(startIndex, rowCount, out int total);
            var pageResult = new VMPageResult<Office>
            {
                StartIndex = startIndex,
                RowCount = rowCount,
                Page = page,
                Total = total,
                Records = offices
            };

            if (TempData.ContainsKey("IsRedirectFromDelete"))
            {
                pageResult.IsRedirectFromDelete = true;
                TempData.Remove("IsRedirectFromDelete");
            }

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

            if (TempData.ContainsKey("IsPosted"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsPosted");
            }

            return View("Office", model);
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
                var validationResult = new Dictionary<string, string>();

                if (OfficeValidator.IsValid(model.Record, out validationResult))
                {
                    if (model.Record.ID == 0)
                    {
                        this._managementOfficeService.Insert(model.Record);
                    }
                    else
                    {
                        this._managementOfficeService.Update(model.Record);
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
                var validationResult = new Dictionary<string, string>();

                if (OfficeStatusValidator.IsValid(model.Record, out validationResult))
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

        #region "Register"

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
                var validationResult = new Dictionary<string, string>();

                if (RegisterValidator.IsValid(model.Record, out validationResult))
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
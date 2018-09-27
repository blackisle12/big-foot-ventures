using BigFootVentures.Application.Web.Models.Extensions;
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

        #endregion

        #region "Constructors"

        public HomeController(IManagementService<Brand> managementBrandService, IManagementService<Company> managementCompanyService)
        {
            this._managementBrandService = managementBrandService;
            this._managementCompanyService = managementCompanyService;
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

        [HttpPost]
        [Route("Brand", Name = "BrandPost")]
        public ActionResult Brand(VMModel<Brand> model)
        {
            Action action = () =>
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
                }
                else
                {
                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Brand>(model, action, new { ID = model.Record.ID });
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
                model = new VMModel<Company>
                {
                    Record = this._managementCompanyService.Get(ID),
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

        [HttpPost]
        [Route("Company", Name = "CompanyPost")]
        public ActionResult Company(VMModel<Company> model)
        {
            Action action = () =>
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
                }
                else
                {
                    throw new Exception("error on validation.."); //will rework on this
                }
            };

            return RedirectPost<Company>(model, action, new { recordType = model.Record.AccountRecordType, ID = model.Record.ID });
        }

        #endregion

        #region "Private Methods"

        private ActionResult RedirectPost<TModel>(VMModel<TModel> model, Action action, dynamic routeValues) where TModel : BusinessBase
        {
            var routeName = model.Name;

            try
            {
                action();
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

            return RedirectToRoute(routeName, routeValues);
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
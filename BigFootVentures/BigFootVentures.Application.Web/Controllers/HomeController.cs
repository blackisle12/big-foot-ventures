using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System;
using System.Web.Mvc;
using static BigFootVentures.Application.Web.Models.Utilities.EnumUtils.ViewModels;

namespace BigFootVentures.Application.Web.Controllers
{
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

        #region "Views"

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Brands(int startIndex = 0, int rowCount = 10, int page = 1)
        {
            startIndex = (page - 1) * rowCount;

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

        public ActionResult Brand(int ID, int? toEdit)
        {
            var brand = ID > 0 ? this._managementBrandService.Get(ID) : new Brand();
            var model = new VMModel<Brand>
            {
                Record = brand,
                PageMode = toEdit != null || ID == 0 ? PageMode.Edit : PageMode.View,
            };

            if (TempData.ContainsKey("IsNewlyCreated"))
            {
                model.PageMode = PageMode.PersistSuccess;
                TempData.Remove("IsNewlyCreated");
            }

            return View(model);
        }

        public ActionResult Companies(int startIndex = 0, int rowCount = 10, int page = 1)
        {
            startIndex = (page - 1) * rowCount;

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

        #endregion

        #region "Http Methods"

        [HttpPost]
        public ActionResult Brand(VMModel<Brand> model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.Record.CategoriesSelected != null)                    
                        model.Record.Category = string.Join(";", model.Record.CategoriesSelected);

                    if (model.Record.ID == 0)
                    {
                        this._managementBrandService.Insert(model.Record);

                        TempData.Add("IsNewlyCreated", true);
                        return RedirectToAction("Brand", "Home", new { model.Record.ID });
                    }
                    else
                    {
                        this._managementBrandService.Update(model.Record);
                    }
                }

                model.PageMode = PageMode.PersistSuccess;
            }
            catch (Exception ex)
            {
                //log exception here     
                model.PageMode = PageMode.PersistError;
            }

            return View(model);
        }

        [HttpGet]
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

            return RedirectToAction("Brands", "Home");
        }

        #endregion
    }
}
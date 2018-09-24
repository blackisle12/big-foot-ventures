using BigFootVentures.Application.Web.Models.ViewModels;
using BigFootVentures.Business.Objects.Management;
using BigFootVentures.Service.BusinessService;
using System;
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

        [Route("Brands/{startIndex?}/{rowCount?}/{page?}", Name = "Brands")]
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

        [Route("Brand/{ID:int}", Name = "BrandView")]
        public ActionResult Brand(int ID)
        {
            var brand = this._managementBrandService.Get(ID);
            var model = new VMModel<Brand>
            {
                Record = brand,
                PageMode = PageMode.View
            };

            if (TempData.ContainsKey("IsBrandPosted"))
            {
                model.PageMode = (bool)TempData["IsBrandPosted"] ? PageMode.PersistSuccess : PageMode.PersistError;
                TempData.Remove("IsBrandPosted");
            }

            return View("Brand", model);
        }

        [Route("Brand/Edit/{ID:int}", Name = "BrandEdit")]
        public ActionResult BrandEdit(int ID)
        {
            var brand = this._managementBrandService.Get(ID);
            var model = new VMModel<Brand>
            {
                Record = brand,
                PageMode = PageMode.Edit
            };

            return View("Brand", model);
        }

        [Route("Brand/New", Name = "BrandNew")]
        public ActionResult BrandNew()
        {            
            var model = new VMModel<Brand>
            {
                Record = new Brand(),
                PageMode = PageMode.Edit
            };

            return View("Brand", model);
        }

        [HttpPost]
        [Route("Brand", Name = "BrandPost")]
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
                    }
                    else
                    {
                        this._managementBrandService.Update(model.Record);
                    }
                }

                TempData.Add("IsBrandPosted", true);
            }
            catch (Exception ex)
            {
                //log exception here                
                TempData.Add("IsBrandPosted", false);
            }
            
            return RedirectToRoute("BrandView", new { ID = model.Record.ID });
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

            return RedirectToAction("Brands", "Home");
        }

        #endregion

        #region "Companies"

        [Route("Company/New/SelectRecordType", Name = "CompanyNewSelectRecordType")]
        public ActionResult CompanyNewSelectRecordType()
        {
            return View();
        }

        #endregion
    }
}
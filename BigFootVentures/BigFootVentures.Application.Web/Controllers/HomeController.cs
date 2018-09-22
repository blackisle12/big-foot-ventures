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

        private readonly IManagementService _managementService = null;

        #endregion

        #region "Constructors"

        public HomeController(IManagementService managementService)
        {
            this._managementService = managementService;
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

            var brands = this._managementService.Brand_Get(startIndex, rowCount, out int total);
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
            var brand = ID > 0 ? this._managementService.Brand_Get(ID) : new Brand();
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

        #endregion

        #region "Http Methods"

        [HttpPost]
        public ActionResult Brand(VMModel<Brand> model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.Record.Category = string.Join(";", model.Record.CategoriesSelected);

                    if (model.Record.ID == 0)
                    {
                        this._managementService.Brand_Insert(model.Record);

                        TempData.Add("IsNewlyCreated", true);
                        return RedirectToAction("Brand", "Home", new { model.Record.ID });
                    }
                    else
                    {
                        this._managementService.Brand_Update(model.Record);
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
                this._managementService.Brand_Delete(ID);

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
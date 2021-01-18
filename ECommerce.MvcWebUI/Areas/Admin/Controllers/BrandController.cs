using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;
using ECommerce.MvcWebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.MvcWebUI.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        private readonly IBrandService _brandService;
        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        public ActionResult Index()
        {
            var brandList = _brandService.GetList();
            return View(brandList);
        }

        public ActionResult Form()
        {
            ViewBag.Title = "Marka Ekle";
            return View("Form");
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                var brand = _brandService.Get(b => b.Id == id);
                if (brand != null)
                {
                    ViewBag.Title = "Marka Güncelle";
                    return View("Form", brand);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(Brand brand)
        {
            if (brand.Id == 0)
            {
                ViewBag.Title = "Marka Ekle";
                try
                {
                    _brandService.Add(brand);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = brand.BrandName, Message = "adlı marka eklendi...", LinkText = "Marka Listesi", Url = "/Admin/Brand" };
                    ModelState.Clear();
                    return View("Form");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                    return View("Form", brand);
                }
            }
            else
            {
                try
                {
                    _brandService.Update(brand);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = brand.BrandName, Message = "adlı marka güncellendi...", LinkText = "Marka Listesi", Url = "/Admin/Brand" };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("Update", new { id = brand.Id });
            }
        }
    }
}
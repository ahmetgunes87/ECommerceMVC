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
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            var categoryList = _categoryService.GetList();
            return View(categoryList);
        }

        public ActionResult Form()
        {
            ViewBag.Title = "Kategori Ekle";
            return View("Form");
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                var category = _categoryService.Get(c => c.Id == id);
                if (category != null)
                {
                    ViewBag.Title = "Kategori Güncelle";
                    return View("Form", category);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(Category category)
        {
            if (category.Id == 0)
            {
                ViewBag.Title = "Kategori Ekle";
                try
                {
                    _categoryService.Add(category);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = category.CategoryName, Message = "adlı kategori eklendi...", LinkText = "Kategori Listesi", Url = "/Admin/Category" };
                    ModelState.Clear();
                    return View("Form");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                    return View("Form", category);
                }
            }
            else
            {
                try
                {
                    _categoryService.Update(category);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = category.CategoryName, Message = "adlı kategori güncellendi...", LinkText = "Kategori Listesi", Url = "/Admin/Category" };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("Update", new { id = category.Id });
            }
        }
    }
}
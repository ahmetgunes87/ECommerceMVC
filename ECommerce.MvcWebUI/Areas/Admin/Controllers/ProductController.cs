using ECommerce.Business.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using ECommerce.MvcWebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.MvcWebUI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;
        public ProductController(IProductService productService, ICategoryService categoryService, IBrandService brandService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _brandService = brandService;
        }

        public ActionResult Index()
        {
            var productList = _productService.GetListWithCategoryName();
            return View(productList);
        }

        public ActionResult Form()
        {
            ViewBag.Title = "Ürün Ekle";
            ProductItem productItem = new ProductItem()
            {
                Product = null,
                Categories = _categoryService.GetList(x => x.IsActive),
                Brands = _brandService.GetList(x => x.IsActive)
            };
            return View("Form", productItem);
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                var product = _productService.Get(p => p.Id == id);
                if (product != null)
                {
                    ViewBag.Title = "Ürün Güncelle";
                    ProductItem productItem = new ProductItem()
                    {
                        Product = product,
                        Categories = _categoryService.GetList(x => x.IsActive).OrderBy(x => x.CategoryName).ToList(),
                        Brands = _brandService.GetList(x => x.IsActive).OrderBy(x => x.BrandName).ToList()
                    };
                    return View("Form", productItem);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(ProductItem productItem)
        {
            var product = productItem.Product;

            if (product.Id == 0)
            {
                ViewBag.Title = "Ürün Ekle";
                try
                {
                    _productService.Add(product);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = product.ProductName, Message = " adlı ürün eklendi...", LinkText = "Ürün Listesi", Url = "/Admin/Product" };
                    ModelState.Clear();
                    return RedirectToAction("Form");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                    ProductItem productNew = new ProductItem()
                    {
                        Product = productItem.Product,
                        Categories = _categoryService.GetList(x => x.IsActive).OrderBy(x => x.Id == product.CategoryId).ToList(),
                        Brands = _brandService.GetList(x => x.IsActive).OrderBy(x => x.Id == product.BrandId).ToList()
                    };
                    return View("Form", productNew);
                }
            }
            else
            {
                try
                {
                    _productService.Update(product);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = product.ProductName, Message = " adlı ürün güncellendi...", LinkText = "Ürün Listesi", Url = "/Admin/Product" };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("Update", new { id = product.Id });
            }
        }
        public ActionResult Image(int id)
        {
            if (id > 0)
            {
                var product = _productService.Get(p => p.Id == id);
                if (product != null)
                {
                    ViewBag.Title = product.ProductName + " - Resimler";
                    ImagesViewModel productImages = new ImagesViewModel()
                    {
                        ProductImages = _productService.GetListProductImages(id)
                    };
                    return View("Image", productImages);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Image(HttpPostedFileBase[] images, int id)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<ProductImage> productImages = new List<ProductImage>();
                    foreach (HttpPostedFileBase image in images)
                    {                        
                        if (image != null)
                        {
                            string extension = Path.GetExtension(image.FileName).ToLower();
                            if (extension == ".jpg" || extension == ".png" || extension == ".jpeg")
                            {
                                string newfolder = Server.MapPath("~/UploadedImages/" + id);
                                if (!Directory.Exists(newfolder))
                                    Directory.CreateDirectory(newfolder);
                                var filename = Path.GetFileName(image.FileName);
                                var ServerSavePath = Path.Combine(Server.MapPath("~/UploadedImages/" + id + "/") + filename);
                                image.SaveAs(ServerSavePath);
                                ProductImage productImage = new ProductImage()
                                {
                                    ProductId = id,
                                    Image = filename,
                                    IsMainImage = false
                                };
                                productImages.Add(productImage);
                            }
                            else
                                TempData["Message"] = new MessageViewModel() { CssClass = "alert-warning", Title = "İzin Verilen:", Message = ".jpg, .png, .jpeg uzantılı resim dosyaları." };
                        }
                    }
                    if (productImages.Count > 0)
                    {
                        _productService.AddImage(productImages);
                        TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = "", Message = productImages.Count().ToString() + " adet resim başarıyla yüklendi...", LinkText = "Ürün Listesi", Url = "/Admin/Product" };
                    }
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
            }
            return RedirectToAction("Image", id);
        }
        public ActionResult DeleteImage(int id)
        {           
            var productImage = _productService.GetImage(p => p.Id == id);
            if (productImage != null)
            {
                _productService.DeleteImage(id);
                string deletepath = Server.MapPath("~/UploadedImages/" + productImage.ProductId + "/" + productImage.Image);
                if (System.IO.File.Exists(deletepath))
                    System.IO.File.Delete(deletepath);                    
            }            
            return RedirectToAction("Image", new { id = productImage.ProductId });
        }
        public ActionResult MainImage(int id)
        {            
            var productImage = _productService.GetImage(p => p.Id == id);
            if (productImage != null)
            {
                _productService.MainImage(id, productImage.ProductId);
            }
            return RedirectToAction("Image", new { id = productImage.ProductId });
        }
    }
}
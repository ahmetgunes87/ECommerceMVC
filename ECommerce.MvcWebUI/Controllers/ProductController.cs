using ECommerce.Business.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.MvcWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public ActionResult Index()
        {
            var productList = _productService.GetList();
            return View(productList);

            //List<Product> products = new List<Product>();
            //string text = "ekran";
            //products = _productService.GetList(x => x.ProductName.ToLower().Contains(text.ToLower()));
            //return View(products);
        }
        public string Add()
        {
            _productService.Add(new Product
            {
                CategoryId = 1,
                BrandId = 1,
                ProductName = "Mouse",
                UnitPrice = 0,
                UnitsInStock = 0,
                IsActive = true
            });
            return "Eklendi";
        }
    }
}
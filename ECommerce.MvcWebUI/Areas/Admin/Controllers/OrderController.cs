using ECommerce.Business.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.MvcWebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.MvcWebUI.Areas.Admin.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IAddressService _addressService;
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        public OrderController(IOrderService orderService, IAddressService addressService, ICustomerService customerService, IProductService productService)
        {
            _orderService = orderService;
            _addressService = addressService;
            _customerService = customerService;
            _productService = productService;
        }

        public ActionResult Index()
        {
            var orderList = _orderService.GetListWithProductNameAndCustomerName();
            return View(orderList);
        }

        public ActionResult Form(int id)
        {
            if (id > 0)
            {
                var order = _orderService.Get(o => o.Id == id);
                if (order != null)
                {
                    ViewBag.Title = "Sipariş Güncelle";
                    OrderItem orderItem = new OrderItem()
                    {
                        ProductName = _productService.Get(p => p.Id == order.ProductId).ProductName,
                        CustomerFullName = _customerService.Get(c => c.Id == order.CustomerId).FirstName + " " + _customerService.Get(c => c.Id == order.CustomerId).LastName,
                        Order = order,
                        Addresses = _addressService.GetList(o => o.CustomerId == order.CustomerId).ToList(),
                        OrderStatuses = _orderService.GetOrderList().ToList()
                    };
                    return View("Form", orderItem);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(OrderItem orderItem)
        {
            var order = orderItem.Order;
            if (order != null)
            {
                try
                {
                    _orderService.Update(order);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = order.Id.ToString(), Message = " nolu sipariş bilgisi güncellendi...", LinkText = "Sipariş Listesi", Url = "/Admin/Order" };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("Form", new { id = order.Id });
            }
            return RedirectToAction("Index");
        }
    }
}
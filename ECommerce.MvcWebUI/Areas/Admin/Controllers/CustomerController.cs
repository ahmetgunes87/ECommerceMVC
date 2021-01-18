using ECommerce.Business.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using ECommerce.MvcWebUI.Areas.Admin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce.MvcWebUI.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly ICityService _cityService;
        private readonly IDistrictService _districtService;
        private readonly IAddressService _addressService;
        private readonly IOrderService _orderService;
        public CustomerController(ICustomerService customerService, ICityService cityService, IDistrictService districtService, IAddressService addressService, IOrderService orderService)
        {
            _customerService = customerService;
            _cityService = cityService;
            _districtService = districtService;
            _addressService = addressService;
            _orderService = orderService;
        }

        public ActionResult Index()
        {
            var customerList = _customerService.GetListWithCityName();
            return View(customerList);
        }

        public ActionResult Form()
        {
            ViewBag.Title = "Müşteri Ekle";
            CustomerItem customerItem = new CustomerItem()
            {
                Customer = null,
                Cities = _cityService.GetList(),
                Districts = _districtService.GetList(x => x.CityId == 0)
            };
            return View("Form", customerItem);
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                var customer = _customerService.Get(c => c.Id == id);
                if (customer != null)
                {
                    ViewBag.Title = "Müşteri Güncelle";
                    CustomerItem customerItem = new CustomerItem()
                    {
                        Customer = customer,
                        Cities = _cityService.GetList().OrderBy(x => customer.CityId).ToList(),
                        Districts = _districtService.GetList().Where(x => x.CityId == customer.CityId).OrderBy(x => customer.DistrictId).ToList()
                    };
                    return View("Form", customerItem);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(CustomerItem customerItem)
        {
            var customer = customerItem.Customer;

            if (customer.Id == 0)
            {
                ViewBag.Title = "Müşteri Ekle";
                try
                {
                    _customerService.Add(customer);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = customer.FirstName + " " + customer.LastName, Message = "ad soyadlı müşteri eklendi...", LinkText = "Müşteri Listesi", Url = "/Admin/Customer" };
                    ModelState.Clear();
                    return RedirectToAction("Form");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                    CustomerItem customerNew = new CustomerItem()
                    {
                        Customer = customerItem.Customer,
                        Cities = _cityService.GetList(x => x.Id == customer.CityId),
                        Districts = _districtService.GetList(x => x.Id == customer.DistrictId)
                    };
                    return View("Form", customerNew);
                }                
            }
            else
            {
                try
                {
                    _customerService.Update(customer);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = customer.FirstName + " " + customer.LastName, Message = "ad soyadlı müşteri güncellendi...", LinkText = "Müşteri Listesi", Url = "/Admin/Customer" };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("Update", new { id = customer.Id });
            }
        }

        public ActionResult Address(int id)
        {
            var customer = _customerService.Get(x => x.Id == id);
            if (customer != null)
            {
                var addressList = _addressService.GetListWithCityNameAndDistrictName(id);
                return View(addressList);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AddressForm(int id)
        {
            var customer = _customerService.Get(x => x.Id == id);
            if (customer != null)
            {
                ViewBag.Title = "Adres Ekle";
                CustomerAddressItem customerAddressItem = new CustomerAddressItem()
                {
                    Address = new Address { CustomerId = id },
                    Cities = _cityService.GetList(),
                    Districts = _districtService.GetList(x => x.CityId == 0)
                };
                return View("AddressForm", customerAddressItem);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateAddress(int id)
        {
            if (id > 0)
            {
                var customerAddress = _addressService.Get(c => c.Id == id);
                if (customerAddress != null)
                {
                    ViewBag.Title = "Adres Güncelle";
                    CustomerAddressItem customerAddressItem = new CustomerAddressItem()
                    {
                        Address = customerAddress,
                        Cities = _cityService.GetList().OrderBy(x => customerAddress.CityId).ToList(),
                        Districts = _districtService.GetList().Where(x => x.CityId == customerAddress.CityId).OrderBy(x => customerAddress.DistrictId).ToList()
                    };
                    return View("AddressForm", customerAddressItem);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddressForm(CustomerAddressItem customerAddressItem)
        {            
            var address = customerAddressItem.Address;

            if (address.Id == 0)
            {
                ViewBag.Title = "Adres Ekle";
                try
                {
                    _addressService.Add(address);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = address.AddressName, Message = "başlıklı adres eklendi...", LinkText = "Adres Listesi", Url = "/Admin/Customer/Address/" + address.CustomerId };
                    ModelState.Clear();
                    return RedirectToAction("AddressForm");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                    CustomerAddressItem customerAddressNew = new CustomerAddressItem()
                    {
                        Address = address,
                        Cities = _cityService.GetList(x => x.Id == address.CityId),
                        Districts = _districtService.GetList(x => x.Id == address.DistrictId)
                    };
                    return View("AddressForm", customerAddressNew);
                }
            }
            else
            {
                try
                {
                    _addressService.Update(address);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = address.AddressName, Message = "başlıklı adres güncellendi...", LinkText = "Adres Listesi", Url = "/Admin/Customer/Address/" + address.CustomerId };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("UpdateAddress", new { id = address.Id });
            }
        }

        public ActionResult Order(int id)
        {
            var customer = _customerService.Get(c => c.Id == id);
            if (customer != null)
            {
                var orderList = _orderService.GetListWithProductName(id);
                return View(orderList);
            }
            return RedirectToAction("Index");
        }

        public ActionResult UpdateOrder(int id)
        {
            if (id > 0)
            {
                var customerOrder = _orderService.Get(c => c.Id == id);
                if (customerOrder != null)
                {
                    ViewBag.Title = "Sipariş Güncelle";
                    CustomerOrderItem customerOrderItem = new CustomerOrderItem()
                    {
                        Order = customerOrder,
                        Addresses = _addressService.GetList(c => c.CustomerId == customerOrder.CustomerId).ToList(),
                        OrderStatuses = _orderService.GetOrderList().ToList()
                    };
                    return View("OrderForm", customerOrderItem);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult OrderForm(CustomerOrderItem customerOrderItem)
        {
            var order = customerOrderItem.Order;
            if (order != null)
            {
                try
                {
                    _orderService.Update(order);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = order.Id.ToString(), Message = " nolu sipariş bilgisi güncellendi...", LinkText = "Sipariş Listesi", Url = "/Admin/Customer/Order/" + order.CustomerId };
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("UpdateOrder", new { id = order.Id });
            }   
            return RedirectToAction("Order", new { id = order.CustomerId });
        }

        public JsonResult DistrictFill(int cityId)
        {
            var districts = _districtService.GetList(x => x.CityId == cityId);
            return Json(districts, JsonRequestBehavior.AllowGet);
        }
    }
}
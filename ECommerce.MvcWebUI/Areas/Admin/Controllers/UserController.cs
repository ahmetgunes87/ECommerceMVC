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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var userList = _userService.GetList();
            return View(userList);
        }

        public ActionResult Form()
        {
            ViewBag.Title = "Kullanıcı Ekle";
            return View("Form");
        }

        public ActionResult Update(int id)
        {
            if (id > 0)
            {
                var user = _userService.Get(u => u.Id == id);
                if (user != null)
                {
                    ViewBag.Title = "Kullanıcı Güncelle";
                    return View("Form", user);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Form(User user)
        {
            if (user.Id == 0)
            {
                ViewBag.Title = "Kullanıcı Ekle";
                try
                {
                    _userService.Add(user);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = user.UserName, Message = "adlı kullanıcı eklendi...", LinkText = "Kullanıcı Listesi", Url = "/Admin/User" };                    
                    ModelState.Clear();
                    return View("Form");
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                    return View("Form", user);
                }                
            }
            else
            {
                try
                {
                    _userService.Update(user);
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = user.UserName, Message = "adlı kullanıcı güncellendi...", LinkText = "Kullanıcı Listesi", Url = "/Admin/User" };                    
                }
                catch (Exception ex)
                {
                    TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Title = "", Message = ex.Message };
                }
                return RedirectToAction("Update", new { id = user.Id });
            }
        }

        public ActionResult Role(int id)
        {            
            if (id > 0)
            {
                var user = _userService.Get(u => u.Id == id);
                if (user != null)
                {
                    var userRoles = _userService.GetRoles(user);
                    return View(userRoles);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Role(List<UserRoleItem> roleItems, int id)
        {
            var items = roleItems.Where(p => p.IsExist).Select(r => r.RoleId).ToList();
            var user = _userService.Get(u => u.Id == id);
            if (items.Count > 0)
            {                 
                List<UserRole> userRoles = new List<UserRole>();
                for (int i = 0; i < items.Count; i++)
                {
                    userRoles.Add(new UserRole { RoleId = items[i], UserId = user.Id });
                }
                _userService.AddDeleteUserRolesTransaction(userRoles, user.Id);

                TempData["Message"] = new MessageViewModel() { CssClass = "alert-success", Title = user.UserName, Message = "adlı kullanıcının rolleri düzenlendi...", LinkText = "Kullanıcı Listesi", Url = "/Admin/User" };
            }
            else
            {
                TempData["Message"] = new MessageViewModel() { CssClass = "alert-danger", Message = "En az 1 adet rol seçimi yapmalısınız." };
            }
            return View("Role", roleItems);
        }
    }
}
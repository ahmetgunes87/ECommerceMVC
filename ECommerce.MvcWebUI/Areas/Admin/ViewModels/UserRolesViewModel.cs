using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ECommerce.MvcWebUI.Areas.Admin.ViewModels
{
    public class UserRolesViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public List<UserRoleItem> UserRoleItems { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.ComplexTypes
{
    public class UserRoleItem
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsExist { get; set; }
    }
}

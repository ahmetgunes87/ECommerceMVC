using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.ComplexTypes
{
    public class OrderItem
    {
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [Display(Name = "Müşteri Adı Soyadı")]
        public string CustomerFullName { get; set; }
        public Order Order { get; set; }
        public List<Address> Addresses { get; set; }
        public List<OrderStatus> OrderStatuses { get; set; }
        public string OrderStatus { get; set; }
    }
}

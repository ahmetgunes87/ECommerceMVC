using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.ComplexTypes
{
    public class CustomerOrderItem
    {
        public string ProductName { get; set; }
        public Order Order { get; set; }
        public List<Address> Addresses { get; set; }
        public List<OrderStatus> OrderStatuses { get; set; }
        public string OrderStatus { get; set; }
    }
}

using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class OrderStatus : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Sipariş Durumu")]
        public string Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}

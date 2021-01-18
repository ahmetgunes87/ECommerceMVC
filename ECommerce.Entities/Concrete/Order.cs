using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Müşteri")]
        public int CustomerId { get; set; }
        [Display(Name = "Ürün")]
        public int ProductId { get; set; }
        [Display(Name = "Sipariş Adresi")]
        public int AddressId { get; set; }
        [Display(Name = "Sipariş Durumu")]
        public int OrderStatusId { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Teslim Tarihi")]
        public DateTime? DeliveryDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        public virtual Address Address { get; set; }
        public virtual OrderStatus OrderStatus { get; set; }
    }
}

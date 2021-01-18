using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        [Display(Name = "Marka")]
        public int BrandId { get; set; }
        [Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Ürün Özellikleri")]
        public string ProductFeature { get; set; }
        [Display(Name = "Stok Miktarı")]
        [RegularExpression(@"[0-9]{0,6}$", ErrorMessage = "Girdiğiniz değer 0 ile 999999 arasında olmalıdır.")]
        public short UnitsInStock { get; set; }
        public bool IsActive { get; set; }

        public virtual Category Category { get; set; }
        public virtual Brand Brand { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }
    }
}

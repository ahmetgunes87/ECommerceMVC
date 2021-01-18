using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class ProductImage : IEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [Display(Name = "Ürün Resmi")]
        public string Image { get; set; }
        public bool IsMainImage { get; set; }

        public virtual Product Product { get; set; }
    }
}

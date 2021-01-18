using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.ComplexTypes
{
    public class ProductItem
    {
        public string MainImage { get; set; }
        public string CategoryName { get; set; }
        public Product Product { get; set; }
        public List<Category> Categories { get; set; }
        public List<Brand> Brands { get; set; }
    }
}

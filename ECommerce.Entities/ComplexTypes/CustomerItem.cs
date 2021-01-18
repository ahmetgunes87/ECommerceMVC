using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.ComplexTypes
{
    public class CustomerItem
    {
        public string CityName { get; set; }
        public Customer Customer { get; set; }
        public List<City> Cities { get; set; }
        public List<District> Districts { get; set; }
    }
}
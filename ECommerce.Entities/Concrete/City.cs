using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class City : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "Şehir Adı")]
        public string CityName { get; set; }

        public virtual ICollection<District> Districts { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}

using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class Address : IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        [Display(Name = "İl")]
        public int CityId { get; set; }
        [Display(Name = "İlçe")]
        public int DistrictId { get; set; }
        [Display(Name = "Adres Başlığı")]
        public string AddressName { get; set; }
        [Display(Name = "Adres")]
        public string AddressContent { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}

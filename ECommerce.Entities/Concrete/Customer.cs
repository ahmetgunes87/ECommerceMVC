using Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Entities.Concrete
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        [Display(Name = "İl")]
        public int CityId { get; set; }
        [Display(Name = "İlçe")]
        public int DistrictId { get; set; }
        [Display(Name = "TC Kimlik No")]
        public string IdentificationNumber { get; set; }
        [Display(Name = "Müşteri Adı")]
        public string FirstName { get; set; }
        [Display(Name = "Müşteri Soyadı")]
        public string LastName { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; }
        [Display(Name = "Parola")]
        public string Password { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Kayıt Tarihi")]
        public DateTime? DateOfRegistration { get; set; }

        public virtual City City { get; set; }
        public virtual District District { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Cart> Carts { get; set; }

    }
}

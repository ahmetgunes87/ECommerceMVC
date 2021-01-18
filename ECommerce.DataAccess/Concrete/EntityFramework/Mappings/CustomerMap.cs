using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable(@"Customers", @"dbo");
            HasKey(x => x.Id);            
            HasRequired(x => x.City).WithMany(x => x.Customers).HasForeignKey(x => x.CityId).WillCascadeOnDelete(false);
            HasRequired(x => x.District).WithMany(x => x.Customers).HasForeignKey(x => x.DistrictId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CityId).HasColumnName("CityId");
            Property(x => x.DistrictId).HasColumnName("DistrictId");
            Property(x => x.IdentificationNumber).HasColumnName("IdentificationNumber").HasMaxLength(11).HasColumnType("varchar");
            Property(x => x.FirstName).HasColumnName("FirstName").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.LastName).HasColumnName("LastName").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.DateOfBirth).HasColumnName("DateOfBirth");
            Property(x => x.Email).HasColumnName("Email").IsRequired().HasMaxLength(50).HasColumnType("varchar");
            Property(x => x.Password).HasColumnName("Password").IsRequired().HasMaxLength(30).HasColumnType("varchar");
            Property(x => x.Phone).HasColumnName("Phone").HasMaxLength(30).HasColumnType("varchar");
            Property(x => x.Address).HasColumnName("Address").IsRequired();
            Property(x => x.DateOfRegistration).HasColumnName("DateOfRegistration");
        }
    }
}

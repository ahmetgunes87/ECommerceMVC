using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class AddressMap : EntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            ToTable(@"Addresses", @"dbo");
            HasKey(x => x.Id);
            HasRequired(x => x.Customer).WithMany(x => x.Addresses).HasForeignKey(x => x.CustomerId).WillCascadeOnDelete(false);
            HasRequired(x => x.City).WithMany(x => x.Addresses).HasForeignKey(x => x.CityId).WillCascadeOnDelete(false);
            HasRequired(x => x.District).WithMany(x => x.Addresses).HasForeignKey(x => x.DistrictId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CustomerId).HasColumnName("CustomerId");
            Property(x => x.CityId).HasColumnName("CityId");
            Property(x => x.DistrictId).HasColumnName("DistrictId");
            Property(x => x.AddressName).HasColumnName("AddressName").IsRequired().HasMaxLength(50).HasColumnType("varchar");            
            Property(x => x.AddressContent).HasColumnName("AddressContent").IsRequired();
        }
    }
}

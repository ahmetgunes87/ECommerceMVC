using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class DistrictMap : EntityTypeConfiguration<District>
    {
        public DistrictMap()
        {
            ToTable(@"Districts", @"dbo");
            HasKey(x => x.Id);
            HasRequired(x => x.City).WithMany(x => x.Districts).HasForeignKey(x => x.CityId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CityId).HasColumnName("CityId");
            Property(x => x.DistrictName).HasColumnName("DistrictName").IsRequired().HasMaxLength(100).HasColumnType("varchar");
        }
    }
}

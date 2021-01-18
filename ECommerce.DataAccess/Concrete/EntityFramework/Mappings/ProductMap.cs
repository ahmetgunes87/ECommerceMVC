using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable(@"Products", @"dbo");
            HasKey(x => x.Id);
            HasRequired(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId).WillCascadeOnDelete(false);
            HasRequired(x => x.Brand).WithMany(x => x.Products).HasForeignKey(x => x.BrandId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CategoryId).HasColumnName("CategoryId");
            Property(x => x.BrandId).HasColumnName("BrandId");
            Property(x => x.ProductName).HasColumnName("ProductName").IsRequired().HasMaxLength(250).HasColumnType("varchar");
            Property(x => x.UnitPrice).HasColumnName("UnitPrice").IsRequired();
            Property(x => x.ProductFeature).HasColumnName("ProductFeature");
            Property(x => x.UnitsInStock).HasColumnName("UnitsInStock").IsRequired();
            Property(x => x.IsActive).HasColumnName("IsActive").IsRequired();
        }
    }
}

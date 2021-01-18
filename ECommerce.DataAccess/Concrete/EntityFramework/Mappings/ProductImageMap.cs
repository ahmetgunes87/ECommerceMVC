using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class ProductImageMap : EntityTypeConfiguration<ProductImage>
    {
        public ProductImageMap()
        {
            ToTable(@"ProductImages", @"dbo");
            HasKey(x => x.Id);
            HasRequired(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.ProductId).HasColumnName("ProductId");
            Property(x => x.Image).HasColumnName("Image").IsRequired().HasMaxLength(250).HasColumnType("varchar");
            Property(x => x.IsMainImage).HasColumnName("IsMainImage").IsRequired();
        }
    }
}

using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class CartMap : EntityTypeConfiguration<Cart>
    {
        public CartMap()
        {
            ToTable(@"Carts", @"dbo");
            HasKey(x => x.Id);
            HasRequired(x => x.Customer).WithMany(x => x.Carts).HasForeignKey(x => x.CustomerId).WillCascadeOnDelete(false);
            HasRequired(x => x.Product).WithMany(x => x.Carts).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CustomerId).HasColumnName("CustomerId");
            Property(x => x.ProductId).HasColumnName("ProductId");
        }
    }
}

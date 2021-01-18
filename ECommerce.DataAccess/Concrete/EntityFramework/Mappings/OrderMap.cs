using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable(@"Orders", @"dbo");
            HasKey(x => x.Id);
            HasRequired(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId).WillCascadeOnDelete(false);
            HasRequired(x => x.Product).WithMany(x => x.Orders).HasForeignKey(x => x.ProductId).WillCascadeOnDelete(false);
            HasRequired(x => x.Address).WithMany(x => x.Orders).HasForeignKey(x => x.AddressId).WillCascadeOnDelete(false);
            HasRequired(x => x.OrderStatus).WithMany(x => x.Orders).HasForeignKey(x => x.OrderStatusId).WillCascadeOnDelete(false);

            Property(x => x.Id).HasColumnName("Id");
            Property(x => x.CustomerId).HasColumnName("CustomerId");
            Property(x => x.ProductId).HasColumnName("ProductId");
            Property(x => x.AddressId).HasColumnName("AddressId");
            Property(x => x.OrderStatusId).HasColumnName("OrderStatusId");
            Property(x => x.OrderDate).HasColumnName("OrderDate").IsRequired();
            Property(x => x.DeliveryDate).HasColumnName("DeliveryDate");
        }
    }
}

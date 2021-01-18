using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, ECommerceDbContext>, IOrderDal
    {
        public List<CustomerOrderItem> GetListWithProductName(int customerId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from o in context.Orders
                              join p in context.Products
                              on o.ProductId equals p.Id
                              where o.CustomerId == customerId
                              select new CustomerOrderItem
                              {
                                  ProductName = p.ProductName,
                                  Order = o,
                                  OrderStatus = o.OrderStatus.Status
                              }).ToList();
                return result;
            }
        }

        public List<OrderItem> GetListWithProductNameAndCustomerName()
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from o in context.Orders
                              join p in context.Products
                              on o.ProductId equals p.Id
                              join c in context.Customers
                              on o.CustomerId equals c.Id
                              orderby o.Id descending
                              select new OrderItem
                              {
                                  ProductName = p.ProductName,
                                  CustomerFullName = c.FirstName + " " + c.LastName,
                                  Order = o,
                                  OrderStatus = o.OrderStatus.Status
                              }).ToList();
                return result;
            }
        }

        public List<OrderStatus> GetOrderList()
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                return context.OrderStatuses.ToList();
            }
        }
    }
}

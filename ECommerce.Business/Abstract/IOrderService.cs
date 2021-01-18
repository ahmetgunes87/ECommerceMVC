using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IOrderService
    {
        Order Get(Expression<Func<Order, bool>> filter);
        List<Order> GetList(Expression<Func<Order, bool>> filter = null);
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        List<CustomerOrderItem> GetListWithProductName(int customerId);
        List<OrderStatus> GetOrderList();
        List<OrderItem> GetListWithProductNameAndCustomerName();
    }
}

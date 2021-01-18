using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public void Add(Order order)
        {
            _orderDal.Add(order);
        }

        public void Delete(Order order)
        {
            _orderDal.Delete(order);
        }

        public Order Get(Expression<Func<Order, bool>> filter)
        {
            return _orderDal.Get(filter);
        }

        public List<Order> GetList(Expression<Func<Order, bool>> filter = null)
        {
            return _orderDal.GetList(filter).ToList();
        }

        public List<CustomerOrderItem> GetListWithProductName(int customerId)
        {
            return _orderDal.GetListWithProductName(customerId);
        }

        public List<OrderItem> GetListWithProductNameAndCustomerName()
        {
            return _orderDal.GetListWithProductNameAndCustomerName();
        }

        public List<OrderStatus> GetOrderList()
        {
            return _orderDal.GetOrderList();
        }

        public void Update(Order order)
        {
            _orderDal.Update(order);
        }
    }
}

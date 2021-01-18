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
    public interface ICustomerService
    {
        Customer Get(Expression<Func<Customer, bool>> filter);
        List<Customer> GetList(Expression<Func<Customer, bool>> filter = null);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Customer GetByEmailAndPassword(string email, string password);
        List<CustomerItem> GetListWithCityName();
    }
}

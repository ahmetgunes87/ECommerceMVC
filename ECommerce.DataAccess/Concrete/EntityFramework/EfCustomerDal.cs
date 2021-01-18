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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ECommerceDbContext>, ICustomerDal
    {
        public List<CustomerItem> GetListWithCityName()
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from cu in context.Customers
                              join c in context.Cities
                              on cu.CityId equals c.Id
                              select new CustomerItem
                              {
                                  CityName = c.CityName,
                                  Customer = cu
                              }).ToList();
                return result;
            }
        }
    }
}

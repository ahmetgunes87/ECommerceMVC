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
    public class EfAddressDal : EfEntityRepositoryBase<Address, ECommerceDbContext>, IAddressDal
    {
        public List<CustomerAddressItem> GetListWithCityNameAndDistrictName(int customerId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from a in context.Addresses
                              join c in context.Cities
                              on a.CityId equals c.Id
                              join d in context.Districts
                              on a.DistrictId equals d.Id
                              where a.CustomerId == customerId
                              select new CustomerAddressItem
                              {
                                  Address = a,
                                  CityName = c.CityName,
                                  DistrictName = d.DistrictName
                              }).ToList();
                return result;
            }
        }
    }
}

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
    public interface IAddressService
    {
        Address Get(Expression<Func<Address, bool>> filter);
        List<Address> GetList(Expression<Func<Address, bool>> filter = null);
        void Add(Address address);
        void Update(Address address);
        void Delete(Address address);
        List<CustomerAddressItem> GetListWithCityNameAndDistrictName(int customerId);
    }
}

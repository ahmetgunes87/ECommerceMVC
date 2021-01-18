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
    public class AddressManager : IAddressService
    {
        private readonly IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }
        public void Add(Address address)
        {
            _addressDal.Add(address);
        }

        public void Delete(Address address)
        {
            _addressDal.Delete(address);
        }

        public Address Get(Expression<Func<Address, bool>> filter)
        {
            return _addressDal.Get(filter);
        }

        public List<Address> GetList(Expression<Func<Address, bool>> filter = null)
        {
            return _addressDal.GetList(filter).ToList();
        }

        public List<CustomerAddressItem> GetListWithCityNameAndDistrictName(int customerId)
        {
            return _addressDal.GetListWithCityNameAndDistrictName(customerId);
        }

        public void Update(Address address)
        {
            _addressDal.Update(address);
        }
    }
}

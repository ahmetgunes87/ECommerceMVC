using ECommerce.Business.Abstract;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class CityManager : ICityService
    {
        private readonly ICityDal _cityDal;
        public CityManager(ICityDal cityDal)
        {
            _cityDal = cityDal;
        }
        public City Get(Expression<Func<City, bool>> filter)
        {
            return _cityDal.Get(filter);
        }

        public List<City> GetList(Expression<Func<City, bool>> filter = null)
        {
            return _cityDal.GetList(filter).ToList();
        }
    }
}

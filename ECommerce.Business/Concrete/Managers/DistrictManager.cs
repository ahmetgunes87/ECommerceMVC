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
    public class DistrictManager : IDistrictService
    {
        private readonly IDistrictDal _districtDal;
        public DistrictManager(IDistrictDal districtDal)
        {
            _districtDal = districtDal;
        }

        public District Get(Expression<Func<District, bool>> filter)
        {
            return _districtDal.Get(filter);
        }

        public List<District> GetList(Expression<Func<District, bool>> filter = null)
        {
            return _districtDal.GetList(filter).ToList();
        }
    }
}

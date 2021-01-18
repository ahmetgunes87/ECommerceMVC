using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface ICityService
    {
        City Get(Expression<Func<City, bool>> filter);
        List<City> GetList(Expression<Func<City, bool>> filter = null);
    }
}

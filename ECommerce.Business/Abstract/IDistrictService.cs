using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IDistrictService
    {
        District Get(Expression<Func<District, bool>> filter);
        List<District> GetList(Expression<Func<District, bool>> filter = null);
    }
}

using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Abstract
{
    public interface IBrandService
    {
        Brand Get(Expression<Func<Brand, bool>> filter);
        List<Brand> GetList(Expression<Func<Brand, bool>> filter = null);
        void Add(Brand brand);
        void Update(Brand brand);
        void Delete(Brand brand);
    }
}

using ECommerce.Business.Abstract;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.Concrete;
using Framework.Aspects.Postsharp.CacheAspects;
using Framework.Aspects.Postsharp.ValidationAspects;
using Framework.CrossCuttingConcerns.Caching.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(BrandValidator))]
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            return _brandDal.Get(filter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Brand> GetList(Expression<Func<Brand, bool>> filter = null)
        {
            return _brandDal.GetList(filter).ToList();
        }

        [FluentValidationAspect(typeof(BrandValidator))]
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}

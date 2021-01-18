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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(CategoryValidator))]
        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(Category category)
        {
            _categoryDal.Delete(category);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public Category Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public List<Category> GetList(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetList(filter).ToList();
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}

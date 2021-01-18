using ECommerce.Business.Abstract;
using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.Aspects.Postsharp.AuthorizationAspects;
using Framework.Aspects.Postsharp.CacheAspects;
using Framework.Aspects.Postsharp.LogAspects;
using Framework.Aspects.Postsharp.PerformanceAspects;
using Framework.Aspects.Postsharp.TransactionAspects;
using Framework.Aspects.Postsharp.ValidationAspects;
using Framework.CrossCuttingConcerns.Caching.Microsoft;
using Framework.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ECommerce.Business.Concrete.Managers
{
    //[LogAspect(typeof(DatabaseLogger))]
    //[LogAspect(typeof(FileLogger))]
    public class ProductManager : IProductService
    {
        private readonly IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        [FluentValidationAspect(typeof(ProductValidator))]
        public void Add(Product product)
        {
            _productDal.Add(product);
        }

        public void AddImage(List<ProductImage> productImages)
        {
            _productDal.AddImage(productImages);
        }

        public void Delete(Product product)
        {
            _productDal.Delete(product);
        }

        public void DeleteById(int id)
        {
            var product = Get(p => p.Id == id);
            _productDal.Delete(product);
        }

        public void DeleteImage(int id)
        {
            _productDal.DeleteImage(id);
        }

        public void DeleteImagesbyProductId(int productId)
        {
            _productDal.DeleteImagesbyProductId(productId);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        public Product Get(Expression<Func<Product, bool>> filter)
        {
            return _productDal.Get(filter);
        }

        public ProductImage GetImage(Expression<Func<ProductImage, bool>> filter)
        {
            return _productDal.GetImage(filter);
        }

        //[PerformanceCounterAspect(typeof(DatabaseLogger), 2)]
        [CacheAspect(typeof(MemoryCacheManager))]  
        //[SecuredOperation(Roles = "Admin")]
        public List<Product> GetList(Expression<Func<Product, bool>> filter = null)
        {
            //PerformanceCounterAspect deneme amaçlı yazıldı.
            //Thread.Sleep(3000);
            return _productDal.GetList(filter).ToList();
        }

        public List<ProductImage> GetListProductImages(int productId)
        {
            return _productDal.GetListProductImages(productId);
        }

        public List<ProductItem> GetListWithCategoryName()
        {
            return _productDal.GetListWithCategoryName();
        }

        public void MainImage(int id, int productId)
        {
            _productDal.MainImage(id, productId);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public void Update(Product product)
        {
            _productDal.Update(product);
        }      
    }
}

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
    public interface IProductService
    {
        Product Get(Expression<Func<Product, bool>> filter);
        List<Product> GetList(Expression<Func<Product, bool>> filter = null);
        void Add(Product product);
        void Update(Product product);
        void DeleteById(int id);
        void Delete(Product product);
        List<ProductItem> GetListWithCategoryName();
        List<ProductImage> GetListProductImages(int productId);
        ProductImage GetImage(Expression<Func<ProductImage, bool>> filter);
        void AddImage(List<ProductImage> productImages);
        void DeleteImage(int id);
        void DeleteImagesbyProductId(int productId);
        void MainImage(int id, int productId);
    }
}

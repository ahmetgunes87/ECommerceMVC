using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductItem> GetListWithCategoryName();
        List<ProductImage> GetListProductImages(int productId);
        ProductImage GetImage(Expression<Func<ProductImage, bool>> filter);
        void AddImage(List<ProductImage> productImages);
        void DeleteImage(int id);
        void DeleteImagesbyProductId(int productId);
        void MainImage(int id, int productId);
    }
}

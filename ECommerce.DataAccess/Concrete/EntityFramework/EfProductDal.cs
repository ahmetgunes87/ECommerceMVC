using ECommerce.DataAccess.Abstract;
using ECommerce.Entities.ComplexTypes;
using ECommerce.Entities.Concrete;
using Framework.DataAccess.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, ECommerceDbContext>, IProductDal
    {
        public List<ProductItem> GetListWithCategoryName()
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = (from p in context.Products
                              join c in context.Categories
                              on p.CategoryId equals c.Id
                              select new ProductItem
                              {
                                  CategoryName = c.CategoryName,
                                  Product = p,
                                  MainImage = context.ProductImages.Where(x => x.ProductId == p.Id && x.IsMainImage).Select(x => x.Image).FirstOrDefault()
                              }).ToList();
                return result;
            }
        }
        public List<ProductImage> GetListProductImages(int productId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = context.ProductImages.Include("Product").Where(p => p.ProductId == productId).OrderByDescending(p => p.IsMainImage).ThenBy(p => p.Id).ToList();
                return result;
            }
        }
        public void AddImage(List<ProductImage> productImages)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                context.ProductImages.AddRange(productImages);
                context.SaveChanges();
            }
        }

        public void DeleteImage(int id)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var entity = context.ProductImages.Where(p => p.Id == id).SingleOrDefault();
                context.ProductImages.Remove(entity);
                context.SaveChanges();
            }
        }

        public void DeleteImagesbyProductId(int productId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var entity = context.ProductImages.Where(p => p.ProductId == productId).ToList();
                context.ProductImages.RemoveRange(entity);
                context.SaveChanges();
            }
        }

        public ProductImage GetImage(Expression<Func<ProductImage, bool>> filter)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                return context.ProductImages.SingleOrDefault(filter);
            }
        }

        public void MainImage(int id, int productId)
        {
            using (ECommerceDbContext context = new ECommerceDbContext())
            {
                var result = context.ProductImages.Where(p => p.ProductId == productId).ToList();
                result.ForEach(p => p.IsMainImage = false);
                var result2 = context.ProductImages.Where(p => p.Id == id).SingleOrDefault();
                result2.IsMainImage = true;
                context.SaveChanges();
            }
        }
    }
}

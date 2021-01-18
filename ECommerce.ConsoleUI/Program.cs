using ECommerce.Business.Abstract;
using ECommerce.Business.DependencyResolvers.Ninject;
using ECommerce.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var productService = InstanceFactory.GetInstance<IProductService>();
            productService.Add(new Product
            {
                ProductName = "Bilgisayar",
                BrandId = 1,
                UnitPrice = 0,
                UnitsInStock = 0,
                IsActive = true
            });
            Console.WriteLine("Eklendi");
            Console.ReadLine();
        }
    }
}

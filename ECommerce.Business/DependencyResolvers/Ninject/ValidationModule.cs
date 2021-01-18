using ECommerce.Business.ValidationRules.FluentValidation;
using ECommerce.Entities.Concrete;
using FluentValidation;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.DependencyResolvers.Ninject
{
    public class ValidationModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidator<Address>>().To<AddressValidator>().InSingletonScope();
            Bind<IValidator<Brand>>().To<BrandValidator>().InSingletonScope();
            Bind<IValidator<Category>>().To<CategoryValidator>().InSingletonScope();
            Bind<IValidator<Customer>>().To<CustomerValidator>().InSingletonScope();
            Bind<IValidator<Order>>().To<OrderValidator>().InSingletonScope();
            Bind<IValidator<Product>>().To<ProductValidator>().InSingletonScope();
            Bind<IValidator<User>>().To<UserValidator>().InSingletonScope();
        }
    }
}

using ECommerce.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.CategoryId).NotEmpty().WithMessage("'Kategori' Seçiniz.");
            RuleFor(p => p.BrandId).NotEmpty().WithMessage("'Marka' Seçiniz.");
            RuleFor(p => p.ProductName).NotEmpty().Length(2, 250);
            RuleFor(p => p.UnitPrice).GreaterThan(0);
            RuleFor(p => p.UnitsInStock).GreaterThanOrEqualTo((short)0);
        }
    }
}

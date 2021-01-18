using ECommerce.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class CustomerValidator : AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            RuleFor(p => p.CityId).NotEmpty().WithMessage("'İl' Seçiniz.");
            RuleFor(p => p.DistrictId).NotEmpty().WithMessage("'İlçe' Seçiniz.");
            RuleFor(p => p.IdentificationNumber).Length(11);
            RuleFor(p => p.FirstName).NotEmpty().Length(2, 50);
            RuleFor(p => p.LastName).NotEmpty().Length(2, 50);
            RuleFor(p => p.Email).NotEmpty().Length(5, 50).EmailAddress();
            RuleFor(p => p.Password).NotEmpty().Length(6, 30);
            RuleFor(p => p.Address).NotEmpty().MinimumLength(5);
            RuleFor(p => p.DateOfBirth).LessThan(DateTime.Today);
        }
    }
}

using ECommerce.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty().WithMessage("Müşteri bulunamadı.");
            RuleFor(p => p.CityId).NotEmpty().WithMessage("'İl' Seçiniz."); ;
            RuleFor(p => p.DistrictId).NotEmpty().WithMessage("'İlçe' Seçiniz."); ;
            RuleFor(p => p.AddressName).NotEmpty().Length(2, 250);
            RuleFor(p => p.AddressContent).NotEmpty().MinimumLength(10);
        }
    }
}
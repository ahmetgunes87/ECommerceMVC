using ECommerce.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(p => p.CustomerId).NotEmpty();
            RuleFor(p => p.ProductId).NotEmpty();
            RuleFor(p => p.AddressId).NotEmpty().WithMessage("'Adres' Seçiniz.");
            RuleFor(p => p.OrderStatusId).NotEmpty().WithMessage("'Sipariş Durumu' Seçiniz.");
        }
    }
}

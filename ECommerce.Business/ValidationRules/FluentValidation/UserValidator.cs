using ECommerce.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.UserName).NotEmpty().Length(3, 50);
            RuleFor(p => p.FirstName).NotEmpty().Length(2, 50);
            RuleFor(p => p.LastName).NotEmpty().Length(2, 50);
            RuleFor(p => p.Email).NotEmpty().Length(5, 50).EmailAddress(); ;
            RuleFor(p => p.Password).NotEmpty().Length(6, 30); ;
        }
    }
}

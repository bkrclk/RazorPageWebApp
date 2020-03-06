using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPageWebApp.Models.Validations
{
    public class UserValidator : AbstractValidator<UserModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Username not empty")
            .Length(4, 50).WithMessage("Username min 4 max 50 characters");

            RuleFor(x => x.Password).NotEmpty().WithMessage("Password not empty")
           .Length(8, 100).WithMessage("Password min 8 characters");

            RuleFor(x => x.Email).EmailAddress().WithMessage("Please valid email adress.")
            .When(x => !string.IsNullOrEmpty(x.Email));
        }
    }
}

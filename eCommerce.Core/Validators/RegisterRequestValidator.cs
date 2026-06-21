using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;
public class RegisterRequestValidator:AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        RuleFor(x=>x.PersonName).NotEmpty().WithMessage("Person name cant be blank.")
            .MaximumLength(100).WithMessage("Person name must be less than 100 characters.");
        RuleFor(x => x.Gender).NotEmpty().WithMessage("Gender is required..");
    }
}


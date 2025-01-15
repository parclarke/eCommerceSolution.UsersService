using eCommerce.Core.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        //string? Email, string? Password, string? PersonName, GenderOptions Gender
        //Email
        RuleFor(temp => temp.Email).NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email address format");

        //Password
        RuleFor(temp => temp.Password).NotEmpty().WithMessage("Password is required");

        //PersonName
        RuleFor(temp => temp.PersonName).NotEmpty().WithMessage("PersonName is required");

        RuleFor(temp => temp.Gender).IsInEnum().WithMessage("Gender must be Male, Female or Other");

    }
}

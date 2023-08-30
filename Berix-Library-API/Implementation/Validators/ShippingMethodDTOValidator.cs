using Application.DTOs.ShippingMethods;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class ShippingMethodDTOValidator : AbstractValidator<ShippingMethodDTO>
    {
        public ShippingMethodDTOValidator()
        {
            RuleFor(x=> x.Name)
                .NotEmpty()
                .WithMessage("ShippingMethod name must not be empty")
                .MaximumLength(50)
                .WithMessage("ShippingMethod name must not be greater then 50 characters.");
            RuleFor(x=> x.Cost)
                .NotEmpty()
                .WithMessage("ShippingMethod cost must not be empty");
        }
    }
}

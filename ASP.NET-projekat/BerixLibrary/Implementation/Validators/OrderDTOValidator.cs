using Application.DTOs.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class OrderDTOValidator : AbstractValidator<OrderDTO>
    {
        public OrderDTOValidator()
        {
            RuleFor(x => x.Customer)
                .NotEmpty()
                .WithMessage("Order Customer must not be empty.");
            RuleFor(x => x.ShippingMethod)
                .NotEmpty()
                .WithMessage("Order ShippingMethod must not be empty.");
        }
    }
}
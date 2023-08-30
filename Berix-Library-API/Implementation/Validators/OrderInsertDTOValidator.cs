using Application.DTOs.Orders;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class OrderInsertDTOValidator: AbstractValidator<OrderInsertDTO>
    {
        public OrderInsertDTOValidator()
        {
            RuleFor(x=>x.OrderInvoices)
                .NotEmpty()
                .WithMessage("There is no item contained in this bill");
            RuleFor(x => x.ShippingMethodId)
                .NotEmpty()
                .WithMessage("No shipping method has been selected");
            RuleFor(x => x.CustomerId)
                .NotEmpty()
                .WithMessage("Customer is not selected");
        }
    }
}

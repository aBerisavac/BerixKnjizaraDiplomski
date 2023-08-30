using Application.Commands.Orders;
using Application.DTOs.Orders;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Orders
{
    public class EfUpdateOrder : IEditOrderCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly OrderDTOValidator _validator;

        public int Id => 27;

        public string Name => "Update Order";

        public EfUpdateOrder(IMapper mapper, DBKnjizaraContext dbContext, OrderDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(OrderDTO request)
        {
            var order = _dbContext.Orders.Find(request.Id);

            if (order == null)
            {
                throw new EntityNotFoundException(Id, typeof(Order));
            }

            /*
        virtual public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
             */

            _validator.ValidateAndThrow(request);

            order.Customer = _mapper.Map<User>(request.Customer);
            order.CustomerId = request.Customer.Id;
            order.ShippingMethod = _mapper.Map<ShippingMethod>(request.ShippingMethod);
            order.ShippingMethodId = request.ShippingMethod.Id;

            _dbContext.SaveChanges();
        }
    }
}

using Application.Commands.Orders;
using Application.DTOs.Orders;
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
    public class EfCreateOrder : IAddOrderCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly OrderInsertDTOValidator _validator;

        public int Id => 25;

        public string Name => "Create Order";

        public EfCreateOrder(IMapper mapper, DBKnjizaraContext dbContext, OrderInsertDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(OrderInsertDTO request)
        {
            var order = _mapper.Map<Order>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(order);
            _dbContext.SaveChanges();
        }
    }
}

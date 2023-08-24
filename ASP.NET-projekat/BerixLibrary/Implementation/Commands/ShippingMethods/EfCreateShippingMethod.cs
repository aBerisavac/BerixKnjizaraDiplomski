using Application.Commands.ShippingMethods;
using Application.DTOs.ShippingMethods;
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

namespace Implementation.Commands.ShippingMethods
{
    public class EfCreateShippingMethod : IAddShippingMethodCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly ShippingMethodDTOValidator _validator;
        public int Id => 4;

        public string Name => "Create ShippingMethod";

        public EfCreateShippingMethod(IMapper mapper, DBKnjizaraContext dbContext, ShippingMethodDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(ShippingMethodDTO request)
        {

            var shippingMethod = _mapper.Map<ShippingMethod>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(shippingMethod);
            _dbContext.SaveChanges();
        }
    }
}

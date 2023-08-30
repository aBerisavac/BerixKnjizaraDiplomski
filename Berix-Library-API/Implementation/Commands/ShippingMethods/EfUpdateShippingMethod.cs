using Application.Commands.ShippingMethods;
using Application.DTOs.ShippingMethods;
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

namespace Implementation.Commands.ShippingMethods
{
    public class EfUpdateShippingMethod : IEditShippingMethodCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly ShippingMethodDTOValidator _validator;
        public int Id => 6;

        public string Name => "Update ShippingMethod";

        public EfUpdateShippingMethod(IMapper mapper, DBKnjizaraContext dbContext, ShippingMethodDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(ShippingMethodDTO request)
        {
            var shippingMethod = _dbContext.ShippingMethods.Find(request.Id);

            if (shippingMethod == null)
            {
                throw new EntityNotFoundException(Id, typeof(ShippingMethod));
            }

            /*
                virtual public ICollection<Order>? Orders { get; set; } = new List<Order>();
             */

            _validator.ValidateAndThrow(request);

            shippingMethod.Name = request.Name;
            shippingMethod.Cost = request.Cost;

            _dbContext.SaveChanges();
        }
    }
}

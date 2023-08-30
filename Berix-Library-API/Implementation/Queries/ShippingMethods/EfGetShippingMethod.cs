using Application.DTOs.ShippingMethods;
using Application.Exceptions;
using Application.Queries.ShippingMethods;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ShippingMethods
{
    public class EfGetShippingMethod : IGetShippingMethodQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 31;

        public string Name => "Get ShippingMethod";

        public EfGetShippingMethod(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public ShippingMethodDTO Execute(int id)
        {
            var shippingMethod = _dbContext.ShippingMethods.Find(id);

            if (shippingMethod == null)
            {
                throw new EntityNotFoundException(id, typeof(ShippingMethod));
            }

            var response = _mapper.Map<ShippingMethodDTO>(shippingMethod);

            return response;
        }
    }
}

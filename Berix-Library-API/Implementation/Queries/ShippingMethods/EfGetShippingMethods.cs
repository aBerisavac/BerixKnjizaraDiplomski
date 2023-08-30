using Application.DTOs.ShippingMethods;
using Application.DTOs.UseCases;
using Application.Queries.ShippingMethods;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.ShippingMethods
{
    public class EfGetShippingMethods : IGetShippingMethodsQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 30;

        public string Name => "Get ShippingMethods";

        public EfGetShippingMethods(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this._mapper = mapper;
        }

        public IEnumerable<ShippingMethodDTO> Execute(string searchTerm)
        {
            var query = _dbContext.ShippingMethods.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Contains(searchTerm));
            }
            else
            {

            }

            return query.Select(x => _mapper.Map<ShippingMethodDTO>(x));
        }
    }
}

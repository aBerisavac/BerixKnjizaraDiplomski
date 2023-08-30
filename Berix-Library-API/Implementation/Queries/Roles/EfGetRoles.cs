using Application.DTOs.Roles;
using Application.DTOs.ShippingMethods;
using Application.Queries.Roles;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Roles
{
    public class EfGetRoles : IGetRolesQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 32;

        public string Name => "Get Roles";

        public EfGetRoles(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<RoleDTO> Execute(string searchTerm)
        {
            var query = _dbContext.Roles.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Contains(searchTerm));
            }
            else
            {

            }

            return query.Select(x => _mapper.Map<RoleDTO>(x));
        }
    }
}

using Application.DTOs.Roles;
using Application.DTOs.ShippingMethods;
using Application.Exceptions;
using Application.Queries.Roles;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Roles
{
    public class EfGetRole : IGetRoleQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 33;

        public string Name => "Get Role";

        public EfGetRole(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public RoleDTO Execute(int id)
        {
            var role = _dbContext.Roles.Find(id);

            if (role == null)
            {
                throw new EntityNotFoundException(id, typeof(Role));
            }

            var response = _mapper.Map<RoleDTO>(role);

            return response;
        }
    }
}

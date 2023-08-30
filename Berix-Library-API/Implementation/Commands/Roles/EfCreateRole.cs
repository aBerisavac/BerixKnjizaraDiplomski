using Application.Commands.Roles;
using Application.DTOs.Roles;
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

namespace Implementation.Commands.Roles
{
    public class EfCreateRole : IAddRoleCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly RoleDTOValidator _validator;
        public int Id => 7;

        public string Name => "Create Role";

        public EfCreateRole(IMapper mapper, DBKnjizaraContext dbContext, RoleDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(RoleDTO request)
        {
            var role = _mapper.Map<Role>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(role);
            _dbContext.SaveChanges();
        }
    }
}

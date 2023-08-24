using Application.Commands.Roles;
using Application.DTOs.Roles;
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

namespace Implementation.Commands.Roles
{
    public class EfUpdateRole : IEditRoleCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly RoleDTOValidator _validator;
        public int Id => 9;

        public string Name => "Update Role";

        public EfUpdateRole(IMapper mapper, DBKnjizaraContext dbContext, RoleDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(RoleDTO request)
        {
            var role = _dbContext.Roles.Find(request.Id);

            if (role == null)
            {
                throw new EntityNotFoundException(Id, typeof(ShippingMethod));
            }

            /*
        virtual public ICollection<User>? Users { get; set; } = new List<User>();
        virtual public ICollection<RoleUseCase>? UseCases { get; set; } = new List<RoleUseCase>();
             */

            _validator.ValidateAndThrow(request);

            role.Name = request.Name;

            _dbContext.SaveChanges();
        }
    }
}

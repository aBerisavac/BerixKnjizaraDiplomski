using Application.DTOs.Roles;
using EFDataAccess;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class RoleDTOValidator: AbstractValidator<RoleDTO>
    {
        public RoleDTOValidator(DBKnjizaraContext dbContext)
        {
            RuleFor(x=>x.Name)
                .NotEmpty()
                .WithMessage("Role name must not be empty.")
                .MaximumLength(30)
                .WithMessage("Role name must not be greater then 30 characters.")
                .Must(name => !dbContext.Roles.Any(y => y.Name == name))
                .WithMessage("Role name must be unique");
        }
    }
}

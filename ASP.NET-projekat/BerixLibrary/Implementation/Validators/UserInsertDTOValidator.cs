using Application.DTOs.Users;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UserInsertDTOValidator : AbstractValidator<UserInsertDTO>
    {
        public UserInsertDTOValidator(DBKnjizaraContext dbContext)
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("User FirstName must not be empty.")
                .MaximumLength(50)
                .WithMessage("User FirstName must not be greater then 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("User LastName must not be empty.")
                .MaximumLength(50)
                .WithMessage("User LastName must not be greater then 50 characters.");
            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("User Email must not be empty.")
                .MaximumLength(50)
                .WithMessage("User Email must not be greater then 50 characters.")
                .Must(email => !dbContext.Users.Any(y => y.Email == email))
                .WithMessage("User Email must be unique");
            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("User Password must not be empty.")
                .MaximumLength(1000)
                .WithMessage("User Password must not be greater then 1000 characters.");
            RuleFor(x => x.Address)
                .NotEmpty()
                .WithMessage("User Address must not be empty.")
                .MaximumLength(50)
                .WithMessage("User Address must not be greater then 50 characters.");
            RuleFor(x => x.RoleId)
                .NotEmpty()
                .WithMessage("User RoleId must not be empty.");
        }
    }
}

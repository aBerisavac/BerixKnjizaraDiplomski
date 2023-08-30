using Application.DTOs.UseCases;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class UseCaseDTOValidator: AbstractValidator<UseCaseDTO>
    {
        public UseCaseDTOValidator(DBKnjizaraContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("UseCase name must not be empty")
                .MaximumLength(50)
                .WithMessage("UseCase name must not be greater then 50 characters.")
                .Must(name => !dbContext.UseCases.Any(y => y.Name == name))
                .WithMessage("UseCase name must be unique");
        }
    }
}

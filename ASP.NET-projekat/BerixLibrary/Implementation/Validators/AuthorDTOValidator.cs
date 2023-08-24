using Application.DTOs.Authors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class AuthorDTOValidator: AbstractValidator<AuthorDTO>
    {
        public AuthorDTOValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("Author FirstName must not be empty")
                .MaximumLength(50)
                .WithMessage("Author FirstName must not be greater then 50 characters.");
            RuleFor(x => x.LastName)
                .NotEmpty()
                .WithMessage("Author LastName must not be empty")
                .MaximumLength(50)
                .WithMessage("Author LastName must not be greater then 50 characters.");
            RuleFor(x => x.BirthDate)
                .NotEmpty()
                .WithMessage("Author BirthDate must not be empty");
            RuleFor(x => x.BirthDate)
                .Must(IsDateInFuture)
                .WithMessage("Author BirthDate must be in the past");
        }

        private bool IsDateInFuture(DateTime date)
        {
            return (date < DateTime.Now);
        }
    }
}

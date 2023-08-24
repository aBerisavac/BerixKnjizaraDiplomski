using Application.DTOs.Logs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class LogDTOValidator: AbstractValidator<LogDTO>
    {
        public LogDTOValidator()
        {
            RuleFor(x => x.Data)
                .NotEmpty()
                .WithMessage("Log Data must not be empty")
                .MaximumLength(500)
                .WithMessage("Log Data must not be longer then 500 characters");
            RuleFor(x => x.Actor)
                .NotEmpty()
                .WithMessage("Log Actor must not be empty");
            RuleFor(x => x.UseCase)
                .NotEmpty()
                .WithMessage("Log UseCase must not be empty");
        }
    }
}

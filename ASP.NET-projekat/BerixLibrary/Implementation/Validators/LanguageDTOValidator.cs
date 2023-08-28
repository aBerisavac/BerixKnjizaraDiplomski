using Application.DTOs.Languages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
  public class LanguageDTOValidator: AbstractValidator<LanguageDTO>
  {
    public LanguageDTOValidator()
    {
      RuleFor(x=>x.Name)
        .NotEmpty()
        .WithMessage("Language Namee must not be empty")
        .MaximumLength(50)
        .WithMessage("Language Name must not be greater then 50 characters.");
    }
  }
}

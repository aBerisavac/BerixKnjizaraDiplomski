using Application.DTOs.HomeParagraphs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
  public class HomeParagraphDTOValidator: AbstractValidator<HomeParagraphDTO>
  {
    public HomeParagraphDTOValidator()
    {
      RuleFor(x => x.Paragraph)
        .NotEmpty()
        .WithMessage("Paragraph must not be empty")
        .MaximumLength(1000)
        .WithMessage("Paragraph must not be longer then 1000 characters.");
    }
  }
}

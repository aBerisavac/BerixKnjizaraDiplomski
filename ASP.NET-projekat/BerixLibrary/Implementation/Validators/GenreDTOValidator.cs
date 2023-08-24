using Application.DTOs.Genres;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class GenreDTOValidator: AbstractValidator<GenreDTO>
    {
        public GenreDTOValidator(DBKnjizaraContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Genre name must not be empty")
                .MaximumLength(50)
                .WithMessage("Genre name must not be longer then 50 characters")
                .Must(name => !dbContext.Genres.Any(y => y.Name == name))
                .WithMessage("Genre name must be unique");
        }
    }
}

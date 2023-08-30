using Application.DTOs.Books;
using EFDataAccess;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class BookUpdateDTOValidator: AbstractValidator<BookUpdateDTO>
    {
        private DBKnjizaraContext _dbKnjizara = new DBKnjizaraContext();
        public BookUpdateDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Book Title must not be empty")
                .MaximumLength(50)
                .WithMessage("Book Title must not be longer then 50 characters");
            RuleFor(x => x.ImageSrc)
                .NotEmpty()
                .WithMessage("Book ImageSrc must not be empty")
                .MaximumLength(50)
                .WithMessage("Book ImageSrc must not be longer then 50 characters");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Book Description must not be empty")
                .MaximumLength(2000)
                .WithMessage("Book Description must not be longer then 2000 characters");
            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .WithMessage("Book ReleaseDate must not be empty")
                .Must(IsDateInFuture)
                .WithMessage("Book ReleaseDate must be in the past");
            RuleFor(x => x.AuthorIds)
                .NotEmpty()
                .WithMessage("Book Authors must not be empty");
            RuleFor(x => x.AuthorIds)
                .Must(authorIds => authorIds.All(id => _dbKnjizara.Authors.Any(a => a.Id == id)))
                .WithMessage("One or more Author ids don't exist in database.");
            RuleFor(x => x.GenreIds)
                .NotEmpty()
                .WithMessage("Book Authors must not be empty");
            RuleFor(x => x.GenreIds)
                .Must(genreIds => genreIds.All(id => _dbKnjizara.Genres.Any(g => g.Id == id)))
                .WithMessage("One or more Genre ids don't exist in database.");
            RuleFor(x => x.LanguageIds)
                .Must(languageIds => languageIds.All(id => _dbKnjizara.Languages.Any(g => g.Id == id)))
                .WithMessage("One or more Language ids don't exist in database.");
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Book Price must not be empty");
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Book id must be inputted");
        }

        private bool IsDateInFuture(DateTime date)
        {
            return (date < DateTime.Now);
        }
    }
}

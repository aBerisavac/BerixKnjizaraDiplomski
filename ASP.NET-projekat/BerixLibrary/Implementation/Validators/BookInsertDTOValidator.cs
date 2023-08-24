using Application.DTOs.Books;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class BookInsertDTOValidator: AbstractValidator<BookInsertDTO>
    {
        public BookInsertDTOValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Book Title must not be empty")
                .MaximumLength(50)
                .WithMessage("Book Title must not be longer then 50 characters");
            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Book Description must not be empty")
                .MaximumLength(200)
                .WithMessage("Book Description must not be longer then 200 characters");
            RuleFor(x => x.Language)
                .NotEmpty()
                .WithMessage("Book Language must not be empty")
                .MaximumLength(200)
                .WithMessage("Book Language must not be longer then 30 characters");
            RuleFor(x => x.ReleaseDate)
                .NotEmpty()
                .WithMessage("Book ReleaseDate must not be empty")
                .Must(IsDateInFuture)
                .WithMessage("Book ReleaseDate must be in the past");
            RuleFor(x => x.AuthorIds)
                .NotEmpty()
                .WithMessage("Book Authors must not be empty");
            RuleFor(x => x.GenreIds)
                .NotEmpty()
                .WithMessage("Book Authors must not be empty");
            RuleFor(x => x.Price)
                .NotEmpty()
                .WithMessage("Book Price must not be empty");
        }

        private bool IsDateInFuture(DateTime date)
        {
            return (date < DateTime.Now);
        }
    }
}

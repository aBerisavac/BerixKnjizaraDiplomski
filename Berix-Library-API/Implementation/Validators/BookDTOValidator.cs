using Application.DTOs.Books;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators
{
    public class BookDTOValidator: AbstractValidator<BookDTO>
    {
        public BookDTOValidator()
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
            RuleFor(x => x.Authors)
                .NotEmpty()
                .WithMessage("Book Authors must not be empty");
            RuleFor(x => x.Genres)
                .NotEmpty()
                .WithMessage("Book Authors must not be empty");
            RuleFor(x => x.Prices)
                .NotEmpty()
                .WithMessage("Book Prices must not be empty");
            RuleFor(x => x.Languages)
                .NotEmpty()
                .WithMessage("Book Languages must not be empty");
        }

        private bool IsDateInFuture(DateTime date)
        {
            return (date < DateTime.Now);
        }
    }
}

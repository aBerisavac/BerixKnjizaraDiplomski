using Application.Commands.Books;
using Application.DTOs.Books;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Books
{
    public class EfCreateBook : IAddBookCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly BookInsertDTOValidator _validator;

        public int Id => 16;

        public string Name => "Create Book";

        public EfCreateBook(IMapper mapper, DBKnjizaraContext dbContext, BookInsertDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(BookInsertDTO request)
        {
            _validator.ValidateAndThrow(request);

            var book = new Book { Title = request.Title, Language = request.Language, Description = request.Description, ReleaseDate = request.ReleaseDate };

            var authors = _dbContext.Authors.Where(x => request.AuthorIds.Any(y => y == x.Id));
            var bookAuthors = new List<BookAuthor>();
            foreach (var author in authors)
            {
                bookAuthors.Add(new BookAuthor { Author=author, Book=book });
            }

            var genres = _dbContext.Genres.Where(x => request.GenreIds.Any(y => y == x.Id));
            var bookGenres = new List<BookGenre>();
            foreach (var genre in genres)
            {
                bookGenres.Add(new BookGenre { Genre = genre, Book = book });
            }

            var bookPrice = new BookPrice
            {
                Price = request.Price,
                Book = book
            };


            _dbContext.Books.Add(book);
            _dbContext.BookPrices.Add(bookPrice);
            _dbContext.BookAuthors.AddRange(bookAuthors);
            _dbContext.BookGenres.AddRange(bookGenres);
            _dbContext.SaveChanges();
        }
    }
}

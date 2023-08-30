using Application.Commands.Books;
using Application.DTOs.Books;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Books
{
    public class EfUpdateBook : IEditBookCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly BookUpdateDTOValidator _validator;

        public int Id => 18;

        public string Name => "Update Book";

        public EfUpdateBook(IMapper mapper, DBKnjizaraContext dbContext, BookUpdateDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(BookUpdateDTO request)
        {
            var books = _dbContext.Books
                .Include(book => book.Authors).ThenInclude(author => author.Author)
                .Include(book => book.Genres).ThenInclude(genre => genre.Genre)
                .Include(book => book.Prices);
            var book = books.Select(x => x).Where(x => x.Id == request.Id).FirstOrDefault();

            if (book == null)
            {
                throw new EntityNotFoundException(request.Id, typeof(Book));
            }

            _validator.ValidateAndThrow(request);

            var changed = false;

            if (book.ReleaseDate != request.ReleaseDate)
            {
                book.ReleaseDate = request.ReleaseDate;
                changed = true;
            }

            if (book.Title != request.Title)
            {
                book.Title = request.Title;
                changed = true;
            }

            if (book.Description != request.Description)
            {
                book.Description = request.Description;
                changed = true;
            }

            if (book.ImageSrc != request.ImageSrc)
            {
                book.ImageSrc = request.ImageSrc;
                changed = true;
            }

            if (request.Price != _dbContext.BookPrices.Where(x => x.CreatedAt == _dbContext.BookPrices.Max(x => x.CreatedAt)).FirstOrDefault().Price)
            {
                var newPrice = new BookPrice { Book = book, Price = request.Price };
                book.Prices.Add(newPrice);
                _dbContext.BookPrices.Add(newPrice);
                changed = true;
            }

            if(checkForChangeinAuthors(request.AuthorIds, request, book))
            {
                var authors = new List<Author>();
                foreach(int authorId in request.AuthorIds)
                {
                    authors.Add(_dbContext.Authors.Find(authorId));
                }

                var authorBooks = new List<BookAuthor>();
                foreach(Author author in authors)
                {
                    authorBooks.Add(new BookAuthor { Book=book, Author = author});
                }

                book.Authors = authorBooks;
                changed = true;
            }

            if(checkForChangesInLanguages(request.LanguageIds, request, book))
            {
                var languages = new List<Language>();
                foreach(int languageId in request.LanguageIds)
                {
                    languages.Add(_dbContext.Languages.Find(languageId));
                }

                var languageBooks = new List<BookLanguage>();
                foreach(Language language in languages)
                {
                  languageBooks.Add(new BookLanguage { Book=book, Language = language});
                }

                book.Languages = languageBooks;
                changed = true;
            }

            if(checkForChangeinGenres(request.GenreIds, request, book))
            {
                var genres = new List<Genre>();
                foreach(int genreId in request.GenreIds)
                {
                    genres.Add(_dbContext.Genres.Find(genreId));
                }

                var genreBooks = new List<BookGenre>();
                foreach(Genre genre in genres)
                {
                    genreBooks.Add(new BookGenre { Book=book, Genre = genre});
                }

                book.Genres = genreBooks;
                changed = true;
            }

            if (changed)
            {
                _dbContext.SaveChanges();
            }
        }

        private bool checkForChangeinAuthors(IEnumerable<int> newAuthorIds, BookUpdateDTO book, Book currentBook)
        {
            for(int i = 0; i < newAuthorIds.Count(); i++)
            {
                var currentBookAuthors = _mapper.Map<BookDTO>(currentBook).Authors;

                if(currentBookAuthors.Any(x=> !newAuthorIds.Contains(x.Id))){
                    return true;
                }

                if(newAuthorIds.Any(x=> !currentBookAuthors.Any(a=>a.Id==x))){
                    return true;
                }
            }

            return false;
        }
        private bool checkForChangesInLanguages(IEnumerable<int> newLanguageIds, BookUpdateDTO book, Book currentBook)
        {
            for(int i = 0; i < newLanguageIds.Count(); i++)
            {
                var currentBookLanguages = _mapper.Map<BookDTO>(currentBook).Authors;

                if(currentBookLanguages.Any(x=> !newLanguageIds.Contains(x.Id))){
                    return true;
                }

                if(newLanguageIds.Any(x=> !currentBookLanguages.Any(a=>a.Id==x))){
                    return true;
                }
            }

            return false;
        }
        private bool checkForChangeinGenres(IEnumerable<int> newGenreIds, BookUpdateDTO book, Book currentBook)
        {
            for(int i = 0; i < newGenreIds.Count(); i++)
            {
                var currentBookGenres = _mapper.Map<BookDTO>(currentBook).Genres;

                if(currentBookGenres.Any(x=> !newGenreIds.Contains(x.Id))){
                    return true;
                }

                if(newGenreIds.Any(x=> !currentBookGenres.Any(a=>a.Id==x))){
                    return true;
                }
            }

            return false;
        }
    }
}

using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.Exceptions;
using Application.Queries.Books;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Books
{
    public class EfGetBook : IGetBookQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 39;

        public string Name => "Get Book";

        public EfGetBook(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public BookDTO Execute(int id)
        {
            var books = _dbContext.Books
                .Include(book => book.Authors).ThenInclude(author => author.Author)
                .Include(book => book.Genres).ThenInclude(genre => genre.Genre)
                .Include(book=>book.Languages).ThenInclude(language=>language.Language)
                .Include(book => book.Prices);
            var book = books.Select(x=>x).Where(x=>x.Id==id).FirstOrDefault();

            if (book == null)
            {
                throw new EntityNotFoundException(id, typeof(Book));
            }

            book.Prices = book.Prices.Where(x=>x.CreatedAt==book.Prices.Max(x=>x.CreatedAt)).ToList();
            var response = _mapper.Map<BookDTO>(book);

            return response;
        }
    }
}

using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.Queries.Books;
using AutoMapper;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Books
{
    public class EfGetBooks : IGetBooksQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;
        public int Id => 38;

        public string Name => "Get Books";

        public EfGetBooks(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<BookDTO> Execute(string searchTerm)
        {
      var query = _dbContext.Books
          .Include(book => book.Authors).ThenInclude(author => author.Author)
          .Include(book => book.Genres).ThenInclude(genre => genre.Genre)
          .Include(book => book.Languages).ThenInclude(language => language.Language)
                .Include(book=>book.Prices)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Title.Contains(searchTerm));
            }
            else
            {

            }

            foreach(var book in query)
            {
                book.Prices = book.Prices.Where(x => x.CreatedAt == book.Prices.Max(x => x.CreatedAt)).ToList();
            }

            return query.Select(x => _mapper.Map<BookDTO>(x));
        }
    }
}

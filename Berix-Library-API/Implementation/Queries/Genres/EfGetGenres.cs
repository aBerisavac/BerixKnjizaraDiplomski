using Application.DTOs.Genres;
using Application.Queries.Genres;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Genres
{
    public class EfGetGenres: IGetGenresQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 34;

        public string Name => "Get Genres";

        public EfGetGenres(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<GenreDTO> Execute(string searchTerm)
        {
            var query = _dbContext.Genres.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Contains(searchTerm));
            }
            else
            {

            }

            return query.Select(x => _mapper.Map<GenreDTO>(x));
        }
    }
}

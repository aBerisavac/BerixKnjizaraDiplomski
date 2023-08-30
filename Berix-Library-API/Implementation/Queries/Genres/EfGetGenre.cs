using Application.DTOs.Genres;
using Application.Exceptions;
using Application.Queries.Genres;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Genres
{
    public class EfGetGenre: IGetGenreQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 35;

        public string Name => "Get Genre";


        public EfGetGenre(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public GenreDTO Execute(int id)
        {
            var genre = _dbContext.Genres.Find(id);

            if (genre == null)
            {
                throw new EntityNotFoundException(id, typeof(Genre));
            }

            var response = _mapper.Map<GenreDTO>(genre);

            return response;
        }
    }
}

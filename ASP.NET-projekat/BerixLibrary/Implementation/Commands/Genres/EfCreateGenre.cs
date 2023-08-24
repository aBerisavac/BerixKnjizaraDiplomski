using Application.Commands.Genres;
using Application.DTOs.Genres;
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

namespace Implementation.Commands.Genres
{
    public class EfCreateGenre : IAddGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly GenreDTOValidator _validator;

        public int Id => 13;

        public string Name => "Create Genre";

        public EfCreateGenre(IMapper mapper, DBKnjizaraContext dbContext, GenreDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(GenreDTO request)
        {
            var genre = _mapper.Map<Genre>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(genre);
            _dbContext.SaveChanges();
        }
    }
}

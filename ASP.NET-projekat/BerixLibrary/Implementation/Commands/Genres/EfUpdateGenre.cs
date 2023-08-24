using Application.Commands.Genres;
using Application.DTOs.Genres;
using Application.Exceptions;
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
    public class EfUpdateGenre : IEditGenreCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly GenreDTOValidator _validator;

        public int Id => 15;

        public string Name => "Update Genre";

        public EfUpdateGenre(IMapper mapper, DBKnjizaraContext dbContext, GenreDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(GenreDTO request)
        {
            var genre = _dbContext.Genres.Find(request.Id);

            if (genre == null)
            {
                throw new EntityNotFoundException(Id, typeof(Genre));
            }

            /*
        virtual public ICollection<BookGenre>? Books { get; set; } = new List<BookGenre>();
             */

            _validator.ValidateAndThrow(request);

            genre.Name = request.Name;

            _dbContext.SaveChanges();
        }
    }
}

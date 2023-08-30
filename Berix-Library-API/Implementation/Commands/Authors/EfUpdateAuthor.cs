using Application.Commands.Authors;
using Application.DTOs.Authors;
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

namespace Implementation.Commands.Authors
{
    public class EfUpdateAuthor : IEditAuthorCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly AuthorDTOValidator _validator;
        public int Id => 12;

        public string Name => "Update Author";

        public EfUpdateAuthor(IMapper mapper, DBKnjizaraContext dbContext, AuthorDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(AuthorDTO request)
        {
            var author = _dbContext.Authors.Find(request.Id);

            if (author == null)
            {
                throw new EntityNotFoundException(Id, typeof(Author));
            }

            _validator.ValidateAndThrow(request);

            author.FirstName = request.FirstName;
            author.LastName = request.LastName;
            author.BirthDate = request.BirthDate;

            _dbContext.SaveChanges();
        }
    }
}

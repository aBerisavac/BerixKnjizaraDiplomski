using Application.Commands.Authors;
using Application.DTOs.Authors;
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
    public class EfCreateAuthor : IAddAuthorCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly AuthorDTOValidator _validator;
        public int Id => 10;

        public string Name => "Create Author";

        public EfCreateAuthor(IMapper mapper, DBKnjizaraContext dbContext, AuthorDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(AuthorDTO request)
        {
            var author = _mapper.Map<Author>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(author);
            _dbContext.SaveChanges();
        }
    }
}

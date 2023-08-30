using Application.DTOs.Authors;
using Application.Exceptions;
using Application.Queries.Authors;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Authors
{
    public class EfGetAuthor : IGetAuthorQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 37;

        public string Name => "Get Author";

        public EfGetAuthor(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDTO Execute(int id)
        {
            var author = _dbContext.Authors.Find(id);

            if (author == null)
            {
                throw new EntityNotFoundException(id, typeof(Author));
            }

            var response = _mapper.Map<AuthorDTO>(author);

            return response;
        }
    }
}

using Application.DTOs.Authors;
using Application.Queries.Authors;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Authors
{
    public class EfGetAuthors : IGetAuthorsQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 36;

        public string Name => "Get Authors";

        public EfGetAuthors(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<AuthorDTO> Execute(string searchTerm)
        {
            var query = _dbContext.Authors.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.FirstName.Contains(searchTerm) || x.LastName.Contains(searchTerm));
            }
            else
            {

            }

            return query.Select(x => _mapper.Map<AuthorDTO>(x));
        }
    }
}

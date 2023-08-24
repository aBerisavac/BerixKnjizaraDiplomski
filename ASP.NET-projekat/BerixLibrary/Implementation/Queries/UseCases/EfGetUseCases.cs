using Application.DTOs.Genres;
using Application.DTOs.UseCases;
using Application.Queries.UseCases;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.UseCases
{
    public class EfGetUseCases : IGetUseCasesQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper mapper;

        public int Id => 28;

        public string Name => "Get UseCases";

        public EfGetUseCases(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public IEnumerable<UseCaseDTO> Execute(string searchTerm)
        {
            var query = _dbContext.UseCases.AsQueryable();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                query = query.Where(x => x.Name.Contains(searchTerm));
            }
            else
            {

            }

            return query.Select(x => mapper.Map<UseCaseDTO>(x));
        }
    }
}

using Application.DTOs.Genres;
using Application.DTOs.UseCases;
using Application.Exceptions;
using Application.Queries.UseCases;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.UseCases
{
    public class EfGetUseCase : IGetUseCaseQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper mapper;

        public int Id => 29;

        public string Name => "Get UseCase";

        public EfGetUseCase(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            this.mapper = mapper;
        }

        public UseCaseDTO Execute(int id)
        {
            var useCase = _dbContext.UseCases.Find(id);

            if (useCase == null)
            {
                throw new EntityNotFoundException(id, typeof(UseCase));
            }

            var response = mapper.Map<UseCaseDTO>(useCase);

            return response;
        }
    }
}

using Application.Commands.UseCases;
using Application.DTOs.UseCases;
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

namespace Implementation.Commands.UseCases
{
    public class EfCreateUseCase : IAddUseCaseCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly UseCaseDTOValidator _validator;
        public int Id => 1;

        public string Name => "Create UseCase";

        public EfCreateUseCase(IMapper mapper, DBKnjizaraContext dbContext, UseCaseDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(UseCaseDTO request)
        {
            var useCase = _mapper.Map<UseCase>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(useCase);
            _dbContext.SaveChanges();
        }
    }
}

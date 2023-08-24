using Application.Commands.UseCases;
using Application.DTOs.UseCases;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.UseCases
{
    public class EfUpdateUseCase : IEditUseCaseCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly UseCaseDTOValidator _validator;
        public EfUpdateUseCase(IMapper mapper, DBKnjizaraContext dbContext, UseCaseDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public int Id => 3;

        public string Name => "Update UseCase";

        public void Execute(UseCaseDTO request)
        {
            var useCase = _dbContext.UseCases.Find(request.Id);

            if (useCase == null)
            {
                throw new EntityNotFoundException(Id, typeof(UseCase));
            }

            /*
        virtual public ICollection<RoleUseCase>? Roles { get; set; } = new List<RoleUseCase>();
        virtual public ICollection<Log>? Logs { get; set; } = new List<Log>();
             */

            _validator.ValidateAndThrow(request);

            useCase.Name = request.Name;

            _dbContext.SaveChanges();
        }
    }
}

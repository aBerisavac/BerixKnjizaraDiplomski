using Application.Commands.Logs;
using Application.DTOs.Logs;
using Application.Exceptions;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Logs
{
    public class EfUpdateLog : IEditLogCommand
    {

        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly LogDTOValidator _validator;

        public int Id => 24;

        public string Name => "Update Log";

        public EfUpdateLog(IMapper mapper, DBKnjizaraContext dbContext, LogDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(LogDTO request)
        {
            var log = _dbContext.Logs.Find(request.Id);

            if (log == null)
            {
                throw new EntityNotFoundException(Id, typeof(Log));
            }

            _validator.ValidateAndThrow(request);

            log.Actor = _mapper.Map<User>(request.Actor);
            log.UseCase = _mapper.Map<UseCase>(request.UseCase);
            log.Data = request.Data;
            log.ActorId = request.Actor.Id;
            log.UseCaseId = request.UseCase.Id;

            _dbContext.SaveChanges();
        }
    }
}

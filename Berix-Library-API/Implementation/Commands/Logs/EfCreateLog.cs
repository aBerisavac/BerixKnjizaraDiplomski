using Application.Commands.Logs;
using Application.DTOs.Logs;
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

namespace Implementation.Commands.Logs
{
    public class EfCreateLog : IAddLogCommand
    {
        private readonly IMapper _mapper;
        private readonly DBKnjizaraContext _dbContext;
        private readonly LogDTOValidator _validator;

        public int Id => 22;

        public string Name => "Create Log";

        public EfCreateLog(IMapper mapper, DBKnjizaraContext dbContext, LogDTOValidator validator)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _validator = validator;
        }

        public void Execute(LogDTO request)
        {
            var log = _mapper.Map<Book>(request);

            _validator.ValidateAndThrow(request);

            _dbContext.Add(log);
            _dbContext.SaveChanges();
        }
    }
}

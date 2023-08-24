using Application.DTOs.Logs;
using Application.DTOs.Users;
using Application.Exceptions;
using Application.Queries.Logs;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Implementation.Queries.Logs
{
    public class EfGetLogs: IGetLogsQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 44;

        public string Name => "Get Logs";

        public EfGetLogs(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public IEnumerable<LogDTO> Execute(string searchTerm)
        {
            var query = _dbContext.Logs
                .Include(log => log.Actor)
                .Include(log => log.UseCase)
                .AsQueryable();

            if (searchTerm != null)
            {
                query = query.Where(x => x.UseCase.Name.Contains(searchTerm));
            }
            else
            {
            }

            var elements = query.Select(x => _mapper.Map<LogDTO>(x));
            return elements;
        }
    }
}

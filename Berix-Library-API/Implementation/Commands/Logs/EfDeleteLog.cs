using Application.Commands.Logs;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Logs
{
    public class EfDeleteLog : IDeleteLogCommand
    {

        private readonly DBKnjizaraContext _dbContext;

        public int Id => 23;

        public string Name => "Delete Log";

        public EfDeleteLog(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(int id)
        {
            var log = _dbContext.Logs.Find(id);

            if (log == null)
            {
                throw new EntityNotFoundException(id, typeof(Log));
            }

            log.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

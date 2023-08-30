using Application;
using Domain;
using EFDataAccess;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Logging
{
    public class SQLLogger : IUseCaseLogger
    {
        private readonly DBKnjizaraContext dbContext;

        public SQLLogger(DBKnjizaraContext libraryContext)
        {
            dbContext = libraryContext;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            var log = new Log();

            log.Actor = dbContext.Users.Find(actor.UserId);
            log.ActorId = actor.UserId;
            log.UseCase = dbContext.UseCases.Find(useCase.Id);
            log.UseCaseId = useCase.Id;
            log.Data = JsonConvert.SerializeObject(useCaseData); //TO DO serialize properly

            dbContext.Logs.Add(log);
            dbContext.SaveChanges();
        }
    }
}

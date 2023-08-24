using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class UseCaseExecutor
    {
        private readonly IApplicationActor actor;
        private readonly IUseCaseLogger logger;

        public UseCaseExecutor(IApplicationActor actor, IUseCaseLogger logger)
        {
            this.actor = actor;
            this.logger = logger;
        }

        public void ExecuteCommand<TRequest>(
            ICommand<TRequest> command,
            TRequest request)
        {
            //Console.WriteLine($"{DateTime.Now}: {actor.Identity} is trying to execute {command.Name} using data: " +
            //    $"{JsonConvert.SerializeObject(request)}");

            if (actor.RoleId != 3)
            {
                logger.Log(command, actor, request);
            }

            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new UnauthorizedUseCaseException(command, actor);
            }

            command.Execute(request);

        }
        public TResult ExecuteQuery<TSearch, TResult>
            (IQuery<TSearch, TResult> query,
            TSearch search)
        {
            
                logger.Log(query, actor, search);

            if (!actor.AllowedUseCases.Contains(query.Id))
                throw new UnauthorizedUseCaseException(query, actor);
            return query.Execute(search);
        }

    }
}

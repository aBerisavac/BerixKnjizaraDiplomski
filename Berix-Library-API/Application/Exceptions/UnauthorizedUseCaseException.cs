using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor)
           : base($"Actor with an id of {actor.UserId} - {actor.Email}, witha role id of {actor.RoleId} tried to execute {useCase.Name}.")
        {

        }
    }
}

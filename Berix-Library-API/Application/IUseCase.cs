using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IUseCase
    {
        int Id { get; }
        string Name { get; }
    }

    public interface ICommand<TRequest> : IUseCase
    {
        void Execute(TRequest execute);
    }

    public interface IQuery<Trequest, TResponse> : IUseCase
    {
        TResponse Execute(Trequest execute);
    }
}

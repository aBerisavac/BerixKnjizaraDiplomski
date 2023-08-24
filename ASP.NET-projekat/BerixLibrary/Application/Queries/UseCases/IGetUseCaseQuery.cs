using Application.DTOs.UseCases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.UseCases
{
    public interface IGetUseCaseQuery : IQuery<int, UseCaseDTO>
    {
    }
}

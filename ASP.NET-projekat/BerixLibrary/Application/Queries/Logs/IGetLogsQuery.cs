using Application.DTOs.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Logs
{
    public interface IGetLogsQuery : IQuery<string, IEnumerable<LogDTO>>
    {
    }
}

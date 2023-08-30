using Application.DTOs.Authors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Authors
{
    public interface IGetAuthorsQuery : IQuery<string, IEnumerable<AuthorDTO>>
    {
    }
}

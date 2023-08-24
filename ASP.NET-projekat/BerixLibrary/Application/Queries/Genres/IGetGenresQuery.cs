using Application.DTOs.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Genres
{
    public interface IGetGenresQuery : IQuery<string, IEnumerable<GenreDTO>>
    {
    }
}

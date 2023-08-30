using Application.DTOs.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Books
{
    public interface IGetBooksQuery : IQuery<string, IEnumerable<BookDTO>>
    {
    }
}

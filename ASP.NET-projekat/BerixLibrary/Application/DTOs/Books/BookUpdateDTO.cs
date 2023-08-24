using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Books
{
    public class BookUpdateDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public IEnumerable<int> GenreIds { get; set; }
        public IEnumerable<int> AuthorIds { get; set; }
        virtual public int Price { get; set; }
    }
}

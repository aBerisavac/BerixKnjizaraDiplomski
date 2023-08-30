using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookGenre
    {
        public int BookId { get; set; }
        public int GenreId { get; set; }
        virtual public Book Book { get; set; }
        virtual public Genre Genre { get; set; }
    }
}

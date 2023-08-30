using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageSrc { get; set; }
        public DateTime ReleaseDate { get; set; }
        virtual public ICollection<OrderInvoice>? OrderInvoices { get; set; } = new List<OrderInvoice>();
        virtual public ICollection<BookAuthor> Authors { get; set; } = new List<BookAuthor>();
        virtual public ICollection<BookPrice> Prices { get; set; } = new List<BookPrice>();
        virtual public ICollection<BookGenre> Genres { get; set; } = new List<BookGenre>();
        virtual public ICollection<BookLanguage> Languages { get; set; } = new List<BookLanguage>();
    }
}

using Application.DTOs.Authors;
using Application.DTOs.Genres;
using Application.DTOs.Orders;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Books
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Language { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<GenreDTO> Genres { get; set; } = new List<GenreDTO>();
        public ICollection<AuthorDTO> Authors { get; set; } = new List<AuthorDTO>();
        virtual public ICollection<BookPriceDTO> Prices { get; set; } = new List<BookPriceDTO>();
        virtual public ICollection<OrderInvoiceDTO>? OrderInvoices { get; set; } = new List<OrderInvoiceDTO>();
    }
}

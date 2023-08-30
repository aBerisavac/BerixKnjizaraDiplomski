using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Books
{
    public class BookPriceDTO
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public BookDTO Book { get; set; }
    }
}

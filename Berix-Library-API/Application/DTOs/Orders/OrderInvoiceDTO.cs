using Application.DTOs.Books;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class OrderInvoiceDTO
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int NumberOfItems { get; set; }
    }
}

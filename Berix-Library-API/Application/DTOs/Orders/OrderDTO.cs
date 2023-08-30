using Application.DTOs.Books;
using Application.DTOs.ShippingMethods;
using Application.DTOs.Users;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int ShippingMethodId { get; set; }
        virtual public ICollection<OrderInvoiceDTO> OrderInvoices { get; set; } = new List<OrderInvoiceDTO>();
        virtual public ShippingMethodDTO ShippingMethod { get; set; }
        virtual public UserDTO Customer { get; set; }
    }
}

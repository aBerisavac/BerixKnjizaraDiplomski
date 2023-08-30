using Application.DTOs.ShippingMethods;
using Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Orders
{
    public class OrderInsertDTO
    {
        public int CustomerId { get; set; }
        public int ShippingMethodId { get; set; }
        virtual public ICollection<OrderInvoiceInsertDTO> OrderInvoices { get; set; } = new List<OrderInvoiceInsertDTO>();
    }
}

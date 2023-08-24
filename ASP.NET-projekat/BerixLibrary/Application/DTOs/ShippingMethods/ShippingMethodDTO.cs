using Application.DTOs.Orders;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.ShippingMethods
{
    public class ShippingMethodDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        virtual public ICollection<OrderDTO>? Orders { get; set; } = new List<OrderDTO>();
    }
}

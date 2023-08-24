using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ShippingMethod : Entity
    { 
        public string Name { get; set; }
        public decimal Cost { get; set; }
        virtual public ICollection<Order>? Orders { get; set; } = new List<Order>();
    }
}

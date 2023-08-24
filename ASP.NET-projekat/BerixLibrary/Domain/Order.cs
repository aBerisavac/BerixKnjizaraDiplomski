using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order : Entity
    { 
        public int CustomerId { get; set; }
        public int ShippingMethodId { get; set; }
        virtual public ICollection<OrderInvoice> OrderInvoices { get; set; } = new List<OrderInvoice>();
        virtual public ShippingMethod ShippingMethod { get; set; }
        virtual public User Customer { get; set; }
    }
}

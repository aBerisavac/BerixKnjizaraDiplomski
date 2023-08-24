using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BookPrice : Entity
    {
        public int BookId { get; set; }
        public decimal Price { get; set; }
        public Book Book { get; set; }
    }
}

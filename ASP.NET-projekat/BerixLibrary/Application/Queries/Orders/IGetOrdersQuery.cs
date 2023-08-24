using Application.DTOs.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Orders
{
    public interface IGetOrdersQuery : IQuery<string, IEnumerable<OrderDTO>>
    {
    }
}

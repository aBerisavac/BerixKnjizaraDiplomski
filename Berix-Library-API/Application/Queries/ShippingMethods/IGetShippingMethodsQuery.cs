using Application.DTOs.ShippingMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.ShippingMethods
{
    public interface IGetShippingMethodsQuery : IQuery<string, IEnumerable<ShippingMethodDTO>>
    {
    }
}

using Application.DTOs.ShippingMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.ShippingMethods
{
    public interface IEditShippingMethodCommand: ICommand<ShippingMethodDTO>
    {
    }
}

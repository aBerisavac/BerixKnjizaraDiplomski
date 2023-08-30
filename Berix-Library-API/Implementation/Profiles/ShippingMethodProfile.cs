using Application.DTOs.ShippingMethods;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class ShippingMethodProfile: Profile
    {
        public ShippingMethodProfile()
        {
            CreateMap<ShippingMethod, ShippingMethodDTO>();
            CreateMap<ShippingMethodDTO, ShippingMethod>();
        }
    }
}

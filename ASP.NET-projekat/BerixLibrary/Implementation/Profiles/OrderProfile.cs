using Application.DTOs.Books;
using Application.DTOs.Orders;
using Application.DTOs.ShippingMethods;
using Application.DTOs.Users;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class OrderProfile : Profile { 
        public OrderProfile()
        {
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>()
                .ForMember(dto => dto.OrderInvoices, orders => orders.MapFrom(order => order.OrderInvoices.Select(x => new OrderInvoiceDTO
                {
                    Id = x.Id,
                    BookId = x.BookId,
                    NumberOfItems = x.NumberOfItems,
                })))
                .ForMember(dto => dto.Customer, orders => orders.MapFrom(order => new UserDTO
                {
                    Id = order.Customer.Id,
                    FirstName = order.Customer.FirstName,
                    LastName = order.Customer.LastName,
                    Address = order.Customer.Address,
                    Email = order.Customer.Email,
                }))
                .ForMember(dto => dto.ShippingMethod, orders => orders.MapFrom(order => new ShippingMethodDTO
                {
                    Id = order.ShippingMethod.Id,
                    Name = order.ShippingMethod.Name,
                    Cost = order.ShippingMethod.Cost,
                }));
            CreateMap<OrderInsertDTO, Order>()
                .ForMember(order => order.OrderInvoices, dtos => dtos.MapFrom(dto => dto.OrderInvoices.Select(x => new OrderInvoice
                {
                    BookId = x.BookId,
                    NumberOfItems = x.NumberOfItems,

                })));

            CreateMap<Order, OrderInsertDTO>();

        }
    }
}

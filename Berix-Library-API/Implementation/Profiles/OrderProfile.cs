using Application.DTOs.Books;
using Application.DTOs.Orders;
using Application.DTOs.ShippingMethods;
using Application.DTOs.Users;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class OrderProfile : Profile
  {
    private readonly DBKnjizaraContext _dbContext = new DBKnjizaraContext();
    public OrderProfile()
        {
      var books = _dbContext.Books.Include(x => x.Prices);
            CreateMap<OrderDTO, Order>();
            CreateMap<Order, OrderDTO>()
                .ForMember(dto => dto.OrderInvoices, orders => orders.MapFrom(order => order.OrderInvoices.Select(x => new OrderInvoiceDTO
                {
                    Id = x.Id,
                    BookId = x.BookId,
                    NumberOfItems = x.NumberOfItems,
                    PricePerItem = x.PricePerItem,
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
                  PricePerItem = books.Where(y=>y.Id == x.BookId).First().Prices.Where(price => price.CreatedAt == books.Where(y => y.Id == x.BookId).First().Prices.Max(x => x.CreatedAt)).ToList().First().Price
                })))
                .ForMember(order => order.ShippingAddress, dtos => dtos.MapFrom(dto => dto.ShippingAddress == null ? _dbContext.Users.Find(dto.CustomerId).Address : dto.ShippingAddress));
            CreateMap<Order, OrderInsertDTO>();

        }
    }
}

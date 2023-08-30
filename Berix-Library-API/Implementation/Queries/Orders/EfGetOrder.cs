using Application.DTOs.Orders;
using Application.DTOs.Users;
using Application.Exceptions;
using Application.Queries.Orders;
using AutoMapper;
using Domain;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Orders
{
    public class EfGetOrder : IGetOrderQuery
    {
        private readonly DBKnjizaraContext _dbContext;
        private readonly IMapper _mapper;

        public int Id => 43;

        public string Name => "Get Order";

        public EfGetOrder(DBKnjizaraContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public OrderDTO Execute(int id)
        {
            var orders = _dbContext.Orders
                .Include(order => order.OrderInvoices).ThenInclude(orderInvoice => orderInvoice.Book)
                .Include(order => order.Customer)
                .Include(order => order.ShippingMethod);
            var order = orders.Select(x => x).Where(x => x.Id == id).FirstOrDefault();

            if (order == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            var response = _mapper.Map<OrderDTO>(order);

            return response;
        }
    }
}

using Application.DTOs.Orders;
using Application.DTOs.Users;
using Application.Queries.Orders;
using AutoMapper;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Orders
{
  public class EfGetOrders : IGetOrdersQuery
  {
    private readonly DBKnjizaraContext _dbContext;
    private readonly IMapper _mapper;
    public int Id => 42;

    public string Name => "Get Books";

    public EfGetOrders(DBKnjizaraContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public IEnumerable<OrderDTO> Execute(string searchTerm)
    {
      var query = _dbContext.Orders
          .Include(order => order.OrderInvoices).ThenInclude(orderInvoice => orderInvoice.Book)
          .Include(order => order.Customer)
          .Include(order => order.ShippingMethod)
          .AsQueryable();

      if (!string.IsNullOrEmpty(searchTerm))
      {
        query = query.Where(x => (x.Customer.FirstName + " " + x.Customer.LastName).Contains(searchTerm));
      }
      else
      {

      }

      return query.Select(x => _mapper.Map<OrderDTO>(x));
    }
  }
}

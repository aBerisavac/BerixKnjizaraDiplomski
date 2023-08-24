using Application.Commands.Orders;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Orders
{
    public class EfDeleteOrder : IDeleteOrderCommand
    {

        private readonly DBKnjizaraContext _dbContext;

        public int Id => 26;

        public string Name => "Delete Order";

        public EfDeleteOrder(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(int id)
        {
            var order = _dbContext.Orders.Find(id);

            if (order == null)
            {
                throw new EntityNotFoundException(id, typeof(Order));
            }

            order.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

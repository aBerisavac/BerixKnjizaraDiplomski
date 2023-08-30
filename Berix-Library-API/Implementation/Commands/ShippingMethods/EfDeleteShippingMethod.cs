using Application.Commands.ShippingMethods;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.ShippingMethods
{
    public class EfDeleteShippingMethod : IDeleteShippingMethodCommand
    {
        private readonly DBKnjizaraContext _dbContext;

        public EfDeleteShippingMethod(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id => 5;

        public string Name => "Delete ShippingMethod";

        public void Execute(int id)
        {
            var shippingMethod = _dbContext.ShippingMethods.Find(id);
            if (shippingMethod == null)
            {
                throw new EntityNotFoundException(id, typeof(ShippingMethod));
            }

            shippingMethod.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

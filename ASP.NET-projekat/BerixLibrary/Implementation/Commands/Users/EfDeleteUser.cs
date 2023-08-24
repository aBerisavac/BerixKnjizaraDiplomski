using Application.Commands.Users;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Users
{
    public class EfDeleteUser : IDeleteUserCommand
    {
        
        private readonly DBKnjizaraContext _dbContext;
        public int Id => 20;

        public string Name => "Delete User";

        public EfDeleteUser(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(int id)
        {
            var user = _dbContext.Users.Find(id);
            if (user == null)
            {
                throw new EntityNotFoundException(id, typeof(User));
            }

            user.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

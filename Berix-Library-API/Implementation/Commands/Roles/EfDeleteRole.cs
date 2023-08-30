using Application.Commands.Roles;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Roles
{
    public class EfDeleteRole : IDeleteRoleCommand
    {
        private readonly DBKnjizaraContext _dbContext;
        public int Id => 8;

        public string Name => "Delete Role";

        public EfDeleteRole(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(int id)
        {
            var role = _dbContext.Roles.Find(id);
            if (role == null)
            {
                throw new EntityNotFoundException(id, typeof(Role));
            }

            role.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

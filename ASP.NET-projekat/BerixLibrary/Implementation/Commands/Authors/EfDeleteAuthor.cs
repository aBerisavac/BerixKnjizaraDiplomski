using Application.Commands.Authors;
using Application.DTOs.Authors;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Authors
{
    public class EfDeleteAuthor : IDeleteAuthorCommand
    {
        private readonly DBKnjizaraContext _dbContext;
        public int Id => 11;
        public string Name => "Delete Author";

        public EfDeleteAuthor(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Execute(int id)
        {
            var author = _dbContext.Authors.Find(id);
            if (author == null)
            {
                throw new EntityNotFoundException(id, typeof(Author));
            }

            author.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

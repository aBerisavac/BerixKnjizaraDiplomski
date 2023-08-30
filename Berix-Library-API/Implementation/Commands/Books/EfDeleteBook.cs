using Application.Commands.Books;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Books
{
    public class EfDeleteBook : IDeleteBookCommand
    {
        private readonly DBKnjizaraContext _dbContext;
        public int Id => 17;

        public string Name => "Delete Book";

        public EfDeleteBook(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(int id)
        {
            var book = _dbContext.Books.Find(id);
            if (book == null)
            {
                throw new EntityNotFoundException(id, typeof(Book));
            }

            book.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

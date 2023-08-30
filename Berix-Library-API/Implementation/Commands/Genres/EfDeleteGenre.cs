using Application.Commands.Genres;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Genres
{
    public class EfDeleteGenre : IDeleteGenreCommand
    {
        private readonly DBKnjizaraContext _dbContext;
        public int Id => 14;

        public string Name => "Delete Genre";

        public EfDeleteGenre(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Execute(int id)
        {
            var genre = _dbContext.Genres.Find(id);
            if (genre == null)
            {
                throw new EntityNotFoundException(id, typeof(Genre));
            }

            genre.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

using Application.Commands.UseCases;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.UseCases
{
    public class EfDeleteUseCase : IDeleteUseCaseCommand
    {
        private readonly DBKnjizaraContext _dbContext;

        public EfDeleteUseCase(DBKnjizaraContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Id => 2;

        public string Name => "Delete UseCase";

        public void Execute(int id)
        {
            var useCase = _dbContext.UseCases.Find(id);
            if (useCase == null)
            {
                throw new EntityNotFoundException(id, typeof(UseCase));
            }

            useCase.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}

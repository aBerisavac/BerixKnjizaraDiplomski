using Application.Commands.HomeParagraphs;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.HomeParagraphs
{
  public class EfDeleteHomeParagraph: IDeleteHomeParagraphCommand
  {
    private readonly DBKnjizaraContext _dbContext;
    public int Id => 52;

    public string Name => "Delete HomeParagraph";

    public EfDeleteHomeParagraph(DBKnjizaraContext dbContext)
    {
      _dbContext = dbContext;
    }

    public void Execute(int id)
    {
      var homeParagraph = _dbContext.HomeParagraphs.Find(id);
      if (homeParagraph == null)
      {
        throw new EntityNotFoundException(id, typeof(HomeParagraph));
      }

      homeParagraph.IsDeleted = true;
      _dbContext.SaveChanges();
    }
  }
}

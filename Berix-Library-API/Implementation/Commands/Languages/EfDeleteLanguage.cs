using Application.Commands.Languages;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.Languages
{
  public class EfDeleteLanguage: IDeleteLanguageCommand
  {
    private readonly DBKnjizaraContext _dbContext;
    public int Id => 47;
    public string Name => "Delete Language";

    public EfDeleteLanguage(DBKnjizaraContext dbContext)
    {
      _dbContext = dbContext;
    }
    public void Execute(int id)
    {
      var language = _dbContext.Languages.Find(id);
      if (language == null)
      {
        throw new EntityNotFoundException(id, typeof(Language));
      }

      if (_dbContext.BookLanguages.Any(x => x.LanguageId == id))
      {
        throw new ReferentialIntegrityViolationException(typeof(Language), typeof(Book));
      }

      language.IsDeleted = true;
      _dbContext.SaveChanges();
    }
  }
}

using Application.DTOs.Authors;
using Application.DTOs.Languages;
using Application.Queries.Languages;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Languages
{
  public class EfGetLanguages: IGetLanguagesQuery
  {
    private readonly DBKnjizaraContext _dbContext;
    private readonly IMapper _mapper;

    public int Id => 49;

    public string Name => "Get Languages";

    public EfGetLanguages(DBKnjizaraContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public IEnumerable<LanguageDTO> Execute(string searchTerm)
    {
      var query = _dbContext.Languages.AsQueryable();

      if (!string.IsNullOrEmpty(searchTerm))
      {
        query = query.Where(x => x.Name.Contains(searchTerm));
      }
      else
      {

      }

      return query.Select(x => _mapper.Map<LanguageDTO>(x));
    }
  }
}

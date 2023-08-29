using Application.DTOs.Authors;
using Application.DTOs.Languages;
using Application.Exceptions;
using Application.Queries.Languages;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.Languages
{
  public class EfGetLanguage: IGetLanguageQuery
  {
    private readonly DBKnjizaraContext _dbContext;
    private readonly IMapper _mapper;

    public int Id => 50;

    public string Name => "Get Language";

    public EfGetLanguage(DBKnjizaraContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public LanguageDTO Execute(int id)
    {
      var language = _dbContext.Languages.Find(id);

      if (language == null)
      {
        throw new EntityNotFoundException(id, typeof(Language));
      }

      var response = _mapper.Map<LanguageDTO>(language);

      return response;
    }
  }
}

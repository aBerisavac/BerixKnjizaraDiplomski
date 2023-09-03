using Application.DTOs.Genres;
using Application.DTOs.HomeParagraphs;
using Application.Exceptions;
using Application.Queries.HomeParagraphs;
using AutoMapper;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.HomeParagraphs
{
  public class EfGetHomeParagraph: IGetHomeParagraphQuery
  {
    private readonly DBKnjizaraContext _dbContext;
    private readonly IMapper _mapper;

    public int Id => 55;

    public string Name => "Get HomeParagraph";


    public EfGetHomeParagraph(DBKnjizaraContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public HomeParagraphDTO Execute(int id)
    {
      var homeParagraph = _dbContext.HomeParagraphs.Find(id);

      if (homeParagraph == null)
      {
        throw new EntityNotFoundException(id, typeof(HomeParagraph));
      }

      var response = _mapper.Map<HomeParagraphDTO>(homeParagraph);

      return response;
    }
  }
}

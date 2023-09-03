using Application.DTOs.Genres;
using Application.DTOs.HomeParagraphs;
using Application.Queries.HomeParagraphs;
using AutoMapper;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Queries.HomeParagraphs
{
  public class EfGetHomeParagraphs: IGetHomeParagraphsQuery
  {
    private readonly DBKnjizaraContext _dbContext;
    private readonly IMapper _mapper;

    public int Id => 54;

    public string Name => "Get Genres";

    public EfGetHomeParagraphs(DBKnjizaraContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public IEnumerable<HomeParagraphDTO> Execute(string searchTerm)
    {
      var query = _dbContext.HomeParagraphs.AsQueryable();

      if (!string.IsNullOrEmpty(searchTerm))
      {
        query = query.Where(x => x.Paragraph.Contains(searchTerm));
      }
      else
      {

      }

      return query.Select(x => _mapper.Map<HomeParagraphDTO>(x));
    }
  }
}

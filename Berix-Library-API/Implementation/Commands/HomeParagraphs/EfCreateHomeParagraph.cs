using Application.Commands.HomeParagraphs;
using Application.DTOs.Genres;
using Application.DTOs.HomeParagraphs;
using AutoMapper;
using Domain;
using EFDataAccess;
using FluentValidation;
using Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Commands.HomeParagraphs
{
  public class EfCreateHomeParagraph: IAddHomeParagraphCommand
  {
    private readonly IMapper _mapper;
    private readonly DBKnjizaraContext _dbContext;
    private readonly HomeParagraphDTOValidator _validator;

    public int Id => 51;

    public string Name => "Create HomeParagraph";

    public EfCreateHomeParagraph(IMapper mapper, DBKnjizaraContext dbContext, HomeParagraphDTOValidator validator)
    {
      _mapper = mapper;
      _dbContext = dbContext;
      _validator = validator;
    }

    public void Execute(HomeParagraphDTO request)
    {
      var homeParagraph = _mapper.Map<HomeParagraph>(request);

      _validator.ValidateAndThrow(request);

      _dbContext.Add(homeParagraph);
      _dbContext.SaveChanges();
    }
  }
}

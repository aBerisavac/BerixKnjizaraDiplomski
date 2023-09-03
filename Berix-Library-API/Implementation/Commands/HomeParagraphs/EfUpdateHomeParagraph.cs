using Application.Commands.HomeParagraphs;
using Application.DTOs.Genres;
using Application.DTOs.HomeParagraphs;
using Application.Exceptions;
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
  public class EfUpdateHomeParagraph: IEditHomeParagraphCommand
  {
    private readonly IMapper _mapper;
    private readonly DBKnjizaraContext _dbContext;
    private readonly HomeParagraphDTOValidator _validator;

    public int Id => 53;

    public string Name => "Update HomeParagraph";

    public EfUpdateHomeParagraph(IMapper mapper, DBKnjizaraContext dbContext, HomeParagraphDTOValidator validator)
    {
      _mapper = mapper;
      _dbContext = dbContext;
      _validator = validator;
    }

    public void Execute(HomeParagraphDTO request)
    {
      var homeParagraph = _dbContext.HomeParagraphs.Find(request.Id);

      if (homeParagraph == null)
      {
        throw new EntityNotFoundException(Id, typeof(HomeParagraph));
      }

      _validator.ValidateAndThrow(request);

      homeParagraph.Paragraph = request.Paragraph;

      _dbContext.SaveChanges();
    }
  }
}

using Application.Commands.Languages;
using Application.DTOs.Authors;
using Application.DTOs.Languages;
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

namespace Implementation.Commands.Languages
{
  public class EfUpdateLanguage: IEditLanguageCommand
  {
    private readonly IMapper _mapper;
    private readonly DBKnjizaraContext _dbContext;
    private readonly LanguageDTOValidator _validator;
    public int Id => 48;

    public string Name => "Update Language";

    public EfUpdateLanguage(IMapper mapper, DBKnjizaraContext dbContext, LanguageDTOValidator validator)
    {
      _mapper = mapper;
      _dbContext = dbContext;
      _validator = validator;
    }

    public void Execute(LanguageDTO request)
    {
      var language = _dbContext.Languages.Find(request.Id);

      if (language == null)
      {
        throw new EntityNotFoundException(Id, typeof(Language));
      }

      _validator.ValidateAndThrow(request);

      language.Name = request.Name;

      _dbContext.SaveChanges();
    }
  }
}

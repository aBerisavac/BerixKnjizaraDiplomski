using Application.Commands.Languages;
using Application.DTOs.Languages;
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
  public class EfCreateLanguage: IAddLanguageCommand
  {
    private readonly IMapper _mapper;
    private readonly DBKnjizaraContext _dbContext;
    private readonly LanguageDTOValidator _validator;
    public int Id => 46;

    public string Name => "Create Language";

    public EfCreateLanguage(IMapper mapper, DBKnjizaraContext dbContext, LanguageDTOValidator validator)
    {
      _mapper = mapper;
      _dbContext = dbContext;
      _validator = validator;
    }

    public void Execute(LanguageDTO request)
    {
      var language = _mapper.Map<Language>(request);

      _validator.ValidateAndThrow(request);

      _dbContext.Languages.Add(language);
      _dbContext.SaveChanges();
    }
  }
}

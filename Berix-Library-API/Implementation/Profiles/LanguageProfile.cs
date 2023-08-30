using Application.DTOs.Authors;
using Application.DTOs.Languages;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
  public class LanguageProfile: Profile
  {
    public LanguageProfile()
    {
      CreateMap<LanguageDTO, Language>();
      CreateMap<Language, LanguageDTO>();
    }
  }
}

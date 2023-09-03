using Application.DTOs.HomeParagraphs;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
  public class HomeParagraphProfile: Profile
  {
    public HomeParagraphProfile()
    {
      CreateMap<HomeParagraphDTO, HomeParagraph>();
      CreateMap<HomeParagraph, HomeParagraphDTO>();
    }
  }
}

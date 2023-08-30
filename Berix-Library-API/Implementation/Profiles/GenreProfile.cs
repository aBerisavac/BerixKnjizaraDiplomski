using Application.DTOs.Genres;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class GenreProfile: Profile
    {
        public GenreProfile()
        {
            CreateMap<Genre, GenreDTO>();
            CreateMap<GenreDTO, Genre>();
        }
    }
}

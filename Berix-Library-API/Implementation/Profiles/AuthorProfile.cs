using Application.DTOs.Authors;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<AuthorDTO, Author>();
            CreateMap<Author, AuthorDTO>();
        }
    }
}

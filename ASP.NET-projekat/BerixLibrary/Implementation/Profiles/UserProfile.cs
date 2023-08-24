using Application.DTOs.Authors;
using Application.DTOs.Books;
using Application.DTOs.Genres;
using Application.DTOs.Users;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
            CreateMap<User, UserInsertDTO>();
            CreateMap<UserInsertDTO, User>();
        }
    }
}

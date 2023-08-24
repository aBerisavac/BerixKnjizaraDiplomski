using Application.DTOs.IntersectEntities;
using Application.DTOs.UseCases;
using AutoMapper;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Profiles
{
    public class UseCaseProfile: Profile
    {
        public UseCaseProfile()
        {
            CreateMap<UseCaseDTO, UseCase>()
                .ForMember(dto => dto.Roles, opt => opt.MapFrom(dto => dto.Roles.Select(x => new RoleUseCase
                {
                    UseCaseId = x.UseCaseId,
                    RoleId = x.RoleId
                })));
                
            CreateMap<UseCase, UseCaseDTO>()
                .ForMember(dto => dto.Roles, opt => opt.MapFrom(dto => dto.Roles.Select(x => new RoleUseCaseDTO
            {
                UseCaseId = x.UseCaseId,
                RoleId = x.RoleId
            })));
        }
    }
}

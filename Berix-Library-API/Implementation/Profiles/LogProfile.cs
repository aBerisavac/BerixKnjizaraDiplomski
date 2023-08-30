using Application.DTOs.Logs;
using Application.DTOs.Orders;
using Application.DTOs.UseCases;
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
    public class LogProfile: Profile
    {
        public LogProfile()
        {
            CreateMap<Log, LogDTO>()
                .ForMember(dto => dto.Actor, logs => logs.MapFrom(log => new UserDTO
                {
                    FirstName = log.Actor.FirstName,
                    LastName = log.Actor.LastName,
                    Address = log.Actor.Address,
                    Email = log.Actor.Email,
                }))
                .ForMember(dto => dto.UseCase, logs => logs.MapFrom(log => new UseCaseDTO
                {
                    Id = log.UseCase.Id,
                    Name = log.UseCase.Name,
                }))
                ;
            CreateMap<LogDTO, Log>();
        }
    }
}

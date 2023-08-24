using Application.DTOs.IntersectEntities;
using Application.DTOs.Logs;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.UseCases
{
    public class UseCaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        virtual public ICollection<RoleUseCaseDTO>? Roles { get; set; } = new List<RoleUseCaseDTO>();
        virtual public ICollection<LogDTO>? Logs { get; set; } = new List<LogDTO>();
    }
}

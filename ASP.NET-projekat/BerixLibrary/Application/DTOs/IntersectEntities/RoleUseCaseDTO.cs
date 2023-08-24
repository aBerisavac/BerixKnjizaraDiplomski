using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.IntersectEntities
{
    public class RoleUseCaseDTO
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }
        public string? RoleName { get; set; }
    }
}

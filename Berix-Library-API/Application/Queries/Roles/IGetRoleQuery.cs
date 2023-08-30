using Application.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Roles
{
    public interface IGetRoleQuery : IQuery<int, RoleDTO>
    {
    }
}

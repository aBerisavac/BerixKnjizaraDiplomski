using Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Users
{
    public interface IGetUsersQuery : IQuery<string, IEnumerable<UserDTO>>
    {
    }
}

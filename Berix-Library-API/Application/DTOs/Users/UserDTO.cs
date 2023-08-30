using Application.DTOs.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Users
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }   
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public RoleDTO Role { get; set; }
    }
}

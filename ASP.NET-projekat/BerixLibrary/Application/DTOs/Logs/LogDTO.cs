using Application.DTOs.UseCases;
using Application.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Logs
{
    public class LogDTO
    {
        public int Id { get; set; }
        public string Data { get; set; }
        public UserDTO Actor { get; set; }
        public UseCaseDTO UseCase { get; set; }
    }
}

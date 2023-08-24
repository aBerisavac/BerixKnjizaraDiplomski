using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RoleUseCase
    {
        public int RoleId { get; set; }
        public int UseCaseId { get; set; }
        virtual public Role Role { get; set; }
        virtual public UseCase UseCase { get; set; }
    }
}

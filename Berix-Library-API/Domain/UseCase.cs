using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class UseCase : Entity
    { 
        public string Name { get; set; }
        virtual public ICollection<RoleUseCase>? Roles { get; set; } = new List<RoleUseCase>();
        virtual public ICollection<Log>? Logs { get; set; } = new List<Log>();
    }
}

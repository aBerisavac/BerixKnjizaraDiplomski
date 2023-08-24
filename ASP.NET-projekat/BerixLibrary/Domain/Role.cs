using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Role : Entity
    { 
        public string Name { get; set; }
        virtual public ICollection<User>? Users { get; set; } = new List<User>();
        virtual public ICollection<RoleUseCase>? UseCases { get; set; } = new List<RoleUseCase>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
  public class UnprocessableEntityException : Exception
  {
    public UnprocessableEntityException(int id, Type type) : base($"Entity of type {type.Name} with an id of {id}")
    {

    }
  }
}

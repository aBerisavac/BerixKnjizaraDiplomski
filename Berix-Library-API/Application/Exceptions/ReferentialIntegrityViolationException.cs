using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
  public class ReferentialIntegrityViolationException : Exception
  {
    public ReferentialIntegrityViolationException(Type constrainedType, Type constraintedByType): base($"Entity of type {constrainedType.Name} is referenced by {constraintedByType.Name}")
    {

    }
  }
}

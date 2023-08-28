using Application.DTOs.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Languages
{
  public interface IAddLanguageCommand: ICommand<LanguageDTO>
  {
  }
}

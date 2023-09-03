using Application.DTOs.HomeParagraphs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.HomeParagraphs
{
  public interface IGetHomeParagraphQuery: IQuery<int, HomeParagraphDTO>
  {
  }
}

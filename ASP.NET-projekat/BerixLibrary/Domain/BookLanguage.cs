using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public class BookLanguage: Entity
  {
    public int BookId { get; set; }
    public int LanguageId { get; set; }
    public Book Book { get; set; }
    public Language Language { get; set; }
  }
}

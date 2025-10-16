using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Models
{
    /// <summary>
    /// Статусы строка хранения
    /// </summary>
    public enum ExpirationDateType
    {
        None = 0,
        ShortTerm = 1,
        MediumTerm = 2,
        LongTerm = 3
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchiveContracts
{
    public record ArchiveCreated
    {
        public string ActivityKey { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
    }
}

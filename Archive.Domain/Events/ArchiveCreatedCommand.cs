using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Domain.Events
{
    public record ArchiveCreatedCommand
    {
        public string ActivityKey { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
    }
}

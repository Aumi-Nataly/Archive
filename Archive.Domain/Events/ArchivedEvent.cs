using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Domain.Events
{
    public class ArchivedEvent
    {
        public int ArchiveId { get; set; }
        public string ActivityKey { get; set; }
    }
}

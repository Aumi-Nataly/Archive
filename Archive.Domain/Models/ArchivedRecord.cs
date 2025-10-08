using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Domain.Models
{
    public class ArchivedRecord
    {
        public int Id { get; set; }
        public string ActivityKey { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
        public DateTime ArchivedDate { get; set; }

    }
}

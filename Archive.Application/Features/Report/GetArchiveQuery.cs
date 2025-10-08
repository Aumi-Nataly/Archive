using Archive.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Report
{
    public class GetArchiveQuery : IRequest<List<ArchivedRecordDto>>
    {
        public int Start { get; set; }
        public int Take { get; set; }
    }
}

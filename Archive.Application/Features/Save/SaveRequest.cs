using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Save
{
    public class SaveRequest : IRequest<bool>
    {
        public string ActivityKey { get; set; }
        public string Name { get; set; }
        public string Reason { get; set; }
    }
}

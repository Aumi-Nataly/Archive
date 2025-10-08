using Archive.Application.Models;
using Archive.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Report
{
    public class GetArchiveHandler : IRequestHandler<GetArchiveQuery, List<ArchivedRecordDto>>
    {
        private readonly IArchiveService _archiveService;

        public GetArchiveHandler(IArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        public async Task<List<ArchivedRecordDto>> Handle(GetArchiveQuery request, CancellationToken cancellationToken)
        {
            try
            {

                // Получение отчета
                var report = await _archiveService.GetRecordsAsync(request.Start,request.Take);

                return report;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

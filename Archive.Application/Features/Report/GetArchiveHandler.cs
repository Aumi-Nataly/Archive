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
    /// <summary>
    /// Получения архивных данных. 
    /// Реализация паттерна Command/Query Handler для обработки запросов на получение архива.
    /// </summary>
    public class GetArchiveHandler : IRequestHandler<GetArchiveQuery, List<ArchivedRecordDto>>
    {
        private readonly IArchiveService _archiveService;
        private readonly ILogger<GetArchiveHandler> _logger;

        public GetArchiveHandler(IArchiveService archiveService, ILogger<GetArchiveHandler> logger)
        {
            _archiveService = archiveService;
            _logger = logger;
        }

        public async Task<List<ArchivedRecordDto>> Handle(GetArchiveQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("GetArchiveHandler.Handle - Начата обработка запроса на получение архива");
              
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

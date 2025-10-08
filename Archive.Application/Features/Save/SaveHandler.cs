using Archive.Application.Models;
using Archive.Application.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Save
{
    public class SaveHandler : IRequestHandler<SaveRequest, bool>
    {
        private readonly IArchiveService _archiveService;

        public SaveHandler(IArchiveService archiveService)
        {
            _archiveService = archiveService;
        }

        public async Task<bool> Handle(SaveRequest request, CancellationToken cancellationToken)
        {
            // Валидация входных данных
            if (string.IsNullOrEmpty(request.ActivityKey))
                throw new ArgumentException("ActivityKey cannot be empty");

            // Создание DTO для сохранения
            var recordDto = new ArchivedRecordDto
            {
                ActivityKey = request.ActivityKey,
                Name = request.Name,
                Reason = request.Reason,
                ArchivedDate = DateTime.UtcNow
            };

            // Сохранение записи
            var savedRecord = await _archiveService.SaveRecordAsync(recordDto);

            return savedRecord.Id !=0;
        }
    }

}


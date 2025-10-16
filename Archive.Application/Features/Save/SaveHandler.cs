using Archive.Application.Features.Report;
using Archive.Application.Models;
using Archive.Application.Services;
using Archive.Domain.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Save
{    
     /// <summary>
     /// Сохранение данных в архив. 
     /// Оповещение подписчиков об успешном сохранении.
     /// Реализация паттерна Command/Query Handler.
     /// </summary>
    public class SaveHandler : IRequestHandler<SaveRequest, bool>
    {
        private readonly IArchiveService _archiveService;
        private readonly ILogger<SaveHandler> _logger;

        public SaveHandler(IArchiveService archiveService, ILogger<SaveHandler> logger)
        {
            _archiveService = archiveService;
            _logger = logger;
        }

        public async Task<bool> Handle(SaveRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Начата обработка команды сохранения");

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

            try
            {
                // Сохранение записи
                var savedRecord = await _archiveService.SaveRecordAsync(recordDto);

                _logger.LogInformation("Данные успешно сохранены в архив. ID: {Id}", savedRecord.Id);
                return savedRecord.Id != 0;
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Ошибка при сохранении данных");
                throw;
            }
        }
    }

}


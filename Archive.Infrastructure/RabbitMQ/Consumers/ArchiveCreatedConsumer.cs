using Archive.Application.Models;
using Archive.Application.Services;
using Archive.DataBase.Repository;
using Archive.DataBase.Repository;
using Archive.Domain.Events;
using Archive.Domain.Models;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Infrastructure.RabbitMQ.Consumers
{
    /// <summary>
    /// Обрабатывает уведомления о создании архивных записей. 
    /// </summary>
    public class ArchiveCreatedConsumer : IConsumer<ArchiveCreatedCommand>
    {
        private readonly IArchiveService _service;
        private readonly ILogger<ArchiveCreatedConsumer> _logger;
        public ArchiveCreatedConsumer(IArchiveService service, ILogger<ArchiveCreatedConsumer> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<ArchiveCreatedCommand> context)
        {
            try
            {
                _logger.LogInformation("Получено событие создания архива: {ActivityKey}", context.Message.ActivityKey);

                var message = context.Message;

                // Валидация входных данных
                if (string.IsNullOrEmpty(message.ActivityKey))
                    throw new ArgumentException("ActivityKey cannot be empty");

                // Создание DTO для сохранения
                var recordDto = new ArchivedRecordDto
                {
                    ActivityKey = message.ActivityKey,
                    Name = message.Name,
                    Reason = message.Reason
                };

                await _service.SaveRecordAsync(recordDto);
            }
            catch (Exception ex)
            {            
                throw;
            }
        }

    }
}

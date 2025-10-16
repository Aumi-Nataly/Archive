using Archive.Application.Mapper;
using Archive.Application.Models;
using Archive.Domain.Models;
using Archive.DataBase.Repository;
using Archive.Domain.Events;
using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static MassTransit.ValidationResultExtensions;

namespace Archive.Application.Services
{
    /// <summary>
    /// Реализация бизнес-логики обработки архивных записей и взаимодействие с хранилищем данных
    /// </summary>
    public class ArchiveService: IArchiveService
    {
        private readonly IArchiveRepository _repository;
        private readonly ILogger<ArchiveService> _logger;
        private readonly IPublishEndpoint _publishEndpoint;

        public ArchiveService(IArchiveRepository repository, 
            ILogger<ArchiveService> logger, IPublishEndpoint publishEndpoint)
        {
            _repository = repository;
            _logger = logger;
            _publishEndpoint = publishEndpoint;
        }

        public async Task<ArchivedRecord> SaveRecordAsync(ArchivedRecordDto recordDto)
        {
            _logger.LogInformation("SaveRecordAsync - Начата операция создания архивной записи");

            var entity = ArchivedRecordMapper.ToEntity(recordDto);
            await _repository.AddAsync(entity);

            // Публикация события
            await _publishEndpoint.Publish(
                new ArchivedEvent
                {
                    ArchiveId = entity.Id,
                    ActivityKey = entity.ActivityKey
                },
                new CancellationToken());

            return entity;
        }

        public async Task<List<ArchivedRecordDto>> GetRecordsAsync(int start, int take)
        {
            _logger.LogInformation("GetRecordsAsync - Запрос на получение архива Start = {Start}, Take = {Take}", start, take);

            var records = await _repository.GetAllAsync();

            return records.Select(r =>
            {
                var dto = ArchivedRecordMapper.ToDto(r);  
                return dto;
            }).OrderBy(x=>x.Id).Take(take).Skip(start).ToList();
  
        }

        public async Task<ArchivedRecordDto> GetRecordAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return ArchivedRecordMapper.ToDto(entity);
        }
    }
}

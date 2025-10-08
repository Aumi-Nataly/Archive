using Archive.Application.Mapper;
using Archive.Application.Models;
using Archive.Domain.Models;
using Archive.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Services
{
    public class ArchiveService: IArchiveService
    {
        private readonly IArchiveRepository _repository;

        public ArchiveService(IArchiveRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArchivedRecord> SaveRecordAsync(ArchivedRecordDto recordDto)
        {
            var entity = ArchivedRecordMapper.ToEntity(recordDto);
            await _repository.AddAsync(entity);
            return entity;
        }

        public async Task<List<ArchivedRecordDto>> GetRecordsAsync()
        {
            var records = await _repository.GetAllAsync();

            return records.Select(r =>
            {
                var dto = ArchivedRecordMapper.ToDto(r);  
                return dto;
            }).ToList();
  
        }

        public async Task<ArchivedRecordDto> GetRecordAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            return ArchivedRecordMapper.ToDto(entity);
        }
    }
}

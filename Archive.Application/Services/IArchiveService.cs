using Archive.Application.Models;
using Archive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Services
{
    public interface IArchiveService
    {
        Task<ArchivedRecord> SaveRecordAsync(ArchivedRecordDto recordDto);
        Task<List<ArchivedRecordDto>> GetRecordsAsync();

        Task<ArchivedRecordDto> GetRecordAsync(int id);

    }
}

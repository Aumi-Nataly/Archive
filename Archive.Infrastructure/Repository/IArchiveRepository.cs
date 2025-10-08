using Archive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Infrastructure.Repository
{
    public interface IArchiveRepository
    {
        Task<ArchivedRecord> GetByIdAsync(int id);
        Task<List<ArchivedRecord>> GetAllAsync();

        Task AddAsync(ArchivedRecord record);
        Task DeleteAsync(int id);
    }
}

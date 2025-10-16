using Archive.Domain.Models;
using Archive.DataBase.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DataBase.Repository
{
    public class ArchiveRepository: IArchiveRepository
    {
        private readonly ArchiveDbContext _context;

        public ArchiveRepository(ArchiveDbContext context)
        {
            _context = context;
        }

        public async Task<ArchivedRecord> GetByIdAsync(int id)
        {
            return await _context.ArchivedRecords.FirstOrDefaultAsync(x => x.Id == id);          
        }

        public async Task<List<ArchivedRecord>> GetAllAsync()
        {
            return await _context.ArchivedRecords.ToListAsync();
        }

        public async Task AddAsync(ArchivedRecord record)
        {
            await _context.ArchivedRecords.AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await GetByIdAsync(id);
            if (record != null)
            {
                _context.ArchivedRecords.Remove(record);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using Archive.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.DataBase.Data
{

        public class ArchiveDbContext : DbContext
        {
            public DbSet<ArchivedRecord> ArchivedRecords { get; set; }

            public ArchiveDbContext(DbContextOptions<ArchiveDbContext> options)
                : base(options) { }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);

                modelBuilder.ApplyConfiguration(new ArchivedRecordConfiguration());
                modelBuilder.HasDefaultSchema("archive");
            }
        }
   
}

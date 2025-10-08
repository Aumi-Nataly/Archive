using Archive.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Infrastructure.Data
{
    public class ArchivedRecordConfiguration : IEntityTypeConfiguration<ArchivedRecord>
    {
        public void Configure(EntityTypeBuilder<ArchivedRecord> builder)
        {
            
            builder.ToTable("archived_records");        
            builder.HasKey(ar => ar.Id);

            builder.Property(ar => ar.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(ar => ar.ActivityKey).HasColumnName("activity_key").IsRequired();

            builder.Property(ar => ar.Name).HasColumnName("name").IsRequired();

            builder.Property(ar => ar.Reason).HasColumnName("reason").IsRequired();

            builder.Property(ar => ar.ArchivedDate)
                .HasColumnName("archived_date")
                .HasColumnType("timestamp with time zone")
                .HasDefaultValueSql("NOW()");

            builder.HasIndex(ar => ar.ArchivedDate);
  
        }
    }
}

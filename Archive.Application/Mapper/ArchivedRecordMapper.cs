using Archive.Application.Models;
using Archive.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Mapper
{
    public static class ArchivedRecordMapper
    {

        // Метод для маппинга сущности в DTO
        public static ArchivedRecordDto ToDto(ArchivedRecord entity)
        {
            return new ArchivedRecordDto
            {
                Id = entity.Id,
                ActivityKey = entity.ActivityKey,
                ArchivedDate = entity.ArchivedDate,
                Name = entity.Name,
                Reason = entity.Reason,
                ExpirationType = CalculateExpirationType(entity.ArchivedDate)
            };
        }

        // Метод для маппинга DTO в сущность
        public static ArchivedRecord ToEntity(ArchivedRecordDto dto)
        {
            return new ArchivedRecord
            {
                Id = dto.Id,
                ActivityKey = dto.ActivityKey,
                ArchivedDate = dto.ArchivedDate,
                Name = dto.Name,
                Reason = dto.Reason
            };
        }

        // Метод расчета типа истечения срока
        private static ExpirationDateType CalculateExpirationType(DateTime archivedDate)
        {
            var now = DateTime.UtcNow;
            var daysSinceArchive = (now - archivedDate).Days;

            if (daysSinceArchive < 30)
                return ExpirationDateType.ShortTerm;
            else if (daysSinceArchive < 90)
                return ExpirationDateType.MediumTerm;
            else
                return ExpirationDateType.LongTerm;
        }
    }
}

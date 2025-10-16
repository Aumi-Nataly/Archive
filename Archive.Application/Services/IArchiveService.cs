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
        /// <summary>
        /// Сохранение записей
        /// </summary>
        /// <param name="recordDto"></param>
        /// <returns></returns>
        Task<ArchivedRecord> SaveRecordAsync(ArchivedRecordDto recordDto);

        /// <summary>
        /// Вывод списка записей
        /// </summary>
        /// <param name="start"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        Task<List<ArchivedRecordDto>> GetRecordsAsync(int start, int take);

        /// <summary>
        /// Получение записи по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ArchivedRecordDto> GetRecordAsync(int id);

    }
}

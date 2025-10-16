using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Models
{
    /// <summary>
    /// Представление архивной записи 
    /// </summary>
    public class ArchivedRecordDto
    {
        /// <summary>
        /// Уникальный ID записи
        /// </summary>
        public int Id { get; set; }
       
        /// <summary>
        /// Ключ записи
        /// </summary>
        public string ActivityKey { get; set; }
      
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Причина удаления
        /// </summary>
        public string Reason { get; set; }
        /// <summary>
        /// Дата архивации
        /// </summary>
        public DateTime ArchivedDate { get; set; }

        /// <summary>
        /// Статус срока хранения
        /// </summary>
        public ExpirationDateType ExpirationType { get; set; }
    }
}

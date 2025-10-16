using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Save
{
    /// <summary>
    /// Модель для сохранения записи в архив
    /// </summary>
    public class SaveRequest : IRequest<bool>
    {
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
    }
}

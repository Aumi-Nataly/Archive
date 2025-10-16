using Archive.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Archive.Application.Features.Report
{
    /// <summary>
    /// Модель для получения списка архива
    /// </summary>
    public class GetArchiveQuery : IRequest<List<ArchivedRecordDto>>
    {
        /// <summary>
        /// С какой позиции начать
        /// </summary>
        public int Start { get; set; }

        /// <summary>
        /// Сколько позиций взять
        /// </summary>
        public int Take { get; set; }
    }
}

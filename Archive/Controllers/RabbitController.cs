using Archive.Application.Features.Save;
using Archive.Domain.Events;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    public class RabbitController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public RabbitController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }


        /// <summary>
        /// Тестовый метод для проверки получения и обработки сообщения на сохранения в архив
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(SendToArchive_Test))]
        public async Task<IActionResult> SendToArchive_Test()
        {
            await _publishEndpoint.Publish(new ArchiveCreatedCommand
            {
                ActivityKey = "qwerty",
                Name = "Name",
                Reason = "Reason"
            });
            return Ok();
        }
    }
}

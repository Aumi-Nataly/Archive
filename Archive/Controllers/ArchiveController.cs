using Archive.Application.Features.Report;
using Archive.Application.Features.Save;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ArchiveController> _logger;

        public ArchiveController(IMediator mediator, ILogger<ArchiveController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Добавление записи в архив
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost(nameof(Save))]
        public async Task<IActionResult> Save([FromBody] SaveRequest request)
        {
            try
            {
                _logger.LogInformation("Начата обработка запроса на добавление в архив");

                var result = await _mediator.Send(request);

                _logger.LogInformation("Архив был создан? = {result}", result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Произошла ошибка при создании архива");
                return StatusCode(500, ex.Message);
            }
        }


        /// <summary>
        /// Получить список записей 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet(nameof(GetArchive))]
        public async Task<IActionResult> GetArchive([FromQuery] GetArchiveQuery request, CancellationToken cancellationToken)
        {
            try
            {
                _logger.LogInformation("Запрос на получение архива");

                var res = await _mediator.Send(request, cancellationToken);
              
                if (res == null || res.Count() == 0)
                {
                    _logger.LogWarning("Записи не найдены. Start = {Start}, Take = {Take}", request.Start, request.Take);
                    return NotFound();
                }

                _logger.LogInformation("Архив успешно получен");
                return Ok(res);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, "Произошла ошибка при получении архива с Start = {Start}, Take = {Take}", request.Start, request.Take);
                return StatusCode(500, ex.Message);
            }
        }
    }
}

using Archive.Application.Features.Report;
using Archive.Application.Features.Save;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Archive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArchiveController : Controller
    {
        private readonly IMediator _mediator;

        public ArchiveController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(nameof(Save))]
        public async Task<IActionResult> Save([FromBody] SaveRequest request)
        {
            try
            {
                var result = await _mediator.Send(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet(nameof(GetArchive))]
        public async Task<IActionResult> GetArchive([FromQuery] GetArchiveQuery request, CancellationToken cancellationToken)
        {
            var res = await _mediator.Send(request, cancellationToken);
            return Ok(res);
        }
    }
}

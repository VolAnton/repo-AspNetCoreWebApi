using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MetricsAgent.Features.Queries;
using MediatR;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/ram/available")]
    [ApiController]
    public class RamMetricsController : ControllerBase
    {
        private readonly ILogger<RamMetricsController> _logger;
        private readonly IMediator _mediator;

        public RamMetricsController(ILogger<RamMetricsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _logger.LogDebug(1, "NLog встроен в RamMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public async Task<IActionResult> GetMetricsByPeriod([FromRoute] RamMetricGetByPeriodQuery request)
        {
            _logger.LogInformation($"Parameters: {request}");
            
            var response = await _mediator.Send(request);
            
            return Ok(response);
        }
    }
}
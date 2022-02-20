using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MetricsManager.Features.Queries.Jobs;
using MetricsManager.Features.Commands.Jobs;


namespace MetricsManager.Controllers
{
    [Route("api/Jobs")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;
        private readonly IMediator _mediator;

        public JobsController(ILogger<AgentsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
        }
                
        [HttpGet]
        public async Task<IActionResult> GetJobNames()
        {
            _logger.LogDebug(1, "Getting Job Names");

            var response = await _mediator.Send(new GetJobsNamesQuery());

            return Ok(response);
        }
                
        [HttpPut("pause")]
        public async Task<IActionResult> PauseJob([FromBody] PauseJobCommand command)
        {
            _logger.LogInformation($"Pause job Parameters: command={command}");

            await _mediator.Send(command);

            return Ok();
        }
                
        [HttpPut("resume")]
        public async Task<IActionResult> ResumeJob([FromBody] ResumeJobCommand command)
        {
            _logger.LogInformation($"Resume job Parameters: command={command}");

            await _mediator.Send(command);

            return Ok();
        }
    }
}
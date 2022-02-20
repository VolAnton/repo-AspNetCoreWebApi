using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using MetricsManager.Features.Queries.Agents;
using MetricsManager.Features.Commands.Agents;


namespace MetricsManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgentsController : ControllerBase
    {
        private readonly ILogger<AgentsController> _logger;

        private readonly IMediator _mediator;

        public AgentsController(ILogger<AgentsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            _logger.LogDebug(1, "NLog встроен в AgentsController");
        }
                
        [HttpGet]
        public async Task<IActionResult> GetRegisteredAgents()
        {
            _logger.LogDebug(1, "Getting registered Agents List");

            var response = await _mediator.Send(new GetRegisteredAgentsQuery());

            return Ok(response);
        }
                
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAgent([FromBody] RegisterAgentCommand request)
        {
            _logger.LogInformation($"Register Agent Parameters: command={request}");

            var result = await _mediator.Send(request);

            return Ok(result);
        }
                
        [HttpPut("enable/{agentId}")]
        public async Task<IActionResult> EnableAgentById([FromRoute] EnableAgentByIdCommand request)
        {
            _logger.LogInformation($"EnableAgentById Parameters: command={request}");

            await _mediator.Send(request);

            return Ok();
        }
                
        [HttpPut("disable/{agentId}")]
        public async Task<IActionResult> DisableAgentById([FromRoute] DisableAgentByIdCommand request)
        {
            _logger.LogInformation($"DisableAgentById Parameters: command={request}");

            await _mediator.Send(request);

            return Ok();
        }
    }
}
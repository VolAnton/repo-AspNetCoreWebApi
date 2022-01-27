using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using MetricsAgent.Models.Dto;
using MetricsAgent.Models.Metrics;
using MetricsAgent.Models.Repositories;
using MetricsAgent.Models.Requests;
using MetricsAgent.Models.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MetricsAgent.Controllers
{
    [Route("api/metrics/hdd/left")]
    [ApiController]
    public class HddMetricsController : ControllerBase
    {
        private IMapper _mapper;
        private IHddMetricsRepository _repository;
        private readonly ILogger<HddMetricsController> _logger;

        public HddMetricsController(IHddMetricsRepository repository, ILogger<HddMetricsController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsAgent.HddMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromTimePeriod([FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
        {
            _logger.LogDebug("MetricsAgent.HddMetricsController.GetMetricsFromTimePeriod вызван.");

            var metrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new HddMetricsResponse()

            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] HddMetricCreateRequest request)
        {
            _logger.LogDebug("MetricsAgent.HddMetricsController.Create вызван.");
            _repository.Create(new HddMetric
            {
                Value = request.Value,
                Time = request.Time
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogDebug("MetricsAgent.HddMetricsController.GetAll вызван.");

            var metrics = _repository.GetAll();
            var response = new HddMetricsResponse()

            {
                Metrics = new List<HddMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<HddMetricDto>(metric));
            }

            return Ok(response);

        }
    }
}

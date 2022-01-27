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
    [Route("api/metrics/dotnet/errors-count")]
    [ApiController]
    public class DotNetMetricsController : ControllerBase
    {
        private IMapper _mapper;
        private IDotNetMetricsRepository _repository;
        private readonly ILogger<DotNetMetricsController> _logger;

        public DotNetMetricsController(IDotNetMetricsRepository repository, ILogger<DotNetMetricsController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsAgent.DotNetMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromTimePeriod([FromRoute]TimeSpan fromTime, [FromRoute]TimeSpan toTime)
        {
            _logger.LogDebug("MetricsAgent.DotNetMetricsController.GetMetricsFromTimePeriod вызван.");

            var metrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new DotNetMetricsResponse()

            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] DotNetMetricCreateRequest request)
        {
            _logger.LogDebug("MetricsAgent.DotNetMetricsController.Create вызван.");
            _repository.Create(new DotNetMetric
            {
                ValueDownload = request.ValueDownload,
                ValueUpload = request.ValueUpload,
                Time = request.Time
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogDebug("MetricsAgent.DotNetMetricsController.GetAll вызван.");
            var metrics = _repository.GetAll();

            var response = new DotNetMetricsResponse()
            {
                Metrics = new List<DotNetMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<DotNetMetricDto>(metric));
            }

            return Ok(response);

        }
    }
}
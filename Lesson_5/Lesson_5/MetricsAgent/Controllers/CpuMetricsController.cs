﻿using System;
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
    [Route("api/metrics/cpu")]
    [ApiController]
    public class CpuMetricsController : ControllerBase
    {
        private ICpuMetricsRepository _repository;
        private readonly ILogger<CpuMetricsController> _logger;
        private IMapper _mapper;        

        public CpuMetricsController(ICpuMetricsRepository repository, ILogger<CpuMetricsController> logger, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
            _logger = logger;
            _logger.LogDebug(1, "NLog встроен в MetricsAgent.CpuMetricsController");
        }

        [HttpGet("from/{fromTime}/to/{toTime}")]
        public IActionResult GetMetricsFromTimePeriod([FromRoute]TimeSpan fromTime, [FromRoute]TimeSpan toTime)
        {
            _logger.LogDebug("MetricsAgent.CpuMetricsController.GetMetricsFromTimePeriod вызван.");

            var metrics = _repository.GetByTimePeriod(fromTime, toTime);
            var response = new CpuMetricsResponse()

            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            return Ok(response);
        }

        [HttpPost("create")]
        public IActionResult Create([FromBody] CpuMetricCreateRequest request)
        {
            _logger.LogDebug("MetricsAgent.CpuMetricsController.Create вызван.");
            _repository.Create(new CpuMetric
            {
                Value = request.Value,
                Time = request.Time
            });

            return Ok();
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            _logger.LogDebug("MetricsAgent.CpuMetricsController.GetAll вызван.");
            var metrics = _repository.GetAll();

            var response = new CpuMetricsResponse()
            {
                Metrics = new List<CpuMetricDto>()
            };

            foreach (var metric in metrics)
            {
                response.Metrics.Add(_mapper.Map<CpuMetricDto>(metric));
            }

            return Ok(response);

        }
    }
}
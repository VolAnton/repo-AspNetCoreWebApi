using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models.Metrics;
using MetricsAgent.Models.Repositories;
using MetricsAgent.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentUnitTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<ICpuMetricsRepository> _mockRepo;
        private Mock<ILogger<CpuMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public CpuMetricsControllerUnitTests()
        {
            _mockRepo = new Mock<ICpuMetricsRepository>();
            _mockLogger = new Mock<ILogger<CpuMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new CpuMetricsController(_mockRepo.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetByTimePeriod_Should_Return_Ok()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(50);

            var result = _controller.GetMetricsFromTimePeriod(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void Create_ShouldCall_Create_From_Repository()
        {
            _mockRepo.Setup(_repository => _repository.Create(It.IsAny<CpuMetric>())).Verifiable();

            var result = _controller.Create(new CpuMetricCreateRequest { Time = TimeSpan.FromSeconds(1), Value = 50 });

            _mockRepo.Verify(_repository => _repository.Create(It.IsAny<CpuMetric>()), Times.AtMostOnce());
        }

        [Fact]
        public void GetAll_Should_Return_Ok()
        {
            _mockRepo.Setup(_repository => _repository.GetAll()).Verifiable();

            var result = _controller.GetAll();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}

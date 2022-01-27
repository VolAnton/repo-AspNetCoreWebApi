using AutoMapper;
using MetricsAgent.Controllers;
using MetricsAgent.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace MetricsAgentUnitTests
{
    public class RamMetricsControllerUnitTests
    {
        private RamMetricsController _controller;
        private Mock<RamMetricsRepository> _mockRepo;
        private Mock<ILogger<RamMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public RamMetricsControllerUnitTests()
        {
            _mockRepo = new Mock<RamMetricsRepository>();
            _mockLogger = new Mock<ILogger<RamMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new RamMetricsController(_mockRepo.Object, _mockLogger.Object, _mockMapper.Object);
        }

        [Fact]
        public void GetByTimePeriod_ReturnsOk()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(50);

            var result = _controller.GetMetricsFromTimePeriod(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

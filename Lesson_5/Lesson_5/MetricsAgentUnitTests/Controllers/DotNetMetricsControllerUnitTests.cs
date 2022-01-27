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
    public class DotNetMetricsControllerUnitTests
    {
        private DotNetMetricsController _controller;
        private Mock<DotNetMetricsRepository> _mockRepo;
        private Mock<ILogger<DotNetMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public DotNetMetricsControllerUnitTests()
        {
            _mockRepo = new Mock<DotNetMetricsRepository>();
            _mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new DotNetMetricsController(_mockRepo.Object, _mockLogger.Object, _mockMapper.Object);
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

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
    public class HddMetricsControllerUnitTests
    {
        private HddMetricsController _controller;
        private Mock<HddMetricsRepository> _mockRepo;
        private Mock<ILogger<HddMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public HddMetricsControllerUnitTests()
        {
            _mockRepo = new Mock<HddMetricsRepository>();
            _mockLogger = new Mock<ILogger<HddMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new HddMetricsController(_mockRepo.Object, _mockLogger.Object, _mockMapper.Object);
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

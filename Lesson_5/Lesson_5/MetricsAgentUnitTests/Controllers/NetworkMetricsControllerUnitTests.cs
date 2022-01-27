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
    public class NetworkMetricsControllerUnitTests
    {
        private NetworkMetricsController _controller;
        private Mock<NetworkMetricsRepository> _mockRepo;
        private Mock<ILogger<NetworkMetricsController>> _mockLogger;
        private Mock<IMapper> _mockMapper;

        public NetworkMetricsControllerUnitTests()
        {
            _mockRepo = new Mock<NetworkMetricsRepository>();
            _mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            _mockMapper = new Mock<IMapper>();
            _controller = new NetworkMetricsController(_mockRepo.Object, _mockLogger.Object, _mockMapper.Object);
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

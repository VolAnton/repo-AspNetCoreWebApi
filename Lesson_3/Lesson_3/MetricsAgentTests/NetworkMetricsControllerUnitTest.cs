using System;
using System.Collections.Generic;
using System.Text;
using MetricsAgent.Controllers;
using MetricsAgent.Models.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _controller;
        private Mock<NetworkMetricsRepository> _mockRepo;
        private Mock<ILogger<NetworkMetricsController>> _mockLogger;

        public NetworkMetricsControllerUnitTest()
        {
            _mockRepo = new Mock<NetworkMetricsRepository>();
            _mockLogger = new Mock<ILogger<NetworkMetricsController>>();
            _controller = new NetworkMetricsController(_mockRepo.Object, _mockLogger.Object);
        }

        [Fact]
        public void GetMetricsFromTimePeriod_ReturnsOk()
        {
            //arrange

            TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            TimeSpan timeTo = TimeSpan.FromSeconds(100);

            //act
            var result = _controller.GetMetricsFromTimePeriod(timeFrom, timeTo);

            // assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

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
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _controller;
        private Mock<HddMetricsRepository> _mockRepo;
        private Mock<ILogger<HddMetricsController>> _mockLogger;

        public HddMetricsControllerUnitTest()
        {
            _mockRepo = new Mock<HddMetricsRepository>();
            _mockLogger = new Mock<ILogger<HddMetricsController>>();
            _controller = new HddMetricsController(_mockRepo.Object, _mockLogger.Object);
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

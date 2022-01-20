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
    public class DotNetMetricsControllerUnitTest
    {

        private DotNetMetricsController _controller;
        private Mock<DotNetMetricsRepository> _mockRepo;
        private Mock<ILogger<DotNetMetricsController>> _mockLogger;

        public DotNetMetricsControllerUnitTest()
        {
            _mockRepo = new Mock<DotNetMetricsRepository>();
            _mockLogger = new Mock<ILogger<DotNetMetricsController>>();
            _controller = new DotNetMetricsController(_mockRepo.Object, _mockLogger.Object);
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

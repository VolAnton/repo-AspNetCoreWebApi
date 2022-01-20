using System;
using System.Collections.Generic;
using System.Text;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;
using MetricsAgent.Models.Interfaces;
using Microsoft.Extensions.Logging;
using MetricsAgent.Models.Repositories;
using MetricsAgent.Models.Requests;
using MetricsAgent.Models.Metrics;

namespace MetricsAgentTests
{
    public class CpuMetricsControllerUnitTests
    {
        private CpuMetricsController _controller;
        private Mock<CpuMetricsRepository> _mockRepo;
        private Mock<ILogger<CpuMetricsController>> _mockLogger;


        public CpuMetricsControllerUnitTests()
        {
            _mockRepo = new Mock<CpuMetricsRepository>();
            _mockLogger = new Mock<ILogger<CpuMetricsController>>();
            _controller = new CpuMetricsController(_mockRepo.Object, _mockLogger.Object);
        }
        [Fact]
        public void GetMetricsFromTimePeriod_ReturnsOk()
        {
            //Arrange            
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            //Act
            var result = _controller.GetMetricsFromTimePeriod(fromTime, toTime);

            // Assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsManagerTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _controller;

        public HddMetricsControllerUnitTest()
        {
            _controller = new HddMetricsController();
        }

        [Fact]
        public void GetMetrics_ReturnsOk()
        {
            //arrange
            var agentId = 1;
            TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            TimeSpan timeTo = TimeSpan.FromSeconds(100);

            //act
            var result = _controller.GetMetric(agentId, timeFrom, timeTo);

            // assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void GetMetricsFromCluster_ReturnsOK()
        {
            var fromTime = TimeSpan.FromSeconds(0);
            var toTime = TimeSpan.FromSeconds(100);

            var result = _controller.GetMetricsFromAllCluster(fromTime, toTime);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}

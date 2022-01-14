using System;
using System.Collections.Generic;
using System.Text;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class NetworkMetricsControllerUnitTest
    {
        private NetworkMetricsController _controller;

        public NetworkMetricsControllerUnitTest()
        {
            _controller = new NetworkMetricsController();
        }

        [Fact]
        public void GetNetworkMetrics_ReturnsOk()
        {
            //arrange

            TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            TimeSpan timeTo = TimeSpan.FromSeconds(100);

            //act
            var result = _controller.GetNetworkMetric(timeFrom, timeTo);

            // assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

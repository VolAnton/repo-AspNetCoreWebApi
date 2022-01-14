using System;
using System.Collections.Generic;
using System.Text;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class DotNetMetricsControllerUnitTest
    {

        private DotNetMetricsController _controller;

        public DotNetMetricsControllerUnitTest()
        {
            _controller = new DotNetMetricsController();
        }

        [Fact]
        public void GetDotNetMetrics_ReturnsOk()
        {
            //arrange

            TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            TimeSpan timeTo = TimeSpan.FromSeconds(100);

            //act
            var result = _controller.GetDotNetMetric(timeFrom, timeTo);

            // assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

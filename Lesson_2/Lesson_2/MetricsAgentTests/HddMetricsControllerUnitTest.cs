using System;
using System.Collections.Generic;
using System.Text;
using MetricsAgent.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace MetricsAgentTests
{
    public class HddMetricsControllerUnitTest
    {
        private HddMetricsController _controller;

        public HddMetricsControllerUnitTest()
        {
            _controller = new HddMetricsController();
        }

        [Fact]
        public void GetHddMetrics_ReturnsOk()
        {
            //arrange

            TimeSpan timeFrom = TimeSpan.FromSeconds(0);
            TimeSpan timeTo = TimeSpan.FromSeconds(100);

            //act
            var result = _controller.GetHddMetric(timeFrom, timeTo);

            // assert
            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }
    }
}

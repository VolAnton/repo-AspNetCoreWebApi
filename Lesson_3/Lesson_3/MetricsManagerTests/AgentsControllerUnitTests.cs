using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MetricsManagerTests
{
    public class AgentsControllerUnitTests
    {
        private AgentsController _controller;
        private Mock<ILogger<AgentsController>> _mockLogger;

        public AgentsControllerUnitTests()
        {
            _mockLogger = new Mock<ILogger<AgentsController>>();
            _controller = new AgentsController(_mockLogger.Object);
        }

        [Fact]
        public void GetRegisteredAgents_ReturnsOK()
        {
            var result = _controller.GetRegisteredAgents();

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void EnableAgentById_ReturnsOK()
        {
            int agentId = 1;

            var result = _controller.EnableAgentById(agentId);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void DisableAgentById_ReturnsOK()
        {
            int agentId = 1;

            var result = _controller.DisableAgentById(agentId);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

        [Fact]
        public void RegisterAgent_ReturnsOK()
        {
            var agentInfo = new AgentInfo()
            {
                AgentId = 1,
                AgentAddress = new Uri(@"http:\\192.168.1.6:5000")
            };

            var result = _controller.RegisterAgent(agentInfo);

            _ = Assert.IsAssignableFrom<IActionResult>(result);
        }

    }
}

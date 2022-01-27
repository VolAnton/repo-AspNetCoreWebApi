using MetricsAgent.Models.Metrics;
using MetricsAgent.Models.Repositories;
using Quartz;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Jobs
{
    public class NetworkMetricJob : IJob
    {
        private INetworkMetricsRepository _repository;
        private PerformanceCounter _networkCounter;

        public NetworkMetricJob(INetworkMetricsRepository repository)
        {
            _networkCounter = new PerformanceCounter("Network", "Available");
            _repository = repository;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            var networkAviable = Convert.ToInt32(_networkCounter.NextValue());

            _repository.Create(new NetworkMetric { Time = time, Value = networkAviable });

            return Task.CompletedTask;
        }
    }
}

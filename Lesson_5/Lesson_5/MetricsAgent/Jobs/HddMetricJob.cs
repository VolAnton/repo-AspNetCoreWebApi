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
    public class HddMetricJob : IJob
    {
        private IHddMetricsRepository _repository;
        private PerformanceCounter _hddCounter;

        public HddMetricJob(IHddMetricsRepository repository)
        {
            _hddCounter = new PerformanceCounter("Hdd", "Available MBytes");
            _repository = repository;
        }
        public Task Execute(IJobExecutionContext context)
        {
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());
            var hddAviable = Convert.ToInt32(_hddCounter.NextValue());

            _repository.Create(new HddMetric { Time = time, Value = hddAviable });

            return Task.CompletedTask;
        }
    }
}

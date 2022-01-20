using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class NetworkMetricsResponse
    {
        public IList<NetworkMetricDto> Metrics { get; set; }

    }

    public class NetworkMetricDto
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public TimeSpan Time { get; set; }
    }

}

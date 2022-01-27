using MetricsAgent.Models.Dto;
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
}

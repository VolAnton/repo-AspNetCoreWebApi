using MetricsAgent.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class HddMetricsResponse
    {
        public IList<HddMetricDto> Metrics { get; set; }
    }
}

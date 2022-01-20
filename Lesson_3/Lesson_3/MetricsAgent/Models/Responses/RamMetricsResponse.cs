using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class RamMetricsResponse
    {
        public IList<RamMetricDto> Metrics { get; set; }

    }

    public class RamMetricDto
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public TimeSpan Time { get; set; }
    }

}
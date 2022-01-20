using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Models.Responses
{
    public class DotNetMetricsResponse
    {
        public IList<DotNetMetricDto> Metrics { get; set; }

    }

    public class DotNetMetricDto
    {
        public int Id { get; set; }

        public int Value { get; set; }

        public TimeSpan Time { get; set; }
    }

}

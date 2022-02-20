using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerClient.DAL.DotNet
{
    public class DotNetMetricResponse
    {
        public List<DotNetMetricDto> Metrics { get; set; } = new List<DotNetMetricDto>();
    }
}

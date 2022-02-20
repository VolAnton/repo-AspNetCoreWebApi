using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerClient.DAL.Hdd
{
    public class HddMetricResponse
    {
        public List<HddMetricDto> Metrics { get; set; } = new List<HddMetricDto>();
    }
}

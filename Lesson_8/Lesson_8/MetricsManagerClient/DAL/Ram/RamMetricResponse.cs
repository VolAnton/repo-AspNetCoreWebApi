using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerClient.DAL.Ram
{
    public class RamMetricResponse
    {
        public List<RamMetricDto> Metrics { get; set; } = new List<RamMetricDto>();
    }
}

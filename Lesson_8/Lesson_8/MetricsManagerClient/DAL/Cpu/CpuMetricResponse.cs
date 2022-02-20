using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetricsManagerClient.DAL.Cpu
{
    public class CpuMetricResponse
    {
        public List<CpuMetricDto> Metrics { get; set; } = new List<CpuMetricDto>();
    }
}

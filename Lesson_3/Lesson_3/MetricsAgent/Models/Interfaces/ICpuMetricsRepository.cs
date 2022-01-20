using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models.Metrics;

namespace MetricsAgent.Models.Interfaces
{
    public class ICpuMetricsRepository : IRepository<CpuMetric>
    {
        public void Create(CpuMetric item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CpuMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public CpuMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CpuMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            throw new NotImplementedException();
        }

        public void Update(CpuMetric item)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models.Metrics;

namespace MetricsAgent.Models.Interfaces
{
    public class IHddMetricsRepository : IRepository<HddMetric>
    {
        public void Create(HddMetric item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<HddMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public HddMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<HddMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            throw new NotImplementedException();
        }

        public void Update(HddMetric item)
        {
            throw new NotImplementedException();
        }
    }
}

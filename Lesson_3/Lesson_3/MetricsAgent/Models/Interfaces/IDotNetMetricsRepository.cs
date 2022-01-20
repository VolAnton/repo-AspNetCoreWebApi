using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models.Metrics;

namespace MetricsAgent.Models.Interfaces
{
    public class IDotNetMetricsRepository : IRepository<DotNetMetric>
    {
        public void Create(DotNetMetric item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DotNetMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public DotNetMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<DotNetMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            throw new NotImplementedException();
        }

        public void Update(DotNetMetric item)
        {
            throw new NotImplementedException();
        }
    }
}

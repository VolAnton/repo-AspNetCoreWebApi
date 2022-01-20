using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models.Metrics;

namespace MetricsAgent.Models.Interfaces
{
    public class INetworkMetricsRepository : IRepository<NetworkMetric>
    {
        public void Create(NetworkMetric item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<NetworkMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public NetworkMetric GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IList<NetworkMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            throw new NotImplementedException();
        }

        public void Update(NetworkMetric item)
        {
            throw new NotImplementedException();
        }
    }
}

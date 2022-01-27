using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.Models.Repositories
{
    public class NetworkMetricsRepository : INetworkMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public NetworkMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO cpumetrics(value, time) VALUES(@value, @time)",
                    new
                    {
                        value = item.Value,
                        time = item.Time.TotalSeconds
                    });
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Execute("DELETE FROM cpumetrics WHERE id=@id",
                new
                {
                    id = id
                });
        }

        public void Update(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Execute("UPDATE cpumetrics SET value = @value, time = @time WHERE id=@id;",
                new
                {
                    value = item.Value,
                    time = item.Time,
                    id = item.Id
                });
        }

        public IList<NetworkMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Query<NetworkMetric>("SELECT Id, Time, Value FROM cpumetrics").ToList();
        }

        public IList<NetworkMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Query<NetworkMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE @fromTime <= Time <= @toTime",
                new
                {
                    fromTime,
                    toTime
                }).ToList();
        }

        public NetworkMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<NetworkMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE id=@id",
                    new { id = id });
            }
        }
    }
}

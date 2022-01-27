using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.Models.Repositories
{
    public class HddMetricsRepository : IHddMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public HddMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }

        public void Create(HddMetric item)
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

        public void Update(HddMetric item)
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

        public IList<HddMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Query<HddMetric>("SELECT Id, Time, Value FROM cpumetrics").ToList();
        }

        public IList<HddMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Query<HddMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE @fromTime <= Time <= @toTime",
                new
                {
                    fromTime,
                    toTime
                }).ToList();
        }

        public HddMetric GetById(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                return connection.QuerySingle<HddMetric>("SELECT Id, Time, Value FROM cpumetrics WHERE id=@id",
                    new { id = id });
            }
        }
    }
}

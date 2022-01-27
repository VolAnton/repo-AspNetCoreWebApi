using Dapper;
using MetricsAgent.DAL;
using MetricsAgent.Models.Metrics;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;

namespace MetricsAgent.Models.Repositories
{
    public class DotNetMetricsRepository : IDotNetMetricsRepository
    {
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public DotNetMetricsRepository()
        {
            SqlMapper.AddTypeHandler(new TimeSpanHandler());
        }


        public void Create(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("INSERT INTO netmetrics(ValueDownload, ValueUpload, Time) VALUES(@ValueDownload, @ValueUpload, @Time)",
                    new
                    {
                        ValueDownload = item.ValueDownload,
                        ValueUpload = item.ValueUpload,
                        Time = item.Time
                    });
            }
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("DELETE FROM netmetrics WHERE Id = @Id",
                    new
                    {
                        Id = id
                    });
            }
        }

        public void Update(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                connection.Execute("UPDATE netmetrics SET ValueDownload = @ValueDownload, ValueUpload = @ValueUpload, Time = @Time WHERE Id=@Id;",
                    new
                    {
                        Time = item.Time,
                        ValueDownload = item.ValueDownload,
                        ValueUpload = item.ValueUpload,
                        Id = item.Id
                    });
            }
        }

        public IList<DotNetMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<DotNetMetric>("SELECT Id, ValueDownload, ValueUpload, Time FROM netmetrics").ToList();
            }
        }

        public IList<DotNetMetric> GetByTimePeriod(TimeSpan fromTime, TimeSpan toTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.Query<DotNetMetric>("SELECT Id, ValueDownload, ValueUpload, Time FROM netmetrics WHERE @fromTime <= Time AND Time <= @toTime",
                    new
                    {
                        fromTime,
                        toTime
                    }).ToList();
            }
        }

        public DotNetMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            {
                return connection.QuerySingle<DotNetMetric>("SELECT Id, ValueDownload, ValueUpload, Time FROM netmetrics WHERE Id=@Id",
                    new 
                    {
                    Id = id
                    });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.IO;
using LiveCharts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace MetricsManagerClient.DAL.Ram
{
    public sealed class RamClient
    {
        public static List<RamMetricDto> ramList = new List<RamMetricDto>();

        private RamMetricResponse _allRamMetricsResponse;

        private readonly HttpClient _client;

        private readonly DateTime _now = DateTime.Now;

        public RamMetricResponse AllRamMetricsResponse
        {
            get { return _allRamMetricsResponse; }

            set { _allRamMetricsResponse = value; }
        }

        public DateTime Now
        {
            get { return _now; }
        }

        public RamClient()
        {           
            _client = new HttpClient();
            Task<RamMetricResponse> data = GetMetrics();
        }
        
        public async Task<RamMetricResponse> GetMetrics()
        {            
            try
            {                
                string fromTime = $"{(Now - TimeSpan.FromSeconds(100)):s}";
                string toTime = $"{Now:s}";
                string url = $"https://localhost:5001/api/metrics/ram/available/agent/1/from/{fromTime}/to/{toTime}"; // Available bbytes

                // https://localhost:5001/api/metrics/dotnet/errors-count/agent/1/from/{fromTime}/to/{toTime} CLR Memory gen 1 heap size
                // https://localhost:5001/api/metrics/network/agent/1/from/{fromTime}/to/{toTime}  Bytes sent in second
                // https://localhost:5001/api/metrics/ram/available/agent/1/from/{fromTime}/to/{toTime} Available bbytes

                HttpResponseMessage response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                Stream stream = response.Content.ReadAsStreamAsync().Result;

                AllRamMetricsResponse = JsonSerializer.DeserializeAsync<RamMetricResponse>(stream).Result;

                ramList.Clear();
                ramList.AddRange(AllRamMetricsResponse.Metrics.ToList());               

                return AllRamMetricsResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            //CpuChart.ColumnSeriesValues[0].Values = new ChartValues<double> { 17, 10, 5, 55, 65, 35, 22, 60, 33, 53 };
           // MaterialCards.Column

            return null;
        }
    }
}


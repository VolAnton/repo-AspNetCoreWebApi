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


namespace MetricsManagerClient.DAL.Hdd
{
    public sealed class HddClient
    {

        public static List<HddMetricDto> hddList = new List<HddMetricDto>();

        private HddMetricResponse _allHddMetricsResponse;

        private readonly HttpClient _client;

        private readonly DateTime _now = DateTime.Now;

        public HddMetricResponse AllHddMetricsResponse
        {
            get { return _allHddMetricsResponse; }

            set { _allHddMetricsResponse = value; }
        }

        public DateTime Now
        {
            get { return _now; }
        }

        public HddClient()
        {           
            _client = new HttpClient();
            Task<HddMetricResponse> data = GetMetrics();
        }
        
        public async Task<HddMetricResponse> GetMetrics()
        {            
            try
            {                
                string fromTime = $"{(Now - TimeSpan.FromSeconds(100)):s}";
                string toTime = $"{Now:s}";
                string url = $"https://localhost:5001/api/metrics/hdd/left/agent/1/from/{fromTime}/to/{toTime}"; // Disk Time

                // https://localhost:5001/api/metrics/dotnet/errors-count/agent/1/from/{fromTime}/to/{toTime} CLR Memory gen 1 heap size
                // https://localhost:5001/api/metrics/network/agent/1/from/{fromTime}/to/{toTime}  Bytes sent in second
                // https://localhost:5001/api/metrics/ram/available/agent/1/from/{fromTime}/to/{toTime} Available bbytes

                HttpResponseMessage response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                Stream stream = response.Content.ReadAsStreamAsync().Result;

                AllHddMetricsResponse = JsonSerializer.DeserializeAsync<HddMetricResponse>(stream).Result;

                hddList.Clear();
                hddList.AddRange(AllHddMetricsResponse.Metrics.ToList());               

                return AllHddMetricsResponse;
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


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


namespace MetricsManagerClient.DAL.Cpu
{
    public sealed class CpuClient
    {

        public static List<CpuMetricDto> cpuList = new List<CpuMetricDto>();

        private CpuMetricResponse _allCpuMetricsResponse;

        private readonly HttpClient _client;

        private readonly DateTime _now = DateTime.Now;

        public CpuMetricResponse AllCpuMetricsResponse
        {
            get { return _allCpuMetricsResponse; }

            set { _allCpuMetricsResponse = value; }
        }

        public DateTime Now
        {
            get { return _now; }
        }

        public CpuClient()
        {           
            _client = new HttpClient();
            Task<CpuMetricResponse> data = GetMetrics();
        }
        
        public async Task<CpuMetricResponse> GetMetrics()
        {            
            try
            {                
                string fromTime = $"{(Now - TimeSpan.FromSeconds(100)):s}";
                string toTime = $"{Now:s}";
                string url = $"https://localhost:5001/api/metrics/cpu/agent/1/from/{fromTime}/to/{toTime}";                

                HttpResponseMessage response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                Stream stream = response.Content.ReadAsStreamAsync().Result;
                
                AllCpuMetricsResponse = JsonSerializer.DeserializeAsync<CpuMetricResponse>(stream).Result;

                cpuList.Clear();
                cpuList.AddRange(AllCpuMetricsResponse.Metrics.ToList());               

                return AllCpuMetricsResponse;
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


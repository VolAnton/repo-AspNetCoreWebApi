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


namespace MetricsManagerClient.DAL.DotNet
{
    public sealed class DotNetClient
    {
        public static List<DotNetMetricDto> dotNetList = new List<DotNetMetricDto>();

        private DotNetMetricResponse _allDotNetMetricsResponse;

        private readonly HttpClient _client;

        private readonly DateTime _now = DateTime.Now;

        public DotNetMetricResponse AllDotNetMetricsResponse
        {
            get { return _allDotNetMetricsResponse; }

            set { _allDotNetMetricsResponse = value; }
        }

        public DateTime Now
        {
            get { return _now; }
        }

        public DotNetClient()
        {           
            _client = new HttpClient();
            Task<DotNetMetricResponse> data = GetMetrics();
        }
        
        public async Task<DotNetMetricResponse> GetMetrics()
        {            
            try
            {                
                string fromTime = $"{(Now - TimeSpan.FromSeconds(100)):s}";
                string toTime = $"{Now:s}";
                string url = $"https://localhost:5001/api/metrics/dotnet/errors-count/agent/1/from/{fromTime}/to/{toTime}"; // CLR Memory gen 1 heap size
                               
                HttpResponseMessage response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                Stream stream = response.Content.ReadAsStreamAsync().Result;

                AllDotNetMetricsResponse = JsonSerializer.DeserializeAsync<DotNetMetricResponse>(stream).Result;

                dotNetList.Clear();
                dotNetList.AddRange(AllDotNetMetricsResponse.Metrics.ToList());               

                return AllDotNetMetricsResponse;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }
    }
}


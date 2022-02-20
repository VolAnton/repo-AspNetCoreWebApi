using LiveCharts;
using LiveCharts.Wpf;
using MetricsManagerClient.DAL.Cpu;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MetricsManagerClient
{
    /// <summary>
    /// Interaction logic for MaterialCardsCpu.xaml
    /// </summary>
    public partial class MaterialCardsCpu : UserControl, INotifyPropertyChanged
    {
        private static double[] _arrayCpu = new double[10];

        //private CpuClient _linkCpu = new CpuClient();
        private CpuClient _linkCpu;

        public CpuClient LinkCpu
        {
            get { return _linkCpu; }

            set { _linkCpu = value; }
        }

        public double[] ArrayCpu
        {
            get { return _arrayCpu; }

            set { _arrayCpu = value; }
        }

        public MaterialCardsCpu()
        {
            InitializeComponent();

            LinkCpu = new CpuClient();

            for (int j = 0; j < 10; j++)
            {
                ArrayCpu[j] = 0;
            }

            //ColumnSeriesValues = new SeriesCollection { new ColumnSeries { Values = new ChartValues<double> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 } } };

            ColumnSeriesValues = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double>
                    {
                        ArrayCpu[0],
                        ArrayCpu[1],
                        ArrayCpu[2],
                        ArrayCpu[3],
                        ArrayCpu[4],
                        ArrayCpu[5],
                        ArrayCpu[6],
                        ArrayCpu[7],
                        ArrayCpu[8],
                        ArrayCpu[9]
                    }
                }
            };
            DataContext = this;
        }

        public SeriesCollection ColumnSeriesValues { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void UpdateOnСlick(object sender, RoutedEventArgs e)
        {
            for (int i = 0, k = 10; i < 10; i++, k--)
            {
                try
                {
                    ArrayCpu[i] = (double)CpuClient.cpuList[CpuClient.cpuList.Count - k].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            ColumnSeriesValues[0].Values = new ChartValues<double>
            {
                ArrayCpu[0],
                ArrayCpu[1],
                ArrayCpu[2],
                ArrayCpu[3],
                ArrayCpu[4],
                ArrayCpu[5],
                ArrayCpu[6],
                ArrayCpu[7],
                ArrayCpu[8],
                ArrayCpu[9]
            };

            LinkCpu = new CpuClient();

            TimePowerChart.Update(true);
        }
    }
}
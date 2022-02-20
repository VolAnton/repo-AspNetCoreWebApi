using LiveCharts;
using LiveCharts.Wpf;
using MetricsManagerClient.DAL.Hdd;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
    /// Interaction logic for MaterialCardsHdd.xaml
    /// </summary>
    public partial class MaterialCardsHdd : UserControl, INotifyPropertyChanged
    {
        private static double[] _arrayHdd = new double[10];

        //private CpuClient _linkCpu = new CpuClient();
        private HddClient _linkHdd;

        public HddClient LinkHdd
        {
            get { return _linkHdd; }

            set { _linkHdd = value; }
        }

        public double[] ArrayHdd
        {
            get { return _arrayHdd; }

            set { _arrayHdd = value; }
        }

        public MaterialCardsHdd()
        {
            InitializeComponent();

            LinkHdd = new HddClient();

            for (int j = 0; j < 10; j++)
            {
                ArrayHdd[j] = 0;
            }

            //ColumnSeriesValues = new SeriesCollection { new ColumnSeries { Values = new ChartValues<double> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 } } };

            ColumnSeriesValues = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double>
                    {
                        ArrayHdd[0],
                        ArrayHdd[1],
                        ArrayHdd[2],
                        ArrayHdd[3],
                        ArrayHdd[4],
                        ArrayHdd[5],
                        ArrayHdd[6],
                        ArrayHdd[7],
                        ArrayHdd[8],
                        ArrayHdd[9]
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
                    ArrayHdd[i] = (double)HddClient.hddList[HddClient.hddList.Count - k].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            ColumnSeriesValues[0].Values = new ChartValues<double>
            {
                ArrayHdd[0],
                ArrayHdd[1],
                ArrayHdd[2],
                ArrayHdd[3],
                ArrayHdd[4],
                ArrayHdd[5],
                ArrayHdd[6],
                ArrayHdd[7],
                ArrayHdd[8],
                ArrayHdd[9]
            };

            LinkHdd = new HddClient();

            TimePowerChart.Update(true);
        }
    }
}
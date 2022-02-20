using LiveCharts;
using LiveCharts.Wpf;
using MetricsManagerClient.DAL.DotNet;
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
    /// Interaction logic for MaterialCardsDotNet.xaml
    /// </summary>
    public partial class MaterialCardsDotNet : UserControl, INotifyPropertyChanged
    {
        private static double[] _arrayDotNet = new double[10];

        private DotNetClient _linkDotNet;

        public DotNetClient LinkDotNet
        {
            get { return _linkDotNet; }

            set { _linkDotNet = value; }
        }

        public double[] ArrayDotNet
        {
            get { return _arrayDotNet; }

            set { _arrayDotNet = value; }
        }

        public MaterialCardsDotNet()
        {
            InitializeComponent();

            LinkDotNet = new DotNetClient();

            for (int j = 0; j < 10; j++)
            {
                ArrayDotNet[j] = 0;
            }

            //ColumnSeriesValues = new SeriesCollection { new ColumnSeries { Values = new ChartValues<double> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 } } };

            ColumnSeriesValues = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double>
                    {
                        ArrayDotNet[0],
                        ArrayDotNet[1],
                        ArrayDotNet[2],
                        ArrayDotNet[3],
                        ArrayDotNet[4],
                        ArrayDotNet[5],
                        ArrayDotNet[6],
                        ArrayDotNet[7],
                        ArrayDotNet[8],
                        ArrayDotNet[9]
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
                    ArrayDotNet[i] = (double)DotNetClient.dotNetList[DotNetClient.dotNetList.Count - k].Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            ColumnSeriesValues[0].Values = new ChartValues<double>
            {
                ArrayDotNet[0],
                ArrayDotNet[1],
                ArrayDotNet[2],
                ArrayDotNet[3],
                ArrayDotNet[4],
                ArrayDotNet[5],
                ArrayDotNet[6],
                ArrayDotNet[7],
                ArrayDotNet[8],
                ArrayDotNet[9]
            };

            LinkDotNet = new DotNetClient();

            TimePowerChart.Update(true);
        }
    }
}
using LiveCharts;
using LiveCharts.Wpf;
using MetricsManagerClient.DAL.Ram;
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
    /// Interaction logic for MaterialCardsRam.xaml
    /// </summary>
    public partial class MaterialCardsRam : UserControl, INotifyPropertyChanged
    {
        private static double[] _arrayRam = new double[10];

        private RamClient _linkRam;

        public RamClient LinkRam
        {
            get { return _linkRam; }

            set { _linkRam = value; }
        }

        public double[] ArrayRam
        {
            get { return _arrayRam; }

            set { _arrayRam = value; }
        }

        public MaterialCardsRam()
        {
            InitializeComponent();

            LinkRam = new RamClient();

            for (int j = 0; j < 10; j++)
            {
                ArrayRam[j] = 0;
            }

            //ColumnSeriesValues = new SeriesCollection { new ColumnSeries { Values = new ChartValues<double> { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 } } };

            ColumnSeriesValues = new SeriesCollection
            {
                new ColumnSeries
                {
                    Values = new ChartValues<double>
                    {
                        ArrayRam[0],
                        ArrayRam[1],
                        ArrayRam[2],
                        ArrayRam[3],
                        ArrayRam[4],
                        ArrayRam[5],
                        ArrayRam[6],
                        ArrayRam[7],
                        ArrayRam[8],
                        ArrayRam[9]
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
                    ArrayRam[i] = (double)RamClient.ramList[RamClient.ramList.Count - k].Value / 32768*100;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

            ColumnSeriesValues[0].Values = new ChartValues<double>
            {
                ArrayRam[0],
                ArrayRam[1],
                ArrayRam[2],
                ArrayRam[3],
                ArrayRam[4],
                ArrayRam[5],
                ArrayRam[6],
                ArrayRam[7],
                ArrayRam[8],
                ArrayRam[9]
            };

            LinkRam = new RamClient();

            TimePowerChart.Update(true);
        }
    }
}
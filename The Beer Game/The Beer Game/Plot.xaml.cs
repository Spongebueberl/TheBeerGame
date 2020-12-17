using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LiveCharts;
using LiveCharts.Wpf;

namespace The_Beer_Game
{
    /// <summary>
    /// Interaktionslogik für Plot.xaml
    /// </summary>
    public partial class Plot : Window
    {
        public Plot(Participant p)
        {
            (string p_name, List<double> l) = p.get_history();
            InitializeComponent();
            ChartValues<double> cv = new ChartValues<double>(l.ToArray());

            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = p_name,
                    Values = cv
                }
            };

            // Labels = new[] {"1"};
            YFormatter = value => value.ToString("C");

            DataContext = this;
        }

        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

    }
}

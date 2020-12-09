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

namespace The_Beer_Game
{
    /// <summary>
    /// Interaktionslogik für Window1.xaml
    /// </summary>
    
    public delegate void DataSentHandler(double cv);   
    public partial class childwindow : Window
    {
   
        public childwindow()
        {                                  
            InitializeComponent();
        }

        public event DataSentHandler DataSent;

        public double get_double()
        {
            return 33.4;
        }

        private void SubmitCreditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreditSlider.Value != 0)
            {
                DataSent(CreditSlider.Value);
                Close();
            }
        }

        public void CreditSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CreditSliderLabel.Content = CreditSlider.Value;         

        }
    }
}

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
    public partial class Window1 : Window
    {
        double creditvalue = 0;
        string myString = "";
        public Window1()
        {
            InitializeComponent();
            Sender = creditvalue;


        }

        private void SubmitCreditButton_Click(object sender, RoutedEventArgs e)
        {
            if (CreditSlider.Value != 0)
            {
                creditvalue = CreditSlider.Value;
                CreditSlider.Value = 0;
                Close();
            }
        }

        public void CreditSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CreditSliderLabel.Content = CreditSlider.Value;
            myString = CreditSlider.Value.ToString();

        }
        public string MyString { get => myString; set => myString = value; }


        // public string myString { get; set; }


    }
}

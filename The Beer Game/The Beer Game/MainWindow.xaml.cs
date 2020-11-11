using System;
using System.Collections.Generic;
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

namespace The_Beer_Game
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Add random number
            Random rnd = new Random();
            
            //Add new Participants
            Participant Fabrik = new Participant("Fabrik", 10, 20, 1);
            Participant Regionallager = new Participant("Regionallager", 10, 20, 1);
            Participant Grosslager = new Participant("Grosslager", 10, 20, 1);
            Participant Einzelhandel = new Participant("Einzelhandel", 10, 20, 1);

            TB_Fabrik.Text = "\n" + Fabrik.exec_storage_costs();
            TB_Regionallager.Text = "\n" + Regionallager.exec_storage_costs();
            TB_Grosshandel.Text = "\n" + Grosslager.exec_storage_costs();
            TB_Einzelhandel.Text = "\n" + Einzelhandel.exec_storage_costs();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Submit_FB_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_EH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_GH_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Submit_RL_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            int x = rnd.Next(0, 16);
        }
    }
}

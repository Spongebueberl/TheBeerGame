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
        //Add random number
        Random rnd = new Random();
        int x;

        //Add new Participants
        Participant Fabrik = new Participant("Fabrik", 10, 20);
        Participant Regionallager = new Participant("Regionallager", 10, 20);
        Participant Grosslager = new Participant("Grosslager", 10, 20);
        Participant Einzelhandel = new Participant("Einzelhandel", 10, 20);
        Participant Rohstofflager = new Participant("Rohstofflager", 1000, 1000);



        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 52; i++)
            {
                update_textboxes(i);

            }


        }

        private void update_textboxes(int round)
        {
            string s;
            int i;
            int m;

            TB_RoundInfo.Text = ("Round :" + round);

            (s, i) = Fabrik.get_inventory();
            (s, m) = Fabrik.get_bank();
            TB_Fabrik.Text = "Inventory: " + i + "\nBank: " + m;
            (s, i) = Regionallager.get_inventory();
            (s, m) = Regionallager.get_bank();
            TB_Regionallager.Text = "Inventory: " + i + "\nBank: " + m;
            (s, i) = Grosslager.get_inventory();
            (s, m) = Grosslager.get_bank();
            TB_Grosshandel.Text = "Inventory: " + i + "\nBank: " + m;
            (s, i) = Einzelhandel.get_inventory();
            (s, m) = Einzelhandel.get_bank();
            TB_Einzelhandel.Text = "Inventory: " + i + "\nBank: " + m;
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
            x = rnd.Next(0, 16);
            Testbox.Text = "" + x;
        }
    }
}

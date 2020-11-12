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


        RoundHandler RH = new RoundHandler();



        public MainWindow()
        {
            InitializeComponent();
        }

        public class RoundHandler
        {
            int round = 0;
            int PT = 0;

            public int update_PT(int p)
            {
                if (p == PT)
                {
                    PT++;
                }
                if (PT == 4)
                {
                    PT = 0;
                    update_round();
                }
                return PT;
            }

            public int update_round()
            {
                round++;
                return round;
            }

            public int get_round()
            {
                return round;
            }

            public int get_PT()
            {
                return PT;
            }

        }

        private void update_textboxes()
        {
            string s;
            int i;
            int m;

            TB_RoundInfo.Text = ("Round :" + RH.get_round() + "\nParticipant: " + RH.get_PT());

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
            RH.update_PT(0);
            update_textboxes();
        }

        private void Submit_EH_Click(object sender, RoutedEventArgs e)
        {
            RH.update_PT(3);
            update_textboxes();
        }

        private void Submit_GH_Click(object sender, RoutedEventArgs e)
        {
            RH.update_PT(2);
            update_textboxes();
        }

        private void Submit_RL_Click(object sender, RoutedEventArgs e)
        {
            RH.update_PT(1);
            update_textboxes();
        }

        private void Startbtn_Click(object sender, RoutedEventArgs e)
        {
            x = rnd.Next(0, 16);
            Testbox.Text = "" + x;
        }
    }
}

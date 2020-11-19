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
        // instantiate Roundhandler
        RoundHandler RH = new RoundHandler();

        //Add new Participants
        Participant Fabrik = new Participant("Fabrik", 10, 60);
        Participant Regionallager = new Participant("Regionallager", 10, 60);
        Participant Grosslager = new Participant("Grosslager", 10, 60);
        Participant Einzelhandel = new Participant("Einzelhandel", 10, 60);
        Participant Rohstofflager = new Participant("Rohstofflager", 1000, 1000);

        int x = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            Fabrik.set_bank(RH.get_Roundstart() * -4);
            //Wareneingangskosten = 4
            Fabrik.set_inventory(RH.get_Roundstart());
            update_textboxes();
        }

        public class RoundHandler
        {
            Random rnd = new Random();
            int round = 0;
            int PT = 0;
            int dice = 0;
            int RoundStart = 0;

            public RoundHandler()
            {
                RoundStart = rnd.Next(0, 16);
                MessageBox.Show("Die Bestellung wird über " + RoundStart + " ausgelöst!");
            }


            public int update_PT()
            {
                PT++;
                if (PT == 4)
                {
                    PT = 0;
                    RoundStart = rnd.Next(0, 16);
                    update_round();
                }
                return PT;
            }

            public int get_Roundstart()
            {
                return RoundStart;
            }

            public int update_round()
            {
                dice = rnd.Next(1, 6);
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
            public string get_currentPT()
            {
                string CPT_String = "";
                switch (PT)
                {
                    case 1:
                        CPT_String = "Regionallager";
                        break;
                    case 2:
                        CPT_String = "Großlager";
                        break;
                    case 3:
                        CPT_String = "Einzelhandel";
                        break;
                    case 0:
                        CPT_String = "Fabrik";
                        break;

                    default:
                        break;
                }
                return CPT_String;
            }
        
            public string get_nextPT()
            {
                string PT_String = "";
                switch (PT)
                {
                    case 0:
                        PT_String = "Regionallager";
                        break;
                    case 1:
                        PT_String = "Großlager";
                        break;
                    case 2:
                        PT_String = "Einzelhandel";
                        break;
                    case 3:
                        PT_String = "Fabrik";
                        break;

                    default:
                        break;
                }

                return PT_String;
            }
        }

        private void update_textboxes()
        {
            string s;
            int i;
            int m;

            TBRoundInfo.Text = ("Round :" + RH.get_round() + "\nParticipant: " + RH.get_currentPT());


            int p = RH.get_PT();

            switch (p)
            {
                case 0:
                    (s, i) = Fabrik.get_inventory();
                    (s, m) = Fabrik.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    break;
                case 1:
                    (s, i) = Regionallager.get_inventory();
                    (s, m) = Regionallager.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    break;
                case 2:
                    (s, i) = Grosslager.get_inventory();
                    (s, m) = Grosslager.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    break;
                case 3:
                    (s, i) = Einzelhandel.get_inventory();
                    (s, m) = Einzelhandel.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    break;
                default:
                    break;
            }

        }
                
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();

            switch (p)
            {
                case 0:
                    Fabrik.set_bank(RH.get_Roundstart() * -4);
                    Fabrik.set_inventory(RH.get_Roundstart());
                    break;
                case 1:
                    Regionallager.set_bank(x * -4);
                    Regionallager.set_inventory(x);
                    break;
                case 2:
                    Grosslager.set_bank(x * -4);
                    Grosslager.set_inventory(x);
                    break;
                case 3:
                    Einzelhandel.set_bank(x * -4);
                    Einzelhandel.set_inventory(x);
                    break;

                default:
                    break;
            }
            MessageBox.Show("Sie haben Ihre Eingabe bestätigt. Bitte an " + RH.get_nextPT() + " weiterreichen!");
            RH.update_PT();
            update_textboxes();
            x = Convert.ToInt32(Slider.Value);
            Slider.Value = 0;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderLabel.Content = Slider.Value.ToString();
        }
    }
}

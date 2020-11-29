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

        double x = 0;
        double price = 0;

        public MainWindow()
        {
            InitializeComponent();
            
            Fabrik.set_bank(RH.get_Roundstart() * price);
            //Wareneingangskosten = 4
            Fabrik.execute_order(RH.get_Roundstart());
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

            public double update_round()
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
            double i;
            double m;

            TBRoundInfo.Text = ("Round :" + RH.get_round() + "\nParticipant: " + RH.get_currentPT());


            int p = RH.get_PT();

            switch (p)
            {
                case 0:
                    (s, i) = Fabrik.get_inventory();
                    (s, m) = Fabrik.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled) = Fabrik.get_checkbutton();                    
                    break;
                case 1:
                    (s, i) = Regionallager.get_inventory();
                    (s, m) = Regionallager.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled) = Regionallager.get_checkbutton();
                    break;
                case 2:
                    (s, i) = Grosslager.get_inventory();
                    (s, m) = Grosslager.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled) = Grosslager.get_checkbutton();
                    break;
                case 3:
                    (s, i) = Einzelhandel.get_inventory();
                    (s, m) = Einzelhandel.get_bank();
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled) = Einzelhandel.get_checkbutton();
                    break;
                default:
                    break;
            }

        }
                
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();
            double s = Slider.Value;

            switch (p)
            {
                case 0:
                    Fabrik.set_bank(RH.get_Roundstart() * price);
                    Fabrik.place_order(RH.get_Roundstart());
                    Submit.IsEnabled = false;
                    break;
                case 1:
                    Regionallager.set_bank(x * price);
                    Regionallager.place_order(s);
                    Submit.IsEnabled = false;
                    break;
                case 2:
                    Grosslager.set_bank(x * price);
                    Grosslager.place_order(s);
                    Submit.IsEnabled = false;
                    break;
                case 3:
                    Einzelhandel.set_bank(x * price);
                    Einzelhandel.place_order(s);
                    Submit.IsEnabled = false;
                    break;

                default:
                    break;
            }            
            update_textboxes();
            MessageBox.Show("Sie haben Ihre Eingabe über " + Slider.Value + " Einheiten bestätigt. Bitte an " + RH.get_nextPT() + " weiterreichen!");
            //x = Convert.ToInt32(Slider.Value);
            Slider.Value = 0;

        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderLabel.Content = Slider.Value.ToString();

            if (Slider.Value < 5)
            {
                price = -4;
            }
            else if (Slider.Value < 10)
            {
                price = -3.5;
            }
            else 
            { 
                price = -3.2;
            }
            double v = (price * -1);
            TB.Text = "Für die Bestellung werden " + (Slider.Value * v) + " fällig!";
        }
         

        private void NP_button_Click(object sender, RoutedEventArgs e)
        {
            RH.update_PT();
            update_textboxes();
            Submit.IsEnabled = true;
        }

        private void SellBack_Button_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();
            bool exp;
            bool sbb;

            switch (p)
            {
                case 0:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Fabrik.get_checkbutton();
                    Fabrik.set_checkbutton(Expbtn: exp, Sbbtn: false);
                    break;
                case 1:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Regionallager.get_checkbutton();
                    Regionallager.set_checkbutton(Expbtn: exp, Sbbtn: false);
                    break;
                case 2:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Grosslager.get_checkbutton();
                    Grosslager.set_checkbutton(Expbtn: exp, Sbbtn: false);
                    break;
                case 3:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Einzelhandel.get_checkbutton();
                    Einzelhandel.set_checkbutton(Expbtn: exp, Sbbtn: false);
                    break;

                default:
                    break;
            }
            //Switch Case Statement ?

            //Setzt SellBack Button auf inaktiv bei Klick
        }

        private void Express_Button_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();
            bool exp;
            bool sbb;
            //Das ist hier falsch muss glaube ich in den RoundHandler
            switch (p)
            {
                case 0:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Fabrik.get_checkbutton();
                    Fabrik.set_checkbutton(Expbtn: false, Sbbtn: sbb);
                    break;
                case 1:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Regionallager.get_checkbutton();
                    Regionallager.set_checkbutton(Expbtn: false, Sbbtn: sbb);
                    break;
                case 2:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Grosslager.get_checkbutton();
                    Grosslager.set_checkbutton(Expbtn: false, Sbbtn: sbb);
                    break;
                case 3:
                    Express_Button.IsEnabled = false;
                    (exp, sbb) = Einzelhandel.get_checkbutton();
                    Einzelhandel.set_checkbutton(Expbtn: false, Sbbtn: sbb);
                    break;

                default:
                    break;
            }
            
            //Setzt Express Button auf inaktiv bei Klick
        }
    }
}

﻿using System;
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

        // Window win1 = new Window1();

        //Add new Participants
        Participant Fabrik = new Participant("Fabrik", 6, 60, 3, 0, 3);
        Participant Regionallager = new Participant("Regionallager", 6, 60, 3, 0, 0);
        Participant Grosslager = new Participant("Grosslager", 6, 60, 3, 0, 0);
        Participant Einzelhandel = new Participant("Einzelhandel", 6, 60, 3, 0, 0);
        Participant Spielleiter = new Participant("Rohstofflager", 1000, 1000, 1000, 0, 0);

        double price = 0;
        double Creditvalue;
        double sellback = 0;
        //double express = 0;

        CardDeck CD = new CardDeck();


        public MainWindow()
        {
            InitializeComponent();

            NP_button.IsEnabled = false;
            CreditButton.IsEnabled = false;
            update_textboxes();            

        }

        public class RoundHandler
        {
            Random rnd = new Random();
            int round = 0;
            int PT = 0;
            int dice = 0;
            int RoundStart = 0;
            int Warehouse = 0;
            bool newround = false;

            public RoundHandler()
            {
                RoundStart = rnd.Next(0, 16);
                MessageBox.Show("Die Bestellung des Endkunden wird über " + RoundStart + " ausgelöst!");
            }

            //Wareneingang eingeführt
            public int set_Warehouse()
            {
                Warehouse = RoundStart;
                return Warehouse;
            }
           

            public int update_PT()
            {
                PT++;
                if (PT == 4)
                {
                    PT = 0;
                    //Set Roundstart
                    newround = true;
                    RoundStart = rnd.Next(0, 16);
                    set_Warehouse();
                    update_round();
                }
                return PT;
            }
            public bool new_round()
            {
                return newround;
            }
            public void end_newround()
            {
                newround = false;                
            }
            
            public int get_Roundstart()
            {
                return RoundStart;
            }

            public double update_round()
            {
                dice = rnd.Next(1, 6);
                MessageBox.Show("Es wurde eine " + dice + " gewürfelt!");
                // hier müsste der Aufruf CardDeck.draw() erfolgen, wenn 6 gewürfelt wurde?
                round++;
                return round;
            }

            public int get_round()
            {
                return round + 1;
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
            double w;
            double st;
            double a;
            double prod;
            bool exp;
            bool sbb;
            bool cb;
            double deliveredgoods;
            double duegoods;
            double duegoodscost;
            double cv;

            TBRoundInfo.Text = ("Runde: " + RH.get_round());
            ParticipantLabel.Content = RH.get_currentPT();

            int p = RH.get_PT();

            if (RH.new_round() == true)
            {
                Fabrik.execute_order();
                Regionallager.execute_order();
                Grosslager.execute_order();
                Einzelhandel.execute_order();
                Fabrik.update_creditvalue();
                Regionallager.update_creditvalue();
                Grosslager.update_creditvalue();
                Einzelhandel.update_creditvalue();
                RH.end_newround();
            }                       
                            
            switch (p)
            {
                case 0:
                    (s, i) = Fabrik.get_inventory();
                    (s, m) = Fabrik.get_bank();
                    Fabrik.execute_storagecosts();
                    (s, w) = Fabrik.get_warehouse();
                    (s, st) = Fabrik.get_storagecosts();
                    (s, a) = Regionallager.get_order();
                    (s, cv) = Fabrik.get_creditvalue();
                    
                    ProductionTB.IsEnabled = true;
                    (s, prod) = Fabrik.get_production();

                    if (i < a)
                    {
                        deliveredgoods = i;
                        duegoods = a - i;
                        duegoodscost = duegoods * 2;
                        
                    }
                    else
                    {
                        deliveredgoods = a;
                        duegoods = 0;
                        duegoodscost = 0;
                    }

                    m -= duegoodscost;

                    if (m < 1)
                    {
                        (exp, sbb, cb) = Fabrik.get_checkbutton();
                        Fabrik.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: true);                        
                        Submit.IsEnabled = false;
                        Slider.IsEnabled = false;
                    }
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    WarehouseTB.Text = w.ToString();
                    StorageTB.Text = st.ToString();
                    NewOrderTB.Text = a.ToString();
                    ProductionTB.Text = prod.ToString();
                    OrderExecTB.Text = deliveredgoods.ToString();
                    OrderDueTB.Text = duegoods.ToString();
                    DelayedDeliveryTB.Text = duegoodscost.ToString();
                    CreditTB.Text = cv.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled, CreditButton.IsEnabled) = Fabrik.get_checkbutton();                    
                    break;
                case 1:
                    (s, i) = Regionallager.get_inventory();
                    (s, m) = Regionallager.get_bank();
                    Regionallager.execute_storagecosts();
                    (s, w) = Regionallager.get_warehouse();
                    (s, st) = Regionallager.get_storagecosts();
                    (s, a) = Grosslager.get_order();
                    (s, prod) = Regionallager.get_production();
                    (s, cv) = Regionallager.get_creditvalue();

                    ProductionTB.IsEnabled = false;

                    if (i < a)
                    {
                        deliveredgoods = i;
                        duegoods = a - i;
                        duegoodscost = duegoods * 2;

                    }
                    else
                    {
                        deliveredgoods = a;
                        duegoods = 0;
                        duegoodscost = 0;
                    }

                    m -= duegoodscost;

                    if (m < 1)
                    {
                        (exp, sbb, cb) = Regionallager.get_checkbutton();
                        Regionallager.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: true);
                        Submit.IsEnabled = false;
                        Slider.IsEnabled = false;
                    }
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    WarehouseTB.Text = w.ToString();
                    StorageTB.Text = st.ToString();
                    NewOrderTB.Text = a.ToString();
                    ProductionTB.Text = prod.ToString();
                    OrderExecTB.Text = deliveredgoods.ToString();
                    OrderDueTB.Text = duegoods.ToString();
                    DelayedDeliveryTB.Text = duegoodscost.ToString();
                    CreditTB.Text = cv.ToString();
                    ProductionTB.IsEnabled = false;                    
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled, CreditButton.IsEnabled) = Regionallager.get_checkbutton();
                    break;
                case 2:
                    (s, i) = Grosslager.get_inventory();
                    (s, m) = Grosslager.get_bank();
                    Grosslager.execute_storagecosts();
                    (s, w) = Grosslager.get_warehouse();
                    (s, st) = Grosslager.get_storagecosts();
                    (s, a) = Einzelhandel.get_order();
                    (s, prod) = Grosslager.get_production();
                    (s, cv) = Grosslager.get_creditvalue();
                    ProductionTB.IsEnabled = false;

                    if (i < a)
                    {
                        deliveredgoods = i;
                        duegoods = a - i;
                        duegoodscost = duegoods * 2;

                    }
                    else
                    {
                        deliveredgoods = a;
                        duegoods = 0;
                        duegoodscost = 0;
                    }

                    m -= duegoodscost;

                    if (m < 1)
                    {
                        (exp, sbb, cb) = Grosslager.get_checkbutton();
                        Grosslager.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: true);                        
                        Submit.IsEnabled = false;
                        Slider.IsEnabled = false;
                    }
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    WarehouseTB.Text = w.ToString();
                    StorageTB.Text = st.ToString();
                    NewOrderTB.Text = a.ToString();
                    ProductionTB.Text = prod.ToString();
                    OrderExecTB.Text = deliveredgoods.ToString();
                    OrderDueTB.Text = duegoods.ToString();
                    DelayedDeliveryTB.Text = duegoodscost.ToString();
                    CreditTB.Text = cv.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled, CreditButton.IsEnabled) = Grosslager.get_checkbutton();
                    break;
                case 3:
                    (s, i) = Einzelhandel.get_inventory();
                    (s, m) = Einzelhandel.get_bank();
                    Einzelhandel.execute_storagecosts();
                    (s, w) = Einzelhandel.get_warehouse();
                    (s, st) = Einzelhandel.get_storagecosts();
                    (s, a) = (s, RH.get_Roundstart());
                    (s, prod) = Einzelhandel.get_production();
                    (s, cv) = Einzelhandel.get_creditvalue();
                    ProductionTB.IsEnabled = false;

                    if (i < a)
                    {
                        deliveredgoods = i;
                        duegoods = a - i;
                        duegoodscost = duegoods * 2;

                    }
                    else
                    {
                        deliveredgoods = a;
                        duegoods = 0;
                        duegoodscost = 0;
                    }

                    m -= duegoodscost;

                    if (m < 1)
                    {
                        (exp, sbb, cb) = Einzelhandel.get_checkbutton();
                        Einzelhandel.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: true);
                        Submit.IsEnabled = false;
                        Slider.IsEnabled = false;
                    }
                    InventoryTB.Text = i.ToString();
                    BankTB.Text = m.ToString();
                    WarehouseTB.Text = w.ToString();
                    StorageTB.Text = st.ToString();
                    NewOrderTB.Text = a.ToString();
                    ProductionTB.Text = prod.ToString();
                    OrderExecTB.Text = deliveredgoods.ToString();
                    OrderDueTB.Text = duegoods.ToString();
                    DelayedDeliveryTB.Text = duegoodscost.ToString();
                    CreditTB.Text = cv.ToString();
                    (Express_Button.IsEnabled, SellBack_Button.IsEnabled, CreditButton.IsEnabled) = Einzelhandel.get_checkbutton();
                    break;
                default:
                    break;
            }

        }                
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();
            double s = Slider.Value;
            double Revenue = 7;

            switch (p)
            {
                case 0:
                    Fabrik.set_bank(s * price);                    
                    Spielleiter.set_bank(s * Revenue);
                    Fabrik.place_order(s);
                    Submit.IsEnabled = false;
                    Slider.IsEnabled = false;                    
                    NP_button.IsEnabled = true;
                    break;
                case 1:
                    Regionallager.set_bank(s * price);
                    Fabrik.set_bank(s * Revenue);
                    Regionallager.place_order(s);
                    Submit.IsEnabled = false;
                    Slider.IsEnabled = false;                    
                    NP_button.IsEnabled = true;
                    break;
                case 2:
                    Grosslager.set_bank(s * price);
                    Regionallager.set_bank(s * Revenue);
                    Grosslager.place_order(s);
                    Submit.IsEnabled = false;
                    Slider.IsEnabled = false;                    
                    NP_button.IsEnabled = true;
                    break;
                case 3:
                    Einzelhandel.set_bank(s * price);
                    Grosslager.set_bank(s * Revenue);
                    Einzelhandel.place_order(s);
                    Submit.IsEnabled = false;
                    Slider.IsEnabled = false;                    
                    NP_button.IsEnabled = true;
                    break;

                default:
                    break;
            }            
            update_textboxes();
            MessageBox.Show("Sie haben Ihre Eingabe über " + Slider.Value + " Einheiten bestätigt. Bitte an " + RH.get_nextPT() + " weiterreichen!");            
            Slider.Value = 0;

        }     

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderLabel.Content = Slider.Value.ToString();           

            int p = RH.get_PT();
            string pt;
            double m;
            double v;

            switch (p)
            {
                case 0:
                    (pt, m) = Fabrik.get_bank();
                    sellback = 0;
                    if (Math.Floor(m / 4) < 15)
                    {
                        Slider.Maximum = Math.Floor(m / 4);
                    }
                    else
                    {
                        Slider.Maximum = 15;
                    }

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
                    v = Math.Round(price * -1, 1);
                    TB.Text = "Für die Bestellung werden " + (Slider.Value * v) + " fällig!";
                    break;
                case 1:
                    (pt, m) = Regionallager.get_bank();
                    sellback = 0.5;
                    if (Math.Floor(m / 4) < 15)
                    {
                        Slider.Maximum = Math.Floor(m / 4);
                    }
                    else
                    {
                        Slider.Maximum = 15;
                    }
                    
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
                    v = Math.Round(price * -1, 1);
                    TB.Text = "Für die Bestellung werden " + (Slider.Value * v) + " fällig!";
                    break;
                case 2:
                    (pt, m) = Grosslager.get_bank();
                    sellback = 1;
                    if (Math.Floor(m / 4) < 15)
                    {
                        Slider.Maximum = Math.Floor(m / 4);
                    }
                    else
                    {
                        Slider.Maximum = 15;
                    }

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
                    v = Math.Round(price * -1, 1);
                    TB.Text = "Für die Bestellung werden " + (Slider.Value * v) + " fällig!";
                    break;
                case 3:
                    (pt, m) = Einzelhandel.get_bank();
                    sellback = 1.25;
                    if (Math.Floor(m / 4) < 15)
                    {
                        Slider.Maximum = Math.Floor(m / 4);
                    }
                    else
                    {
                        Slider.Maximum = 15;
                    }

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
                    v = Math.Round(price * -1 , 1);
                    TB.Text = "Für die Bestellung werden " + (Slider.Value * v) + " fällig!";
                    break;

                default:
                    break;
            }
            /*
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
            */
        }
         

        private void NP_button_Click(object sender, RoutedEventArgs e)
        {
            RH.update_PT();
            update_textboxes();
            Submit.IsEnabled = true;
            Slider.IsEnabled = true;
            NP_button.IsEnabled = false;
            Slider.Maximum = 15;
        }

        private void SellBack_Button_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();
            double s = Slider.Value;
            double i = Slider.Value * -1;
            bool exp;
            bool sbb;
            bool cb;

            switch (p)
            {
                case 0:
                    if (Slider.Value > 0)
                    {
                        Fabrik.set_bank(s * sellback);
                        Fabrik.set_inventoryonsellback(s);
                        SellBack_Button.IsEnabled = false;
                        (exp, sbb, cb) = Fabrik.get_checkbutton();
                        Fabrik.set_checkbutton(Expbtn: exp, Sbbtn: false, Cbtn: cb);
                    }
                    break;
                case 1:
                    if (Slider.Value > 0)
                    {
                        Regionallager.set_bank(s * sellback);
                        Regionallager.set_inventoryonsellback(s);
                        Fabrik.set_inventoryonsellback(i);
                        SellBack_Button.IsEnabled = false;
                        (exp, sbb, cb) = Regionallager.get_checkbutton();
                        Regionallager.set_checkbutton(Expbtn: exp, Sbbtn: false, Cbtn: cb);
                    }
                    break;
                case 2:
                    if (Slider.Value > 0)
                    {
                        Grosslager.set_bank(s * sellback);
                        Regionallager.set_inventoryonsellback(i);
                        SellBack_Button.IsEnabled = false;
                        (exp, sbb, cb) = Grosslager.get_checkbutton();
                        Grosslager.set_checkbutton(Expbtn: exp, Sbbtn: false, Cbtn: cb);
                    }
                    break;
                case 3:
                    if (Slider.Value > 0)
                    {
                        Einzelhandel.set_bank(s * sellback);
                        Einzelhandel.set_inventoryonsellback(s);
                        Grosslager.set_inventoryonsellback(i);
                        SellBack_Button.IsEnabled = false;
                        (exp, sbb, cb) = Einzelhandel.get_checkbutton();
                        Einzelhandel.set_checkbutton(Expbtn: exp, Sbbtn: false, Cbtn: cb);
                    }
                    break;

                default:
                    break;
                    
            }
            update_textboxes();
            Slider.Value = 0;
            Slider.IsEnabled = false;          

            
        }

        private void Express_Button_Click(object sender, RoutedEventArgs e)
        {
            int p = RH.get_PT();
            double ex = Slider.Value;
            double nex = Slider.Value * -1;
            bool exp;
            bool sbb;
            bool cb;
            
            switch (p)
            {
                case 0:
                    if (Slider.Value > 0)
                    {
                        Fabrik.set_bank(ex * price);
                        Fabrik.set_inventoryonexpress(ex);
                        Express_Button.IsEnabled = false;
                        (exp, sbb, cb) = Fabrik.get_checkbutton();
                        Fabrik.set_checkbutton(Expbtn: false, Sbbtn: sbb, Cbtn: cb);
                    }
                    break;
                case 1:
                    if (Slider.Value > 0)
                    {
                        Regionallager.set_bank(ex * price);
                        Regionallager.set_inventoryonexpress(ex);
                        Fabrik.set_inventoryonsellback(nex);
                        Fabrik.set_bank(nex * price);
                        Express_Button.IsEnabled = false;
                        (exp, sbb, cb) = Regionallager.get_checkbutton();
                        Regionallager.set_checkbutton(Expbtn: false, Sbbtn: sbb, Cbtn: cb);
                    }
                    break;
                case 2:
                    if (Slider.Value > 0)
                    {
                        Grosslager.set_bank(ex * price);
                        Grosslager.set_inventoryonexpress(ex);
                        Regionallager.set_inventoryonsellback(nex);
                        Regionallager.set_bank(nex * price);
                        Express_Button.IsEnabled = false;
                        (exp, sbb, cb) = Grosslager.get_checkbutton();
                        Grosslager.set_checkbutton(Expbtn: false, Sbbtn: sbb, Cbtn: cb);
                    }
                    break;
                case 3:
                    if (Slider.Value > 0)
                    {
                        Einzelhandel.set_bank(ex * price);
                        Einzelhandel.set_inventoryonexpress(ex);
                        Grosslager.set_inventoryonsellback(nex);
                        Grosslager.set_bank(nex * price);
                        Express_Button.IsEnabled = false;
                        (exp, sbb, cb) = Einzelhandel.get_checkbutton();
                        Einzelhandel.set_checkbutton(Expbtn: false, Sbbtn: sbb, Cbtn: cb);
                    }
                    break;

                default:
                    break;
            }
            update_textboxes();
            Slider.Value = 0;
            Slider.IsEnabled = false;
            //Setzt Express Button auf inaktiv bei Klick
        }
                
        private void Credit_Button_Click(object sender, RoutedEventArgs e)
        {

            childwindow win1 = new childwindow();

            int p = RH.get_PT();
            bool exp;
            bool sbb;
            bool cb;
            string part;
            double b;

            //win1.DataSent += Win1_DataSent;
            //win1.Show();            
            switch (p)
            {
                case 0:
                    if (win1.ShowDialog() == true)
                    {
                        CreditButton.IsEnabled = false;
                        (exp, sbb, cb) = Fabrik.get_checkbutton();
                        (part, b) = Fabrik.get_bank();
                        Fabrik.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: false);
                        Fabrik.set_creditvalue(win1.creditv);
                        Fabrik.set_bank(b += win1.creditv);
                    }
                    break;
                case 1:
                    if (win1.ShowDialog() == true)
                    {
                        CreditButton.IsEnabled = false;
                        (exp, sbb, cb) = Regionallager.get_checkbutton();
                        Regionallager.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: false);
                        Regionallager.set_creditvalue(win1.creditv);                        
                    }
                    break;
                case 2:
                    if (win1.ShowDialog() == true)
                    {
                        CreditButton.IsEnabled = false;
                        (exp, sbb, cb) = Grosslager.get_checkbutton();
                        Grosslager.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: false);
                        Grosslager.set_creditvalue(win1.creditv);                        
                    }
                    break;
                case 3:
                    if (win1.ShowDialog() == true)
                    {
                        CreditButton.IsEnabled = false;
                        (exp, sbb, cb) = Einzelhandel.get_checkbutton();
                        Einzelhandel.set_checkbutton(Expbtn: exp, Sbbtn: sbb, Cbtn: false);
                        Einzelhandel.set_creditvalue(win1.creditv);                        
                    }
                    break;

                default:
                    break;                    
            }
            update_textboxes();
            /*
            if (win1.ShowDialog() == true)
            {
                MessageBox.Show(win1.creditv.ToString());
            }
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Participant pt;
            //switch (RH.get_PT())
            //{
            //    case 0:
            //        pt = Fabrik;
            //        break;
            //    case 1:
            //        pt = Regionallager;
            //        break;
            //    case 2:
            //        pt = Grosslager;
            //        break;
            //    case 3:
            //        pt = Einzelhandel;
            //        break;
            //}
            Plot p = new Plot(Fabrik);
            p.Show();
            // (_, TB.Text) = CD.DrawCard();
        }
    }
}

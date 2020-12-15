using System;
using System.Collections.Generic;
using System.Text;

namespace The_Beer_Game
{
    public class Participant
    {
        // create variables for class:
        string ParticipantName = "";
        double Inventory = 0;
        double goods_in = 0;
        double Bank = 0;
        double goods_ordered = 0;
        double delivered_goods = 0;
        bool Expressbutton = true;
        bool Sellbackbutton = true;
        bool Creditbutton = false;
        double Warehouse = 0;
        double Production = 0;
        double Storage = 0;
        double Creditvalue = 0;
        double Shipment = 0;
        

        // class constructor:
        public Participant(string name, double inv, double money, double goods_in, double credit, double producedgoods)
        {
            // set inventory and bank to given values at class initialization:
            ParticipantName = name;
            Inventory = inv;
            Bank = money;
            Warehouse = goods_in;//neu eingeführt
            Creditvalue = credit;
            Production = producedgoods;
        }

        // Method to show inventory:
        public (string, double) get_inventory()
        {
            return (ParticipantName, Inventory);
        }

        // Method to show bank:
        public (string, double) get_bank()
        {
            return (ParticipantName, Bank);
        }

        public (string, double) set_bank(double money)
        {          
            Bank += money;
            return (ParticipantName, Bank);
        }

        public (string, double) place_order(double amount)
        {
            goods_ordered = amount;
            return (ParticipantName, goods_ordered);
        }

        public (string, double) get_order()
        {
            return (ParticipantName, goods_ordered);
        }

        /*public (string, double) execute_delivery()
        {
            delivered_goods = 
        }
        */
        public (string, double) execute_order() 
        {
            Inventory += Warehouse;
            incoming_goods();
            return (ParticipantName, Inventory);
        }

        public (string, double) set_production(double amount)
        {
            Production = Warehouse;
            return (ParticipantName, Production);
        }

        public (string, double) get_production()
        {
            return (ParticipantName, Production);
        }

        public (string, double) set_deliveredgoods(double amount)
        {
            if(Inventory < goods_ordered)
            {
                Shipment = Inventory;
                Inventory = 0;
            }
            else
            {
                Shipment = goods_ordered;

            }
            return (ParticipantName, Shipment);
        }
        
        public (string, double) get_deliveredgoods()
        {
            return (ParticipantName, Shipment);
        }

        public (string, double) set_producedinventory(double amount)
        {
            Inventory += Production;
            return (ParticipantName, Inventory);
        }

        public (string, double) get_producedinventory()
        {
            return (ParticipantName, Inventory);
        }
        

        public (string, double) set_inventoryonsellback(double InvOnS)
        //Wird beim Aufruf des SellbackButtons benutzt
        {
            Inventory -= InvOnS;
            return (ParticipantName, Inventory);
        }

        public (string, double) set_inventoryonexpress(double InvOnEx)
        //Wird beim Aufruf des Expressbuttons benutzt
        {
            Inventory += InvOnEx;
            return (ParticipantName, Inventory);
        }

        public (string, double) incoming_goods()
            
        {
            //Setzt den Wareneingang auf einen Wert
            Warehouse = goods_ordered;
            return (ParticipantName, Warehouse);
        }

        public (string,double) get_warehouse()
        {
            return (ParticipantName, Warehouse);
        }

        public (string, double) get_storagecosts()
        {
            Storage = Inventory * 1.5;
            return (ParticipantName, Storage);
        }

        public (string, double) set_creditvalue(double credit)
        {
            Creditvalue += credit;
            return (ParticipantName, Creditvalue);
        }
        public (string, double) get_creditvalue()
        {
            return (ParticipantName, Creditvalue);
        }
        public void set_checkbutton(bool Expbtn, bool Sbbtn, bool Cbtn)
        {
            Expressbutton = Expbtn;
            Sellbackbutton = Sbbtn;
            Creditbutton = Cbtn;
        }
        public (bool, bool, bool) get_checkbutton()
        {
            return (Expressbutton, Sellbackbutton, Creditbutton);
        }



        /*
        // Method to receive order:
        public (string, double, double) receive_order(double amount, double price)
        {
            if (Inventory - amount >=0) 
            {
                Inventory = Inventory - amount;
                Bank = Bank + price * amount;
                return ("erfolgreich abgeschlossen", 3, 23.343434);
            }
            else
            {
                return ("teafdfasd", 4, 7.23232);
            }                        
        }

        // Method to place order:
        public void place_order(double amount, double price)
        {
            if (Bank - amount * price >= 0)
            {
                Bank = Bank - amount * price;
            }
            else 
            {
                Console.WriteLine("Nicht genügend Geld in der Bank!");            
            }
        }

        //Method to show not executed contracts
        public double get_opencontracts()
        {
            return Contracts;
        }

        // Method to store non executed contracts
        public void open_contracts(double amount)
        {
            if(Inventory <= 0)
            {
                Contracts = Contracts + amount;
            }
        }

        // Execute to store storage costs
        public string exec_storage_costs()
        {
            Bank = Bank - Storagecost * Inventory;
            string msg = ("Die Lagerkosten von " + ParticipantName + " betragen: " + Storagecost * Inventory);
            return msg;
        }
        
        */
        // deconstructor:

    }
}

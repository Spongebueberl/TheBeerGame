using System;
using System.Collections.Generic;
using System.Text;

namespace The_Beer_Game
{
    public class Participant
    {
        // create variables for class:
        string ParticipantName = "";
        int Inventory = 0;
        int Bank = 0;

        // class constructor:
        public Participant(string name, int inv, int money)
        {
            // set inventory and bank to given values at class initialization:
            ParticipantName = name;
            Inventory = inv;
            Bank = money;
        }

        // Method to show inventory:
        public (string, int) get_inventory()
        {
            return (ParticipantName, Inventory);
        }

        // Method to show bank:
        public (string, int) get_bank()
        {
            return (ParticipantName, Bank);
        }

        public (string, int) set_bank(int money)
        {
            Bank += money;
            return (ParticipantName, Bank);
        }

        public (string, int) set_inventory(int amount)
        {
            Inventory += amount;
            return (ParticipantName, Inventory);
        }

        /*
        // Method to receive order:
        public (string, int, double) receive_order(int amount, int price)
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
        public void place_order(int amount, int price)
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
        public int get_opencontracts()
        {
            return Contracts;
        }

        // Method to store non executed contracts
        public void open_contracts(int amount)
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
        ~Participant()
        {
            // tbd
        }
    }
}

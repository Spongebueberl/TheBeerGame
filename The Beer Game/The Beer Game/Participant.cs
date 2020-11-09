using System;
using System.Collections.Generic;
using System.Text;

namespace The_Beer_Game
{
    public class Participant
    {
        // create variables for class:
        int Inventory = 0;
        int Bank = 0;
        int Contracts = 0;
        int Storagecost = 0;

        // class constructor:
        public Participant(int inv, int money, int storagecost)
        {
            // set inventory and bank to given values at class initialization:
            Inventory = inv;
            Bank = money;
            Storagecost = storagecost;
        }

        // Method to show inventory:
        public int get_inventory()
        {
            return Inventory;
        }

        // Method to show bank:
        public int get_bank()
        {
            return Bank;
        }

        // Method to receive order:
        public void receive_order(int amount, int price)
        {
            if (Inventory - amount >=0) 
            {
                Inventory = Inventory - amount;
                Bank = Bank + price * amount;
            }
            else
            {
                Console.WriteLine("Nicht genügend Ware am Lager!");
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
            string msg = ("Die Lagerkosten betragen: " + Storagecost * Inventory);
            return msg;
        }

        // deconstructor:
        ~Participant()
        {
            // tbd
        }
    }
}

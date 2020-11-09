using System;
using System.Collections.Generic;
using System.Text;

namespace The_Beer_Game
{
    class Participant
    {
        // create variables for class:
        int Inventory = 0;
        int Bank = 0;
        int Contracts = 0;

        // class constructor:
        Participant(int inv, int money, int storagecost)
        {
            // set inventory and bank to given values at class initialization:
            Inventory = inv;
            Bank = money;
            Storagecost = storagecost;
        }
        
        // Method to show inventory:
        int get_inventory()
        {
            return Inventory;
        }
        
        // Method to show bank:
        int get_bank()
        {
            return Bank;
        }
        
        // Method to receive order:
        void receive_order(int amount, int price)
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
        void place_order(int amount, int price)
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
        int get_opencontracts()
        {
            return Contracts;
        }
        
        // Method to store non executed contracts
        int open_contracts(int amount, int price)
        {
            if(Inventory <=0)
            {
                Contracts = Contracts + amount;
            }
        }

        // Execute to store storage costs


        // deconstructor:
        ~Participant()
        {
            // tbd
        }
    }
}

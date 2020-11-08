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
        
        // class constructor:
        Participant(int inv, int money)
        {
            // set inventory and bank to given values at class initialization:
            Inventory = inv;
            Bank = money;
        }
        
        // Method to show inventory:
        int get_invetory()
        {
            return Invetory;
        }
        
        // Method to show bank:
        void get_bank()
        {
            return Bank;
        }
        
        // Method to receive order:
        void receive_order(int amount, int price)
        {
            
        }
        
        // Method to place order:
        void place_order(int amount, int price)
        {
            
        }
        
        // Method to process incoming goods:
        void incoming_goods(int amount)
        {
            
        }
        
        // Method to process outgoing goods:
        void outgoing_goods(int amount)
        {
            
        }
        
        // deconstructor:
        ~Participant()
        {
            // tbd
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Text;

namespace The_Beer_Game
{
    public class Participant
    {
        // create variables for class:
        string ParticipantName = "";
        double Inventory = 0;
        double Bank = 0;
        double goods_ordered = 0;
        bool Expressbutton = true;

        // class constructor:
        public Participant(string name, double inv, double money)
        {
            // set inventory and bank to given values at class initialization:
            ParticipantName = name;
            Inventory = inv;
            Bank = money;            
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

        public (string, double) execute_order(double amount) 
        {
            Inventory += amount;
            return (ParticipantName, Inventory);
        }

        public (string, bool) get_checkbutton()
        {
            return (ParticipantName, Expressbutton);
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
        ~Participant()
        {
            // tbd
        }
    }
}

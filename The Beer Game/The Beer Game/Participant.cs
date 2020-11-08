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
        
    }

}

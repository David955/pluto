using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class Player
    {
        public static string CurrentRoom;       // location, where player is
        public static string CurrentInventory;  // items in inventory
        public static string Map;               // ASCII picture of space station and players location
        public static string Text;              // all previously generated text
        public static int health = 100;         // 
        public static int armor = 0;            // 
        public static int experience = 0;       // 

    }
}

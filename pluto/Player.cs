using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class Player
    {
        public string name;              // name of your character
        public string currentRoom;       // location, where player is
        public string currentInventory;  // items in inventory
        //public string mapPossiton;       // ASCII picture of space station and players location
        //public string text;              // all previously generated text
        public int health = 100;         // 
        public int armorValue = 0;       // 
        public int attack = 10;          // default unarmed attack
        public int experience = 0;       // 

        // LM = last mentrioned, in-game reffered to as "it", "that" or "there" (drop it, use it, go there, take that)
        //public string lm_item;
        //public string lm_room;
        //public string lm_thing; // item, room or anything that was last mentioned in previous dialog

    }
}

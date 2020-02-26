using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class Program
    {
        static void Main(string[] args)
        {
            // these two strings will be part of player class
            //string CurrentRoom;
            //string CurrentInventory;

            Settings s = new Settings();
            s.SetGame();
            //SaveToTemp.Save();
            
            MainMenu m = new MainMenu();
            m.NewGameMenu();

            // save game 
            /*
            SaveGame n = new SaveGame();
            n.SaveToText();

            Console.ReadKey();
            */
        }
    }
}
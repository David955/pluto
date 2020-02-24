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
            string CurrentRoom;
            string CurrentInventory;

            Settings.SetGame();
            Console.ReadKey();

            // save game 
            SaveGame n = new SaveGame();
            n.SaveToText();

            // load game
            LoadGame m = new LoadGame();
            CurrentRoom = m.LoadRoom();
            CurrentInventory = m.LoadInventory();

            Console.WriteLine(CurrentRoom);
            Console.WriteLine(CurrentInventory);

            Console.ReadKey();
        }
    }
}
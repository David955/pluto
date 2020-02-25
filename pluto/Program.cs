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
            string CurrentRoom;
            string CurrentInventory;

            Settings s = new Settings();
            s.SetGame();
            //SaveToTemp.Save();
            Console.ReadKey();

            // save game 
            SaveGame n = new SaveGame();
            n.SaveToText();

            Console.ReadKey();

            // load game
            LoadGame m = new LoadGame();
            LoadGame.InitiateLoading();
            CurrentRoom = m.LoadRoom();
            CurrentInventory = m.LoadInventory();
            LoadGame.FinishLoading();

            // show if saved data is loaded corectly
            //Console.WriteLine(CurrentRoom);
            //Console.WriteLine(CurrentInventory);

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            
            // delete txt file after closing game
            // File.Delete("../../../../temp.txt");
        }
    }
}
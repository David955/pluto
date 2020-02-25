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

            Console.ReadKey();

            // load game
            LoadGame m = new LoadGame();
            LoadGame.InitiateLoading();
            CurrentRoom = m.LoadRoom();
            CurrentInventory = m.LoadInventory();
            LoadGame.FinishLoading();

            //Console.WriteLine(CurrentRoom);
            //Console.WriteLine(CurrentInventory);

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}
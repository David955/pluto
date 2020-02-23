using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;     //for read & write .txt files
using System.Runtime.InteropServices; //for wondow size and maximize lock (https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute?view=netframework-4.8)

namespace pluto
{
    class Program
    {
        // window size and maximize lock 
        

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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class LoadGame
    {
        StreamReader m = new StreamReader("../../../../save_file.txt");

        public static void LoadingSequence()
        {
            InitiateLoading();
            FinishLoading();
        }

        public static void InitiateLoading()
        {
            // loading animation
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 43);
            Console.WriteLine("Loading...");
            var WaitMan = new WaitMan(10, 43);

            WaitMan.Start();
            Thread.Sleep(2500);
            WaitMan.Stop();
        }

        public string LoadRoom()
        {
            // read save data from .txt file (https://stackoverflow.com/questions/6768151/get-values-from-textfile-with-c-sharp)
            var save_data = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return save_data["LastRoom"];
        }

        public string LoadInventory()
        {
            var save_data = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return save_data["LastInventory"];
        }

        public static void FinishLoading()
        {
            // sends data from file to variables in Player class
            LoadGame m = new LoadGame();
            Player.CurrentRoom = m.LoadRoom();
            Player.CurrentInventory = m.LoadInventory();
            // after last loading operation, press enter to start loaded game
            Console.SetCursorPosition(0, 43);
            Console.Write("GAME LOADED - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("press"); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ENTER");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" to START");
            // show loaded data
            //Console.Write(Player.CurrentInventory + Player.CurrentRoom);

            Music.SystemSound();
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }
    }
}
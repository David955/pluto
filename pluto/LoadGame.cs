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

        public static void InitiateLoading()
        {
            // loading animation
            Console.SetCursorPosition(0, 43);
            Console.WriteLine("Loading...");
            var WaitMan = new WaitMan(11, 43);

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
            // after last loading operation, press enter to start loaded game
            Console.SetCursorPosition(0, 43);
            Console.WriteLine("GAME LOADED - PRESS ENTER TO CONTINUE");

            // don't play sound after loading, when player turned it off in settings menu
            Settings s = new Settings();
            if (s.Sounds == true)
            {
                Music.SystemSound();
            }
        }
    }
}
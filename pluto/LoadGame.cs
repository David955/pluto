using System;
using System.IO;
using System.Linq;
using System.Threading;

/* This class contains 1 + X functions:
 * First one is "LoadingAnimation" which informs player when game loads sved data and when is process finished.
 * Other X functions are for loading X values that player saved into save_file.txt (name, last possition, settings,...) 
 * 
 * If player chosed "LOAD GAME" option in main menu, boolean variable "gameLoaded" in MainMenu class is set to true.
 * Finaly in Game class, function "Play" contains condition which check value of "gameLoaded" variable and if true, loads data from save_data.txt to
 * new instance of Player class called "ThePlayer" - each value (name, inventory,...) separately with functions from this class.
 * 
 * 
 * Check MainMenu.cs line 8 for variable gameLoaded
 * Check MainMenu.cs lines 82 to 102 for complete process of loading previous game
 * Check Game.cs line 13 for condition for loading values for current player (instance ThePlayer)
 * 
 * 
 * resources: https://stackoverflow.com/questions/6768151/get-values-from-textfile-with-c-sharp
 */

namespace pluto
{
    class LoadGame
    {
        StreamReader m = new StreamReader("../../../../save_file.txt");

        public static void LoadingAnimation()
        {
            // loading animation
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 43);
            Console.WriteLine("Loading...");
            var WaitMan = new WaitMan(10, 43);

            WaitMan.Start();
            Thread.Sleep(2500);
            WaitMan.Stop();

            // after last loading operation, press enter to start loaded game
            Console.SetCursorPosition(0, 43);
            Console.Write("GAME LOADED - ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("press");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ENTER");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" to START");

            Music.SystemSound();
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }

        // functions for settings
        public string LoadSounds()
        {
            var set_sounds = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return set_sounds["sounds"];
        }

        public string LoadIntroSong()
        {
            var set_song = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return set_song["introSong"];
        }

        public string LoadResize()
        {
            var set_size = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return set_size["resize"];
        }

        // functions for ThePlayer variables
        public string LoadRoom()
        {
            var saved_room = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return saved_room["LastRoom"];
        }

        public string LoadInventory()
        {
            var saved_inventory = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);
            var p = new Player();

            m.Close();
            return saved_inventory["LastInventory"];
        }
    }
}
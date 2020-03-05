using System;
using System.IO;
using System.Threading;

namespace pluto
{
    class SaveGame
    {
        StreamWriter n = new StreamWriter("../../../../save_file.txt", false);
        public void SaveToText()
        {
            // save animation
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 43);
            Console.WriteLine("saving...");
            var WaitMan = new WaitMan(9, 43);

            WaitMan.Start();
            Thread.Sleep(2500);

            // settings (only values 1 or 0)
            n.WriteLine("sounds = 1");
            n.WriteLine("introSong = 0");
            n.WriteLine("resize = 0");

            // player data
            n.WriteLine("LastRoom = 1");
            n.WriteLine("LastInventory = 0");
            n.Flush();
            n.Close();

            WaitMan.Stop();

            Console.SetCursorPosition(0, 43);
            Console.WriteLine("GAME SAVED");

            Music.SystemSound();
        }
    }
}
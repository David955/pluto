﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class SaveGame
    {
        StreamWriter n = new StreamWriter("../../../../save_file.txt", false);
        public void SaveToText()
        {
            // save animation
            Console.SetCursorPosition(0, 43);
            Console.WriteLine("saving...");
            var WaitMan = new WaitMan(9, 43);           
            
            WaitMan.Start();
            Thread.Sleep(2500);
            
            // write to file
            n.WriteLine("LastRoom = 7");
            n.WriteLine("LastInventory = 1");
            n.Flush();
            n.Close();

            WaitMan.Stop();

            Console.SetCursorPosition(0, 43);
            Console.WriteLine("GAME SAVED");

            // don't play sound after saving, when player turned it off in settings menu
            Settings s = new Settings();
            if (s.Sounds == true)
            {
                Music.SystemSound();
            }
        }
    }
}
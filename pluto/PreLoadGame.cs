using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class PreLoadGame
    {
        public bool CheckSaveFile()
        {
            try
            {
                // check if save_file.txt is present/reachable
                using (var fileStream = new FileStream("../../../../save_file.txt", FileMode.Open, FileAccess.Read))
                return true;
            }
            catch (IOException)
            {
                // error message
                // creates loading animation, then informs about missing save file                
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 43);
                Console.WriteLine("Loading...");
                var WaitMan = new WaitMan(10, 43);

                WaitMan.Start();
                Thread.Sleep(1500);
                WaitMan.Stop();

                Console.SetCursorPosition(0, 43);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("LOADING FAILED - save file NOT FOUND");
                return false;
            }
        }
    }
}

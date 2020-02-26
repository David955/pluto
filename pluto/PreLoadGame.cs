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
                using (var fileStream = new FileStream("../../../../save_file.txt", FileMode.Open, FileAccess.Read))
                return true;
            }
            catch (IOException)
            {
                Console.SetCursorPosition(0, 43);
                Console.WriteLine("Loading...");
                var WaitMan = new WaitMan(10, 43);

                WaitMan.Start();
                Thread.Sleep(1500);
                WaitMan.Stop();

                Console.SetCursorPosition(0, 43);
                Console.WriteLine("LOADING FAILED - SAVE FILE NOT FOUND (make sure that .exe and save_file are in same directory)");
                return false;
            }
        }

    }
}

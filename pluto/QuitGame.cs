using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class QuitGame
    {
        public static void QuitFromMenu()
        {
            Environment.Exit(0);
        }

        public void QuitGameSafely()
        {
            //quit game and delete temp file
            // File.Delete("../../../../temp.txt");
        }
    }
}

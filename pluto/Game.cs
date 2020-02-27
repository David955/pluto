using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class Game
    {
        public void intro()
        {
            // in any case, set text color to white
            Console.ForegroundColor = ConsoleColor.White;
            // make cursor visible, unlike in main menu
            Console.CursorVisible = true;
            Console.Clear();
            Console.WriteLine("new game started");
            // standard for input, inspiration from Zork
            Console.Write("> "); Console.ReadLine();
        }
    }
}

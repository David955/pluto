using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class Game
    {
        public void Play()
        {
            Console.WriteLine("this is the game");
            // standard for input, inspiration from Zork
            Console.CursorVisible = true;
            Console.Write("> "); Console.ReadLine();
        }
        
        public static void intro()
        {
            Console.WriteLine("Welcome to game!!!\n");
            Console.CursorVisible = false;
            Console.ReadKey();
        }

        public static void ClearSpace()
        {
            // in any case, set text color to white
            Console.ForegroundColor = ConsoleColor.White;
            // make cursor visible, unlike in main menu
            Console.CursorVisible = true;
            Console.Clear();
        }
    }
}

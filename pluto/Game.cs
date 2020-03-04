using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class Game
    {
        public static Player currentPlayer = new Player();

        public void Play()
        {
            Console.WriteLine("this is the game");
            // standard for input, inspiration from Zork
            Console.CursorVisible = true;
            Console.Write("> "); Console.ReadLine();
        }
        
        public static void Intro()
        {
            // introduction text
            Console.WriteLine("Welcome to game!!!\n");
            Console.WriteLine("You look through the window but all you can see is vast blackness of space. In reflection you see yourself. You are wearing standard "); 
            // here is just Write for entering players name (not WriteLine)
            Console.Write("janitor jumpsuit. When you look closer, you can even see your name badge on it. It says: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("NAME");

            // read players name
            Console.CursorVisible = true;
            Console.SetCursorPosition(89, 3);
            Console.ForegroundColor = ConsoleColor.White;
            currentPlayer.name = Console.ReadLine();
            
            // check if player entered name
            if ( currentPlayer.name == "" )
            {
                Console.SetCursorPosition(80, 3);
                Console.Write("However, you can not read it because it's covered in blood.\n");
                Console.Write("It might be from your head injury");
            }
            Console.WriteLine("\n");


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

using System;

namespace pluto
{
    class Game
    {
        public static Player ThePlayer = new Player();

        public void Play()
        {
            // if player choosed LOAD GAME option, this condition will load values from save_data.txt to "ThePlayer",
            // if not, player will start with default values from PLayer class.
            if ( MainMenu.gameLoaded == true) 
            { 
                var LoadGame = new LoadGame();
                ThePlayer.currentRoom = LoadGame.LoadRoom();
                ThePlayer.currentInventory = LoadGame.LoadInventory();
            }

            Console.WriteLine("this is the game");
            // standard for input, inspiration from Zork
            Console.CursorVisible = true;
            Console.Write("> "); Console.ReadLine();

        }

        public static void Intro()
        {
                    // PART 1 - BASIC INTRO
            Console.WriteLine("Welcome to game!!!\n");
            Console.ReadKey();

                    // PART 2 - CHARACTER CREATION
            Console.WriteLine("You look through the window but all you can see is vast blackness of space. In reflection you see yourself. You are wearing standard ");
            // used Write - not Writeline for effect
            Console.Write("janitor jumpsuit. When you look closer, you can even see your name badge on it. It says: ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("TYPE YOUR NAME");

            // read players name
            Console.CursorVisible = true;
            Console.SetCursorPosition(89, 3);
            Console.ForegroundColor = ConsoleColor.White;
            ThePlayer.name = Console.ReadLine();

            // check if player entered name
            if (ThePlayer.name == "")
            {
                Console.SetCursorPosition(80, 3);
                Console.Write("However, you can not read it because it's covered in blood.\n");
                Console.Write("It might be from your head injury");
            }
            Console.WriteLine("\n");

                    // PART 3 - TUTORIAL

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

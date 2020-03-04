using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pluto
{
    class MainMenu
    {
        public static void NewGameMenu()
        {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.White;
            // this and ONLY this WriteLine needs 85 characters in order to delete previous "press ENTER to START" 
            Console.WriteLine("                                                               version 0.1           \n\n"); 
            Console.WriteLine("                                                               > NEW GAME");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 LOAD GAME");
            Console.WriteLine("                                                                 SETTINGS");
            Console.WriteLine("                                                                 QUIT");
            // sets text to black, so no input in menu is visible
            Console.ForegroundColor = ConsoleColor.Black;

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        // when loading after previous failed loading, this will clear the bottom error text 
                        Console.SetCursorPosition(0, 43);
                        Console.WriteLine("                                                                                                                ");
                        // plays quick loading animation, then starts GAME
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 43);
                        Console.WriteLine("Starting...");
                        var WaitMan = new WaitMan(11, 43);

                        WaitMan.Start();
                        Thread.Sleep(1500);
                        WaitMan.Stop();

                        Game.ClearSpace();
                        Game.intro();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        LoadGameMenu();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        NewGameMenu();
                        return;
                    case ConsoleKey.Escape:
                        Music.NoSound();
                        QuitGame.QuitFromMenu();
                        return;
                }
            }
        }

        public static void LoadGameMenu()
        {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 NEW GAME");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               > LOAD GAME");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 SETTINGS");
            Console.WriteLine("                                                                 QUIT");
            // sets text to black, so no input in menu is visible
            Console.ForegroundColor = ConsoleColor.Black;

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        // this will clear the bottom error text when loading after previous failed loading
                        Console.SetCursorPosition(0, 43);
                        Console.WriteLine("                                                                                                                ");
                        // PreLoadGame checks if is save file present
                        PreLoadGame p = new PreLoadGame();
                        if (p.CheckSaveFile() == true)
                        {
                            // if is file present, players position is loaded from file
                            LoadGame.LoadingSequence();
                        }
                        else
                        {
                            // else error message from PreLoadGame is displayed, then return to main menu
                            Music.SystemSound();
                            LoadGameMenu();
                        }
                        Game.ClearSpace();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        NewGameMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        SettingsMenu();
                        return;
                    case ConsoleKey.Escape:
                        Music.NoSound();
                        QuitGame.QuitFromMenu();
                        return;
                }
            }
        }
        
        public static void SettingsMenu()
        {
            // SettingsMenu has additional spaces in WriteLine in order to hide previous SettingsScreen
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               version 0.1\n");
            Console.WriteLine("                                                                                                 ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 NEW GAME                        ");
            Console.WriteLine("                                                                 LOAD GAME                       ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               > SETTINGS                        ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 QUIT                            ");
            Console.WriteLine("                                                                                                 ");
            // sets text to black, so no input in menu is visible
            Console.ForegroundColor = ConsoleColor.Black;

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Settings s = new Settings();
                        s.ScreenSound();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        LoadGameMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        QuitMenu();
                        return;
                    case ConsoleKey.Escape:
                        Music.NoSound();
                        QuitGame.QuitFromMenu();
                        return;
                }
            }
        }

        public static void QuitMenu()
        {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 NEW GAME");
            Console.WriteLine("                                                                 LOAD GAME");
            Console.WriteLine("                                                                 SETTINGS");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               > QUIT");
            // sets text to black, so no input in menu is visible
            Console.ForegroundColor = ConsoleColor.Black;

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Music.NoSound();
                        QuitGame.QuitFromMenu();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        SettingsMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        QuitMenu();
                        return;
                    case ConsoleKey.Escape:
                        Music.NoSound();
                        QuitGame.QuitFromMenu();
                        return;
                }
            }
        }
    }
}

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
        public void NewGameMenu()
        {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               version 0.1            \n\n");
            Console.WriteLine("                                                               > NEW GAME");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 LOAD GAME");
            Console.WriteLine("                                                                 SETTINGS");
            Console.WriteLine("                                                                 QUIT");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        // plays quick loading animation, then starts GAME
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 43);
                        Console.WriteLine("Starting...");
                        var WaitMan = new WaitMan(11, 43);

                        WaitMan.Start();
                        Thread.Sleep(1500);
                        WaitMan.Stop();

                        // core game
                        Game g = new Game();
                        g.intro();

                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        LoadGameMenu();
                        return;
                }
            }
        }

        public void LoadGameMenu()
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

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        // PreLoadGame checks if is save file present
                        PreLoadGame p = new PreLoadGame();
                        if (p.CheckSaveFile() == true)
                        {
                            // if is file present, players position is loaded from file
                            LoadGame m = new LoadGame();
                            LoadGame.InitiateLoading();
                            LoadGame.FinishLoading();
                            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
                        }
                        else
                        {
                            // else error message from PreLoadGame is displayed, then return to main menu
                            Music.SystemSound();
                            Console.ReadKey();
                            LoadGameMenu();
                        }
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        NewGameMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        SettingsMenu();
                        return;
                }
            }
        }
        
        public void SettingsMenu()
        {
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 NEW GAME");
            Console.WriteLine("                                                                 LOAD GAME");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                               > SETTINGS");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                                 QUIT");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Settings s = new Settings();
                        s.SettingsScreen();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        LoadGameMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        QuitMenu();
                        return;
                }
            }
        }

        public void QuitMenu()
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
                }
            }
        }
    }
}

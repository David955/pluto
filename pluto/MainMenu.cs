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
            Console.Clear();
            Settings.Logo();
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.WriteLine("                                                               > NEW GAME");
            Console.WriteLine("                                                                 LOAD GAME");
            Console.WriteLine("                                                                 SETTINGS");
            Console.WriteLine("                                                                 QUIT");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Console.SetCursorPosition(0, 43);
                        Console.WriteLine("Starting...");
                        var WaitMan = new WaitMan(11, 43);

                        WaitMan.Start();
                        Thread.Sleep(1500);
                        WaitMan.Stop();

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
            Console.Clear();
            Settings.Logo();
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.WriteLine("                                                                 NEW GAME");
            Console.WriteLine("                                                               > LOAD GAME");
            Console.WriteLine("                                                                 SETTINGS");
            Console.WriteLine("                                                                 QUIT");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        LoadGame m = new LoadGame();
                        LoadGame.InitiateLoading();
                        LoadGame.FinishLoading();
                        while(Console.ReadKey().Key != ConsoleKey.Enter) { }
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
            Console.Clear();
            Settings.Logo();
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.WriteLine("                                                                 NEW GAME");
            Console.WriteLine("                                                                 LOAD GAME");
            Console.WriteLine("                                                               > SETTINGS");
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
            Console.Clear();
            Settings.Logo();
            Console.WriteLine("                                                               version 0.1\n\n");
            Console.WriteLine("                                                                 NEW GAME");
            Console.WriteLine("                                                                 LOAD GAME");
            Console.WriteLine("                                                                 SETTINGS");
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

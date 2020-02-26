using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pluto
{
    class MainMenu
    {
        public void NewGameMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"                                          _____________                          __________      ");
            Console.WriteLine(@"                                          __  ____/__(_)______ ______ _______ ______(_)_  /_____ ");
            Console.WriteLine(@"                                          _  / __ __  /__  __ `/  __ `/_  __ `__ \_  /_  __/  _ \");
            Console.WriteLine(@"                                          / /_/ / _  / _  /_/ // /_/ /_  / / / / /  / / /_ /  __/");
            Console.WriteLine(@"                                          \____/  /_/  _\__, / \__,_/ /_/ /_/ /_//_/  \__/ \___/ ");
            Console.WriteLine("                                                       /____/                                    \n");
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
                        Game g = new Game();
                        g.intro();
                        return;
                    case ConsoleKey.DownArrow:
                        LoadGameMenu();
                        return;
                }
            }
        }

        public void LoadGameMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"                                          _____________                          __________      ");
            Console.WriteLine(@"                                          __  ____/__(_)______ ______ _______ ______(_)_  /_____ ");
            Console.WriteLine(@"                                          _  / __ __  /__  __ `/  __ `/_  __ `__ \_  /_  __/  _ \");
            Console.WriteLine(@"                                          / /_/ / _  / _  /_/ // /_/ /_  / / / / /  / / /_ /  __/");
            Console.WriteLine(@"                                          \____/  /_/  _\__, / \__,_/ /_/ /_/ /_//_/  \__/ \___/ ");
            Console.WriteLine("                                                       /____/                                    \n");
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
                        NewGameMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        SettingsMenu();
                        return;
                }
            }
        }
        
        public void SettingsMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"                                          _____________                          __________      ");
            Console.WriteLine(@"                                          __  ____/__(_)______ ______ _______ ______(_)_  /_____ ");
            Console.WriteLine(@"                                          _  / __ __  /__  __ `/  __ `/_  __ `__ \_  /_  __/  _ \");
            Console.WriteLine(@"                                          / /_/ / _  / _  /_/ // /_/ /_  / / / / /  / / /_ /  __/");
            Console.WriteLine(@"                                          \____/  /_/  _\__, / \__,_/ /_/ /_/ /_//_/  \__/ \___/ ");
            Console.WriteLine("                                                       /____/                                    \n");
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
                        LoadGameMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        QuitMenu();
                        return;
                }
            }
        }

        public void QuitMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"                                          _____________                          __________      ");
            Console.WriteLine(@"                                          __  ____/__(_)______ ______ _______ ______(_)_  /_____ ");
            Console.WriteLine(@"                                          _  / __ __  /__  __ `/  __ `/_  __ `__ \_  /_  __/  _ \");
            Console.WriteLine(@"                                          / /_/ / _  / _  /_/ // /_/ /_  / / / / /  / / /_ /  __/");
            Console.WriteLine(@"                                          \____/  /_/  _\__, / \__,_/ /_/ /_/ /_//_/  \__/ \___/ ");
            Console.WriteLine("                                                       /____/                                    \n");
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
                        QuitGame.QuitFromMenu();
                        return;
                    case ConsoleKey.UpArrow:
                        SettingsMenu();
                        return;
                }
            }
        }
    }
}

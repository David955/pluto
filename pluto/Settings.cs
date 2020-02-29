using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; 
//for wondow size and maximize lock 
//(https://social.msdn.microsoft.com/Forums/vstudio/en-US/1aa43c6c-71b9-42d4-aa00-60058a85f0eb/c-console-window-disable-resize?forum=csharpgeneral)

namespace pluto
{

    class Settings
    {
        // sound settings !!!set music on in release version!!!
        public static bool IntroSong = false;
        public static bool Sounds = true;
        public static bool Resize = false;

        private const int MF_BYCOMMAND = 0x00000000;
        public const int SC_CLOSE = 0xF060;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_SIZE = 0xF000;

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        public void SetGame()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                if (Resize == false)
                {
                    DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
                }
                // !!!uncoment this in final release to close game by deleting temp file!!!
                //DeleteMenu(sysMenu, SC_CLOSE, MF_BYCOMMAND;
            }

            Console.SetWindowSize(140, 45);
            Console.Title = "Pluto";
            // hide cursor
            Console.CursorVisible = false;
            // display logo
            Logo();

            // don't play intro song when player turned it off in settings menu
            if (IntroSong == true)
            {
                Music.Intro();
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("                                                            press");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ENTER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" to START");
            // sets text to black, so no input in start screen is visible
            Console.ForegroundColor = ConsoleColor.Black;

            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
            Music.YesSound();

        }

        public void ScreenSound()
        {
            Console.ForegroundColor = ConsoleColor.White;
                SettingsSound();
            Console.ForegroundColor = ConsoleColor.DarkGray;
                SettingsIntroSong();
                SettingsWindowSize();
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("                                                                                    ");
            Console.WriteLine("                                                      > BACK                        ");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        if (Sounds == true)
                        {
                            Sounds = false;
                        }
                        else
                        {
                            Sounds = true;
                        }

                        Music.MenuSound();
                        ScreenSound();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        ScreenIntroSong();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        ScreenSound();
                        return;
                }
            }
        }

        public void ScreenIntroSong()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
                SettingsSound();
            Console.ForegroundColor = ConsoleColor.White;
                SettingsIntroSong();
            Console.ForegroundColor = ConsoleColor.DarkGray;
                SettingsWindowSize();
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("                                                                                    ");
            Console.WriteLine("                                                      > BACK                        ");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        if (IntroSong == true)
                        {
                            IntroSong = false;
                        }
                        else
                        {
                            IntroSong = true;
                        }

                        Music.MenuSound();
                        ScreenIntroSong();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        ScreenResizeWindow();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        ScreenSound();
                        return;
                }
            }
        }

        public void ScreenResizeWindow()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
                SettingsSound();
                SettingsIntroSong();
            Console.ForegroundColor = ConsoleColor.White;
                SettingsWindowSize();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("                                                                                    ");
            Console.WriteLine("                                                      > BACK                        ");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        if (Resize == true)
                        {
                            Resize = false;
                        }
                        else
                        {
                            Resize = true;
                        }

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(0, 43);
                        Console.WriteLine("Restart needed");

                        Music.SystemSound();

                        ScreenResizeWindow();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        ScreenQuit();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        ScreenIntroSong();
                        return;
                }
            }
        }

        public void ScreenQuit()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
                SettingsSound();
                SettingsIntroSong();
                SettingsWindowSize();
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("                                                                                    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("                                                      > BACK                        ");

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Music.MenuSound();
                        MainMenu m = new MainMenu();
                        m.SettingsMenu();
                        return;
                    case ConsoleKey.DownArrow:
                        Music.MenuSound();
                        ScreenQuit();
                        return;
                    case ConsoleKey.UpArrow:
                        Music.MenuSound();
                        ScreenResizeWindow();
                        return;
                }
            }
        }

        public void SettingsSound()
        {
            Console.SetCursorPosition(0, 15);
            Console.Write("                                                      SOUNDS");
            if ( Sounds == true )
            {
                Console.Write("            > ON     OFF");
            }
            else
            {
                Console.Write("              ON   > OFF");
            }
        }

        public void SettingsIntroSong()
        {
            Console.SetCursorPosition(0, 16);
            Console.Write("                                                      INTRO SONG");
            if ( IntroSong == true )
            {
                Console.Write("        > ON     OFF");
            }
            else
            {
                Console.Write("          ON   > OFF");
            }
        }

        public void SettingsWindowSize()
        {
            Console.SetCursorPosition(0, 17);
            Console.Write("                                                      RESIZE WINDOW");
            if (Resize == true)
            {
                Console.Write("     > ON     OFF");
            }
            else
            {
                Console.Write("       ON   > OFF");
            }
        }

        public static void Logo()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n\n");
            Console.WriteLine(@"                                                        ____  _    _   _ _____ ___  ");
            Console.WriteLine(@"                                                       |  _ \| |  | | | |_   _/ _ \ ");
            Console.WriteLine(@"                                                       | |_) | |  | | | | | || | | |");
            Console.WriteLine(@"                                                       |  __/| |__| |_| | | || |_| |");
            Console.WriteLine(@"                                                       |_|   |_____\___/  |_| \___/ ");
            Console.WriteLine("                                                                           \n\n\n");
        }
    }
}

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
        public static bool sounds = true;
        public static bool introSong = false;
        public static bool resize = false;

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

        public static void SetGame()
        {
            IntPtr handle = GetConsoleWindow();
            IntPtr sysMenu = GetSystemMenu(handle, false);

            if (handle != IntPtr.Zero)
            {
                DeleteMenu(sysMenu, SC_MAXIMIZE, MF_BYCOMMAND);
                if (resize == false)
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
            Music.Intro();
            
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("                                                            press");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ENTER");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(" to START");
            // sets text to black, so no input in start screen is visible
            Console.ForegroundColor = ConsoleColor.Black;
            PressStart();
        }

        public static void PressStart()
        {
            var ch = Console.ReadKey(false).Key;
            switch (ch)
            {
                case ConsoleKey.Enter:
                    break;
                case ConsoleKey.Escape:
                    Music.NoSound();
                    QuitGame.QuitFromMenu();
                    return;
                default:
                    Music.MenuSound();
                    PressStart();
                    return;
            }
            Music.YesSound();
        }

        public void ScreenSound()
        {
            Console.ForegroundColor = ConsoleColor.White;
                SettingsSound();
            Console.ForegroundColor = ConsoleColor.DarkGray;
                SettingsIntroSong();
                SettingsWindowSize();
                RestOfScreen();

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        if (sounds == true)
                        {
                            sounds = false;
                        }
                        else
                        {
                            sounds = true;
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
                RestOfScreen();

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        if (introSong == true)
                        {
                            introSong = false;
                        }
                        else
                        {
                            introSong = true;
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
                RestOfScreen();

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.LeftArrow:
                        if (resize == true)
                        {
                            resize = false;
                        }
                        else
                        {
                            resize = true;
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
            Console.ForegroundColor = ConsoleColor.Black;

            while (true)
            {
                var ch = Console.ReadKey(false).Key;
                switch (ch)
                {
                    case ConsoleKey.Enter:
                        Music.MenuSound();
                        MainMenu.SettingsMenu();
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

        public static void RestOfScreen()
        {
            Console.SetCursorPosition(0, 18);
            Console.WriteLine("                                                                                    ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("                                                      > BACK                        ");
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void SettingsSound()
        {
            Console.SetCursorPosition(0, 15);
            Console.Write("                                                      SOUNDS");
            if ( sounds == true )
            {
                Console.Write("            > ON     OFF");
            }
            else
            {
                Console.Write("              ON   > OFF");
            }
        }

        public static void SettingsIntroSong()
        {
            Console.SetCursorPosition(0, 16);
            Console.Write("                                                      INTRO SONG");
            if ( introSong == true )
            {
                Console.Write("        > ON     OFF");
            }
            else
            {
                Console.Write("          ON   > OFF");
            }
        }

        public static void SettingsWindowSize()
        {
            Console.SetCursorPosition(0, 17);
            Console.Write("                                                      RESIZE WINDOW");
            if (resize == true)
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

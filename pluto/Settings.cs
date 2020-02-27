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
        public bool IntroSong = false;
        public bool Sounds = true;

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
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
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

        public void SettingsScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("FUTURE SETTINGS SCREEN");
            Console.ReadLine();
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

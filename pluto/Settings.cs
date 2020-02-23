using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices; //for wondow size and maximize lock (https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.dllimportattribute?view=netframework-4.8)

namespace pluto
{

    class Settings
    {
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
                DeleteMenu(sysMenu, SC_SIZE, MF_BYCOMMAND);
            }

            Console.SetWindowSize(140, 45);
            Console.Title = "Gigamite";        //use console title as status bar (room name, inventory status, health,...)
            Console.WriteLine("");
            Console.WriteLine(@"                                         _____________                          __________      ");
            Console.WriteLine(@"                                        __  ____/__(_)______ ______ _______ ______(_)_  /_____ ");
            Console.WriteLine(@"                                        _  / __ __  /__  __ `/  __ `/_  __ `__ \_  /_  __/  _ \");
            Console.WriteLine(@"                                        / /_/ / _  / _  /_/ // /_/ /_  / / / / /  / / /_ /  __/");
            Console.WriteLine(@"                                        \____/  /_/  _\__, / \__,_/ /_/ /_/ /_//_/  \__/ \___/ ");
            Console.WriteLine("                                                     /____/                                    \n\n");
            Console.WriteLine(@"                                                             version 0.1");


            Music p = new Music();
            p.PlayIntro();
        }
    }
}

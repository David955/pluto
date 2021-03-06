﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace pluto
{
    class Music
    {
        public static void Intro()
        {
            // iron maiden: caught somewhere in time, 2nd verse
            if (Settings.introSong == true)
            {
                Thread.Sleep(450);
                Console.Beep(587, 472);
                Console.Beep(523, 472);
                Console.Beep(440, 350);
                Thread.Sleep(143);
                Console.Beep(493, 472);
                Console.Beep(523, 133);
                Console.Beep(493, 93);
                Console.Beep(440, 93);
                Console.Beep(493, 1100);

                Thread.Sleep(120);

                Console.Beep(587, 1100);
                Console.Beep(523, 572);

                Thread.Sleep(230);

                Console.Beep(587, 93);
                Console.Beep(523, 93);
                Console.Beep(440, 1000);

                Thread.Sleep(150);
                Console.Beep(493, 400);
                Thread.Sleep(150);
                Console.Beep(523, 400);
            }
        }

        public static void SystemSound()
        {
            if (Settings.sounds == true)
            {
                Console.Beep(700, 150);
            }
        }

        public static void MenuSound()
        {
            if (Settings.sounds == true)
            {
                Console.Beep(200, 80);
            }
        }

        public static void YesSound()
        {
            if (Settings.sounds == true)
            {
                Console.Beep(500, 90);
                Console.Beep(700, 250);
            }
        }

        public static void NoSound()
        {
            if (Settings.sounds == true)
            {
                Console.Beep(300, 300);
                Console.Beep(200, 500);
            }
        }
    }
}
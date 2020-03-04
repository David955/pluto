using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class Program
    {
        static void Main(string[] args)
        {
            // loads settings, opens title screen
            Settings.SetGame();

            // opens main menu
            MainMenu.NewGameMenu();

            Game g = new Game();
            g.Play();

        }
    }
}

/*  UNUSED FUNCTIONS 


// save game 
SaveGame n = new SaveGame();
n.SaveToText();
Console.ReadKey();


// save temp
SaveToTemp.Save();
Console.ReadKey();


*/
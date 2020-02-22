using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;     //for read & write .txt files

namespace pluto
{
    class Program
    {
       static void Main(string[] args)
        {
            string CurrentRoom;
            string CurrentInventory;

            Console.SetWindowSize(140, 45);         
            Console.Title = "pluto";        //use console title as status bar (room name, inventory status, health,...)  
            Console.WriteLine(" OBRAZOK");
            
            Music p = new Music();
            p.PlayIntro();

                Console.ReadLine();

            // save game 
            SaveGame n = new SaveGame();
            n.SaveToText();

            // load game
            LoadGame m = new LoadGame();
            CurrentRoom = m.LoadRoom();
            CurrentInventory = m.LoadInventory();

            Console.WriteLine(CurrentRoom);
            Console.WriteLine(CurrentInventory);

                Console.ReadLine();
        }
    }
}
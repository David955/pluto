using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class SaveGame
    {
        StreamWriter n = new StreamWriter("../../../../save_file.txt", false);
        public void SaveToText()
        {

            n.WriteLine("LastRoom = 7");
            n.WriteLine("LastInventory = 1");
            n.Flush();
            n.Close();

            Console.WriteLine("GAME SAVED");
        }
    }
}
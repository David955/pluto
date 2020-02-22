using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class LoadGame
    {
        StreamReader m = new StreamReader("../../../../save_file.txt");
        public string LoadRoom()
        {
            //read save data from .txt file (https://stackoverflow.com/questions/6768151/get-values-from-textfile-with-c-sharp)
            var save_data = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return save_data["LastRoom"];
        }
        public string LoadInventory()
        {
            var save_data = File
            .ReadAllLines("../../../../save_file.txt")
            .Select(x => x.Split('='))
            .Where(x => x.Length > 1)
            .ToDictionary(x => x[0].Trim(), x => x[1]);

            m.Close();
            return save_data["LastInventory"];
        }

    }
}
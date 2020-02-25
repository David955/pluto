using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pluto
{
    class SaveToTemp
    {
        static public void Save()
        {
            // create temporary file for switchig between rooms and map page
            // http://www.java2s.com/Code/CSharp/Development-Class/DemonstratesredirectingtheConsoleoutputtoafile.htm
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            try
            {
                ostrm = new FileStream("../../../../temp.txt", FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(ostrm);
            }
            catch (Exception e)
            {
                Console.WriteLine("Cannot open Redirect.txt for writing");
                Console.WriteLine(e.Message);
                return;
            }
            Console.SetOut(writer);

            // here is the place
            Console.WriteLine("Skuska");

            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }
    }
}

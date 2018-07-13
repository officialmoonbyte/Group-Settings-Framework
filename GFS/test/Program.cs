using GlobalSettingsFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!Directory.Exists("C:\\TestD")) Directory.CreateDirectory("C:\\TestD");
            GFS gfsEditor = new GFS("C:\\TestD\\TestFile.txt");
            //Loads the port setting
            if (gfsEditor.CheckSetting("port"))
            {
                Console.WriteLine(true);
            }
            else
            {
                gfsEditor.EditSetting("port", 7777.ToString());
                Console.WriteLine(false);
            }
            Console.ReadLine();
        }
    }
}

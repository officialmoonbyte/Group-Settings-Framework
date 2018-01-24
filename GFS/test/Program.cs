using GlobalSettingsFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            GFS gfs = new GFS();
            gfs.EditSetting("wolololo", "rogen?");
            Console.WriteLine(gfs.ReadSetting("wolololo"));
            Console.Read();
        }
    }
}

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
            MoonSettings setting = new MoonSettings();
            setting.LoadAll();
            setting.SaveAll();
        }
    }
}

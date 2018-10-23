using GlobalSettingsFramework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class MoonSettings
    {
        public string Username = "Test User";
        public string Password;

        private GFS manager = new GFS();
        private string SettingsDirectory = @"C:\te\";

        public void SaveAll()
        {
            if (!Directory.Exists(SettingsDirectory)) Directory.CreateDirectory(SettingsDirectory);
            manager.SettingsDirectory = SettingsDirectory + "settings.dll";

            manager.EditSetting("user", Username);
            manager.EditSetting("pass", Password);
        }

        public void LoadAll()
        {
            if (!Directory.Exists(SettingsDirectory)) Directory.CreateDirectory(SettingsDirectory);
            manager.SettingsDirectory = SettingsDirectory + "settings.dll";

            Username = manager.ReadSetting("user");
            Password = manager.ReadSetting("pass");
        }
    }
}

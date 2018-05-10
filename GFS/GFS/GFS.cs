using GlobalSettingsFramework.Logger;
using GlobalSettingsFramework.VoidBuilds;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#region Legal stuff

/*

Copyright (c) 2017 IndieGoat

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

 */

#endregion

namespace GlobalSettingsFramework
{
    /// <summary>
    /// The GFS object
    /// </summary>
    public class GFS
    {

        List<Setting> SettingList = new List<Setting>();
        public string SettingsDirectory = null;

        public GFS(string settingsDirectory = null)
        { SettingsDirectory = settingsDirectory; }

        //Read-Setting from file
        public string ReadSetting(string SettingName)
        {
            if (SettingsDirectory == null) SettingsDirectory = GetSettingDirectory;
            return ClassRead.ReadSetting(SettingName, SettingsDirectory);
        }

        //Edit-Setting from file
        public void EditSetting(string SettingName, string SettingValue)
        {
            if (SettingsDirectory == null) SettingsDirectory = GetSettingDirectory;
            ClassEdit.EditSetting(SettingName, SettingValue, SettingsDirectory);
        }

        public void EditSetting(string SettingName, string SettingValue, string FileDirectory)
        {
            if (SettingsDirectory == null) SettingsDirectory = GetSettingDirectory;
            ClassEdit.EditSetting(SettingName, SettingValue, FileDirectory);
        }

        //Check-Setting from file
        public bool CheckSetting(string SettingName)
        {
            if (SettingsDirectory == null) SettingsDirectory = GetSettingDirectory;
            return ClassCheck.CheckSetting(SettingName, GetSettingDirectory);
        }

        #region Directory Methods

        /// <summary>
        /// The default directory for the setting file
        /// </summary>
        string GetMainDirectory
        {
            get
            {
                //The name of the application
                string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                //Set a local var as the directory
                string mainDirectory = @"C:\" + "Vortex Studio" + @"\" + name + @"\";

                //Check if directory exist
                if (Directory.Exists(mainDirectory)) Directory.CreateDirectory(mainDirectory);

                //Returns the main directory
                return mainDirectory;
            }
        }

        string GetSettingDirectory
        {
            get
            {
                //The name of the application
                string name = System.Diagnostics.Process.GetCurrentProcess().ProcessName;

                //Set a local var as the directory
                string directory = @"C:\" + "IndieGoat" + @"\" + name + @"\";

                //Set a local var as the directory to the setting file
                string settingDirectory = directory + "Settings.set";

                //Check if the directory exist
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);

                //Check if the setting file exist
                if (!File.Exists(settingDirectory)) File.Create(settingDirectory).Close();

                //Return the setting directory
                return settingDirectory;
            }
        }

        #endregion

    }

    public class Setting
    {
        //Setting both the name and the value for the setting
        public string Name;
        public string Value;

        /// <summary>
        /// Used to set the Name and the Value of the setting
        /// </summary>
        public Setting(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}

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

namespace GlobalSettingsFramework.VoidBuilds
{
    public class ClassEdit
    {
        /// <summary>
        /// Used to edit a setting in the array
        /// </summary>
        /// <param name="_SettingName">The name of the setting</param>
        /// <param name="_SettingValue">The value of th setting</param>
        /// <param name="_FileDirectory">The directory of the setting</param>
        public static void EditSetting(string _SettingName, string _SettingValue, string _FileDirectory)
        {
            //Initializing the Seperators
            string[] Seperators = { "|:%20%:|" };

            //Check if the file exist
            if (!File.Exists(_FileDirectory)) File.Create(_FileDirectory).Close();

            //Check for invalid characters
            if (_SettingName.Contains(Seperators[0]) || _SettingValue.Contains(Seperators[0]))
            {
                //Error message for invalid characters
                Console.WriteLine("[Vortex Studio] Cannot edit a setting with the charaters |:%20%:|");
                return;
            }

            //Setting the list of file content
            List<string> fileContent = new List<string>();

            try
            {
                //Read the setting file
                fileContent = File.ReadAllLines(_FileDirectory).ToList();

                //For each content in file
                for (int i = 0; i < fileContent.Count(); i++)
                {
                    //Set the temp var for file content
                    string[] temp = fileContent[i].Split(Seperators, StringSplitOptions.None);

                    //Checks if the temp file name is equal to destinated setting name
                    if (temp[0] == _SettingName)
                    {
                        //Edit the setting
                        fileContent[i] = temp[0] + Seperators[0] + _SettingValue;
                        break;
                    }
                    else if (i == (fileContent.Count() - 1))
                    {
                        //Remove the setting and then readd it
                        fileContent.Remove(_SettingName + Seperators[0] + temp[1]);
                        fileContent.Add(_SettingName + Seperators[0] + _SettingValue);
                    }
                }

                //Add the setting if we have no stored settings
                if (fileContent.Count() == 0) fileContent.Add(_SettingName + Seperators[0] + _SettingValue);

                //Write all of the lines to the file
                File.WriteAllLines(_FileDirectory, fileContent);
            }
            catch (Exception e)
            {
                Console.WriteLine("[Vortex Studio] Error in GFS : " + e.ToString());
                return;
            }
        }
    }
}

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
    public class ClassCheck
    {
        /// <summary>
        /// Use to check if the setting exist
        /// </summary>
        /// <param name="_SettingName">The name of the setting in the file</param>
        /// <param name="_FileDirectory">The directory of the file</param>
        /// <returns></returns>
        public static bool CheckSetting(string _SettingName, string _FileDirectory)
        {
            //Initializing the seperators
            string[] Seperators = { "|:%20%:|" };

            //Check if the setting file exist
            if (!File.Exists(_FileDirectory)) File.Create(_FileDirectory).Close();

            //Initializing the FileContent
            List<string> fileContent = new List<string>();

            try
            {
                //Reading the file
                fileContent = File.ReadAllLines(_FileDirectory).ToList();

                //For each file in FileContent
                for (int i = 0; i < fileContent.Count; i++)
                {
                    //Register the temp Split
                    string[] tempSplit = fileContent[i].Split(Seperators, StringSplitOptions.None);

                    //Check if temp split name is equal to string name
                    if (tempSplit[0] == _SettingName)
                    {
                        return true;
                    }
                }

                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("[VortexStudio] Error in GFS : " + e.ToString());
                return false;
            }
        }
    }
}

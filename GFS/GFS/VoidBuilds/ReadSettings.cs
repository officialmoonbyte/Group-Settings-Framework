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

namespace GFS.VoidBuilds
{
    public class ClassRead
    {
        public static string ReadSetting(string SettingName, string FileDirectory)
        {
            //All private vars
            string file = FileDirectory;
            string[] Seperators = { "|:%20%:|" };

            List<string> FileContent = new List<string>();

            //Checking if the file exist. If not, then create it
            if (!File.Exists(file)) File.Create(file).Close();

            //Try event for logging errors
            try
            {
                //Reading the setting file
                FileContent = File.ReadAllLines(file).ToList();

                //Getting the value
                for (int i = 0; i < FileContent.Count(); i++)
                {
                    //Temp split
                    string[] tmp = FileContent[i].Split(Seperators, StringSplitOptions.None);

                    //Check if value is eual to setting name
                    if (tmp[0] == SettingName)
                    {
                        //Returns the value of the setting
                        return tmp[1];
                    }
                }

                Console.WriteLine("Could not find setting file.");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine("[IndieGoat] ERROR IN GFS : " + e.ToString());
                return null;
            }

        }
    }
}

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    class Comands
    {
        public void GetComands(int startRow, int startCol)
        {
            Content content = new Content();
            CheckInputData cid = new CheckInputData(startRow, startCol);
            Error error = new Error();

            string[] subStrings = cid.SubString();

            switch (subStrings[0])
            {
                case "ls":
                    content.OpenContent(subStrings[1], Convert.ToInt32(subStrings[3]));
                    File.WriteAllText("LastOpenPath.txt", $"{subStrings[0]} {subStrings[1]} {subStrings[2]} {subStrings[3]}");
                    break;

                case "cpdir":
                    try
                    {
                        CopyDirectoryFiles(subStrings[1], subStrings[2]);
                    }
                    catch(Exception e)
                    {
                        error.OutputErrorConsole(e.Message, "", startRow, startCol, 3);
                    }
                    break;

                case "cpfile":
                    try
                    {
                        File.Copy(subStrings[1], subStrings[2], true);
                    }
                    catch (Exception e)
                    {
                        error.OutputErrorConsole(e.Message, "", startRow, startCol, 3);
                    }
                    break;

                case "rmdir":
                    try
                    {
                        Directory.Delete(subStrings[1], true);
                    }
                    catch (Exception e)
                    {
                        error.OutputErrorConsole(e.Message, "", startRow, startCol, 3);
                    }
                    break;

                case "rmfile":
                    try
                    {
                        File.Delete(subStrings[1]);
                    }
                    catch (Exception e)
                    {
                        error.OutputErrorConsole(e.Message, "", startRow, startCol, 3);
                    }
                    break;

                case "file":
                    try
                    {
                        content.InfoFile(subStrings[1]);
                    }
                    catch (Exception e)
                    {
                        error.OutputErrorConsole(e.Message, "", startRow, startCol, 3);
                    }
                    break;
            }
        }


        //Метод копирует файлы и папки
        private void CopyDirectoryFiles(string from, string to)
        {
            foreach (var dirPath in Directory.GetDirectories(from, "*", SearchOption.AllDirectories))
            {
                try
                {
                    Directory.CreateDirectory(dirPath.Replace(from, to));
                }
                catch (Exception e) 
                {
                    Console.WriteLine(e.Message);
                }
            }

            foreach(var path in Directory.GetFiles(from, "*", SearchOption.AllDirectories))
            {
                try
                {
                    File.Copy(path, path.Replace(from, to), true);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }        
    }
}

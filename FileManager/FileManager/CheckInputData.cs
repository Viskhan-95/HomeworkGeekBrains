using System;
using System.IO;

namespace FileManager
{
    class CheckInputData
    {
        private int StartRow { get; set; }
        private int StartCol { get; set; }
        
        string[] subStrings;

        Error error = new Error();

        public CheckInputData(int startRow, int startCol)
        {
            StartRow = startRow;
            StartCol = startCol;
        }


        //Метод разбивает строку на подстроки
        public string[] SubString()
        {
            Console.SetCursorPosition(StartRow, StartCol);
            bool correctComand = false;
            string comand = string.Empty;

            while (!correctComand)
            {
                comand = Console.ReadLine();

                while (string.IsNullOrWhiteSpace(comand))
                {
                    Console.SetCursorPosition(StartRow, StartCol);
                    comand = Console.ReadLine();
                }

                correctComand = CheckComand(comand.Trim());
            }

            return subStrings;
        }


        //Метод проверяет правильность введенной команды
        public bool CheckComand(string cmd)
        {
            subStrings = null;
            string splitString = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];

            bool correctComand = false;

            switch(splitString.ToLower())
            {
                case "ls":
                    subStrings = new string[4];
                    subStrings[0] = splitString.ToLower();

                    if (cmd.IndexOf("-p") == -1)
                        error.OutputErrorConsole("Неккоректный ввод", cmd, StartRow, StartCol, 3);
                    else if (!CheckDirectory(cmd.Substring(cmd.IndexOf(":\\") - 1, cmd.IndexOf("-p") - cmd.IndexOf(":\\")).Trim()))
                        error.OutputErrorConsole("Некорректно введен путь к директории", cmd, StartRow, StartCol, 3);
                    else if (!CheckPage(cmd[cmd.Length - 1].ToString().Trim()))
                        error.OutputErrorConsole("Неккоректен номер страницы", cmd, StartRow, StartCol, 3);
                    else
                    {
                        error.OutputErrorConsole("", cmd, StartRow, StartCol, 3);
                        subStrings[1] = cmd.Substring(cmd.IndexOf(":\\") - 1, cmd.IndexOf("-p") - cmd.IndexOf(":\\")).Trim();
                        subStrings[2] = "-p";
                        subStrings[3] = cmd[cmd.Length - 1].ToString().Trim();
                        correctComand = true;
                    }
                    break;

                case "cp":
                    subStrings = new string[3];

                    if (cmd.IndexOf(":\\") == -1 || cmd.LastIndexOf(":\\") == -1)
                        error.OutputErrorConsole("Неккоректный ввод", cmd, StartRow, StartCol, 3);
                    else
                    {
                        subStrings[1] = cmd.Substring(cmd.IndexOf(":\\") - 1, cmd.LastIndexOf(":\\") - cmd.IndexOf(":\\") - 1).Trim();
                        subStrings[2] = cmd.Substring(cmd.LastIndexOf(":\\") - 1).Trim();
                        error.OutputErrorConsole("", cmd, StartRow, StartCol, 3);
                    }

                    if(cmd.IndexOf('.') == -1)
                    {
                        if (CheckDirectory(subStrings[1]) || CheckDirectory(subStrings[2]))
                        {
                            correctComand = true;
                            subStrings[0] = splitString.ToLower() + "dir";
                        }
                        else
                            error.OutputErrorConsole("Некорректно введен путь", cmd, StartRow, StartCol, 3);
                    }
                    else
                    {
                        if (CheckFile(subStrings[1]) || CheckFile(subStrings[2]))
                        {
                            correctComand = true;
                            subStrings[0] = splitString.ToLower() + "file";
                        }
                        else
                            error.OutputErrorConsole("Некорректно введен путь", cmd, StartRow, StartCol, 3);
                    }
                    break;

                case "rm":
                    subStrings = new string[2];
                    if (cmd.IndexOf(":\\") == -1)
                        error.OutputErrorConsole("Неккоректный ввод", cmd, StartRow, StartCol, 3);
                    else
                    {
                        subStrings[1] = cmd.Substring(cmd.IndexOf(":\\") - 1).Trim();
                        error.OutputErrorConsole("", cmd, StartRow, StartCol, 3);
                    }

                    if (cmd.IndexOf('.') == -1)
                    {
                        if (CheckDirectory(subStrings[1]))
                        {
                            correctComand = true;
                            subStrings[0] = splitString.ToLower() + "dir";
                        }
                        else
                            error.OutputErrorConsole("Некорректно введен путь", cmd, StartRow, StartCol, 3);
                    }
                    else
                    {
                        if (CheckFile(subStrings[1]))
                        {
                            correctComand = true;
                            subStrings[0] = splitString.ToLower() + "file";
                        }
                        else
                            error.OutputErrorConsole("Некорректно введен путь", cmd, StartRow, StartCol, 3);
                    }
                    break;

                case "file":
                    subStrings = new string[2];
                    subStrings[0] = splitString.ToLower();

                    if (cmd.IndexOf(":\\") == -1)
                        error.OutputErrorConsole("Неккоректный ввод", cmd, StartRow, StartCol, 3);
                    else
                    {
                        subStrings[1] = cmd.Substring(cmd.IndexOf(":\\") - 1).Trim();
                        error.OutputErrorConsole("", cmd, StartRow, StartCol, 3);
                    }

                    if (CheckFile(subStrings[1]))
                        correctComand = true;
                    else
                        error.OutputErrorConsole("Некорректно введен путь", cmd, StartRow, StartCol, 3);
                    break;
                
                default:
                    error.OutputErrorConsole("Неккоректный ввод", cmd, StartRow, StartCol, 3);
                    break;
            }
            return correctComand;
        }


        //Метод проверяет номер страницы
        public bool CheckPage(string page)
        {
            bool checkRezult = false;

            if (int.TryParse(page, out int rezult))
            {
                if (rezult > 0 && rezult < 3)
                    checkRezult = true;
                else
                    checkRezult = false;
            }
            return checkRezult;
        }


        //Метод проверяет существует ли директория
        public bool CheckDirectory(string path)
        {
            if (Directory.Exists(path))
                return true;
            else
                return false;
        }


        //Метод проверяет существует ли файл
        public bool CheckFile(string path)
        {
            if (File.Exists(path))
                return true;
            else
                return false;
        }        
    }
}

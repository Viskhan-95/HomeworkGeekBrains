using System;
using System.IO;
using System.Text.Json;

namespace FileManager
{
    class Content
    {
        //Метод вывод директоии и файлы на консоль
        public void OpenContent(string path, int page)
        {
            string numberItemsPage = File.ReadAllText(@"Config.json");
            int countCol = 4;
            int startI = 0;
            
            int lengthDir = Directory.GetDirectories(path).Length;
            int lengthFile = Directory.GetFiles(path).Length;

            string[] files = new string[lengthDir + lengthFile];

            Clear(4, 4, 20);
            Clear(4, (Console.LargestWindowHeight - 10) * 75 / 100, 8);

            DirectoryInfo di = new DirectoryInfo(path);

            for(int i = 0; i < lengthDir; i++)
            {
                files[i] = di.GetDirectories()[i].Name;
            }
            
            for(int i = 0; i < lengthFile; i++)
            {
                files[i + lengthDir] = di.GetFiles()[i].Name;
            }


            if (page == 1)
            {
                for (int i = startI; i < int.Parse(numberItemsPage); i++)
                {
                    Console.SetCursorPosition(4, countCol);
                    Console.WriteLine(Path.GetFileName(files[i]));
                    countCol++;
                }
            }
            else if(page == 2)
            {
                for (int i = int.Parse(numberItemsPage); i < int.Parse(numberItemsPage)*2; i++)
                {
                    Console.SetCursorPosition(4, countCol);
                    Console.WriteLine(Path.GetFileName(files[i]));
                    countCol++;
                }
            }
        }


        //Метод вывод информацию о файле на консоль
        public void InfoFile(string path)
        {
            int countCol = (Console.LargestWindowHeight - 10) * 75 / 100;
            Clear(4, 4, 20);
            Clear(4, countCol, 8);

            FileInfo fi = new FileInfo(path);

            Console.SetCursorPosition(4, countCol);
            Console.WriteLine($"Название файла \r\t\t\t\t {fi.Name}");
            
            Console.SetCursorPosition(4, countCol += 2);
            Console.WriteLine($"Расширение \r\t\t\t\t {fi.Extension}");
            
            Console.SetCursorPosition(4, countCol += 2);
            Console.WriteLine($"Атрибуты \r\t\t\t\t {fi.Attributes}");
            
            Console.SetCursorPosition(4, countCol += 2);
            Console.WriteLine($"Дата изменения \r\t\t\t\t {fi.LastWriteTime}");
            
            Console.SetCursorPosition(4, countCol += 2);
            Console.WriteLine($"Размер \r\t\t\t\t {fi.Length / 1024} КБ");
        }


        private void Clear(int startRow, int startCol, int countRow)
        {
            for(int i = 0; i < countRow; i++)
            {
                Console.SetCursorPosition(startRow, startCol + i);
                Console.Write("".PadRight(Console.LargestWindowWidth - 46, ' '));
            }
        }
    }
}

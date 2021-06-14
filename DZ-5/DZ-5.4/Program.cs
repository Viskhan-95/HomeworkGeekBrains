using System;
using System.IO;

namespace DZ_5._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathDir = @"C:\Users\Висхан\Desktop\X";
            GetDirectoryAndFilesRecurs(pathDir);
            GetDirectoryAndFiles(pathDir);
        }

        static void GetDirectoryAndFilesRecurs(string path)
        {
            if (Directory.Exists(path))
            {
                string[] nameDir = Directory.GetDirectories(path);
                string[] nameFile = Directory.GetFiles(path);

                foreach (var dir in nameDir)
                {
                    File.AppendAllText("Directory.txt", $"Подкаталоги {dir} \n");
                    GetDirectoryAndFilesRecurs(dir);
                }

                foreach (var file in nameFile)
                {
                    File.AppendAllText("Directory.txt", $"Файлы {file} \n");
                    GetDirectoryAndFilesRecurs(file);
                }
            }
        }


        static void GetDirectoryAndFiles(string path)
        {
            string[] nameDir = Directory.GetDirectories(path, "", SearchOption.AllDirectories);
            string[] nameFile = Directory.GetFiles(path, "", SearchOption.AllDirectories);

            foreach (var dir in nameDir)
            {
                File.AppendAllText("Directory.txt", $"{dir} \n");
            }

            foreach (var dir in nameFile)
            {
                File.AppendAllText("Directory.txt", $"{dir} \n");
            }
        }
    }
}

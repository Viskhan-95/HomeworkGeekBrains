using System;
using System.IO;

namespace DZ_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите данные для записи в файл: ");
            string inputString = Console.ReadLine();

            //string fileName = "C:\\Users\\Висхан\\Desktop\\homeworkGB\\DZ-5.1.txt";
            string fileName = "DZ-5.1.txt";

            File.AppendAllText(fileName, inputString);

            //Console.WriteLine(File.ReadAllText(fileName));
        }
    }
}

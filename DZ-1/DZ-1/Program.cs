using System;

namespace DZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите ваше имя:");
            var userName = Console.ReadLine();

            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Now.ToShortDateString()}");
        }
    }
}

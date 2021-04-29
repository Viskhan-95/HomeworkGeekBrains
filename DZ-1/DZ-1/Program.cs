using System;

namespace DZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your name");
            var userName = Console.ReadLine();

            Console.WriteLine($"Hello, {userName}, today {DateTime.Now.ToShortDateString()}.");
        }
    }
}

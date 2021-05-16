using System;

namespace DZ_3._3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите строку: ");
            string inputString = Console.ReadLine();
            string reversString = string.Empty;

            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                reversString += inputString[i];
            }

            Console.WriteLine(reversString);
        }
    }
}

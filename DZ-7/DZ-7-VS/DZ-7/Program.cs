using System;

namespace DZ_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number from 0 to 10: ");
            if(Console.ReadLine() == "5")
                Console.WriteLine("Well done, guessed!");
            else
                Console.WriteLine("Not well done, not guessed!");
        }
    }
}

using System;

namespace DZ_2._3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = ConvertStringToInt("Введите число: ");

            if(number % 2 == 0)
            {
                Console.WriteLine("Введенное число является четным: ");
            }
            else
            {
                Console.WriteLine("Введенное число является нечетным: ");
            }
        }

        private static int ConvertStringToInt(string consoleOutputString)
        {
            int number;
            bool resultConvertToInt;
            do
            {
                Console.Write(consoleOutputString);
                resultConvertToInt = int.TryParse(Console.ReadLine(), out number);
                if (!resultConvertToInt)
                    Console.WriteLine("Вы ввели не число, введите пожалуйста число \n");
            }
            while (!resultConvertToInt);

            return number;
        }
    }
}

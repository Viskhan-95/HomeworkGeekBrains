using System;

namespace DZ_4._4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число: ");
            int number = ConvertInputString(Console.ReadLine());
            Console.WriteLine(NumberFibonacci(number).ToString());
        }

        //Метод возвращает число фибоначчи
        static int NumberFibonacci(int number)
        {
            if (number == 0)
                return 0;
            else if (number == 1)
                return 1;
            else
                return NumberFibonacci(number - 1) + NumberFibonacci(number - 2);
        }

        //Метод конвертирует строку в число
        static int ConvertInputString(string inputString)
        {
            int result;
            while(true)
            {
                if (!int.TryParse(inputString, out result))
                {
                    Console.Write("Вы ввели не число, введите число: ");
                    inputString = Console.ReadLine();
                }
                else
                    break;
            }
            return result;
        }
    }
}

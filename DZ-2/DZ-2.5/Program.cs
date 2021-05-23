using System;

namespace DZ_2._5
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberMonth = ConvertStringToInt("Введите порядковый номер месяца от 1 до 12: ", 1, 12);
            int minTemperature = ConvertStringToInt("Введите минимальную температуру: ", -100, 100);
            int maxTemperature = ConvertStringToInt("Введите максимальную температуру: ", -100, 100);

            if(numberMonth == 12 || numberMonth == 1 || numberMonth == 2)
            {
                if((maxTemperature - minTemperature) / 2 > 0)
                    Console.WriteLine("Дождливая зима");
            }
        }

        private static int ConvertStringToInt(string consoleOutputString, int minValue, int maxValue)
        {
            int value;
            bool resultConvertToInt;
            bool rangeNumberMonth;
            do
            {
                Console.Write(consoleOutputString);
                resultConvertToInt = int.TryParse(Console.ReadLine(), out value);
                rangeNumberMonth = false;
                if (!resultConvertToInt)
                    Console.WriteLine("Вы ввели не число, введите число  \n");
                else 
                {
                    rangeNumberMonth = RangeCheck(value, minValue, maxValue);
                    if(rangeNumberMonth)
                        Console.WriteLine("Превысили диапазан значений, попробуйте еще раз \n");
                }
            }
            while (!resultConvertToInt || rangeNumberMonth);

            return value;
        }

        private static bool RangeCheck(int value, int minValue, int maxValue)
        {
            bool rangeCheck;
            if (value > maxValue || value < minValue)
                rangeCheck = true;
            else
                rangeCheck = false;

            return rangeCheck;

        }
    }
}

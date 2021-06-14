using System;

namespace DZ_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int minTemperature = ConvertStringToInt("Введите минимальную температуру: ");
            int maxTemperature = ConvertStringToInt("Введите максимальную температуру: ");

            Console.WriteLine($"Среднесуточная температура равна {(maxTemperature + minTemperature) / 2}");
        }

        private static int ConvertStringToInt(string consoleOutputString)
        {
            bool resultConvertToInt;
            int temperature;
            do
            {
                Console.Write(consoleOutputString);
                resultConvertToInt = int.TryParse(Console.ReadLine(), out temperature);
                if (!resultConvertToInt)
                {
                    Console.WriteLine("Вы ввели не число, введите пожалуйста число \n");
                }
            }
            while (!resultConvertToInt);
            return temperature;
        }
    }
}

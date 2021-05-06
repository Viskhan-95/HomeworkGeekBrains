using System;

namespace DZ_2._2
{
    class Program
    {
        enum Month
        {
            Январь = 1, Февраль, Март, Апрель, Май, Июнь, Июль, Август, Сентябрь, Октябрь, Ноябрь, Декабрь
        }

        static void Main(string[] args)
        {
            int numberMonth = ConvertStringToInt("Введите порядковый номер месяца от 1 до 12: ");
            
            switch(numberMonth)
            {
                case 1: Console.WriteLine(Month.Январь);
                    break;
                case 2: Console.WriteLine(Month.Февраль);
                    break;
                case 3: Console.WriteLine(Month.Март);
                    break;
                case 4:
                    Console.WriteLine(Month.Апрель);
                    break;
                case 5:
                    Console.WriteLine(Month.Май);
                    break;
                case 6:
                    Console.WriteLine(Month.Июнь);
                    break;
                case 7:
                    Console.WriteLine(Month.Июль);
                    break;
                case 8:
                    Console.WriteLine(Month.Август);
                    break;
                case 9:
                    Console.WriteLine(Month.Сентябрь);
                    break;
                case 10:
                    Console.WriteLine(Month.Октябрь);
                    break;
                case 11:
                    Console.WriteLine(Month.Ноябрь);
                    break;
                case 12:
                    Console.WriteLine(Month.Декабрь);
                    break;
            }
        }

        private static int ConvertStringToInt(string consoleOutputString)
        {
            int numberMonth;
            bool resultConvertToInt;
            bool rangeNumberMonth;
            do
            {
                Console.Write(consoleOutputString);
                resultConvertToInt = int.TryParse(Console.ReadLine(), out numberMonth);
                rangeNumberMonth = false;
                if (!resultConvertToInt)
                    Console.WriteLine("Вы ввели не число, введите число  \n");
                else if (numberMonth > 12 || numberMonth < 1)
                {
                    Console.WriteLine("Вы превысили диапазон значений, введите от 1 до 12 \n");
                    rangeNumberMonth = true;
                }
            }
            while (!resultConvertToInt || rangeNumberMonth);

            return numberMonth;
        }
    }
}

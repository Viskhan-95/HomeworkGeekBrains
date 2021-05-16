using System;

namespace DZ_4._3
{
    class Program
    {
        enum Seasons { Winter, Spring, Summer, Autumn}
        static void Main(string[] args)
        {
            int numberSeasons;

            Console.Write("Введите порядковый номер месяца: ");
            
            while (true)
            {
                numberSeasons = ConvertInputString(Console.ReadLine());
                if (CheckNumberSeasons(numberSeasons))
                    break;
            }

            Seasons seasons = ReturnSeason(numberSeasons);
            Console.WriteLine(ReturnSeason(seasons));

        }

        //Метод возврашает введенное число
        static int ConvertInputString(string inputString)
        {
            bool isConversion;
            int result;
            do
            {
                isConversion = Int32.TryParse(inputString, out result);
                if (!isConversion)
                {
                    Console.Write("Вы ввели не число, введите число от 1 до 12: ");
                    inputString = Console.ReadLine();
                }
            }
            while (!isConversion);
                return result;
        }

        //Метод проверяет введенное число на значение в диапазоне
        static bool CheckNumberSeasons(int numberSeasons)
        {
            bool isNumberSeasons = true;

            if (numberSeasons > 12 || numberSeasons < 1)
            {
                Console.Write("Ошибка: введите число от 1 до 12: ");
                isNumberSeasons = false;
            }
            else
                isNumberSeasons = true;

            return isNumberSeasons;
        }

        //Метод возврашает время года на английском языке
        static Seasons ReturnSeason(int numberSeason)
        {

            switch (numberSeason)
            {
                case 12:
                case 1:
                case 2:
                    return Seasons.Winter;

                case 3:
                case 4:
                case 5:
                    return Seasons.Spring;

                case 6:
                case 7:
                case 8:
                    return Seasons.Summer;

                default:
                    return Seasons.Autumn;
            }
        }

        //Метод возврашает время года на русском языке
        static string ReturnSeason(Enum season)
        {
            switch(season)
            {
                case Seasons.Winter:
                    return "Зима";
                case Seasons.Spring:
                    return "Весна";
                case Seasons.Summer:
                    return "Лето";
                default:
                    return "Осень";
            }
        }
    }
}

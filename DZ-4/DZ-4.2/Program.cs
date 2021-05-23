using System;

namespace DZ_4._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите числа: ");
            string numberString = Console.ReadLine();

            Console.WriteLine(SumNumber(numberString));
        }

        static int SumNumber(string numberString)
        {
            int sum = 0;

            var arrayNumberOfString = numberString.Split(" ");
            foreach (var number in arrayNumberOfString)
            {
                sum += Convert.ToInt32(number);
            }

            return sum;
        }
    }
}

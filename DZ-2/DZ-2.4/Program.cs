using System;

namespace DZ_2._4
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameShop = "ИП БУДУЩИЙ ПРОГРАММИСТ";
            DateTime purchaseData = new DateTime(2021, 05, 02, 10, 20, 30);
            double price = 131990.00;

            Console.WriteLine("\t\t  КАССОВЫЙ ЧЕК\\ПРИХОД");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($"\t\t {nameShop} \n");
            Console.WriteLine($"Дата {purchaseData}\n");

            Console.WriteLine("iPhone 11 Pro Max");
            Console.WriteLine($"Цена \t\t\t\t\t {string.Format("{0:0.00}", price)}");
            Console.WriteLine("Количество \t\t\t\t 1 шт");
            Console.WriteLine($"Итого \t\t\t\t\t {string.Format("{0:0.00}", price)}");
        }
    }
}

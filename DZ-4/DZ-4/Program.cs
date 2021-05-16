using System;

namespace DZ_4
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = new string[4];

            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine($"Введите ФИО {i + 1} человека");
                name[i] = InputConsoleName();
                Console.WriteLine();
            }

            for (int i = 0; i < name.Length; i++)
            {
                Console.WriteLine(name[i]);
            }
        }

        //Метод выводит на консоль запрос на воод ФИО
        static string InputConsoleName()
        {
            Console.Write("Введите фамилию: ");
            string lastName = GetString(Console.ReadLine());

            Console.Write("Введите имя: ");
            string firstName = GetString(Console.ReadLine());

            Console.Write("Введите отчество: ");
            string patronymic = GetString(Console.ReadLine());

            return GetFullName(lastName, firstName, patronymic);
        }

        //Метод возвращает объединенную строку
        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{firstName} {lastName} {patronymic}";
        }

        //Метод проверяет введена ли строка
        static string GetString(string inputString)
        {
            bool isString = false;
            string returnString = string.Empty;

            do
            {
                if (inputString == string.Empty)
                {
                    Console.Write("Вы ввели пустую строку, введите еще раз: ");
                    returnString = GetString(Console.ReadLine());
                    if (returnString != string.Empty)
                        inputString = returnString;
                }

                foreach (var str in inputString)
                {
                    if (char.IsDigit(str) || char.IsPunctuation(str))
                    {
                        Console.Write("Вы ввели не строку, введите еще раз: ");
                        isString = true;
                        inputString = Console.ReadLine();
                    }
                    else
                        isString = false;
                }
            }
            while (isString);
            return inputString;
        }
    }
}

using System;

namespace DZ_3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new string[5, 2];
            int count = 0;

            while (count < phonebook.GetLength(0))
            {
                for (int i = 0; i < phonebook.GetLength(0); i++)
                {
                    for (int j = 0; j < phonebook.GetLength(1); j++)
                    {
                        if (j == 0)
                            phonebook[i, j] = GetNameContact();
                        else
                            phonebook[i, j] = GetNumberPhone();
                    }
                    count++;
                    Console.WriteLine();
                }
            }

            for (int i = 0; i < phonebook.GetLength(0); i++)
            {
                for (int j = 0; j < phonebook.GetLength(1); j++)
                {
                    Console.Write($"{phonebook[i,j]} \t");
                }
                Console.WriteLine();
            }
        }


        private static string GetNameContact()
        {
            string nameContact;
            bool isName = false;

            do
            {
                Console.Write("Введите имя контакта: ");
                nameContact = Console.ReadLine();

                foreach (var name in nameContact)
                {
                    if (Char.IsLower(name) || Char.IsUpper(name))
                        isName = true;
                    else
                    {
                        isName = false;
                        Console.WriteLine("Вы ввели не корректное имя, введите пожалуйста имя");
                        break;
                    }
                }
            }
            while (!isName);
            return nameContact;
        }


        private static string GetNumberPhone()
        {
            string numberPhone;
            bool isNumber = false;

            do
            {
                Console.Write("Введите номер телефона: ");
                numberPhone = Console.ReadLine();
                foreach (var number in numberPhone)
                {
                    if (Char.IsNumber(number) || Char.IsPunctuation(number))
                        isNumber = true;
                    else
                    {
                        isNumber = false;
                        Console.WriteLine("Вы ввели не корректный номер, введите пожалуйста номер телефона");
                        break;
                    }
                }
            }
            while (!isNumber);
            return numberPhone;
        }
    }
}

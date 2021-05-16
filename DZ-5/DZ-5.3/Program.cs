using System;
using System.IO;

namespace DZ_5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "binary.bin";
            Console.WriteLine("Ввести числа от 0 до 255: ");
            string stringToByte = Console.ReadLine();

            byte[] arrayByte = System.Text.Encoding.UTF8.GetBytes(stringToByte);

            File.WriteAllBytes(fileName, arrayByte);
        }
    }
}

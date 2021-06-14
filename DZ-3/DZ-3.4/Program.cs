using System;

namespace DZ_3._4
{
    class Program
    {
        static void Main(string[] args)
        {
            var seaBattle = new string[10, 10];
            Random random = new Random();

            for (int i = 0; i < (seaBattle.GetLength(0) / 2); i++)
            {
                for (int j = 0; j < (seaBattle.GetLength(1) / 2); j++)
                {
                    seaBattle[random.Next(0, 10), random.Next(0, 10)] = "X ";
                }
            }


            for (int i = 0; i < seaBattle.GetLength(0); i++)
            {
                for(int j = 0; j < seaBattle.GetLength(1); j++)
                {
                    if(seaBattle[i, j] == null)
                        seaBattle[i, j] = "O ";
                }
            }

            for (int i = 0; i < seaBattle.GetLength(0); i++)
            {
                for (int j = 0; j < seaBattle.GetLength(1); j++)
                {
                    Console.Write(seaBattle[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}

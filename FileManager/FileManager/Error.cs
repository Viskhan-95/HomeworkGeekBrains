using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    class Error
    {
        //Метод выводит ошибки
        public void OutputErrorConsole(string errorString, string comand, int startRow, int startCol, int countRow)
        {
            if (startCol > Console.LargestWindowHeight*80/100) startCol = Console.LargestWindowHeight * 80 / 100;
            Clear(startRow, startCol, countRow);

            Console.SetCursorPosition(startRow, startCol++);
            Console.WriteLine(comand);
            
            Console.SetCursorPosition(startRow, startCol++);
            Console.WriteLine(errorString);

            Console.SetCursorPosition(startRow, startCol);
        }


        //Метод очишает консоль
        public void Clear(int startRow, int startCol, int countRow)
        {
            for (int i = 0; i < countRow; i++)
            {
                Console.SetCursorPosition(startRow, startCol + i);
                Console.Write("".PadRight(Console.LargestWindowWidth - 46, ' '));
            }
        }
    }
}

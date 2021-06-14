using System;
using System.Collections.Generic;
using System.Text;

namespace FileManager
{
    class Frame
    {
        char LeftUpCorner = '╔';
        char LeftCorner = '╠';
        char LeftDownCorner = '╚';
        char RightUpCorner = '╗';
        char RightCorner = '╣';
        char RighrDownCorner = '╝';
        char Liner = '═';
        char Border = '║';

        int StartCol;
        int StartRow;
        int rows;
        int cols;
        string FrameName = "File Manager";

        public Frame(int startRow, int startCol, int rws, int cls)
        {
            StartCol = startCol;
            StartRow = startRow;
            rows = rws;
            cols = cls;
            Show();
        }

        //Метод рисует рамку
        private void Show()
        {
            if (Console.WindowWidth < StartRow + rows)
            {
                Console.WindowWidth = StartRow + rows + 10;
            }
            if (Console.WindowHeight < StartCol + cols)
            {

                Console.WindowHeight = StartCol + cols;
            }

            for (int i = 1; i < cols; i++)
            {
                Console.SetCursorPosition(StartRow, StartCol + i);
                Console.Write(Border);
                Console.SetCursorPosition(StartRow + rows - 1, StartCol + i);
                Console.Write($"{Border}");
            }

            Console.SetCursorPosition(StartRow, StartCol);
            Console.Write($"{LeftUpCorner}".PadRight(rows - 1, Liner) + RightUpCorner);
            
            Console.SetCursorPosition(StartRow, StartCol + 2);
            Console.Write($"{LeftCorner}".PadRight(rows - 1, Liner) + RightCorner);
            
            Console.SetCursorPosition(StartRow, StartCol + cols*70/100);
            Console.Write($"{LeftCorner}".PadRight(rows - 1, Liner) + RightCorner);

            Console.SetCursorPosition(StartRow, StartCol + cols*90/100);
            Console.Write($"{LeftCorner}".PadRight(rows - 1, Liner) + RightCorner);

            Console.SetCursorPosition(StartRow + 5, StartCol + cols * 90 / 100);
            Console.WriteLine("Enter:");

            Console.SetCursorPosition(StartRow + 5, StartCol);
            Console.Write(FrameName.PadRight(rows - 6, Liner));

            Console.SetCursorPosition(StartRow, StartCol + cols);
            Console.Write($"{ LeftDownCorner}".PadRight(rows - 1, Liner) + RighrDownCorner);
        }

        //Метод очистки строки
        public void Clear(int startRow, int startCol)
        {
            for (int i = 0; i < rows; i++)
            {
                Console.SetCursorPosition(StartCol + 1, StartRow + 1 + i);
                Console.Write("".PadRight(cols - 2, ' '));
            }
        }
    }
}

using System;
using System.IO;

namespace DZ_5._2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "startup.txt";

            File.AppendAllText(fileName, DateTime.Now.ToString() + "\n");
            //File.AppendAllText(fileName, Environment.NewLine);
        }
    }
}

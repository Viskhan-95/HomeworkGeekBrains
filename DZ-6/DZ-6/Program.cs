using System;
using System.Diagnostics;

namespace DZ_6
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(Process process in Process.GetProcesses())
            {
                Console.WriteLine($"ID: {process.Id} Name: {process.ProcessName} ");
            }
            Console.Write("Для закрытия процесса введите его ID или имя: ");
            string dataProcess = Console.ReadLine();
            ExitProcess(dataProcess);
        }


        static void ExitProcess(string dataProcess)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (ConvertStringToInt(dataProcess))
                {

                    if (process.Id == int.Parse(dataProcess))
                        process.Kill();
                }
                else if (process.ProcessName == dataProcess)
                    process.Kill();
            }
        }


        static bool ConvertStringToInt(string convertString)
        {
            bool result = false;
            result = int.TryParse(convertString, out int idProcess);
            return result;
        }
    }
}

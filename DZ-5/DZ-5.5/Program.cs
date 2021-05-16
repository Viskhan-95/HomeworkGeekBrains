using System;
using System.IO;
using System.Text.Json;

namespace DZ_5._5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lastTasks = OutputListTasks(out int lastNumberTask);

            Console.Write("Введите задачу (для выполненной задачи, указать номер): ");
            string inputString = Console.ReadLine();

            if (IsNumberTask(inputString, lastNumberTask, out int returnNumberTask))
            {
                File.Delete("tasks.json"); //хоть и не грамотно удалять, но другого решения не пришло на ум
                MarkCompletedTask(lastTasks, returnNumberTask);
            }
            else
            {
                var task = new ToDo(lastNumberTask, inputString, false);

                string newTask = JsonSerializer.Serialize(task);

                File.AppendAllText("tasks.json", newTask);
                File.AppendAllText("tasks.json", Environment.NewLine);
            }
        }

        //Метод выводит в консол данные из файла tasks.json
        static string[] OutputListTasks(out int lastNumberTask)
        {
            string[] arrayListTasks = null;
            lastNumberTask = 1;

            if (File.Exists("tasks.json"))
            {
                arrayListTasks = File.ReadAllLines("tasks.json");

                foreach (var t in arrayListTasks)
                {
                    var listTasks = JsonSerializer.Deserialize<ToDo>(t);
                    if (listTasks.IsDone)
                        Console.WriteLine($"{listTasks.NumberTask} [x] {listTasks.Title}");
                    else
                        Console.WriteLine($"{listTasks.NumberTask} {listTasks.Title}");
                    lastNumberTask = ++listTasks.NumberTask;
                }
            }
            return arrayListTasks;
        }


        //Метод проверяет введенный номер задачи
        static bool IsNumberTask(string inputNumberTask, int lastNumberTask, out int numberTask)
        {
            bool result = int.TryParse(inputNumberTask, out numberTask);
            
            if (result)
            {
                if (numberTask < lastNumberTask && numberTask > 0)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    
    
        //Метод делает отметку о выполнении задачи
        static void MarkCompletedTask(string[] listTasks, int numberTask)
        {
            foreach (var t in listTasks)
            {
                var listTasksJson = JsonSerializer.Deserialize<ToDo>(t);

                if (listTasksJson.NumberTask == numberTask)
                {
                    listTasksJson.IsDone = true;
                    File.AppendAllText("tasks.json", JsonSerializer.Serialize(listTasksJson));
                    File.AppendAllText("tasks.json", Environment.NewLine);
                }
                else
                {
                    File.AppendAllText("tasks.json", t);
                    File.AppendAllText("tasks.json", Environment.NewLine);
                }
            }
        }
    }

    class ToDo
    {
        public int NumberTask { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }

        public ToDo(int numberTask, string title, bool isDone)
        {
            NumberTask = numberTask;
            Title = title;
            IsDone = isDone;
        }

        public ToDo() { }
    }
}

using System;
using System.Collections.Generic;
using TaskScheduler.Models;
using TaskScheduler.Managers;

namespace TaskScheduler.Managers
{
    public static class TaskActions
    {
        public static void AddTask(List<TaskModel> tasks, string filePath)
        {
            Console.WriteLine("Введіть нове завдання (або 'exit' для повернення до меню):");
            string input = Console.ReadLine();
            if (input.ToLower() == "exit")
            {
                return;
            }

            Console.WriteLine("Введіть дату дедлайну (формат: dd.MM.yyyy HH:mm:ss):");
            string dateInput = Console.ReadLine();
            if (DateTime.TryParse(dateInput, out DateTime deadline))
            {
                tasks.Add(new TaskModel { TaskText = input, Deadline = deadline });
                TaskManager.SaveTasksToFile(tasks, filePath);
            }
            else
            {
                Console.WriteLine("Невірний формат дати. Спробуйте ще раз.");
            }
        }

        public static void DisplayTasks(List<TaskModel> tasks)
        {
            Console.Clear();
            Console.WriteLine("Список завдань:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.TaskText} - Дедлайн: {task.Deadline}");
            }
            Console.WriteLine("Натисніть будь-яку клавішу для повернення до меню...");
            Console.ReadKey();
        }

        public static void DeleteTask(List<TaskModel> tasks, string filePath)
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Немає завдань для видалення.");
                Console.WriteLine("Натисніть будь-яку клавішу для повернення до меню...");
                Console.ReadKey();
                return;
            }

            int selectedIndex = MenuManager.SelectTaskForDeletion(tasks);
            if (selectedIndex >= 0)
            {
                tasks.RemoveAt(selectedIndex);
                TaskManager.SaveTasksToFile(tasks, filePath);
                Console.WriteLine("Завдання видалено.");
                Console.WriteLine("Натисніть будь-яку клавішу для повернення до меню...");
                Console.ReadKey();
            }
        }
    }
}

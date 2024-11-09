using System;
using System.Collections.Generic;
using TaskScheduler.Models;

namespace TaskScheduler.Managers
{
    public static class MenuManager
    {
        public static int NavigateMenu(string[] options)
        {
            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                for (int i = 0; i < options.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine(options[i]);
                    Console.ResetColor();
                }

                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : options.Length - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < options.Length - 1) ? selectedIndex + 1 : 0;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

            return selectedIndex;
        }

        public static int SelectTaskForDeletion(List<TaskModel> tasks)
        {
            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("Виберіть завдання для видалення:");

                for (int i = 0; i < tasks.Count; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{tasks[i].TaskText} - Дедлайн: {tasks[i].Deadline}");
                    Console.ResetColor();
                }

                keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex > 0) ? selectedIndex - 1 : tasks.Count - 1;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex < tasks.Count - 1) ? selectedIndex + 1 : 0;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);

            return selectedIndex;
        }
    }
}

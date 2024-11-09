using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using TaskScheduler;
using TaskScheduler.Managers;
using TaskScheduler.Models;

class Program
{
    static async Task Main(string[] args)
    {
        SpeechSynthesizer synthesizer = SpeechManager.InitializeSynthesizer();

        SpeechManager.SelectVoice(synthesizer);

        string filePath = "tasks.json";
        List<TaskScheduler.TaskModel> tasks = TaskScheduler.TaskManager.LoadTasksFromFile(filePath);

        _ = TaskMonitor.MonitorDeadlinesAsync(tasks, synthesizer);

        while (true)
        {
            string[] menuOptions = { "Додати нове завдання", "Переглянути список завдань", "Видалити завдання", "Вийти" };
            int selectedOption = MenuManager.NavigateMenu(menuOptions);

            if (selectedOption == 0)
            {
                TaskActions.AddTask(tasks, filePath);
            }
            else if (selectedOption == 1)
            {
                TaskActions.DisplayTasks(tasks);
            }
            else if (selectedOption == 2)
            {
                TaskActions.DeleteTask(tasks, filePath);
            }
            else if (selectedOption == 3)
            {
                break;
            }
        }
    }
}

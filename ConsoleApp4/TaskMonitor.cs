using System;
using System.Collections.Generic;
using System.Speech.Synthesis;
using System.Threading.Tasks;
using TaskScheduler.Models;
using TaskScheduler.Managers;

namespace TaskScheduler.Managers
{
    public static class TaskMonitor
    {
        public static async Task MonitorDeadlinesAsync(List<TaskModel> tasks, SpeechSynthesizer synthesizer)
        {
            while (true)
            {
                DateTime now = DateTime.Now;
                List<TaskModel> overdueTasks = new List<TaskModel>();

                foreach (var task in tasks)
                {
                    if (task.Deadline <= now)
                    {
                        overdueTasks.Add(task);
                        synthesizer.Speak($"Task {task.TaskText} deadline finished!");
                    }
                }

                tasks.RemoveAll(t => overdueTasks.Contains(t));
                TaskManager.SaveTasksToFile(tasks, "tasks.json");

                await Task.Delay(1000);
            }
        }
    }
}

using Quartz;
using System;
using System.Threading.Tasks;

namespace TopshelfQuartz.Scheduler
{
    public class Job1 : IJob
    {
        private static int cont = 1;
        public Task Execute(IJobExecutionContext context)
        {
            return Task.Run(() =>
            {
                Console.WriteLine($"job 1 ejecutado {DateTime.Now.ToString("HH:mm:ss")}. Ejecución: {cont++}");
            });
        }
    }
}

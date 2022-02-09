using System;
using System.Threading.Tasks;

namespace AsyncAwaitDemo
{
    class Program
    {
        // This method must be async and return a Task
        // in order to use await inside the method.
        static async Task Main(string[] args)
        {
            var startTime = DateTime.Now;

            // Start the timers
            Task<string> timer1 = TimerAsync(750);
            Task<string> timer2 = TimerAsync(250);

            // Wait for the timers to finish
            string time = await timer1;
            Console.WriteLine("Timer1 elapsed time: " + time);
            time = await timer2;
            Console.WriteLine("Timer2 elapsed time: " + time);
            Console.WriteLine("Total time: " + ElapsedTime(startTime));
        }


        static async Task<string> TimerAsync(int delay)
        {
            var start = DateTime.Now;
            await Task.Delay(delay);  // await allows other async tasks to execute
            return ElapsedTime(start);
        }


        static string ElapsedTime(DateTime start)
        {
            return (DateTime.Now - start).TotalSeconds.ToString() + " seconds";
        }
    }
}


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
            Task timer1 = TimerAsync(1, 1000);
            Task timer2 = TimerAsync(2, 750);
            Task timer3 = TimerAsync(3, 250);

            // Wait for the timers to finish
            // The await statements will be execute in the order written
            await timer1;
            Console.WriteLine("Total time A: " + ElapsedTime(startTime));
            await timer2;
            Console.WriteLine("Total time B: " + ElapsedTime(startTime));
            await timer3;
            Console.WriteLine("Total time C: " + ElapsedTime(startTime));

            /****************************************************************/
            /* Do it again, but await the tasks in the opposite order */
            /****************************************************************/

            Console.WriteLine("\nStarting again, awaiting in reverse order");
            startTime = DateTime.Now;

            // Start the timers
            timer1 = TimerAsync(1, 1000);
            timer2 = TimerAsync(2, 750);
            timer3 = TimerAsync(3, 250);

            // Wait for the timers to finish
            // The await statements will be execute in the order written
            await timer3;
            Console.WriteLine("Total time A: " + ElapsedTime(startTime));
            await timer2;
            Console.WriteLine("Total time B: " + ElapsedTime(startTime));
            await timer1;
            Console.WriteLine("Total time C: " + ElapsedTime(startTime));
        }


        static async Task TimerAsync(int id, int delay)
        {
            var start = DateTime.Now;
            Console.WriteLine("Starting timer " + id);
            // Task.Delay(delay).Wait();  // wait prevents other async tasks from executing
            await Task.Delay(delay);  // await allows other async tasks to execute
            Console.WriteLine("Timer " + id + " elapsed time: " + ElapsedTime(start));
        }


        static string ElapsedTime(DateTime start)
        {
            return (DateTime.Now - start).TotalSeconds.ToString() + " seconds";
        }
    }
}


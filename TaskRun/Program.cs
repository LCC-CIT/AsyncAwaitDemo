using System;
using System.Threading.Tasks;

namespace TaskRun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //double pi = await CalculatePi();
            Task<double> task = CalculatePi();  
            Console.WriteLine("We're doing something else now");
            double pi = await task;
            Console.WriteLine("Apporimation of pi: " + pi);
        }

        // Approximate pi using Wallis's Series
        static async Task<double> CalculatePi()
        {
            const int N = 1000000000; // It takes 900 million iterations for 8 digits of precision
            double pi = 4;

            await Task.Run(() =>
            {
                for (double i = 3; i <= (N + 2); i += 2)
                    pi = pi * ((i - 1) / i) * ((i + 1) / i);
            });

            return pi;
        }
    }
}

// Code for calculating pi was written by José Cintra
// https://www.codeproject.com/Articles/813185/Calculating-the-Number-PI-Through-Infinite-Sequenc

using System;
using System.Threading.Tasks;

// This code is a simplified version of the code in the AsyncBreakfast example:
// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/

namespace AsyncBreakfastSimplified
{
    class Program
    {
 

static async Task Main(string[] args)
        {
            Task<Egg> eggTask = FryEggAsync();
            Task<Bacon> baconTask = FryBaconAsync();
            Task<Toast> toastTask = MakeToastWithButterAndJamAsync();

            Toast toast = await toastTask;
            Egg egg = await eggTask;
            Bacon bacon = await baconTask;

            await Task.WhenAll(eggTask, baconTask, toastTask);
            Console.WriteLine("Breakfast is ready!");
        }


        static async Task<Toast> MakeToastWithButterAndJamAsync()
        {
            var toast = await ToastBreadAsync();
            ApplyButter(toast);
            ApplyJam(toast);
            return toast;
        }

        static async Task<Toast> ToastBreadAsync()
        {
            await Task.Delay(2000);
            var random = new Random();
            if(random.Next(1, 100) == 13)
              throw new InvalidOperationException("The toaster is on fire");
            return new Toast();
        }

        static async Task<Egg> FryEggAsync()
        {
            await Task.Delay(5000);
            return new Egg();
        }

        static async Task<Bacon> FryBaconAsync()
        {
            await Task.Delay(3000);
            return new Bacon();
        }

        static void ApplyJam(Toast toast) => Console.WriteLine("Putting jam on the toast");

        static void ApplyButter(Toast toast) => Console.WriteLine("Putting butter on the toast");



    }
}


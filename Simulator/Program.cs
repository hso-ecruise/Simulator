using FluentScheduler;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

//using ecruise.Models;

namespace Simulator
{
    class Program
    {
       
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
           // RunAsync().Wait();

            JobManager.Initialize(new BackgroundTasker().ScheduleBookings());
            
            Console.ReadLine();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Simulator wurde gestartet");
            // New code:
            try
            {
                await TaskScheduler.loginAsAdmin();

                await TaskScheduler.getCarbyId(1,5000);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
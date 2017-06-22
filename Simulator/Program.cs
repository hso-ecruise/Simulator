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

            JobManager.Initialize(new BackgroundTasker().ScheduleBookings());

            Console.ReadLine();
        }

    }
}
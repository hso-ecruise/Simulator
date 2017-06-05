using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using ecruise.Models;
using ecruise;

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
            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            Console.WriteLine("Simulator wurde gestartet");
            // New code:
            try
            {
                SimClient client = new SimClient();
                Response r = await client.LoginAsync("admin@ecruise.me", "ecruiseAdmin123!!!");
                Console.WriteLine(r.Token.ToString());
                client.access_token = r.Token;

                Car car = await client.Cars2Async(1, "");
                Console.WriteLine(car.ToString());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
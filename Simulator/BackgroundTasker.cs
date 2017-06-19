using System;
using FluentScheduler;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Simulator
{
    internal class BackgroundTasker
    {
        private static SimClient client = null;
        private ObservableCollection<CarChargingStation> allCarCarchingStations = null;

        public BackgroundTasker()
        {
            if (client == null)
                client = new SimClient();
            loginAsAdmin().Wait();
        }

        internal Registry ScheduleBookings()
        {
            // Create registry
            Registry registry = new Registry();

            registry.Schedule((Action)ScheduleRandomBooking).ToRunEvery(10).Seconds();
            //throw new NotImplementedException();
            return registry;
        }
        private static async Task<bool> loginAsAdmin()
        {
            Response r = await client.LoginAsync("admin@ecruise.me", "ecruiseAdmin123!!!");
            Console.WriteLine("access_token: " + r.Token.ToString());
            client.access_token = r.Token;
            return true;
        }

        private async void ScheduleRandomBooking()
        {
            Console.WriteLine(DateTime.Now.ToString());
            Booking b = new Booking();
            b.BookingDate = DateTime.Today;
            b.CustomerId = 1;
            ObservableCollection<Booking> allBookings = await client.BookingsAllAsync("") ;
            foreach (Booking b1 in allBookings)
            {
                Console.WriteLine("BookingId: " + b1.BookingId);
            }
            b.BookingId = allBookings.Count + 1;
            


            //Car car = await client.Cars2Async(i++, "");
            //Console.WriteLine(car.CarId.ToString());
            Console.WriteLine(DateTime.Now.ToString());

        }
    }
}
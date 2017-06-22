using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    class TaskScheduler
    {
        public static SimClient client = null;

        public static async Task<bool> loginAsAdmin()
        {
            if (client == null)
                client = new SimClient();
            Response r = await client.LoginAsync("admin@ecruise.me", "ecruiseAdmin123!!!");
            Console.WriteLine("access_token: " + r.Token.ToString());
            client.access_token = r.Token;
            return true;
        }

        public static async Task<bool> getCarbyId(int id, int delay)
        {
            await Task.Delay(delay);
            Car car = await client.Cars2Async(1, "");
            Console.WriteLine(car.CarId.ToString());
            return true;

        }
        static async Task simulateTrip(int carId, ChargingStation from, CarChargingStation to, int delay)
        {
            await Task.Delay(delay);
            Trip trip = new Trip();
            trip.CarId = carId;
            trip.CustomerId = 123;
            trip.StartDate = DateTime.Now;
            trip.EndDate = DateTime.Now.AddMinutes(1.0);
            trip.StartChargingStationId = 1;
            trip.EndChargingStationId = 2;

            await client.TripsAsync(trip);

            await Task.Delay(60000);
            ChargingStation station = await client.ChargingStations2Async((int)trip.EndChargingStationId, "");
            await client.CarPatchPositionAsync(carId, station.Latitude, station.Longitude);
        }
    }
}

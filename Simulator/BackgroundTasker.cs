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
        private Registry registry = null;
        private int tId = 0;
        Random rnd = new Random();

        public BackgroundTasker()
        {
            if (client == null)
                client = new SimClient();
            loginAsAdmin().Wait();
            registry = new Registry();

        }

        internal Registry ScheduleBookings()
        {
            // Create registry

            //registry.Schedule((Action)ScheduleRandomBooking).ToRunEvery(10).Seconds();
            registry.Schedule((Action)fixCarBookingState).ToRunNow();
            //registry.Schedule((Action)allCarsToString).ToRunNow();

            //registry.Schedule((Action)ScheduleRandomBooking).ToRunNow();
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

        private async void ScheduleRandomTrip()
        {
            Console.WriteLine(DateTime.Now.ToString());
            Trip t = new Trip();
            t.CustomerId = 1;

            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            ObservableCollection<Car> allAvailableCars = new ObservableCollection<Car>();
            foreach (Car c in allCars)
            {
                Console.WriteLine(c.ToJson().ToString()+"\n");
                if (c.BookingState == CarBookingState.AVAILABLE && c.ChargingState == CarChargingState.FULL)
                    allAvailableCars.Add(c);
            }
            if (allAvailableCars.Count < 1)
                return;
            Car currentCar = allAvailableCars[rnd.Next(0, allAvailableCars.Count-1)];

            t.CarId = currentCar.CarId;
            ObservableCollection<CarChargingStation> ccs = await client.ByCar2Async((int)currentCar.CarId);
            t.StartChargingStationId = ccs[0].ChargingStationId;
            
            PostReference r = await client.TripsAsync(t);
            tId = (int) r.Id;
            Console.WriteLine(DateTime.Now.ToString() + ": " + t.ToJson().ToString());
            registry.Schedule((Action)ScheduleEndTrip).ToRunOnceIn(rnd.Next(1, 3)).Minutes();
            //Car car = await client.Cars2Async(i++, "");
            //Console.WriteLine(car.CarId.ToString());
            Console.WriteLine(DateTime.Now.ToString());

        }

        private async void ScheduleEndTrip( )
        {
            Trip2 trip = new Trip2();
            trip.DistanceTravelled = rnd.Next(10, 100);

            ObservableCollection<ChargingStation> stations = await client.ChargingStationsAllAsync("");
            ObservableCollection<ChargingStation> stationWithFreeSlots = new ObservableCollection<ChargingStation>();
            foreach (ChargingStation cs in stations)
                if (cs.Slots > cs.SlotsOccupied)
                    stationWithFreeSlots.Add(cs);
            if (stationWithFreeSlots.Count < 1)
                return;
            trip.EndChargingStationId = (int) stationWithFreeSlots[rnd.Next(0, stationWithFreeSlots.Count -1)].ChargingStationId;

            await client.TripPatchTrips3Async(tId,  trip);
        }
        private async void fixCarBookingState()
        {
            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            foreach (Car c in allCars)
            {
                Console.WriteLine(c.ToJson().ToString() + "\n");
                if (c.BookingState == CarBookingState.BOOKED && c.ChargingState == CarChargingState.FULL)
                {
                    await client.CarPatchBookingstateAsync((int)c.CarId, BookingState.AVAILABLE);
                }
                switch(c.ChargingState)
                {
                    case CarChargingState.CHARGING:
                        if (c.BookingState != CarBookingState.BLOCKED)
                            await client.CarPatchBookingstateAsync((int)c.CarId, BookingState.BLOCKED);
                        break;
                    case CarChargingState.DISCHARGING:
                        if (c.BookingState != CarBookingState.BOOKED)
                            await client.CarPatchBookingstateAsync((int)c.CarId, BookingState.BOOKED);
                        break;

                }
            }
            allCarsToString();
        }

        private async void allCarsToString()
        {
            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            foreach (Car c in allCars)
                Console.WriteLine(c.ToJson().ToString() + "\n");
        }
        private async void PostCar()
        {
            Car car = await client.Cars2Async(10,"");
            car.LicensePlate = "MA EC 3003";
            car.BookingState = CarBookingState.AVAILABLE;
            car.CarId = 0;

            
            PostReference r = await client.CarsAsync(car);
            allCarsToString();
        }
    }
}
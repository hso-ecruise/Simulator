using System;
using FluentScheduler;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace Simulator
{
    internal class BackgroundTasker
    {
        private static SimClient client = null;
        private static int OverrunChargingStationId = 5;
        private ObservableCollection<CarChargingStation> allCarCarchingStations = null;
        private Registry registry = null;
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
            //Thread.Sleep(2000);
            // Create registry
            //registry.Schedule((Action)loginAsAdmin).ToRunEvery(1).Minutes();

            //registry.Schedule((Action)ScheduleRandomBooking).ToRunEvery(10).Seconds();
            //registry.Schedule((Action)fixCarBookingState).ToRunNow();
            //registry.Schedule((Action)PostCar).ToRunNow();

            registry.Schedule((Action)allCarsToString).ToRunNow();//.ToRunEvery(15).Seconds();

            //registry.Schedule((Action)allTripsToString).ToRunEvery(5).Seconds();
            //registry.Schedule((Action)allStatisticsToString).ToRunNow();
            //registry.Schedule((Action)allChargingStationsToString).ToRunNow();
            endAllTrips();
            allChargingStationsToString();
            allCarChargingStationsToString();
            //ScheduleEndTrip(64, 2);
            //ScheduleEndTrip(65, 4);
            //ScheduleEndTrip(66, 6);
            //ScheduleEndTrip(68, 1);
            ////ScheduleEndTrip(58, 5);

            registry.Schedule((Action)simulateCharging).ToRunEvery(1).Seconds();

            //registry.Schedule((Action)ScheduleEndTrip).ToRunOnceIn(50).Seconds();
            //registry.Schedule((Action)allTripsToString).ToRunOnceIn(25).Seconds();
            //registry.Schedule((Action)allChargingStationsToString).ToRunOnceIn(25).Seconds();

            //registry.Schedule((Action)ScheduleTripFromChargingStation).ToRunEvery(10).Seconds();
            //registry.Schedule((Action)ScheduleRandomTrip).ToRunEvery(5).Seconds();

            //registry.Schedule((Action)allTripsToString).ToRunOnceIn(45).Seconds();
            //throw new NotImplementedException();
            return registry;
        }
        private static async Task loginAsAdmin()
        {
            Response r = await client.LoginAsync("admin@ecruise.me", "ecruiseAdmin123!!!");
            Console.WriteLine("access_token: " + r.Token.ToString());
            client.access_token = r.Token;
            return ;
        }
        private async void simulateCharging()
        {
            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            foreach (Car c in allCars)
            {
                if (c.ChargingState == CarChargingState.CHARGING)
                {
                    c.ChargeLevel += 1;
                    if(c.ChargeLevel >= 100)
                    {
                        c.ChargeLevel = 100;
                        client.CarPatchChargingstateAsync((int)c.CarId, ChargingState.FULL);
                        client.CarPatchBookingstateAsync((int)c.CarId, BookingState.AVAILABLE);
                    }
                    client.CarPatchChargelevelAsync((int)c.CarId, c.ChargeLevel);
                }

            }
        }

        private async void ScheduleTripFromChargingStation()
        {
            if (OverrunChargingStationId != 0)
            {
                ChargingStation cs = await client.ChargingStations2Async(OverrunChargingStationId, "");
                if (true)   //cs.Slots > cs.SlotsOccupied)
                {
                    ObservableCollection< CarChargingStation > allCcs = await client.CarChargingStationsAllAsync("");
                    ObservableCollection<Car> carsAtChargingStation = new ObservableCollection<Car>();
                    ObservableCollection<Car> allCars = await client.CarsAllAsync("");
                    foreach (Car c in allCars)
                    {
                        int lastChargingStationId = 0;
                        foreach (CarChargingStation ccs in allCcs)
                            if (c.CarId == ccs.CarId)
                                lastChargingStationId = ccs.ChargingStationId;
                        if (lastChargingStationId == OverrunChargingStationId)
                            carsAtChargingStation.Add(c);
                    }
                    //ObservableCollection<Car> allCarsAtCs = new ObservableCollection<Car>();
                    //foreach (CarChargingStation ccs in ccsAnCs)
                    //    if (ccs.ChargingStationId == OverrunChargingStationId)
                    //        allCarsAtCs.Add(await client.Cars2Async(ccs.CarId, ""));

                    ObservableCollection<Car> allAvailableCars = new ObservableCollection<Car>();
                    foreach (Car c in carsAtChargingStation)
                    {
                        //Console.WriteLine(c.ToJson().ToString()+"\n");
                        if (c.BookingState == CarBookingState.AVAILABLE && c.ChargingState == CarChargingState.FULL)
                            allAvailableCars.Add(c);
                    }
                    if (allAvailableCars.Count < 1)
                        return;

                    Car currentCar = allAvailableCars[rnd.Next(0, allAvailableCars.Count - 1)];
                    ScheduleTrip((int)currentCar.CarId);
                }
                else
                    ScheduleRandomTrip();
            }
            else
                ScheduleRandomTrip();

        }

        private async void ScheduleRandomTrip()
        {

            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            ObservableCollection<Car> allAvailableCars = new ObservableCollection<Car>();
            foreach (Car c in allCars)
            {
                //Console.WriteLine(c.ToJson().ToString()+"\n");
                if (c.BookingState == CarBookingState.AVAILABLE && c.ChargingState == CarChargingState.FULL)
                    allAvailableCars.Add(c);
            }
            //if (allAvailableCars.Count < 1)
            //{
            //    //PostCar();
            //    return;
            //}

            Car currentCar = allAvailableCars[rnd.Next(0, allAvailableCars.Count - 1)];
            ScheduleTrip((int)currentCar.CarId);
        }


        private async void ScheduleTrip(int carId)
        {
            Console.WriteLine(DateTime.Now.ToString());
            Trip t = new Trip();
            t.CustomerId = 1;

            t.CarId = carId;

            ObservableCollection<CarChargingStation> ccs;
            try
            {
                ccs = await client.ByCar2Async((int)carId);
                t.StartChargingStationId = ccs[0].ChargingStationId;
            }
            catch (Exception)
            {
                //await client.CarPatchBookingstateAsync((int)currentCar.CarId, BookingState.AVAILABLE);
                return;
            }
            //ccs = await client.ByCar2Async((int)currentCar.CarId);
            //t.StartChargingStationId = ccs[0].ChargingStationId;
            t.StartDate = DateTime.UtcNow.AddMinutes(-3);
            t.TripId = 0;
            
            PostReference r = await client.TripsAsync(t);
            await client.CarPatchBookingstateAsync((int)carId, BookingState.BOOKED);
            //Console.WriteLine(DateTime.Now.ToString() + " localObject: " + t.ToJson().ToString());
            Trip dbTrip = await client.Trips2Async((int) r.Id, "");
            Console.WriteLine(DateTime.Now.ToString() + " Tripstartet: " + dbTrip.ToJson().ToString());

            Booking b = new Booking();
            b.BookingId = 0;
            b.CustomerId = 1;
            b.PlannedDate = null;
            b.TripId = dbTrip.TripId;
            ChargingStation cs = await client.ChargingStations2Async((int)t.StartChargingStationId, "");
            b.BookingPositionLatitude = cs.Latitude;
            b.BookingPositionLongitude = cs.Longitude;

            //allBookingsToString();
            await client.BookingsAsync(b);
            //allBookingsToString();

            Thread.Sleep(rnd.Next(5000, 60000) );
            Console.WriteLine(DateTime.Now.ToString() + " Sleep ended: " + dbTrip.ToJson().ToString());
            ScheduleEndTrip((int)dbTrip.TripId, (int) dbTrip.CarId);
            dbTrip = await client.Trips2Async((int) r.Id, "");
            //registry.Schedule((Action)ScheduleEndTrip).ToRunNow();
            //Car car = await client.Cars2Async(i++, "");
            //Console.WriteLine(car.CarId.ToString());
            Console.WriteLine(DateTime.Now.ToString());
        }

        private async void endAllTrips()
        {
            ObservableCollection<Trip> allTrips = await client.TripsAllAsync(Filterbystate.NOTFINISHED, "");
            ObservableCollection<Trip> unfinishedTrips = new ObservableCollection<Trip>();
            foreach (Trip t in allTrips)
                if (t.EndDate == null && t.TripId != 64)
                {
                    Car currentCar = await client.Cars2Async((int)t.CarId, "");
                    ScheduleEndTrip((int) t.TripId, (int) currentCar.CarId);
                }
        }
        private async void ScheduleEndTrip( int tripId, int carId)
        {
            Trip2 trip = new Trip2();
            trip.DistanceTravelled = rnd.Next(10, 75);
            Car car = await client.Cars2Async(carId, "");
            client.CarPatchMileageAsync(carId, car.Mileage + (int) trip.DistanceTravelled);
            client.CarPatchChargelevelAsync(carId, 100 - trip.DistanceTravelled / 2);
            //client.CarPatchBookingstateAsync(carId, BookingState.BLOCKED);

            ObservableCollection<ChargingStation> stations = await client.ChargingStationsAllAsync("");
            ObservableCollection<ChargingStation> stationWithFreeSlots = new ObservableCollection<ChargingStation>();
            foreach (ChargingStation cs in stations)
                if (cs.Slots > cs.SlotsOccupied)
                    stationWithFreeSlots.Add(cs);
            if (stationWithFreeSlots.Count < 1)
                return;
            ChargingStation endChargingStation = null;
            if (OverrunChargingStationId != 0)
            {
                endChargingStation = await client.ChargingStations2Async(OverrunChargingStationId, "");
                
            }
            if (stationWithFreeSlots.Contains(endChargingStation))
                trip.EndChargingStationId = OverrunChargingStationId;
            else
            {
                endChargingStation = stationWithFreeSlots[rnd.Next(0, stationWithFreeSlots.Count - 1)];
                trip.EndChargingStationId = (int)endChargingStation.ChargingStationId;
            }
            client.CarPatchPositionAsync(carId, endChargingStation.Latitude, endChargingStation.Longitude);
            
            await client.TripPatchTrips3Async(tripId,  trip);
            Trip dbTrip = await client.Trips2Async(tripId, "");
            Console.WriteLine(DateTime.Now.ToString() + " Trip ended: " + dbTrip.ToJson().ToString());
        }
        private async void fixSlotsOccupied()
        {
            ObservableCollection<ChargingStation> allChargingStations = await client.ChargingStationsAllAsync("");
            foreach (ChargingStation cs in allChargingStations)
                cs.SlotsOccupied = 0;
            ObservableCollection<CarChargingStation> allCcs = await client.CarChargingStationsAllAsync("");
            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            foreach (Car c in allCars)
            {
                int lastChargingStationId = 0;
                foreach (CarChargingStation ccs in allCcs)
                    if (c.CarId == ccs.CarId)
                        lastChargingStationId = ccs.ChargingStationId;
                foreach (ChargingStation cs in allChargingStations)
                    if (cs.ChargingStationId == lastChargingStationId)
                        cs.SlotsOccupied++;
            }
            foreach (ChargingStation cs in allChargingStations)
                if (cs.SlotsOccupied <= cs.Slots)
                    client.SlotsOccupiedAsync((int)cs.ChargingStationId, cs.SlotsOccupied);
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
        private async void allStatisticsToString()
        {
            //Statistic stat = await client.StatisticAsync(DateTime.Today.AddDays(-1));
            //Console.WriteLine(stat.ToJson().ToString());
            ObservableCollection<Statistic> allStatistic = await client.StatisticAllAsync("");
            foreach (Statistic c in allStatistic)
                Console.WriteLine(c.ToJson().ToString() + "\n");
        }
        private async void allTripsToString()
        {
            try
            {
                ObservableCollection<Trip> allTrips = await client.TripsAllAsync(Filterbystate.FINISHED, "");
                foreach (Trip c in allTrips)
                    Console.WriteLine(c.ToJson().ToString() + "\n");
            }
            catch (Exception)
            {
                return;
                //throw;
            }
        }
        private async void allBookingsToString()
        {
            try
            {
                ObservableCollection<Booking> allBooking = await client.BookingsAllAsync("");
                foreach (Booking c in allBooking)
                    Console.WriteLine(c.ToJson().ToString() + "\n");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void allChargingStationsToString()
        {
            try
            {
                ObservableCollection<ChargingStation> allChargingStation = await client.ChargingStationsAllAsync("");
                foreach (ChargingStation c in allChargingStation)
                    Console.WriteLine(c.ToJson().ToString() + "\n");
            }
            catch (Exception)
            {

                throw;
            }
        }
        private async void allCarChargingStationsToString()
        {
            ObservableCollection<CarChargingStation> allCarChargingStation = await client.CarChargingStationsAllAsync("");
            foreach (CarChargingStation c in allCarChargingStation)
                Console.WriteLine(c.ToJson().ToString() + "\n");
        }

        private async void allCarsToString()
        {
            ObservableCollection<Car> allCars = await client.CarsAllAsync("");
            foreach (Car c in allCars)
                if(c.BookingState != CarBookingState.AVAILABLE || c.ChargingState == CarChargingState.CHARGING)
                    Console.WriteLine(c.ToJson().ToString() + "\n");
        }
        private async void PostCar()
        {
            Car car = await client.Cars2Async(10,"");
            car.LicensePlate = "MA EC 3006";
            car.BookingState = CarBookingState.AVAILABLE;
            car.ChargingState = CarChargingState.FULL;
            car.CarId = 0;

            
            PostReference r = await client.CarsAsync(car);
            allCarsToString();
        }
    }
}
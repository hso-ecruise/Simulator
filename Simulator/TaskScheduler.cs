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

        public static async Task<bool> getCarbyId(int id)
        {
            Car car = await client.Cars2Async(1, "");
            Console.WriteLine(car.CarId.ToString());
            return true;

        }

        static void makeMaintanace()
        {

        }
    }
}

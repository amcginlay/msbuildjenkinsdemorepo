using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
    class Program
    {
        static void Main(string[] args)
        {
            var utcTimeService = new UTCTimeService();
            var timeResolver = new TimeResolver(utcTimeService);

            while (true)
            {
                Console.Write("Enter city name: ");
                var cityString = Console.ReadLine().Trim();
                if (Enum.IsDefined(typeof(CityEnum), cityString))
                {
                    var city = (CityEnum)Enum.Parse(typeof(CityEnum), cityString);
                    var resolvedTime = timeResolver.GetTime(city);
                    Console.WriteLine("The time in {0} is {1}", city, resolvedTime);
                }
                else
                {
                    Console.WriteLine("Unrecognised, try again");
                }
            }
        }
    }
}

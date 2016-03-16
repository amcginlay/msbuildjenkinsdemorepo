using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeZones
{
    public class TimeResolver
    {
        private IUTCTimeService utcTimeService;
        
        public TimeResolver(IUTCTimeService utcTimeService)
        {
            if (utcTimeService == null)
                throw new TimeZonesException();

            this.utcTimeService = utcTimeService;
        }

        private int TimeDiff(CityEnum city)
        {
            if (city == CityEnum.NewYork)
                return -5;
            return 0;
        }

        public DateTime GetTime(CityEnum city)
        {
            var currentUtcTime = utcTimeService.GetTime();
            var timeDiff = TimeDiff(city);
            return currentUtcTime.AddHours(timeDiff);
        }
    }
}

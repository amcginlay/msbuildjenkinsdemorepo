using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZones;

namespace TimesZonesTest
{
    public class xFakeUTCTimeService : IUTCTimeService
    {
        public DateTime GetTime()
        {
            return new DateTime(1900, 1, 1, 0, 0, 0);
        }
    }
}

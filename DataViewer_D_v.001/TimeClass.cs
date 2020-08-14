using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    class TimeClass
    {
        public int hours;
        public int minutes;
        public TimeClass(int Hours, int Minutes)
        {
            this.hours = Hours;
            this.minutes = Minutes;
        }
        public override string ToString()
        {
            string hoursStr, minutesStr;

            if (hours / 10 < 1)
                hoursStr = "0" + Convert.ToString(this.hours);
            else
                hoursStr = Convert.ToString(this.hours);

            if (minutes / 10 < 1)
                minutesStr = "0" + Convert.ToString(this.minutes);
            else
                minutesStr = Convert.ToString(this.minutes);

            return hoursStr + ":" + minutesStr;
        }
    }
}

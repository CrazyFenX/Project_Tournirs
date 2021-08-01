using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class TimeClass
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

        public void ToInt(string timeStr)
        {
            int i = 0;
            this.hours = 0;
            this.minutes = 0;

            //MessageBox.Show(timeStr);

            while (timeStr[i] != 58 && i < timeStr.Length)
            {
                this.hours = this.hours * 10 + (Convert.ToInt32(timeStr[i]) - 48);
                i++;
            }

            i++;

            while (i < timeStr.Length)
            {
                this.minutes = this.minutes * 10 + (Convert.ToInt32(timeStr[i]) - 48);
                i++;
            }

            //MessageBox.Show($"{this.hours}:{this.minutes}");
        }
    }
}

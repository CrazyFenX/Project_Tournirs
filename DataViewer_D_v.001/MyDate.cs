using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms; //для теста

namespace DataViewer_D_v._001
{
    public class MyDate
    {
        public int Day;
        public int Mounth;
        public int Year;

        public MyDate()
        {

        }

        public MyDate(int day, int mounth, int year)
        {
            this.Day = day;
            this.Mounth = mounth;
            this.Year = year;
        }

        public override string ToString()
        {
            string DayStr;
            string MounthStr;

            if (this.Day < 10)
                DayStr = "0" + Convert.ToString(this.Day);
            else
                DayStr = Convert.ToString(this.Day);

            if (this.Mounth < 10)
                MounthStr = "0" + Convert.ToString(this.Mounth);
            else
                MounthStr = Convert.ToString(this.Mounth);

            return DayStr + "." + MounthStr + "." + Convert.ToString(Year);
        }

        public void ToInt(string DateStr)
        {
            int i = 0;
            this.Day = 0;
            this.Mounth = 0;
            this.Year = 0;

            while (DateStr[i] != 46 && i != DateStr.Length)
            {
                this.Day = this.Day * 10 + (Convert.ToInt32(DateStr[i]) - 48);

                //MessageBox.Show(DateStr + $"\n{i}\n{this.Day}");
                i++;
            }

            i++;

            while (DateStr[i] != 46 && i != DateStr.Length)
            {
                this.Mounth = this.Mounth * 10 + (Convert.ToInt32(DateStr[i]) - 48);

                //MessageBox.Show(DateStr + $"\n{i}\n{this.Mounth}");
                i++;
            }

            i++;

            while (i != DateStr.Length)
            {
                this.Year = this.Year * 10 + (Convert.ToInt32(DateStr[i]) - 48);
                //MessageBox.Show(DateStr + $"\n{i}\n{this.Year}");
                i++;
            }
            MessageBox.Show(this.ToString());
        }

        public MyDate Substract(MyDate lastDate)
        {
            MyDate difDate = new MyDate(0,0,0);
            //int Day = this.Day - lastDate.Day;
            //int Mounth = this;
            //int Year;

            //difDate.Day = Day;
            //difDate.Mounth = Mounth;
            //difDate.Year = Year;

            return difDate;
        }

        public bool inTen(int a)
        {
            if (a == 1 || a == 2 || a == 3 || a == 4 || a == 5 || a == 6 || a == 7 || a == 8 || a == 9 || a == 0)
                return true;
            return false;
        }
    }
}

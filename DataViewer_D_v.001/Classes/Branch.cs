using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001.Classes
{
    public class Branch
    {
        //Fiels
        public int number = 0;
        public TimeClass startTime = new TimeClass(0, 0);
        public TimeClass finishTime = new TimeClass(0, 0);

        public List<int> groupOrderList = new List<int>();
        public ushort[,] toursOrder = new ushort[0, 0];
        public int countOfTours = 0;
        //Constructors
        public Branch(TimeClass sTime, TimeClass fTime)
        {
            startTime = sTime;
            finishTime = fTime;
            groupOrderList = new List<int>();
        }

        public Branch(int num, TimeClass sTime, TimeClass fTime):this(sTime, fTime)
        {
            number = num;
        }

        public Branch()
        {

        }

        public override string ToString()
        {
            return number.ToString() + ") " + startTime.ToString() + " - " + finishTime.ToString();
        }
    }
}

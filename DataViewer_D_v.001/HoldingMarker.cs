using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class HoldingMarker
    {
        public int tourNumber;

        public int groupNumber;
        public int setNumber;
        public int duetNumber;

        public HoldingMarker(int Tour, int Group, int Set, int Duet)
        {
            this.tourNumber = Tour;
            this.groupNumber = Group;
            this.setNumber = Set;
            this.duetNumber = Duet;
        }

        public override string ToString()
        {
            string outStr = "";
            outStr += this.tourNumber + " " + this.groupNumber + " " + this.setNumber + " " + this.duetNumber;
            return outStr;
        }
    }
}

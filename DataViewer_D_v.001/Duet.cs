using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class Duet
    {
        public Sportsman sportsman1 = new Sportsman();
        public Sportsman sportsman2 = new Sportsman();

        public int number = 0;
        public int groupNumber = 0;

        public Duet(int Num)
        {
            this.number = Num;
        }

        public Duet()
        {
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1, Sportsman Sportsman2)
        {
            this.number = Num;
            this.sportsman1 = Sportsman1;
            this.sportsman2 = Sportsman2;
            this.groupNumber = GroupNum;
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1)
        {
            this.number = Num;
            this.sportsman1 = Sportsman1;
            this.sportsman2 = new Sportsman(-1);
            this.groupNumber = GroupNum;
        }

        public override string ToString()
        {
            return sportsman1.ToString() + " " + sportsman2.ToString() + " " + number.ToString() + " " + groupNumber.ToString();
        }
    }
}

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

        public int number;

        public Duet(int Num)
        {
            this.number = Num;
        }

        public Duet()
        {
        }
    }
}

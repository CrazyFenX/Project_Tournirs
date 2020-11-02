using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    class duetInTourComparer : IComparer<DuetInTour>
    {
        public int Compare(DuetInTour o1, DuetInTour o2)
        {
            if (o1.mark > o2.mark)
            {
                return 1;
            }
            else if (o1.mark < o2.mark)
            {
                return -1;
            }

            return 0;
        }
    }
}

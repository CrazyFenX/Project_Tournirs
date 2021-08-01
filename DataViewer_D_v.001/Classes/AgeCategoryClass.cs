using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class AgeCategoryClass
    {
        int minAge = 0;
        int maxAge = 0;

        string name;

        public AgeCategoryClass() { }

        public AgeCategoryClass(string Name, int MinAge, int MaxAge)
        {
            minAge = MinAge;
            maxAge = MaxAge;
            name = Name;
        }
    }
}

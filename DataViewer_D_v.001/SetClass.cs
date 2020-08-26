using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    class SetClass
    {
        public int number;
        public int numberOfGroup;
        public string category;

        public List<Duet> DuetList = new List<Duet>();
        public List<Sportsman> SoloList = new List<Sportsman>();

        public SetClass()
        { 
        
        }

        public SetClass(int Group_Number, int Number, string Category)
        {
            this.numberOfGroup = Group_Number;
            this.number = Number;
            this.category = Category;
        }

        public override string ToString()
        {
            return Convert.ToString(this.number) + " " + Convert.ToString(this.numberOfGroup) + " " + Convert.ToString(this.category);
        }
    }
}

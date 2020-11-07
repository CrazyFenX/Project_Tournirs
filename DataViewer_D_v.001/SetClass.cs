using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class SetClass
    {
        public int number;
        public int numberOfGroup;
        public string category;

        public List<Duet> DuetList = new List<Duet>();
        public List<Sportsman> SoloList = new List<Sportsman>();

        public SetClass()
        {
            this.number = 0;
            this.numberOfGroup = 0;
            this.category = "";
            this.DuetList = new List<Duet>();
            this.SoloList = new List<Sportsman>();
        }

        public SetClass(int Group_Number, int Number, string Category)
        {
            this.numberOfGroup = Group_Number;
            this.number = Number;
            this.category = Category;
        }

        public SetClass(int Group_Number, int Number)
        {
            this.numberOfGroup = Group_Number;
            this.number = Number;
            this.category = "";
            this.DuetList = new List<Duet>();
            this.SoloList = new List<Sportsman>();
        }

        public override string ToString()
        {
            return "Заход номер " + Convert.ToString(this.number) + " из группы " + Convert.ToString(this.numberOfGroup) + " категория " + Convert.ToString(this.category);
        }
    }
}

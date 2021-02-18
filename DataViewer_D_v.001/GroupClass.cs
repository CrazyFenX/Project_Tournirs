using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class GroupClass
    {
        public int number;
        public string name;
        public string tournir_name;
        public TimeClass time;
        public List<SetClass> SetList = new List<SetClass>();
        public List<string> CategoryList = new List<string>();
        public List<AgeCategoryClass> AgeCategoryClassList = new List<AgeCategoryClass>();

        public List<Duet> duetList = new List<Duet>();
        public List<Duet> sortDuetList = new List<Duet>();

        //public List<danceClass> DanceClass = new List<danceClass>();
        public List<string> DancesList = new List<string>();

        public List<Judge> JudgeList = new List<Judge>();
        public GroupClass()
        {
            this.SetList = new List<SetClass>();
            this.CategoryList = new List<string>();
        }

        public GroupClass(int Number, string Tournir_Name): this()
        {
            this.number = Number;
            this.tournir_name = Tournir_Name;
            //this.SetList = new List<SetClass>();
            //this.CategoryList = new List<string>();
        }

        public GroupClass(int Number, string Tournir_Name, string GroupName): this(Number, Tournir_Name)
        {
            //this.number = Number;
            //this.tournir_name = Tournir_Name;
            this.name = GroupName;
            //this.SetList = new List<SetClass>();
            //this.CategoryList = new List<string>();
        }

        public override string ToString()
        {
            return "Группа " + Convert.ToString(this.number) + " " + this.name;
        }

        public string show()
        {
            string retStr = "";

            retStr += this.number;
            retStr += "\n";
            retStr += this.tournir_name;
            retStr += "\n";
            //retStr += this.time.ToString();
            //retStr += "\n";

            foreach (string item in this.CategoryList)
            {
                retStr += item + " ";
            }
            retStr += "\n";

            foreach (string item in this.DancesList)
            {
                retStr += item + " ";
            }
            retStr += "\n";

            foreach (Duet item in this.duetList)
            {
                retStr += item.ToString();
                retStr += "\n";
            }
            return retStr;
        }
    }
}

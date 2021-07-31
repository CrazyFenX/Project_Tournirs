using DataViewer_D_v._001.Classes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class GroupClass
    {
        public int number;
        public string name;
        public string tournir_name;
        public TimeClass time;
        public ushort branchNumber;

        public List<SetClass> SetList = new List<SetClass>();
        public List<string> CategoryList = new List<string>();
        public List<AgeCategoryClass> AgeCategoryClassList = new List<AgeCategoryClass>();

        public List<Duet> duetList = new List<Duet>();
        public List<Duet> sortDuetList = new List<Duet>();

        public List<Duet> duetListFinal = new List<Duet>();
        public List<Duet> sortDuetListFinal = new List<Duet>();

        public int system;

        public List<Tour> tours = new List<Tour>();

        public bool markered = false;
        public bool isTheFirstTourInitialised = false;

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
            retStr += this.branchNumber.ToString();
            retStr += "\n";

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

        public string getDancesToString()
        {
            string retStr = "";
            foreach (string item in DancesList)
            {
                retStr += item;
                if (DancesList.IndexOf(item) < DancesList.Count - 1)
                    retStr += ",";
            }
            return retStr;
        }

        public void fillBitMapForFirstTour()
        {
            int max = -1, idmax = -1;
            for(int i = 0; i < tours.Count; i++)
            {
                MessageBox.Show(tours[i].degree.ToString());
                if (tours[i].degree > max)
                {
                    max = tours[i].degree;
                    idmax = i;
                }
            }
            if (idmax > -1)
            {
                tours[idmax].isItPlayed = 0;
                tours[idmax].tourBitMap = new BitArray(duetList.Count, true);
                isTheFirstTourInitialised = true;
            }
        }
    }
}

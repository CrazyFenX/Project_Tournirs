using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class GroupClass
    {
        public int number;
        public string tournir_name;
        public TimeClass time;
        public List<SetClass> SetList = new List<SetClass>();
        public List<string> CategoryList = new List<string>();

        public GroupClass()
        {
            this.SetList = new List<SetClass>();
            this.CategoryList = new List<string>();
        }

        public GroupClass(int Number, string Tournir_Name)
        {
            this.number = Number;
            this.tournir_name = Tournir_Name;
            this.SetList = new List<SetClass>();
            this.CategoryList = new List<string>();
        }

        public override string ToString()
        {
            return "Группа номер " + Convert.ToString(this.number) + " в " + Convert.ToString(this.tournir_name);
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
                retStr += item;
                retStr += "\n";
            }

            foreach (SetClass item in this.SetList)
            {
                retStr += item.ToString();
                retStr += "\n";
            }
            return retStr;
        }
    }
}

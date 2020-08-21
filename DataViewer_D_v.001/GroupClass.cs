using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    class GroupClass
    {
        public int number;
        public string tournir_name;
        public TimeClass time;
        public List<SetClass> SetList = new List<SetClass>();
        public List<string> CategoryList = new List<string>();

        public GroupClass()
        {

        }

        public GroupClass(int Number, string Tournir_Name)
        {
            this.number = Number;
            this.tournir_name = Tournir_Name;
        }

        public override string ToString()
        {
            return Convert.ToString(this.number) + Convert.ToString(this.tournir_name);
        }
    }
}

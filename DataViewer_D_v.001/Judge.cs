using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class Judge
    {
        public ushort Number;

        public string Name;
        public string Surname;
        public string Patronymic;

        public string JudgeClass;
        public string position;
        public string City;

        //public ushort number;
        public char judgeChar;

        public Judge()
        { 
        
        }

        public Judge(int number, string surname, string name,  string patronymic, string judjeClass)
        {
            this.Number = (ushort)number;
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
        }

        //public Judge(string Name, string Surname, string Patronymic, string judjeClass)
        //{

        //}

        public string ToSNP()
        {
            return this.Surname + " " + this.Name + " " + this.Patronymic;
        }

        public void ToJudge(string SNP)
        {
            string[] SNPList = SNP.Split(new char[] { ';' });
            this.Surname = SNPList[0];
            this.Name = SNPList[1];
            this.Patronymic = SNPList[2];
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic + " " + JudgeClass + " " + Number + " " + judgeChar + " Должность: " + position;
        }

        public string ToShortString()
        {
            return Surname + " " + Name + " " + Patronymic + " " + "Должность: " + position;
        }
    }
}

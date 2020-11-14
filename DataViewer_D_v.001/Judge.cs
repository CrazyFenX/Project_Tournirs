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

        //public ushort number;
        public char judgeChar;

        public Judge()
        { 
        
        }

        public Judge(int number, string name, string surname, string patronymic, string judjeClass)
        {
            this.Number = (ushort)number;
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
        }

        public Judge(string Name, string Surname, string Patronymic, string judjeClass)
        {

        }

        public string ToNSP()
        {
            return this.Name + " " + this.Surname + " " + this.Patronymic;
        }

        public void ToJudge(string NSP)
        {
            string name = "";
            string surname = "";
            string patronymic = "";

            int i = 0;
                while (NSP[i] != ' ' && i <= NSP.Length)
                {
                    name += NSP[i];
                    i++;
                }
                //MessageBox.Show(name);
                i++;

                while (NSP[i] != ' ' && i <= NSP.Length)
                {
                    surname += NSP[i];
                    i++;
                }
                //MessageBox.Show(surname);
                i++;

                while (NSP[i] != ' ' && i <= NSP.Length)
                {
                    patronymic += NSP[i];
                    i++;
                }
                //MessageBox.Show(patronymic);

            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
        }

        public override string ToString()
        {
            return this.Name + " " + this.Surname + " " + this.Patronymic + " " + this.Number.ToString() + " " + this.judgeChar;
        }
    }
}

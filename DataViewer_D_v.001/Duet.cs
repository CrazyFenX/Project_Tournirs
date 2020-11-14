using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class Duet
    {
        public int mark = 0;
        public Sportsman sportsman1 = new Sportsman();
        public Sportsman sportsman2 = new Sportsman();

        public int number = 0;
        public int groupNumber = 0;

        public string type = "";

        public Duet(int Num)
        {
            this.number = Num;
        }

        public Duet()
        {
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1, Sportsman Sportsman2)
        {
            this.number = Num;
            this.sportsman1 = Sportsman1;
            this.sportsman2 = Sportsman2;
            this.groupNumber = GroupNum;
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1)
        {
            this.number = Num;
            this.sportsman1 = Sportsman1;
            this.sportsman2 = new Sportsman(-1);
            this.groupNumber = GroupNum;
        }

        public Duet(int Num, int GroupNum, string SNP1)
        {
            this.number = Num;
            this.takeFromSNP(SNP1, 1);
            this.groupNumber = GroupNum;
            this.type = "Соло";
        }

        public Duet(int Num, int GroupNum, string SNP1, string SNP2)
        {
            this.number = Num;
            this.takeFromSNP(SNP1, 1);
            this.takeFromSNP(SNP2, 2);
            this.groupNumber = GroupNum;
            this.type = "Пара";
        }

        public override string ToString()
        {
            return number.ToString() + " " + sportsman1.ToString() + " " + sportsman2.ToString() + " " + number.ToString() + " " + groupNumber.ToString();
        }

        public void takeFromSNP(string SNPstring, int flag)
        {
            //string[] tempList = System.Text.RegularExpressions.Regex.Split(SNPstring, ";");
            string[] tempList = SNPstring.Split(new Char[] { ' ', ',', '.', ':', ';', '\t' });
            //string retstr = "";

            //foreach (string item in tempList)
            //    retstr += item + "\n";
            //MessageBox.Show(retstr);

            if (flag == 1)
            {
                this.sportsman1.Surname = tempList[0];
                this.sportsman1.Name = tempList[1];
                this.sportsman1.Patronymic = tempList[2];
                //MessageBox.Show(sportsman1.ToString());
            }
            else if (flag == 2)
            {
                this.sportsman2.Surname = tempList[0];
                this.sportsman2.Name = tempList[1];
                this.sportsman2.Patronymic = tempList[2];
                //MessageBox.Show(sportsman2.ToString());
            }
        }
    }
}

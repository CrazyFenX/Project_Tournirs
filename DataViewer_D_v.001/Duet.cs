using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class Duet
    {
        public double mark = 0;
        public double markSum = 0;
        public Sportsman sportsman1 = new Sportsman();
        public Sportsman sportsman2 = new Sportsman();

        public int number = 0;
        public int groupNumber = 0;
        public int numberInGroup = 0;

        public string diplomPlace;
        public List<List<int>> judgeMarkList = new List<List<int>>();

        public List<Trainer> trainers = new List<Trainer>();

        public string type = "";

        public Duet(int Num)
        {
            this.number = Num;
        }

        public Duet()
        {
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1, Sportsman Sportsman2, double mark):this(Num, GroupNum, Sportsman1, Sportsman2)
        {
            this.mark = mark;
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1, Sportsman Sportsman2):this(Num, GroupNum, Sportsman1)
        {
            this.sportsman2 = Sportsman2;
        }

        public Duet(int Num, int GroupNum, Sportsman Sportsman1)
        {
            this.number = Num;
            this.sportsman1 = Sportsman1;
            this.sportsman2 = new Sportsman(-1);
            this.groupNumber = GroupNum;
        }

        //public Duet(int Num, int GroupNum, Sportsman Sportsman1)
        //{
        //    this.number = Num;
        //    this.sportsman1 = Sportsman1;
        //    this.sportsman2 = new Sportsman(-1);
        //    this.groupNumber = GroupNum;
        //    this.mark = mark;
        //}

        public Duet(int Num, int NumInGroup, int GroupNum, string SNP1, double mark) : this(Num, NumInGroup, GroupNum, SNP1)
        {
            //this.number = Num;
            //this.takeFromSNP(SNP1, 1);
            //this.groupNumber = GroupNum;
            //this.type = "Солист";
            //this.numberInGroup = NumInGroup;
            this.mark = mark;
        }

        public Duet(int Num, int NumInGroup, int GroupNum, string SNP1)
        {
            this.number = Num;
            this.takeFromSNP(SNP1, 1);
            this.groupNumber = GroupNum;
            this.type = "Солист";
            this.numberInGroup = NumInGroup;
        }

        public Duet(int Num, int NumInGroup, int GroupNum, string SNP1, string SNP2)
        {
            this.number = Num;
            this.takeFromSNP(SNP1, 1);
            this.takeFromSNP(SNP2, 2);
            this.groupNumber = GroupNum;
            this.type = "Пара";
            this.numberInGroup = NumInGroup;
        }

        public Duet(int Num, int NumInGroup, int GroupNum, string SNP1, string SNP2, double mark): this(Num, NumInGroup, GroupNum, SNP1, SNP2)
        {
            this.mark = mark;
        }

        public override string ToString()
        {
            string retstr = "";
            retstr += "Пара " + number.ToString() + " В Группе " + groupNumber.ToString() + " Под помером " + numberInGroup.ToString() + " \n" + sportsman1.ToString() + " " + sportsman2.ToString();
            if (this.mark >= 0)
                retstr += " Баллы: " + this.mark.ToString() + " " + this.diplomPlace + "\n";
            retstr += "\nТренера: ";
            foreach (Trainer trItem in trainers) 
                retstr += trItem.ToString() + " ";
            return retstr;
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
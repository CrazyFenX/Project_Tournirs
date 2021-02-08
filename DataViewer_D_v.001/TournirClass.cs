using ADOX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Data.OleDb;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class TournirClass
    {
        public string name;
        public MyDate date = new MyDate();
        public TimeClass time = new TimeClass(0,0);
        public string place;
        public string organisation;
        public List<GroupClass> groups = new List<GroupClass>();
        public string registrator;
        public string secretary;

        public List<Judge> positionsList = new List<Judge>(); 

        public List<Judge> judges = new List<Judge>();//Продумать
        public string path;

        public ushort[] groupsOrder = new ushort[0];

        public List<List<GroupClass>> tourList = new List<List<GroupClass>>();//Продумать (карта перехода из groups в tourList)

        public TournirClass()
        {
            this.groups = new List<GroupClass>();
        }

        public TournirClass(string cn)
        {
            this.groups = new List<GroupClass>();
            SecretaryController.TakeTournir(cn);
        }

        public void Show()
        {
            string result = "";

            result += this.name;
            result += "\n";

            result += this.date.ToString();
            result += "\n";

            result += this.time.ToString();
            result += "\n";

            result += this.place;
            result += "\n";

            result += this.organisation;
            result += "\n";

            foreach (Judge item in this.judges)
            {
                result += item.ToString();
                result += "\n";
            }

            foreach (GroupClass group in this.groups)
            {
                result += group.ToString();
                result += "\n Танцы \n";
                foreach (string dance in group.DancesList)
                {
                    result += dance;
                    result += "\n";
                }
                result += "\n Категории \n";
                foreach (string category in group.CategoryList)
                {
                    result += category.ToString();
                    result += "\n";
                }
                result += "\n Судьи \n";
                foreach (Judge jud in group.JudgeList)
                {
                    result += jud.ToString();
                    result += "\n";
                }
                result += "\n Пары \n";
                foreach (Duet duet in group.duetList)
                {
                    result += duet.ToString();
                    result += "\n";
                }
            }

            MessageBox.Show(result);
        }

        public void info()
        {
            string result = "";

            result += this.name;
            result += "\n";

            result += this.date.ToString();
            result += "\n";

            result += this.time.ToString();
            result += "\n";

            result += this.place;
            result += "\n";

            result += this.organisation;
            result += "\n";

            result += this.registrator;
            result += "\n";

            result += this.secretary;
            result += "\n";

            foreach (GroupClass group in this.groups)
            {
                result += "\n";
                result += group.ToString();
                result += "\n Танцы: ";
                foreach (string dance in group.DancesList)
                {
                    result += dance + " ";
                }
                result += "   Категории: ";
                foreach (string category in group.CategoryList)
                {
                    result += category.ToString() + " ";
                }
                result += "   Пар в группе: ";
                result += group.duetList.Count().ToString();
                result += "\n";
            }

            MessageBox.Show(result);
        }

        public void info2()
        {
            string result = "";

            result += this.name;
            result += "\n";

            result += this.date.ToString();
            result += "\n";

            result += this.time.ToString();
            result += "\n";

            result += this.place;
            result += "\n";

            result += this.organisation;
            result += "\n";

            result += "\n Судьи: ";
            foreach (Judge judge in judges)
            {
                result += judge.ToString() + "\n";
            }

            result += "\n Должности: ";
            foreach (Judge jitem in positionsList)
            {
                result += jitem.ToShortString();
                result += "\n";
            }

            foreach (GroupClass group in this.groups)
            {
                result += "\n";
                result += group.ToString();
                result += "\n Танцы: ";
                foreach (string dance in group.DancesList)
                {
                    result += dance + " ";
                }
                result += "   Категории: ";
                foreach (string category in group.CategoryList)
                {
                    result += category.ToString() + " ";
                }

                result += "   Пар в группе: ";
                result += group.duetList.Count().ToString();
                result += "\n";
            }

            MessageBox.Show(result);
        }
    }
}
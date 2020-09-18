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
        public List<Judge> judges = new List<Judge>();//Продумать
        public string path;

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
                result += item.ToNSP();
                result += "\n";
            }

            result += this.registrator;
            result += "\n";

            result += this.secretary;
            result += "\n";

            foreach (GroupClass group in this.groups)
            {
                result += group.ToString();
                result += "\n";
                foreach (SetClass set in group.SetList)
                {
                    result += set.ToString();
                    result += "\n";
                }
            }
            MessageBox.Show(result);
        }
    }
}
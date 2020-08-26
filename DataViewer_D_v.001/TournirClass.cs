using ADOX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Data.OleDb;

namespace DataViewer_D_v._001
{
    class TournirClass
    {
        public string name;
        public MyDate date = new MyDate();
        public TimeClass time = new TimeClass(0,0);
        public string place;
        public string organisation;
        public List<GroupClass> groups = new List<GroupClass>();//Продумать
        public string registrator;
        public string secretary;
        public List<Judge> judges = new List<Judge>();//Продумать

        public TournirClass()
        {
            this.groups = new List<GroupClass>();
        }

        public TournirClass(string cn)
        {
            this.groups = new List<GroupClass>();
            SecretaryController.TakeTournir(cn);
        }
    }
}
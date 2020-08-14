using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;

namespace DataViewer_D_v._001
{
    class TournirClass
    {
        public string name;
        public MyDate date;
        public TimeClass time;
        public string place;
        public string organisation;
        public List<int> groups = new List<int>();
        public string registrator;
        public string secretary;
        public List<int> judges = new List<int>();
    }
}
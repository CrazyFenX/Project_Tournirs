using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class SetInTour
    {
        public int number;
        //public List<Button> DuetListInTour;
        public List<DuetInTour> DuetListInTour;
        public Button setButton;
        
        public bool isValid;

        public SetInTour(int Num)
        {
            this.number = Num;
            //this.DuetListInTour = new List<Button>();
            this.DuetListInTour = new List<DuetInTour>();
            this.isValid = true;
        }

        public SetInTour(int Num, Button But)
        {
            this.number = Num;
            this.setButton = But;
            //this.DuetListInTour = new List<Button>();
            this.DuetListInTour = new List<DuetInTour>();
            this.isValid = true;
        }

        public SetInTour()
        {
            //this.DuetListInTour = new List<Button>();
            this.DuetListInTour = new List<DuetInTour>();
            this.isValid = true;
        }
    }
}

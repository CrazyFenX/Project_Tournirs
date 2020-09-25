using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class GroupInTour
    {
        public List<SetInTour> SetListInTour;
        public Button groupButton;

        public GroupInTour(Button buttgroup)
        {
            this.groupButton = buttgroup;
            this.SetListInTour = new List<SetInTour>();
        }
        public GroupInTour()
        {
            this.SetListInTour = new List<SetInTour>();
        }
    }
}

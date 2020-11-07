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

        public List<DuetInTour> DuetInGroupList = new List<DuetInTour>();

        public List<tournirResultComboBox> resultOfGroup_list = new List<tournirResultComboBox>();

        public bool isValid;
        public uint countOfParticipants;

        public GroupInTour(Button buttgroup)
        {
            this.groupButton = buttgroup;
            this.SetListInTour = new List<SetInTour>();
            this.isValid = true;
        }
        public GroupInTour()
        {
            this.SetListInTour = new List<SetInTour>();
            this.isValid = true;
        }

        public void takeCountOfParticipants()
        {
            foreach (SetInTour setItem in this.SetListInTour)
            {
                countOfParticipants += (uint)setItem.DuetListInTour.Count();
            }
        }

        public void takeDuetInGroupList()
        {
            string retstr = "";
            this.DuetInGroupList.Clear();
            foreach (SetInTour setItem in this.SetListInTour)
            {
                foreach (DuetInTour duetItem in setItem.DuetListInTour)
                {
                    this.DuetInGroupList.Add(duetItem);
                    retstr += duetItem.ToString() +"\n";
                }
            }
            //MessageBox.Show(retstr);
        }
    }
}

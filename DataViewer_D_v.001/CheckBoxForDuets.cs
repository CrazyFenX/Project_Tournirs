using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class CheckBoxForDuets
    {
        public HoldingMarker marker;
        public CheckBox validnessCheckBox;
        public bool isItViewed;

        public CheckBoxForDuets()
        {
        }

        public CheckBoxForDuets(HoldingMarker mark)
        {
            this.marker = mark;
        }

        public CheckBoxForDuets(HoldingMarker mark, CheckBox cheBox)
        {
            this.marker = mark;
            this.validnessCheckBox = cheBox;
        }

        public override string ToString()
        {
            string outStr = "";
            outStr += this.marker.tourNumber.ToString() + " " + this.marker.groupNumber.ToString() + " " + this.marker.setNumber.ToString() + " " + this.marker.duetNumber.ToString() + "\n" + this.validnessCheckBox.Checked;
            
            return outStr;
        }
    }
}

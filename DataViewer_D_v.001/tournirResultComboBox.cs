using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class tournirResultComboBox
    {
        public HoldingMarker marker;
        public ComboBox valueComboBox;
        public bool isItViewed;

        public tournirResultComboBox()
        {
        }

        public tournirResultComboBox(HoldingMarker mark)
        {
            this.marker = mark;
        }

        public tournirResultComboBox(HoldingMarker mark, ComboBox comBox)
        {
            this.marker = mark;
            this.valueComboBox = comBox;
        }

        public override string ToString()
        {
            string outStr = "";
            outStr += this.marker.tourNumber.ToString() + " " + this.marker.groupNumber.ToString() + " " + this.marker.setNumber.ToString() + " " + this.marker.duetNumber.ToString() + "\n" + this.valueComboBox.SelectedItem.ToString();

            return outStr;
        }
    }
}

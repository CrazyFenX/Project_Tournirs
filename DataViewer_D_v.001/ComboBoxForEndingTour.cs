using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    class ComboBoxForEndingTour
    {
        public HoldingMarker marker;
        public ComboBox markComboBox;
        //public bool isItViewed;
        public int mark;

        public ComboBoxForEndingTour()
        {
            this.mark = 0;
        }

        public ComboBoxForEndingTour(HoldingMarker marker)
        {
            this.marker = marker;
            this.mark = 0;
        }

        public ComboBoxForEndingTour(HoldingMarker marker, ComboBox comBox)
        {
            this.marker = marker;
            this.markComboBox = comBox;
            this.mark = 0;
        }

        public override string ToString()
        {
            string outStr = "";
            outStr += this.marker.tourNumber.ToString() + " " + this.marker.groupNumber.ToString() + " " + this.marker.setNumber.ToString() + " " + this.marker.duetNumber.ToString() + "\n" + this.markComboBox.SelectedIndex + 1;

            return outStr;
        }
    }
}

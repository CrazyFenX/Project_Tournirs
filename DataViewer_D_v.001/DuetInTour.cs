using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class DuetInTour
    {
        public int number;
        public Button duetButton;

        public bool passToNextTour;
        public bool isItViewed;

        public double mark;

        public DuetInTour()
        {
            number = 0;
            duetButton = new Button();
            passToNextTour = false;
            isItViewed = false;
        }

        public DuetInTour(Button btn)
        {
            number = 0;
            duetButton = btn;
            passToNextTour = false;
            isItViewed = false;
        }

        public DuetInTour(int num, Button btn)
        {
            number = num;
            duetButton = btn;
            passToNextTour = false;
            isItViewed = false;
        }
    }
}

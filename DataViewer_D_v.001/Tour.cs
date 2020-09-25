using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class Tour
    {
        //класс ТУРА
        //лист класса Группы
        //кнопка Группы
        //лист кнопок Заходов
        public int number;
        public List<GroupInTour> groupList = new List<GroupInTour>();

        public Panel controlTourPanel;
        public Button tourButton;

        public Tour(int Num)
        {
            this.number = Num;
            this.groupList = new List<GroupInTour>();
        }

        public Tour(int Num, Panel TourPanel, Button TourButton)
        {
            this.number = Num;
            this.groupList = new List<GroupInTour>();
            this.controlTourPanel = TourPanel;
            this.tourButton = TourButton;
        }

        public Tour()
        {
            this.groupList = new List<GroupInTour>();
        }
    }
}

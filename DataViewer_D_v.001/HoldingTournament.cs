using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public partial class HoldingTournament : Form
    {
        public secretaryMainForm previousForm;
        public TournirClass tournir;

        public List<Button> groupsButtons; //После добавления ТУРОВ переделать

        //класс ТУРА
            //лист класса Группы
                //кнопка Группы
                //лист кнопок Заходов

        public HoldingTournament()
        {
            InitializeComponent();
        }

        public HoldingTournament(secretaryMainForm PreviousForm)
        {
            InitializeComponent();
            this.previousForm = PreviousForm;
            this.tournir = PreviousForm.tournir;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Button buttonGroupNew;
            Button buttonSetNew;
            int heigh = 0;
            //int weight = 0;

            foreach (GroupClass item in this.tournir.groups) //организовать запись ТУРОВ и подогнать метод под вывод кнопок для каждого ТУРА
            {
                heigh += 15;
                ControlPanel.Controls.Add(buttonGroupNew = new Button() { Name = "groupButton" + (item.number), Location = new Point(10, heigh), Size = new Size(565, 35), Text = "Группа номер " + item.number });
                heigh += 35;

                foreach (SetClass setItem in item.SetList)
                {
                    heigh += 5;
                    ControlPanel.Controls.Add(buttonSetNew = new Button() {Name = "setButton" + (setItem.number), Location = new Point(15, heigh), Size = new Size(500, 30), Text = "Заход номер " + setItem.number });
                    heigh += 30;
                }
            }
        }

        private void HoldingTournament_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Enabled = true;
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Enabled = true;
            this.Hide();
        }
    }
}

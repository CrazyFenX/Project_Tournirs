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
    public partial class GradingForm : Form
    {
        TournirClass tournir = new TournirClass();

        List<Button> buttonList = new List<Button>();
        List<ComboBox> resultOfTournir_list = new List<ComboBox>();

        secretaryMainForm previousForm = new secretaryMainForm();

        ToolTip t = new ToolTip();
        private int currentGroup = 0;

        public GradingForm()
        {
            InitializeComponent();
        }

        public GradingForm(secretaryMainForm PreviousForm)
        {
            InitializeComponent();
            this.tournir = PreviousForm.tournir;
            this.previousForm = PreviousForm;
        }

        private void GradingForm_Load(object sender, EventArgs e)
        {
            graduatePanel.Visible = false;
            drawTourInfo();
        }

        public void drawTourInfo()
        {
            Button buttonGroupNew;
            buttonList.Clear();

            int heigh = 0;
            foreach (GroupClass item in this.tournir.groups)
            {
                heigh += 15;
                panelOfElements.Controls.Add(buttonGroupNew = new Button()
                {
                    Name = "groupButton" + (item.number),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(10, heigh),
                    Size = new Size(panelOfElements.Width - 20, 35),
                    Text = "Группа " + item.number.ToString(),
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | 
                    System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                });
                heigh += 35;
                buttonList.Add(buttonGroupNew);
                buttonGroupNew.Click += TourButtonsEvent;
                //drawTourInfo(tourList[i]);
                t.SetToolTip(buttonGroupNew, tournir.groups[buttonList.IndexOf(buttonGroupNew)].name);
            }
        }

        public void drawTournirEnding(GroupClass inputGroup)
        {
            ComboBox comboBoxOfJudge = new ComboBox();
            Label newLabel = new Label();
            graduatePanel.Controls.Clear();
            graduatePanel.Visible = true;
            graduatePanel.Visible = true;
            List<int> positionsInComboBoxList = new List<int>();

            int height = 0;
            int weidh = 0;

            height += 45;
            weidh += 30;

            for (int i = 0; i < inputGroup.JudgeList.Count; i++)
            {
                graduatePanel.Controls.Add(newLabel = new Label()
                {
                    Text = inputGroup.JudgeList[i].judgeChar.ToString(),
                    Location = new Point(105 + 80 * i, 15),
                    Size = new Size(30, 25),
                    Font = new Font("", 12)
                });
                t.SetToolTip(newLabel, inputGroup.JudgeList[i].ToString());
            }

            int j = 0;

            foreach (Duet duetItem in inputGroup.duetList)
            {
                graduatePanel.Controls.Add(newLabel = new Label()
                {
                    Text = "Пара" + Convert.ToString(duetItem.number),
                    Location = new Point(10, height),
                    Size = new Size(90, 25),
                    Font = new Font("", 12),
                });
                t.SetToolTip(newLabel, duetItem.ToString());

                for (int i = 0; i < inputGroup.JudgeList.Count; i++)
                {
                    graduatePanel.Controls.Add(comboBoxOfJudge = new ComboBox()
                    {
                        Location = new Point(105 + 80 * i, height),
                        Size = new Size(45, 33),
                        Font = new Font("", 12)
                    });

                    for (int g = 1; g <= 5/*countsOfPositionsNumericUpDown.Value*/; g++)
                    {
                       comboBoxOfJudge.Items.Add(g);
                    }

                    comboBoxOfJudge.BringToFront();

                    //tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].resultOfGroup_list.Add(new tournirResultComboBox(markerForCheckList, comboBoxOfJudge));
                    resultOfTournir_list.Add(comboBoxOfJudge);
                }
                height += 30;
                j++;
            }
        }

        public void TourButtonsEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            graduatePanel.Visible = true;

            drawTournirEnding(tournir.groups[buttonList.IndexOf(btn)]);
        }

        private void GradingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            previousForm.Enabled = true;
        }

        private void controlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toSumUpButton_Click(object sender, EventArgs e)
        {
            double tempMark = 0;
            int counter = 0;

            for (int i = 0; i < tournir.groups[currentGroup].duetList.Count; i++)
            {
                tempMark = 0;
                for (int j = 0; j < tournir.groups[currentGroup].JudgeList.Count; j++)
                {
                    if (resultOfTournir_list[counter].SelectedIndex > -1)
                    {
                        tempMark += resultOfTournir_list[counter].SelectedIndex + 1;
                    }
                    counter++;
                }
                tournir.groups[currentGroup].duetList[i].mark = tempMark / tournir.groups[currentGroup].JudgeList.Count;
                MessageBox.Show(tournir.groups[currentGroup].duetList[i].mark.ToString());
            }
            //for (int i = 0; i < resultOfTournir_list.Count; i++)
            //{
            //    if (resultOfTournir_list[i].SelectedIndex > -1)
            //    {

            //    }
            //}
        }
    }
}
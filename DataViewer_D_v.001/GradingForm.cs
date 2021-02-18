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
        //List<ComboBox> resultOfTournir_list = new List<ComboBox>();
        //List<ComboBox[,]> resultOfTournir_list = new List<ComboBox[,]>();
        ComboBox[,,] resultOfTournir_list;

        List<TabControl> tabControlList = new List<TabControl>();

        secretaryMainForm previousForm = new secretaryMainForm();

        ToolTip t = new ToolTip();
        private int currentGroup = -1;

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
            foreach (Button butItem in buttonList)
                butItem.Visible = true;
        }

        public void drawTourInfo()
        {
            Button buttonGroupNew;
            TabControl tabControlGroupNew;
            buttonList.Clear();

            int heigh = 0;
            //foreach (GroupClass item in this.tournir.groups)
            for (int i = 0; i < tournir.groupsOrder.Length; i++)
            {
                heigh += 15;
                panelOfElements.Controls.Add(buttonGroupNew = new Button()
                {
                    Name = "groupButton" + (tournir.groups[tournir.groupsOrder[i] - 1].number),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Location = new Point(10, heigh),
                    Size = new Size(panelOfElements.Width - 20, 35),
                    Text = "Гр." + tournir.groups[tournir.groupsOrder[i] - 1].number.ToString() + " " + tournir.groups[tournir.groupsOrder[i] - 1].name,
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                    System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                });
                heigh += 35;
                buttonList.Add(buttonGroupNew);
                buttonGroupNew.Click += TourButtonsEvent;
                t.SetToolTip(buttonGroupNew, tournir.groups[tournir.groupsOrder[i] - 1].name);

                panelOfElements.Controls.Add(tabControlGroupNew = new TabControl()
                {
                    Name = "tabControlgroup" + tournir.groups[tournir.groupsOrder[i] - 1].number.ToString(),
                    Size = new Size(panelOfElements.Width, panelOfElements.Height),
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                    System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)))
                });
                foreach (string danceItem in tournir.groups[tournir.groupsOrder[i] - 1].DancesList)
                {
                    tabControlGroupNew.TabPages.Add(new TabPage(danceItem) { AutoScroll = true});
                }

                tabControlList.Add(tabControlGroupNew);
                tabControlGroupNew.Visible = false;
            }
        }

        public void drawTournirEnding(GroupClass inputGroup, TabControl outputContrl)
        {
            ComboBox comboBoxOfJudge = new ComboBox();
            ComboBox[,] comboBoxOfJudgeList = new ComboBox[inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            Label newLabel = new Label();
            //graduatePanel.Controls.Clear();
            //graduatePanel.Visible = true;
            outputContrl.Visible = true;
            //List<int> positionsInComboBoxList = new List<int>();
            resultOfTournir_list = new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            //foreach (TabPage outPage in outputContrl.TabPages)
            for (int f = 0; f < inputGroup.DancesList.Count; f++)
            {
                int height = 0;
                int weidh = 0;

                height += 45;
                weidh += 30;

                int j = 0;
                //for (int i = 0; i < inputGroup.JudgeList.Count; i++)
                foreach (Judge jitem in inputGroup.JudgeList)
                {
                    //graduatePanel.Controls.Add(newLabel = new Label()
                    outputContrl.TabPages[f].Controls.Add(newLabel = new Label()
                    {
                        Text = jitem.judgeChar.ToString(),
                        Location = new Point(105 + 80 * j, 15),
                        Size = new Size(30, 25),
                        Font = new Font("", 12)
                    });
                    t.SetToolTip(newLabel, jitem.ToString());
                    //inputGroup.JudgeList[i]
                    j++;
                } //вывод букв судей

                for (int i = 0; i < inputGroup.duetList.Count; i++)
                {
                    //graduatePanel.Controls.Add(newLabel = new Label()
                    outputContrl.TabPages[f].Controls.Add(newLabel = new Label()
                    {
                        Text = "Пара" + Convert.ToString(inputGroup.duetList[i].number),
                        Location = new Point(10, height),
                        Size = new Size(90, 25),
                        Font = new Font("", 12),
                    });
                    t.SetToolTip(newLabel, inputGroup.duetList[i].ToString());

                    //for (int g = 0; g < inputGroup.DancesList.Count; g++)
                    //{
                    for (j = 0; j < inputGroup.JudgeList.Count; j++)
                    {
                        //graduatePanel.Controls.Add(comboBoxOfJudge = new ComboBox()
                        outputContrl.TabPages[f].Controls.Add(comboBoxOfJudge = new ComboBox()
                        {
                            Location = new Point(105 + 80 * j, height),
                            Size = new Size(45, 33),
                            Font = new Font("", 12)
                        });
                        t.SetToolTip(comboBoxOfJudge, inputGroup.number + " " + inputGroup.duetList[i].numberInGroup.ToString() + " " + (i + 1).ToString());

                        for (int m = 1; m <= 5; m++)
                        {
                            comboBoxOfJudge.Items.Add(m);
                        }

                        /////comboBoxOfJudgeList[i, j] = comboBoxOfJudge;
                        comboBoxOfJudge.BringToFront();
                        resultOfTournir_list[f, i, j] = comboBoxOfJudge;
                        //tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].resultOfGroup_list.Add(new tournirResultComboBox(markerForCheckList, comboBoxOfJudge));
                    }
                    /////resultOfTournir_list.Add(comboBoxOfJudgeList);
                    //}
                    height += 30;
                }
            }
        }

        public void TourButtonsEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            graduatePanel.Visible = true;
            //tabControl1.Visible = true;
            foreach (Button butItem in buttonList)
                butItem.Visible = false;

            currentGroup = tournir.groupsOrder[buttonList.IndexOf(btn)] - 1;
            MessageBox.Show("Выбрана группа " + (currentGroup + 1).ToString());
            drawTournirEnding(tournir.groups[currentGroup], tabControlList[buttonList.IndexOf(btn)]);
            //drawTournirEnding(tournir.groups[buttonList.IndexOf(btn)], tabControlList[tournir.groupsOrder[buttonList.IndexOf(btn)] - 1]);
        }

        private void GradingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (currentGroup > -1)
                    pdf_controller.getResultsPDF(tournir, tournir.groups[currentGroup]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            previousForm.Enabled = true;
        }

        private void controlPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toSumUpButton_Click(object sender, EventArgs e)
        {
            double tempMark = 0;
            int counter = 0;
            if (currentGroup != -1)
                for (int i = 0; i < tournir.groups[currentGroup].duetList.Count; i++)
                {
                    tempMark = 0;
                    tournir.groups[currentGroup].duetList[i].judgeMarkList = new List<List<int>>(tournir.groups[currentGroup].DancesList.Count);
                    tournir.groups[currentGroup].duetList[i].mark = 0;
                    for (int g = 0; g < tournir.groups[currentGroup].DancesList.Count; g++)
                    {
                        tournir.groups[currentGroup].duetList[i].judgeMarkList.Add(new List<int>());
                        for (int j = 0; j < tournir.groups[currentGroup].JudgeList.Count; j++)
                        {
                            //MessageBox.Show("Dance " + g.ToString() + "\nDuet " + i.ToString() + "\nJudge " + j.ToString());
                            if (/*resultOfTournir_list[g][i, j].SelectedIndex > -1*/resultOfTournir_list[g, i, j].Text != "")
                            {
                                tempMark += Convert.ToInt32(resultOfTournir_list[g, i, j].Text);
                                tournir.groups[currentGroup].duetList[i].judgeMarkList[g].Add(Convert.ToInt32(resultOfTournir_list[g, i, j].Text));
                            }
                            counter++;
                        }
                    }

                    MessageBox.Show("Сумма: " + tempMark.ToString() + "\nСудей: " + tournir.groups[currentGroup].JudgeList.Count.ToString() + "\n" +"Танцев" + tournir.groups[currentGroup].DancesList.Count.ToString());

                    tournir.groups[currentGroup].duetList[i].markSum = tempMark;
                    tournir.groups[currentGroup].duetList[i].mark = tempMark / (tournir.groups[currentGroup].JudgeList.Count * tournir.groups[currentGroup].DancesList.Count);
                    tournir.groups[currentGroup].duetList[i].diplomPlace = SecretaryController.getDiplomPlace(tournir.groups[currentGroup].duetList[i].mark);
                    MessageBox.Show(tournir.groups[currentGroup].duetList[i].diplomPlace);

                    string retstr = "";
                    foreach (Judge item in tournir.groups[currentGroup].JudgeList)
                    {
                        retstr += item.judgeChar + " ";
                    }
                    retstr += "\n";
                    for (int d = 0; d < tournir.groups[currentGroup].DancesList.Count; d++)
                    {
                        foreach (int item in tournir.groups[currentGroup].duetList[i].judgeMarkList[d])
                        {
                            retstr += item.ToString();
                        }
                        retstr += "\n";
                    }
                    MessageBox.Show(tournir.groups[currentGroup].duetList[i].ToString() + "\n" + retstr);
                    SecretaryController.UpdateDuetMark(tournir.groups[currentGroup].duetList[i], previousForm.Path_textBox.Text);
                }
            tournir.groups[currentGroup].sortDuetList = sortController.QuickSort(tournir.groups[currentGroup].duetList);
            previousForm.resultsButton.Visible = true;
            //previousForm.Enabled = true;
            //this.Hide();
            //for (int i = 0; i < resultOfTournir_list.Count; i++)
            //{
            //    if (resultOfTournir_list[i].SelectedIndex > -1)
            //    {

            //    }
            //}
        }

        private void graduatePanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
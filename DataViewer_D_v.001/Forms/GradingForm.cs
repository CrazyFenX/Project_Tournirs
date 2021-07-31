using DataViewer_D_v._001.Classes;
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
        ushort[,] totalToursOrder = new ushort[0, 0];

        //List<ComboBox> resultOfTournir_list = new List<ComboBox>();
        //List<ComboBox[,]> resultOfTournir_list = new List<ComboBox[,]>();
        ComboBox[,,] resultOfTournir_list;
        List<ComboBox[,,]> hashResultOfTournir_list = new List<ComboBox[,,]>();

        CheckBox[,,,] resultOfTournirScating_list;
        List<ComboBox[,,]> resultOfTournirScatingFinal_list = new List<ComboBox[,,]>();
        List<CheckBox[,,,]> hashResultOfTournirScating_list = new List<CheckBox[,,,]>();
        //CheckBox[,,] hashResultOfTournirScating_list = CheckBox[0,0,0];
        //hashResultOfTournirScating_list

        List<bool[]> toursResultsBitMap = new List<bool[]>();

        List<TabControl> tabControlList = new List<TabControl>();
        bool isItScating = false;
        bool is_hashResultOfTournir_list_initialised = false;
        bool is_hashResultOfTournirScating_list_initialised = false;
        bool is_resultOfTournirScatingFinal_list_initialised = false;
        secretaryMainForm previousForm = new secretaryMainForm();

        ToolTip t = new ToolTip();
        private int currentGroup = -1;
        private int currentTour = -1;

        public GradingForm()
        {
            InitializeComponent();
        }

        public GradingForm(secretaryMainForm PreviousForm, bool IsThisScating)
        {
            InitializeComponent();
            //MessageBox.Show(IsThisScating.ToString());
            this.tournir = PreviousForm.tournir;
            this.previousForm = PreviousForm;
            this.isItScating = IsThisScating;
        }

        private void GradingForm_Load(object sender, EventArgs e)
        {
            graduatePanel.Visible = false;

            if (!isItScating)
                drawTourInfo();
            else
                drawTourInfoScating();
            foreach (Button butItem in buttonList)
                butItem.Visible = true;
            //}
            //else
            //{
            //    drawTourInfoScating();
            //    foreach (Button butItem in buttonList)
            //        butItem.Visible = true;
            //}
        }

        public void drawTourInfo()
        {
            Button buttonGroupNew;
            TabControl tabControlGroupNew;
            buttonList.Clear();

            nextTourTextBox.Visible = false;
            setCountTextBox.Visible = false;

            toSumUpButton.Text = "Подвести итоги группы";
             
            int height = 0;
            //foreach (GroupClass item in this.tournir.groups)
            for (int i = 0; i < tournir.Branches.Count; i++)
            {
                height += 5;
                panelOfElements.Controls.Add(new Label()
                {
                    Name = "Branch" + (i + 1).ToString(),
                    Text = Convert.ToString(tournir.Branches[i].number) + " Отделение",
                    Location = new Point(10, height + 20),
                    Size = new Size(130, 25),
                    Font = new Font("", 12),

                });
                height += 25;
                foreach (int groupNumInOrder in tournir.Branches[i].groupOrderList)
                {
                    //try
                    //{
                        height += 5;
                        panelOfElements.Controls.Add(buttonGroupNew = new Button()
                        {
                            Name = "groupButton" + (tournir.groups[groupNumInOrder - 1].number),
                            TextAlign = ContentAlignment.MiddleLeft,
                            Location = new Point(10, height),
                            Size = new Size(panelOfElements.Width - 20, 35),
                            Text = "Гр." + tournir.groups[groupNumInOrder - 1].number.ToString() + " " + tournir.groups[groupNumInOrder - 1].name,
                            Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                            System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                        });
                        height += 35;
                        buttonList.Add(buttonGroupNew);
                        if (!isItScating)
                            buttonGroupNew.Click += TourButtonsEvent;
                        else
                            buttonGroupNew.Click += TourButtonsEventScating;

                        t.SetToolTip(buttonGroupNew, tournir.groups[groupNumInOrder - 1].name);

                        panelOfElements.Controls.Add(tabControlGroupNew = new TabControl()
                        {
                            Name = "tabControlgroup" + tournir.groups[groupNumInOrder - 1].number.ToString(),
                            Size = new Size(panelOfElements.Width, panelOfElements.Height),
                            Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                            System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)))
                        });
                        foreach (string danceItem in tournir.groups[groupNumInOrder - 1].DancesList)
                        {
                            tabControlGroupNew.TabPages.Add(new TabPage(danceItem) { AutoScroll = true });
                        }

                        tabControlList.Add(tabControlGroupNew);
                        tabControlGroupNew.Visible = false;
                        //MessageBox.Show("Drawing group " + (groupNumInOrder).ToString());
                        if (!isItScating)
                            drawTournirEnding(tournir.groups[groupNumInOrder - 1], i, tabControlList[tabControlList.Count - 1]);
                        //else
                        //    drawTournirEndingScating(tournir.groups[groupNumInOrder - 1], i, tabControlList[i]);
                    //}
                    //catch (Exception ex)
                    //{
                    //    MessageBox.Show(ex.Message);
                    //}
                }
            }
        }

        public void drawTourInfoScating()
        {
            Button buttonGroupNew;
            TabControl tabControlGroupNew;
            buttonList.Clear();

            nextTourTextBox.Visible = true;
            setCountTextBox.Visible = true;

            toSumUpButton.Text = "Подвести итоги тура";

            int counter = 0;
            int index = -1;
            int heigh = 0;
            //foreach (GroupClass item in this.tournir.groups)
            for (int i = 0; i < tournir.toursOrder.Count; i++)
            {
                counter += tournir.toursOrder[i].Length;
            }
            //MessageBox.Show("В tournir.toursOrder: " + counter.ToString());
            totalToursOrder = new ushort[counter, 2];

            for (int i = 0; i < tournir.toursOrder.Count; i++)
            {
                for (int j = 0; j < tournir.toursOrder[i].Length; j++)
                {
                    try
                    {
                        index++;
                    heigh += 15;
                    panelOfElements.Controls.Add(buttonGroupNew = new Button()
                    {
                        Name = "groupButton" + (tournir.groups[tournir.toursOrder[i][j, 0]].number),
                        TextAlign = ContentAlignment.MiddleLeft,
                        Location = new Point(10, heigh),
                        Size = new Size(panelOfElements.Width - 20, 35),
                        Text = "Гр." + tournir.groups[tournir.toursOrder[i][j, 0]].number.ToString() + " " + tournir.groups[tournir.toursOrder[i][j, 0]].name + " " + Tour.getStringDegr(tournir.toursOrder[i][j, 1]),
                        Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                        System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                    });
                    heigh += 35;
                    buttonList.Add(buttonGroupNew);
                    buttonGroupNew.Click += TourButtonsEventScating;
                    totalToursOrder[index, 0] = tournir.toursOrder[i][j, 0];
                    totalToursOrder[index, 1] = tournir.toursOrder[i][j, 1];
                    t.SetToolTip(buttonGroupNew, tournir.groups[tournir.toursOrder[i][j, 0]].name);

                    panelOfElements.Controls.Add(tabControlGroupNew = new TabControl()
                    {
                        Name = "tabControlgroup" + tournir.groups[tournir.toursOrder[i][j, 0]].number.ToString(),
                        Size = new Size(panelOfElements.Width, panelOfElements.Height),
                        Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                        System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)))
                    });
                    foreach (string danceItem in tournir.groups[tournir.toursOrder[i][j, 0]].DancesList)
                    {
                        tabControlGroupNew.TabPages.Add(new TabPage(danceItem) { AutoScroll = true });
                    }

                    tabControlList.Add(tabControlGroupNew);
                    tabControlGroupNew.Visible = false;

                    //if(!isItScating)
                    //    drawTournirEnding(tournir.groups[tournir.groupsOrder[i] - 1], i, tabControlList[i]);
                    //else
                    if (!tournir.groups[tournir.toursOrder[i][j, 0]].isTheFirstTourInitialised) { tournir.groups[tournir.toursOrder[i][j, 0]].fillBitMapForFirstTour(); }
                    if (tournir.toursOrder[i][j, 1] == 0)
                        drawTournirEndingScatingFinal(tournir.groups[tournir.toursOrder[i][j, 0]], tabControlList[j]);
                    else
                        drawTournirEndingScating(tournir.groups[tournir.toursOrder[i][j, 0]], tournir.toursOrder[i][j, 1], tabControlList[j]);
                    }
                    catch (Exception ex)
                    {
                        //MessageBox.Show(ex.Message);
                    }
                }
            }
            //show
            string str1 = "";
            for (int i = 0; i < totalToursOrder.Length; i++)
            {
                //str1 += "[" + totalToursOrder[i, 0] + "; " + totalToursOrder[i, 1] + "]";
            }
            //MessageBox.Show(str1);
        }

        public void drawTournirEndingScating(GroupClass inputGroup, ushort tourDegree, TabControl outputContrl)
        {
            CheckBox checkBoxOfJudge = new CheckBox();
            CheckBox[,] checkBoxOfJudgeList = new CheckBox[inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            Label newLabel = new Label();
            TabControl tmpTabControl = new TabControl();

            CheckBox tmpCheckBox = new CheckBox();

            hashResultOfTournirScating_list_initialisation();

            for (int f = 0; f < inputGroup.DancesList.Count; f++)
            {
                int height = 5;
                int width = 30;
                //height += 45;
                //weidh += 30;

                int j = 0;

                outputContrl.TabPages[f].Controls.Add(tmpTabControl = new TabControl()
                {
                    Size = new Size(panelOfElements.Width - 10, panelOfElements.Height - 10),
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                    System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom))),
                    Font = new Font("", 12)
                });
                foreach (Judge jitem in inputGroup.JudgeList)
                {
                    width = 20;
                    height = 0;
                    tmpTabControl.TabPages.Add(new TabPage()
                    {
                        Text = jitem.judgeChar.ToString(),
                        AutoScroll = true
                    });
                    int counter = 0;
                    for (int g = 0; g < inputGroup.SetList.Count; g++)
                    {
                        width = 20;
                        tmpTabControl.TabPages[inputGroup.JudgeList.IndexOf(jitem)].Controls.Add(newLabel = new Label()
                        {
                            Text = Convert.ToString(inputGroup.SetList[g].number) + " заход",
                            Location = new Point(width, height + 20),
                            Size = new Size(70, 20),
                            Font = new Font("", 12),
                        });
                        height += 20;
                        for (int i = 0; i < inputGroup.SetList[g].DuetList.Count; i++)
                        {
                            tmpTabControl.TabPages[inputGroup.JudgeList.IndexOf(jitem)].Controls.Add(newLabel = new Label()
                            {
                                Text = Convert.ToString(inputGroup.SetList[g].DuetList[i].number),
                                Location = new Point(width, height + 20),
                                Size = new Size(40, 20),
                                Font = new Font("", 12),
                            });

                            tmpTabControl.TabPages[inputGroup.JudgeList.IndexOf(jitem)].Controls.Add(tmpCheckBox = new CheckBox()
                            {
                                Location = new Point(width, height + 40),
                                Size = new Size(40, 20),
                                Font = new Font("", 12),
                            });
                            //t.SetToolTip(tmpCheckBox, f.ToString() + inputGroup.JudgeList.IndexOf(jitem).ToString() + counter.ToString());
                            if (!inputGroup.tours[tourDegree].tourBitMap[counter])
                                tmpCheckBox.Enabled = false;
                            hashResultOfTournirScating_list[inputGroup.number - 1][tourDegree, f, inputGroup.JudgeList.IndexOf(jitem), counter] = tmpCheckBox;
                            //MessageBox.Show(tourDegree.ToString() + f.ToString() + inputGroup.JudgeList.IndexOf(jitem).ToString() + counter.ToString());
                            //t.SetToolTip(newLabel, inputGroup.SetList[g].DuetList.ToString());
                            width += 40;
                            if (i % 15 == 0 && i > 0)
                            {
                                width = 20;
                                height += 70;
                            }
                            counter++;
                        }
                        height += 70;
                    }
                    t.SetToolTip(tmpTabControl, jitem.ToString());
                    //inputGroup.JudgeList[i]
                    j++;
                } //вывод букв судей

            }
        }

        public void drawTournirEndingScatingFinal(GroupClass inputGroup, TabControl outputContrl)
        {
            //CheckBox checkBoxOfJudge = new CheckBox();
            //CheckBox[,] checkBoxOfJudgeList = new CheckBox[inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            Label newLabel = new Label();
            TabControl tmpTabControl = new TabControl();

            ComboBox tmpEtaloneComboBox = new ComboBox();
            ComboBox tmpComboBox = new ComboBox();
            //graduatePanel.Controls.Clear();
            //graduatePanel.Visible = true;

            //outputContrl.Visible = true;
            for (int i = 0; i < inputGroup.tours[0].countOfDuets; i++)
                tmpEtaloneComboBox.Items.Add(i + 1);

            //List<int> positionsInComboBoxList = new List<int>();
            //resultOfTournir_list = new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count];

            resultOfTournirScatingFinal_list_initialisation();

            //////resultOfTournir_list = new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            //for (int y = 0; y < inp)
            //MessageBox.Show("in resultOfTournirScatingFinal_list: " + resultOfTournirScatingFinal_list.Count.ToString() + "\nGroup " + inputGroup.number.ToString() + " Tour " + 0.ToString());

            for (int f = 0; f < inputGroup.DancesList.Count; f++)
            {
                int height = 5;
                int width = 30;

                int j = 0;

                outputContrl.TabPages[f].Controls.Add(tmpTabControl = new TabControl()
                {
                    Size = new Size(panelOfElements.Width - 10, panelOfElements.Height - 10),
                    Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                    System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom))),
                    Font = new Font("", 12)
                });
                foreach (Judge jitem in inputGroup.JudgeList)
                {
                    width = 20;
                    height = 0;
                    tmpTabControl.TabPages.Add(new TabPage()
                    {
                        Text = jitem.judgeChar.ToString(),
                        AutoScroll = true
                    });
                    int counter = 0;
                    for (int g = 0; g < inputGroup.SetList.Count; g++)
                    {
                        width = 20;
                        tmpTabControl.TabPages[inputGroup.JudgeList.IndexOf(jitem)].Controls.Add(newLabel = new Label()
                        {
                            Text = Convert.ToString(inputGroup.SetList[g].number) + " заход",
                            Location = new Point(width, height + 20),
                            Size = new Size(70, 20),
                            Font = new Font("", 12),
                        });
                        height += 20;
                        for (int i = 0; i < inputGroup.SetList[g].DuetList.Count; i++)
                        {
                            tmpTabControl.TabPages[inputGroup.JudgeList.IndexOf(jitem)].Controls.Add(newLabel = new Label()
                            {
                                Text = Convert.ToString(inputGroup.SetList[g].DuetList[i].number),
                                Location = new Point(width, height + 20),
                                Size = new Size(40, 20),
                                Font = new Font("", 12),
                            });

                            tmpTabControl.TabPages[inputGroup.JudgeList.IndexOf(jitem)].Controls.Add(tmpComboBox = new ComboBox()
                            {
                                Location = new Point(width, height + 40),
                                Size = new Size(40, 20),
                                Font = new Font("", 12),
                            });
                            tmpComboBox.Items.AddRange(tmpEtaloneComboBox.Items.Cast<object>().ToArray());
                            //t.SetToolTip(tmpCheckBox, f.ToString() + inputGroup.JudgeList.IndexOf(jitem).ToString() + counter.ToString());

                            tmpComboBox.Enabled = inputGroup.tours[0].tourBitMap[counter];

                            resultOfTournirScatingFinal_list[inputGroup.number - 1][f, inputGroup.JudgeList.IndexOf(jitem), counter] = tmpComboBox;
                            //MessageBox.Show(tourDegree.ToString() + f.ToString() + inputGroup.JudgeList.IndexOf(jitem).ToString() + counter.ToString());
                            //t.SetToolTip(newLabel, inputGroup.SetList[g].DuetList.ToString());
                            width += 40;
                            if (i % 15 == 0 && i > 0)
                            {
                                width = 20;
                                height += 70;
                            }
                            counter++;
                        }
                        height += 70;
                    }
                    t.SetToolTip(tmpTabControl, jitem.ToString());
                    //inputGroup.JudgeList[i]
                    j++;
                } //вывод букв судей

            }
        }


        public void hashResultOfTournir_list_initialisation()
        {
            if (!is_hashResultOfTournir_list_initialised)
            {
                foreach(uint item in tournir.groupsOrder)
                        hashResultOfTournir_list.Add(new ComboBox[0, 0, 0]);
                is_hashResultOfTournir_list_initialised = true;
            }
        }
        public void hashResultOfTournirScating_list_initialisation()
        {
            if (!is_hashResultOfTournirScating_list_initialised)
            {
                foreach(var groupItem in tournir.groups)
                    hashResultOfTournirScating_list.Add(new CheckBox[groupItem.tours.Count, groupItem.DancesList.Count, groupItem.JudgeList.Count, groupItem.duetList.Count]);
                is_hashResultOfTournirScating_list_initialised = true;
            }
        }
        public void resultOfTournirScatingFinal_list_initialisation()
        {
            if (!is_resultOfTournirScatingFinal_list_initialised)
            {
                resultOfTournirScatingFinal_list = new List<ComboBox[,,]>();
                foreach (var groupItem in tournir.groups)
                    resultOfTournirScatingFinal_list.Add(new ComboBox[groupItem.DancesList.Count, groupItem.JudgeList.Count, groupItem.duetList.Count]);
                is_resultOfTournirScatingFinal_list_initialised = true;
                //MessageBox.Show("resultOfTournirScatingFinal_list was initialised!");
            }
        }
        public void drawTournirEnding(GroupClass inputGroup, int numberInGroupOrder, TabControl outputContrl)
        {
            ComboBox comboBoxOfJudge = new ComboBox();
            ComboBox[,] comboBoxOfJudgeList = new ComboBox[inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            Label newLabel = new Label();
            //graduatePanel.Controls.Clear();
            //graduatePanel.Visible = true;

            //////////outputContrl.Visible = true;

            //List<int> positionsInComboBoxList = new List<int>();
            //resultOfTournir_list = new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count];

            hashResultOfTournir_list_initialisation();
            //////resultOfTournir_list = new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            //MessageBox.Show(inputGroup.DancesList.Count.ToString() + " " + inputGroup.duetList.Count.ToString() + " " + inputGroup.JudgeList.Count.ToString());
            hashResultOfTournir_list[inputGroup.number - 1] = new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            //hashResultOfTournir_list.Add(new ComboBox[inputGroup.DancesList.Count, inputGroup.duetList.Count, inputGroup.JudgeList.Count]);

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
                        //MessageBox.Show("Num of group: " + inputGroup.number.ToString() + "\nName of group: " + inputGroup.name);
                        //MessageBox.Show("Count of branches: " + (tournir.Branches.Count).ToString());
                        //MessageBox.Show("Branch.number: " + (tournir.Branches[inputGroup.branchNumber - 1].number - 1).ToString());
                        //hashResultOfTournir_list[tournir.Branches[inputGroup.branchNumber - 1].number - 1][f, i, j] = comboBoxOfJudge;
                        hashResultOfTournir_list[inputGroup.number - 1][f, i, j] = comboBoxOfJudge;
                        //tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].resultOfGroup_list.Add(new tournirResultComboBox(markerForCheckList, comboBoxOfJudge));
                    }
                    ////resultOfTournir_list.Add(comboBoxOfJudgeList);

                    //}
                    height += 30;
                }
            }
        }

        public void drawScatingReglament(GroupClass inputGroup, int numberInGroupOrder, Panel outputContrl)
        {
            ComboBox comboBoxOfJudge = new ComboBox();
            ComboBox[,] comboBoxOfJudgeList = new ComboBox[inputGroup.duetList.Count, inputGroup.JudgeList.Count];
            Label newLabel = new Label();
            Button tmpButton1 = new Button();
            Button tmpButton2 = new Button();
            Button tmpButton3 = new Button();

            int height = 15;
            int weidh = 10;

            //for (int f = 0; f < inputGroup.tours.Count; f++)
            //{
            //    weidh = 10;
            //    outputContrl.Controls.Add(newLabel = new Label()
            //    {
            //        Text = inputGroup.name,
            //        Location = new Point(height, weidh),
            //        Size = new Size(30, 25),
            //        Font = new Font("", 12)
            //    });
            //    weidh += 35;
            //    if (inputGroup.tours[f].isItPlayed)
            //        outputContrl.Controls.Add(tmpButton1 = new Button()
            //        {
            //            Text = inputGroup.name,
            //            Location = new Point(height, weidh),
            //            Size = new Size(80, 25),
            //            Font = new Font("", 12),
            //            BackColor = Color.YellowGreen
            //        });
            //    else
            //    {
            //        outputContrl.Controls.Add(tmpButton2 = new Button()
            //        {
            //            Text = inputGroup.name,
            //            Location = new Point(height, weidh),
            //            Size = new Size(80, 25),
            //            Font = new Font("", 12)
            //        });
            //        outputContrl.Controls.Add(tmpButton3 = new Button()
            //        {
            //            Text = inputGroup.name,
            //            Location = new Point(height, weidh),
            //            Size = new Size(80, 25),
            //            Font = new Font("", 12)
            //        });
            //    }
            //}
        }

        public void TourButtonsEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            graduatePanel.Visible = true;
            foreach (Button butItem in buttonList)
                butItem.Visible = false;

            currentGroup = tournir.groupsOrder[buttonList.IndexOf(btn)] - 1;
            //MessageBox.Show("Выбрана группа " + (currentGroup + 1).ToString());
            tabControlList[buttonList.IndexOf(btn)].Visible = true;
            resultOfTournir_list = hashResultOfTournir_list[currentGroup];
            //drawTournirEnding(tournir.groups[currentGroup], tabControlList[buttonList.IndexOf(btn)]);
        }

        public void TourButtonsEventScating(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            graduatePanel.Visible = true;
            //tabControl1.Visible = true;
            foreach (Button butItem in buttonList)
                butItem.Visible = false;

            currentGroup = totalToursOrder[buttonList.IndexOf(btn), 0];
            currentTour = totalToursOrder[buttonList.IndexOf(btn), 1];
            MessageBox.Show("Выбрана группа " + (currentGroup + 1).ToString() + " Тур " + Tour.getStringDegr(currentTour));
            if (currentTour - 1 >= 0)
            {
                //MessageBox.Show("В туре " + tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets.ToString());
                nextTourTextBox.Text = tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets.ToString();
            }
            else
                nextTourTextBox.Text = "-";
            //!!!
            if (currentTour > 0)
                redrawingCheckBoxList(tournir.groups[currentGroup], tournir.groups[currentGroup].tours[currentTour]);
            else
                redrawingComboBoxList(tournir.groups[currentGroup], tournir.groups[currentGroup].tours[currentTour]);
            tabControlList[buttonList.IndexOf(btn)].Visible = true;
            //

            //if (currentTour == 0)
            //    drawTournirEndingScatingFinal(tournir.groups[currentGroup], tabControlList[buttonList.IndexOf(btn)]);
            //else
            //    drawTournirEndingScating(tournir.groups[currentGroup], (ushort)currentTour, tabControlList[buttonList.IndexOf(btn)]);

            //foreach (var item in tournir.groups[currentGroup].tours[currentTour].tourBitMap)
            if (!tournir.groups[currentGroup].isTheFirstTourInitialised) { tournir.groups[currentGroup].fillBitMapForFirstTour();}
            if (currentTour > 0)
                resultOfTournirScating_list = hashResultOfTournirScating_list[currentGroup];
            //drawTournirEnding(tournir.groups[currentGroup], tabControlList[buttonList.IndexOf(btn)]);
        }

        private void redrawingButtonList(Tour inputTour)
        {
            foreach (Button item in buttonList)
            {
            //    if ()
            }
            //buttonList[totalToursOrder]
        }

        private void redrawingCheckBoxList(GroupClass inputGroup, Tour inputTour)
        {
            for (int i = 0; i < inputTour.tourBitMap.Length; i++)
            {
                for (int f = 0; f < inputGroup.DancesList.Count; f++)
                    for (int g = 0; g < inputGroup.JudgeList.Count; g++)
                        hashResultOfTournirScating_list[inputGroup.number - 1][inputTour.degree, f, g, i].Enabled = inputTour.tourBitMap[i];
            }
        }

        private void redrawingComboBoxList(GroupClass inputGroup, Tour inputTour)
        {
            for (int i = 0; i < inputTour.tourBitMap.Length; i++)
            {
                for (int f = 0; f < inputGroup.DancesList.Count; f++)
                    for (int g = 0; g < inputGroup.JudgeList.Count; g++)
                       resultOfTournirScatingFinal_list[inputGroup.number - 1][f, g, i].Enabled = inputTour.tourBitMap[i];
            }
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
            if (currentGroup != -1)
            {
                if (previousForm.Path_textBox.Text != "")
                {

                    if (!isItScating)
                        toSumUpMassSport();
                    else
                        toSumUpScating();
                }
                else
                    MessageBox.Show("Выберите базу турнира");
            }
            else
                MessageBox.Show("Группа не выбрана! Повторите попытку");
        }

        private void toSumUpMassSport()
        {
            int numOfDuetsInNextTour = 10;
            double tempMark = 0;
            int counter = 0;

            //MessageBox.Show(currentGroup.ToString());
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
                            if (resultOfTournir_list[g, i, j].Text != "")
                            {
                                tempMark += Convert.ToInt32(resultOfTournir_list[g, i, j].Text);
                                tournir.groups[currentGroup].duetList[i].judgeMarkList[g].Add(Convert.ToInt32(resultOfTournir_list[g, i, j].Text));
                            }
                            else
                                tournir.groups[currentGroup].duetList[i].judgeMarkList[g].Add(0);
                            //MessageBox.Show("Dance " + g.ToString() + "\nJudge " + j.ToString() + "\nDuet " + counter.ToString() + "\n" + tournir.groups[currentGroup].duetList[i].judgeMarkList[g][0].ToString());

                            counter++;
                        }
                    }

                    //MessageBox.Show("Сумма: " + tempMark.ToString() + "\nСудей: " + tournir.groups[currentGroup].JudgeList.Count.ToString() + "\n" +"Танцев" + tournir.groups[currentGroup].DancesList.Count.ToString());

                    tournir.groups[currentGroup].duetList[i].markSum = tempMark;
                    tournir.groups[currentGroup].duetList[i].mark = tempMark / (tournir.groups[currentGroup].JudgeList.Count * tournir.groups[currentGroup].DancesList.Count);
                    tournir.groups[currentGroup].duetList[i].diplomPlace = SecretaryController.getDiplomPlace(tournir.groups[currentGroup].duetList[i].mark);
                    //MessageBox.Show(tournir.groups[currentGroup].duetList[i].diplomPlace);

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
                    //MessageBox.Show(tournir.groups[currentGroup].duetList[i].ToString() + "\n" + retstr);
                    SecretaryController.UpdateDuetMark(tournir.groups[currentGroup].duetList[i], previousForm.Path_textBox.Text);
                }
            string retstr1 = "";
            foreach (Duet duetItem in tournir.groups[currentGroup].duetList)
                retstr1 += duetItem.ToString();
            //MessageBox.Show(retstr1);
            tournir.groups[currentGroup].sortDuetList = sortController.QuickSort(tournir.groups[currentGroup].duetList.ToArray(), 0);
            retstr1 = "";
            foreach (Duet duetItem in tournir.groups[currentGroup].sortDuetList)
                retstr1 += duetItem.ToString();
            // MessageBox.Show(retstr1);

            previousForm.resultsButton.Visible = true;

            try
            {
                pdf_controller.getResultsPDF(tournir, tournir.groups[currentGroup]);
                previousForm.printButton.Visible = true;
                previousForm.label_printerName.Visible = true;
                previousForm.printerName_TextBox.Visible = true;
                tournir.groups[currentGroup].markered = true;
                MessageBox.Show("Протокол\n" + tournir.groups[currentGroup].name + "\nуспешно сформирован!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toSumUpScating()
        {
            if (currentTour == 0)
                finalToSumUp();
            else
                tourToSumUp();
        }

        private void tourToSumUp()
        {
            tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets = Convert.ToInt32(nextTourTextBox.Text);
            double tempMark = 0;

            String retStr = "";
            MessageBox.Show("Оценка группы: " + currentGroup.ToString() + " Тура: " + currentTour.ToString());
            for (int i = 0; i < tournir.groups[currentGroup].duetList.Count; i++)
            {
                tempMark = 0;
                if (tournir.groups[currentGroup].tours[currentTour].tourBitMap[i])
                {
                    tournir.groups[currentGroup].tours[currentTour].sortDuetList.Add(tournir.groups[currentGroup].duetList[i]);
                    tournir.groups[currentGroup].duetList[i].judgeMarkListScating.Clear();
                    for (int g = 0; g < tournir.groups[currentGroup].DancesList.Count; g++)
                    {
                        //tournir.groups[currentGroup].duetList[i].judgeMarkListScating.Add(new List<List<bool>>()); //Добавляем строку в массиве для очередного танца (ХХ-Х--ХХХХ--Х-Х)
                        tournir.groups[currentGroup].duetList[i].judgeMarkListScating.Add(new List<bool>()); //Добавляем строку в массиве для очередного танца (ХХ-Х--ХХХХ--Х-Х)

                        for (int j = 0; j < tournir.groups[currentGroup].JudgeList.Count; j++)
                        {
                            //MessageBox.Show(currentTour.ToString() + g.ToString() + j.ToString() + i.ToString());
                            //resultOfTournirScating_list[currentTour, g, j, i].BackColor = Color.LimeGreen;
                            //tournir.groups[currentGroup].duetList[i].judgeMarkListScating[g].Add(new List<bool>());
                            if (resultOfTournirScating_list[currentTour, g, j, i].Checked)
                            {
                                tournir.groups[currentGroup].duetList[i].judgeMarkListScating[g].Add(true);
                                tempMark += 1;
                            }
                            else
                                tournir.groups[currentGroup].duetList[i].judgeMarkListScating[g].Add(false);
                        }
                    }
                    //retStr += tempMark.ToString() + " ";
                    tournir.groups[currentGroup].duetList[i].markSum = tempMark;
                }
                //MessageBox.Show(retStr);
                retStr = "";
                for (int j = 0; j < tournir.groups[currentGroup].duetList.Count; j++)
                {
                    retStr += tournir.groups[currentGroup].duetList[j].number.ToString() + "\n";
                    foreach (List<bool> itemDance in tournir.groups[currentGroup].duetList[j].judgeMarkListScating)
                    {
                        foreach (bool itemJud in itemDance)
                        {
                            retStr += "  " + itemJud.ToString() + " ";
                        }
                        retStr += "\n";
                    }
                    retStr += "\n";
                }
            }
            //MessageBox.Show(retStr);
            //string retstr1 = "";
            //foreach (Duet duetitem in tournir.groups[currentGroup].duetList)
            //    retstr1 += duetitem.ToStringScating();
            //MessageBox.Show(retstr1);
            tournir.groups[currentGroup].sortDuetList = sortController.QuickSort(tournir.groups[currentGroup].duetList.ToArray(), 1);
            tournir.groups[currentGroup].tours[currentTour].sortDuetList = sortController.QuickSort(tournir.groups[currentGroup].duetList.ToArray(), 1);
            //retstr1 = "";
            //foreach (Duet duetitem in tournir.groups[currentGroup].sortDuetList)
            //foreach (Duet duetitem in tournir.groups[currentGroup].tours[currentTour].sortDuetList)
            //        retstr1 += duetitem.ToStringScating();
            //MessageBox.Show(retstr1);

            retStr = "";
            if (currentTour - 1 >= 0)
            {
                if (tournir.groups[currentGroup].sortDuetList[tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets - 1].markSum == tournir.groups[currentGroup].sortDuetList[tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets].markSum)
                {
                    MessageBox.Show("Невозможно однозначно определить список участников, переходящих в следующий тур!\nСкорректрируйте число участников, проходящих в следующий тур и повторите поптку");
                    retStr = "";
                    for (int i = 0; i < tournir.groups[currentGroup].sortDuetList.Count; i++)
                    {
                        retStr += tournir.groups[currentGroup].sortDuetList[i].ToStringScating() + "\n";
                        if ((i + 1) == tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets)
                            retStr += "----------------------------------\n";
                    }
                    MessageBox.Show(retStr);
                }
                else
                {
                    tournir.groups[currentGroup].tours[currentTour - 1].tourBitMap = new System.Collections.BitArray(tournir.groups[currentGroup].duetList.Count, false);
                    for (int j = 0; j < tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets; j++)
                        tournir.groups[currentGroup].tours[currentTour - 1].tourBitMap[tournir.groups[currentGroup].duetList.IndexOf(tournir.groups[currentGroup].sortDuetList[j])] = true;
                    for (int j = tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets; j < tournir.groups[currentGroup].duetList.Count; j++)
                        tournir.groups[currentGroup].duetList[tournir.groups[currentGroup].duetList.IndexOf(tournir.groups[currentGroup].sortDuetList[j])].skatingPosition = j + 1;
                }
            }
            retStr = "";
            foreach (var item in tournir.groups[currentGroup].tours[currentTour - 1].tourBitMap)
                retStr += item.ToString();
            //MessageBox.Show("BitMap в следующий тур: " + retStr);
            try
            {
                pdf_controller.getTourResultsPDF(tournir, tournir.groups[currentGroup], tournir.groups[currentGroup].tours[currentTour]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (setCountTextBox.Text.Length > 0)
            {
                try
                {
                    //if (Path_textBox.Text != "" && setCountTextBox.Text != "" && groupComboBox.SelectedIndex > -1)
                    //{
                    ushort setCount = (ushort)(Convert.ToInt32(setCountTextBox.Text));
                    tournir.groups[currentGroup].SetList.Clear();
                    
                    //retStr = "";
                    //foreach (bool boolItem in tournir.groups[currentGroup].tours[currentTour - 1].tourBitMap)
                    //    retStr += boolItem.ToString() + " ";
                    //retStr += "\n";
                    //MessageBox.Show(retStr);

                    SecretaryController.splitGroupForSets(tournir.groups[currentGroup], setCount, tournir.groups[currentGroup].tours[currentTour - 1].tourBitMap);
                    retStr = "";
                    foreach (SetClass setItem in tournir.groups[currentGroup].SetList)
                    {
                        retStr += tournir.groups[currentGroup].SetList.IndexOf(setItem);
                        foreach (Duet duetItem in setItem.DuetList)
                            retStr += duetItem.ToString() + "\n";
                        retStr += "\n";
                    }
                    MessageBox.Show("Сформированы заходы:\n" + retStr);
                    //SecretaryController.clearSet(tournir.groups[currentGroup], previousForm.Path_textBox.Text);
                    //for (int i = 0; i < tournir.groups[currentGroup].SetList.Count; i++)
                    //    SecretaryController.insertSet(tournir.groups[currentGroup].SetList[i], previousForm.Path_textBox.Text);
                    
                    pdf_controller.getBlankForJudgePDF(tournir, tournir.groups[currentGroup]);
                    MessageBox.Show("Заходы успешно сформированы!");
                    DialogResult res = MessageBox.Show("Распечатать бланки для судей?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string folderName = tournir.path.Remove(tournir.path.LastIndexOf('\\'), tournir.path.Length - tournir.path.LastIndexOf('\\'));
                        foreach (Judge judgeItem in tournir.judges)
                            foreach (string danceItem in tournir.groups[currentGroup].DancesList)
                                printing_controller.PrintPDF(previousForm.printerName_TextBox.Text, folderName + $@"\MarkBlanks\{"Group " + tournir.groups[currentGroup].number.ToString() + " " + danceItem + " " + tournir.groups[currentGroup].tournir_name.Replace(" ", "") + " " + judgeItem.Name + "_" + judgeItem.Surname[0] + "_" + judgeItem.Patronymic[0]}.pdf", folderName);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }

        private void finalToSumUp()
        {
            int tempMark = 0;

            String retStr = "";
            MessageBox.Show("Оценка группы: " + currentGroup.ToString() + " Тура: " + currentTour.ToString());
            retStr = "";
            //foreach (var item in tournir.groups[currentGroup].tours[currentTour].tourBitMap)
            //    retStr += item.ToString();
            //MessageBox.Show(retStr);
            retStr = "";
            for (int i = 0; i < tournir.groups[currentGroup].duetList.Count; i++)
            {
                tempMark = 0;
                if (tournir.groups[currentGroup].tours[currentTour].tourBitMap[i])
                {
                    tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList.Clear();
                    for (int g = 0; g < tournir.groups[currentGroup].DancesList.Count; g++)
                    {
                        tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList.Add(new List<int>()); //Добавляем строку в массиве для очередного танца (ХХ-Х--ХХХХ--Х-Х)
                        for (int j = 0; j < tournir.groups[currentGroup].JudgeList.Count; j++)
                        {
                            //MessageBox.Show(currentTour.ToString() + g.ToString() + j.ToString() + i.ToString());
                            //resultOfTournirScating_list[currentTour, g, j, i].BackColor = Color.LimeGreen;
                            if (resultOfTournirScatingFinal_list[currentGroup][g, j, i].Text != "")
                            {
                                try
                                {
                                    tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList[g].Add(Convert.ToInt32(resultOfTournirScatingFinal_list[currentGroup][g, j, i].Text));
                                    //tempMark += Convert.ToInt32(resultOfTournirScatingFinal_list[currentGroup][g, j, i].Text);
                                }
                                catch
                                {
                                    //MessageBox.Show("Оценка пары номер " + i.ToString() + " имела неверный формат!\nОценка пропущена.");
                                    tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList[g].Add(0);
                                }
                            }
                            else
                                tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList[g].Add(0);
                            retStr += tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList[g][tournir.groups[currentGroup].duetList[i].judgeMarkScatingFinalList[g].Count - 1].ToString() + " ";
                        }
                        retStr += "\n";
                    }
                    //tournir.groups[currentGroup].duetList[i].markSum = tempMark;
                }
                //MessageBox.Show(retStr);

                //retStr = "";
                //for (int j = 0; j < tournir.groups[currentGroup].duetList.Count; j++)
                //{
                //    retStr += tournir.groups[currentGroup].duetList[j].number.ToString() + "\n";
                //    foreach (List<bool> itemDance in tournir.groups[currentGroup].duetList[j].judgeMarkListScating)
                //    {
                //        foreach (bool itemJud in itemDance)
                //        {
                //            retStr += "  " + itemJud.ToString() + " ";
                //        }
                //        retStr += "\n";
                //    }
                //    retStr += "\n";
                //}
                //MessageBox.Show(retStr);
            }
            string retstr1 = "Исходный массив участников:\n";
            tournir.groups[currentGroup].duetListFinal = new List<Duet>();
            foreach (Duet duetitem in tournir.groups[currentGroup].duetList)
            {
                if (tournir.groups[currentGroup].tours[currentTour].tourBitMap[tournir.groups[currentGroup].duetList.IndexOf(duetitem)])
                {
                    tournir.groups[currentGroup].duetListFinal.Add(duetitem);
                    retstr1 += duetitem.ToStringScating();
                }
            }
            //MessageBox.Show(retstr1);
            tournir.groups[currentGroup].sortDuetListFinal = FinalGrading.sortingDuetsInFinalTour(tournir.groups[currentGroup].duetListFinal, tournir.groups[currentGroup].DancesList.Count);

            retstr1 = "Отсортированный массив:\n";
            foreach (Duet duetitem in tournir.groups[currentGroup].sortDuetListFinal)
                retstr1 += duetitem.ToStringScating();
            //MessageBox.Show(retstr1);
            for (int i = 0; i < tournir.groups[currentGroup].tours.Count; i++)
            {
                for (int j = 0; j < tournir.groups[currentGroup].tours[i].countOfDuets; j++)
                {

                }
            }
            try
            {
                pdf_controller.getFinalTourResultsPDF(tournir, tournir.groups[currentGroup]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void updateButtonsAccess()
        {
            foreach (Button buttonItem in buttonList)
            {
                //if (tournir.groups[i].tours[j].isItPlayed == -1) buttonItem.BackColor = Color.LawnGreen;
                //else if (tournir.groups[i].tours[j].isItPlayed == 0) buttonItem.BackColor = Color.LimeGreen;
                //else if (tournir.groups[i].tours[j].isItPlayed == 1) buttonItem.BackColor = Color.LightGray;
            }
        }

        private void graduatePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelOfElements_Paint(object sender, PaintEventArgs e)
        {

        }

        private void backToGroupButton_Click(object sender, EventArgs e)
        {
            graduatePanel.Visible = false;
            foreach (TabControl item in tabControlList)
            {
                item.Visible = false;
            }
            foreach (Button butItem in buttonList)
                butItem.Visible = true;
        }

        private void nextTourTextBox_TextChanged(object sender, EventArgs e)
        {
            int tmpInt = 0;
            try
            {
                tmpInt = Convert.ToInt32(nextTourTextBox.Text);
                if (currentTour > 0 && tmpInt < tournir.groups[currentGroup].duetList.Count)
                {
                    tournir.groups[currentGroup].tours[currentTour - 1].countOfDuets = tmpInt;
                    //MessageBox.Show(tmpInt.ToString());
                }
            }
            catch
            {

            }
        }

        private void testButton_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using DataViewer_D_v._001.Classes;

namespace DataViewer_D_v._001
{
    public partial class formationReglament : Form
    {
        public secretaryMainForm previousForm;
        TournirClass tournir = null;
        List<Tour> totalTourList = new List<Tour>();
        List<indexedComboBox> storageOftoursIndex = new List<indexedComboBox>();
        //List<ComboBox> comboboxList;
        //ComboBox HourOfTournir_comboBox;
        //ComboBox MinutesOfTournir_comboBox;

        List<TabControl> tabControlList = new List<TabControl>();
        List<List<ComboBox>> groupComboBoxList = new List<List<ComboBox>>();
        List<List<TextBox>> groupTextBoxList = new List<List<TextBox>>();

        List<List<int>> countOfToursInBranch = new List<List<int>>();

        List<int> skatingSystemGroupsIndexes = new List<int>();

        int selectedGroup = 0;

        int system = 0;
        int height;
        ComboBox tmpComboBox = new ComboBox();

        public static string connectString;

        public static OleDbConnection con;

        public static OleDbCommand command;

        public formationReglament()
        {
            InitializeComponent();
        }

        public formationReglament(secretaryMainForm secretaryPreviousForm)
        {
            InitializeComponent();
            this.previousForm = secretaryPreviousForm;
            this.tournir = this.previousForm.tournir;
            system = 0;
        }
        public formationReglament(secretaryMainForm secretaryPreviousForm, int sys)
        {
            InitializeComponent();
            this.previousForm = secretaryPreviousForm;
            this.tournir = this.previousForm.tournir;
            this.system = sys;
            if (sys == 0)
            {
                label2.Visible = false;
                label3.Visible = false;
                startTourComboBox.Visible = false;
                numOfDuetNextTourTextBox.Visible = false;
            }
            else if (sys == 1)
            {

            }
        }


        private void formationReglament_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Enabled = true;
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            string retstr = "";
            string retstr1 = "";
            foreach (List<ushort> listItem in tournir.groupsBranchOrder)
            {
                foreach (ushort item in listItem)
                    retstr += item.ToString() + ";";
                //retstr += "\n";
            }
            if (system == 0)
            {
                foreach (ushort shortItem in tournir.groupsOrder)
                    retstr1 += shortItem.ToString();
                MessageBox.Show(retstr1);
            }
            else
            {
                foreach (ushort[,] ushortItemVector in tournir.toursOrder)
                    for(int i = 0; i < ushortItemVector.GetLength(0); i++)
                        retstr1 += "[" + ushortItemVector[i, 0].ToString() + ", " + ushortItemVector[i, 1].ToString() + "]\n";
                MessageBox.Show(retstr1);
            }
            this.previousForm.Enabled = true;
            this.Hide();
        }

        private void formationReglament_Load(object sender, EventArgs e)
        {
            Label groupLabel = new Label();
            //HourOfTournir_comboBox = new ComboBox();
            //MinutesOfTournir_comboBox = new ComboBox();
            Label branchNumLabel = new Label();

            //foreach (Branch in)
            //countOfToursInBranch.Add(new List<int>());

            //foreach (Branch item in tournir.Branches)
            //    tournir.toursOrder.Add(new ushort[0, 0]);
            ComboBox groupComboBox = new ComboBox();
            ComboBox tmpComboBox = new ComboBox();
            groupComboBoxList.Clear();
            int height = 0;
            //int h1 = 0;
            //List<ComboBox.ObjectCollection> comboCollection = new List<ComboBox.ObjectCollection>();

            //comboboxList = new List<ComboBox>();
            //try
            //{
            if (system == 0)
                drawTourInfo();
            else
                drawTourInfoSkating();
                //for (int g = 0; g < this.tournir.Branches.Count; g++)
                //{
                //    groupComboBoxList.Add(new List<ComboBox>());
                //    tmpComboBox = new ComboBox();

                //    panelOfElements.Controls.Add(branchNumLabel = new Label()
                //    {
                //        Text = this.tournir.Branches[g].ToString(),
                //        Location = new Point(5, height += 15)
                //    });

                //    for (int j = 0; j < tournir.groups.Count; j++)
                //        if (tournir.groups[j].branchNumber == g + 1)
                //        {
                //            tmpComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name + "          " + tournir.groups[j].duetList.Count + " пар");
                //        }

                //    for (int i = 0; i < this.tournir.groups.Count; i++)
                //    {

                //        if (tournir.groups[i].branchNumber == g + 1)
                //        {
                //            panelOfElements.Controls.Add(groupComboBox = new ComboBox()
                //            {
                //                Name = "comboBox" + (i).ToString(),
                //                Location = new Point(5, height += 30),
                //                Size = new Size(450, 50)
                //            });
                //            groupComboBox.Items.AddRange(tmpComboBox.Items.Cast<String>().ToArray());
                //            groupComboBoxList[g].Add(groupComboBox);
                //        }
                //    }
                //    height += 30;

                //foreach (String item in tmpComboBox.Items)
                //{
                //    groupComboBox.Items.Add(item);
                //}
                //foreach (String item in tmpComboBox.Items)
                //{
                //    groupComboBox.Items.Add(item);
                //}
                //groupComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name + " " + tournir.groups[j].duetList.Count + " пар");
                //foreach (ComboBox comboBoxItem in groupComboBoxList[g])
                //    foreach (String item in tmpComboBox.Items)
                //    {
                //        comboBoxItem.Items.Add(item);
                //    }
                //comboBoxItem.Items.Add(groupComboBox.Items[groupComboBoxList[g].IndexOf(comboBoxItem)]);

                //MessageBox.Show($"{times_Comboboxes.Count}");
                //h ++;
            //}
                timeTournirLabel.Text = "Время начала турнира: " + tournir.time.ToString();
                //for (int i = 0; i < this.tournir.groups.Count; i++)
                //{
                //    formation_groupBox.Controls["panelOfElements"].Controls.Add(new GroupBox() { Name = "groupbox" + (i).ToString(), Location = new Point(5, 50 * (i)), Size = new Size(450, 50) });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(groupLabel = new Label() { Name = "groupLabel" + (i).ToString(), Location = new Point(5, 15), Text = "Группа номер " + (i + 1).ToString() });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(HourOfTournir_comboBox = new ComboBox() { Name = "HourOfTournir_comboBox" + (i).ToString(), Location = new Point(330, 18), Size = new Size(40, 24), Text = "Часы" ,Items = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" } });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(MinutesOfTournir_comboBox = new ComboBox() { Name = "MinutesOfTournir_comboBox" + (i).ToString(), Location = new Point(384, 18), Size = new Size(60, 24), Text = "Минуты", Items = { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" } });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(doublePointLabel = new Label() { Name = "doublePointLabel" + (i).ToString(), Location = new Point(370, 18), Text = ":", Size = new Size(14, 24) });

                //    times_Comboboxes.Add(HourOfTournir_comboBox);
                //    times_Comboboxes.Add(MinutesOfTournir_comboBox);

                //}
                //MessageBox.Show($"{times_Comboboxes.Count}");

                //timeTournirLabel.Text = "Время начала турнира: " + tournir.time.ToString();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            try
            {
                pdf_controller.getReglamentReport(tournir);
                MessageBox.Show("Документ регламента успешно сформирован!\nНайти его можно в папке Reglament");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //try
            //{
            if (system == 0)
                saveIfMassSport();
            else
                saveIfSkatingSystem();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public void saveIfMassSport()
        {

            int counter = 0;
            //for (int j = 0; j <= tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab); j++)
            for (int j = 0; j <= tabControlOfElements.SelectedIndex; j++)
                for (int i = 0; i < groupComboBoxList[j].Count; i++)
                {
                    if (groupComboBoxList[j][i].SelectedIndex == -1)
                    {
                        MessageBox.Show("Не все поля заполнены!");
                        return;
                    }
                    for (int k = i + 1; k < groupComboBoxList[tabControlOfElements.SelectedIndex].Count - 1; k++)
                    {
                        if (groupComboBoxList[j][i].SelectedIndex == groupComboBoxList[j][k].SelectedIndex)
                        {
                            MessageBox.Show("Недопустимо выбирать одну группу несколько раз!");
                            return;
                        }
                    }
                }

            //tournir.groupsOrder = new ushort[tournir.groups.Count];
            tournir.groupsOrder = new List<ushort>(tournir.groups.Count);
            for (int g = 0; g < tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab) + 1; g++)
                tournir.groupsBranchOrder.Add(new List<ushort>());// = new List<List<ushort>>(tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab) + 1);


            string retstr = "";
            //for (int k = 0; k <= tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab); k++)
            //{
            int k1 = tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab);
            for (int t = 0; t < k1; t++)
                for (int t1 = 0; t1 < groupComboBoxList[t].Count; t1++)
                    counter++;
            ushort[] positionsList = new ushort[groupComboBoxList[k1].Count];
            //MessageBox.Show(groupComboBoxList[k].Count.ToString());
            for (int i = 0; i < groupComboBoxList[k1].Count; i++)
            {
                //positionsList[i] = (ushort)(groupComboBoxList[tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab)][i].SelectedIndex + 1);
                positionsList[i] = (ushort)(tournir.groups[groupComboBoxList[k1][i].SelectedIndex + counter].number);
                //tournir.groupsOrder[i] = (ushort)(tournir.groups[groupComboBoxList[k1][i].SelectedIndex + counter].number);
                retstr += (tournir.groups[groupComboBoxList[k1][i].SelectedIndex + counter].number).ToString() + ";";
            }
            //tournir.groupsBranchOrder[k] = new List<ushort>(positionsList.ToList());
            //}
            MessageBox.Show(retstr);
            //this.previousForm.tournir.groupsBranchOrder[tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab)];

            //retstr1 = "";
            string retstr1 = "";
            counter = 0;
            foreach (List<ushort> listItem in tournir.groupsBranchOrder)
            {
                foreach (ushort item in listItem)
                {
                    retstr1 += item.ToString() + ";";
                    tournir.groupsOrder[counter] = item;
                    counter++;
                }
                //retstr += "\n";
            }
            //foreach (ushort shortItem in tournir.groupsOrder)
            //    retstr1 += shortItem.ToString();
            //MessageBox.Show(retstr);
            //MessageBox.Show(retstr1);
            SecretaryController.UpdateGroupsOrder(retstr, k1 + 1, previousForm.Path_textBox.Text);
            tournir.Branches = SecretaryController.TakeBranch(previousForm.Path_textBox.Text);

            foreach (Branch itemBranch in tournir.Branches)
                foreach (int item in itemBranch.groupOrderList)
                    tournir.groupsOrder.Add((ushort)item);
        }

        public void saveIfSkatingSystem()
        {
            int counter = 0;
            //for (int j = 0; j <= tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab); j++)
            for (int i = 0; i < storageOftoursIndex.Count; i++)
            {
                counter++;
                storageOftoursIndex[i].tourComboBox.BackColor = Color.White;
                if (storageOftoursIndex[i].tourComboBox.SelectedIndex == -1)
                {
                    storageOftoursIndex[i].tourComboBox.BackColor = Color.MediumVioletRed;
                    MessageBox.Show("Не все поля заполнены!");
                    return;
                }
                for (int k = i + 1; k < storageOftoursIndex.Count; k++)
                {
                    //MessageBox.Show(storageOftoursIndex[i].tourComboBox.SelectedIndex.ToString());
                    if (storageOftoursIndex[i].tourComboBox.SelectedIndex == storageOftoursIndex[k].tourComboBox.SelectedIndex)
                    {
                        storageOftoursIndex[i].tourComboBox.BackColor = Color.PaleVioletRed;
                        storageOftoursIndex[k].tourComboBox.BackColor = Color.PaleVioletRed;
                        MessageBox.Show("Недопустимо выбирать один тур несколько раз!");
                        return;
                    }
                }
            }
            //try
            //{
            if (tournir.toursOrder == null || tournir.toursOrder.Count == 0)
            {
                MessageBox.Show("toursOrder is null");
                tournir.toursOrder = new List<ushort[,]>();
                for (int i = 0; i < tournir.Branches.Count; i++)
                {
                    MessageBox.Show("Количество групп в отделении " + (i + 1).ToString() + " " + tournir.Branches[i].groupOrderList.Count.ToString());
                    tournir.toursOrder.Add(new ushort[tournir.Branches[i].countOfTours, 2]);
                }
            }
            else 
            {
                for (int i = 0; i < tournir.Branches.Count; i++)
                {
                    if (tournir.Branches[i].countOfTours > tournir.toursOrder[i].Length)
                        tournir.toursOrder[i] = new ushort[tournir.Branches[i].countOfTours, 2];
                }
            }
            //MessageBox.Show("toursOrder contains: " + tournir.toursOrder.Count);
            //foreach(var item in tournir.toursOrder)
            //    MessageBox.Show("toursOrder item contains: " + item.Length.ToString());
            //for (int g = 0; g < tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab) + 1; g++)
            //    tournir.groupsBranchOrder.Add(new List<ushort>());// = new List<List<ushort>>(tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab) + 1);

            counter = 0;
            string retstr = "";
            //int k = tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab);
            //MessageBox.Show("Всего туров в этом отделении: " + storageOftoursIndex.Count.ToString());
            for (int i = 0; i < storageOftoursIndex.Count; i++)
            {
                //int numCurrentGroup = Convert.ToInt32(storageOftoursIndex[i].tourComboBox.Text.Substring(0, storageOftoursIndex[i].tourComboBox.Text.IndexOf(")"))) - 1;
                int numCurrentGroup = storageOftoursIndex[i].GroupNumber;
                //MessageBox.Show(storageOftoursIndex[i].GroupNumber.ToString() + storageOftoursIndex[i].TourNumber.ToString());
                //Добавляем в массив индексы группы и тура под номером выбранного отделения 
                //tournir.toursOrder[tabControlOfElements.SelectedIndex][i, 0] = storageOftoursIndex[storageOftoursIndex[i].tourComboBox.SelectedIndex].GroupNumber;
                //tournir.toursOrder[tabControlOfElements.SelectedIndex][i, 1] = storageOftoursIndex[storageOftoursIndex[i].tourComboBox.SelectedIndex].TourNumber;
                
                //MessageBox.Show(i.ToString());

                tournir.toursOrder[tabControlOfElements.SelectedIndex][i, 0] = storageOftoursIndex[storageOftoursIndex[i].tourComboBox.SelectedIndex].GroupNumber;
                tournir.toursOrder[tabControlOfElements.SelectedIndex][i, 1] = storageOftoursIndex[storageOftoursIndex[i].tourComboBox.SelectedIndex].TourNumber;
                //Удалять прошлые записи
                SecretaryController.clearTours(tournir.groups[numCurrentGroup], tournir.path);
                SecretaryController.insertTours(tournir.groups[numCurrentGroup], tournir.path);
                
                retstr += storageOftoursIndex[storageOftoursIndex[i].tourComboBox.SelectedIndex].GroupNumber.ToString() + ".";
                retstr += storageOftoursIndex[storageOftoursIndex[i].tourComboBox.SelectedIndex].TourNumber.ToString() + ";";
            }
            MessageBox.Show(retstr);
            SecretaryController.UpdateToursOrderInBranch(retstr, tabControlOfElements.SelectedIndex + 1, tournir.path);
            //for (int i = 0; i < groupComboBoxList[k].Count; i++)
            //{
            //positionsList[i] = (ushort)(groupComboBoxList[tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab)][i].SelectedIndex + 1);
            //positionsList[i] = (ushort)(tournir.groups[groupComboBoxList[k][i].SelectedIndex + counter].number);
            //tournir.groupsOrder[i] = (ushort)(tournir.groups[groupComboBoxList[k][i].SelectedIndex + counter].number);
            //retstr += (tournir.groups[groupComboBoxList[k][i].SelectedIndex + counter].number).ToString() + ";";
            //}
            //tournir.groupsBranchOrder[k] = new List<ushort>(positionsList.ToList());
            //tournir.groupsBranchOrder.Add(new List<ushort>(positionsList.ToList()));
            //}
            //MessageBox.Show(retstr);
            //this.previousForm.tournir.groupsBranchOrder[tabControlOfElements.TabPages.IndexOf(tabControlOfElements.SelectedTab)];

            retstr = "";
            string retstr1 = "";
            counter = 0;
            foreach (List<ushort> listItem in tournir.groupsBranchOrder)
            {
                foreach (ushort item in listItem)
                {
                    retstr += item.ToString() + ";";
                    tournir.groupsOrder[counter] = item;
                    counter++;
                }
                //retstr += "\n";
            }
            foreach (ushort shortItem in tournir.groupsOrder)
                retstr1 += shortItem.ToString();
            MessageBox.Show(retstr);
            //MessageBox.Show(retstr1);
            //////SecretaryController.UpdateGroupsOrder(retstr, previousForm.Path_textBox.Text);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        public void drawTourInfo()
        {
            //try
            //{
            ComboBox groupComboBox = new ComboBox();
            ComboBox tmpComboBox = new ComboBox();
            groupComboBoxList = new List<List<ComboBox>>();
            tabControlOfElements.TabPages.Clear();
            int counter = 0;
            int height = 0;
            int heigh = 0;
            //foreach (GroupClass item in this.tournir.groups)
            for (int i = 0; i < tournir.Branches.Count; i++)
            {
                groupComboBoxList.Add(new List<ComboBox>());
                tmpComboBox = new ComboBox();

                tabControlOfElements.TabPages.Add(new TabPage(tournir.Branches[i].ToString()) { AutoScroll = true });
                heigh += 15;
                for (int j = 0; j < tournir.groups.Count; j++)
                    if (tournir.groups[j].branchNumber == i + 1)
                    {
                        tmpComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name + "          " + tournir.groups[j].duetList.Count + " пар");
                    }

                for (int g = 0; g < this.tournir.groups.Count; g++)
                {

                    if (tournir.groups[g].branchNumber == i + 1)
                    {
                        tabControlOfElements.TabPages[i].Controls.Add(groupComboBox = new ComboBox()
                        {
                            Name = "comboBox" + (i).ToString(),
                            Location = new Point(5, height += 30),
                            Size = new Size(450, 50)
                        });
                        groupComboBox.Items.AddRange(tmpComboBox.Items.Cast<String>().ToArray());
                        groupComboBox.Click += GroupComboBoxClickEvent;
                        groupComboBox.SelectedIndexChanged += GroupComboBoxClickEvent;
                        groupComboBoxList[i].Add(groupComboBox);
                    }
                }
                height = 0;
            }
            counter = 0;
            for (int i = 0; i < tournir.groupsBranchOrder.Count; i++)
            {
                if (tournir.groupsBranchOrder[i] != null)
                {
                    for (int j = 0; j < tournir.groupsBranchOrder[i].Count; j++)
                    {
                        try
                        {
                            groupComboBoxList[i][j].SelectedIndex = tournir.groupsBranchOrder[i][j] - 1 - counter;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    counter += tournir.groupsBranchOrder[i].Count;
                }
            }
            timeTournirLabel.Text = "Время начала турнира: " + tournir.time.ToString();
        }

        public void drawTourInfoSkating()
        {
            //try
            //{
            Label groupLabel = new Label();
            TextBox groupTextBox = new TextBox();
            ComboBox groupComboBox = new ComboBox();

            groupComboBoxList = new List<List<ComboBox>>();
            groupTextBoxList = new List<List<TextBox>>();
            tabControlOfElements.TabPages.Clear();
            int counter = 0;
            height = 10;
            int heigh = 0;
            //foreach (GroupClass item in this.tournir.groups)
            for (int i = 0; i < tournir.Branches.Count; i++)
            {
                groupComboBoxList.Add(new List<ComboBox>());
                groupTextBoxList.Add(new List<TextBox>());

                tabControlOfElements.TabPages.Add(new TabPage(tournir.Branches[i].ToString()) { AutoScroll = true });
                heigh += 15;

                for (int g = 0; g < this.tournir.groups.Count; g++)
                {
                    groupComboBox = new ComboBox();
                    groupLabel = new Label();
                    groupTextBox = new TextBox();
                    if (tournir.groups[g].branchNumber == (i + 1) && tournir.groups[g].system == 1)
                    {
                        tabControlOfElements.TabPages[i].Controls.Add(groupLabel = new Label()
                        {
                            Name = "skate_label" + (i).ToString(),
                            Text = tournir.groups[g].name + "          " + tournir.groups[g].duetList.Count + " пар",
                            Location = new Point(5, height),
                            Size = new Size(200, 20),
                            Font = new Font("", 12)
                        });

                        tabControlOfElements.TabPages[i].Controls.Add(groupComboBox = new ComboBox()
                        {
                            Name = "skate_comboBox" + (i).ToString(),
                            Location = new Point(210, height),
                            Size = new Size(100, 20),
                            Font = new Font("", 12)
                        });
                        //groupComboBox.Items.AddRange(tmpComboBox.Items.Cast<String>().ToArray());
                        //groupComboBox.Click += startTourComboBoxFromList_SelectedIndexChanged;
                        groupComboBox.SelectedIndexChanged += startTourComboBoxFromList_SelectedIndexChanged;

                        tabControlOfElements.TabPages[i].Controls.Add(groupTextBox = new TextBox()
                        {
                            Name = "skate_textBox" + (i).ToString(),
                            Location = new Point(320, height),
                            Size = new Size(50, 20),
                            Font = new Font("", 12)
                        });
                        skatingSystemGroupsIndexes.Add(tournir.groups[g].number - 1);
                        groupComboBoxList[i].Add(groupComboBox);
                        groupTextBoxList[i].Add(groupTextBox);
                        fillFormationElements(tournir.groups[g], groupComboBox, groupTextBox);

                        height += 30;
                    }
                }
                height = 0;
            }
            counter = 0;
            for (int i = 0; i < tournir.groupsBranchOrder.Count; i++)
            {
                if (tournir.groupsBranchOrder[i] != null)
                {
                    for (int j = 0; j < tournir.groupsBranchOrder[i].Count; j++)
                    {
                        try
                        {
                            groupComboBoxList[i][j].SelectedIndex = tournir.groupsBranchOrder[i][j] - 1 - counter;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    counter += tournir.groupsBranchOrder[i].Count;
                }
            }
            timeTournirLabel.Text = "Время начала турнира: " + tournir.time.ToString();
        }


        public void fillFormationElements(GroupClass inputGroup, ComboBox startTourCB, TextBox numTB)
        {
            startTourCB.Items.Clear();
            List<int> tmpList = Tour.getTourdegree(inputGroup.duetList.Count);
            //MessageBox.Show(inputGroup.duetList.Count.ToString());
            int tourDegree = 1;
            foreach (int item in tmpList)
            {
                tourDegree = 1;
                //if (item == 0)
                //    startTourComboBox.Items.Add($"Финал");
                //else
                //{
                //    for (int j = 0; j < item; j++)
                //        tourDegree *= 2;
                //    startTourComboBox.Items.Add($"1/{tourDegree}");
                //}
                startTourCB.Items.Add(Tour.getStringDegr(item));
            }
            //startTourComboBox.SelectedIndex = startTourComboBox.Items.Count - 1;
            numTB.Text = (6 * (tourDegree / 2)).ToString();
            //return retTour;
        }
        public void GroupComboBoxClickEvent(object sender, EventArgs e)
        {
            ComboBox tmpComboBox = (ComboBox)sender;
            Tour retTour = new Tour();
            if (tmpComboBox.SelectedIndex > -1)
            {
                //fillFormationElements(this.tournir.groups[tmpComboBox.SelectedIndex]);
                //MessageBox.Show("Группа" + (tmpComboBox.SelectedIndex + 1).ToString());
                //Tour retTour = new Tour(this.tournir.groups[tmpComboBox.SelectedIndex].duetList.Count);
                //retTour.formReglamentComboBox = tmpComboBox;
                retTour = new Tour(this.tournir.groups[tmpComboBox.SelectedIndex].duetList.Count);
                retTour.formReglamentComboBox = tmpComboBox;

                selectedGroup = tmpComboBox.SelectedIndex;
                //MessageBox.Show("Выбрана группа" + selectedGroup.ToString());
                tournir.groups[selectedGroup].tours.Add(retTour);
                //MessageBox.Show(retTour.ToString());
            }
        }

        private void startNumberInTourComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox thisComboBox = (ComboBox)sender;
            //indexedComboBox tmpIndexedCB = new indexedComboBox(thisComboBox);
            if (thisComboBox.SelectedIndex > -1 && thisComboBox.Text != "")
            {
                int tourDegree = 1;
                int countOfParticipants = 0;
                for (int i = 0; i <= thisComboBox.SelectedIndex; i++)
                {
                    tourDegree *= 2;
                }
                if (thisComboBox.Text.Contains("Финал")) countOfParticipants = 6;
                else
                {
                    countOfParticipants = 6 * Convert.ToInt32(thisComboBox.Text.Substring(thisComboBox.Text.LastIndexOf('/') + 1));
                }
                //MessageBox.Show(tournir.groups[selectedGroup].tour.degrees[thisComboBox.SelectedIndex].ToString());
                foreach (indexedComboBox inexedItem in storageOftoursIndex)
                {
                    if (inexedItem.Equals(new indexedComboBox(ref thisComboBox, 0, 0)))
                    {
                        //MessageBox.Show(storageOftoursIndex.IndexOf(inexedItem).ToString());
                        totalTourList[storageOftoursIndex.IndexOf(inexedItem)].numOfParticipantsTextBox.Text = countOfParticipants.ToString();
                    }
                }
                //groupTextBoxList[tabControlOfElements.SelectedIndex][groupComboBoxList[tabControlOfElements.SelectedIndex].IndexOf(thisComboBox)].Text = countOfParticipants.ToString();
            }
        }

        private void startTourComboBoxFromList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox thisComboBox = (ComboBox)sender;
            if (thisComboBox.SelectedIndex > -1 && thisComboBox.Text != "")
            {
                int tourDegree = 1;
                int countOfParticipants = 0;
                for (int i = 0; i <= thisComboBox.SelectedIndex; i++)
                {
                    tourDegree *= 2;
                }
                if (thisComboBox.Text == "Финал")
                    if (tournir.groups[selectedGroup].duetList.Count < 6)
                        countOfParticipants = tournir.groups[selectedGroup].duetList.Count; 
                    else
                        countOfParticipants = 6;
                else
                {
                    if (tournir.groups[selectedGroup].duetList.Count < 6 * Convert.ToInt32(thisComboBox.Text.Substring(thisComboBox.Text.LastIndexOf('/') + 1)))
                        countOfParticipants = tournir.groups[selectedGroup].duetList.Count;
                    else
                        countOfParticipants = 6 * Convert.ToInt32(thisComboBox.Text.Substring(thisComboBox.Text.LastIndexOf('/') + 1));
                }
                //MessageBox.Show(tournir.groups[selectedGroup].tour.degrees[thisComboBox.SelectedIndex].ToString());
                groupTextBoxList[tabControlOfElements.SelectedIndex][groupComboBoxList[tabControlOfElements.SelectedIndex].IndexOf(thisComboBox)].Text = countOfParticipants.ToString();
            }
        }

        private void tournir_toursOrder_initialising()
        {
            //if (tournir.toursOrder == null || tournir.toursOrder.Count == 0)

        }

        private void formatingToursButton_Click(object sender, EventArgs e)
        {
            bool IsToursOrderEmpty = false;
            //tournir_toursOrder_initialising();
            if (tournir.toursOrder == null || tournir.toursOrder.Count == 0)
            {
                MessageBox.Show("ToursOrderIsEmpty!");
                IsToursOrderEmpty = true;
            }
            label1.Text = "Задайте очередность туров:";
            formatingToursButton.Visible = false;
            saveButton.Visible = true;
            formatingToursPanel.Controls.Clear();
            formatingToursPanel.Visible = true;

            Label groupLabel = new Label();
            TextBox groupTextBox = new TextBox();
            ComboBox groupComboBox = new ComboBox();
            Tour tmpTour = new Tour();
            formatingToursPanel.Controls.Clear();
            tmpComboBox = new ComboBox();
            totalTourList = new List<Tour>();
            //storageOftoursIndex = new List<ComboBox>();
            storageOftoursIndex = new List<indexedComboBox>();
            int g1 = -1;
            //int sumDynDegree = 0;
            for (int g = 0; g < this.tournir.groups.Count; g++)
            {
                if (tournir.groups[g].branchNumber == tabControlOfElements.SelectedIndex + 1 && tournir.groups[g].system == 1) //skatingSystemGroupsIndexes
                {
                    g1++;
                    int tmpDegree = 1;
                    int dynamicDegree = 1;
                    tournir.groups[g].tours.Clear();
                    //MessageBox.Show(tabControlOfElements.SelectedIndex.ToString() + " " + g.ToString());
                    if (groupComboBoxList[tabControlOfElements.SelectedIndex][g1].Text != "Финал")
                        tmpDegree = Convert.ToInt32(groupComboBoxList[tabControlOfElements.SelectedIndex][g].Text.Substring(groupComboBoxList[tabControlOfElements.SelectedIndex][g1].Text.LastIndexOf('/') + 1));
                    tmpComboBox.Items.Add(tournir.groups[g].number.ToString() + ".1" + ") " + tournir.groups[g].name + " Финал");
                    tournir.groups[g].tours.Add(tmpTour = new Tour(0, 1));
                    totalTourList.Add(tmpTour);
                    storageOftoursIndex.Add(new indexedComboBox((ushort)(tournir.groups[g].number - 1), (ushort)(tournir.groups[g].tours.Count - 1)));
                    //sumDynDegree++;
                    //string retStr = ""; 
                    while (tmpDegree > 1)
                    {
                        tournir.groups[g].tours.Add(tmpTour = new Tour(Tour.getCountFromDegr(dynamicDegree), 1));
                        //sumDynDegree += tmpTour.degree + 1;
                        //MessageBox.Show(tournir.groups[g].number.ToString() + "." + (tournir.groups[g].tours.Count).ToString());
                        storageOftoursIndex.Add(new indexedComboBox((ushort)(tournir.groups[g].number - 1), (ushort)(tournir.groups[g].tours.Count - 1)));
                        totalTourList.Add(tmpTour);
                        tmpComboBox.Items.Add(tournir.groups[g].number.ToString() + "." + (tournir.groups[g].tours.Count).ToString() + ") " + tournir.groups[g].name + " " + Tour.getStringDegr(tournir.groups[g].tours[tournir.groups[g].tours.Count - 1].degree));
                        tmpDegree /= 2;
                        dynamicDegree++;
                        //sumDynDegree++;
                        //retStr += ;0
                    }
                    tmpTour.countOfDuets = Convert.ToInt32(groupTextBoxList[tabControlOfElements.SelectedIndex][g1].Text);
                    MessageBox.Show("в туре " + tmpTour.countOfDuets.ToString() + "участников");
                    tournir.Branches[tournir.groups[g].branchNumber - 1].countOfTours += tournir.groups[g].tours.Count;
                    //if (IsToursOrderEmpty)
                }
            }
            //for (int h = 0; h < tmpComboBox.Items.Count; h++)
            //tournir.toursOrder[tabControlOfElements.SelectedIndex] = new ushort[tmpComboBox.Items.Count, 0];
            //MessageBox.Show("Now in tournir.toursOrder: " + tournir.toursOrder[tabControlOfElements.SelectedIndex].Length.ToString());
            int counter = 0;
            for (int g = 0; g < this.tournir.groups.Count; g++)
            {
                if (tournir.groups[g].branchNumber == tabControlOfElements.SelectedIndex + 1 && tournir.groups[g].system == 1)
                {
                    foreach (Tour itemTour in tournir.groups[g].tours)
                    {
                        groupLabel = new Label();
                        groupComboBox = new ComboBox();
                        formatingToursPanel.Controls.Add(groupComboBox = new ComboBox()
                        {
                            Name = "skateTour_ComboBox" + (tabControlOfElements.SelectedIndex).ToString(),
                            Location = new Point(5, height),
                            Size = new Size(200, 20),
                            Font = new Font("", 12)
                        });
                        groupComboBox.Items.AddRange(tmpComboBox.Items.Cast<String>().ToArray());
                        groupComboBox.SelectedIndexChanged += startNumberInTourComboBox_SelectedIndexChanged;

                        formatingToursPanel.Controls.Add(groupTextBox = new TextBox()
                        {
                            Name = "skateTour_textBox" + (tabControlOfElements.SelectedIndex).ToString(),
                            Location = new Point(320, height),
                            Size = new Size(50, 20),
                            Font = new Font("", 12)
                        });
                        //toursTextBoxList .Add(groupTextBox);
                        //fillFormationElements(tournir.groups[g], groupTextBox);

                        //indexedComboBox tmpIndexedComboBox = new indexedComboBox(ref groupComboBox, (ushort)g, (ushort)tournir.groups[g].tours.IndexOf(itemTour));
                        storageOftoursIndex[counter].tourComboBox = groupComboBox;
                        itemTour.formReglamentComboBox = groupComboBox;
                        itemTour.numOfParticipantsTextBox = groupTextBox;
                        counter++;
                        height += 30;
                    }
                }
            }
            height = 0;
        
        }

        private void formatingToursPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    public partial class indexedComboBox
    {
        ushort groupNumber = 0;
        ushort tourNumber = 0;
        public ComboBox tourComboBox = null;

        public ushort GroupNumber { get { return groupNumber; } set { groupNumber = value; } }
        public ushort TourNumber { get { return tourNumber; } set { tourNumber = value; } }

        //Constructors
        public indexedComboBox() { }
        public indexedComboBox(ushort group, ushort tour)
        {
            tourComboBox = null;
            groupNumber = group;
            tourNumber = tour;
        }
        public indexedComboBox(ref ComboBox tourCB, ushort group, ushort tour)
        {
            tourComboBox = tourCB;
            groupNumber = group;
            tourNumber = tour;
        }
        public override bool Equals(object obj)
        {
            indexedComboBox tempICB = (indexedComboBox)obj;
            if (this.tourComboBox == tempICB.tourComboBox) return true;
            return false;
        }
    }
}

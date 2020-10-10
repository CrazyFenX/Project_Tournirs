using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace DataViewer_D_v._001
{
    public partial class HoldingTournament : Form
    {
        public secretaryMainForm previousForm;
        public TournirClass tournir;

        public List<Button> groupsButtons; //После добавления ТУРОВ переделать

        public DateTime timeOfStart;

        public HoldingMarker currentMark;

        public Thread threadForTimer;

        public List<Button> tourButtonList;

        public List<CheckBox> judgeCheckBoxes;

        bool tournamentIsAlive;

        public DateTime diffDate = new DateTime();

        public List<Tour> tourList = new List<Tour>();
        public int currentTour;

        //класс ТУРА
        //лист класса Группы
        //кнопка Группы
        //лист кнопок Заходов

        public HoldingTournament()
        {
            InitializeComponent();
            tournamentIsAlive = false;

            tourList = new List<Tour>();
        }

        public HoldingTournament(secretaryMainForm PreviousForm)
        {
            InitializeComponent();
            tournamentIsAlive = false;
            this.previousForm = PreviousForm;
            this.tournir = PreviousForm.tournir;
            TestAddingDuets(tournir);

            tourList = new List<Tour>();
            tourButtonList = new List<Button>();
        }

        public void TourButtonsEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            currentTour = tourButtonList.IndexOf(btn);

            //MessageBox.Show("Выбран тур" + (currentTour).ToString());

            for (int i = 0; i < tourList.Count; i++)
            {
                if (i == currentTour)
                {
                    tourList[i].tourButton.BackColor = Color.Turquoise;
                    tourList[i].controlTourPanel.Visible = true;
                }
                else
                {
                    tourList[i].tourButton.BackColor = Color.Gray;
                    tourList[i].controlTourPanel.Visible = false;
                }
            }
        }

        public void drawTourInfo(Tour tourNew)
        {
            Button buttonGroupNew;
            Button buttonSetNew;
            Button buttonDuetNew;

            int heigh = 0;
            foreach (GroupClass item in this.tournir.groups) //организовать запись ТУРОВ и подогнать метод под вывод кнопок для каждого ТУРА
            {
                if (item.SetList.Count != 0)
                {
                    heigh += 15;
                    tourNew.controlTourPanel.Controls.Add(buttonGroupNew = new Button() { Name = "groupButton" + (item.number), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(10, heigh), Size = new Size(565, 35), Text = "Группа номер " + item.number });
                    heigh += 35;
                    GroupInTour groupInTourNew = new GroupInTour(buttonGroupNew);
                    int countOfSets = 0;

                    foreach (SetClass setItem in item.SetList)
                    {
                        if (setItem.DuetList.Count != 0)
                        {
                            heigh += 5;
                            tourNew.controlTourPanel.Controls.Add(buttonSetNew = new Button() { Name = "setButton" + (setItem.number), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(35, heigh), Size = new Size(500, 30), Text = "Заход номер " + setItem.number });
                            heigh += 30;

                            groupInTourNew.SetListInTour.Add(new SetInTour(countOfSets, buttonSetNew));
                            //int countOfDuets = 0;

                            foreach (Duet duetItem in setItem.DuetList)
                            {
                                heigh += 5;
                                tourNew.controlTourPanel.Controls.Add(buttonDuetNew = new Button() { Name = "duetButton" + (duetItem.number), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(55, heigh), Size = new Size(460, 20), Text = "Пара номер " + (duetItem.number + 1) });
                                heigh += 20;

                                groupInTourNew.SetListInTour[countOfSets].DuetListInTour.Add(new DuetInTour(duetItem.number, buttonDuetNew));
                            }
                            countOfSets++;

                            //for (int j = 0; j < setItem.DuetList.Count; j++)
                            //{
                            //    heigh += 5;
                            //    tourNew.controlTourPanel.Controls.Add(buttonDuetNew = new Button() { Name = "duetButton" + (setItem.DuetList[j].number), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(40, heigh), Size = new Size(460, 20), Text = "Пара номер " + duetItem.number + 1 });
                            //    heigh += 20;

                            //    groupInTourNew.SetListInTour[countOfSets].DuetListInTour.Add(new DuetInTour(buttonDuetNew));
                            //}
                            //countOfSets++;
                        }
                    }

                    tourNew.groupList.Add(groupInTourNew); ///////ЧАСТНЫЙ СЛУЧАЙ
                }
            }
            ClrAndMarkerIt(currentMark);
        }

        public void drawTourInfo2(Tour tour)
        {
            int heigh = 0;
            foreach (GroupInTour groupItem in tour.groupList) //организовать запись ТУРОВ и подогнать метод под вывод кнопок для каждого ТУРА
            {
                if (groupItem.SetListInTour.Count != 0)
                {
                    heigh += 15;
                    groupItem.groupButton.Location = new Point(10, heigh);
                    tour.controlTourPanel.Controls.Add(groupItem.groupButton);
                    heigh += 35;
                    //GroupInTour groupInTourNew = new GroupInTour(buttonGroupNew);
                    int countOfSets = 0;

                    foreach (SetInTour setItem in groupItem.SetListInTour)
                    {
                        if (setItem.DuetListInTour.Count != 0)
                        {
                            heigh += 5;
                            setItem.setButton.Location = new Point(35, heigh);
                            tour.controlTourPanel.Controls.Add(setItem.setButton);
                            heigh += 30;

                            foreach (DuetInTour duetItem in setItem.DuetListInTour)
                            {
                                heigh += 5;
                                duetItem.duetButton.Location = new Point(55, heigh);
                                tour.controlTourPanel.Controls.Add(duetItem.duetButton);
                                heigh += 20;
                            }
                            countOfSets++;
                        }
                    }
                }
            }
            ClrAndMarkerIt(currentMark);
        }

        public void drawGroupEnding()
        {
            CheckBox checkBoxOfJudge = new CheckBox();
            ControlPanel.Controls.Clear();
            tourList[currentMark.tourNumber].result_list.Clear();
            ControlPanel.Visible = true;
            buttonPanel.Visible = true;

            int height = 45;
            //int weidh = 30;

            for (int i = 0; i < this.tournir.judges.Count; i++)
            {
                //ControlPanel.Controls.Add(new Label() { Text = Convert.ToString((char)(65 + i)), Location = new Point(45 + 470 / this.tournir.judges.Count * i, 15), Font = new Font("", 12)});
                ControlPanel.Controls.Add(new Label() { Text = Convert.ToString((char)(65 + i)), Location = new Point(105 + 60 * i, 15), Size = new Size(30,25), Font = new Font("", 12) });
            }

            int j = 0;
            foreach (SetInTour setItem in tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour)
            {
                ControlPanel.Controls.Add(new Label() { Text = "Заход" + Convert.ToString(setItem.number + 1), Location = new Point(5, height), Size = new Size(100, 25), Font = new Font("", 12) });
                height += 30;

                foreach (DuetInTour duetItem in setItem.DuetListInTour)
                {
                    //ControlPanel.Controls.Add(new Label() { Text = Convert.ToString(duetItem.number + 1), Location = new Point(10, 45 + 300 / this.tournir.judges.Count * j), Font = new Font("", 12) });
                    ControlPanel.Controls.Add(new Label() { Text = "Пара" + Convert.ToString(duetItem.number + 1), Location = new Point(10, height), Size = new Size(90, 25), Font = new Font("", 12) });

                    HoldingMarker markerForCheckList = new HoldingMarker(currentMark.tourNumber, currentMark.groupNumber,
                        tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour.IndexOf(setItem),
                        tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour[tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour.IndexOf(setItem)].DuetListInTour.IndexOf(duetItem));

                    for (int i = 0; i < this.tournir.judges.Count; i++)
                    {
                        //ControlPanel.Controls.Add(checkBoxOfJudge = new CheckBox() {Location = new Point(45 + 470 / this.tournir.judges.Count * i, 45 + 300 / this.tournir.judges.Count * j), Font = new Font("", 12) });
                        //ControlPanel.Controls.Add(checkBoxOfJudge = new CheckBox() {Location = new Point(45 + 470 / this.tournir.judges.Count * i, height), Font = new Font("", 12) });
                        ControlPanel.Controls.Add(checkBoxOfJudge = new CheckBox() { Location = new Point(105 + 60 * i, height), Size = new Size(20, 20), Font = new Font("", 12) });

                        //height += 25;

                        checkBoxOfJudge.BringToFront();

                        CheckBoxForDuets checkBoxForDuet = new CheckBoxForDuets(markerForCheckList, checkBoxOfJudge);

                        tourList[currentMark.tourNumber].result_list.Add(checkBoxForDuet);
                    }

                    height += 30;

                    j++;
                }
            }
        }

        public void drawTournirEnding()
        {
            ComboBox comboBoxOfJudge = new ComboBox();
            ControlPanel.Controls.Clear();
            ControlPanel.Visible = true;
            buttonPanel.Visible = true;

            int height = 0;
            int weidh = 0;

            height += 15;
            weidh += 30;

            for (int i = 0; i < this.tournir.judges.Count; i++)
            {
                //ControlPanel.Controls.Add(new Label() { Text = Convert.ToString((char)(65 + i)), Location = new Point(45 + 470 / this.tournir.judges.Count * i, 15), Font = new Font("", 12)});
                ControlPanel.Controls.Add(new Label() { Text = Convert.ToString((char)(65 + i)), Location = new Point(105 + 80 * i, 15), Size = new Size(30, 25), Font = new Font("", 12) });
            }

            int j = 0;
            foreach (SetInTour setItem in tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour)
            {
                ControlPanel.Controls.Add(new Label() { Text = "Заход" + Convert.ToString(setItem.number + 1), Location = new Point(5, height), Size = new Size(100, 25), Font = new Font("", 12) });
                height += 30;

                foreach (DuetInTour duetItem in setItem.DuetListInTour)
                {
                    ControlPanel.Controls.Add(new Label() { Text = "Пара" + Convert.ToString(duetItem.number + 1), Location = new Point(10, height), Size = new Size(90, 25), Font = new Font("", 12) });

                    HoldingMarker markerForCheckList = new HoldingMarker(currentMark.tourNumber, currentMark.groupNumber,
                        tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour.IndexOf(setItem),
                        tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour[tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour.IndexOf(setItem)].DuetListInTour.IndexOf(duetItem));

                    for (int i = 0; i < this.tournir.judges.Count; i++)
                    {
                        ControlPanel.Controls.Add(comboBoxOfJudge = new ComboBox() { Location = new Point(105 + 80 * i, height), Size = new Size(45, 33), Font = new Font("", 12), Items = { 1, 2, 3, 4, 5} });
                        comboBoxOfJudge.BringToFront();

                        tourList[currentMark.tourNumber].resultOfTournir_list.Add( new tournirResultComboBox(markerForCheckList, comboBoxOfJudge));
                    }

                    height += 30;

                    j++;
                }
            }

            //for (int i = 0; i < this.tournir.judges.Count; i++)
            //{
            //    ControlPanel.Controls.Add(new Label() { Text = Convert.ToString((char)(65 + i)), Location = new Point(45 + 470 / this.tournir.judges.Count * i, 15), Font = new Font("", 12) });
            //}

            //int j = 0;
            //foreach (SetInTour setItem in tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour)
            //{
            //    foreach (DuetInTour duetItem in setItem.DuetListInTour)
            //    {
            //        ControlPanel.Controls.Add(new Label() { Text = Convert.ToString(duetItem.number + 1), Location = new Point(10, 45 + 300 / this.tournir.judges.Count * j), Font = new Font("", 12) });

            //        HoldingMarker markerForCheckList = new HoldingMarker(currentMark.tourNumber, currentMark.groupNumber,
            //            tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour.IndexOf(setItem),
            //            tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour[tourList[currentMark.tourNumber].groupList[currentMark.groupNumber].SetListInTour.IndexOf(setItem)].DuetListInTour.IndexOf(duetItem));

            //        for (int i = 0; i < this.tournir.judges.Count; i++)
            //        {
            //            ControlPanel.Controls.Add(comboBoxOfJudge = new ComboBox() { Location = new Point(45 + 470 / this.tournir.judges.Count * i, 45 + 300 / this.tournir.judges.Count * j), Size = new Size(45, 45), Font = new Font("", 12) });
            //            comboBoxOfJudge.BringToFront();

            //            ComboBoxForEndingTour combokBoxForDuet = new ComboBoxForEndingTour(markerForCheckList, comboBoxOfJudge);

            //            tourList[currentMark.tourNumber].resultOfTournir_list.Add(comboBoxOfJudge);
            //        }
            //        j++;
            //    }
            //}
        }

        public void drawMarking(HoldingMarker marker)
        {
            MessageBox.Show($"{marker.tourNumber}\n{tourList.Count - 1}");
            if (marker.tourNumber >= tourList.Count - 1)
                drawTournirEnding();
            else
                drawGroupEnding();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            timeOfStart = DateTime.Now;
            timelabel.Text = Convert.ToString(timeOfStart.ToShortTimeString());

            timer1.Start();

            Panel ControlPanel = new Panel();
            Button TourOneButton = new Button();

            foreach (Tour item in tourList)
                item.controlTourPanel.Controls.Clear();

            foreach (Button btn in tourButtonList)
                Controls.RemoveByKey(btn.Name);

            tourButtonList.Clear();

            RemoveEmptyGroupsFromForm();

            currentMark = new HoldingMarker(0, 0, 0, 0);

            int countOfTour = Convert.ToInt32(countOfTourTextBox.Text);


            pushStartLabel.Visible = false;

            for (int i = 0; i < countOfTour; i++)
            {
                Controls.Add(ControlPanel = new Panel() { Name = "ControlPanel" + i, Location = new Point(25, 78), Size = new Size(500, 350), BorderStyle = BorderStyle.FixedSingle, AutoScroll = true });
                Controls.Add(TourOneButton = new Button() { Name = "TourButton" + i, Location = new Point(25 + i * 500 / countOfTour, 45), Size = new Size(500 / countOfTour, 35), Text = "Тур " + (i + 1), Font = new Font("", 12), TextAlign = ContentAlignment.MiddleLeft });

                tourButtonList.Add(TourOneButton);

                tourList.Add(new Tour(i, ControlPanel, TourOneButton));
                tourList[i].tourButton.Click += TourButtonsEvent;
                drawTourInfo(tourList[i]);
            }
            tourButtonList[0].PerformClick();
        }

        private void timerTicking()
        {
            while (tournamentIsAlive)
            {
                DateTime nowDate = DateTime.Now;
                System.TimeSpan diffTime = DateTime.Now - timeOfStart;
                DateTime rel = new DateTime(diffTime.Ticks);
                MessageBox.Show(rel.Hour.ToString() + ":" + rel.Minute.ToString() + ":" + rel.Second.ToString());
                nowTimelabel.Text = rel.Hour.ToString() + ":" + rel.Minute.ToString() + ":" + rel.Second.ToString();
                Thread.Sleep(1000);
            }
        }

        private void HoldingTournament_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Enabled = true;
            tournamentIsAlive = false;
            this.Hide();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Enabled = true;
            tournamentIsAlive = false;
            this.Hide();
        }

        private void HoldingTournament_Load(object sender, EventArgs e)
        {
            tournamentNamelabel.Text = tournir.name;
            ControlPanel.Visible = false;
            buttonPanel.Visible = false;
        }

        public void TestAddingDuets(TournirClass ourTournir)
        {
            Random rnd = new Random();
            for(int j = 0; j < ourTournir.groups.Count; j++)
                foreach (SetClass item in ourTournir.groups[j].SetList)
                {
                    for (int i = 0; i < rnd.Next()%5 + 1; i++)
                    {
                        item.DuetList.Add(new Duet(i));
                    }
                }
        }

        public void GoToMarkeredButton(HoldingMarker marker)
        {
            tourList[marker.tourNumber].groupList[marker.groupNumber].groupButton.BackColor = Color.Turquoise;
            tourList[marker.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].setButton.BackColor = Color.Turquoise;
            tourList[marker.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].DuetListInTour[marker.duetNumber].duetButton.BackColor = Color.Turquoise;
        }
        
        public void ClrMarkerButton(HoldingMarker marker)
        {
            foreach (GroupInTour groupN in tourList[marker.tourNumber].groupList)
            {
                groupN.groupButton.BackColor = Color.Empty; ;
                foreach (SetInTour setN in groupN.SetListInTour)
                {
                    setN.setButton.BackColor = Color.Empty;
                    foreach (DuetInTour duetN in setN.DuetListInTour)
                    {
                        duetN.duetButton.BackColor = Color.Empty;
                    }
                }
            }
        }

        public void ClrAndMarkerIt(HoldingMarker marker)
        {
            ClrMarkerButton(marker);
            GoToMarkeredButton(marker);
        }

        public void RemoveEmptyGroupsFromForm()
        {
            foreach (Tour tour in tourList)
                foreach (GroupInTour group in tour.groupList)
                {
                    if (group.SetListInTour.Count == 0)
                        tour.groupList.Remove(group);
                }
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            //currentMark = new HoldingMarker(currentMark.groupNumber - 1, currentMark.setNumber - 1, currentMark.duetNumber - 1);
            decrementMarker(currentMark);
            ClrAndMarkerIt(currentMark);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
             //currentMark = new HoldingMarker(currentMark.groupNumber + 1, currentMark.setNumber + 1, currentMark.duetNumber + 1);
            incrementMarker(currentMark);
            ClrAndMarkerIt(currentMark);
        }

        public void incrementMarker(HoldingMarker marker)
        {
            if (marker.duetNumber >= tourList[marker.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].DuetListInTour.Count - 1)
            {
                if (marker.setNumber >= tourList[marker.tourNumber].groupList[marker.groupNumber].SetListInTour.Count - 1)
                {
                    if (marker.groupNumber >= tourList[marker.tourNumber].groupList.Count - 1)
                    {
                        DialogResult result = MessageBox.Show("Кажется, это крайняя группа в этом туре!\n Перейти на следующий тур?", "Системное сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            if (marker.tourNumber >= tourList.Count - 1)
                            {
                                //tourList[currentMark.tourNumber].takeNextTournir(tourList, currentMark.tourNumber);
                                //ClrMarkerButton(marker);
                                //tourButtonList[marker.tourNumber].PerformClick();
                                result = MessageBox.Show("Вы завершили последний тур!\nЗавершить турнир?", "Системное сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                                if (result == DialogResult.Yes)
                                    //drawTournirEnding();
                                    drawMarking(marker);
                                //drawGroupEnding();
                            }
                            else
                            {
                                //marker.tourNumber++;
                                //marker.groupNumber = 0;
                                //marker.setNumber = 0;
                                //marker.duetNumber = 0;
                                //ClrAndMarkerIt(marker);
                                //drawGroupEnding();
                                drawMarking(marker);
                            }
                        }
                    }
                    else
                    {
                        drawMarking(marker);
                    }
                }
                else
                {
                    marker.duetNumber = 0;
                    marker.setNumber += 1;
                }
            }
            else
            {
                marker.duetNumber += 1;
            }
        }

        public void decrementMarker(HoldingMarker marker)
        {
            if (marker.duetNumber == 0)
            {
                if (marker.setNumber == 0)
                {
                    if (marker.groupNumber == 0)
                    {
                        MessageBox.Show("Кажется, более ранних групп не существует");
                    }
                    else
                    {
                        marker.groupNumber -= 1;
                        marker.setNumber = tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour.Count - 1;
                        marker.duetNumber = tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].DuetListInTour.Count - 1;
                    }
                }
                else
                {
                    marker.setNumber -= 1;
                    marker.duetNumber = tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].DuetListInTour.Count - 1;
                }
            }
            else
            {
                marker.duetNumber -= 1;
            }
        }

        private void nextTournirButton_Click(object sender, EventArgs e)
        {
            drawGroupEnding();
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            if (currentMark.tourNumber < tourList.Count - 1)
            {
                tourList[currentMark.tourNumber].changeNextTour(tourList, currentMark.groupNumber, tournir.judges.Count);

                ClrMarkerButton(currentMark);
                if (currentMark.groupNumber < tourList[currentMark.tourNumber].groupList.Count - 1)
                {
                    currentMark.groupNumber++;
                    currentMark.setNumber = 0;
                    currentMark.duetNumber = 0;
                    ClrAndMarkerIt(currentMark);
                }
                else
                {
                    if (currentMark.tourNumber < tourList.Count)
                    {
                        currentMark.tourNumber++;
                        currentMark.groupNumber = 0;
                        currentMark.setNumber = 0;
                        currentMark.duetNumber = 0;

                        tourList[currentMark.tourNumber].removeEmptySets();
                        tourList[currentMark.tourNumber].controlTourPanel.Controls.Clear();
                        drawTourInfo2(tourList[currentMark.tourNumber]);

                        tourButtonList[currentMark.tourNumber].PerformClick();
                    }
                    else
                    {
                        //MessageBox.Show("это группа последнего тура!");
                        //tourList[currentMark.tourNumber].takeTournirResults(currentMark.groupNumber, tournir.judges.Count);

                    }
                }
            }
            else
            {
                //pass
                MessageBox.Show("это группа последнего тура!");
                tourList[currentMark.tourNumber].takeTournirResults(currentMark.groupNumber, tournir.judges.Count);

            }
            ControlPanel.Visible = false;
            buttonPanel.Visible = false;
        }

        private void backPanelButton_Click(object sender, EventArgs e)
        {
            ControlPanel.Controls.Clear();
            ControlPanel.Visible = false;
            buttonPanel.Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan tempSpan = DateTime.Now - timeOfStart;
            diffDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, tempSpan.Hours, tempSpan.Minutes, tempSpan.Seconds);

            //diffDate.Hour = tempSpan.Hours;
            //diffDate.Minute = tempSpan.Minutes;
            //diffDate.Second = tempSpan.Seconds;

            nowTimelabel.Text = diffDate.ToLongTimeString(); ;
        }
    }
}

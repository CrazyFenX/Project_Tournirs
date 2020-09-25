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

        bool tournamentIsAlive;

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
            currentTour = tourButtonList.IndexOf(btn) + 1;

            //MessageBox.Show("Выбран тур" + (currentTour).ToString());

            for (int i = 0; i < tourList.Count; i++)
            {
                if (i == currentTour - 1)
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

        public void drowTourInfo(Tour tourNew)
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
                            tourNew.controlTourPanel.Controls.Add(buttonSetNew = new Button() { Name = "setButton" + (setItem.number), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(25, heigh), Size = new Size(500, 30), Text = "Заход номер " + setItem.number });
                            heigh += 30;

                            groupInTourNew.SetListInTour.Add(new SetInTour(countOfSets, buttonSetNew));
                            //int countOfDuets = 0;

                            foreach (Duet duetItem in setItem.DuetList)
                            {
                                heigh += 5;
                                tourNew.controlTourPanel.Controls.Add(buttonDuetNew = new Button() { Name = "duetButton" + (duetItem.number), TextAlign = ContentAlignment.MiddleLeft, Location = new Point(40, heigh), Size = new Size(460, 20), Text = "Пара номер " + duetItem.number + 1 });
                                heigh += 20;

                                groupInTourNew.SetListInTour[countOfSets].DuetListInTour.Add(buttonDuetNew);
                            }
                            countOfSets++;
                        }
                    }

                    tourNew.groupList.Add(groupInTourNew); ///////ЧАСТНЫЙ СЛУЧАЙ
                }
            }
            ClrAndMarkerIt(currentMark);
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            TourOneButton.Visible = false;
            ControlPanel.Visible = false;
            foreach (Tour item in tourList)
                item.controlTourPanel.Controls.Clear();

            foreach (Button btn in tourButtonList)
                Controls.RemoveByKey(btn.Name);

            RemoveEmptyGroupsFromForm();

            currentMark = new HoldingMarker(0, 0, 0, 0);

            int countOfTour = Convert.ToInt32(countOfTourTextBox.Text);

            currentTour = 1;

            threadForTimer = new Thread(new ThreadStart(timerTicking));
            threadForTimer.Start();

            timeOfStart = DateTime.Now;
            timelabel.Text = Convert.ToString(timeOfStart.ToShortTimeString());

            for (int i = 0; i < countOfTour; i++)
            {
                Controls.Add(ControlPanel = new Panel() { Name = "ControlPanel" + i, Location = new Point(25, 78), Size = new Size(500, 350), BorderStyle = BorderStyle.FixedSingle, AutoScroll = true });
                Controls.Add(TourOneButton = new Button() { Name = "TourButton" + i, Location = new Point(25 + i * 500 / countOfTour, 45), Size = new Size(500 / countOfTour, 35), Text = "Тур " + (i + 1), Font = new Font("", 12), TextAlign = ContentAlignment.MiddleLeft });

                tourButtonList.Add(TourOneButton);

                tourList.Add(new Tour(i, ControlPanel, TourOneButton));
                tourList[i].tourButton.Click += TourButtonsEvent;
                drowTourInfo(tourList[i]);
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
            tourList[currentMark.tourNumber].groupList[marker.groupNumber].groupButton.BackColor = Color.Turquoise;
            tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].setButton.BackColor = Color.Turquoise;
            tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].DuetListInTour[marker.duetNumber].BackColor = Color.Turquoise;
        }
        
        public void ClrMarkerButton(HoldingMarker marker)
        {
            foreach (GroupInTour groupN in tourList[marker.tourNumber].groupList)
            {
                groupN.groupButton.BackColor = Color.Empty; ;
                foreach (SetInTour setN in groupN.SetListInTour)
                {
                    setN.setButton.BackColor = Color.Empty;
                    foreach (Button duetN in setN.DuetListInTour)
                    {
                        duetN.BackColor = Color.Empty;
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
            if (marker.duetNumber >= tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour[marker.setNumber].DuetListInTour.Count - 1)
            {
                if (marker.setNumber >= tourList[currentMark.tourNumber].groupList[marker.groupNumber].SetListInTour.Count - 1)
                {
                    if (marker.groupNumber >= tourList[currentMark.tourNumber].groupList.Count - 1)
                    {
                        DialogResult result = MessageBox.Show("Кажется, это крайняя группа в этом туре!\n Перейти на следующий тур?", "Системное сообщение", MessageBoxButtons.YesNo,MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            if (marker.tourNumber < tourList.Count - 1)
                            {
                                ClrMarkerButton(marker);
                                marker.tourNumber++;
                                marker.groupNumber = 0;
                                marker.setNumber = 0;
                                marker.duetNumber = 0;
                                tourButtonList[marker.tourNumber].PerformClick();
                            }
                            else
                                MessageBox.Show("Вы завершили последний тур!\nЗавершить турнир?", "Системное сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
                        }
                    }
                    else
                    {
                        marker.duetNumber = 0;
                        marker.setNumber = 0;
                        marker.groupNumber += 1;
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
    }
}

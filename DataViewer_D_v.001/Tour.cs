using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class Tour
    {
        public int number;
        public List<GroupInTour> groupList = new List<GroupInTour>();

        public Panel controlTourPanel;
        public Button tourButton;

        public List<CheckBoxForDuets> result_list;

        public List<ComboBox> resultOfTournir_list;

        public Tour(int Num)
        {
            this.number = Num;
            this.groupList = new List<GroupInTour>();
            this.result_list = new List<CheckBoxForDuets>();
            this.resultOfTournir_list = new List<ComboBox>();
        }

        public Tour(int Num, Panel TourPanel, Button TourButton)
        {
            this.number = Num;
            this.groupList = new List<GroupInTour>();
            this.controlTourPanel = TourPanel;
            this.tourButton = TourButton;
            this.result_list = new List<CheckBoxForDuets>();
            this.resultOfTournir_list = new List<ComboBox>();
        }

        public Tour()
        {
            this.groupList = new List<GroupInTour>();
            this.result_list = new List<CheckBoxForDuets>();
            this.resultOfTournir_list = new List<ComboBox>();
        }

        public void changeNextTour(List<Tour> tempTourList, int groupNum, int judgeCount)
        {
            MessageBox.Show($"рассматривается группа {groupNum}"); // TEESSSTTT

            if (this.result_list.Count > 0 && tempTourList.Count - 1 > tempTourList.IndexOf(this) && judgeCount > 0)
            {
                MessageBox.Show(judgeCount.ToString());

                List<SetInTour> retSetList = new List<SetInTour>();

                for (int h = 0; h < this.groupList[groupNum].SetListInTour.Count; h++)
                {
                    retSetList.Add(new SetInTour(this.groupList[groupNum].SetListInTour[h].number, this.groupList[groupNum].SetListInTour[h].setButton));
                    retSetList[retSetList.Count - 1].DuetListInTour = new List<DuetInTour>();
                }
                MessageBox.Show($"Создан лист длины {this.groupList[groupNum].SetListInTour.Count}");

                foreach (CheckBoxForDuets item in this.result_list)
                {
                    if (item.validnessCheckBox.Checked && !this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber].passToNextTour)
                    {
                        retSetList[item.marker.setNumber].DuetListInTour.Add(this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber]);
                        this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber].passToNextTour = true;
                    }
                }

                tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].SetListInTour = retSetList;

                string contrStr = "";//TESTTTT
                contrStr += $"Группа {groupNum + 1}\n";
                foreach (SetInTour setItem in this.groupList[groupNum].SetListInTour)
                {
                    contrStr += $"Заход {setItem.number + 1}\n";
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                    {
                        if (duetItem.passToNextTour)
                        {
                            contrStr += $"Пара {duetItem.number + 1}\n";
                        }
                    }
                }
                MessageBox.Show("Предполагалось\n" + contrStr);       //TESTTTT

                contrStr = "";                                      //TESTTTT
                contrStr += $"Группа {groupNum + 1}\n";
                foreach (SetInTour setItem in tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].SetListInTour)
                {
                    contrStr += $"Заход {setItem.number + 1}\n";
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                    {
                        contrStr += $"Пара {duetItem.number + 1}\n";
                    }
                }
                MessageBox.Show("По факту\n" + contrStr);

                tempTourList[tempTourList.IndexOf(this) + 1].removeEmpty();

                contrStr = "";       //TESTTTT
                contrStr += $"Группа {groupNum + 1}\n";
                foreach (SetInTour setItem in tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].SetListInTour)
                {
                    contrStr += $"Заход {setItem.number + 1}\n";
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                    {
                        contrStr += $"Пара {duetItem.number + 1}\n";
                    }
                }
                MessageBox.Show("После удаления пустых заходов\n" + contrStr);

            }
            else
                MessageBox.Show("Список оценок пуст, не зарегистрировано ниодного судьи или перед вами последний тур!");
        }

        public void removeEmpty()
        {
            for (int i = 0; i < groupList.Count; i++)
            {
                if (groupList[i].SetListInTour.Count == 0)
                {
                    groupList.Remove(groupList[i]);
                }
                else
                {
                    for (int j = 0; j < groupList[i].SetListInTour.Count; j++)
                    {
                        if (groupList[i].SetListInTour[j].DuetListInTour.Count == 0)
                        {
                            MessageBox.Show("Удален заход номер " + (groupList[i].SetListInTour[j].number + 1).ToString());
                            groupList[i].SetListInTour.Remove(groupList[i].SetListInTour[j]);
                            j--;
                        }
                    }
                }
            }
        }
    }
}

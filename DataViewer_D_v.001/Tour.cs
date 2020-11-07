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
        public int countOfParticipants;

        public List<DuetInTour> mainDuetList = new List<DuetInTour>();

        public Panel controlTourPanel;
        public Button tourButton;

        public List<CheckBoxForDuets> result_list;

        public List<tournirResultComboBox> resultOfTournir_list;

        public Tour(int Num)
        {
            this.number = Num;
            this.groupList = new List<GroupInTour>();
            this.result_list = new List<CheckBoxForDuets>();
            this.resultOfTournir_list = new List<tournirResultComboBox>();
            this.countOfParticipants = 0;
        }

        public Tour(int Num, Panel TourPanel, Button TourButton)
        {
            this.number = Num;
            this.groupList = new List<GroupInTour>();
            this.controlTourPanel = TourPanel;
            this.tourButton = TourButton;
            this.result_list = new List<CheckBoxForDuets>();
            this.resultOfTournir_list = new List<tournirResultComboBox>();
            this.countOfParticipants = 0;
        }

        public Tour()
        {
            this.groupList = new List<GroupInTour>();
            this.result_list = new List<CheckBoxForDuets>();
            this.resultOfTournir_list = new List<tournirResultComboBox>();
            this.countOfParticipants = 0;
        }

        private void getCountOfParticipants()
        {
            this.countOfParticipants = 0;
            foreach (GroupInTour groupItem in this.groupList)
                foreach (SetInTour setItem in groupItem.SetListInTour)
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                        countOfParticipants++;
        }

        public void changeNextTour(List<Tour> tempTourList, int groupNum, int judgeCount)
        {
            MessageBox.Show($"рассматривается группа {groupNum + 1}"); // TEESSSTTT

            if (this.result_list.Count > 0 && tempTourList.Count - 1 > tempTourList.IndexOf(this) && judgeCount > 0)
            {
                //MessageBox.Show(judgeCount.ToString());

                List<SetInTour> retSetList = new List<SetInTour>();
                List<SetInTour> retSetCommunalList = new List<SetInTour>();

                for (int h = 0; h < this.groupList[groupNum].SetListInTour.Count; h++)
                {
                    retSetList.Add(new SetInTour(this.groupList[groupNum].SetListInTour[h].number, this.groupList[groupNum].SetListInTour[h].setButton));
                    retSetList[retSetList.Count - 1].DuetListInTour = new List<DuetInTour>();
                }
                //MessageBox.Show($"Создан лист длины {this.groupList[groupNum].SetListInTour.Count}");

                foreach (CheckBoxForDuets item in this.result_list)
                {
                    if (item.validnessCheckBox.Checked && !this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber].passToNextTour)
                    {
                        retSetList[item.marker.setNumber].DuetListInTour.Add(this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber]);
                        //retSetCommunalList[item.marker.setNumber].DuetListInTour.Add(this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber]);
                        this.groupList[item.marker.groupNumber].SetListInTour[item.marker.setNumber].DuetListInTour[item.marker.duetNumber].passToNextTour = true;
                    }
                }

                tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].SetListInTour = retSetList;
                tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].takeDuetInGroupList();
                
                if (this.countOfParticipants == 0)
                    this.getCountOfParticipants();
                if (this.groupList[groupNum].countOfParticipants == 0)
                    this.groupList[groupNum].takeCountOfParticipants();

                //MessageBox.Show("Участников в туре " + this.countOfParticipants.ToString());
                //MessageBox.Show("Участников в группе " + this.groupList[groupNum].countOfParticipants.ToString());

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
                        else
                        {
                            duetItem.positionInTour = (uint)this.countOfParticipants;
                            duetItem.positionInGroup = (uint)this.groupList[groupNum].countOfParticipants;
                        MessageBox.Show(duetItem.ToString());
                            this.countOfParticipants--;
                            this.groupList[groupNum].countOfParticipants--;
                        }
                    }
                }
                //MessageBox.Show("Предполагалось\n" + contrStr);       //TESTTTT

                contrStr = "";                                      //TESTTTT
                contrStr += $"Группа {groupNum + 1}\n";
                foreach (SetInTour setItem in tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].SetListInTour)
                {
                    contrStr += $"Заход {setItem.number + 1}\n";
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                    {
                        contrStr += $"Пара {duetItem.number + 1}\n";
                        contrStr += $"{duetItem.passToNextTour}\n";
                    }
                }

                MessageBox.Show("По факту\n" + contrStr);

                tempTourList[tempTourList.IndexOf(this) + 1].removeEmptySets();

                contrStr = "";       //TESTTTT
                contrStr += $"Группа {groupNum + 1}\n";
                foreach (SetInTour setItem in tempTourList[tempTourList.IndexOf(this) + 1].groupList[groupNum].SetListInTour)
                {
                    contrStr += $"Заход {setItem.number + 1}\n";
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                    {
                        contrStr += $"Пара {duetItem.number + 1}\n";
                        duetItem.passToNextTour = false;

                        contrStr += $"{duetItem.passToNextTour}\n";
                    }
                }
                MessageBox.Show("После удаления пустых заходов\n" + contrStr);

            }
            else
                MessageBox.Show("Список оценок пуст, не зарегистрировано ниодного судьи или перед вами последний тур!");
        }

        public void takeGroupResults(int groupNum, int judgeCount)
        {
            MessageBox.Show($"рассматривается группа {groupNum + 1}"); // TEESSSTTT

            if (this.resultOfTournir_list.Count > 0 && judgeCount > 0)
            {
                int i = 1;
                //int startPos = 0;
                //for (int g = 0; g < groupNum; g++)
                //{
                //    foreach (DuetInTour duetItem in this.groupList[g].DuetInGroupList)
                //    {
                //        startPos++;
                //    }
                //}
                //MessageBox.Show(startPos.ToString());

                //for (int j = startPos; j < this.resultOfTournir_list.Count; j++)
                //{
                //    this.groupList[groupNum].SetListInTour[this.resultOfTournir_list[j].marker.setNumber].DuetListInTour[this.resultOfTournir_list[j].marker.duetNumber].mark += this.resultOfTournir_list[j].valueComboBox.SelectedIndex + 1;
                //    //MessageBox.Show($"рассматривается пара " + comboBoxItem.marker.ToString()); // TEESSSTTT

                //    if (i > 0 && i % judgeCount == 0)
                //    {
                //        MessageBox.Show($"рассматривается пара " + this.resultOfTournir_list[j].marker.ToString());
                //        //MessageBox.Show($"{i}");
                //        this.groupList[groupNum].SetListInTour[this.resultOfTournir_list[j].marker.setNumber].DuetListInTour[this.resultOfTournir_list[j].marker.duetNumber].mark /= judgeCount;
                //        MessageBox.Show($"оценка {this.groupList[groupNum].SetListInTour[this.resultOfTournir_list[j].marker.setNumber].DuetListInTour[this.resultOfTournir_list[j].marker.duetNumber].mark}"); // TEESSSTTT
                //    }
                //    i++;
                //}

                //foreach (tournirResultComboBox comboBoxItem in this.resultOfTournir_list)
                foreach (tournirResultComboBox comboBoxItem in this.groupList[groupNum].resultOfGroup_list)
                {
                    this.groupList[groupNum].SetListInTour[comboBoxItem.marker.setNumber].DuetListInTour[comboBoxItem.marker.duetNumber].mark += comboBoxItem.valueComboBox.SelectedIndex + 1;
                    //MessageBox.Show($"рассматривается пара " + comboBoxItem.marker.ToString()); // TEESSSTTT

                    if (i > 0 && i % judgeCount == 0)
                    {
                        MessageBox.Show($"рассматривается пара " + comboBoxItem.marker.ToString());
                        //MessageBox.Show($"{i}");
                        this.groupList[groupNum].SetListInTour[comboBoxItem.marker.setNumber].DuetListInTour[comboBoxItem.marker.duetNumber].mark /= judgeCount;
                        MessageBox.Show($"оценка {this.groupList[groupNum].SetListInTour[comboBoxItem.marker.setNumber].DuetListInTour[comboBoxItem.marker.duetNumber].mark}"); // TEESSSTTT
                    }
                    i++;
                }
            }
            this.takeMainDuetList();
        }

        public void takePositions(int countPos, int groupNum)
        {
            //foreach (GroupInTour groupItem in this.groupList)
            //{
            List<DuetInTour> tempPartisipantList = new List<DuetInTour>();
            List<DuetInTour> tempToTempPartisipantList = new List<DuetInTour>(); //Test

            foreach (SetInTour setItem in this.groupList[groupNum].SetListInTour)
            {
                foreach (DuetInTour duetItem in setItem.DuetListInTour)
                {
                    tempPartisipantList.Add(duetItem);
                }
            }

            duetInTourComparer comparer = new duetInTourComparer();

            showDITList(tempPartisipantList);
            //sortController.QuickSort(tempPartisipantList);
            tempPartisipantList.Sort(comparer);
            showDITList(tempPartisipantList);

            foreach (DuetInTour duetItem in tempPartisipantList)
            {
                duetItem.positionInGroup = (uint)(tempPartisipantList.IndexOf(duetItem) + 1);
            }

            foreach (SetInTour setItem in this.groupList[groupNum].SetListInTour) //Test
            {
                foreach (DuetInTour duetItem in setItem.DuetListInTour)//Test
                {
                    tempToTempPartisipantList.Add(duetItem);//Test
                }
            }

            showDITList(tempToTempPartisipantList);//Test
            //}
            this.showAllParticipants();
        }

        public void showAllParticipants()
        {
            string retStr = "";
            foreach (GroupInTour groupItem in this.groupList)
            {
                foreach (SetInTour setItem in groupItem.SetListInTour)
                {
                    foreach (DuetInTour duetItem in setItem.DuetListInTour)
                    {
                        retStr += duetItem.ToString() + "\n";
                    }
                }

            }
        }

        private static void showDITList(List<DuetInTour> DITList)
        {
            string retStr = "";
            foreach (DuetInTour duetItem in DITList)
            {
                retStr += duetItem.ToString() + "\n";
            }
            MessageBox.Show(retStr);
        }

        public void removeEmptySets()
        {
            for (int i = 0; i < groupList.Count; i++)
                for (int j = 0; j < groupList[i].SetListInTour.Count; j++)
                    if (groupList[i].SetListInTour[j].DuetListInTour.Count == 0)
                    {
                        MessageBox.Show("Удален заход номер " + (groupList[i].SetListInTour[j].number + 1).ToString());
                        groupList[i].SetListInTour.Remove(groupList[i].SetListInTour[j]);
                        j--;
                    }
        }


        public void takeMainDuetList()
        {
            string retstr = "";
            mainDuetList.Clear();
            foreach (GroupInTour groupItem in this.groupList)
            {
                groupItem.takeDuetInGroupList();
                foreach (DuetInTour duetItem in groupItem.DuetInGroupList)
                {
                    mainDuetList.Add(duetItem);
                    retstr += duetItem.ToString() + "\n";
                }
                retstr += "\n";
            }
            MessageBox.Show(retstr);
        }

        public void takeGroupDIGList()
        {
            foreach (GroupInTour groupItem in this.groupList)
            {
                groupItem.takeDuetInGroupList();
            }
        }
    }
}
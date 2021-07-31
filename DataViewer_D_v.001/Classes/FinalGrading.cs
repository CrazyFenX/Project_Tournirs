using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataViewer_D_v._001.Classes;
using System.Windows.Forms;
using System.Collections;

namespace DataViewer_D_v._001.Classes
{
    public class FinalGrading
    {
        static int numOfColumnDyn = 0;
        public static List<Duet> sortingDuetsInFinalTour(List<Duet> inputDuetList, int danceCount)
        {
            List<Duet> outputDuetList = new List<Duet>(inputDuetList);
            List<List<int[]>> summirizeMarks = new List<List<int[]>>();
            List<List<int[]>> summirizeSumPosMarks = new List<List<int[]>>();
            List<int> duetNumbers = new List<int>();
            List<DuetInFinal> duetInFinalList = new List<DuetInFinal>();

            for (int i = 0; i < inputDuetList.Count; i++)
            {
                for (int danceNumber = 0; danceNumber < danceCount; danceNumber++)
                {
                summirizeMarks.Add(new List<int[]>());
                summirizeSumPosMarks.Add(new List<int[]>());

                    duetNumbers.Add(inputDuetList[i].number);
                    //Подсчет различных оценок (summirize)
                    summirizeMarks[i].Add(new int[inputDuetList.Count]);
                    summirizeSumPosMarks[i].Add(new int[inputDuetList.Count]);
                    //Подсчет 1
                    summirizeMarks[i][danceNumber][0] = 0;

                    for (int g = 0; g < inputDuetList[i].judgeMarkScatingFinalList[danceNumber].Count; g++)
                    {
                        if (1 == inputDuetList[i].judgeMarkScatingFinalList[danceNumber][g])
                            summirizeMarks[i][danceNumber][0]++;
                    }
                    summirizeSumPosMarks[i][danceNumber][0] = summirizeMarks[i][danceNumber][0];

                    //Подсчет остальных оценок (summirize)
                    for (int j = 1; j < inputDuetList.Count; j++)
                    {
                        int tmpCount = 0;
                        int tmpSum = 0;
                        summirizeMarks[i][danceNumber][j] = 0;
                        summirizeSumPosMarks[i][danceNumber][j] = 0;
                        for (int g = 0; g < inputDuetList[i].judgeMarkScatingFinalList[danceNumber].Count; g++)
                        {
                            if ((j + 1) == inputDuetList[i].judgeMarkScatingFinalList[danceNumber][g])
                            {
                                tmpCount++;
                                tmpSum += j + 1;
                            }
                        }
                        summirizeMarks[i][danceNumber][j] = summirizeMarks[i][danceNumber][j - 1] + tmpCount;
                        summirizeSumPosMarks[i][danceNumber][j] = summirizeSumPosMarks[i][danceNumber][j - 1] + tmpSum;
                    }

                }
            }
            //List<DuetInFinal> duetInFinalList = new List<DuetInFinal>();
            for (int i = 0; i < inputDuetList.Count; i++)
            {
                duetInFinalList.Add(new DuetInFinal(summirizeMarks[i], summirizeSumPosMarks[i], inputDuetList[i].number, i));
                for (int j = 0; j < danceCount; j++)
                    duetInFinalList[i].positions.Add(-1);
            }

            string retStr = "";
            List<DuetInFinal> tmpList = new List<DuetInFinal>();
            //tmpList.AddRange(duetInFinalList);
            for (int danceNumber = 0; danceNumber < danceCount; danceNumber++)
            {
                retStr = "";
                numOfColumnDyn = 0;
                tmpList = new List<DuetInFinal>();
                //MessageBox.Show("Оценка танца " + danceNumber.ToString());
                combSort(ref duetInFinalList, ref tmpList, 0, duetInFinalList.Count, danceNumber);
                duetInFinalList.Clear();
                duetInFinalList.AddRange(tmpList);
                foreach (DuetInFinal item in tmpList)
                    retStr += item.ToString() + "\n";
                MessageBox.Show("Успешно промежуточно отсортировано! танец (" + danceNumber + ")\n" + retStr);
            }
            retStr = "";
            foreach (DuetInFinal item in tmpList)
            {
                int tmpInt = 0;
                for (int g = 0; g < danceCount; g++)
                    tmpInt += item.positions[g];
                item.summirizeSumPosListFinal = tmpInt;
                retStr += item.ToString() + "\n";
            }
                MessageBox.Show("Успешно отсортировано!\n" + retStr);


            for (int i = 0; i < tmpList.Count; i++)
            {
                tmpList[i].summirizePosListFinal = new List<int>();
                tmpList[i].summirizePosListFinal_Third = new List<int>();

                tmpList[i].summirizePosListFinal.Add(0);
                tmpList[i].summirizePosListFinal_Third.Add(0);
                for (int g = 0; g < tmpList[i].positions.Count; g++)
                {
                    if (1 == tmpList[i].positions[g])
                        tmpList[i].summirizePosListFinal[0]++;
                }
                tmpList[i].summirizePosListFinal_Third[0] = tmpList[i].summirizePosListFinal[0];
                for (int j = 1; j < tmpList.Count; j++)
                {
                    int tmpCount = 0;
                    int tmpSum = 0;
                    tmpList[i].summirizePosListFinal.Add(0);
                    tmpList[i].summirizePosListFinal_Third.Add(0);
                    for (int g = 0; g < tmpList[i].positions.Count; g++)
                    {
                        if ((j + 1) == tmpList[i].positions[g])
                        {
                            tmpCount++;
                            tmpSum += j + 1;
                        }
                    }
                    tmpList[i].summirizePosListFinal[j] =  tmpCount;
                    tmpList[i].summirizePosListFinal_Third[j] = tmpList[i].summirizePosListFinal_Third[j - 1] + tmpCount;
                }
            }

            retStr = "";
            numOfColumnDyn = 0;
            duetInFinalList.Clear();
            duetInFinalList.AddRange(tmpList);
            tmpList = new List<DuetInFinal>();
            MessageBox.Show("Оценка финала");
            combSortfinalGrading(ref duetInFinalList, ref tmpList, 0, duetInFinalList.Count, danceCount);
            //ФИНАЛЬНАЯ СОРТИРОВКА

            outputDuetList = new List<Duet>();
            foreach (DuetInFinal item in tmpList)
            {
                outputDuetList.Add(inputDuetList[item.numberInGroup]);
                outputDuetList[tmpList.IndexOf(item)].skatingPosition = item.finslPosition;
                outputDuetList[tmpList.IndexOf(item)].markSum = item.summirizeSumPosListFinal;
            }

            foreach (DuetInFinal item in tmpList)
                retStr += item.ToString() + "\n";
            MessageBox.Show("Успешно ФИНАЛЬНО отсортировано! \n" + retStr);

            return outputDuetList;
        }

        //public static List<int[]> combSort(List<int[]> summirizeInput, int numOfColumn, List<int> duetNumbers)//int[] input)
        //public static List<int> combSort(ref List<int[]> summirizeInput, ref List<int[]> summirizeSumsInput, ref List<int> duetNumbers, int numOfColumn)//int[] input)
        //public static List<DuetInFinal> combSort(ref List<DuetInFinal> duetInFinalList, int numOfColumn, int countOfParticipants)//int[] input)
        //{
        //numOfColumnDyn = numOfColumn;
        //if (duetInFinalList.Count <= 1 || numOfColumn + 1 == duetInFinalList.Count)

        //1.Сортируем
        //    for (int numOfCol = 0; numOfCol < duetInFinalList.Count; numOfCol++)
        //    {
        //        string retStr = "numOfColumn: " + numOfCol.ToString();
        //        for (int i = numOfCol; i < duetInFinalList.Count - 1; i++)
        //        {
        //            for (int j = i + 1; j < duetInFinalList.Count; j++)
        //            {
        //                for (int g = numOfCol; g < duetInFinalList.Count; g++)
        //                    if (duetInFinalList[i].summirizePosList[g] < duetInFinalList[j].summirizePosList[g])
        //                    {
        //                        MessageBox.Show("Swapping!\nCause: " + duetInFinalList[i].summirizePosList[g].ToString() + " < " + duetInFinalList[j].summirizePosList[g].ToString());

        //                        DuetInFinal swap = duetInFinalList[i];
        //                        duetInFinalList[i] = duetInFinalList[j];
        //                        duetInFinalList[j] = swap;
        //                        break;
        //                    }
        //                    //else if (duetInFinalList[i].summirizePosList[g] == duetInFinalList[j].summirizePosList[g] && duetInFinalList[j].summirizePosList[g] != 0 && numOfColumn != 0)
        //                    else if (duetInFinalList[i].summirizePosList[g] == duetInFinalList[j].summirizePosList[g] && duetInFinalList[j].summirizePosList[g] != 0 && numOfCol != 0)
        //                    {
        //                        MessageBox.Show("Comparing Sums: " + duetInFinalList[i].summirizePosList[g].ToString() + " with " + duetInFinalList[j].summirizePosList[g].ToString() + " from " + i.ToString() + " and " + j.ToString());
        //                        if (duetInFinalList[i].summirizeSumPosList[g] > duetInFinalList[j].summirizeSumPosList[g])
        //                        {
        //                            MessageBox.Show("Swapping Sums!\nCause: " + duetInFinalList[i].summirizeSumPosList[g].ToString() + " > " + duetInFinalList[j].summirizeSumPosList[g].ToString());
        //                            DuetInFinal swap = duetInFinalList[i];
        //                            duetInFinalList[i] = duetInFinalList[j];
        //                            duetInFinalList[j] = swap;
        //                            numOfCol++;
        //                            break;
        //                        }
        //                        else if (duetInFinalList[i].summirizeSumPosList[g] < duetInFinalList[j].summirizeSumPosList[g])
        //                        {
        //                            numOfCol++;
        //                            break;
        //                        }
        //                        }
        //                    else break;
        //                string retStrList = "";
        //                for (int h = 0; h < duetInFinalList.Count; h++)
        //                {
        //                    retStrList += duetInFinalList[h].ToString() + "\n";
        //                }
        //                MessageBox.Show(i.ToString() + " Step sorting: (" + numOfCol + "):\n" + retStrList);
        //            }
        //        }
        //    }
        //    string retStrList1 = "";
        //    for (int i = 0; i < duetInFinalList.Count; i++)
        //    {
        //        retStrList1 += duetInFinalList[i].ToString() + "\n";
        //    }
        //    MessageBox.Show(retStrList1);

        //    return (duetInFinalList);
        //}

        public static List<DuetInFinal> combSort(ref List<DuetInFinal> duetInFinalList, ref List<DuetInFinal> outPutFinalList, int numOfColumn, int countOfParticipants, int danceNumber)//int[] input)
        {
            string retStr = "numOfColumn: " + numOfColumn.ToString();
            //numOfColumnDyn = numOfColumn;
            //if (duetInFinalList.Count <= 1 || numOfColumn + 1 == duetInFinalList.Count)
            if (duetInFinalList.Count <= 1 || numOfColumn >= countOfParticipants + 1)
            {
                string retStrList = "";
                for (int i = 0; i < duetInFinalList.Count; i++)
                {
                    duetInFinalList[i].positions[danceNumber] = numOfColumnDyn + 1;
                    retStrList += duetInFinalList[i].ToString() + "\n";
                }
                numOfColumnDyn += duetInFinalList.Count;
                //MessageBox.Show("numOfColumnDyn: " + numOfColumnDyn.ToString() + "Returning(" + numOfColumn + "):\n" + retStrList);
                outPutFinalList.AddRange(duetInFinalList);
                return (duetInFinalList);
            }
            //1.Сортируем
            //if (numOfColumnDyn < countOfParticipants && numOfColumn < countOfParticipants)
            //{
            //try
            //{
                for (int i = 0; i < duetInFinalList.Count - 1; i++)
                {
                    for (int j = i + 1; j < duetInFinalList.Count; j++)
                    {
                        for (int g = numOfColumn; g < duetInFinalList.Count; g++)
                        {
                            if (duetInFinalList[i].summirizePosList[danceNumber][g] < duetInFinalList[j].summirizePosList[danceNumber][g])
                            {
                                //MessageBox.Show("Swapping!\nCause: " + duetInFinalList[i].summirizePosList[g].ToString() + " < " + duetInFinalList[j].summirizePosList[g].ToString());

                                DuetInFinal swap = duetInFinalList[i];
                                duetInFinalList[i] = duetInFinalList[j];
                                duetInFinalList[j] = swap;
                                break;
                            }
                            //else if (duetInFinalList[i].summirizePosList[g] == duetInFinalList[j].summirizePosList[g] && duetInFinalList[j].summirizePosList[g] != 0 && numOfColumn != 0)
                            else if (duetInFinalList[i].summirizePosList[danceNumber][g] == duetInFinalList[j].summirizePosList[danceNumber][g] && numOfColumn != 0)
                            {
                                //MessageBox.Show("Comparing Sums: " + duetInFinalList[i].summirizePosList[g].ToString() + " with " + duetInFinalList[j].summirizePosList[g].ToString() + " from " + i.ToString() + " and " + j.ToString());
                                if (duetInFinalList[i].summirizeSumPosList[danceNumber][g] > duetInFinalList[j].summirizeSumPosList[danceNumber][g])
                                {
                                    //MessageBox.Show("Swapping Sums!\nCause: " + duetInFinalList[i].summirizeSumPosList[g].ToString() + " > " + duetInFinalList[j].summirizeSumPosList[g].ToString());
                                    DuetInFinal swap = duetInFinalList[i];
                                    duetInFinalList[i] = duetInFinalList[j];
                                    duetInFinalList[j] = swap;
                                    break;
                                }
                                else if (duetInFinalList[i].summirizeSumPosList[danceNumber][g] < duetInFinalList[j].summirizeSumPosList[danceNumber][g]) break;
                            }
                            else break;
                        }
                        string retStrList = "";
                        for (int h = 0; h < duetInFinalList.Count; h++)
                        {
                            retStrList += duetInFinalList[h].ToString() + "\n";
                        }
                        //MessageBox.Show(i.ToString() + " Step sorting: (" + numOfColumn + "):\n" + retStrList);
                    }
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show (ex.Message);
            //}
            //2.Набираем List элементов, равных максимальному
            List<DuetInFinal> retList1 = new List<DuetInFinal>();
            List<DuetInFinal> retList2 = new List<DuetInFinal>();
            string retStrList1 = "";
            string retStrList2 = "";

            for (int i = 0; i < duetInFinalList.Count; i++)
            {
                //if (numOfColumn < duetInFinalList.Count)
                if (numOfColumnDyn < countOfParticipants && numOfColumn < countOfParticipants)
                {
                    //if (duetInFinalList[i].summirizePosList[0] == duetInFinalList[0].summirizePosList[0] && duetInFinalList[i].summirizeSumPosList[0] == duetInFinalList[0].summirizeSumPosList[0])
                    if (duetInFinalList[i].summirizePosList[danceNumber][numOfColumn] == duetInFinalList[0].summirizePosList[danceNumber][numOfColumn] && duetInFinalList[i].summirizeSumPosList[danceNumber][numOfColumn] == duetInFinalList[0].summirizeSumPosList[danceNumber][numOfColumn])
                    //if(i == 0)
                    {
                        retList1.Add(duetInFinalList[i]);
                        retStrList1 += duetInFinalList[i].ToString() + "\n";
                    }
                    else
                    {
                        retList2.Add(duetInFinalList[i]);
                        retStrList2 += duetInFinalList[i].ToString() + "\n";
                    }
                }
                else
                {
                    if (duetInFinalList[i].positions[danceNumber] == -1)
                    {
                        duetInFinalList[i].positions[danceNumber] = numOfColumnDyn;
                        retList1.Add(duetInFinalList[i]);
                        retStrList1 += duetInFinalList[i].ToString() + "\n";
                    }
                }
            }
            //MessageBox.Show("List1:\n" + retStrList1 + "\n\n List2:\n" + numOfColumnDyn.ToString() + retStrList2 );

            //3.Сортируем новый лист
            //if (numOfColumn + 1 < countOfParticipants)
            //    numOfColumn++;

            return unionLists(combSort(ref retList1, ref outPutFinalList, numOfColumn + 1, countOfParticipants, danceNumber), combSort(ref retList2, ref outPutFinalList, numOfColumnDyn, countOfParticipants, danceNumber));
        }

        public static List<DuetInFinal> combSortfinalGrading(ref List<DuetInFinal> duetInFinalList, ref List<DuetInFinal> outPutFinalList, int numOfColumn, int countOfParticipants, int danceCount)//int[] input)
        {
            string retStr = "numOfColumn: " + numOfColumn.ToString();
            //numOfColumnDyn = numOfColumn;
            //if (duetInFinalList.Count <= 1 || numOfColumn + 1 == duetInFinalList.Count)
            if (duetInFinalList.Count <= 1 || numOfColumn >= countOfParticipants + 1)
            {
                string retStrList = "";
                for (int i = 0; i < duetInFinalList.Count; i++)
                {
                    duetInFinalList[i].finslPosition = numOfColumnDyn + 1;
                    retStrList += duetInFinalList[i].ToString() + "\n";
                }
                numOfColumnDyn += duetInFinalList.Count;
                MessageBox.Show("Returning(" + numOfColumn + "):\n" + retStrList);
                outPutFinalList.AddRange(duetInFinalList);
                return (duetInFinalList);
            }
            //1.Сортируем
            //if (numOfColumnDyn < countOfParticipants && numOfColumn < countOfParticipants)
            //{
            //try
            //{
            for (int i = 0; i < duetInFinalList.Count - 1; i++)
            {
                for (int j = i + 1; j < duetInFinalList.Count; j++)
                {
                    for (int g = numOfColumnDyn; g < danceCount; g++)
                    {
                        if (duetInFinalList[i].summirizeSumPosListFinal > duetInFinalList[j].summirizeSumPosListFinal)
                        {
                            //MessageBox.Show("Swapping!\nCause: " + duetInFinalList[i].summirizeSumPosListFinal + " < " + duetInFinalList[j].summirizeSumPosListFinal.ToString());

                            DuetInFinal swap = duetInFinalList[i];
                            duetInFinalList[i] = duetInFinalList[j];
                            duetInFinalList[j] = swap;
                            break;
                        }
                        //else if (duetInFinalList[i].summirizePosList[g] == duetInFinalList[j].summirizePosList[g] && duetInFinalList[j].summirizePosList[g] != 0 && numOfColumn != 0)
                        else if (duetInFinalList[i].summirizeSumPosListFinal == duetInFinalList[j].summirizeSumPosListFinal && numOfColumn != 0)
                        {
                            MessageBox.Show("Comparing Sums: " + duetInFinalList[i].summirizeSumPosListFinal.ToString() + " with " + duetInFinalList[j].summirizeSumPosListFinal.ToString() + " from " + i.ToString() + " and " + j.ToString());
                            if (duetInFinalList[i].summirizePosListFinal[g] < duetInFinalList[j].summirizePosListFinal[g])
                            {
                                    MessageBox.Show("Swapping Sums!\nCause: (" + g.ToString() + ") " + duetInFinalList[i].summirizePosListFinal[g].ToString() + " > " + duetInFinalList[j].summirizePosListFinal[g].ToString());
                                    DuetInFinal swap = duetInFinalList[i];
                                    duetInFinalList[i] = duetInFinalList[j];
                                    duetInFinalList[j] = swap;
                                    break;
                            }
                            else if (duetInFinalList[i].summirizePosListFinal[g] == duetInFinalList[j].summirizePosListFinal[g])
                            {
                                MessageBox.Show("Comparing Sumssss: " + duetInFinalList[i].summirizePosListFinal_Third[g].ToString() + " with " + duetInFinalList[j].summirizePosListFinal_Third[g].ToString() + " from " + i.ToString() + " and " + j.ToString());
                                if (duetInFinalList[i].summirizePosListFinal_Third[g] < duetInFinalList[j].summirizePosListFinal_Third[g])
                                {
                                    MessageBox.Show("Swapping Sums!\nCause: (" + g.ToString() + ") " + duetInFinalList[i].summirizePosListFinal[g].ToString() + " > " + duetInFinalList[j].summirizePosListFinal[g].ToString());
                                    DuetInFinal swap = duetInFinalList[i];
                                    duetInFinalList[i] = duetInFinalList[j];
                                    duetInFinalList[j] = swap;
                                    break;
                                }
                            }
                            else break;
                            //else if (duetInFinalList[i].summirizePosListFinal[g] < duetInFinalList[j].summirizePosListFinal[g]) break;
                        }
                        else break;
                    }
                    string retStrList = "";
                    for (int h = 0; h < duetInFinalList.Count; h++)
                    {
                        retStrList += duetInFinalList[h].ToString() + "\n";
                    }
                    //MessageBox.Show(i.ToString() + " Step sorting: (" + numOfColumn + "):\n" + retStrList);
                }
            }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show (ex.Message);
            //}
            //2.Набираем List элементов, равных максимальному
            List<DuetInFinal> retList1 = new List<DuetInFinal>();
            List<DuetInFinal> retList2 = new List<DuetInFinal>();
            string retStrList1 = "";
            string retStrList2 = "";

            for (int i = 0; i < duetInFinalList.Count; i++)
            {
                //if (numOfColumn < duetInFinalList.Count)
                if (numOfColumnDyn < countOfParticipants && numOfColumn < countOfParticipants)
                {
                    //if (duetInFinalList[i].summirizePosList[0] == duetInFinalList[0].summirizePosList[0] && duetInFinalList[i].summirizeSumPosList[0] == duetInFinalList[0].summirizeSumPosList[0])
                    if (duetInFinalList[i].summirizeSumPosListFinal == duetInFinalList[0].summirizeSumPosListFinal)
                    //if(i == 0)
                    {
                        retList1.Add(duetInFinalList[i]);
                        retStrList1 += duetInFinalList[i].ToString() + "\n";
                    }
                    else
                    {
                        retList2.Add(duetInFinalList[i]);
                        retStrList2 += duetInFinalList[i].ToString() + "\n";
                    }
                }
                else
                {
                    if (duetInFinalList[i].finslPosition == -1)
                    {
                        duetInFinalList[i].finslPosition = numOfColumnDyn;
                        retList1.Add(duetInFinalList[i]);
                        retStrList1 += duetInFinalList[i].ToString() + "\n";
                    }
                }
            }
            //MessageBox.Show("List1:\n" + retStrList1 + "\n\n List2:\n" + numOfColumnDyn.ToString() + retStrList2);

            //3.Сортируем новый лист
            //if (numOfColumn + 1 < countOfParticipants)
            //    numOfColumn++;

            return unionLists(combSortfinalGrading(ref retList1, ref outPutFinalList, numOfColumn + 1, countOfParticipants, danceCount), combSortfinalGrading(ref retList2, ref outPutFinalList, numOfColumnDyn, countOfParticipants, danceCount));
        }

        private static List<DuetInFinal> unionLists(List<DuetInFinal> list1, List<DuetInFinal> list2)
        {
            List<DuetInFinal> retList = new List<DuetInFinal>();
            for (int i = 0; i < list2.Count; i++)
                list1.Add(list2[i]);
            return retList;
        }

        //        for (int i = 0; i<inputDuetList.Count; i++)
        //            {
        //                int num = inputDuetList[i].number;

        //        duetNumbers.Add(inputDuetList[i].number);
        //                //Подсчет различных оценок (summirize)
        //                summirizeMarks.Add(new int[inputDuetList.Count]);
        //                //Подсчет 1
        //                summirizeMarks[i][0] = 0;

        //                for (int g = 0; g<inputDuetList[i].judgeMarkScatingFinalList[danceNumber].Count; g++)
        //                {
        //                    if (1 == inputDuetList[i].judgeMarkScatingFinalList[danceNumber][g])
        //                        summirizeMarks[i][0]++;
        //                }

        //                //Подсчет остальных оценок (summirize)
        //                for (int j = 1; j<inputDuetList.Count; j++)
        //                {
        //                    int tmpCount = 0;
        //    summirizeMarks[i][j] = 0;
        //                    for (int g = 0; g<inputDuetList[i].judgeMarkScatingFinalList[danceNumber].Count; g++)
        //                    {
        //                        if ((j + 1) == inputDuetList[i].judgeMarkScatingFinalList[danceNumber][g])
        //                            tmpCount++;
        //                    }
        //summirizeMarks[i][j] = summirizeMarks[i][j - 1] + tmpCount;
        //                }
        //            }

        //public static List<int> combSort(ref List<int[]> summirizeInput, int numOfColumn, int position, ref List<int> duetNumbers)//int[] input)
        //{
        //    string retStr = "numOfColumn: " + numOfColumn.ToString() + "position" + position.ToString() + "\nДо: ";
        //    foreach (int item in duetNumbers)
        //    {
        //        retStr += item.ToString();
        //    }
        //    MessageBox.Show(retStr);
        //    for (int i = numOfColumn; i < summirizeInput.Count - 1; i++)
        //    {
        //        for (int j = i + 1; j < summirizeInput.Count; j++)
        //        {
        //            if (summirizeInput[i][numOfColumn] < summirizeInput[j][numOfColumn])
        //            {
        //                int[] swap = summirizeInput[i];
        //                summirizeInput[i] = summirizeInput[j];
        //                summirizeInput[j] = swap;

        //                //MessageBox.Show("Compare: " + summirizeInput[i][numOfColumn].ToString() + " and " + summirizeInput[j][numOfColumn].ToString());
        //                //MessageBox.Show("Swap: " + duetNumbers[i].ToString() + " and " + duetNumbers[j].ToString());

        //                int duetSwap = duetNumbers[i];
        //                duetNumbers[i] = duetNumbers[j];
        //                duetNumbers[j] = duetSwap;
        //            }
        //        }
        //    }
        //    //return summirizeInput;
        //    retStr = "После: ";
        //    foreach (int item in duetNumbers)
        //    {
        //        retStr += item.ToString();
        //    }
        //    MessageBox.Show(retStr);
        //    return duetNumbers;
        //}
    }
}

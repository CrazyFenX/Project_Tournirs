using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001.Classes
{
    public class DuetInFinal
    {
        public List<int[]> summirizePosList = new List<int[]> { };
        public List<int[]> summirizeSumPosList = new List<int[]> { };

        public List<int> summirizePosListFinal = new List<int> { };
        public List<int> summirizePosListFinal_Third = new List<int> { };
        //public List<int> summirizeSumPosListFinal = new List<int> { };
        public int summirizeSumPosListFinal = 0;

        public int number;
        public int numberInGroup;
        public List<int> positions = new List<int>();

        public int finslPosition = -1;
        public DuetInFinal(List<int[]> sumPosList, List<int[]> sumSumPosList, int num, int numInGroup)
        {
            summirizePosList = sumPosList;
            summirizeSumPosList = sumSumPosList;
            number = num;
            numberInGroup = numInGroup;
        }

        public override string ToString()
        {
            string retStr = "number " + number.ToString() + " numInGroup " + numberInGroup.ToString() + "Pos ";
            foreach (int item in positions)
                retStr += item.ToString() + " ";
            retStr += "\n";
            foreach (int[] item in summirizePosList)
                for (int i = 0; i < item.Length; i++)
                {
                    retStr += item[i].ToString() + " ";
                }
            retStr += "\n";
            foreach (int[] item in summirizeSumPosList)
                for (int i = 0; i < item.Length; i++)
                {
                    retStr += item[i].ToString() + " ";
                }
            retStr += "\n";
            retStr += this.summirizeSumPosListFinal.ToString() + " ";
            retStr += "\n";
            foreach (int item in summirizePosListFinal)
                retStr += item.ToString() + " ";
            retStr += "\n";
            retStr += "Финальная позиция " + this.finslPosition.ToString() + " ";
            return retStr;
        }
    }
}

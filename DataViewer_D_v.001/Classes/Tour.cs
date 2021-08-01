using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001.Classes
{
    public class Tour
    {
        public static int[] basicCounts = new int[] { 6, 12, 24, 48, 96, 192, 384 };
        public BitArray tourBitMap;
        public BitArray nextTourBitMap;
        public List<int> degrees = new List<int>();
        public int degree = 0;
        public int countOfDuets = 0;
        public int countOfDuetsNextTour = 0;
        public ComboBox formReglamentComboBox = new ComboBox();
        public TextBox numOfParticipantsTextBox = new TextBox();

        public List<Duet> sortDuetList = new List<Duet>();

        public int isItPlayed = -1; //-1 - тур еще не доступен, 0 - тур доступен для оценки, 1 - тур оценен

        //Constructors
        public Tour() { degrees.Add(0); countOfDuets = 0; tourBitMap = new BitArray(0, false); }

        public Tour(int count)
        {
            degrees = getTourdegree(count);
            countOfDuets = count;
            tourBitMap = new BitArray(count, false);
        }
        public Tour(int degr, int flag)
        {
            degree = degr;
            countOfDuets = basicCounts[degr];
            tourBitMap = new BitArray(countOfDuets, false);
        }

        //methods
        public static List<int> getTourdegree(int inputCount)
        {
            List<int> retDegree = new List<int>();
            if (inputCount < 8)
                retDegree.Add(0); //= 0;
            if (inputCount < 15 && inputCount >= 7)
                retDegree.Add(1); //= 1;
            if (inputCount < 30 && inputCount >= 13)
                retDegree.Add(2); //= 2;
            if (inputCount < 60 && inputCount >= 25)
                retDegree.Add(3); //= 3;
            if (inputCount < 120 && inputCount >= 49)
                retDegree.Add(4); //= 4;
            if (inputCount < 240 && inputCount >= 97)
                retDegree.Add(5); //= 5;
            if (inputCount >= 193)
                retDegree.Add(6);// = 6;

            return retDegree;
        }

        public override string ToString()
        {
            string retStr = "";
            foreach (int item in degrees)
                retStr += item.ToString() + " ";
            retStr += "\n";
            retStr += countOfDuets.ToString();
            return retStr;
        }

        public static string getStringDegr(int inputDegr)
        {
            int tourDegree = 1;
            if (inputDegr == 0)
                return "Финал";
            for (int j = 0; j < inputDegr; j++)
                tourDegree *= 2;
            return $"1/{tourDegree}";
        }
        public static string getShortStringDegr(int inputDegr)
        {
            int tourDegree = 1;
            if (inputDegr == 0)
                return "Финaл";
            for (int j = 0; j < inputDegr; j++)
                tourDegree *= 2;
            return $"тур 1-{tourDegree}";
        }

        public static int getCountFromDegr(int inputDegr)
        {
            int tourDegree = 0;
            while(inputDegr >= 1)
            {
                inputDegr /= 2;
                tourDegree += 1;
            }
            return tourDegree;
        }

        public int[] getDuetListFromString(string inputStr)
        {
            string[] strArray = inputStr.Split(new char[] { ';' });
            int[] retArr = new int[strArray.Length];
            for (int i = 0; i < strArray.Length - 1; i++)
                retArr[i] = Convert.ToInt32(strArray[i]);
            return retArr;
        }
    }
}

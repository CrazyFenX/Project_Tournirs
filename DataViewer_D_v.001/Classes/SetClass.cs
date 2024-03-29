﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class SetClass
    {
        public int number;
        public int numberOfGroup;
        public string category;
        
        public List<Duet> DuetList = new List<Duet>();
        public List<Sportsman> SoloList = new List<Sportsman>();

        public SetClass()
        {
            this.number = 0;
            this.numberOfGroup = 0;
            this.category = "";
            this.DuetList = new List<Duet>();
            this.SoloList = new List<Sportsman>();
        }

        public SetClass(int Group_Number, int Number, string Category):this(Group_Number, Number)
        {
            //this.numberOfGroup = Group_Number;
            //this.number = Number;
            this.category = Category;
        }

        public SetClass(int Group_Number, int Number):this()
        {
            this.numberOfGroup = Group_Number;
            this.number = Number;
            //this.category = "";
            //this.DuetList = new List<Duet>();
            //this.SoloList = new List<Sportsman>();
        }

        public string getDuetString()
        {
            string retStr = "";
            foreach (Duet item in DuetList)
                retStr += item.number + ";";
            return retStr;
        }

        public int[] getDuetListFromString(string inputStr)
        {
            string[] strArray = inputStr.Split(new char[] { ';' });
            int[] retArr = new int[strArray.Length];
            for (int i = 0; i < strArray.Length - 1; i++)
                retArr[i] = Convert.ToInt32(strArray[i]);
            return retArr;
        }

        public override string ToString()
        {
            return "Заход номер " + Convert.ToString(this.number) + " из группы " + Convert.ToString(this.numberOfGroup) + " категория " + Convert.ToString(this.category);
        }
    }
}
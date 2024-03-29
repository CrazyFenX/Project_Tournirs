﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataViewer_D_v._001
{
    public class Sportsman
    {
        public string Name;
        public string Surname;
        public string Patronymic;

        public MyDate BirthDate = new MyDate();

        //public DateTime BirthDate = new DateTime();

        public int BookNumber;

        public int GroupNumber;
        public int SetNumber;
        public int DuetNumber;

        public int NumberInTournir;
        public int NumberInGroup;

        public string ClubName;
        public string City;

        public Trainer OlderTrainer = new Trainer();
        public Trainer FirstTrainer = new Trainer();
        public Trainer SecondTrainer = new Trainer();

        public string AgeCategory;
        public string SportClass;
        public List<danceClass> danceList = new List<danceClass>();

        public string SportCategory;

        public Sportsman() //Constructor
        {
            // this.Name = "NotDefined";
            Name = "";
            Surname = "";
            Patronymic = "";
            BookNumber = -1;

            OlderTrainer = new Trainer();
            FirstTrainer = new Trainer();
            SecondTrainer = new Trainer();
            MyDate BirthDate = new MyDate();
        }

        public Sportsman(int Num) //Constructor
        {
            // this.Name = "NotDefined";
            BookNumber = Num;
            OlderTrainer = new Trainer();
            FirstTrainer = new Trainer();
            SecondTrainer = new Trainer();
            MyDate BirthDate = new MyDate();
        }

        public override string ToString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
        public string ToString(int i)
        {
            if (Name == "" || Name == null)
                Name = " ";
            if (Patronymic == "" || Patronymic == null)
                Patronymic = " ";
            return Surname;
        }
    }
}

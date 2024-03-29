﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public class Trainer
    {
        public string Pas = "";
        public string Name;
        public int Number;
        public string Surname;
        public string Patronymic;

        public string Status; // 1,2 (1 - older, 2 - second)

        public Trainer()
        {
            //pass
        }

        public Trainer(string name, string surname, string patronymic, string status)
        {
            this.Name = name;
            this.Surname = surname;
            this.Patronymic = patronymic;
            this.Status = status;
            //MessageBox.Show($"Новый тренер: {this.Name} {this.Surname} {this.Status}");

        }

        public void pasItendificate()
        {
            char[] pas_ = new char[9];

            pas_[0] = this.Surname[0];
            pas_[1] = this.Surname[1];
            pas_[2] = this.Surname[2];

            pas_[3] = this.Name[0];
            pas_[4] = this.Name[1];
            pas_[5] = this.Name[2];

            pas_[6] = this.Patronymic[0];
            pas_[7] = this.Patronymic[1];
            pas_[8] = this.Patronymic[2];
            this.Pas = new string(pas_);
            //MessageBox.Show(this.Pas);
        }

        public override string ToString()
        {
            if (this.Name == "" || this.Name == null)
                this.Name = " ";
            if (this.Patronymic == "" || this.Patronymic == null)
                this.Patronymic = " ";
            return Surname + " " + Name[0] + "." + Patronymic[0] + ".";
        }
        public string ToLongString()
        {
            return Surname + " " + Name + " " + Patronymic;
        }
    }
}
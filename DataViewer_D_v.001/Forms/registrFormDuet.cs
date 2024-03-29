﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public partial class registrFormDuet : Form
    {
        startWindow startWindow = new startWindow();

        Sportsman sportsman_first = new Sportsman();
        Sportsman sportsman_second = new Sportsman();

        List<string> AgeCategoryList = new List<string> { "Д-0", "Д-1", "Д-2", "Ю-1", "Ю-2", "М-1", "М-2", "Вз", "Другой" };

        List<string> GroupAgeCategoryList = new List<string>() { "Д-0", "Д-1", "Д-2", "Ю-1", "Ю-2", "М-1", "М-2", "Вз", "Другой" };

        string folderName;

        int participantNumber = 0;

        TournirClass tournir = new TournirClass();

        public registrFormDuet()
        {
            InitializeComponent();
            ParticipantsDataGridView.Visible = false;
        }
        public registrFormDuet(string Path) : this()
        {
            this.Path_textBox.Text = Path;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            startWindow.Show();
            startWindow.path = Path_textBox.Text;
            Controller.myConnection.Close();//////////////////////

            startWindow.registratorButton.Visible = false;
            startWindow.secretaryButton.Visible = false;
            startWindow.Exit_button.Visible = false;

            startWindow.backButton.Visible = true;
            startWindow.solistButton.Visible = true;
            startWindow.duetButton.Visible = true;
            startWindow.sekwayButton.Visible = true;
            startWindow.ansamblButton.Visible = true;
        }

        private void registrFormDuet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            startWindow.Show();
            startWindow.path = Path_textBox.Text;
            Controller.myConnection.Close();

            startWindow.registratorButton.Visible = false;
            startWindow.secretaryButton.Visible = false;
            startWindow.Exit_button.Visible = false;

            startWindow.backButton.Visible = true;
            startWindow.solistButton.Visible = true;
            startWindow.duetButton.Visible = true;
            startWindow.sekwayButton.Visible = true;
            startWindow.ansamblButton.Visible = true;
        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            //bool searchFailedFlag = false;

            //if (BookNumber1_textBox.Text != "" && BookNumber2_textBox.Text != "")
                //try
                //{
                    //sportsman_first = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber1_textBox.Text));
                    //sportsman_second = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber2_textBox.Text));

                    //if (sportsman_first.Name != "NotDefined" || sportsman_second.Name != "NotDefined")
                    //{
                    //    searchFailedFlag = true;
                    //}
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show($"{ex.Message}");
                //}
            //else
            //{
            //    MessageBox.Show("Заполните поле 'Номер Книжки' для первого спортсмена!");
            //}

            if (checkAllBoxes())
            {
                sportsman_first = new Sportsman();
                sportsman_second = new Sportsman();

                sportsman_first.Name = Name1textBox.Text;
                sportsman_first.Surname = Surname1textBox.Text;
                sportsman_first.Patronymic = Patronymic1textBox.Text;
                sportsman_first.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, GroupAgeCategoryList, 1);
                

                sportsman_second.Name = Name2textBox.Text;
                sportsman_second.Surname = Surname2textBox.Text;
                sportsman_second.Patronymic = Patronymic2textBox.Text;
                sportsman_second.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, GroupAgeCategoryList, 1);
                if (sportsman_first.AgeCategory == "0" || sportsman_second.AgeCategory == "0")
                    return;
                sportsman_first.BirthDate = new MyDate();
                sportsman_second.BirthDate = new MyDate();

                //sportsman_first.BirthDate = new DateTime(2020 - YearOfBirth1_comboBox.SelectedIndex, MounthOfBirth1_comboBox.SelectedIndex + 1, DayOfBirth1_comboBox.SelectedIndex + 1);
                //sportsman_second.BirthDate = new DateTime(2020 - YearOfBirth2_comboBox.SelectedIndex, MounthOfBirth2_comboBox.SelectedIndex + 1, DayOfBirth2_comboBox.SelectedIndex + 1);

                sportsman_first.BirthDate.Day = DayOfBirth1_comboBox.SelectedIndex + 1;
                sportsman_first.BirthDate.Month = MounthOfBirth1_comboBox.SelectedIndex + 1;
                sportsman_first.BirthDate.Year = 2020 - YearOfBirth1_comboBox.SelectedIndex;

                //MessageBox.Show(sportsman_first.BirthDate.ToShortDateString() + "\n" + sportsman_second.BirthDate.ToShortDateString());

                sportsman_second.BirthDate.Day = DayOfBirth2_comboBox.SelectedIndex + 1;
                sportsman_second.BirthDate.Month = MounthOfBirth2_comboBox.SelectedIndex + 1;
                sportsman_second.BirthDate.Year = 2020 - YearOfBirth2_comboBox.SelectedIndex;

                //sportsman_first.BookNumber = Convert.ToInt32(BookNumber1_textBox.Text);
                //sportsman_second.BookNumber = Convert.ToInt32(BookNumber2_textBox.Text);
                sportsman_first.BookNumber = 0;
                sportsman_second.BookNumber = 0;


                participantNumber = (SecretaryController.TakeMax("Номер", "participants", Path_textBox.Text) + 1);
                sportsman_first.NumberInTournir = participantNumber;
                sportsman_second.NumberInTournir = participantNumber + 1;

                sportsman_first.GroupNumber = Convert.ToInt32(groupNumber_comboBox.Text);
                sportsman_second.GroupNumber = Convert.ToInt32(groupNumber_comboBox.Text);

                sportsman_first.DuetNumber = Convert.ToInt32(duetNumber_textBox.Text);
                sportsman_second.DuetNumber = Convert.ToInt32(duetNumber_textBox.Text);

                sportsman_first.NumberInGroup = SecretaryController.TakeMax("Номер_В_Группе","duets", "Номер_Группы", sportsman_first.GroupNumber,  Path_textBox.Text) + 1;//Convert.ToInt32(duetNumber_textBox.Text);
                //sportsman_second.NumberInGroup = SecretaryController.TakeMax("Номер_В_Группе", "duets", "Номер_Группы", sportsman_second.GroupNumber, Path_textBox.Text);//Convert.ToInt32(duetNumber_textBox.Text);
                sportsman_second.NumberInGroup = sportsman_first.NumberInGroup + 1;
                //MessageBox.Show("Номер группы: ");

                sportsman_first.ClubName = ClubName_textBox.Text;
                sportsman_first.City = City_textBox.Text;
                sportsman_second.ClubName = ClubName_textBox.Text;
                sportsman_second.City = City_textBox.Text;

                sportsman_first.OlderTrainer = new Trainer(NameOfOldTrainer_textBox.Text, SurnameOfOldTrainer_textBox.Text, PatronymicOfOldTrainer_textBox.Text, "Старший");
                sportsman_first.FirstTrainer = new Trainer(NameOfDuetTrainer1_textBox.Text, SurnameOfDuetTrainer1_textBox.Text, PatronymicOfDuetTrainer1_textBox.Text, "Первый");
                if (DuetTrainer2_checkBox.Checked)
                    sportsman_first.SecondTrainer = new Trainer(NameOfDuetTrainer2_textBox.Text, SurnameOfDuetTrainer2_textBox.Text, PatronymicOfDuetTrainer2_textBox.Text, "Второй");

                sportsman_first.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategoryList);

                sportsman_first.SportClass = Convert.ToString(SportClass1_comboBox.SelectedItem);
                sportsman_first.SportCategory = Convert.ToString(SportCategory1_comboBox.SelectedItem);

                sportsman_second.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategoryList);

                sportsman_second.SportClass = Convert.ToString(SportClass2_comboBox.SelectedItem);
                sportsman_second.SportCategory = Convert.ToString(SportCategory2_comboBox.SelectedItem);

                //if (searchFailedFlag)
                //{
                //    Controller.insertInSportDB(sportsman_first);
                //    Controller.insertInSportDB(sportsman_second);
                //
                //}

                //SecretaryController.insertTrainer(sportsman_first.OlderTrainer, sportsman_first.DuetNumber, Path_textBox.Text);
                //SecretaryController.insertTrainer(sportsman_first.FirstTrainer, sportsman_first.DuetNumber, Path_textBox.Text);
                //if (DuetTrainer2_checkBox.Checked)
                //    SecretaryController.insertTrainer(sportsman_first.SecondTrainer, sportsman_first.DuetNumber, Path_textBox.Text);
                
                int OldTrainerNumber = 0;
                OldTrainerNumber = SecretaryController.checkTrainerExist(sportsman_first.OlderTrainer, Path_textBox.Text);
                if (OldTrainerNumber == 0)
                    sportsman_first.OlderTrainer.Number = SecretaryController.insertTrainer(sportsman_first.OlderTrainer, sportsman_first.DuetNumber, Path_textBox.Text); //RETURN TRAINER NUMBER
                else
                    sportsman_first.OlderTrainer.Number = OldTrainerNumber;

                int FirstTrainerNumber = 0;
                FirstTrainerNumber = SecretaryController.checkTrainerExist(sportsman_first.FirstTrainer, Path_textBox.Text);
                if (FirstTrainerNumber == 0)
                    sportsman_first.FirstTrainer.Number = SecretaryController.insertTrainer(sportsman_first.FirstTrainer, sportsman_first.DuetNumber, Path_textBox.Text);
                else
                    sportsman_first.FirstTrainer.Number = FirstTrainerNumber;

                int SecondTrainerNumber = 0;
                SecondTrainerNumber = SecretaryController.checkTrainerExist(sportsman_first.SecondTrainer, Path_textBox.Text);
                if (DuetTrainer2_checkBox.Checked)
                    if (SecondTrainerNumber == 0)
                        sportsman_first.SecondTrainer.Number = SecretaryController.insertTrainer(sportsman_first.SecondTrainer, sportsman_first.DuetNumber, Path_textBox.Text);
                    else
                        sportsman_first.SecondTrainer.Number = SecondTrainerNumber;

                SecretaryController.insertInParticipants(sportsman_first, 1, Path_textBox.Text);
                SecretaryController.insertInParticipants(sportsman_second, 2, Path_textBox.Text);

                SecretaryController.insertParticipantsInDuet(Convert.ToInt32(duetNumber_textBox.Text), sportsman_first, sportsman_second, Convert.ToInt32(groupNumber_comboBox.Text), Path_textBox.Text);
                string retFolderName = "";
                //printing number
                //if (checkBoxPrintNumber.Checked)
                //{         inputGroup.number.ToString() + ") " + 
                if (advCheckBox.Checked)
                    retFolderName = pdf_controller.getNumberCard_largeWithAdv(Path_textBox.Text, tournir.groups[groupNumber_comboBox.SelectedIndex].number.ToString() + ") " + tournir.groups[groupNumber_comboBox.SelectedIndex].name, sportsman_first, sportsman_second, Convert.ToInt32(duetNumber_textBox.Text), advTextBox.Text);
                else
                    retFolderName = pdf_controller.getNumberCard_largeWithAdv(Path_textBox.Text, tournir.groups[groupNumber_comboBox.SelectedIndex].number.ToString() + ") " + tournir.groups[groupNumber_comboBox.SelectedIndex].name, sportsman_first, sportsman_second, Convert.ToInt32(duetNumber_textBox.Text), tournir.name);
                //}

                if (checkBoxPrintNumber.Checked)
                {
                    printing_controller.PrintWord(printerName_TextBox.Text, retFolderName);
                }
                //MessageBox.Show(retFolderName);
                retFolderName = "";

                if (advCheckBox.Checked)
                    retFolderName = pdf_controller.getNumberCard_largeWithAdv(Path_textBox.Text, tournir.groups[groupNumber_comboBox.SelectedIndex].number.ToString() + ") " + tournir.groups[groupNumber_comboBox.SelectedIndex].name, sportsman_second, sportsman_first, Convert.ToInt32(duetNumber_textBox.Text), advTextBox.Text);
                else
                    retFolderName = pdf_controller.getNumberCard_largeWithAdv(Path_textBox.Text, tournir.groups[groupNumber_comboBox.SelectedIndex].number.ToString() + ") " + tournir.groups[groupNumber_comboBox.SelectedIndex].name, sportsman_second, sportsman_first, Convert.ToInt32(duetNumber_textBox.Text), tournir.name);
                //MessageBox.Show(retFolderName);

                if (checkBoxPrintNumber.Checked)
                {
                    printing_controller.PrintWord(printerName_TextBox.Text, retFolderName);
                }

                duetNumber_textBox.Text = (Convert.ToInt32(duetNumber_textBox.Text) + 1).ToString();
                clearAllBoxes();
                MessageBox.Show("Пара успешно зарегистрирована");
            }
            else
                MessageBox.Show("Не все необходимые поля заполнены!");
        }

        public void clearAllBoxes()
        {
            Name1textBox.Text = "";
            Surname1textBox.Text = "";
            Patronymic1textBox.Text = "";

            DayOfBirth1_comboBox.SelectedIndex = -1;
            MounthOfBirth1_comboBox.SelectedIndex = -1;
            YearOfBirth1_comboBox.SelectedIndex = -1;

            Name2textBox.Text = "";
            Surname2textBox.Text = "";
            Patronymic2textBox.Text = "";

            DayOfBirth2_comboBox.SelectedIndex = -1; 
            MounthOfBirth2_comboBox.SelectedIndex = -1;
            YearOfBirth2_comboBox.SelectedIndex = -1;

            ClubName_textBox.Text = "";
            NameOfOldTrainer_textBox.Text = "";
            SurnameOfOldTrainer_textBox.Text = "";
            PatronymicOfOldTrainer_textBox.Text = "";
            City_textBox.Text = "";

            SurnameOfDuetTrainer1_textBox.Text = "";
            NameOfDuetTrainer1_textBox.Text = "";
            PatronymicOfDuetTrainer1_textBox.Text = "";
            SurnameOfDuetTrainer2_textBox.Text = "";
            NameOfDuetTrainer2_textBox.Text = "";
            PatronymicOfDuetTrainer2_textBox.Text = "";

            SportCategory1_comboBox.SelectedIndex = SportCategory1_comboBox.Items.Count - 1;
            SportClass1_comboBox.SelectedIndex = SportClass1_comboBox.Items.Count - 1;

            SportCategory2_comboBox.SelectedIndex = SportCategory2_comboBox.Items.Count - 1;
            SportClass2_comboBox.SelectedIndex = SportClass2_comboBox.Items.Count - 1;
        }
        public bool checkAllBoxes()
        {
            if (Name1textBox.Text != "" && Surname1textBox.Text != "" && Patronymic1textBox.Text != "" &&
                ClubName_textBox.Text != "" && NameOfOldTrainer_textBox.Text != "" && SurnameOfOldTrainer_textBox.Text != "" &&
                City_textBox.Text != "" && DayOfBirth1_comboBox.SelectedIndex != -1 && MounthOfBirth1_comboBox.SelectedIndex != -1 &&
                YearOfBirth1_comboBox.SelectedIndex != -1 && Name2textBox.Text != "" && Surname2textBox.Text != "" && Patronymic2textBox.Text != ""
                && DayOfBirth2_comboBox.SelectedIndex != -1 && MounthOfBirth2_comboBox.SelectedIndex != -1 && YearOfBirth2_comboBox.SelectedIndex != -1
                && NameOfOldTrainer_textBox.Text != "" && SurnameOfOldTrainer_textBox.Text != "" && PatronymicOfOldTrainer_textBox.Text != ""
                && SurnameOfDuetTrainer1_textBox.Text != "" && NameOfDuetTrainer1_textBox.Text != "" && PatronymicOfDuetTrainer1_textBox.Text != ""
                && ((DuetTrainer2_checkBox.Checked && (SurnameOfDuetTrainer2_textBox.Text != "" && NameOfDuetTrainer2_textBox.Text != "" && PatronymicOfDuetTrainer2_textBox.Text != "")) || !DuetTrainer2_checkBox.Checked)
                )
                return true;
            return false;
        }

        private void openDataBasaButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Path_textBox.Text != "")
                if (ParticipantsDataGridView.Visible)
                {
                    ParticipantsDataGridView.Visible = false;
                    btn.Text = "Открыть базу";
                }
                else
                {
                    ParticipantsDataGridView.Visible = true;
                    btn.Text = "Закрыть базу";
                    SecretaryController.FillParticipantsDataViewer(ParticipantsDataGridView, Path_textBox.Text);
                }
            else
                MessageBox.Show("Не подключена база турнира!");
        }

        private void registrFormDuet_Load(object sender, EventArgs e)
        {
            clearAllBoxes();
        }

        /////////////////////////////////////////////////////////////
        private void DayOfBirth1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategory1_comboBox, CategoryOfDancing_comboBox);
            if (DayOfBirth1_comboBox.SelectedIndex != -1 && MounthOfBirth1_comboBox.SelectedIndex != -1 && YearOfBirth1_comboBox.SelectedIndex != -1)
            {
                sportsman_first.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, GroupAgeCategoryList);
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman_first.AgeCategory), ref SportClass1_comboBox);
            }
            //MessageBox.Show(sportsman_first.AgeCategory);
        }

        private void MounthOfBirth1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategory1_comboBox, CategoryOfDancing_comboBox);
            if (DayOfBirth1_comboBox.SelectedIndex != -1 && MounthOfBirth1_comboBox.SelectedIndex != -1 && YearOfBirth1_comboBox.SelectedIndex != -1)
            {
                sportsman_first.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, GroupAgeCategoryList);
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman_first.AgeCategory), ref SportClass1_comboBox);
            }
        }

        private void YearOfBirth1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategory1_comboBox, CategoryOfDancing_comboBox);
            if (DayOfBirth1_comboBox.SelectedIndex != -1 && MounthOfBirth1_comboBox.SelectedIndex != -1 && YearOfBirth1_comboBox.SelectedIndex != -1)
            {
                sportsman_first.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, GroupAgeCategoryList);
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman_first.AgeCategory), ref SportClass1_comboBox);
            }
        }
        /////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////
        private void DayOfBirth2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategory2_comboBox, CategoryOfDancing_comboBox);
            if (DayOfBirth2_comboBox.SelectedIndex != -1 && MounthOfBirth2_comboBox.SelectedIndex != -1 && YearOfBirth2_comboBox.SelectedIndex != -1)
            {
                sportsman_second.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, GroupAgeCategoryList);
                //MessageBox.Show(sportsman_second.AgeCategory);
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman_second.AgeCategory), ref SportClass2_comboBox);
            }
        }

        private void MounthOfBirth2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategory2_comboBox, CategoryOfDancing_comboBox);
            if (DayOfBirth2_comboBox.SelectedIndex != -1 && MounthOfBirth2_comboBox.SelectedIndex != -1 && YearOfBirth2_comboBox.SelectedIndex != -1)
            {
                sportsman_second.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, GroupAgeCategoryList);
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman_second.AgeCategory), ref SportClass2_comboBox);
            }
        }

        private void YearOfBirth2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            /////Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategory2_comboBox, CategoryOfDancing_comboBox);
            if (DayOfBirth2_comboBox.SelectedIndex != -1 && MounthOfBirth2_comboBox.SelectedIndex != -1 && YearOfBirth2_comboBox.SelectedIndex != -1)
            {
                sportsman_second.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, GroupAgeCategoryList);
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman_second.AgeCategory), ref SportClass2_comboBox);
            }
        }
        /////////////////////////////////////////////////////////////


        //private void searchByBook_1_button_Click(object sender, EventArgs e)
        //{
        //    if (BookNumber1_textBox.Text != "")
        //        try
        //        {
        //            sportsman_first = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber1_textBox.Text));
        //            autoFilling_first(sportsman_first);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"{ex.Message}");
        //        }
        //    else
        //    {
        //        MessageBox.Show("Заполните поле 'Номер Книжки' для первого спортсмена!");
        //    }
        //}

        public void autoFilling_first(Sportsman sportsman_first)
        {
            Name1textBox.Text = sportsman_first.Name;
            Surname1textBox.Text = sportsman_first.Surname;
            Patronymic1textBox.Text = sportsman_first.Patronymic;

            DayOfBirth1_comboBox.SelectedIndex = sportsman_first.BirthDate.Day - 1;
            MounthOfBirth1_comboBox.SelectedIndex = sportsman_first.BirthDate.Month - 1;
            if (sportsman_first.BirthDate.Year > 0)
                YearOfBirth1_comboBox.SelectedIndex = 2020 - sportsman_first.BirthDate.Year;

            ClubName_textBox.Text = sportsman_first.ClubName;
            City_textBox.Text = sportsman_first.City;

            SurnameOfOldTrainer_textBox.Text = sportsman_first.OlderTrainer.Surname;
            NameOfOldTrainer_textBox.Text = sportsman_first.OlderTrainer.Name;
            PatronymicOfOldTrainer_textBox.Text = sportsman_first.OlderTrainer.Patronymic;

            switch (sportsman_first.SportCategory)
            {
                case "Ю-I":
                    SportCategory1_comboBox.SelectedIndex = 0;
                    break;

                case "Ю-II":
                    SportCategory1_comboBox.SelectedIndex = 1;
                    break;

                case "Ю-III":
                    SportCategory1_comboBox.SelectedIndex = 2;
                    break;

                case "Вз-I":
                    SportCategory1_comboBox.SelectedIndex = 3;
                    break;

                case "Вз-II":
                    SportCategory1_comboBox.SelectedIndex = 4;
                    break;

                case "Вз-III":
                    SportCategory1_comboBox.SelectedIndex = 5;
                    break;

                case "КМС":
                    SportCategory1_comboBox.SelectedIndex = 6;
                    break;

                case "МС":
                    SportCategory1_comboBox.SelectedIndex = 7;
                    break;

                case "МСМК":
                    SportCategory1_comboBox.SelectedIndex = 8;
                    break;
            }

            switch (sportsman_first.SportClass)
            {
                case "H":
                case "Н":
                    SportClass1_comboBox.SelectedIndex = 0;
                    break;

                case "E":
                case "Е":
                    SportClass1_comboBox.SelectedIndex = 1;
                    break;

                case "Д":
                    SportClass1_comboBox.SelectedIndex = 2;
                    break;

                case "C":
                case "С":
                    SportClass1_comboBox.SelectedIndex = 3;
                    break;

                case "B":
                case "В":
                    SportClass1_comboBox.SelectedIndex = 4;
                    break;

                case "A":
                case "А":
                    SportClass1_comboBox.SelectedIndex = 5;
                    break;

                case "S":
                    SportClass1_comboBox.SelectedIndex = 6;
                    break;

                case "M":
                case "М":
                    SportClass1_comboBox.SelectedIndex = 7;
                    break;
            }
        }

        public void autoFilling_second(Sportsman sportsman_second)
        {
            Name2textBox.Text = sportsman_second.Name;
            Surname2textBox.Text = sportsman_second.Surname;
            Patronymic2textBox.Text = sportsman_second.Patronymic;

            DayOfBirth2_comboBox.SelectedIndex = sportsman_second.BirthDate.Day - 1;
            MounthOfBirth2_comboBox.SelectedIndex = sportsman_second.BirthDate.Month - 1;
            if (sportsman_second.BirthDate.Year > 0)
                YearOfBirth2_comboBox.SelectedIndex = 2020 - sportsman_second.BirthDate.Year;

            ClubName_textBox.Text = sportsman_second.ClubName;
            City_textBox.Text = sportsman_second.City;

            SurnameOfDuetTrainer1_textBox.Text = sportsman_second.OlderTrainer.Surname;
            NameOfDuetTrainer1_textBox.Text = sportsman_second.OlderTrainer.Name;
            PatronymicOfDuetTrainer1_textBox.Text = sportsman_second.OlderTrainer.Patronymic;

            switch (sportsman_second.SportCategory)
            {
                case "Ю-I":
                    SportCategory2_comboBox.SelectedIndex = 0;
                    break;

                case "Ю-II":
                    SportCategory2_comboBox.SelectedIndex = 1;
                    break;

                case "Ю-III":
                    SportCategory2_comboBox.SelectedIndex = 2;
                    break;

                case "Вз-I":
                    SportCategory2_comboBox.SelectedIndex = 3;
                    break;

                case "Вз-II":
                    SportCategory2_comboBox.SelectedIndex = 4;
                    break;

                case "Вз-III":
                    SportCategory2_comboBox.SelectedIndex = 5;
                    break;

                case "КМС":
                    SportCategory2_comboBox.SelectedIndex = 6;
                    break;

                case "МС":
                    SportCategory2_comboBox.SelectedIndex = 7;
                    break;

                case "МСМК":
                    SportCategory2_comboBox.SelectedIndex = 8;
                    break;
            }

            switch (sportsman_second.SportClass)
            {
                case "H":
                case "Н":
                    SportClass2_comboBox.SelectedIndex = 0;
                    break;

                case "E":
                case "Е":
                    SportClass2_comboBox.SelectedIndex = 1;
                    break;

                case "Д":
                    SportClass2_comboBox.SelectedIndex = 2;
                    break;

                case "C":
                case "С":
                    SportClass2_comboBox.SelectedIndex = 3;
                    break;

                case "B":
                case "В":
                    SportClass2_comboBox.SelectedIndex = 4;
                    break;

                case "A":
                case "А":
                    SportClass2_comboBox.SelectedIndex = 5;
                    break;

                case "S":
                    SportClass2_comboBox.SelectedIndex = 6;
                    break;

                case "M":
                case "М":
                    SportClass2_comboBox.SelectedIndex = 7;
                    break;
            }
        }

        public void autoFillingCategoryAndClasses_second(Sportsman sportsman_second)
        {
            switch (sportsman_second.SportCategory)
            {
                case "Ю-I":
                    SportCategory2_comboBox.SelectedIndex = 0;
                    break;

                case "Ю-II":
                    SportCategory2_comboBox.SelectedIndex = 1;
                    break;

                case "Ю-III":
                    SportCategory2_comboBox.SelectedIndex = 2;
                    break;

                case "Вз-I":
                    SportCategory2_comboBox.SelectedIndex = 3;
                    break;

                case "Вз-II":
                    SportCategory2_comboBox.SelectedIndex = 4;
                    break;

                case "Вз-III":
                    SportCategory2_comboBox.SelectedIndex = 5;
                    break;

                case "КМС":
                    SportCategory2_comboBox.SelectedIndex = 6;
                    break;

                case "МС":
                    SportCategory2_comboBox.SelectedIndex = 7;
                    break;

                case "МСМК":
                    SportCategory2_comboBox.SelectedIndex = 8;
                    break;
            }

            switch (sportsman_second.SportClass)
            {
                case "H":
                case "Н":
                    SportClass2_comboBox.SelectedIndex = 0;
                    break;

                case "E":
                case "Е":
                    SportClass2_comboBox.SelectedIndex = 1;
                    break;

                case "Д":
                    SportClass2_comboBox.SelectedIndex = 2;
                    break;

                case "C":
                case "С":
                    SportClass2_comboBox.SelectedIndex = 3;
                    break;

                case "B":
                case "В":
                    SportClass2_comboBox.SelectedIndex = 4;
                    break;

                case "A":
                case "А":
                    SportClass2_comboBox.SelectedIndex = 5;
                    break;

                case "S":
                    SportClass2_comboBox.SelectedIndex = 6;
                    break;

                case "M":
                case "М":
                    SportClass2_comboBox.SelectedIndex = 7;
                    break;
            }
        }
            //private void searchByBook_2_Button_Click(object sender, EventArgs e)
            //{
            //    if (BookNumber2_textBox.Text != "")
            //        try
            //        {
            //            sportsman_second = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber2_textBox.Text));
            //            autoFilling_second(sportsman_second);
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show($"{ex.Message}");
            //        }
            //    else
            //    {
            //        MessageBox.Show("Заполните поле 'Номер Книжки' для второго спортсмена!");
            //    }
            //}

            private void Browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = openFileDialog1.FileName;
                Path_textBox.Text = folderName;
            }
        }

        private void Path_textBox_TextChanged(object sender, EventArgs e)
        {
            folderName = Path_textBox.Text;
            try
            {
                tournir = SecretaryController.TakeTournir(folderName);
                for (int i = 0; i < tournir.groups.Count; i++)
                {
                    //MessageBox.Show(tournir.groups[i].name);
                    groupNumber_comboBox.Items.Add(tournir.groups[i].number);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupNumber_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                duetNumber_textBox.Text = "";

                duetNumber_textBox.Text = SecretaryController.TakeMax("Номер", "duets", Path_textBox.Text).ToString();

                for (int i = 0; i < tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList.Count; i++)
                {
                    AgeCategoryList.Add(tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList[i]);
                    //AgeCategory2_comboBox.Items.Add(tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgeCategory1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //зависимость класса
           ///// Controller.takeSportClassSet(AgeCategory1_comboBox, SportClass1_comboBox);
        }

        private void AgeCategory2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //////Controller.takeSportClassSet(AgeCategory2_comboBox, SportClass2_comboBox);
        }

        private void registrFormDuet_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 930)
                this.Size = new Size(900, this.Size.Height);
            if (this.Size.Height < 650)
                this.Size = new Size(this.Size.Width, 650);
        }

        private void groupNumber_comboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                try
                {
                    SecretaryController.myConnection.Open();
                    duetNumber_textBox.Text = "";

                    duetNumber_textBox.Text = (SecretaryController.TakeMax("Номер", "duets", Path_textBox.Text) + 1).ToString();
                    //duetNumber_textBox.Text = (SecretaryController.TakeMax("Номер", "participants", "Номер_Группы", groupNumber_comboBox.SelectedIndex + 1, Path_textBox.Text) + 1).ToString();
                    participantNumber = (SecretaryController.TakeMax("Номер_Пары", "participants", Path_textBox.Text) + 1);

                    GroupAgeCategoryList.Clear();
                    string retstr = "";

                    string groupNameTmp = tournir.groups[groupNumber_comboBox.SelectedIndex].name;
                    //MessageBox.Show(groupNameTmp);
                    //MessageBox.Show(tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList.Count.ToString());
                    for (int i = 0; i < tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList.Count; i++)
                    {
                        GroupAgeCategoryList.Add(tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList[i].Replace(" ", string.Empty));
                        retstr += tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList[i].Replace(" ", string.Empty);
                    }
                    groupName_textBox.Text = groupNameTmp + " (пар(солистов): " + tournir.groups[groupNumber_comboBox.SelectedIndex].duetList.Count + ")";
                    //MessageBox.Show(retstr);
                    //MessageBox.Show(tournir.groups[groupNumber_comboBox.SelectedIndex].name);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void checkBoxPrintNumber_CheckedChanged(object sender, EventArgs e)
        {
            printNumberGroupBox.Visible = checkBoxPrintNumber.Checked;
        }

        private void ChoosePrinterButton_Click(object sender, EventArgs e)
        {
            try
            {
                printerName_TextBox.Text = printing_controller.GetDefaultPrinterName();
            }
            catch
            {
            }
        }

        private void SportCategory1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
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


        public registrFormDuet()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            startWindow.Show();
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

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void registrationButton_Click(object sender, EventArgs e)
        {
            if (checkAllBoxes())
            {
                sportsman_first.Name = Name1textBox.Text;
                sportsman_first.Surname = Surname1textBox.Text;
                sportsman_first.Patronymic = Patronymic1textBox.Text;

                sportsman_second.Name = Name2textBox.Text;
                sportsman_second.Surname = Surname2textBox.Text;
                sportsman_second.Patronymic = Patronymic2textBox.Text;

                sportsman_first.BirthDate = new MyDate();
                sportsman_second.BirthDate = new MyDate();

                sportsman_first.BirthDate.Day = DayOfBirth1_comboBox.SelectedIndex + 1;
                sportsman_first.BirthDate.Mounth = MounthOfBirth1_comboBox.SelectedIndex + 1;
                sportsman_first.BirthDate.Year = 2020 - YearOfBirth1_comboBox.SelectedIndex;


                sportsman_second.BirthDate.Day = DayOfBirth2_comboBox.SelectedIndex + 1;
                sportsman_second.BirthDate.Mounth = MounthOfBirth2_comboBox.SelectedIndex + 1;
                sportsman_second.BirthDate.Year = 2020 - YearOfBirth2_comboBox.SelectedIndex;

                sportsman_first.BookNumber = Convert.ToInt32(BookNumber1_textBox.Text);
                sportsman_second.BookNumber = Convert.ToInt32(BookNumber2_textBox.Text);

                sportsman_first.ClubName = ClubName_textBox.Text;
                sportsman_first.City = City_textBox.Text;
                sportsman_second.ClubName = ClubName_textBox.Text;
                sportsman_second.City = City_textBox.Text;

                sportsman_first.OlderTrainer = new Trainer(NameOfOldTrainer_textBox.Text, SurnameOfOldTrainer_textBox.Text, PatronymicOfOldTrainer_textBox.Text, 1);
                sportsman_second.OlderTrainer = new Trainer(NameOfOldTrainer_textBox.Text, SurnameOfOldTrainer_textBox.Text, PatronymicOfOldTrainer_textBox.Text, 1);

                sportsman_first.AgeCategory = Convert.ToString(AgeCategory1_comboBox.SelectedItem);
                sportsman_first.SportClass = Convert.ToString(SportClass1_comboBox.SelectedItem);
                sportsman_first.SportCategory = Convert.ToString(SportCategory1_comboBox.SelectedItem);

                sportsman_second.AgeCategory = Convert.ToString(AgeCategory2_comboBox.SelectedItem);
                sportsman_second.SportClass = Convert.ToString(SportClass2_comboBox.SelectedItem);
                sportsman_second.SportCategory = Convert.ToString(SportCategory2_comboBox.SelectedItem);

                Controller.insertInSportDB(sportsman_first);
                Controller.insertInSportDB(sportsman_second);

                Controller.insertTrainer(sportsman_first.OlderTrainer, sportsman_first.BookNumber);
            }
            else
                MessageBox.Show("Не все необходимые поля заполнены!");
        }

        public bool checkAllBoxes()
        {
            if (Name1textBox.Text != "" && Surname1textBox.Text != "" && Patronymic1textBox.Text != "" && BookNumber1_textBox.Text != "" &&
                ClubName_textBox.Text != "" && NameOfOldTrainer_textBox.Text != "" && SurnameOfOldTrainer_textBox.Text != "" &&
                City_textBox.Text != "" && DayOfBirth1_comboBox.SelectedIndex != -1 && MounthOfBirth1_comboBox.SelectedIndex != -1 &&
                YearOfBirth1_comboBox.SelectedIndex != -1 && Name2textBox.Text != "" && Surname2textBox.Text != "" && Patronymic2textBox.Text != "" && BookNumber2_textBox.Text != ""
                && DayOfBirth2_comboBox.SelectedIndex != -1 && MounthOfBirth2_comboBox.SelectedIndex != -1 && YearOfBirth2_comboBox.SelectedIndex != -1)
                return true;
            return false;
        }

        private void openDataBasaButton_Click(object sender, EventArgs e)
        {
            DataBasaViewer DBForm = new DataBasaViewer();
            DBForm.Show();
        }

        private void registrFormDuet_Load(object sender, EventArgs e)
        {

        }

        /////////////////////////////////////////////////////////////
        private void DayOfBirth1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategory1_comboBox);
        }

        private void MounthOfBirth1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategory1_comboBox);
        }

        private void YearOfBirth1_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth1_comboBox, MounthOfBirth1_comboBox, YearOfBirth1_comboBox, AgeCategory1_comboBox);
        }
        /////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////
        private void DayOfBirth2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategory2_comboBox);
        }

        private void MounthOfBirth2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategory2_comboBox);
        }

        private void YearOfBirth2_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth2_comboBox, MounthOfBirth2_comboBox, YearOfBirth2_comboBox, AgeCategory2_comboBox);
        }
        /////////////////////////////////////////////////////////////


        private void searchByBook_1_button_Click(object sender, EventArgs e)
        {
            if (BookNumber1_textBox.Text != "")
                try
                {
                    sportsman_first = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber1_textBox.Text));
                    autoFilling_first(sportsman_first);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            else
            {
                MessageBox.Show("Заполните поле 'Номер Книжки' для первого спортсмена!");
            }
        }

        public void autoFilling_first(Sportsman sportsman_first)
        {
            Name1textBox.Text = sportsman_first.Name;
            Surname1textBox.Text = sportsman_first.Surname;
            Patronymic1textBox.Text = sportsman_first.Patronymic;

            DayOfBirth1_comboBox.SelectedIndex = sportsman_first.BirthDate.Day - 1;
            MounthOfBirth1_comboBox.SelectedIndex = sportsman_first.BirthDate.Mounth - 1;
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
            MounthOfBirth2_comboBox.SelectedIndex = sportsman_second.BirthDate.Mounth - 1;
            if (sportsman_second.BirthDate.Year > 0)
                YearOfBirth2_comboBox.SelectedIndex = 2020 - sportsman_second.BirthDate.Year;

            ClubName_textBox.Text = sportsman_second.ClubName;
            City_textBox.Text = sportsman_second.City;

            SurnameOfDuetTrainer_textBox.Text = sportsman_second.OlderTrainer.Surname;
            NameOfDuetTrainer_textBox.Text = sportsman_second.OlderTrainer.Name;
            PatronymicOfDuetTrainer_textBox.Text = sportsman_second.OlderTrainer.Patronymic;

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

        private void searchByBook_2_Button_Click(object sender, EventArgs e)
        {
            if (BookNumber2_textBox.Text != "")
                try
                {
                    sportsman_second = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber2_textBox.Text));
                    autoFilling_second(sportsman_second);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            else
            {
                MessageBox.Show("Заполните поле 'Номер Книжки' для второго спортсмена!");
            }
        }

    }
}

using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public partial class registrFormSolo : Form
    {
        startWindow startWindow = new startWindow();

        Sportsman sportsman = new Sportsman();

        public registrFormSolo()
        {
            InitializeComponent();

            if (FirstTrainer_checkBox.Checked == false)
            {
                FirstTrainer_groupBox.ForeColor = Color.Gray;
            }
            if (SecondTrainer_checkBox.Checked == false)
            {
                SecondTrainer_groupBox.ForeColor = Color.Gray;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            startWindow.Show();
            Controller.myConnection.Close();///////////

            startWindow.registratorButton.Visible = false;
            startWindow.secretaryButton.Visible = false;
            startWindow.Exit_button.Visible = false;

            startWindow.backButton.Visible = true;
            startWindow.solistButton.Visible = true;
            startWindow.duetButton.Visible = true;
            startWindow.sekwayButton.Visible = true;
            startWindow.ansamblButton.Visible = true;
        }

        private void registrForm_Load(object sender, EventArgs e)
        {
         
        }

        private void registrForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            startWindow.Show();
            Controller.myConnection.Close();///////////

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
            if (checkAllBoxes())
            {
                sportsman.Name = Name_textBox.Text;
                sportsman.Surname = Surname_textBox.Text;
                sportsman.Patronymic = Patronymic_textBox.Text;

                sportsman.BirthDate = new MyDate();
                sportsman.BirthDate.Day = DayOfBirth_comboBox.SelectedIndex + 1;
                sportsman.BirthDate.Mounth = MounthOfBirth_comboBox.SelectedIndex + 1;
                sportsman.BirthDate.Year = 2020 - YearOfBirth_comboBox.SelectedIndex;

                sportsman.BookNumber = Convert.ToInt32(BookNumber_textBox.Text);

                sportsman.ClubName = ClubName_textBox.Text;
                sportsman.City = City_textBox.Text;

                sportsman.OlderTrainer = new Trainer(NameOfOldTrainer_textBox.Text, SurnameOfOldTrainer_textBox.Text, PatronymicOfOldTrainer_textBox.Text, 1);

                sportsman.AgeCategory = Convert.ToString(AgeCategory_comboBox.SelectedItem);
                sportsman.SportClass = Convert.ToString(SportClass_comboBox.SelectedItem);
                sportsman.SportCategory = Convert.ToString(SportCategory_comboBox.SelectedItem);

                MessageBox.Show($"Новый спортсмен \nФамилия: {sportsman.Surname}\nИмя: {sportsman.Name}\nОтчество: {sportsman.Patronymic}" +
                    $"\nНомер Книжки: {sportsman.BookNumber}\nГород: {sportsman.City}\nВозростная Категория: {sportsman.AgeCategory}" +
                    $"\nСпортивный Класс: {sportsman.SportClass}\nРазраяд: {sportsman.SportCategory}\nСтарший тренер: {sportsman.OlderTrainer.Name} {sportsman.OlderTrainer.Surname}");

                Controller.insertInSportDB(sportsman);
                Controller.insertTrainer(sportsman.OlderTrainer, sportsman.BookNumber);
            }
            else
                MessageBox.Show("Не все необходимые поля заполнены!");
        }

        public bool checkAllBoxes()
        {
            if (Name_textBox.Text != "" && Surname_textBox.Text != "" && Patronymic_textBox.Text != "" && BookNumber_textBox.Text != "" &&
                ClubName_textBox.Text != "" && NameOfOldTrainer_textBox.Text != "" && SurnameOfOldTrainer_textBox.Text != "" &&
                City_textBox.Text != "" && DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 && 
                YearOfBirth_comboBox.SelectedIndex != -1 && AgeCategory_comboBox.SelectedIndex != -1 && SportCategory_comboBox.SelectedIndex != -1
                && SportClass_comboBox.SelectedIndex != -1 && NameOfOldTrainer_textBox.Text != "" && SurnameOfOldTrainer_textBox.Text != ""
                && PatronymicOfOldTrainer_textBox.Text != "")
            return true;
            return false;
        }

        private void FirstTrainer_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (FirstTrainer_checkBox.Checked == true)
                FirstTrainer_groupBox.ForeColor = Color.Black;
            else
                FirstTrainer_groupBox.ForeColor = Color.Gray;
        }

        private void SecondTrainer_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SecondTrainer_checkBox.Checked == true)
                SecondTrainer_groupBox.ForeColor = Color.Black;
            else
                SecondTrainer_groupBox.ForeColor = Color.Gray;
        }

        private void openDataBasaButton_Click(object sender, EventArgs e)
        {
            DataBasaViewer DBForm = new DataBasaViewer();
            DBForm.Show();
        }

        private void DayOfBirth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategory_comboBox);
        }

        private void MounthOfBirth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategory_comboBox);
        }

        private void YearOfBirth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategory_comboBox);
        }

        /*public void AgeCategoryAutoFill(ComboBox DayOfBirth_comboBox, ComboBox MounthOfBirth_comboBox, ComboBox YearOfBirth_comboBox, ComboBox AgeCategory_comboBox)
        {
            if (DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 && YearOfBirth_comboBox.SelectedIndex != -1)
            {
                DateTime cureDate = DateTime.Now;
                MyDate curMyDate = new MyDate(cureDate.Day, cureDate.Month, cureDate.Year);
                MyDate birthDate = new MyDate(DayOfBirth_comboBox.SelectedIndex + 1, MounthOfBirth_comboBox.SelectedIndex + 1, 2020 - YearOfBirth_comboBox.SelectedIndex);
                int differ;

                differ = curMyDate.Year - birthDate.Year;
                MessageBox.Show(Convert.ToString(curMyDate.Year - birthDate.Year));

                switch (differ)
                {
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 0:
                        AgeCategory_comboBox.SelectedIndex = 1;
                        break;
                    case 10:
                    case 11:
                        AgeCategory_comboBox.SelectedIndex = 2;
                        break;
                    case 12:
                    case 13:
                        AgeCategory_comboBox.SelectedIndex = 3;
                        break;
                    case 14:
                    case 15:
                        AgeCategory_comboBox.SelectedIndex = 4;
                        break;
                    case 16:
                    case 17:
                    case 18:
                        AgeCategory_comboBox.SelectedIndex = 5;
                        break;
                    case 19:
                    case 20:
                        AgeCategory_comboBox.SelectedIndex = 6;
                        break;
                    default:
                        AgeCategory_comboBox.SelectedIndex = 7;
                        break;
                }
            }
        }
        */
        private void searchByBook_Button_Click(object sender, EventArgs e)
        {
            if (BookNumber_textBox.Text != "")
                try
                {
                    sportsman = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber_textBox.Text));
                    autoFilling(sportsman);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}");
                }
            else
            {
                MessageBox.Show("Заполните поле 'Номер Книжки'");
            }
        }

        public void autoFilling(Sportsman sportsman)
        {
            Name_textBox.Text = sportsman.Name;
            Surname_textBox.Text = sportsman.Surname;
            Patronymic_textBox.Text = sportsman.Patronymic;

            DayOfBirth_comboBox.SelectedIndex = sportsman.BirthDate.Day - 1;
            MounthOfBirth_comboBox.SelectedIndex = sportsman.BirthDate.Mounth - 1;
            if (sportsman.BirthDate.Year > 0)
                YearOfBirth_comboBox.SelectedIndex = 2020 - sportsman.BirthDate.Year;

            ClubName_textBox.Text = sportsman.ClubName;
            City_textBox.Text = sportsman.City;

            switch (sportsman.SportCategory)
            {
                case "Ю-I":
                    SportCategory_comboBox.SelectedIndex = 0;
                    break;

                case "Ю-II":
                    SportCategory_comboBox.SelectedIndex = 1;
                    break;

                case "Ю-III":
                    SportCategory_comboBox.SelectedIndex = 2;
                    break;

                case "Вз-I":
                    SportCategory_comboBox.SelectedIndex = 3;
                    break;

                case "Вз-II":
                    SportCategory_comboBox.SelectedIndex = 4;
                    break;

                case "Вз-III":
                    SportCategory_comboBox.SelectedIndex = 5;
                    break;

                case "КМС":
                    SportCategory_comboBox.SelectedIndex = 6;
                    break;

                case "МС":
                    SportCategory_comboBox.SelectedIndex = 7;
                    break;

                case "МСМК":
                    SportCategory_comboBox.SelectedIndex = 8;
                    break;
            }

            switch (sportsman.SportClass)
            {
                case "H": case "Н":
                    SportClass_comboBox.SelectedIndex = 0;
                    break;

                case "E": case "Е":
                    SportClass_comboBox.SelectedIndex = 1;
                    break;

                case "Д":
                    SportClass_comboBox.SelectedIndex = 2;
                    break;

                case "C": case "С":
                    SportClass_comboBox.SelectedIndex = 3;
                    break;

                case "B": case "В":
                    SportClass_comboBox.SelectedIndex = 4;
                    break;

                case "A": case "А":
                    SportClass_comboBox.SelectedIndex = 5;
                    break;

                case "S":
                    SportClass_comboBox.SelectedIndex = 6;
                    break;

                case "M": case "М":
                    SportClass_comboBox.SelectedIndex = 7;
                    break;
            }

            SurnameOfOldTrainer_textBox.Text = sportsman.OlderTrainer.Surname;
            NameOfOldTrainer_textBox.Text = sportsman.OlderTrainer.Name;
            PatronymicOfOldTrainer_textBox.Text = sportsman.OlderTrainer.Patronymic;
        }

    }
}

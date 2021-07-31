using ADOX;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Drawing.Printing;
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

        //List<CheckBox> danceCheckList = new List<CheckBox>();

        List<string> AgeCategoryList = new List<string> {"Д-0", "Д-1", "Д-2", "Ю-1", "Ю-2", "М-1", "М-2", "Вз", "Другой" };
        List<string> GroupAgeCategoryList = new List<string> { "Д-0", "Д-1", "Д-2", "Ю-1", "Ю-2", "М-1", "М-2", "Вз", "Другой" };

        //List<string> GroupCategoryList = new List<string>();

        public string folderName;

        int participantNumber;

        TournirClass tournir = new TournirClass();

        public registrFormSolo()
        {
            InitializeComponent();

            sportsman = new Sportsman();

            //if (FirstTrainer_checkBox.Checked == false)
            //{
            //    FirstTrainer_groupBox.ForeColor = Color.Gray;
            //}
            //if (SecondTrainer_checkBox.Checked == false)
            //{
            //    SecondTrainer_groupBox.ForeColor = Color.Gray;
            //}

            //danceCheckList.Add(danceCheckBox1);
            //danceCheckList.Add(danceCheckBox2);
            //danceCheckList.Add(danceCheckBox3);
            //danceCheckList.Add(danceCheckBox4);
            //danceCheckList.Add(danceCheckBox5);
            //danceCheckList.Add(danceCheckBox6);
            //danceCheckList.Add(danceCheckBox7);
            //danceCheckList.Add(danceCheckBox8);
            //danceCheckList.Add(danceCheckBox9);
            //danceCheckList.Add(danceCheckBox10);
            ParticipantsDataGridView.Visible = false;
        }
        public registrFormSolo(string Path):this()
        {
            this.Path_textBox.Text = Path;
        }
        private void backButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            startWindow.Show();
            startWindow.path = Path_textBox.Text;
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
            try
            {
                clearAllBoxes();
                String[] printers = PrinterSettings.InstalledPrinters.Cast<string>().ToArray();
                for (int i = 0; i < printers.Length; i++)
                    if (new PrinterSettings() { PrinterName = printers[i] }.IsDefaultPrinter)
                        printerName_TextBox.Text = printers[i];
                SportCategory_comboBox.SelectedIndex = SportCategory_comboBox.Items.Count - 1;
                SportClass_comboBox.SelectedIndex = SportClass_comboBox.Items.Count - 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void registrForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            startWindow.Show();
            startWindow.path = Path_textBox.Text;
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
                sportsman = new Sportsman();
                sportsman.Name = Name_textBox.Text;
                sportsman.Surname = Surname_textBox.Text;
                sportsman.Patronymic = Patronymic_textBox.Text;
                sportsman.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList);
                //sportsman.NumberInTournir = Convert.ToInt32(duetNumber_textBox.Text);
                //sportsman.BirthDate = new DateTime(2020 - YearOfBirth_comboBox.SelectedIndex, MounthOfBirth_comboBox.SelectedIndex + 1, DayOfBirth_comboBox.SelectedIndex + 1);
                sportsman.BirthDate.Day = DayOfBirth_comboBox.SelectedIndex + 1;
                sportsman.BirthDate.Month = MounthOfBirth_comboBox.SelectedIndex + 1;
                sportsman.BirthDate.Year = 2020 - YearOfBirth_comboBox.SelectedIndex;
                participantNumber = (SecretaryController.TakeMax("Номер_Пары", "participants", Path_textBox.Text) + 1);

                sportsman.DuetNumber = participantNumber;

                sportsman.GroupNumber = Convert.ToInt32(groupNumber_comboBox.SelectedIndex + 1);
                //MessageBox.Show("sportsman.GroupNumber " + sportsman.GroupNumber.ToString());

                sportsman.NumberInGroup = SecretaryController.TakeMax("Номер_В_Группе", "duets", "Номер_Группы", sportsman.GroupNumber, Path_textBox.Text) + 1;//Convert.ToInt32(duetNumber_textBox.Text);

                sportsman.NumberInTournir = SecretaryController.TakeMax("Номер", "participants", Path_textBox.Text) + 1;//Convert.ToInt32(duetNumber_textBox.Text);

                sportsman.ClubName = ClubName_textBox.Text;
                sportsman.City = City_textBox.Text;

                sportsman.OlderTrainer = new Trainer(NameOfOldTrainer_textBox.Text, SurnameOfOldTrainer_textBox.Text, PatronymicOfOldTrainer_textBox.Text, "Старший");
                //if (FirstTrainer_checkBox.Checked)
                sportsman.FirstTrainer = new Trainer(NameFirstTrainer_textBox.Text, SurnameFirstTrainer_textBox.Text, PatronymicFirstTrainer_textBox.Text, "Первый");
                if (SecondTrainer_checkBox.Checked)
                    sportsman.SecondTrainer = new Trainer(NameSecondTrainer_textBox.Text, SurnameSecondTrainer_textBox.Text, PatronymicSecondTrainer_textBox.Text, "Второй");

                //sportsman.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, GroupAgeCategoryList);
                //if (sportsman.AgeCategory == "0")
                //{
                //    MessageBox.Show("Процесс регистрации прерван. Ни одна из категория группы не подходит возрасту спортсмена!");
                //    return;
                //}

                //Controller.checkAgeCategory(sportsman.AgeCategory, GroupAgeCategoryList);
                //string retstr = "";
                //for (int g = 0; g < GroupAgeCategoryList.Count; g++)
                //{
                //    retstr += GroupAgeCategoryList[g];
                //}
                //MessageBox.Show(retstr);

                if (!GroupAgeCategoryList.Contains(sportsman.AgeCategory) && !GroupAgeCategoryList.Contains("Другая"))
                {
                    MessageBox.Show("В группее нет категорий, подходящих спортсмену!");
                    return;
                }

                sportsman.SportClass = Convert.ToString(SportClass_comboBox.SelectedItem);
                sportsman.SportCategory = Convert.ToString(SportCategory_comboBox.SelectedItem);

                MessageBox.Show($"Новый спортсмен \nФамилия: {sportsman.Surname}\nИмя: {sportsman.Name}\nОтчество: {sportsman.Patronymic}" +
                    $"\nГород: {sportsman.City}\nВозрастная Категория: {sportsman.AgeCategory}" +
                    $"\nСпортивный Класс: {sportsman.SportClass}\nРазряд: {sportsman.SportCategory}\nСтарший тренер: {sportsman.OlderTrainer.Name} {sportsman.OlderTrainer.Surname}");

                //////Controller.insertInSportDB(sportsman);
                int OldTrainerNumber = SecretaryController.checkTrainerExist(sportsman.OlderTrainer, Path_textBox.Text);
                if (OldTrainerNumber == 0)
                    sportsman.OlderTrainer.Number = SecretaryController.insertTrainer(sportsman.OlderTrainer, sportsman.DuetNumber, Path_textBox.Text); //RETURN TRAINER NUMBER
                else
                    sportsman.OlderTrainer.Number = OldTrainerNumber;

                int FirstTrainerNumber = 0;
                FirstTrainerNumber = SecretaryController.checkTrainerExist(sportsman.FirstTrainer, Path_textBox.Text);
                //if (FirstTrainer_checkBox.Checked)
                if (FirstTrainerNumber == 0)
                    sportsman.FirstTrainer.Number = SecretaryController.insertTrainer(sportsman.FirstTrainer, sportsman.DuetNumber, Path_textBox.Text);
                else
                    sportsman.FirstTrainer.Number = FirstTrainerNumber;

                int SecondTrainerNumber = 0;
                SecondTrainerNumber = SecretaryController.checkTrainerExist(sportsman.SecondTrainer, Path_textBox.Text);
                if (SecondTrainer_checkBox.Checked)
                    if (SecondTrainerNumber == 0)
                        sportsman.SecondTrainer.Number = SecretaryController.insertTrainer(sportsman.SecondTrainer, sportsman.DuetNumber, Path_textBox.Text);
                    else
                        sportsman.SecondTrainer.Number = SecondTrainerNumber;
                SecretaryController.insertInParticipants(sportsman, 1, Path_textBox.Text);
                //SecretaryController.insertInParticipants(sportsman, Path_textBox.Text);
                //if (setNumber_comboBox.SelectedIndex != -1)
                SecretaryController.insertParticipantsInDuet(Convert.ToInt32(duetNumber_textBox.Text), sportsman, Convert.ToInt32(groupNumber_comboBox.Text), Path_textBox.Text);

                //printing number
                string retFolderName = "";
               
                if (advCheckBox.Checked)
                    retFolderName = pdf_controller.getNumberCard_largeWithAdv(Path_textBox.Text, tournir.groups[groupNumber_comboBox.SelectedIndex].number.ToString() + ") " + tournir.groups[groupNumber_comboBox.SelectedIndex].name, sportsman, new Sportsman(), Convert.ToInt32(duetNumber_textBox.Text), advTextBox.Text);
                else
                    retFolderName = pdf_controller.getNumberCard_largeWithAdv(Path_textBox.Text, tournir.groups[groupNumber_comboBox.SelectedIndex].number.ToString() + ") " + tournir.groups[groupNumber_comboBox.SelectedIndex].name, sportsman, new Sportsman(), Convert.ToInt32(duetNumber_textBox.Text), tournir.name);
                if (checkBoxPrintNumber.Checked)
                {
                    printing_controller.PrintWord(printerName_TextBox.Text, retFolderName);
                }

                duetNumber_textBox.Text = (Convert.ToInt32(duetNumber_textBox.Text) + 1).ToString();
                clearAllBoxes();

                SportCategory_comboBox.SelectedIndex = SportCategory_comboBox.Items.Count - 1;
                SportClass_comboBox.SelectedIndex = SportClass_comboBox.Items.Count - 1;
            }
            else
                MessageBox.Show("Не все необходимые поля заполнены!");
        }

        public void clearAllBoxes()
        {
            Name_textBox.Text = "";
            Surname_textBox.Text = "";
            Patronymic_textBox.Text = "";
            ClubName_textBox.Text = "";
            NameOfOldTrainer_textBox.Text = "";
            SurnameOfOldTrainer_textBox.Text = "";
            City_textBox.Text = "";

            DayOfBirth_comboBox.SelectedIndex = -1;
            MounthOfBirth_comboBox.SelectedIndex = -1;
            YearOfBirth_comboBox.SelectedIndex = -1;
            SportCategory_comboBox.SelectedIndex = -1;
            SportClass_comboBox.SelectedIndex = -1;

            //duetNumber_textBox.Text = "";

            //FirstTrainer_checkBox.Checked = false;
            SurnameFirstTrainer_textBox.Text = "";
            NameFirstTrainer_textBox.Text = "";
            PatronymicFirstTrainer_textBox.Text = "";

            SecondTrainer_checkBox.Checked = false;
            SurnameSecondTrainer_textBox.Text = "";
            NameSecondTrainer_textBox.Text = "";
            PatronymicSecondTrainer_textBox.Text = "";
        }

        public bool checkAllBoxes()
        {
            if (Name_textBox.Text != "" && Surname_textBox.Text != "" && Patronymic_textBox.Text != "" &&
                ClubName_textBox.Text != "" && NameOfOldTrainer_textBox.Text != "" && SurnameOfOldTrainer_textBox.Text != "" &&
                City_textBox.Text != "" && DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 &&
                YearOfBirth_comboBox.SelectedIndex != -1 && SportCategory_comboBox.SelectedIndex != -1
                && SportClass_comboBox.SelectedIndex != -1 && groupNumber_comboBox.SelectedIndex != -1 && duetNumber_textBox.Text != "" && Path_textBox.Text != ""
                && (SurnameFirstTrainer_textBox.Text != "" && NameFirstTrainer_textBox.Text != "" && PatronymicFirstTrainer_textBox.Text != "")
                && ((SecondTrainer_checkBox.Checked && SurnameSecondTrainer_textBox.Text != "" && NameSecondTrainer_textBox.Text != "" && PatronymicSecondTrainer_textBox.Text != "") || (!SecondTrainer_checkBox.Checked)))
                
            return true;
            return false;
        }

        private void FirstTrainer_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //if (FirstTrainer_checkBox.Checked == true)
            //    FirstTrainer_groupBox.ForeColor = Color.Black;
            //else
            //    FirstTrainer_groupBox.ForeColor = Color.Gray;
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

        private void DayOfBirth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    MessageBox.Show(Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList/* AgeCategory_comboBox, CategoryOfDancing_comboBox*/));
            if (DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 && YearOfBirth_comboBox.SelectedIndex != -1)
               sportsman.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList);
            //Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman.AgeCategory), SportClass_comboBox);
            //MessageBox.Show(sportsman.AgeCategory);
        }

        private void MounthOfBirth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //    Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList, sportsman/* AgeCategory_comboBox/*, CategoryOfDancing_comboBox*/);
            if (DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 && YearOfBirth_comboBox.SelectedIndex != -1)
                sportsman.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList);
            //Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman.AgeCategory), SportClass_comboBox);
        }

        private void YearOfBirth_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //   Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList, sportsman/* AgeCategory_comboBox, CategoryOfDancing_comboBox*/);
            if (DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 && YearOfBirth_comboBox.SelectedIndex != -1)
                sportsman.AgeCategory = Controller.AgeCategoryAutoFill(DayOfBirth_comboBox, MounthOfBirth_comboBox, YearOfBirth_comboBox, AgeCategoryList);
            //Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman.AgeCategory), SportClass_comboBox);
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

        //private void searchByBook_Button_Click(object sender, EventArgs e)
        //{
        //    if (BookNumber_textBox.Text != "")
        //        try
        //        {
        //            sportsman = Controller.SearchByBookNumber(Convert.ToInt32(BookNumber_textBox.Text));
        //            autoFilling(sportsman);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show($"{ex.Message}");
        //        }
        //    else
        //    {
        //        MessageBox.Show("Заполните поле 'Номер Книжки'");
        //    }
        //}

        public void autoFilling(Sportsman sportsman)
        {
            Name_textBox.Text = sportsman.Name;
            Surname_textBox.Text = sportsman.Surname;
            Patronymic_textBox.Text = sportsman.Patronymic;

            DayOfBirth_comboBox.SelectedIndex = sportsman.BirthDate.Day - 1;
            MounthOfBirth_comboBox.SelectedIndex = sportsman.BirthDate.Month - 1;
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
            groupNumber_comboBox.Items.Clear();
            groupName_textBox.Text = "";
            GroupAgeCategoryList.Clear();

            folderName = Path_textBox.Text;
            try
            {
                tournir = SecretaryController.TakeTournir(folderName);
                for (int i = 0; i < tournir.groups.Count; i++)
                {
                    groupNumber_comboBox.Items.Add(tournir.groups[i].number);
                    //MessageBox.Show("Категорий в группе " + (i + 1).ToString() + " " + tournir.groups[i].number.ToString());
                    for (int j = 0; j < tournir.groups[i].CategoryList.Count; j++)
                        if (!GroupAgeCategoryList.Contains(tournir.groups[i].CategoryList[j]))
                        {
                            //MessageBox.Show(tournir.groups[i].CategoryList[j]);
                            GroupAgeCategoryList.Add(tournir.groups[i].CategoryList[j]);
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void groupNumber_comboBox_SelectedIndexChanged(object sender, EventArgs e)
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
                    //MessageBox.Show(tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList.Count.ToString());
                    for (int i = 0; i < tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList.Count; i++)
                    {
                        GroupAgeCategoryList.Add(tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList[i].Replace(" ", string.Empty));
                        retstr += tournir.groups[groupNumber_comboBox.SelectedIndex].CategoryList[i].Replace(" ", string.Empty);
                    }
                    groupName_textBox.Text = tournir.groups[groupNumber_comboBox.SelectedIndex].name + " (пар(солистов): " + tournir.groups[groupNumber_comboBox.SelectedIndex].duetList.Count + ")"; ;
                    //MessageBox.Show(retstr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void AgeCategory_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Controller.takeSportClassSet(AgeCategoryList.IndexOf(sportsman.AgeCategory), ref SportClass_comboBox);
            }
            catch (Exception ex)
            {
                MessageBox.Show("При определении списка доступных классов произошла ошибка!" + ex.Message);
            }
        }

        private void registrFormSolo_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 900)
                this.Size = new Size(900, this.Size.Height);
            if (this.Size.Height < 530)
                this.Size = new Size(this.Size.Width, 530);
        }

        private void Sportsman_groupBox_Enter(object sender, EventArgs e)
        {

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
    }
}

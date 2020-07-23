using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    class Controller
    {
        public static string connectString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\People.mdb";
        public static OleDbConnection myConnection = new OleDbConnection(connectString);

        public static OleDbCommand command = new OleDbCommand("", myConnection);


        public static void insertInSportDB(Sportsman sportsman)
        {
            OleDbCommand command = new OleDbCommand("", myConnection);

            command.CommandText = "INSERT INTO Sportsmans(НомерКнижки, Фамилия, Имя, Отчество, НазваниеКлуба, Город, ДатаРождения, СпортивныйКласс, Разряд)" + "VALUES (@BookNumber,@Surname,@Name,@Patronymic,@ClubName,@City,@BirthDate,@SportClass,@SportCategory)";

            command.Parameters.AddWithValue("BookNumber", sportsman.BookNumber);
            command.Parameters.AddWithValue("Surname", sportsman.Surname);
            command.Parameters.AddWithValue("Name", sportsman.Name);
            command.Parameters.AddWithValue("Patronymic", sportsman.Patronymic);
            command.Parameters.AddWithValue("ClubName", sportsman.ClubName);
            command.Parameters.AddWithValue("City", sportsman.City);
            command.Parameters.AddWithValue("BirthDate", sportsman.BirthDate.ToString());
            command.Parameters.AddWithValue("SportClass", sportsman.SportClass);
            command.Parameters.AddWithValue("SportCategory", sportsman.SportCategory);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Попытка повторного ввода номера книжки:\n{sportsman.BookNumber}\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void insertTrainer(Trainer trainer, int bookNumber)
        {
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            commandTrain.CommandText = "INSERT INTO Trainers(НомерКнижки, Код,Фамилия, Имя, Отчество)" + "VALUES (@bookNumber, @Pas,@Surname,@Name,@Patronymic)";
            
            trainer.pasItendificate();
            commandTrain.Parameters.AddWithValue("booknumber", bookNumber);
            commandTrain.Parameters.AddWithValue("Pas", trainer.Pas);
            commandTrain.Parameters.AddWithValue("Surname", trainer.Surname);
            commandTrain.Parameters.AddWithValue("Name", trainer.Name);
            commandTrain.Parameters.AddWithValue("Patronymic", trainer.Patronymic);

            try
            {
                commandTrain.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Sportsman SearchByBookNumber(int BookNumber)
        {
            Sportsman sportsman = new Sportsman();

            OleDbCommand command1 = new OleDbCommand("", myConnection);

            OleDbCommand command2 = new OleDbCommand("", myConnection);
            OleDbCommand command3 = new OleDbCommand("", myConnection);

            OleDbCommand command4 = new OleDbCommand("", myConnection);
            OleDbCommand command5 = new OleDbCommand("", myConnection);

            OleDbCommand command6 = new OleDbCommand("", myConnection);

            OleDbCommand command7 = new OleDbCommand("", myConnection);

            OleDbCommand command8 = new OleDbCommand("", myConnection);



            OleDbCommand command9 = new OleDbCommand("", myConnection); //OldTrainer.Surname
            OleDbCommand command10 = new OleDbCommand("", myConnection);//OldTrainer.Name
            OleDbCommand command11 = new OleDbCommand("", myConnection);//OldTrainer.Patronymic


            command1.CommandText = "SELECT Фамилия FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command1.Parameters.AddWithValue("BookNum", BookNumber);

            command2.CommandText = "SELECT Имя FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command2.Parameters.AddWithValue("BookNum", BookNumber);

            command3.CommandText = "SELECT Отчество FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command3.Parameters.AddWithValue("BookNum", BookNumber);

            command4.CommandText = "SELECT НазваниеКлуба FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command4.Parameters.AddWithValue("BookNum", BookNumber);

            command5.CommandText = "SELECT Город FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command5.Parameters.AddWithValue("BookNum", BookNumber);

            command6.CommandText = "SELECT ДатаРождения FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command6.Parameters.AddWithValue("BookNum", BookNumber);

            command7.CommandText = "SELECT СпортивныйКласс FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command7.Parameters.AddWithValue("BookNum", BookNumber);

            command8.CommandText = "SELECT Разряд FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command8.Parameters.AddWithValue("BookNum", BookNumber);



            command9.CommandText = "SELECT Фамилия FROM Trainers WHERE НомерКнижки = @BookNum";
            command9.Parameters.AddWithValue("BookNum", BookNumber);

            command10.CommandText = "SELECT Имя FROM Trainers WHERE НомерКнижки = @BookNum";
            command10.Parameters.AddWithValue("BookNum", BookNumber);

            command11.CommandText = "SELECT Отчество FROM Trainers WHERE НомерКнижки = @BookNum";
            command11.Parameters.AddWithValue("BookNum", BookNumber);

            try
            {
                sportsman.Surname = command1.ExecuteScalar().ToString();
           
                sportsman.Name = command2.ExecuteScalar().ToString();
                sportsman.Patronymic = command3.ExecuteScalar().ToString();
                sportsman.ClubName = command4.ExecuteScalar().ToString();
                sportsman.City = command5.ExecuteScalar().ToString();
                sportsman.BirthDate.ToInt(command6.ExecuteScalar().ToString());

                MessageBox.Show(sportsman.BirthDate.ToString());

                sportsman.SportClass = command7.ExecuteScalar().ToString();
                sportsman.SportCategory = command8.ExecuteScalar().ToString();

                sportsman.OlderTrainer.Surname = command9.ExecuteScalar().ToString();
                sportsman.OlderTrainer.Name = command10.ExecuteScalar().ToString();
                sportsman.OlderTrainer.Patronymic = command11.ExecuteScalar().ToString();
            }
            catch (System.NullReferenceException ex)
            {
                MessageBox.Show("Спортсмен не найден!\n" + ex.Message);
            }
            return sportsman;
        }

        public static void AgeCategoryAutoFill(ComboBox DayOfBirth_comboBox, ComboBox MounthOfBirth_comboBox, ComboBox YearOfBirth_comboBox, ComboBox AgeCategory_comboBox)
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

    }
}

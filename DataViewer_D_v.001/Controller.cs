using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace DataViewer_D_v._001
{
    public class Controller
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

            commandTrain.CommandText = "INSERT INTO Trainers(НомерКнижки, Код, Фамилия, Имя, Отчество)" + "VALUES (@bookNumber, @Pas, @Surname, @Name, @Patronymic)";

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

            command10.CommandText = "SELECT Имя FROM Trainers НомерКнижки WHERE НомерКнижки = @BookNum";
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

                //MessageBox.Show(sportsman.BirthDate.ToString());

                sportsman.SportClass = command7.ExecuteScalar().ToString();
                sportsman.SportCategory = command8.ExecuteScalar().ToString();

                sportsman.OlderTrainer.Surname = command9.ExecuteScalar().ToString();
                sportsman.OlderTrainer.Name = command10.ExecuteScalar().ToString();
                sportsman.OlderTrainer.Patronymic = command11.ExecuteScalar().ToString();
            }
            catch (/*System.NullReferenceException*/Exception ex)
            {
                //MessageBox.Show("Спортсмен не найден!\n" + ex.Message);
                MessageBox.Show("Что-то пошло не так! \n" + ex.Message);
                //sportsman.Name = "NotDefined";
            }
            return sportsman;
        }

        public static Sportsman SearchByBookNumberShort(int BookNumber)
        {
            Sportsman sportsman = new Sportsman();

            OleDbCommand command1 = new OleDbCommand("", myConnection);

            OleDbCommand command2 = new OleDbCommand("", myConnection);
            OleDbCommand command3 = new OleDbCommand("", myConnection);

            OleDbCommand command4 = new OleDbCommand("", myConnection);
            OleDbCommand command5 = new OleDbCommand("", myConnection);

            OleDbCommand command6 = new OleDbCommand("", myConnection);

            OleDbCommand command7 = new OleDbCommand("", myConnection);


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

            command6.CommandText = "SELECT СпортивныйКласс FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command6.Parameters.AddWithValue("BookNum", BookNumber);

            command7.CommandText = "SELECT Разряд FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command7.Parameters.AddWithValue("BookNum", BookNumber);

            try
            {
                sportsman.Surname = command1.ExecuteScalar().ToString();
                sportsman.Name = command2.ExecuteScalar().ToString();
                sportsman.Patronymic = command3.ExecuteScalar().ToString();
                sportsman.ClubName = command4.ExecuteScalar().ToString();
                sportsman.City = command5.ExecuteScalar().ToString();

            //MessageBox.Show(sportsman.BirthDate.ToString());

                sportsman.SportClass = command6.ExecuteScalar().ToString();
                sportsman.SportCategory = command7.ExecuteScalar().ToString();
            }
            catch (/*System.NullReferenceException*/Exception ex)
            {
                MessageBox.Show("Что-то пошло не так! \n" + ex.Message);
            }
            return sportsman;
        }

        public static void AgeCategoryAutoFill(ComboBox DayOfBirth_comboBox, ComboBox MounthOfBirth_comboBox, ComboBox YearOfBirth_comboBox, ComboBox AgeCategory_comboBox, ComboBox CategoryOfDancing_comboBox)
        {
            try
            {
                if (DayOfBirth_comboBox.SelectedIndex != -1 && MounthOfBirth_comboBox.SelectedIndex != -1 && YearOfBirth_comboBox.SelectedIndex != -1)
                {
                    DateTime cureDate = DateTime.Now;

                    //MessageBox.Show((DayOfBirth_comboBox.SelectedIndex + 1).ToString() + (MounthOfBirth_comboBox.SelectedIndex + 1).ToString() + (2020 - YearOfBirth_comboBox.SelectedIndex).ToString());

                    DateTime birthDate = new DateTime(Convert.ToInt16(2020 - YearOfBirth_comboBox.SelectedIndex), Convert.ToInt16(MounthOfBirth_comboBox.SelectedIndex + 1), Convert.ToInt16(DayOfBirth_comboBox.SelectedIndex + 1));

                    //MessageBox.Show("Сейчас " + cureDate.ToString());
                    //MessageBox.Show("Дата рожд. " + birthDate.ToShortDateString());
                    DateTime differ = new DateTime((cureDate - birthDate).Ticks);

                    //MessageBox.Show(differ.ToShortDateString());

                    switch (differ.Year)
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
                            CategoryOfDancing_comboBox.SelectedIndex = 1;
                            break;
                        case 10:
                        case 11:
                            AgeCategory_comboBox.SelectedIndex = 2;
                            CategoryOfDancing_comboBox.SelectedIndex = 2;
                            break;
                        case 12:
                        case 13:
                            AgeCategory_comboBox.SelectedIndex = 3;
                            CategoryOfDancing_comboBox.SelectedIndex = 3;
                            break;
                        case 14:
                        case 15:
                            AgeCategory_comboBox.SelectedIndex = 4;
                            CategoryOfDancing_comboBox.SelectedIndex = 4;
                            break;
                        case 16:
                        case 17:
                        case 18:
                            AgeCategory_comboBox.SelectedIndex = 5;
                            CategoryOfDancing_comboBox.SelectedIndex = 5;
                            break;
                        case 19:
                        case 20:
                            AgeCategory_comboBox.SelectedIndex = 6;
                            CategoryOfDancing_comboBox.SelectedIndex = 6;
                            break;
                        default:
                            AgeCategory_comboBox.SelectedIndex = 0;
                            CategoryOfDancing_comboBox.SelectedIndex = 0;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Спортсмену не подходит ни одна из категорий группы!\n" + ex.Message);
            }
        }

        public static BitArray GapCounter(string rowName, string tableName, OleDbConnection cn)
        {
            int k = 0, i = 1;//, counter = 1;
            OleDbCommand command1 = new OleDbCommand($"SELECT MAX({rowName}) FROM {tableName}", cn);
            BitArray retArr = new BitArray(0);

            try
            {
                if (command1.ExecuteScalar() != DBNull.Value)
                {
                    k = Convert.ToInt32(command1.ExecuteScalar().ToString());
                    retArr = new BitArray(k);

                    while (i <= k)
                    {
                        OleDbCommand command2 = new OleDbCommand($"SELECT {rowName} FROM {tableName} WHERE {rowName} = @id", cn);
                        command2.Parameters.AddWithValue("id", i);
                        if (command2.ExecuteScalar() == null)
                        {
                            //MessageBox.Show($"Отсутствует эллемент под номером {i}");
                            retArr[i - 1] = false;
                        }
                        else
                            retArr[i - 1] = true;
                        i++;
                    }

                    string mesStr = "";
                    foreach (bool item in retArr)
                    {
                        mesStr += $"{item} ";
                    }
                    //MessageBox.Show(mesStr);
                }
                else
                    MessageBox.Show($"Записей в {rowName} из {tableName} не найдено");
            }
            catch (Exception ex)
            {
                MessageBox.Show("ошибка в GapCounter при обработке " + rowName + " в таблице " + tableName + ex.Message);
            }
            return retArr;
        }

        public static BitArray GapCounter(string rowName, string tableName, string parametrRowName, int parametr, OleDbConnection cn)
        {
            int k = 0, i = 1;//, counter = 1;
            OleDbCommand command1 = new OleDbCommand($"SELECT MAX({rowName}) FROM {tableName} WHERE {parametrRowName} = @num", cn);
            command1.Parameters.AddWithValue("num", parametr);
            BitArray retArr = new BitArray(0);

            try
            {
                if (command1.ExecuteScalar() != DBNull.Value)
                {
                    k = Convert.ToInt32(command1.ExecuteScalar().ToString());
                    //MessageBox.Show($"макс номер захода в группе {parametr}: {k}");
                    retArr = new BitArray(k);

                    while (i <= k)
                    {
                        OleDbCommand command2 = new OleDbCommand($"SELECT {rowName} FROM {tableName} WHERE {rowName} = @id AND {parametrRowName} = @num", cn);
                        command2.Parameters.AddWithValue("id", i);
                        command2.Parameters.AddWithValue("num", parametr);

                        if (command2.ExecuteScalar() == null)
                        {
                            //MessageBox.Show($"Отсутствует эллемент под номером {i}");
                            retArr[i - 1] = false;
                        }
                        else
                            retArr[i - 1] = true;
                        i++;
                    }

                    string mesStr = "";
                    foreach (bool item in retArr)
                    {
                        mesStr += $"{item} ";
                    }
                    //MessageBox.Show(mesStr);
                }
                else
                {
                    MessageBox.Show($"Записей в {rowName} из {tableName} не найдено");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ошибка в GapCounter при обработке " + rowName + " в таблице " + tableName + ex.Message);
            }
            return retArr;
        }

        public static void takeSportClassSet(ComboBox first, ComboBox second)
        {
            second.Items.Clear();
            switch (first.SelectedIndex)
            {
                case 0:
                    second.Items.Add("H");
                    break;
                case 1:
                    second.Items.AddRange(new object[] {"H", "E", "D" });
                    break;
                case 2:
                    second.Items.AddRange(new object[] { "H", "E", "D", "C" });
                    break;
                case 3:
                    second.Items.AddRange(new object[] { "H", "E", "D", "C", "B" });
                    break;
                case 4:
                    second.Items.AddRange(new object[] { "H", "E", "D", "C", "B", "A" });
                    break;
                case 5:
                    second.Items.AddRange(new object[] { "H", "E", "D", "C", "B", "A", "S" });
                    break;
                case 6:
                    second.Items.AddRange(new object[] { "H", "E", "D", "C", "B", "A", "S", "M" });
                    break;
                case 7:
                    second.Items.AddRange(new object[] { "H", "E", "D", "C", "B", "A", "S", "M" });
                    break;
                default:
                    second.Items.Clear();
                    break;
            }
        }
    }
}

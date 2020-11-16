using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.CodeDom;
using System.Collections;

namespace DataViewer_D_v._001
{
    class SecretaryController
    {
        public static string connectString;

        public static OleDbConnection myConnection;

        public static OleDbCommand command = new OleDbCommand("", myConnection);

        public static void insertInJudges(Judge judje, string path)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);

            try
            {
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO judges(ФИО, Категория_Судейства)" + "VALUES (@SNP, @Category)";

                command.Parameters.AddWithValue("SNP", judje.Surname + " " + judje.Name + " " + judje.Patronymic);
                command.Parameters.AddWithValue("Category", judje.JudgeClass);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void insertInParticipants(Sportsman sportsman, string path)
        {
            //try
            //{
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO participants(Номер, Фамилия, Имя, Отчество, Категория, Номер_Группы)" + "VALUES (@Number, @Surname, @Name, @Patronymic, @AgeCategory, @GroupNumber)";

                command.Parameters.AddWithValue("Number", sportsman.NumberInTournir);
                command.Parameters.AddWithValue("Surname", sportsman.Surname);
                command.Parameters.AddWithValue("Name", sportsman.Name);
                command.Parameters.AddWithValue("Patronymic", sportsman.Patronymic);
                command.Parameters.AddWithValue("AgeCategory",sportsman.AgeCategory);
                command.Parameters.AddWithValue("GroupNumber", sportsman.GroupNumber);

                command.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            myConnection.Close();
        }

        public static void insertParticipantsInSet(int number, Sportsman sportsman, int groupNumber, int setNumber, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);
                if (setNumber != -1)
                {
                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Захода, Номер_Книжки1, Тип)" + "VALUES (@Number, @GroupNumber, @SetNumber, @BookNumber, @Type)";
                    //command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber, @Type)";
                    command.Parameters.AddWithValue("Number", number);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    command.Parameters.AddWithValue("SetNumber", setNumber);
                    command.Parameters.AddWithValue("BookNumber", sportsman.BookNumber);
                    command.Parameters.AddWithValue("Type", "Соло");
                }
                else
                {
                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber, @Type)";
                    command.Parameters.AddWithValue("Number", number);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    command.Parameters.AddWithValue("BookNumber", sportsman.BookNumber);
                    command.Parameters.AddWithValue("Type", "Соло");
                }

                MessageBox.Show($"Новый Солист:\n{sportsman.BookNumber}\nГруппа: {groupNumber}\nЗаход: {setNumber}");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при записи очередного солиста...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void insertParticipantsInDuet(int number, Sportsman sportsman, int groupNumber, string path)
        {
            //try
            //{
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, ФИО1, Тип)" + "VALUES (@Number, @GroupNumber, @SNP, @Type)";
                command.Parameters.AddWithValue("Number", number);
                command.Parameters.AddWithValue("GroupNumber", groupNumber);
                command.Parameters.AddWithValue("SNP", sportsman.Surname + ";" + sportsman.Name + ";" + sportsman.Patronymic + ";");
                command.Parameters.AddWithValue("Type", "Соло");

                MessageBox.Show($"Новый Солист:\n{sportsman.BookNumber}\nГруппа: {groupNumber}");

                command.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Упс, что-то пошло не так при записи очередного солиста...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            myConnection.Close();
        }

        public static void insertParticipantsInDuet(int number, Sportsman sportsman1, Sportsman sportsman2, int groupNumber, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);
                if (groupNumber != -1)
                {
                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, ФИО1, ФИО2, Тип)" + "VALUES (@Number, @GroupNumber, @SNP1, @SNP2, @Type)";
                    //command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber1, @BookNumber2, @Type)";

                    command.Parameters.AddWithValue("Number", number);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    //command.Parameters.AddWithValue("SetNumber", setNumber);
                    command.Parameters.AddWithValue("@SNP1", sportsman1.Surname + ";" + sportsman1.Name + ";" + sportsman1.Patronymic + ";");
                    command.Parameters.AddWithValue("@SNP2", sportsman2.Surname + ";" + sportsman2.Name + ";" + sportsman2.Patronymic + ";");
                    command.Parameters.AddWithValue("Type", "Пара");
                }
                else 
                {
                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber1, @BookNumber2, @Type)";

                    command.Parameters.AddWithValue("Number", number);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    command.Parameters.AddWithValue("BookNumber1", sportsman1.BookNumber);
                    command.Parameters.AddWithValue("BookNumber2", sportsman2.BookNumber);
                    command.Parameters.AddWithValue("Type", "Пара");
                }
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при записи очередного пары...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void insertParticipantsInSet(int number, Sportsman sportsman1, Sportsman sportsman2, int groupNumber, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber1, @BookNumber2, @Type)";

                    command.Parameters.AddWithValue("Number", number);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    command.Parameters.AddWithValue("BookNumber1", sportsman1.BookNumber);
                    command.Parameters.AddWithValue("BookNumber2", sportsman2.BookNumber);
                    command.Parameters.AddWithValue("Type", "Пара");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при записи очередного пары...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void insertTrainer(Trainer trainer, int Number)
            {
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            commandTrain.CommandText = "INSERT INTO Trainers(Номер, Код,Фамилия, Имя, Отчество)" + "VALUES (@Number, @Pas,@Surname,@Name,@Patronymic)";

            trainer.pasItendificate();
            commandTrain.Parameters.AddWithValue("Number", Number);
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

                //MessageBox.Show(sportsman.BirthDate.ToString());

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
                //MessageBox.Show(Convert.ToString(curMyDate.Year - birthDate.Year));

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

        public static TournirClass TakeTournir(string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            int Num = 1;

            TournirClass RetTournir = new TournirClass();

            OleDbCommand command1 = new OleDbCommand("", myConnection);
            OleDbCommand command2 = new OleDbCommand("", myConnection);
            OleDbCommand command3 = new OleDbCommand("", myConnection);
            OleDbCommand command4 = new OleDbCommand("", myConnection);
            OleDbCommand command5 = new OleDbCommand("", myConnection);
            OleDbCommand command6 = new OleDbCommand("", myConnection);
            OleDbCommand command7 = new OleDbCommand("", myConnection);

            command1.CommandText = "SELECT Название FROM tournir WHERE ID = @Num";
            command1.Parameters.AddWithValue("Num", Num);

            command2.CommandText = "SELECT Дата_Проведения FROM tournir WHERE ID = @Num";
            command2.Parameters.AddWithValue("Num", Num);

            command3.CommandText = "SELECT Время_Проведения FROM tournir WHERE ID = @Num";
            command3.Parameters.AddWithValue("Num", Num);

            command4.CommandText = "SELECT Место_Проведения FROM tournir WHERE ID = @Num";
            command4.Parameters.AddWithValue("Num", Num);

            command5.CommandText = "SELECT Организация FROM tournir WHERE ID = @Num";
            command5.Parameters.AddWithValue("Num", Num);

            command6.CommandText = "SELECT ФИО_Секретаря FROM tournir WHERE ID = @Num";
            command6.Parameters.AddWithValue("Num", Num);

            command7.CommandText = "SELECT ФИО_Регистратора FROM tournir WHERE ID = @Num";
            command7.Parameters.AddWithValue("Num", Num);

            try
            {
                RetTournir.name = command1.ExecuteScalar().ToString();
                RetTournir.date.ToInt(command2.ExecuteScalar().ToString());
                RetTournir.time.ToInt(command3.ExecuteScalar().ToString());
                RetTournir.place = command4.ExecuteScalar().ToString();
                RetTournir.organisation = command5.ExecuteScalar().ToString();
                RetTournir.secretary = command6.ExecuteScalar().ToString();
                RetTournir.registrator = command7.ExecuteScalar().ToString();

                //MessageBox.Show($"Турнир: {RetTournir.name}\nДата: {RetTournir.date}\nВремя: {RetTournir.time}\nМесто: {RetTournir.place}\nОрганизация: {RetTournir.organisation}\nСекретарь: {RetTournir.secretary}\nРегистратор: {RetTournir.registrator}");
                //myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так... код 1\nError: " + ex.Message);
            } //заполнение Турнира

            try
            {
                int i = 1;
                int k = 0;
                string name = "";

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT COUNT(Номер_Группы) FROM groups";
                k = Convert.ToInt32(command.ExecuteScalar());

                //MessageBox.Show("Количество групп: " + Convert.ToString(k));

                while (i <= k)
                {
                    myConnection = new OleDbConnection(connectString);
                    myConnection.Open();
                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Категория FROM groups WHERE Номер_Группы = @id";
                    command.Parameters.AddWithValue("id", i);
                    name = Convert.ToString(command.ExecuteScalar());
                    RetTournir.groups.Add(new GroupClass(i, RetTournir.name, name));

                    RetTournir.groups[i - 1].CategoryList = TakeCategory(RetTournir.groups[i - 1], cn);
                    RetTournir.groups[i - 1].DancesList = TakeDances(RetTournir.groups[i - 1], cn);
                    RetTournir.groups[i - 1].JudgeList = TakeJudges(RetTournir.groups[i - 1], cn);
                    //MessageBox.Show(RetTournir.groups[i - 1].show());

                    //MessageBox.Show("Вытягивание списка пар");
                    RetTournir.groups[i - 1].duetList = TakeDuets(RetTournir.groups[i - 1], cn);
                    //MessageBox.Show(RetTournir.groups[i - 1].show());
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка групп\nError: " + ex.Message);
            } //заполнение групп

            try
            {
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                BitArray checkArray =  Controller.GapCounter("Номер", "judges", myConnection);

                int i1 = 0;
                int counter = 0;
                int k1 = 0;
                int max = 0;

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT COUNT(Номер) FROM judges";

                command3 = new OleDbCommand("", myConnection);
                command3.CommandText = "SELECT MAX(Номер) FROM judges";

                k1 = Convert.ToInt32(command.ExecuteScalar());
                //MessageBox.Show("Количество судей: " + Convert.ToString(k1));

                if (k1 > 0)
                {
                    max = Convert.ToInt32(command3.ExecuteScalar());
                    //MessageBox.Show("Максимальный номер судьи: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        if (i1 < max)
                            if (checkArray[i1])
                            {
                                Judge judge_new = new Judge();

                                command1 = new OleDbCommand("SELECT ФИО FROM judges WHERE Номер = @id", myConnection); //NSP
                                command1.Parameters.AddWithValue("id", i1 + 1);
                                command2 = new OleDbCommand("SELECT Категория_Судейства FROM judges WHERE Номер = @id", myConnection); //JudjeClass
                                command2.Parameters.AddWithValue("id", i1 + 1);

                                judge_new.ToJudge(command1.ExecuteScalar().ToString());
                                judge_new.JudgeClass = command2.ExecuteScalar().ToString();
                                judge_new.Number = (ushort)(i1 + 1);
                                judge_new.judgeChar = (char)(64 + judge_new.Number);
                                RetTournir.judges.Add(judge_new);
                                //MessageBox.Show(RetTournir.judges[i1 - counter].ToNSP() + " " + RetTournir.judges[i1 - counter].JudgeClass);
                            }
                            else
                            {
                                counter++;
                            }
                        i1++;
                    }
                }
                else
                {
                    //MessageBox.Show($"Не зарегистрировано ниодного судьи!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка судей\nError: " + ex.Message);
            } //заполнение судей

            myConnection.Close();
            RetTournir.Show();

            return RetTournir; 
        }

        public static void insertSet(SetClass setInput, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO sets(Номер_Захода, Номер_Группы, Категория)" + "VALUES (@number, @group_number, @category)";

                command.Parameters.AddWithValue("number", setInput.number);
                command.Parameters.AddWithValue("group_number", setInput.numberOfGroup);
                command.Parameters.AddWithValue("category", setInput.category);

                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так...\n" + ex.Message);
            }
        }

        public static void insertDance(danceClass danceInput, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO dances(Номер_Группы, Танец)" + "VALUES (@group_number, @dance)";

                command.Parameters.AddWithValue("group_number", danceInput.groupnumber);
                command.Parameters.AddWithValue("dance", danceInput.name);

                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так...\n" + ex.Message);
            }
        }

        public static List<SetClass> TakeSet(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<SetClass> SetList_New = new List<SetClass>();

            try
            {
                int i = 1;
                int max = 0;
                int counter = 0;

                BitArray checkArray = Controller.GapCounter("Номер_Захода", "sets", "Номер_Группы", input_group.number, myConnection);

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT MAX(Номер_Захода) FROM sets WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                if (command.ExecuteScalar() != DBNull.Value && checkArray != null)
                {
                    max = Convert.ToInt32(command.ExecuteScalar());

                    //MessageBox.Show($"MAX в группе {input_group.number}: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        if (i <= max)
                        if (checkArray[i-1])
                        {
                            command = new OleDbCommand("", myConnection);
                            command.CommandText = "SELECT Категория FROM categories WHERE Номер_Группы = @num";
                            command.Parameters.AddWithValue("id", i);
                            command.Parameters.AddWithValue("num", input_group.number);

                            OleDbDataReader reader = command.ExecuteReader();

                            while (reader.Read())
                            {
                                //if (reader["Номер_Книжки2"].ToString() != "")
                                //{
                                //    Sportsman sportsman1 = new Sportsman();
                                //    Sportsman sportsman2 = new Sportsman();
                                //    outStr += " ";
                                //    Num1 = (Convert.ToInt32(reader["Номер_Книжки1"]));
                                //    Num2 = (Convert.ToInt32(reader["Номер_Книжки2"]));

                                //    sportsman1 = Controller.SearchByBookNumberShort(Num1);
                                //    sportsman1.BookNumber = Num1;
                                //    sportsman1.GroupNumber = i + 1;
                                //    sportsman2 = Controller.SearchByBookNumberShort(Num2);
                                //    sportsman2.BookNumber = Num2;
                                //    sportsman2.GroupNumber = i + 1;
                                //    DuetList_New.Add(new Duet(Convert.ToInt32(reader["Номер"]) - 1, i, sportsman1, sportsman2));

                                //    outStr += DuetList_New[j1].ToString() + "\n";
                                //    j1++;
                                //}
                            }
                        }
                        else
                        {
                            counter++;
                        }
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Нулевой результат запроса");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка заходов\nError: " + ex.Message);
            }

            myConnection.Close();
            return SetList_New;
        }

        public static List<Duet> TakeDuets(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<Duet> DuetList_New = new List<Duet>();
            try
            {
                int max = 0;

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT Count(Номер) FROM duets WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                max = Convert.ToInt32(command.ExecuteScalar());
                //MessageBox.Show(max.ToString());

                for (int i = 0; i < max; i++)
                {
                    string Type;
                    string SNP1;
                    string SNP2;
                    int number;
                    Duet set_new = new Duet();

                    OleDbCommand command1 = new OleDbCommand("", myConnection);
                    OleDbCommand command2 = new OleDbCommand("", myConnection);
                    OleDbCommand command3 = new OleDbCommand("", myConnection);
                    OleDbCommand command4 = new OleDbCommand("", myConnection);

                    command1.CommandText = "SELECT Номер FROM duets WHERE Номер_Группы = @num AND Номер = @id";
                    command1.Parameters.AddWithValue("num", input_group.number);
                    command1.Parameters.AddWithValue("id", i + 1);
                    number = Convert.ToInt32(command1.ExecuteScalar());
                    //MessageBox.Show(number.ToString());

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Тип FROM duets WHERE Номер_Группы = @num AND Номер = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    Type = command2.ExecuteScalar().ToString().Replace(" ", "");
                    //MessageBox.Show(Type);

                    command3 = new OleDbCommand("", myConnection);
                    command3.CommandText = "SELECT ФИО1 FROM duets WHERE Номер_Группы = @num AND Номер = @id";
                    command3.Parameters.AddWithValue("num", input_group.number);
                    command3.Parameters.AddWithValue("id", i + 1);
                    SNP1 = command3.ExecuteScalar().ToString().Replace(" ", "");
                    //SNP1 = command3.ExecuteScalar().ToString();
                    //MessageBox.Show(SNP1);

                    if (Type == "Пара")
                        {
                        command4 = new OleDbCommand("", myConnection);
                        command4.CommandText = "SELECT ФИО2 FROM duets WHERE Номер_Группы = @num AND Номер = @id";
                        command4.Parameters.AddWithValue("num", input_group.number);
                        command4.Parameters.AddWithValue("id", i + 1);
                        SNP2 = command4.ExecuteScalar().ToString().Replace(" ", "");
                        //MessageBox.Show(SNP2);
                        set_new = new Duet(number, input_group.number, SNP1, SNP2);
                    }
                    else
                        set_new = new Duet(number, input_group.number, SNP1);

                    DuetList_New.Add(set_new); //ДОРАБОТКА
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка пар\nError: " + ex.Message);
            }

            myConnection.Close();
            return DuetList_New;
        }

        public static List<Judge> TakeJudges(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            Judge new_judge = new Judge();
            List<Judge> judgeList = new List<Judge>();
            try
            {
                string judgesString = "";
                string[] judgesStringList;

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT Судьи FROM groups WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                judgesString = command.ExecuteScalar().ToString().Replace(" ", "");
                judgesStringList = judgesString.Split(new char[] { ';' });
                //MessageBox.Show(judgesString);

                judgeList = new List<Judge>();

                for (int i = 0; i < judgesStringList.Length - 1; i++)
                {
                    new_judge = new Judge();
                    int number = Convert.ToInt32(judgesStringList[i]);

                    //MessageBox.Show(number.ToString());

                    OleDbCommand command1 = new OleDbCommand("", myConnection);

                    command1.CommandText = "SELECT ФИО FROM judges WHERE Номер = @num";
                    command1.Parameters.AddWithValue("num", number);
                    string jSNP = command1.ExecuteScalar().ToString();

                    command1 = new OleDbCommand("", myConnection);
                    command1.CommandText = "SELECT Категория_Судейства FROM judges WHERE Номер = @num";
                    command1.Parameters.AddWithValue("num", number);
                    string jcategory = command1.ExecuteScalar().ToString().Replace(" ", "");

                    string[] jSNPList = jSNP.Split(new char[] { ' ' });
                    if (jSNPList.Length >= 3)
                    {
                        new_judge.Surname = jSNPList[0];
                        new_judge.Name = jSNPList[1];
                        new_judge.Patronymic = jSNPList[2];
                    }

                    new_judge.JudgeClass = jcategory;
                    new_judge.Number = (ushort)number;
                    new_judge.judgeChar = (char)(64 + number);

                    //MessageBox.Show(new_judge.ToString());

                    judgeList.Add(new_judge);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка судей\nError: " + ex.Message);
            }

            myConnection.Close();
            return judgeList;
        }

        public static List<string> TakeCategory(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<string> CategoryList_New = new List<string>();

            try
            {
                int i = 1;
                int max = 0;
                int counter = 0;

                BitArray checkArray = Controller.GapCounter("Номер", "categories", "Номер_Группы", input_group.number, myConnection);

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT MAX(Номер) FROM categories WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                if (command.ExecuteScalar() != DBNull.Value && checkArray != null)
                {
                    max = Convert.ToInt32(command.ExecuteScalar());

                    //MessageBox.Show($"MAX в группе {input_group.number}: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        if (i <= max)
                            if (checkArray[i - 1])
                            {
                                command = new OleDbCommand("", myConnection);
                                command.CommandText = "SELECT Категория FROM categories WHERE Номер = @id AND Номер_Группы = @num";
                                command.Parameters.AddWithValue("id", i);
                                command.Parameters.AddWithValue("num", input_group.number);

                                string category = command.ExecuteScalar().ToString();
                                //MessageBox.Show(category);
                                CategoryList_New.Add(category); //ДОРАБОТКА
                            }
                            else
                            {
                                counter++;
                            }
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Нулевой результат запроса");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка заходов\nError: " + ex.Message);
            }

            myConnection.Close();
            return CategoryList_New;
        }

        public static List<string> TakeDances(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<string> CategoryList_New = new List<string>();

            try
            {
                int i = 1;
                int max = 0;
                int counter = 0;

                BitArray checkArray = Controller.GapCounter("Номер", "dances", "Номер_Группы", input_group.number, myConnection);

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT MAX(Номер) FROM dances WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                if (command.ExecuteScalar() != DBNull.Value && checkArray != null)
                {
                    max = Convert.ToInt32(command.ExecuteScalar());

                    //MessageBox.Show($"MAX в группе {input_group.number}: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        if (i <= max)
                            if (checkArray[i - 1])
                            {
                                command = new OleDbCommand("", myConnection);
                                command.CommandText = "SELECT Танец FROM dances WHERE Номер = @id AND Номер_Группы = @num";
                                command.Parameters.AddWithValue("id", i);
                                command.Parameters.AddWithValue("num", input_group.number);

                                string category = command.ExecuteScalar().ToString();
                                //MessageBox.Show(category);
                                CategoryList_New.Add(category); //ДОРАБОТКА
                            }
                            else
                            {
                                counter++;
                            }
                        i++;
                    }
                }
                else
                {
                    MessageBox.Show("Нулевой результат запроса");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка танцев\nError: " + ex.Message);
            }

            myConnection.Close();
            return CategoryList_New;
        }

        public static int TakeMax(string rowName, string tableName, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            int max = 0;
            try
            {
                OleDbCommand command = new OleDbCommand("", myConnection);
                command.CommandText = $"SELECT MAX({rowName}) FROM {tableName}";

                max = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при определении максимального значения {rowName} из {tableName}\nError: " + ex.Message);
            }

            myConnection.Close();

            return max;
        }

        public static int TakeMax(string rowName, string tableName, string parametr, int paramValue, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            int max = 0;
            try
            {
                OleDbCommand command = new OleDbCommand("", myConnection);
                command.CommandText = $"SELECT MAX({rowName}) FROM {tableName} WHERE {parametr} = {paramValue}";

                max = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show($"Упс, что-то пошло не так при определении максимального значения {rowName} из {tableName}\nError: " + ex.Message);
                max = 0;
            }

            myConnection.Close();

            return max;
        }
    }
}

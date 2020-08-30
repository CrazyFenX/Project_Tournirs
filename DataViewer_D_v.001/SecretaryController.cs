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
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO participants(Номер_Книжки, Фамилия, Имя, Отчество, Категория)" + "VALUES (@BookNumber,@Surname,@Name,@Patronymic,@AgeCategory)";

                command.Parameters.AddWithValue("BookNumber", sportsman.BookNumber);
                command.Parameters.AddWithValue("Surname", sportsman.Surname);
                command.Parameters.AddWithValue("Name", sportsman.Name);
                command.Parameters.AddWithValue("Patronymic", sportsman.Patronymic);
                command.Parameters.AddWithValue("AgeCategory",sportsman.AgeCategory);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

                command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Захода, Номер_Книжки1, Тип)" + "VALUES (@Number, @GroupNumber, @SetNumber, @BookNumber, @Type)";

                command.Parameters.AddWithValue("Number", number);
                command.Parameters.AddWithValue("GroupNumber", groupNumber);
                command.Parameters.AddWithValue("SetNumber", setNumber);
                command.Parameters.AddWithValue("BookNumber", sportsman.BookNumber);
                command.Parameters.AddWithValue("Type", "Соло");

                MessageBox.Show($"Новый Солист:\n{sportsman.BookNumber}\nГруппа: {groupNumber}\nЗаход: {setNumber}");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при записи очередного солиста...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void insertParticipantsInSet(int number, Sportsman sportsman1, Sportsman sportsman2, int groupNumber, int setNumber, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Захода, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @SetNumber, @BookNumber1, @BookNumber2, @Type)";

                command.Parameters.AddWithValue("Number", number);
                command.Parameters.AddWithValue("GroupNumber", groupNumber);
                command.Parameters.AddWithValue("SetNumber", setNumber);
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

                MessageBox.Show($"Турнир: {RetTournir.name}\nДата: {RetTournir.date}\nВремя: {RetTournir.time}\nМесто: {RetTournir.place}\nОрганизация: {RetTournir.organisation}\nСекретарь: {RetTournir.secretary}\nРегистратор: {RetTournir.registrator}");

                /*
                public string name;
                public MyDate date;
                public TimeClass time;
                public string place;
                public string organisation;

                public List<GroupClass> groups = new List<GroupClass>();

                public string registrator;
                public string secretary;

                ++++++++public List<Judge> judges = new List<Judge>();

                public List<Set> Sets = new List<Set>(); В группах
                */
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так...\nError: " + ex.Message);
            } //заполнение Турнира

            try
            {
                int i = 1;
                int k = 0;

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT COUNT(Номер_Группы) FROM groups";

                k = Convert.ToInt32(command.ExecuteScalar());

                MessageBox.Show("Количество групп: " + Convert.ToString(k));

                while (i <= k)
                {
                    RetTournir.groups.Add(new GroupClass(i, RetTournir.name));
                    RetTournir.groups[i - 1].SetList = TakeSet(RetTournir.groups[i - 1], cn);
                    RetTournir.groups[i - 1].CategoryList = TakeCategory(RetTournir.groups[i - 1], cn);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так при определении списка групп\nError: " + ex.Message);
            } //заполнение групп

            try
            {
                myConnection.Close();
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
                MessageBox.Show("Количество судей: " + Convert.ToString(k1));

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
                                command2 = new OleDbCommand("SELECT Категория_Судейства FROM judges WHERE Номер = @id", myConnection); //JudjeClass

                                command1.Parameters.AddWithValue("id", i1 + 1);

                                command2.Parameters.AddWithValue("id", i1 + 1);

                                judge_new.ToJudge(command1.ExecuteScalar().ToString());
                                judge_new.JudgeClass = command2.ExecuteScalar().ToString();

                                RetTournir.judges.Add(judge_new);
                                MessageBox.Show(RetTournir.judges[i1 - counter].ToNSP() + " " + RetTournir.judges[i1 - counter].JudgeClass);
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
                    MessageBox.Show($"Записей при определении судей не найдено");
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

                    MessageBox.Show($"MAX в группе {input_group.number}: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        if (i <= max)
                            if (checkArray[i-1])
                            {
                                command = new OleDbCommand("", myConnection);
                                command.CommandText = "SELECT Категория FROM sets WHERE Номер_Захода = @id AND Номер_Группы = @num";
                                command.Parameters.AddWithValue("id", i);
                                command.Parameters.AddWithValue("num", input_group.number);

                                SetClass set_new = new SetClass(input_group.number, i, command.ExecuteScalar().ToString());

                                SetList_New.Add(set_new); //ДОРАБОТКА
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
                //command.Parameters.AddWithValue();

                max = Convert.ToInt32(command.ExecuteScalar().ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при определении максимального значения {rowName} из {tableName}\nError: " + ex.Message);
            }

            myConnection.Close();

            return max;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Resources;
using System.CodeDom;
using System.Collections;

//using iTextSharp;
//using iTextSharp.text;
using System.IO;
//using iTextSharp.text.pdf;
//using System.Drawing;

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

                command.CommandText = "INSERT INTO judges(ФИО, Категория_Судейства, Должность, Город)" + "VALUES (@SNP, @Category, @Pos, @City)";

                command.Parameters.AddWithValue("SNP", judje.Surname + ";" + judje.Name + ";" + judje.Patronymic + ";");
                command.Parameters.AddWithValue("Category", judje.JudgeClass);
                command.Parameters.AddWithValue("Pos", judje.position);
                command.Parameters.AddWithValue("City", judje.City);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void createTournirFolderNDataBase(string folderName, CreatingTournirDBForm previousForm)
        {
            string dbName = previousForm.Name_textBox.Text;
            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(folderName + '\\' + dbName);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory("Results");
                dirInfo.CreateSubdirectory("Diploms");
                dirInfo.CreateSubdirectory("MarkBlanks");
                dirInfo.CreateSubdirectory("DuetNumbers");
                folderName += '\\' + dbName + '\\' + dbName;

                ADOX.Catalog BD = new ADOX.Catalog();
                BD.Create($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}.mdb;Jet OLEDB:Engine Type=5");

                OleDbConnection cn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}.mdb");
                cn.Open();
                OleDbCommand com = new OleDbCommand();

                //Создание Таблицы Турнира
                com = new OleDbCommand("CREATE TABLE tournir(ID COUNTER, Название CHAR(50), Дата_Проведения CHAR(10),  Время_Проведения CHAR(5),  Место_Проведения CHAR(150), Организация CHAR(100), ФИО_Секретаря CHAR(100), ФИО_Регистратора CHAR(100), Порядок CHAR(100) DEFAULT '0;', CONSTRAINT tournir_pk PRIMARY KEY (Название))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Групп
                com = new OleDbCommand("CREATE TABLE groups(Номер_Группы COUNTER, Название_Турнира CHAR(100), Время CHAR(5), Категория CHAR(100), Категории CHAR(50), Танцы CHAR(100), Судьи CHAR(100), CONSTRAINT groups_pk PRIMARY KEY (Номер_Группы), CONSTRAINT fk_groups FOREIGN KEY (Название_Турнира) REFERENCES tournir(Название))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Категорий
                com = new OleDbCommand("CREATE TABLE categories(Номер INT DEFAULT 0, Номер_Группы INT, Категория CHAR(6), CONSTRAINT fk_categories FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Танцев
                com = new OleDbCommand("CREATE TABLE dances(Номер INT DEFAULT 0, Номер_Группы INT, Танец CHAR(100), CONSTRAINT fk_dances FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Судей
                com = new OleDbCommand("CREATE TABLE judges(Номер COUNTER DEFAULT 0, Название_Турнира CHAR(50), ФИО CHAR(100), Категория_Судейства CHAR(20), Должность CHAR(5), Город CHAR(50), CONSTRAINT judges_pk PRIMARY KEY (Номер), CONSTRAINT fk_judges FOREIGN KEY (Название_Турнира) REFERENCES tournir(Название))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Должностей
                com = new OleDbCommand("CREATE TABLE positions(Номер COUNTER DEFAULT 0, ФИО CHAR(100), Должность CHAR(5), Город CHAR(50), CONSTRAINT pos_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Судей
                com = new OleDbCommand("CREATE TABLE trainers(Номер COUNTER DEFAULT 0, Номер_Пары INT DEFAULT 0, ФИО CHAR(100), Категория CHAR(20))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Участников
                com = new OleDbCommand("CREATE TABLE participants(Номер INT DEFAULT 0, Номер_Пары INT DEFAULT 0, Фамилия CHAR(50), Имя CHAR(50), Отчество CHAR(50), Категория CHAR(5), Номер_Группы INT, Счет INT DEFAULT 0)", cn);
                com.ExecuteNonQuery();

                com = new OleDbCommand("CREATE TABLE duets(Номер INT DEFAULT 0, Номер_В_Группе INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Номер_Захода INT, ФИО1 CHAR(100), ФИО2 CHAR(100), Тип CHAR(4), Счет FLOAT DEFAULT 0, Оценки CHAR(255))", cn);
                com.ExecuteNonQuery();

                TournirClass NewTournir = new TournirClass();

                NewTournir.name = previousForm.Name_textBox.Text;
                NewTournir.date = new MyDate(previousForm.DayOfTournir_comboBox.SelectedIndex + 1, previousForm.MounthOfTournir_comboBox.SelectedIndex + 1, Convert.ToInt32(previousForm.YearOfTournir_textBox.Text));
                NewTournir.time = new TimeClass(previousForm.HourTournirStart_comboBox.SelectedIndex, previousForm.MinutesTournirStart_comboBox.SelectedIndex * 5);
                //MessageBox.Show(NewTournir.time.ToString());
                NewTournir.place = previousForm.CityOfTournir_textBox.Text;
                NewTournir.organisation = previousForm.OrganisationOfTournir_textBox.Text;
                NewTournir.registrator = "SNP_registrator";
                NewTournir.secretary = "SNP_secretary";

                com = new OleDbCommand("INSERT INTO tournir(Название, Дата_Проведения,  Время_Проведения,  Место_Проведения, Организация, ФИО_Секретаря, ФИО_Регистратора)" + "VALUES (@name,@date,@time,@plase,@organisation,@secretary,@registrator)", cn);
                com.Parameters.AddWithValue("name", NewTournir.name);
                com.Parameters.AddWithValue("date", NewTournir.date.ToString());
                com.Parameters.AddWithValue("time", NewTournir.time.ToString());
                com.Parameters.AddWithValue("place", NewTournir.place);
                com.Parameters.AddWithValue("organisation", NewTournir.organisation);
                com.Parameters.AddWithValue("secretary", NewTournir.secretary);
                com.Parameters.AddWithValue("registrator", NewTournir.registrator);

                com.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void insertInParticipants(Sportsman sportsman, string path)
        {
            //try
            //{
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            OleDbCommand command = new OleDbCommand("", myConnection);

            command.CommandText = "INSERT INTO participants(Номер, Номер_Пары, Фамилия, Имя, Отчество, Категория, Номер_Группы)" + "VALUES (@Number, @DuetNumber, @Surname, @Name, @Patronymic, @AgeCategory, @GroupNumber)";

            command.Parameters.AddWithValue("Number", sportsman.NumberInTournir);
            command.Parameters.AddWithValue("DuetNumber", sportsman.DuetNumber);
            command.Parameters.AddWithValue("Surname", sportsman.Surname);
            command.Parameters.AddWithValue("Name", sportsman.Name);
            command.Parameters.AddWithValue("Patronymic", sportsman.Patronymic);
            command.Parameters.AddWithValue("AgeCategory", sportsman.AgeCategory);
            command.Parameters.AddWithValue("GroupNumber", sportsman.GroupNumber);

            command.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            myConnection.Close();
        }

        public static void insertInParticipants(Sportsman sportsman1, Sportsman sportsman2, string path)
        {
            //try
            //{
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            OleDbCommand command = new OleDbCommand("", myConnection);

            command.CommandText = "INSERT INTO participants(Номер, Фамилия, Имя, Отчество, Категория, Номер_Группы)" + "VALUES (@Number, @Surname, @Name, @Patronymic, @AgeCategory, @GroupNumber)";

            command.Parameters.AddWithValue("Number", sportsman1.NumberInTournir);
            command.Parameters.AddWithValue("Surname", sportsman1.Surname);
            command.Parameters.AddWithValue("Name", sportsman1.Name);
            command.Parameters.AddWithValue("Patronymic", sportsman1.Patronymic);
            command.Parameters.AddWithValue("AgeCategory", sportsman1.AgeCategory);
            command.Parameters.AddWithValue("GroupNumber", sportsman1.GroupNumber);

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

            command.CommandText = "INSERT INTO duets(Номер, Номер_В_Группе, Номер_Группы, ФИО1, Тип)" + "VALUES (@Number, @NumberInGroup, @GroupNumber, @SNP, @Type)";
            command.Parameters.AddWithValue("Number", number);
            command.Parameters.AddWithValue("NumberInGroup", sportsman.NumberInGroup);
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
                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_В_Группе, ФИО1, ФИО2, Тип)" + "VALUES (@Number, @GroupNumber, @NumberInGroup, @SNP1, @SNP2, @Type)";
                    //command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber1, @BookNumber2, @Type)";

                    command.Parameters.AddWithValue("Number", number);
                    //command.Parameters.AddWithValue("DuetNumber", sportsman1.DuetNumber);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    command.Parameters.AddWithValue("NumberInGroup", sportsman1.NumberInGroup);
                    //command.Parameters.AddWithValue("SetNumber", setNumber);
                    command.Parameters.AddWithValue("@SNP1", sportsman1.Surname + ";" + sportsman1.Name + ";" + sportsman1.Patronymic + ";");
                    command.Parameters.AddWithValue("@SNP2", sportsman2.Surname + ";" + sportsman2.Name + ";" + sportsman2.Patronymic + ";");
                    command.Parameters.AddWithValue("Type", "Пара");
                }
                else
                {
                    //command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber1, @BookNumber2, @Type)";

                    //command.Parameters.AddWithValue("Number", number);
                    //command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    //command.Parameters.AddWithValue("BookNumber1", sportsman1.BookNumber);
                    //command.Parameters.AddWithValue("BookNumber2", sportsman2.BookNumber);
                    //command.Parameters.AddWithValue("Type", "Пара");
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

        public static void insertTrainer(Trainer trainer, int Number) //potncial DELETING
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

        public static Sportsman SearchByBookNumber(int BookNumber) //potncial DELETING
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
            OleDbCommand command8 = new OleDbCommand("", myConnection);

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

            command8.CommandText = "SELECT Порядок FROM tournir WHERE ID = @Num";
            command8.Parameters.AddWithValue("Num", Num);

            int i;
            try
            {
                RetTournir.path = cn;
                RetTournir.name = command1.ExecuteScalar().ToString().Replace(" ", "");
                RetTournir.date.ToInt(command2.ExecuteScalar().ToString().Replace(" ", ""));
                RetTournir.time.ToInt(command3.ExecuteScalar().ToString().Replace(" ", ""));
                RetTournir.place = command4.ExecuteScalar().ToString().Replace(" ", "");
                RetTournir.organisation = command5.ExecuteScalar().ToString().Replace(" ", "");
                RetTournir.secretary = command6.ExecuteScalar().ToString().Replace(" ", "");
                RetTournir.registrator = command7.ExecuteScalar().ToString().Replace(" ", "");
                string[] tmpOrder = command8.ExecuteScalar().ToString().Replace(" ", "").Split(new char[] { ';' });
                
                string retstr = "";
                //MessageBox.Show("Len: " + tmpOrder.Length.ToString() + " " + tmpOrder[1]);
                RetTournir.groupsOrder = new ushort[tmpOrder.Length - 1];
                for (i = 0; i < tmpOrder.Length - 1; i++)
                {
                    RetTournir.groupsOrder[i] = (ushort)Convert.ToInt32(tmpOrder[i]);
                    retstr += RetTournir.groupsOrder[i].ToString() + " ";
                }
                //MessageBox.Show("Len: " + tmpOrder.Length.ToString() + " " + retstr);
                //MessageBox.Show($"Турнир: {RetTournir.name}\nДата: {RetTournir.date}\nВремя: {RetTournir.time}\nМесто: {RetTournir.place}\nОрганизация: {RetTournir.organisation}\nСекретарь: {RetTournir.secretary}\nРегистратор: {RetTournir.registrator}");
                //myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так... код 1\nError: " + ex.Message);
            } //заполнение Турнира

            try
            {
                i = 1;
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
                    name = Convert.ToString(command.ExecuteScalar()).Replace(" ", "");
                    RetTournir.groups.Add(new GroupClass(i, RetTournir.name, name));

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Категории FROM groups WHERE Номер_Группы = @id";
                    command.Parameters.AddWithValue("id", i);
                    string categoriesStr = Convert.ToString(command.ExecuteScalar()).Replace(" ", "");
                    foreach (string strItem in categoriesStr.Split(new char[] { ';' }))
                        if (strItem != "") RetTournir.groups[i - 1].CategoryList.Add(strItem);

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Танцы FROM groups WHERE Номер_Группы = @id";
                    command.Parameters.AddWithValue("id", i);
                    string dancesStr = Convert.ToString(command.ExecuteScalar()).Replace(" ", "");
                    foreach (string strItem in dancesStr.Split(new char[] { ';' }))
                        if (strItem != "") RetTournir.groups[i - 1].DancesList.Add(strItem);
                    //RetTournir.groups[i - 1].CategoryList = TakeCategory(RetTournir.groups[i - 1], cn);
                    //RetTournir.groups[i - 1].DancesList = TakeDances(RetTournir.groups[i - 1], cn);

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

                BitArray checkArray = Controller.GapCounter("Номер", "judges", myConnection);

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
                                command3 = new OleDbCommand("SELECT Должность FROM judges WHERE Номер = @id", myConnection); //JudjePos
                                command3.Parameters.AddWithValue("id", i1 + 1);
                                command4 = new OleDbCommand("SELECT Город FROM judges WHERE Номер = @id", myConnection);
                                command4.Parameters.AddWithValue("id", i1 + 1);

                                judge_new.ToJudge(command1.ExecuteScalar().ToString().Replace(" ", ""));

                                //MessageBox.Show(judge_new.Surname + "\n" + judge_new.Name + "\n" + judge_new.Patronymic);

                                judge_new.JudgeClass = command2.ExecuteScalar().ToString().Replace(" ", "");
                                judge_new.position = command3.ExecuteScalar().ToString().Replace(" ", "");
                                judge_new.City = command4.ExecuteScalar().ToString().Replace(" ", "");

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

                    command1 = new OleDbCommand("SELECT COUNT(Номер) FROM positions", myConnection);
                    int countOfPositions = Convert.ToInt32(command1.ExecuteScalar().ToString());
                    for (int h = 0; h < countOfPositions; h++)
                    {
                        Judge judge_new = new Judge();

                        command1 = new OleDbCommand("SELECT ФИО FROM positions WHERE Номер = @id", myConnection); //NSP
                        command1.Parameters.AddWithValue("id", h + 1);
                        command3 = new OleDbCommand("SELECT Должность FROM positions WHERE Номер = @id", myConnection); //JudjePos
                        command3.Parameters.AddWithValue("id", h + 1);
                        command4 = new OleDbCommand("SELECT Город FROM positions WHERE Номер = @id", myConnection); //JudjePos
                        command4.Parameters.AddWithValue("id", h + 1);

                        judge_new.ToJudge(command1.ExecuteScalar().ToString().Replace(" ", ""));
                        judge_new.position = command3.ExecuteScalar().ToString().Replace(" ", "");
                        judge_new.City = command4.ExecuteScalar().ToString().Replace(" ", "");

                        RetTournir.positionsList.Add(judge_new);
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
            //RetTournir.Show();
            RetTournir.info2();

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
                            if (checkArray[i - 1])
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
                command.CommandText = "SELECT Count(Номер_В_Группе) FROM duets WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                max = Convert.ToInt32(command.ExecuteScalar());
                //MessageBox.Show(max.ToString());

                for (int i = 0; i < max; i++)
                {
                    string Type;
                    string SNP1;
                    string SNP2;
                    int number;
                    double mark;
                    Duet set_new = new Duet();

                    OleDbCommand command1 = new OleDbCommand("", myConnection);
                    OleDbCommand command2 = new OleDbCommand("", myConnection);
                    OleDbCommand command3 = new OleDbCommand("", myConnection);
                    OleDbCommand command4 = new OleDbCommand("", myConnection);
                    OleDbCommand command5 = new OleDbCommand("", myConnection);

                    command1.CommandText = "SELECT Номер FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command1.Parameters.AddWithValue("num", input_group.number);
                    command1.Parameters.AddWithValue("id", i + 1);
                    number = Convert.ToInt32(command1.ExecuteScalar());
                    //MessageBox.Show(number.ToString());

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Тип FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    Type = command2.ExecuteScalar().ToString().Replace(" ", "");
                    //MessageBox.Show(Type);

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Счет FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    mark = Convert.ToDouble(command2.ExecuteScalar());
                    //MessageBox.Show(mark.ToString());

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Оценки FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    List<List<int>> newMarksList = new List<List<int>>();
                    if (command2.ExecuteScalar().ToString() != "")
                    {
                        string[] marksString = command2.ExecuteScalar().ToString().Replace(" ", "").Split(new char[] { ';' });
                        int counter = 0;
                        foreach (string itemStr in marksString)
                        {
                            if (itemStr != "")
                            {
                                string[] marksInDance = itemStr.Split(new char[] { ':' });
                                newMarksList.Add(new List<int>(marksInDance.Length));
                                foreach (string itemMark in marksInDance)
                                {
                                    newMarksList[counter].Add(Convert.ToInt32(itemMark));
                                }
                                counter++;
                            }
                        }
                    }
                    command3 = new OleDbCommand("", myConnection);
                    command3.CommandText = "SELECT ФИО1 FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command3.Parameters.AddWithValue("num", input_group.number);
                    command3.Parameters.AddWithValue("id", i + 1);
                    SNP1 = command3.ExecuteScalar().ToString().Replace(" ", "");
                    //SNP1 = command3.ExecuteScalar().ToString();
                    //MessageBox.Show(SNP1);

                    command5 = new OleDbCommand("", myConnection);
                    command5.CommandText = "SELECT COUNT(Номер_Пары) FROM trainers WHERE Номер_Пары = @id";
                    //command3.Parameters.AddWithValue("num", input_group.number);
                    command5.Parameters.AddWithValue("id", number);
                    int countOfTrainers = Convert.ToInt32(command5.ExecuteScalar().ToString());
                    List<Trainer> tmpListTrainers = new List<Trainer>(3);

                    switch (countOfTrainers)
                    {
                        case 1:
                            tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Старший", myConnection));
                            break;
                        case 2:
                            tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Старший", myConnection));
                            tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Первый", myConnection));
                            break;
                        case 3:
                            tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Старший", myConnection));
                            tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Первый", myConnection));
                            tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Второй", myConnection));
                            break;
                    }

                    if (Type == "Пара")
                    {
                        command4 = new OleDbCommand("", myConnection);
                        command4.CommandText = "SELECT ФИО2 FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                        command4.Parameters.AddWithValue("num", input_group.number);
                        command4.Parameters.AddWithValue("id", i + 1);
                        SNP2 = command4.ExecuteScalar().ToString().Replace(" ", "");
                        //MessageBox.Show(SNP2);
                        set_new = new Duet(number, i + 1, input_group.number, SNP1, SNP2, mark);
                    }
                    else
                        set_new = new Duet(number, i + 1, input_group.number, SNP1, mark);
                    set_new.trainers = tmpListTrainers;
                    set_new.diplomPlace = getDiplomPlace(mark);
                    set_new.judgeMarkList = newMarksList;
                    getMarksSum(set_new);
                    //MessageBox.Show(getDiplomPlase(mark));
                    //MessageBox.Show(set_new.ToString());
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

                    string[] jSNPList = jSNP.Split(new char[] { ';' });
                    if (jSNPList.Length >= 3)
                    {
                        new_judge.Surname = jSNPList[0];
                        new_judge.Name = jSNPList[1];
                        new_judge.Patronymic = jSNPList[2];
                    }

                    command1 = new OleDbCommand("", myConnection);
                    command1.CommandText = "SELECT Город FROM judges WHERE Номер = @num";
                    command1.Parameters.AddWithValue("num", number);
                    string jcity = command1.ExecuteScalar().ToString().Replace(" ", "");

                    new_judge.JudgeClass = jcategory;
                    new_judge.Number = (ushort)number;
                    new_judge.judgeChar = (char)(64 + number);
                    new_judge.City = jcity;

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

                if (command.ExecuteScalar() != DBNull.Value)
                    max = Convert.ToInt32(command.ExecuteScalar());
                else
                    max = 0;
            }
            catch (Exception)
            {
                //MessageBox.Show($"Упс, что-то пошло не так при определении максимального значения {rowName} из {tableName}\nError: " + ex.Message);
                max = 0;
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

                if (command.ExecuteScalar() != DBNull.Value)
                    max = Convert.ToInt32(command.ExecuteScalar());
                else
                    max = 0;
            }
            catch (Exception)
            {
                //MessageBox.Show($"Упс, что-то пошло не так при определении максимального значения {rowName} из {tableName}\nError: " + ex.Message);
                max = 0;
            }
            myConnection.Close();
            return max;
        }

        public static Trainer TakeTrainer(int duetNum, int groupNum, string status, OleDbConnection cn)
        {
            //connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            //myConnection = new OleDbConnection(connectString);
            //myConnection.Open();

            Trainer tmpTrainer = new Trainer();
            try
            {
                //OleDbCommand command = new OleDbCommand($"SELECT ФИО FROM trainers WHERE Номер_Группы = @num AND Номер_Пары = @id AND Категория = @Categ", cn);
                OleDbCommand command = new OleDbCommand($"SELECT ФИО FROM trainers WHERE Номер_Пары = @id AND Категория = @Categ", cn);
                //command.Parameters.AddWithValue("num", groupNum);
                command.Parameters.AddWithValue("id", duetNum);
                command.Parameters.AddWithValue("Categ", status);

                string[] SNPstring = command.ExecuteScalar().ToString().Replace(" ", "").Split(new char[] { ';', ' ' });
                tmpTrainer.Surname = SNPstring[0];
                tmpTrainer.Name = SNPstring[1];
                tmpTrainer.Patronymic = SNPstring[2];

                tmpTrainer.Status = status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при определении тренера {status} {duetNum} пары\nError: " + ex.Message);
                
            }

            //myConnection.Close();

            return tmpTrainer;
        }


        public static void UpdateDuetMark(Duet duetItem, string cn)
        {
            OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
            con.Open();

            OleDbCommand command = new OleDbCommand();
            command = new OleDbCommand("", con);
            command.CommandText = "UPDATE duets SET Счет = @mark WHERE Номер = @id";
            command.Parameters.AddWithValue("mark", duetItem.mark);
            command.Parameters.AddWithValue("id", duetItem.number);
            command.ExecuteNonQuery();

            string marksString = "";
            foreach (List<int> itemList in duetItem.judgeMarkList)
            {
                for(int k = 0; k < itemList.Count; k++)
                {
                    marksString += itemList[k].ToString();
                    if (k < itemList.Count - 1)
                        marksString += ":";
                }
                marksString += ";";
            }
            MessageBox.Show(marksString);
            command = new OleDbCommand("", con);
            command.CommandText = "UPDATE duets SET Оценки = @markSum WHERE Номер = @id";
            command.Parameters.AddWithValue("markSum", marksString);
            command.Parameters.AddWithValue("id", duetItem.number);
            command.ExecuteNonQuery();

            command = new OleDbCommand("", con);
            command.CommandText = "UPDATE participants SET Счет = @mark WHERE Номер = @id";
            command.Parameters.AddWithValue("mark", duetItem.mark);
            command.Parameters.AddWithValue("id", duetItem.number);
            command.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateGroupsOrder(string orderString, string cn)
        {
            OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
            con.Open();

            OleDbCommand command = new OleDbCommand();
            command = new OleDbCommand("", con);
            command.CommandText = "UPDATE tournir SET Порядок = @tmpOrder WHERE ID = @id";
            command.Parameters.AddWithValue("tmpOrder", orderString);
            command.Parameters.AddWithValue("id", 1);
            command.ExecuteNonQuery();

            con.Close();
        }


        public static string getDiplomPlace(double mark)
        {
            if (mark >= 4.5) return "Л1";
            if (mark >= 4 && mark < 4.5) return "Л2";
            if (mark >= 3.5 && mark < 4) return "Л3";
            if (mark >= 3 && mark < 3.5) return "Д1";
            if (mark >= 2.5 && mark < 3) return "Д2";
            return "Д3";
        }

        public static void getMarksSum(Duet inputDuet)
        {
            foreach (List<int> itemList in inputDuet.judgeMarkList)
                foreach (int item in itemList)
                    inputDuet.markSum += item;
        }

        public static void insertTrainer(Trainer trainer,int duetNum ,string path)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            commandTrain.CommandText = "INSERT INTO trainers(Номер_Пары, ФИО, Категория)" + "VALUES (@Num, @SNP, @Category)";

            trainer.pasItendificate();
            commandTrain.Parameters.AddWithValue("Num", duetNum);
            commandTrain.Parameters.AddWithValue("SNP", trainer.Surname + ";" + trainer.Name + ";" + trainer.Patronymic + ";");
            commandTrain.Parameters.AddWithValue("Category", trainer.Status);

            try
            {
                commandTrain.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
        }

        public static void insertPosition(Judge judge, string path)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            commandTrain.CommandText = "INSERT INTO positions(ФИО, Должность, Город)" + "VALUES (@SNP, @Posit, @City)";
            commandTrain.Parameters.AddWithValue("SNP", judge.Surname + ";" + judge.Name + ";" + judge.Patronymic + ";");
            commandTrain.Parameters.AddWithValue("Posit", judge.position);
            commandTrain.Parameters.AddWithValue("City", judge.City);

            try
            {
                commandTrain.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
        }

        //---------------------------//
        public static void splitGroupForSets(GroupClass inputGroup, ushort countOfSets)
        {
            int countOfDuetsInSet = (int)(inputGroup.duetList.Count / (countOfSets - 1));
            MessageBox.Show(countOfDuetsInSet.ToString());
            int counter = 0;
            SetClass tempSet = new SetClass();

            for (int j = 0; j < countOfSets - 1; j++)
            {
                tempSet = new SetClass(inputGroup.number, j + 1);
                inputGroup.SetList.Add(tempSet);
                for (int i = 0; i < countOfDuetsInSet; i++)
                {
                    inputGroup.SetList[j].DuetList.Add(inputGroup.duetList[counter]);
                    counter++;
                }
            }

            MessageBox.Show((inputGroup.duetList.Count % (countOfSets - 1)).ToString());

            if (inputGroup.duetList.Count % (countOfSets - 1) > 0)
            {
                tempSet = new SetClass(inputGroup.number, countOfSets);
                inputGroup.SetList.Add(tempSet);
                for (int i = counter; i < inputGroup.duetList.Count; i++)
                {
                    inputGroup.SetList[countOfSets - 1].DuetList.Add(inputGroup.duetList[i]);
                }
            }
        }
    }
}
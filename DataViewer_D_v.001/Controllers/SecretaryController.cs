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
using System.Data;
using DataViewer_D_v._001.Classes;
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
            previousForm.Name_textBox.Text = previousForm.Name_textBox.Text.Replace(" ", "_");
            string dbName = previousForm.Name_textBox.Text;
            try
            {
                //MessageBox.Show(folderName + '\\' + dbName);
                DirectoryInfo dirInfo = new DirectoryInfo(folderName + '\\' + dbName);
                if (!dirInfo.Exists)
                {
                    dirInfo.Create();
                }
                dirInfo.CreateSubdirectory("Results");
                dirInfo.CreateSubdirectory("InfoReports");
                dirInfo.CreateSubdirectory("Diploms");
                dirInfo.CreateSubdirectory("MarkBlanks");
                dirInfo.CreateSubdirectory("DuetNumbers");
                dirInfo.CreateSubdirectory("Reglament");
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
                //com = new OleDbCommand("CREATE TABLE groups(Номер_Группы COUNTER, Название_Турнира CHAR(100), Отделение INT DEFAULT 0, Категория CHAR(100), Категории CHAR(50), Танцы CHAR(100), Судьи CHAR(100), Система INT DEFAULT 0, CONSTRAINT groups_pk PRIMARY KEY (Номер_Группы), CONSTRAINT fk_groups FOREIGN KEY (Название_Турнира) REFERENCES tournir(Название))", cn);
                com = new OleDbCommand("CREATE TABLE groups(Номер_Группы COUNTER, Название_Турнира CHAR(100), Отделение INT DEFAULT 0, Категория CHAR(100), Категории CHAR(50), Танцы CHAR(100), Судьи CHAR(100), Система INT DEFAULT 0, CONSTRAINT groups_pk PRIMARY KEY (Номер_Группы))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Категорий
                //com = new OleDbCommand("CREATE TABLE categories(Номер INT DEFAULT 0, Номер_Группы INT, Категория CHAR(6), CONSTRAINT fk_categories FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                //com.ExecuteNonQuery();

                //Создание Таблицы Танцев
                //com = new OleDbCommand("CREATE TABLE dances(Номер INT DEFAULT 0, Номер_Группы INT, Танец CHAR(100), CONSTRAINT fk_dances FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                //com.ExecuteNonQuery();

                //Создание Таблицы Судей
                //com = new OleDbCommand("CREATE TABLE judges(Номер COUNTER DEFAULT 0, Название_Турнира CHAR(50), ФИО CHAR(100), Категория_Судейства CHAR(20), Должность CHAR(5), Город CHAR(50), CONSTRAINT judges_pk PRIMARY KEY (Номер), CONSTRAINT fk_judges FOREIGN KEY (Название_Турнира) REFERENCES tournir(Название))", cn);
                com = new OleDbCommand("CREATE TABLE judges(Номер COUNTER DEFAULT 0, Название_Турнира CHAR(50), ФИО CHAR(100), Категория_Судейства CHAR(20), Должность CHAR(5), Город CHAR(50), CONSTRAINT judges_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Должностей
                com = new OleDbCommand("CREATE TABLE positions(Номер COUNTER DEFAULT 0, ФИО CHAR(100), Должность CHAR(5), Город CHAR(50), CONSTRAINT pos_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Судей
                com = new OleDbCommand("CREATE TABLE trainers(Номер COUNTER DEFAULT 0, Номер_Пары INT DEFAULT 0, ФИО CHAR(100), Категория CHAR(20))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Участников
                com = new OleDbCommand("CREATE TABLE participants(Номер INT DEFAULT 0, Номер_Пары INT DEFAULT 0,  Номер_В_Паре INT DEFAULT 0, Фамилия CHAR(50), Имя CHAR(50), Отчество CHAR(50), Дата_рождения CHAR(10), Город CHAR(30), Клуб CHAR(50), Категория CHAR(5), Номер_Группы INT, Номер_В_Группе INT, Счет INT DEFAULT 0)", cn);
                com.ExecuteNonQuery();

                //com = new OleDbCommand("CREATE TABLE duets(Номер INT DEFAULT 0, Номер_В_Группе INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Номер_Захода INT, ФИО1 CHAR(100), ФИО2 CHAR(100), Тип CHAR(4), Счет FLOAT DEFAULT 0, Оценки CHAR(255))", cn);
                com = new OleDbCommand("CREATE TABLE duets(Номер INT DEFAULT 0, Номер_В_Группе INT DEFAULT 0, Номер_Группы INT DEFAULT 0, ФИО1 CHAR(100), ФИО2 CHAR(100), Тип CHAR(4), Счет FLOAT DEFAULT 0, Оценки CHAR(255), Старший_Тренер INT DEFAULT 0, Тренер1 INT DEFAULT 0, Тренер2 INT DEFAULT 0)", cn);
                com.ExecuteNonQuery();

                com = new OleDbCommand("CREATE TABLE branches(Номер INT NOT NULL, Время_Начала CHAR(5), Время_Окончания CHAR(5), Группы CHAR(255), Туры CHAR(255), CONSTRAINT branch_pk PRIMARY KEY (Номер))", cn);
                //com = new OleDbCommand("CREATE TABLE branches(Номер INT NOT NULL, Время_Начала CHAR(5), Время_Окончания CHAR(5), CONSTRAINT branch_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //com = new OleDbCommand("CREATE TABLE duets(Номер INT DEFAULT 0, Номер_В_Группе INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Номер_Захода INT, ФИО1 CHAR(100), ФИО2 CHAR(100), Тип CHAR(4), Счет FLOAT DEFAULT 0, Оценки CHAR(255))", cn);
                com = new OleDbCommand("CREATE TABLE sets(Номер INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Список_Пар CHAR(255))", cn);
                com.ExecuteNonQuery();

                //com = new OleDbCommand("CREATE TABLE duets(Номер INT DEFAULT 0, Номер_В_Группе INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Номер_Захода INT, ФИО1 CHAR(100), ФИО2 CHAR(100), Тип CHAR(4), Счет FLOAT DEFAULT 0, Оценки CHAR(255))", cn);
                com = new OleDbCommand("CREATE TABLE tours(Номер_Группы INT DEFAULT 0, Степень INT DEFAULT 0, Список_Пар MEMO, Список_Пар_В_След_Тур MEMO, Колво_Пар INT DEFAULT 0, Колво_Пар_В_След_Тур INT DEFAULT 0)", cn);
                com.ExecuteNonQuery();

                TournirClass NewTournir = new TournirClass();

                NewTournir.name = previousForm.Name_textBox.Text.Replace(" ", "_");
                NewTournir.date = new MyDate(previousForm.DayOfTournir_comboBox.SelectedIndex + 1, previousForm.MounthOfTournir_comboBox.SelectedIndex + 1, Convert.ToInt32(previousForm.YearOfTournir_textBox.Text));
                NewTournir.time = new TimeClass(previousForm.HourTournirStart_comboBox.SelectedIndex, previousForm.MinutesTournirStart_comboBox.SelectedIndex * 5);
                //MessageBox.Show(NewTournir.name + NewTournir.info());
                NewTournir.place = previousForm.CityOfTournir_textBox.Text;
                NewTournir.organisation = previousForm.OrganisationOfTournir_textBox.Text;
                NewTournir.registrator = "SNP_registrator";
                NewTournir.secretary = "SNP_secretary";
                NewTournir.info();

                com = new OleDbCommand("INSERT INTO tournir(Название, Дата_Проведения,  Время_Проведения,  Место_Проведения, Организация, ФИО_Секретаря, ФИО_Регистратора)" + "VALUES (@name,@date,@time,@plase,@organisation,@secretary,@registrator)", cn);
                com.Parameters.AddWithValue("name", NewTournir.name);
                com.Parameters.AddWithValue("date", NewTournir.date.ToString());
                com.Parameters.AddWithValue("time", NewTournir.time.ToString());
                com.Parameters.AddWithValue("place", NewTournir.place);
                com.Parameters.AddWithValue("organisation", NewTournir.organisation);
                com.Parameters.AddWithValue("secretary", NewTournir.secretary);
                com.Parameters.AddWithValue("registrator", NewTournir.registrator);

                com.ExecuteNonQuery();
                cn.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void insertInParticipants(Sportsman sportsman, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO participants(Номер, Номер_Пары, Фамилия, Имя, Отчество, Дата_рождения, Город, Клуб, Категория, Номер_В_Группе, Номер_Группы)" + "VALUES (@Number, @DuetNumber, @Surname, @Name, @Patronymic, @BirthDate, @City, @Club, @AgeCategory,@NumInGroup, @GroupNumber)";

                command.Parameters.AddWithValue("Number", sportsman.NumberInTournir);
                command.Parameters.AddWithValue("DuetNumber", sportsman.DuetNumber);
                command.Parameters.AddWithValue("Surname", sportsman.Surname);
                command.Parameters.AddWithValue("Name", sportsman.Name);
                command.Parameters.AddWithValue("Patronymic", sportsman.Patronymic);
                command.Parameters.AddWithValue("BirthDate", sportsman.BirthDate.ToString());
                command.Parameters.AddWithValue("City", sportsman.City);
                command.Parameters.AddWithValue("Club", sportsman.ClubName);
                command.Parameters.AddWithValue("AgeCategory", sportsman.AgeCategory);
                command.Parameters.AddWithValue("NumInGroup", sportsman.NumberInGroup);
                command.Parameters.AddWithValue("GroupNumber", sportsman.GroupNumber);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
        }

        public static void insertInParticipants(Sportsman sportsman, int numInDuet, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                OleDbCommand command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO participants(Номер, Номер_Пары, Номер_В_Паре, Фамилия, Имя, Отчество, Дата_рождения, Город, Клуб, Категория, Номер_В_Группе, Номер_Группы)" + "VALUES (@Number, @DuetNumber, @NumInDuet, @Surname, @Name, @Patronymic, @BirthDate, @City, @Club, @AgeCategory,@NumInGroup, @GroupNumber)";

                command.Parameters.AddWithValue("Number", sportsman.NumberInTournir);
                command.Parameters.AddWithValue("DuetNumber", sportsman.DuetNumber);
                command.Parameters.AddWithValue("NumInDuet", numInDuet);
                command.Parameters.AddWithValue("Surname", sportsman.Surname);
                command.Parameters.AddWithValue("Name", sportsman.Name);
                command.Parameters.AddWithValue("Patronymic", sportsman.Patronymic);
                command.Parameters.AddWithValue("BirthDate", sportsman.BirthDate.ToString());
                command.Parameters.AddWithValue("City", sportsman.City);
                command.Parameters.AddWithValue("Club", sportsman.ClubName);
                command.Parameters.AddWithValue("AgeCategory", sportsman.AgeCategory);
                command.Parameters.AddWithValue("NumInGroup", sportsman.NumberInGroup);
                command.Parameters.AddWithValue("GroupNumber", sportsman.GroupNumber);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            try
            {
                    connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);

                command.CommandText = "INSERT INTO duets(Номер, Номер_В_Группе, Номер_Группы, ФИО1, Тип, Старший_Тренер, Тренер1, Тренер2)" + "VALUES (@Number, @NumberInGroup, @GroupNumber, @SNP, @Type, @TrainerOld, @Trainer1, @Trainer2)";
                command.Parameters.AddWithValue("Number", number);
                command.Parameters.AddWithValue("NumberInGroup", sportsman.NumberInGroup);
                command.Parameters.AddWithValue("GroupNumber", groupNumber);
                command.Parameters.AddWithValue("SNP", sportsman.Surname + ";" + sportsman.Name + ";" + sportsman.Patronymic + ";");
                command.Parameters.AddWithValue("Type", "Соло");
                command.Parameters.AddWithValue("TrainerOld", sportsman.OlderTrainer.Number);
                command.Parameters.AddWithValue("Trainer1", sportsman.FirstTrainer.Number);
                command.Parameters.AddWithValue("Trainer2", sportsman.SecondTrainer.Number);

                //MessageBox.Show($"Новый Солист:\n{sportsman.BookNumber}\nГруппа: {groupNumber}");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при записи очередного солиста...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_В_Группе, ФИО1, ФИО2, Тип, Старший_Тренер, Тренер1, Тренер2)" + "VALUES (@Number, @GroupNumber, @NumberInGroup, @SNP1, @SNP2, @Type, @TrainerOld, @Trainer1, @Trainer2)";
                    //command.CommandText = "INSERT INTO duets(Номер, Номер_Группы, Номер_Книжки1, Номер_Книжки2, Тип)" + "VALUES (@Number, @GroupNumber, @BookNumber1, @BookNumber2, @Type)";

                    command.Parameters.AddWithValue("Number", number);
                    //command.Parameters.AddWithValue("DuetNumber", sportsman1.DuetNumber);
                    command.Parameters.AddWithValue("GroupNumber", groupNumber);
                    command.Parameters.AddWithValue("NumberInGroup", sportsman1.NumberInGroup);
                    //command.Parameters.AddWithValue("SetNumber", setNumber);
                    command.Parameters.AddWithValue("@SNP1", sportsman1.Surname + ";" + sportsman1.Name + ";" + sportsman1.Patronymic + ";");
                    command.Parameters.AddWithValue("@SNP2", sportsman2.Surname + ";" + sportsman2.Name + ";" + sportsman2.Patronymic + ";");
                    command.Parameters.AddWithValue("Type", "Пара");
                    command.Parameters.AddWithValue("TrainerOld", sportsman1.OlderTrainer.Number);
                    command.Parameters.AddWithValue("Trainer1", sportsman1.FirstTrainer.Number);
                    command.Parameters.AddWithValue("Trainer2", sportsman1.SecondTrainer.Number);
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

        public static void insertTrainer(Trainer trainer, int Number) //potencial DELETING
        {
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            commandTrain.CommandText = "INSERT INTO Trainers(Номер, Код, Фамилия, Имя, Отчество)" + "VALUES (@Number,@Surname,@Name,@Patronymic)";

            //trainer.pasItendificate();
            commandTrain.Parameters.AddWithValue("Number", Number);
            //commandTrain.Parameters.AddWithValue("Pas", trainer.Pas);
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

            command4.CommandText = "SELECT Клуб FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command4.Parameters.AddWithValue("BookNum", BookNumber);

            command5.CommandText = "SELECT Город FROM Sportsmans WHERE НомерКнижки = @BookNum";
            command5.Parameters.AddWithValue("BookNum", BookNumber);

            command6.CommandText = "SELECT Дата_Рождения FROM Sportsmans WHERE НомерКнижки = @BookNum";
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
                //string[] tmpOrder = command8.ExecuteScalar().ToString().Replace(" ", "").Split(new char[] { ';' });
                
                //string retstr = "";
                //MessageBox.Show("Len: " + tmpOrder.Length.ToString() + " " + tmpOrder[1]);
                //RetTournir.groupsOrder = new ushort[tmpOrder.Length - 1];
                //RetTournir.groupsOrder = new List<ushort>(tmpOrder.Length - 1;
                //for (i = 0; i < tmpOrder.Length - 1; i++)
                //{
                //    RetTournir.groupsOrder[i] = (ushort)Convert.ToInt32(tmpOrder[i]);
                //    retstr += RetTournir.groupsOrder[i].ToString() + " ";
                //}
                //MessageBox.Show("Len: " + tmpOrder.Length.ToString() + " " + retstr);
                //MessageBox.Show($"Турнир: {RetTournir.name}\nДата: {RetTournir.date}\nВремя: {RetTournir.time}\nМесто: {RetTournir.place}\nОрганизация: {RetTournir.organisation}\nСекретарь: {RetTournir.secretary}\nРегистратор: {RetTournir.registrator}");
                //myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так... код 1\nError: " + ex.Message);
            } //заполнение Турнира

            //try
            //{
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

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Отделение FROM groups WHERE Номер_Группы = @id";
                    command.Parameters.AddWithValue("id", i);
                    RetTournir.groups[i - 1].branchNumber = (ushort)Convert.ToInt32(command.ExecuteScalar());
                    //MessageBox.Show(RetTournir.groups[i - 1].show());

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Система FROM groups WHERE Номер_Группы = @id";
                    command.Parameters.AddWithValue("id", i);
                    RetTournir.groups[i - 1].system = (int)Convert.ToInt32(command.ExecuteScalar());   

                    RetTournir.groups[i - 1].JudgeList = TakeJudges(RetTournir.groups[i - 1], cn);
                    //MessageBox.Show(RetTournir.groups[i - 1].show());

                    //MessageBox.Show("Вытягивание списка пар");
                    RetTournir.groups[i - 1].duetList = TakeDuets(RetTournir.groups[i - 1], cn);
                    //MessageBox.Show(RetTournir.groups[i - 1].show());
                    RetTournir.groups[i - 1].SetList = TakeSet(RetTournir.groups[i - 1], cn);
                    RetTournir.groups[i - 1].tours = TakeTours(RetTournir.groups[i - 1], cn);
                    string str2 = "Туры в группе №" + i.ToString() + ":\n";
                    foreach (Tour item in RetTournir.groups[i - 1].tours)
                    {
                        str2 += item.ToString() + "\n";
                    }
                    //MessageBox.Show(str2);
                    i++;
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Упс, что-то пошло не так при определении списка групп\nError: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //} //заполнение групп

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
                MessageBox.Show("Упс, что-то пошло не так при определении списка судей\nError: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } //заполнение судей

            try
            {
                string str1 = "";
                RetTournir.Branches = TakeBranch(cn);
                RetTournir.toursOrder = new List<ushort[,]>();
                foreach (Branch itemBranch in RetTournir.Branches)
                {
                    foreach (int item in itemBranch.groupOrderList)
                        RetTournir.groupsOrder.Add((ushort)item);
                    RetTournir.toursOrder.Add(itemBranch.toursOrder);
                }
                foreach (ushort[,] item in RetTournir.toursOrder)
                    for (int d = 0; d < item.Length/2; d++)
                    {
                        str1 += "[" + item[d, 0].ToString() + "; " + item[d, 1].ToString() + "]";
                    }
                //MessageBox.Show(str1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            myConnection.Close();
            //RetTournir.Show();
            //RetTournir.info2();

            return RetTournir;
        }
        public static void clearSet(GroupClass groupInput, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);

                command.CommandText = "DELETE FROM sets WHERE Номер_Группы = @id"; //NSP
                command.Parameters.AddWithValue("id", groupInput.number);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так...\n" + ex.Message);
            }
        }

        public static void clearTours(GroupClass groupInput, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);

                command.CommandText = "DELETE FROM tours WHERE Номер_Группы = @id"; //NSP
                command.Parameters.AddWithValue("id", groupInput.number);
                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так...\n" + ex.Message);
            }
        }

        public static void insertSet(SetClass setInput, string path)
        {
            try
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                command = new OleDbCommand("", myConnection);
                command.CommandText = "INSERT INTO sets(Номер, Номер_Группы, Список_Пар)" + "VALUES (@number, @group_number, @duets)";

                command.Parameters.AddWithValue("number", setInput.number);
                command.Parameters.AddWithValue("group_number", setInput.numberOfGroup);
                command.Parameters.AddWithValue("duets", setInput.getDuetString());

                command.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс, что-то пошло не так...\n" + ex.Message);
            }
        }

        public static void insertTours(GroupClass groupInput, string path)
        {
            //try
            //{
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
                myConnection = new OleDbConnection(connectString);
                myConnection.Open();

                for (int i = 0; i < groupInput.tours.Count; i++)
                {
                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "INSERT INTO tours(Номер_Группы, Степень, Колво_Пар)" + "VALUES (@group_number, @degree, @countOfDuets)";
                    //MessageBox.Show("group: " + groupInput.number.ToString() + "degree: " + groupInput.tours[i].degree);
                    command.Parameters.AddWithValue("group_number", groupInput.number);
                    command.Parameters.AddWithValue("degree", groupInput.tours[i].degree);
                    command.Parameters.AddWithValue("countOfDuets", groupInput.tours[i].countOfDuets);

                command.ExecuteNonQuery();
                }
                myConnection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Упс, что-то пошло не так...\n" + ex.Message);
            //}
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

        public static void insertGroup(GroupClass group_new, string dances, string categories, string cn)
        {
            OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
            con.Open();
            OleDbCommand com1 = new OleDbCommand();
            OleDbCommand com2 = new OleDbCommand();
            com1 = new OleDbCommand("INSERT INTO groups(Название_Турнира, Номер_Группы, Отделение, Категория, Категории, Танцы, Система)" + "VALUES (@tournir_name, @group_number, @branch, @category, @categories, @dances, @system)", con);

            com1.Parameters.AddWithValue("tournir_name", group_new.tournir_name);
            com1.Parameters.AddWithValue("group_number", group_new.number);
            com1.Parameters.AddWithValue("branch", group_new.branchNumber);
            com1.Parameters.AddWithValue("category", group_new.name);

            com1.Parameters.AddWithValue("categories", categories);
            com1.Parameters.AddWithValue("dances", dances);
            com1.Parameters.AddWithValue("system", group_new.system);

            com1.ExecuteNonQuery();
        }

        public static void insertBranch(Branch inputBranch, string cn)
        {
            OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
            con.Open();
            OleDbCommand command = new OleDbCommand("INSERT INTO branches(Номер, Время_Начала, Время_Окончания)" + "VALUES (@number,@sTime,@fTime)", con);
            command.Parameters.AddWithValue("name", inputBranch.number);
            command.Parameters.AddWithValue("sTime", inputBranch.startTime.ToString());
            command.Parameters.AddWithValue("fTime", inputBranch.finishTime.ToString());

            command.ExecuteNonQuery();
            con.Close();
        }

        public static List<SetClass> TakeSet(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<SetClass> SetList_New = new List<SetClass>();

            //try
            //{
                int i = 1;
                int max = 0;
                int counter = 0;

                BitArray checkArray = Controller.GapCounter("Номер", "sets", "Номер_Группы", input_group.number, myConnection);

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT MAX(Номер) FROM sets WHERE Номер_Группы = @id";
                command.Parameters.AddWithValue("id", input_group.number);

                if (command.ExecuteScalar() != DBNull.Value && checkArray != null)
                {
                    max = Convert.ToInt32(command.ExecuteScalar());

                    //MessageBox.Show($"MAX в группе {input_group.number}: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        if (i <= max)
                        {
                            if (checkArray[i - 1])
                            {
                                command = new OleDbCommand("", myConnection);
                                command.CommandText = "SELECT Список_Пар FROM sets WHERE Номер = @id AND Номер_Группы = @num";
                                command.Parameters.AddWithValue("id", i);
                                command.Parameters.AddWithValue("num", input_group.number);
                                SetList_New.Add(new SetClass(input_group.number, i));

                                //MessageBox.Show(command.ExecuteScalar().ToString());
                                int[] numArray = SetList_New[SetList_New.Count - 1].getDuetListFromString(command.ExecuteScalar().ToString());
                                //OleDbDataReader reader = command.ExecuteReader();
                                
                                Duet tmpDuet = new Duet();
                                foreach (int intArrayItem in numArray)
                                    for (int g = 0; g < input_group.duetList.Count; g++)
                                        if (input_group.duetList[g].number == intArrayItem)
                                            SetList_New[SetList_New.Count - 1].DuetList.Add(input_group.duetList[g]);
                            }
                            else
                            {
                                counter++;
                            }
                        }
                        i++;
                    }
                }
                else
                {
                    //MessageBox.Show("Нулевой результат запроса");
                }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Упс, что-то пошло не так при определении списка заходов\nError: " + ex.Message);
            //}

            myConnection.Close();
            return SetList_New;
        }

        public static List<Tour> TakeTours(GroupClass input_group, string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<Tour> tourList_New = new List<Tour>();

            //try
            //{
            int count = 0;

            //BitArray checkArray = Controller.GapCounter("Номер", "tours", "Номер_Группы", input_group.number, myConnection);

            command = new OleDbCommand("", myConnection);
            command.CommandText = "SELECT Count(Номер) FROM tours WHERE Номер_Группы = @id";
            command.Parameters.AddWithValue("id", input_group.number);

            //if (command.ExecuteScalar() != DBNull.Value)
            //{
                count = Convert.ToInt32(command.ExecuteScalar());

                //MessageBox.Show($"MAX в группе {input_group.number}: " + counter.ToString());

                for (int i = 0; i < count; i++)
                {
                    tourList_New.Add(new Tour(i, 0));

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Список_Пар FROM tours WHERE Степень = @degree AND Номер_Группы = @num";
                    command.Parameters.AddWithValue("degree", i);
                    command.Parameters.AddWithValue("num", input_group.number);
                    tourList_New[tourList_New.Count - 1].tourBitMap = new BitArray(input_group.duetList.Count, false);
                    int[] numArray = tourList_New[tourList_New.Count - 1].getDuetListFromString(command.ExecuteScalar().ToString());
                    //foreach (int intArrayItem in numArray)
                    for (int g = 0; g < numArray.Length - 1; g++)
                        if (numArray[g] == 1) tourList_New[tourList_New.Count - 1].tourBitMap[g] = true;
                        else tourList_New[tourList_New.Count - 1].tourBitMap[g] = false;

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Список_Пар_В_Следующий_Тур FROM tours WHERE Степень = @degree AND Номер_Группы = @num";
                    command.Parameters.AddWithValue("degree", i);
                    command.Parameters.AddWithValue("num", input_group.number);
                    tourList_New[tourList_New.Count - 1].nextTourBitMap = new BitArray(input_group.duetList.Count, false);
                    numArray = tourList_New[tourList_New.Count - 1].getDuetListFromString(command.ExecuteScalar().ToString());
                    for (int g = 0; g < numArray.Length - 1; g++)
                        if (numArray[g] == 1) tourList_New[tourList_New.Count - 1].nextTourBitMap[g] = true;
                        else tourList_New[tourList_New.Count - 1].nextTourBitMap[g] = false;

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Колво_Пар FROM tours WHERE Степень = @degree AND Номер_Группы = @num";
                    command.Parameters.AddWithValue("degree", i);
                    command.Parameters.AddWithValue("num", input_group.number);
                    string result = command.ExecuteScalar().ToString();
                    if(result.Length > 0)
                    tourList_New[tourList_New.Count - 1].countOfDuets = Convert.ToInt32(command.ExecuteScalar().ToString());

                    command = new OleDbCommand("", myConnection);
                    command.CommandText = "SELECT Колво_Пар_В_Следующий_Тур FROM tours WHERE Степень = @degree AND Номер_Группы = @num";
                    command.Parameters.AddWithValue("degree", i);
                    command.Parameters.AddWithValue("num", input_group.number);
                    result = command.ExecuteScalar().ToString();
                    if (result.Length > 0)
                    tourList_New[tourList_New.Count - 1].countOfDuetsNextTour = Convert.ToInt32(command.ExecuteScalar().ToString());
                }
            //}
            //else
            //{
            //    //MessageBox.Show("Нулевой результат запроса");
            //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Упс, что-то пошло не так при определении списка заходов\nError: " + ex.Message);
            //}

            myConnection.Close();
            return tourList_New;
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
                    //string SNP1;
                    //string SNP2;
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
                    try
                    {
                        if (mark >= 0) input_group.markered = true;
                    }
                    catch { }
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

                    //Sportsman sportsman1 = SecretaryController.TakeSportsman(input_group.number, i + 1, 1, cn);
                    Sportsman sportsman1 = SecretaryController.TakeSportsman(input_group.number, number, 1, cn);

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Старший_Тренер FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    int OldTrainerNumber = Convert.ToInt32(command2.ExecuteScalar());

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Тренер1 FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    int FirstTrainerNumber = Convert.ToInt32(command2.ExecuteScalar());

                    command2 = new OleDbCommand("", myConnection);
                    command2.CommandText = "SELECT Тренер2 FROM duets WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
                    command2.Parameters.AddWithValue("num", input_group.number);
                    command2.Parameters.AddWithValue("id", i + 1);
                    int SecondTrainerNumber = Convert.ToInt32(command2.ExecuteScalar());

                    command5 = new OleDbCommand("", myConnection);

                    command5.CommandText = "SELECT ФИО FROM trainers WHERE Номер = @id";
                    //command3.Parameters.AddWithValue("num", input_group.number);
                    command5.Parameters.AddWithValue("id", number);
                //int countOfTrainers = Convert.ToInt32(command5.ExecuteScalar().ToString());
                List<Trainer> tmpListTrainers = new List<Trainer>(3);

                //switch (countOfTrainers)
                //{
                //    case 1:
                //        tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Старший", myConnection));
                //        break;
                //    case 2:
                //        tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Старший", myConnection));
                //        tmpListTrainers.Add(SecretaryController.TakeTrainer(number, input_group.number, "Первый", myConnection));
                //        break;
                //    case 3:
                if (OldTrainerNumber > 0)
                    tmpListTrainers.Add(SecretaryController.TakeTrainer(OldTrainerNumber, "Старший", myConnection));
                if (FirstTrainerNumber > 0)
                    tmpListTrainers.Add(SecretaryController.TakeTrainer(FirstTrainerNumber, "Первый", myConnection));
                if (SecondTrainerNumber > 0)
                    tmpListTrainers.Add(SecretaryController.TakeTrainer(SecondTrainerNumber, "Второй", myConnection));

                    //        break;
                    //}

                    if (Type == "Пара")
                    {
                        //Sportsman sportsman2 = SecretaryController.TakeSportsman(input_group.number, i + 1, 2, cn);
                        Sportsman sportsman2 = SecretaryController.TakeSportsman(input_group.number, number, 2, cn);
                        //MessageBox.Show(sportsman1.ToString() + " " + sportsman2.ToString() + "\n");
                        set_new = new Duet(number, i + 1, input_group.number, sportsman1, sportsman2, mark);
                    }
                    else
                        set_new = new Duet(number, i + 1, input_group.number, sportsman1, mark);
                    set_new.trainers = tmpListTrainers;
                    set_new.diplomPlace = getDiplomPlace(mark);
                    set_new.judgeMarkList = newMarksList;
                    set_new.type = Type;
                    getMarksSum(set_new);
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

        public static Sportsman TakeSportsman(int groupNumber, int numberInGroup, string cn)
        {
            Sportsman sportsmanTemp = new Sportsman();

            OleDbCommand command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Фамилия FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", numberInGroup);
            sportsmanTemp.Surname = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Имя FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", numberInGroup);
            sportsmanTemp.Name = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Отчество FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", numberInGroup);
            sportsmanTemp.Patronymic = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Дата_рождения FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", numberInGroup);
            sportsmanTemp.BirthDate = new MyDate();
            sportsmanTemp.BirthDate.ToInt(command3.ExecuteScalar().ToString().Replace(" ", ""));

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Город FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", numberInGroup);
            sportsmanTemp.City = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Клуб FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", numberInGroup);
            sportsmanTemp.ClubName = command3.ExecuteScalar().ToString().Replace(" ", "");

            return sportsmanTemp;
        }

        //public static Sportsman TakeSportsman(int groupNumber, int numberInGroup, int numberInDuet, string cn)
        //{
        //    Sportsman sportsmanTemp = new Sportsman();
        //    MessageBox.Show(groupNumber.ToString() + numberInGroup.ToString() + numberInDuet.ToString());
        //    OleDbCommand command3 = new OleDbCommand("", myConnection);
        //    command3.CommandText = "SELECT Фамилия FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id AND Номер_В_Паре = @numInDuet";
        //    command3.Parameters.AddWithValue("num", groupNumber);
        //    command3.Parameters.AddWithValue("id", numberInGroup);
        //    command3.Parameters.AddWithValue("numInDuet", numberInGroup);
        //    sportsmanTemp.Surname = command3.ExecuteScalar().ToString().Replace(" ", "");

        //    command3 = new OleDbCommand("", myConnection);
        //    command3.CommandText = "SELECT Имя FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id AND Номер_В_Паре = @numInDuet";
        //    command3.Parameters.AddWithValue("num", groupNumber);
        //    command3.Parameters.AddWithValue("id", numberInGroup);
        //    command3.Parameters.AddWithValue("numInDuet", numberInGroup);
        //    sportsmanTemp.Name = command3.ExecuteScalar().ToString().Replace(" ", "");

        //    command3 = new OleDbCommand("", myConnection);
        //    command3.CommandText = "SELECT Отчество FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id AND Номер_В_Паре = @numInDuet";
        //    command3.Parameters.AddWithValue("num", groupNumber);
        //    command3.Parameters.AddWithValue("id", numberInGroup);
        //    command3.Parameters.AddWithValue("numInDuet", numberInGroup);
        //    sportsmanTemp.Patronymic = command3.ExecuteScalar().ToString().Replace(" ", "");

        //    command3 = new OleDbCommand("", myConnection);
        //    command3.CommandText = "SELECT Дата_рождения FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id AND Номер_В_Паре = @numInDuet";
        //    command3.Parameters.AddWithValue("num", groupNumber);
        //    command3.Parameters.AddWithValue("id", numberInGroup);
        //    command3.Parameters.AddWithValue("numInDuet", numberInGroup);
        //    sportsmanTemp.BirthDate = new MyDate();
        //    sportsmanTemp.BirthDate.ToInt(command3.ExecuteScalar().ToString().Replace(" ", ""));

        //    command3 = new OleDbCommand("", myConnection);
        //    command3.CommandText = "SELECT Город FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id AND Номер_В_Паре = @numInDuet";
        //    command3.Parameters.AddWithValue("num", groupNumber);
        //    command3.Parameters.AddWithValue("id", numberInGroup);
        //    command3.Parameters.AddWithValue("numInDuet", numberInGroup);
        //    sportsmanTemp.City = command3.ExecuteScalar().ToString().Replace(" ", "");

        //    command3 = new OleDbCommand("", myConnection);
        //    command3.CommandText = "SELECT Клуб FROM Participants WHERE Номер_Группы = @num AND Номер_В_Группе = @id AND Номер_В_Паре = @numInDuet";
        //    command3.Parameters.AddWithValue("num", groupNumber);
        //    command3.Parameters.AddWithValue("id", numberInGroup);
        //    command3.Parameters.AddWithValue("numInDuet", numberInGroup);
        //    sportsmanTemp.ClubName = command3.ExecuteScalar().ToString().Replace(" ", "");

        //    return sportsmanTemp;
        //}

        public static Sportsman TakeSportsman(int groupNumber, int duetNumber, int numberInDuet, string cn)
        {
            Sportsman sportsmanTemp = new Sportsman();
            //MessageBox.Show(groupNumber.ToString() + duetNumber.ToString() + numberInDuet.ToString());
            OleDbCommand command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Фамилия FROM Participants WHERE Номер_Группы = @num AND Номер_Пары = @id AND Номер_В_Паре = @numInDuet";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", duetNumber);
            command3.Parameters.AddWithValue("numInDuet", numberInDuet);
            sportsmanTemp.Surname = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Имя FROM Participants WHERE Номер_Группы = @num AND Номер_Пары = @id AND Номер_В_Паре = @numInDuet";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", duetNumber);
            command3.Parameters.AddWithValue("numInDuet", numberInDuet);
            sportsmanTemp.Name = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Отчество FROM Participants WHERE Номер_Группы = @num AND Номер_Пары = @id AND Номер_В_Паре = @numInDuet";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", duetNumber);
            command3.Parameters.AddWithValue("numInDuet", numberInDuet);
            sportsmanTemp.Patronymic = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Дата_рождения FROM Participants WHERE Номер_Группы = @num AND Номер_Пары = @id AND Номер_В_Паре = @numInDuet";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", duetNumber);
            command3.Parameters.AddWithValue("numInDuet", numberInDuet);
            sportsmanTemp.BirthDate = new MyDate();
            sportsmanTemp.BirthDate.ToInt(command3.ExecuteScalar().ToString().Replace(" ", ""));

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Город FROM Participants WHERE Номер_Группы = @num AND Номер_Пары = @id AND Номер_В_Паре = @numInDuet";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", duetNumber);
            command3.Parameters.AddWithValue("numInDuet", numberInDuet);
            sportsmanTemp.City = command3.ExecuteScalar().ToString().Replace(" ", "");

            command3 = new OleDbCommand("", myConnection);
            command3.CommandText = "SELECT Клуб FROM Participants WHERE Номер_Группы = @num AND Номер_Пары = @id AND Номер_В_Паре = @numInDuet";
            command3.Parameters.AddWithValue("num", groupNumber);
            command3.Parameters.AddWithValue("id", duetNumber);
            command3.Parameters.AddWithValue("numInDuet", numberInDuet);
            sportsmanTemp.ClubName = command3.ExecuteScalar().ToString().Replace(" ", "");

            return sportsmanTemp;
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
        public static List<Branch> TakeBranch(string cn)
        {
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();

            List<Branch> branches = new List<Branch>();
            Branch branch = new Branch();

            //try
            //{
                int i = 1;
                int max = 0;

                BitArray checkArray = Controller.GapCounter("Номер", "branches", myConnection);

                command = new OleDbCommand("", myConnection);
                command.CommandText = "SELECT MAX(Номер) FROM branches";

                if (command.ExecuteScalar() != DBNull.Value && checkArray != null)
                {
                    max = Convert.ToInt32(command.ExecuteScalar());

                    //MessageBox.Show($"MAX в группе {input_group.number}: " + Convert.ToString(max));

                    foreach (bool item in checkArray)
                    {
                        //for(i = 1; i <= max; i++)
                        //{
                        //if (i <= max)
                        if (checkArray[i - 1])
                        {
                            branch = new Branch();
                            branch.number = i;
                            command = new OleDbCommand("", myConnection);
                            command.CommandText = "SELECT Время_Начала FROM branches WHERE Номер = @id";
                            command.Parameters.AddWithValue("id", i);
                            branch.startTime.ToInt(command.ExecuteScalar().ToString());

                            command = new OleDbCommand("", myConnection);
                            command.CommandText = "SELECT Время_Окончания FROM branches WHERE Номер = @id";
                            command.Parameters.AddWithValue("id", i);
                            branch.finishTime.ToInt(command.ExecuteScalar().ToString().Replace(" ", ""));

                            command = new OleDbCommand("", myConnection);
                            command.CommandText = "SELECT Группы FROM branches WHERE Номер = @id";
                            command.Parameters.AddWithValue("id", i);

                            string groupsStr = Convert.ToString(command.ExecuteScalar()).Replace(" ", "");
                            string[] groupsStrSplited = groupsStr.Split(new char[] { ';' });
                            if (groupsStrSplited.Length > 0)
                                for (int f = 0; f < groupsStrSplited.Length - 1; f++)
                                    if (groupsStrSplited[f] != "") branch.groupOrderList.Add(Convert.ToInt32(groupsStrSplited[f]));

                            command = new OleDbCommand("", myConnection);
                            command.CommandText = "SELECT Туры FROM branches WHERE Номер = @id";
                            command.Parameters.AddWithValue("id", i);

                            string groupsStrTours = Convert.ToString(command.ExecuteScalar()).Replace(" ", "");
                            string[] groupsStrTourSplited = groupsStrTours.Split(new char[] { ';' });
                            branch.countOfTours = groupsStrTourSplited.Length - 1;
                            //MessageBox.Show(branch.countOfTours.ToString());

                            branch.toursOrder = new ushort[branch.countOfTours, 2];
                            string str1 = "";
                            if (groupsStrTourSplited.Length > 0)
                                for (int f = 0; f < groupsStrTourSplited.Length - 1; f++)
                                    if (groupsStrTourSplited[f] != "")
                                    {
                                        //MessageBox.Show(groupsStrTourSplited[f].Substring(0, groupsStrTourSplited[f].IndexOf(".")));
                                        branch.toursOrder[f, 0] = (ushort)(Convert.ToInt32(groupsStrTourSplited[f].Substring(0, groupsStrTourSplited[f].IndexOf("."))));
                                        //MessageBox.Show(groupsStrTourSplited[f].Substring(groupsStrTourSplited[f].IndexOf("."), groupsStrTourSplited[f].Length - 1).Replace(".", ""));
                                        branch.toursOrder[f, 1] = (ushort)(Convert.ToInt32(groupsStrTourSplited[f].Substring(groupsStrTourSplited[f].IndexOf("."), groupsStrTourSplited[f].Length - 1).Replace(".","")));
                                        str1 += "[" + branch.toursOrder[f, 0] + " " + branch.toursOrder[f, 1] + "]\n";
                                    }
                            //MessageBox.Show(str1);
                            branches.Add(branch);
                        }
                        i++;
                    }
                }
                //else
                //{
                //    MessageBox.Show("Нулевой результат запроса");
                //}
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Упс, что-то пошло не так при определении списка отделений\nError: " + ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            myConnection.Close();
            return branches;
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
                //else
                //{
                //    MessageBox.Show("Нулевой результат запроса");
                //}
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

        public static Trainer TakeTrainer(int Num, string status, OleDbConnection cn)
        {
            //connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}";
            //myConnection = new OleDbConnection(connectString);
            //myConnection.Open();

            Trainer tmpTrainer = new Trainer();
            try
            {
                //OleDbCommand command = new OleDbCommand($"SELECT ФИО FROM trainers WHERE Номер_Группы = @num AND Номер_Пары = @id AND Категория = @Categ", cn);
                OleDbCommand command = new OleDbCommand($"SELECT ФИО FROM trainers WHERE Номер = @id", cn);
                //command.Parameters.AddWithValue("num", groupNum);
                command.Parameters.AddWithValue("id", Num);

                string[] SNPstring = command.ExecuteScalar().ToString().Replace(" ", "").Split(new char[] { ';', ' ' });
                tmpTrainer.Surname = SNPstring[0];
                tmpTrainer.Name = SNPstring[1];
                tmpTrainer.Patronymic = SNPstring[2];

                tmpTrainer.Status = status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так при определении тренера {status} {Num} пары\nError: " + ex.Message);

            }

            //myConnection.Close();

            return tmpTrainer;
        }

        //2
        //3
        //4
        //5
        //6
        //***открываем.соединение();
        //DataSet ds = new DataSet();
        //        SqlDataAdapter dataAdapter = new SqlDataAdapter(comand, connection);
        //        dataAdapter.Fill(ds, "grazdanin");           
        //dataGridView1.DataSource = ds.Tables["grazdanin"];
        //***закрываем.соединение();

        public static void FillParticipantsDataViewer(DataGridView dataGrid, string cn)
        {
            try
            {
                OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
                con.Open();

                OleDbDataAdapter dbAdapter = new OleDbDataAdapter("SELECT Номер_Пары, Номер_Группы, Фамилия, Имя, Отчество, Дата_рождения, Город, Клуб, Категория FROM [participants]", con); ;
                DataTable dataTable = new DataTable();

                dbAdapter.Fill(dataTable);
                dataGrid.DataSource = dataTable;

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            //MessageBox.Show(marksString);
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

        public static void UpdateGroupsOrder(string orderString, int number, string cn)
        {
            OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
            con.Open();

            OleDbCommand command = new OleDbCommand();
            command = new OleDbCommand("", con);
            command.CommandText = "UPDATE branches SET Группы = @tmpOrder WHERE Номер = @id";
            command.Parameters.AddWithValue("tmpOrder", orderString);
            command.Parameters.AddWithValue("id", number);
            command.ExecuteNonQuery();

            con.Close();
        }

        public static void UpdateToursOrderInBranch(string orderString, int number, string cn)
        {
            OleDbConnection con = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={cn}");
            con.Open();

            OleDbCommand command = new OleDbCommand();
            command = new OleDbCommand("", con);
            command.CommandText = "UPDATE branches SET Туры = @Order WHERE Номер = @id";
            command.Parameters.AddWithValue("Order", orderString);
            command.Parameters.AddWithValue("id", number);
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

        public static int insertTrainer(Trainer trainer,int duetNum ,string path)
        {
            int retInt = 0;
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            OleDbCommand command = new OleDbCommand("SELECT MAX(Номер) FROM trainers", myConnection);
            if (command.ExecuteScalar() != DBNull.Value)
                retInt = Convert.ToInt32(command.ExecuteScalar()) + 1;
            else
                retInt = 1;

            commandTrain.CommandText = "INSERT INTO trainers(Номер_Пары, ФИО, Категория)" + "VALUES (@Num, @SNP, @Category)";

            //trainer.pasItendificate();
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
            return retInt;
        }

        public static int checkTrainerExist(Trainer inputTrainer, string path)
        {
            int retInt = 0;
            connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={path}";
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            OleDbCommand commandTrain = new OleDbCommand("", myConnection);

            //commandTrain.CommandText = "SELECT Номер FROM trainers WHERE ФИО like @SNP";
            //command.Parameters.AddWithValue("SNP", inputTrainer.Surname + ";" + inputTrainer.Name + ";" + inputTrainer.Patronymic + ";%");

            commandTrain.CommandText = "SELECT Номер FROM trainers WHERE ФИО = @SNP";
            commandTrain.Parameters.AddWithValue("SNP", inputTrainer.Surname + ";" + inputTrainer.Name + ";" + inputTrainer.Patronymic + ";");

            try
            {
                if (commandTrain.ExecuteScalar() != null)
                    retInt = Convert.ToInt32(commandTrain.ExecuteScalar());
                //MessageBox.Show(retInt.ToString());
                myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                myConnection.Close();
            }
            //SELECT * FROM Text WHERE Val like 'Hello%world'
            return retInt;
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
            int counter = 0;
            SetClass tempSet = new SetClass();
            int countOfDuetsInSet = (int)(inputGroup.duetList.Count / countOfSets) + 1;
            //MessageBox.Show(countOfDuetsInSet.ToString());
            if ((inputGroup.duetList.Count % countOfSets) == 0 && inputGroup.duetList.Count > countOfSets)
                countOfDuetsInSet = (int)(inputGroup.duetList.Count / countOfSets);
            else
                countOfDuetsInSet = (int)(inputGroup.duetList.Count / countOfSets) + 1;

            counter = 0;
            int counterSet = -1;
            foreach (Duet duetItem in inputGroup.duetList)
            {
                if (counter % countOfDuetsInSet == 0)
                {
                    counterSet++;
                    inputGroup.SetList.Add(new SetClass(inputGroup.number, counterSet + 1));
                }
                inputGroup.SetList[counterSet].DuetList.Add(inputGroup.duetList[counter]);
                counter++;
            }
        }

        public static void splitGroupForSets(GroupClass inputGroup, ushort countOfSets, BitArray tourBitMap)
        {
            int counter = 0;
            SetClass tempSet = new SetClass();
            int countOfDuetsInSet = (int)(inputGroup.duetList.Count / countOfSets) + 1;
            int countOfValidDuetsInBitMap = 0;
            for (int i = 0; i < tourBitMap.Length; i++)
                if (tourBitMap[i]) countOfValidDuetsInBitMap++;
            if ((countOfValidDuetsInBitMap % countOfSets) == 0 && countOfValidDuetsInBitMap > countOfSets)
                countOfDuetsInSet = (int)(countOfValidDuetsInBitMap / countOfSets);
            else
                countOfDuetsInSet = (int)(countOfValidDuetsInBitMap / countOfSets) + 1;
            //MessageBox.Show("В заходе: " + countOfDuetsInSet.ToString());
            counter = 0;
            int counterSet = -1;
            inputGroup.SetList.Clear();
            foreach (Duet duetItem in inputGroup.duetList)
            {
                if (tourBitMap[inputGroup.duetList.IndexOf(duetItem)])
                {
                    MessageBox.Show(inputGroup.duetList.IndexOf(duetItem).ToString());
                    if (counter % countOfDuetsInSet == 0)
                    {
                        counterSet++;
                        inputGroup.SetList.Add(new SetClass(inputGroup.number, counterSet + 1));
                    }
                    inputGroup.SetList[counterSet].DuetList.Add(duetItem);
                    counter++;
                }
            }
        }
    }
}
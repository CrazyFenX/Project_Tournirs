using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public partial class CreatingTournirDBForm : Form
    {
        private secretaryForm previousForm;
        public string folderName;
        public string dbName;

        public CreatingTournirDBForm()
        {
            InitializeComponent();
            folderBrowserDialog1.SelectedPath = @"C:\Users\Кирилл\source\repos\DataViewer_D_v.001\DataViewer_D_v.001\bin\x86\Debug\tournirs";
        }

        public CreatingTournirDBForm(secretaryForm PreviousForm)
        {
            InitializeComponent();
            this.previousForm = PreviousForm;
            folderBrowserDialog1.SelectedPath = @"C:\Users\Кирилл\source\repos\DataViewer_D_v.001\DataViewer_D_v.001\bin\x86\Debug\tournirs";
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = folderBrowserDialog1.SelectedPath;
            }
            Path_textBox.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            this.previousForm.Enabled = true;
            this.Hide();
        }

        private void CreatingTournirDBForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Enabled = true;
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
            if (Name_textBox.Text != "" && Path_textBox.Text != "" && DayOfTournir_comboBox.SelectedIndex != -1 && MounthOfTournir_comboBox.SelectedIndex != -1 &&
                HourTournirStart_comboBox.SelectedIndex != -1 && MinutesTournirStart_comboBox.SelectedIndex != -1 && CityOfTournir_textBox.Text != "" && OrganisationOfTournir_textBox.Text != "")
            {
                folderName = "";
                folderName = Path_textBox.Text;
                dbName = Name_textBox.Text;
                folderName += '\\';
                folderName += dbName;

                try
                {
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

                    //Создание Таблицы Заходов
                    ///доработка связей///com = new OleDbCommand("CREATE TABLE sets(Номер_Захода INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Категория CHAR(5), CONSTRAINT sets_uq UNIQUE(Номер_Захода, Номер_Группы), CONSTRAINT sets_pk PRIMARY KEY (Номер_Захода, Номер_Группы), CONSTRAINT fk_sets FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                    //com = new OleDbCommand("CREATE TABLE sets(Номер_Захода INT DEFAULT 0, Номер_Группы INT DEFAULT 0, Категория CHAR(5), CONSTRAINT sets_pk PRIMARY KEY (Номер_Захода, Номер_Группы))", cn);
                    //com.ExecuteNonQuery();

                    //Создание Таблицы Танцев
                    //com = new OleDbCommand("CREATE TABLE dances(Номер_Книжки INT, Номер_Группы INT DEFAULT 0, Название CHAR(20), CONSTRAINT dance_pk PRIMARY KEY (Номер_Книжки, Название, Номер_Группы))", cn);
                    //com.ExecuteNonQuery();

                    //Создание Таблицы Пар
                    ///доработка связей///com = new OleDbCommand("CREATE TABLE duets(Номер_Пары COUNTER, Номер_Захода INT, CONSTRAINT duets_uq UNIQUE(Номер_Пары, Номер_Захода), CONSTRAINT duets_pk PRIMARY KEY (Номер_Пары), CONSTRAINT fk_duets FOREIGN KEY (Номер_Захода) REFERENCES sets(Номер_Захода))", cn);
                    //com = new OleDbCommand("CREATE TABLE duets(Номер INT, Номер_Группы INT DEFAULT 0, Номер_Захода INT, Номер_Книжки1 INT, Номер_Книжки2 INT, Тип CHAR(4))", cn);
                    //com.ExecuteNonQuery();

                    TournirClass NewTournir = new TournirClass();

                    NewTournir.name = Name_textBox.Text;
                    NewTournir.date = new MyDate(DayOfTournir_comboBox.SelectedIndex + 1, MounthOfTournir_comboBox.SelectedIndex + 1, Convert.ToInt32(YearOfTournir_textBox.Text));
                    NewTournir.time = new TimeClass(HourTournirStart_comboBox.SelectedIndex, MinutesTournirStart_comboBox.SelectedIndex * 5);
                    //MessageBox.Show(NewTournir.time.ToString());
                    NewTournir.place = CityOfTournir_textBox.Text;
                    NewTournir.organisation = OrganisationOfTournir_textBox.Text;
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

                try
                {
                    com.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                cn.Close();
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.previousForm.Path_textBox.Text = folderName + ".mdb";
            }
            else
            {
                MessageBox.Show("Заполните все необходимые поля и повторите попытку!");
            }
        }

        private void CreatingTournirDBForm_Load(object sender, EventArgs e)
        {

        }
    }
}

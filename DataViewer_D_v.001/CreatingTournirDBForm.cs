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
            if (Name_textBox.Text != "" && Path_textBox.Text != "")
            {
                folderName = "";
                folderName = Path_textBox.Text;
                dbName = Name_textBox.Text;
                folderName += '\\';
                folderName += dbName;
                MessageBox.Show(folderName);
            }
            else
            {
                MessageBox.Show("Заполните все необходимые поля и повторите попытку!");
            }

            try
            {
                ADOX.Catalog BD = new ADOX.Catalog();
                BD.Create($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}.mdb;Jet OLEDB:Engine Type=5");

                OleDbConnection cn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}.mdb");
                cn.Open();
                OleDbCommand com = new OleDbCommand();

                //Создание Таблицы Категорий
                ///com = new OleDbCommand("CREATE TABLE categories(Категория CHAR(5), CONSTRAINT categories_pk PRIMARY KEY (Категория), CONSTRAINT fk_categories FOREIGN KEY (Категория) REFERENCES groups(Категория), CONSTRAINT fk_categories FOREIGN KEY (Категория) REFERENCES participants(Категория))", cn);
                com = new OleDbCommand("CREATE TABLE categories(Категория CHAR(5), CONSTRAINT categories_pk PRIMARY KEY (Категория))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Судей
                com = new OleDbCommand("CREATE TABLE judges(Номер COUNTER, ФИО CHAR(100), Категория CHAR(5), CONSTRAINT judges_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Участников
                com = new OleDbCommand("CREATE TABLE participants(Номер_Книжки INT, Фамилия CHAR(50), Имя CHAR(50), Отчество CHAR(50), Категория CHAR(5), CONSTRAINT participants_pk PRIMARY KEY (Номер_Книжки), CONSTRAINT fk_participants FOREIGN KEY (Категория) REFERENCES categories(Категория))", cn);
                /////com = new OleDbCommand("CREATE TABLE participants(Номер_Книжки INT, Фамилия CHAR(50), Имя CHAR(50), Отчество CHAR(50), Категория CHAR(5), CONSTRAINT participants_pk PRIMARY KEY (Номер_Книжки), CONSTRAINT fk_participants FOREIGN KEY(Номер_Книжки) REFERENCES duets(Участник1))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Пар
                com = new OleDbCommand("CREATE TABLE duets(Номер COUNTER, Участник1 INT, Участник2 INT, CONSTRAINT duets_pk PRIMARY KEY (Номер), CONSTRAINT fk_duets FOREIGN KEY (Участник1) REFERENCES participants(Номер_Книжки), CONSTRAINT fk_duets2 FOREIGN KEY (Участник2) REFERENCES participants(Номер_Книжки))", cn);
                ////com = new OleDbCommand("CREATE TABLE duets(Номер COUNTER, Участник1 INT, Участник2 INT, CONSTRAINT duets_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Заходов
                com = new OleDbCommand("CREATE TABLE sets(Номер COUNTER, Пара INT, Солист INT, CONSTRAINT sets_pk PRIMARY KEY (Номер), CONSTRAINT fk_sets FOREIGN KEY (Пара) REFERENCES duets(Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Групп
                com = new OleDbCommand("CREATE TABLE groups(Номер COUNTER, Заход INT, Категория CHAR(5), CONSTRAINT groups_pk PRIMARY KEY (Номер), CONSTRAINT fk_groups FOREIGN KEY (Заход) REFERENCES Sets(Номер), CONSTRAINT fk_groups1 FOREIGN KEY (Категория) REFERENCES categories(Категория))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Турнира
                com = new OleDbCommand("CREATE TABLE tournir(Название CHAR(50), Дата_Проведения CHAR(10),  Время_Проведения CHAR(10),  Место_Проведения CHAR(5), Организация CHAR(50), Группа INT, ФИО_Секретаря CHAR(100), ФИО_Регистратора CHAR(100), Судья INT, CONSTRAINT tournir_pk PRIMARY KEY (Название), CONSTRAINT fk_tournir FOREIGN KEY (Судья) REFERENCES judges(Номер), CONSTRAINT fk_tournir1 FOREIGN KEY (Группа) REFERENCES groups(Номер))", cn);
                com.ExecuteNonQuery();

                //Заполнение Категорий

                string[] categories = {"Д-0", "Д-1", "Д-2", "Ю-1", "Ю-2", "М", "М-2", "Вз"};
                foreach (string item in categories)
                {
                    MessageBox.Show(item);
                    com = new OleDbCommand("INSERT INTO categories(Категория)" + "VALUES (@category)", cn);
                    com.Parameters.AddWithValue("category",item);

                    try
                    {
                        com.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                cn.Close();
            }
            catch(Exception ex) 
            {
                  MessageBox.Show(ex.Message);
            }
        }

        private void CreatingTournirDBForm_Load(object sender, EventArgs e)
        {

        }
    }
}

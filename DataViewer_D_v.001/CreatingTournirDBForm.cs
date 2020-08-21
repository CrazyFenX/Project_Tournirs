﻿using System;
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
                HourOfTournir_comboBox.SelectedIndex != -1 && MinutesOfTournir_comboBox.SelectedIndex != -1 && CityOfTournir_textBox.Text != "" && OrganisationOfTournir_textBox.Text != "")
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
                    com = new OleDbCommand("CREATE TABLE tournir(ID COUNTER, Название CHAR(50), Дата_Проведения CHAR(10),  Время_Проведения CHAR(5),  Место_Проведения CHAR(50), Организация CHAR(50), ФИО_Секретаря CHAR(100), ФИО_Регистратора CHAR(100), CONSTRAINT tournir_pk PRIMARY KEY (Название))", cn);
                    com.ExecuteNonQuery();

                    //Создание Таблицы Групп
                    com = new OleDbCommand("CREATE TABLE groups(Номер_Группы COUNTER, Название_Турнира CHAR(50), Время CHAR(5), CONSTRAINT groups_pk PRIMARY KEY (Номер_Группы), CONSTRAINT fk_groups FOREIGN KEY (Название_Турнира) REFERENCES tournir(Название))", cn);
                    com.ExecuteNonQuery();

                    //Создание Таблицы Категорий
                    com = new OleDbCommand("CREATE TABLE categories(Номер_Группы INT, Категория CHAR(5), CONSTRAINT fk_categories FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                    com.ExecuteNonQuery();

                    //Создание Таблицы Судей
                    com = new OleDbCommand("CREATE TABLE judges(Номер COUNTER, Название_Турнира CHAR(50), ФИО CHAR(100), Категория_Судейства CHAR(20), CONSTRAINT judges_pk PRIMARY KEY (Номер), CONSTRAINT fk_judges FOREIGN KEY (Название_Турнира) REFERENCES tournir(Название))", cn);
                    com.ExecuteNonQuery();

                    //Создание Таблицы Участников
                    com = new OleDbCommand("CREATE TABLE participants(Номер_Книжки INT, Фамилия CHAR(50), Имя CHAR(50), Отчество CHAR(50), Категория CHAR(5), CONSTRAINT participants_pk PRIMARY KEY (Номер_Книжки))", cn);
                    com.ExecuteNonQuery();

                    //Создание Таблицы Заходов
                    com = new OleDbCommand("CREATE TABLE sets(Номер COUNTER, Номер_Группы INT, Категория CHAR(5), CONSTRAINT sets_pk PRIMARY KEY (Номер), CONSTRAINT fk_sets FOREIGN KEY (Номер_Группы) REFERENCES groups(Номер_Группы))", cn);
                    com.ExecuteNonQuery();

                    //Создание Таблицы Пар
                    com = new OleDbCommand("CREATE TABLE duets(Номер_Пары COUNTER, Номер_Захода INT, CONSTRAINT duets_pk PRIMARY KEY (Номер_Пары), CONSTRAINT fk_duets FOREIGN KEY (Номер_Захода) REFERENCES sets(Номер))", cn);
                    com.ExecuteNonQuery();

                    //Создание Связи Пар и Участников
                    com = new OleDbCommand("CREATE TABLE du_par_link(Номер_Книжки INT, Номер_Пары INT, CONSTRAINT fk_du_par_link FOREIGN KEY (Номер_Книжки) REFERENCES participants(Номер_Книжки), CONSTRAINT fk_du_par_link1 FOREIGN KEY (Номер_Пары) REFERENCES duets(Номер_Пары))", cn);
                    com.ExecuteNonQuery();

                    TournirClass NewTournir = new TournirClass();

                    NewTournir.name = Name_textBox.Text;
                    NewTournir.date = new MyDate(DayOfTournir_comboBox.SelectedIndex + 1, MounthOfTournir_comboBox.SelectedIndex + 1, Convert.ToInt32(YearOfTournir_textBox.Text));
                    NewTournir.time = new TimeClass(HourOfTournir_comboBox.SelectedIndex, MinutesOfTournir_comboBox.SelectedIndex * 5);
                    MessageBox.Show(NewTournir.time.ToString());
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
                catch(Exception ex) 
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

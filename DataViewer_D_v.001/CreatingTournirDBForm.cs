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

                //Создание Таблицы Турнира
                OleDbCommand com = new OleDbCommand("CREATE TABLE tournir(Название CHAR(50), Дата_Проведения CHAR(10),  Время_Проведения CHAR(10),  Место_Проведения CHAR(5), Организация CHAR(50), Группы INT, Заходы INT, ФИО_Секретаря CHAR(100), ФИО_Регистратора CHAR(100), CONSTRAINT tournir_pk PRIMARY KEY (Название))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Судей
                com = new OleDbCommand("CREATE TABLE judges(Номер COUNTER, ФИО CHAR(100), CONSTRAINT judges_pk PRIMARY KEY (Номер))", cn);
                com.ExecuteNonQuery();

                //Создание Таблицы Участников
                com = new OleDbCommand("CREATE TABLE participants(Номер_Книжки INT, Заход INT, Группа INT, CONSTRAINT participants_pk PRIMARY KEY (Номер_Книжки))", cn);
                com.ExecuteNonQuery();
                /*
                    CREATE TABLE suppliers
                    (   
                        supplier_id int NOT NULL,
                        supplier_name char(50) NOT NULL,
                        contact_name char(50),
                        CONSTRAINT suppliers_pk PRIMARY KEY (supplier_id)
                    );
                */
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

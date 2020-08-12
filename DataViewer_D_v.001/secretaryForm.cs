using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace DataViewer_D_v._001
{
    public partial class secretaryForm : Form
    {
        public Controller controller = new Controller();

        DataViewerSecretary dataViewerSecretary;

        secretaryMainForm secretaryMainForm;

        public string folderName;

        public secretaryForm(secretaryMainForm secretaryMainForm)
        {
            InitializeComponent();
            this.secretaryMainForm = secretaryMainForm;
        }

        public secretaryForm()
        {
            InitializeComponent();
        }
        private void CreateNewTournirButton_Click(object sender, EventArgs e)
        {
            CreatingTournirDBForm creatingTournirDBForm = new CreatingTournirDBForm(this);
            this.Enabled = false;
            creatingTournirDBForm.Show();
            /*try
            {
                ADOX.Catalog BD = new ADOX.Catalog();
                //BD.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\Exp\Abra.mdb;Jet OLEDB:Engine Type=5;Jet OLEDB:Database Password=password");
               
                BD.Create("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Abra.mdb;Jet OLEDB:Engine Type=5");

                OleDbConnection cn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Abra.mdb");
                cn.Open();
                OleDbCommand com = new OleDbCommand("CREATE TABLE Tables", cn);
            */
            //Добавить необходимые таблицы:

            //*Турнир +
            //**Название
            //**Дата проведения
            //**Время проведения
            //**Место проведения
            //**Организация
            //**Группы
            //**Заходы
            //**Секретарь (возможно объединение в одну таблицу)
            //**Регистратор (возможно объединение в одну таблицу)
            //**

            //*Секретарь -
            //**Фамилия
            //**Имя
            //**Отчество

            //*Регистратор -
            //**Фамилия
            //**Имя
            //**Отчество

            //*Судья +
            //**Номер
            //**Фамилия
            //**Имя
            //**Отчество

            //*Участник +
            //**Номер Книжки
            //**Фамилия
            //**Имя
            //**Отчество
            //**Заход
            //**Группа

            //*Группа +
            //**Категория 1
            //**Категория 2

            //*Заход +
            //**Участники (Пары/Солисты)

            //*Пара +
            //**Спортсмен 1
            //**Спортсмен 2

            //*Солист -

            //Добавить наполнение таблиц

            ///string str;
            ///string nazvanie = textBox1.Text;
            ///sqlConnection.Open();
            ///SqlCommand command = new SqlCommand();
            ///command.Connection = sqlConnection;
            ///str = "CREATE TABLE " + nazvanie + " (Id_file INT IDENTITY (1, 1) PRIMARY KEY, File_name NVARCHAR (50), Title NVARCHAR (50), File_data VARBINARY (MAX))";
            ///command.CommandText = str;
            ///command.ExecuteNonQuery();
            ///sqlConnection.Close();
            /*
                com.ExecuteNonQuery();
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.secretaryMainForm.Enabled = true;
            this.Hide();
        }

        private void secretaryForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.secretaryMainForm.Enabled = true;
            this.Hide();
        }

        private void secretaryForm_Load(object sender, EventArgs e)
        {

        }

        private void OpenBase_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text == "")
                this.dataViewerSecretary = new DataViewerSecretary(this);
            else
                this.dataViewerSecretary = new DataViewerSecretary(this,Path_textBox.Text);

            dataViewerSecretary.Show();
        }

        private void Delete_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (Path_textBox.Text == "")
                {
                    MessageBox.Show("Choose the DataBase before!");
                }
                else
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить выбранную базу данных?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        System.IO.File.Delete(Path_textBox.Text);
                    }
                }
                Path_textBox.Text = "";
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Упс, что-то пошло не так...\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = openFileDialog1.FileName;
                Path_textBox.Text = openFileDialog1.FileName;
            }
        }

        private void registr_button_Click(object sender, EventArgs e)
        {
            Judge judge = new Judge();
            judge.Surname = JudgeSurname_textBox.Text;
            judge.Name = JudgeName_textBox.Text;
            judge.Patronymic = JudgePatronymic_textBox.Text;

            if (Path_textBox.Text != "")
                SecretaryController.insertInJudges(judge, Path_textBox.Text);
            else
                MessageBox.Show("Необходимо выбрать базу Турнира!");
        }
    }
}

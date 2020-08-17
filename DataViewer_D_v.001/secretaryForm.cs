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
            CreateGroup_button.Visible = true;
            CreateSet_button.Visible = true;

            CreateGroupSecond_button.Visible = false;
            Categoriess_groupBox.Visible = false;
            label_NumberOfGroup.Visible = false;
            NumberOfGroup_textBox.Visible = false;
            BackSecond_button.Visible = false;
        }

        public secretaryForm()
        {
            InitializeComponent();
            CreateGroup_button.Visible = true;
            CreateSet_button.Visible = true;

            CreateGroupSecond_button.Visible = false;
            Categoriess_groupBox.Visible = false;
            label_NumberOfGroup.Visible = false;
            NumberOfGroup_textBox.Visible = false;
            BackSecond_button.Visible = false;
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
            judge.JudgeClass = JudgeClass_textBox.Text;

            if (Path_textBox.Text != "")
                SecretaryController.insertInJudges(judge, Path_textBox.Text);
            else
                MessageBox.Show("Необходимо выбрать базу Турнира!");
        }

        private void CreateGroup_button_Click(object sender, EventArgs e)
        {
            //CreatingGroup creatingGroup = new CreatingGroup(this);
            //this.Enabled = false;
            CreateGroup_button.Visible = false;
            CreateSet_button.Visible = false;

            CreateGroupSecond_button.Visible = true;
            Categoriess_groupBox.Visible = true;
            label_NumberOfGroup.Visible = true;
            NumberOfGroup_textBox.Visible = true;
            BackSecond_button.Visible = true;
        }

        private void BackSecond_button_Click(object sender, EventArgs e)
        {
            CreateGroup_button.Visible = true;
            CreateSet_button.Visible = true;

            CreateGroupSecond_button.Visible = false;
            Categoriess_groupBox.Visible = false;
            label_NumberOfGroup.Visible = false;
            NumberOfGroup_textBox.Visible = false;
            BackSecond_button.Visible = false;
        }

        private void CreateGroupSecond_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                try
                {
                    OleDbConnection cn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}.mdb");
                    cn.Open();
                    OleDbCommand com = new OleDbCommand();


                    string[] categories = { "Д-0", "Д-1", "Д-2", "Ю-1", "Ю-2", "М", "М-2", "Вз" };
                    foreach (string item in categories)
                    {
                        //MessageBox.Show(item);
                        com = new OleDbCommand("INSERT INTO categories(Категория)" + "VALUES (@category)", cn);
                        com.Parameters.AddWithValue("category", item);

                        try
                        {
                            com.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Возникло непредвиденное исключение:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    TournirClass NewTournir = new TournirClass();

                    //NewTournir.name = Name_textBox.Text;
                    //NewTournir.date = new MyDate(DayOfTournir_comboBox.SelectedIndex, MounthOfTournir_comboBox.SelectedIndex, YearOfTournir_comboBox.SelectedIndex);
                    // NewTournir.time = new TimeClass(HourOfTournir_comboBox.SelectedIndex, MinutesOfTournir_comboBox.SelectedIndex * 5);
                    // MessageBox.Show(NewTournir.time.ToString());
                    // NewTournir.place = CityOfTournir_textBox.Text;
                    // NewTournir.organisation = OrganisationOfTournir_textBox.Text;
                    // NewTournir.registrator = "SNP_registrator";
                    // NewTournir.secretary = "SNP_secretary";

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
            }
            else
                MessageBox.Show("Необходимо выбрать базу турнира!");
        }
    }
}

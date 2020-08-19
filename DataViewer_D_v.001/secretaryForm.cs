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

        public DataViewerSecretary dataViewerSecretary;

        public secretaryMainForm secretaryMainForm;

        TournirClass tournir = new TournirClass();

        public string folderName;

        public secretaryForm(secretaryMainForm secretaryMainForm)
        {
            InitializeComponent();
            this.secretaryMainForm = secretaryMainForm;
            CreateGroup_button.Visible = true;
            CreateSet_button.Visible = true;

            CreateGroupSecond_button.Visible = false;
            Categoriess_groupBox.Visible = false;
            creatingSet_groupBox.Visible = false;

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
                this.dataViewerSecretary = new DataViewerSecretary(this, Path_textBox.Text);

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
            catch (Exception ex)
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
            GroupClass group_new = new GroupClass();

            if (NumberOfGroup_textBox.Text != "")
            {
                group_new.number = Convert.ToInt32(NumberOfGroup_textBox.Text);


            CheckBox[] CategoriesList = new CheckBox[] {D0_checkBox, D1_checkBox, D2_checkBox, M_checkBox, M2_checkBox, U1_checkBox, U2_checkBox, Vz_checkBox};

                if (Path_textBox.Text != "")
                {
                    try
                    {
                        OleDbConnection cn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}");
                        cn.Open();
                        OleDbCommand com = new OleDbCommand();

                        com = new OleDbCommand("INSERT INTO groups(Название_Турнира, Номер_Группы)" + "VALUES (@tournir_name, @group_number)", cn);
                        com.Parameters.AddWithValue("tournir_name", tournir.name);
                        com.Parameters.AddWithValue("group_number", group_new.number);

                        try
                        {
                            com.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Возникло непредвиденная проблема при обращении к базе:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string testStr = "";

                        for (int i = 0; i < CategoriesList.Length; i++)
                        {
                            com = new OleDbCommand("INSERT INTO categories(Номер_Группы, Категория)" + "VALUES (@group_number, @category)", cn);
                            com.Parameters.AddWithValue("group_number", group_new.number);
                            if (CategoriesList[i].Checked == true)
                            {
                                switch (i)
                                {
                                    case 0:
                                        com.Parameters.AddWithValue("category", "Д-0");
                                        testStr += "Д-0 ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 1:
                                        com.Parameters.AddWithValue("category", "Д-1");
                                        testStr += "Д-1 ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 2:
                                        com.Parameters.AddWithValue("category", "Д-2");
                                        testStr += "Д-2 ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 3:
                                        com.Parameters.AddWithValue("category", "М");
                                        testStr += "М ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 4:
                                        com.Parameters.AddWithValue("category", "М-2");
                                        testStr += "М-2 ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 5:
                                        com.Parameters.AddWithValue("category", "Ю-1");
                                        testStr += "Ю-1 ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 6:
                                        com.Parameters.AddWithValue("category", "Ю-2");
                                        testStr += "Ю-2 ";
                                        com.ExecuteNonQuery();
                                        break;
                                    case 7:
                                        com.Parameters.AddWithValue("category", "Вз");
                                        testStr += "Вз";
                                        com.ExecuteNonQuery();
                                        break;
                                }
                            }
                        }
                        MessageBox.Show("Новая группа успешно создана!\nУказаны категории: " + testStr);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Упс...Что-то пошло не так\n" + ex.Message);
                    }
                }
                else
                    MessageBox.Show("Необходимо выбрать базу турнира!");
            }
            else
                MessageBox.Show("Поле номера группы не может быть пустым!");
        }

        private void Path_textBox_TextChanged(object sender, EventArgs e)
        {
            folderName = Path_textBox.Text;
            try
            {
                tournir = SecretaryController.TakeTournir(folderName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CreateSet_button_Click(object sender, EventArgs e)
        {
            creatingSet_groupBox.Visible = true;
        }

        private void backThird_button_Click(object sender, EventArgs e)
        {
            creatingSet_groupBox.Visible = false;
        }
    }
}

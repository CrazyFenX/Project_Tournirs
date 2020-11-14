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
using System.Diagnostics;

namespace DataViewer_D_v._001
{
    public partial class secretaryForm : Form
    {
        public Controller controller = new Controller();

        public DataViewerSecretary dataViewerSecretary;

        public secretaryMainForm secretaryMainForm;

        TournirClass tournir = new TournirClass();

        public string folderName;

        private List<Label> groupLabelList = new List<Label>();
        private List<CheckBox[]> judgeChessCheckList = new List<CheckBox[]>();
        //public CheckBox[] judgeChessCheckList = new CheckBox[0, 0];

        public secretaryForm(secretaryMainForm secretaryMainForm)
        {
            InitializeComponent();
            //tournir = new TournirClass();
            tournir = secretaryMainForm.tournir;
            this.secretaryMainForm = secretaryMainForm;

            judgeGroupBox.Visible = false;
            Categoriess_groupBox.Visible = false;
            CreateGroup_button.Visible = true;
            //CreateSet_button.Visible = true;

            CreateGroupSecond_button.Visible = false;
            Categoriess_groupBox.Visible = false;
            //creatingSet_groupBox.Visible = false;

            label_NumberOfGroup.Visible = false;
            NumberOfGroup_textBox.Visible = false;
            BackSecond_button.Visible = false;

            judgeChessPanel.Visible = false;
        }

        public secretaryForm()
        {
            InitializeComponent();
            tournir = new TournirClass();

            CreateGroup_button.Visible = true;
            //CreateSet_button.Visible = true;

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

            this.secretaryMainForm.tournir = this.tournir;
            if (this.Path_textBox.Text != "")
                this.secretaryMainForm.Path_textBox.Text = this.Path_textBox.Text;
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
                    MessageBox.Show("Сперва нужно выбрать базу данных!");
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
            {
                //Text = Convert.ToString((char)(65 + i)),
                SecretaryController.insertInJudges(judge, Path_textBox.Text);
                judge.Number = (ushort)(SecretaryController.TakeMax("judges", "Номер", Path_textBox.Text));
                judge.judgeChar = (char)(64 + judge.Number);
                tournir.judges.Add(judge);
            }
            else
                MessageBox.Show("Необходимо выбрать базу Турнира!");
        }

        private void CreateGroup_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                Categoriess_groupBox.Visible = true;

                CreateGroup_button.Visible = false;
                //CreateSet_button.Visible = false;

                CreateGroupSecond_button.Visible = true;
                Categoriess_groupBox.Visible = true;
                label_NumberOfGroup.Visible = true;
                NumberOfGroup_textBox.Visible = true;
                BackSecond_button.Visible = true;
            }
            else
            {
                MessageBox.Show("Необходимо выбоать базу турнира!");
            }
        }

        private void BackSecond_button_Click(object sender, EventArgs e)
        {
            CreateGroup_button.Visible = true;
            //CreateSet_button.Visible = true;

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
                CheckBox[] CategoriesList = new CheckBox[] { D0_checkBox, D1_checkBox, D2_checkBox, M_checkBox, M2_checkBox, U1_checkBox, U2_checkBox, Vz_checkBox, other_checkBox };
                CheckBox[] DancesList = new CheckBox[] { W_dance_checkBox, V_dance_checkBox, T_dance_checkBox, F_dance_checkBox, Q_dance_checkBox, S_dance_checkBox, Ch_dance_checkBox, R_dance_checkBox, P_dance_checkBox, J_dance_checkBox };

                string str = "";

                foreach (CheckBox item in DancesList)
                    if (item.Checked)
                    {
                        group_new.DancesList.Add(item.Text);
                        str += item.Text;
                        MessageBox.Show(str);
                    }

                foreach (CheckBox item in CategoriesList)
                    if (item.Checked)
                    {
                        group_new.CategoryList.Add(item.Text);
                        str += item.Text;
                        MessageBox.Show(str);
                    }

                group_new.tournir_name = tournir.name;
                group_new.name = categoryNameTextBox.Text;

                if (Path_textBox.Text != "")
                {
                    try
                    {
                        OleDbConnection cn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}");
                        cn.Open();
                        OleDbCommand com1 = new OleDbCommand();
                        OleDbCommand com2 = new OleDbCommand();

                        com1 = new OleDbCommand("INSERT INTO groups(Название_Турнира, Номер_Группы, Категория, Категории, Танцы)" + "VALUES (@tournir_name, @group_number, @category, @categories, @dances)", cn);

                        com1.Parameters.AddWithValue("tournir_name", group_new.tournir_name);
                        com1.Parameters.AddWithValue("group_number", group_new.number);
                        com1.Parameters.AddWithValue("category", group_new.name);
                        string testStr = "";
                        for (int i = 0; i < CategoriesList.Length; i++)
                        {
                            testStr = "";
                            if (CategoriesList[i].Checked == true)
                            {
                                switch (i)
                                {
                                    case 0:
                                        testStr += "Д-0;";
                                        group_new.CategoryList.Add("Д-0");
                                        break;
                                    case 1:
                                        testStr += "Д-1;";
                                        group_new.CategoryList.Add("Д-1");
                                        break;
                                    case 2:
                                        testStr += "Д-2;";
                                        group_new.CategoryList.Add("Д-2");
                                        break;
                                    case 3:
                                        testStr += "М;";
                                        group_new.CategoryList.Add("М");
                                        break;
                                    case 4:
                                        testStr += "М-2;";
                                        group_new.CategoryList.Add("М-2");
                                        break;
                                    case 5:
                                        testStr += "Ю-1;";
                                        group_new.CategoryList.Add("Ю-1");
                                        break;
                                    case 6:
                                        testStr += "Ю-2;";
                                        group_new.CategoryList.Add("Ю-2");
                                        break;
                                    case 7:
                                        testStr += "Вз;";
                                        group_new.CategoryList.Add("Вз");
                                        break;
                                    default:
                                        testStr += "Другая;";
                                        group_new.CategoryList.Add("Другая");
                                        break;
                                }
                            }
                        }
                        com1.Parameters.AddWithValue("categories", testStr);

                        string testStr1 = "";
                        for (int i = 0; i < DancesList.Length; i++)
                        {
                            if (DancesList[i].Checked == true)
                            {
                                switch (i)
                                {
                                    case 0:
                                        testStr1 += "W;";
                                        group_new.DancesList.Add("W");
                                        break;
                                    case 1:
                                        testStr1 += "V;";
                                        group_new.DancesList.Add("V");
                                        break;
                                    case 2:
                                        testStr1 += "T;";
                                        group_new.DancesList.Add("T");
                                        break;
                                    case 3:
                                        testStr1 += "F;";
                                        group_new.DancesList.Add("F");
                                        break;
                                    case 4:
                                        testStr1 += "Q;";
                                        group_new.DancesList.Add("Q");
                                        break;
                                    case 5:
                                        testStr1 += "S;";
                                        group_new.DancesList.Add("S");
                                        break;
                                    case 6:
                                        testStr1 += "Ch;";
                                        group_new.DancesList.Add("Ch");
                                        break;
                                    case 7:
                                        testStr1 += "R;";
                                        group_new.DancesList.Add("R");
                                        break;
                                    case 8:
                                        testStr1 += "P;";
                                        group_new.DancesList.Add("P");
                                        break;
                                    case 9:
                                        testStr1 += "J;";
                                        group_new.DancesList.Add("J");
                                        break;
                                }
                            }
                        }
                        com1.Parameters.AddWithValue("dances", testStr1);

                        try
                        {
                            com1.ExecuteNonQuery();
                            tournir.groups.Add(group_new);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Возникла непредвиденная проблема при обращении к базе:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        for (int i = 0; i < CategoriesList.Length; i++)
                        {
                            com2 = new OleDbCommand("INSERT INTO categories(Номер, Номер_Группы, Категория)" + "VALUES (@number, @group_number, @category)", cn);
                            com2.Parameters.AddWithValue("number", i + 1);
                            com2.Parameters.AddWithValue("group_number", group_new.number);

                            if (CategoriesList[i].Checked == true)
                            {
                                switch (i)
                                {
                                    case 0:
                                        com2.Parameters.AddWithValue("category", "Д-0");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 1:
                                        com2.Parameters.AddWithValue("category", "Д-1");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 2:
                                        com2.Parameters.AddWithValue("category", "Д-2");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 3:
                                        com2.Parameters.AddWithValue("category", "М");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 4:
                                        com2.Parameters.AddWithValue("category", "М-2");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 5:
                                        com2.Parameters.AddWithValue("category", "Ю-1");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 6:
                                        com2.Parameters.AddWithValue("category", "Ю-2");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 7:
                                        com2.Parameters.AddWithValue("category", "Вз");
                                        com2.ExecuteNonQuery();
                                        break;
                                    default:
                                        com2.Parameters.AddWithValue("category", "Другая");
                                        com2.ExecuteNonQuery();
                                        break;
                                }
                            }
                        }

                        for (int i = 0; i < DancesList.Length; i++)
                        {
                            com2 = new OleDbCommand("INSERT INTO dances(Номер_Группы, Танец)" + "VALUES (@group_number, @dance)", cn);
                            com2.Parameters.AddWithValue("group_number", group_new.number);

                            if (DancesList[i].Checked == true)
                            {
                                switch (i)
                                {
                                    case 0:
                                        com2.Parameters.AddWithValue("dance", "W");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 1:
                                        com2.Parameters.AddWithValue("dance", "V");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 2:
                                        com2.Parameters.AddWithValue("dance", "T");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 3:
                                        com2.Parameters.AddWithValue("dance", "F");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 4:
                                        com2.Parameters.AddWithValue("dance", "Q");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 5:
                                        com2.Parameters.AddWithValue("dance", "S");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 6:
                                        com2.Parameters.AddWithValue("dance", "Ch");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 7:
                                        com2.Parameters.AddWithValue("dance", "R");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 8:
                                        com2.Parameters.AddWithValue("dance", "P");
                                        com2.ExecuteNonQuery();
                                        break;
                                    case 9:
                                        com2.Parameters.AddWithValue("dance", "J");
                                        com2.ExecuteNonQuery();
                                        break;
                                }
                            }
                        }

                        NumberOfGroup_textBox.Text = Convert.ToString(tournir.groups.Count + 1);
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
                tournir.path = Path_textBox.Text;

                //for (int i = 0; i < tournir.groups.Count; i++)
                //    setGroupNumber_comboBox.Items.Add(tournir.groups[i].number);
                NumberOfGroup_textBox.Text = Convert.ToString(tournir.groups.Count + 1);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backThird_button_Click(object sender, EventArgs e)
        {
            //creatingSet_groupBox.Visible = false;
        }

        //private void setGroupNumber_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (Path_textBox.Text != "")
        //        {
        //            //setNumber_textBox.Text = Convert.ToString(tournir.groups[Convert.ToInt32(setGroupNumber_comboBox.Text) - 1].SetList.Count() + 1);

        //            //setCategory_comboBox.Items.Clear();
        //            //MessageBox.Show($"{tournir.groups[Convert.ToInt32(setGroupNumber_comboBox.Text) - 1].CategoryList.Count}");

        //            string retStr = "";

        //            //foreach (string category in tournir.groups[Convert.ToInt32(setGroupNumber_comboBox.Text) - 1].CategoryList)
        //            //{
        //            //    setCategory_comboBox.Items.Add(category);
        //            //    retStr += category;
        //            //}

        //            //MessageBox.Show(retStr);
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void configButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
                tournir.Show();
            else
                MessageBox.Show("Сперва необходимо выбрать базу турнира!");
        }

        private void showJudgeRegButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
                judgeGroupBox.Visible = true;
            else
                MessageBox.Show("Сперва необходимо выбрать базу турнира!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            judgeGroupBox.Visible = false;
        }

        private void secretaryForm_Resize(object sender, EventArgs e)
        {
            {
                if (this.Size.Width < 740)
                    this.Size = new Size(740, this.Size.Height);
                if (this.Size.Height < 490)
                    this.Size = new Size(this.Size.Width, 490);
            }
        }

        public void TourButtonsEvent(object sender, EventArgs e)
        {

        }

        private void judgeChessBbutton_Click(object sender, EventArgs e)
        {
            try
            {
                int N = tournir.judges.Count;
                int M = tournir.groups.Count;
                CheckBox[] tempJudgeChessCheckList = new CheckBox[tournir.judges.Count];

                CheckBox checkBoxOfJudge = new CheckBox();
                judgeChessPanel.Controls.Clear();

                judgeChessCheckList = new List<CheckBox[]>();

                judgeChessPanel.Visible = true;
                int height = 45;

                ToolTip t = new ToolTip();

                Label new_label = new Label();

                for (int i = 0; i < this.tournir.judges.Count; i++)
                {
                    judgeChessPanel.Controls.Add(new_label = new Label()
                    {
                        Text = tournir.judges[i].judgeChar.ToString(),
                        Location = new Point(105 + 60 * i, 15),
                        Size = new Size(30, 25),
                        Font = new Font("", 12)
                    });
                    t.SetToolTip(new_label, tournir.judges[i].ToNSP());
                }

                foreach (GroupClass groupItem in tournir.groups)
                {
                    tempJudgeChessCheckList = new CheckBox[tournir.judges.Count];
                    judgeChessPanel.Controls.Add(new_label = new Label()
                    {
                        Text = "Группа" + Convert.ToString(groupItem.number),
                        Location = new Point(10, height),
                        Size = new Size(90, 25),
                        Font = new Font("", 12)
                    });
                    t.SetToolTip(new_label, groupItem.name);

                    string retstr = "Группа " + groupItem.number.ToString() + "\n";

                    int j = 0;
                    for (int i = 0; i < this.tournir.judges.Count; i++)
                    {
                        judgeChessPanel.Controls.Add(checkBoxOfJudge = new CheckBox()
                        {
                            Location = new Point(105 + 60 * i, height),
                            Size = new Size(20, 20),
                            Font = new Font("", 12)
                        });

                        checkBoxOfJudge.BringToFront();
                        tempJudgeChessCheckList[i] = checkBoxOfJudge;
                        retstr += groupItem.number.ToString() + " " + i.ToString() +  " " + tempJudgeChessCheckList[i].ToString(); 
                        j++;
                    }
                    MessageBox.Show(retstr);
                    judgeChessCheckList.Add(tempJudgeChessCheckList);
                    height += 30;
                }

                judgeAllowButton.Visible = true;
                judgeChessPanel.Visible = true;
                judgeChessButton.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void judgeAllowButton_Click(object sender, EventArgs e)
        {
            try
            {
                OleDbConnection cn = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}");
                cn.Open();
                //string retstr = "";
                for (int i = 0; i < tournir.groups.Count; i++)
                {
                    OleDbCommand command = new OleDbCommand();
                    command = new OleDbCommand("", cn);
                    command.CommandText = "UPDATE groups SET Судьи = '' WHERE Номер_Группы = @id";
                    ////command.Parameters.AddWithValue("judge", "");
                    command.Parameters.AddWithValue("id", i + 1);
                    command.ExecuteNonQuery();
                    tournir.groups[i].JudgeList.Count();
                    ////retstr += "Группа " + tournir.groups[i].number.ToString();

                    for (int j = 0; j < tournir.judges.Count; j++)
                    {
                        if (judgeChessCheckList[i][j].Checked)
                        {
                            tournir.groups[i].JudgeList.Add(tournir.judges[j]);
                            
                            command = new OleDbCommand("", cn);
                            command.CommandText = "UPDATE groups SET Судьи = @judge WHERE Номер_Группы = @id";
                            command.Parameters.AddWithValue("judge", (j + 1) + ";");
                            command.Parameters.AddWithValue("id", i + 1);
                            command.ExecuteNonQuery();
                        }
                    }
                }
                judgeAllowButton.Visible = false;
                judgeChessPanel.Visible = false;
                judgeChessButton.Visible = true;
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void judgeListButton_Click(object sender, EventArgs e)
        {
            string retstr = "";
            foreach (Judge jItem in tournir.judges)
            {
                retstr += jItem.ToString() + "\n";
            }
            MessageBox.Show(retstr);
        }

        private void judgeInGroupButton_Click(object sender, EventArgs e)
        {
            string retstr = "";
            foreach (GroupClass gItem in tournir.groups)
            {
                retstr += "Группа " + gItem.number + "\n";
                foreach (Judge judgeItem in gItem.JudgeList)
                {
                    retstr += judgeItem.ToString() + "\n";
                }
            }
            MessageBox.Show(retstr);
        }
    }
}
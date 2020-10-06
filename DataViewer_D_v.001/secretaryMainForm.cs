using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public partial class secretaryMainForm : Form
    {
        startWindow startWindow = new startWindow();

        public string folderName;

        public string connectString;

        public TournirClass tournir = new TournirClass();

        public secretaryMainForm()
        {
            InitializeComponent();
        }

        private void secretaryMainForm_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            secretaryForm secretaryForm = new secretaryForm(this);

            this.Enabled = false;
            secretaryForm.Show();
            //Открытие коннекта
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            startWindow.Show();

            startWindow.registratorButton.Visible = true;
            startWindow.secretaryButton.Visible = true;
            startWindow.Exit_button.Visible = true;

            startWindow.backButton.Visible = false;
            startWindow.solistButton.Visible = false;
            startWindow.duetButton.Visible = false;
            startWindow.sekwayButton.Visible = false;
            startWindow.ansamblButton.Visible = false;
        }

        private void secretaryMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            startWindow.Show();

            startWindow.registratorButton.Visible = true;
            startWindow.secretaryButton.Visible = true;
            startWindow.Exit_button.Visible = true;

            startWindow.backButton.Visible = false;
            startWindow.solistButton.Visible = false;
            startWindow.duetButton.Visible = false;
            startWindow.sekwayButton.Visible = false;
            startWindow.ansamblButton.Visible = false;
        }

        private void reglament_button_Click(object sender, EventArgs e)
        {
            formationReglament formRegform = new formationReglament(this);
            this.Enabled = false;
            formRegform.Show();
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            this.tournir.Show();
        }

        private void formingSets_button_Click(object sender, EventArgs e)
        {
            if (this.tournir.name != "" && Path_textBox.Text != "")
            {
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}";
                OleDbConnection con = new OleDbConnection(connectString);
                con.Open();

                int countOfElements = 0;
                Random rnd = new Random();

                for (int i = 0; i < tournir.groups.Count; i++)
                {
                    OleDbCommand command = new OleDbCommand("SELECT COUNT(Номер_Книжки1) From duets WHERE Номер_Группы = @id", con);

                    command.Parameters.AddWithValue("id", i + 1);
                    countOfElements = Convert.ToInt32(command.ExecuteScalar().ToString());
                    MessageBox.Show(Convert.ToString(countOfElements));

                    List<SetClass> newSetList = new List<SetClass>();
                    List<int> newBookNumList = new List<int>();

                    string outStr = "";

                    OleDbCommand command1 = new OleDbCommand("SELECT Номер_Книжки1, Номер_Книжки2 From duets WHERE Номер_Группы = @id", con);

                    command1.Parameters.AddWithValue("id", i + 1);
                    OleDbDataReader reader = command1.ExecuteReader();
                    int j = 0;

                    while (reader.Read())
                    {
                        newBookNumList.Add(Convert.ToInt32(reader["Номер_Книжки1"]));
                        outStr += newBookNumList[j];
                        j++;

                        if (reader["Номер_Книжки2"].ToString() != "")
                        {
                            outStr += " ";
                            newBookNumList.Add(Convert.ToInt32(reader["Номер_Книжки2"]));
                            outStr += newBookNumList[j];
                            j++;
                        }
                        outStr += "\n";
                    }
                    MessageBox.Show(outStr);
                    //}
                    //tournir.groups[i].SetList = newSetList;\
                }
                con.Close();
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }

        private void Path_textBox_TextChanged(object sender, EventArgs e)
        {
            folderName = Path_textBox.Text;
            try
            {
                tournir = SecretaryController.TakeTournir(folderName);
                //for (int i = 0; i < tournir.groups.Count; i++)
                //    groupNumber_comboBox.Items.Add(tournir.groups[i].number);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = openFileDialog1.FileName;
                Path_textBox.Text = folderName;
            }
        }

        private void startToutnamentButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                HoldingTournament holdingToutnamentForm = new HoldingTournament(this);

                this.Enabled = false;
                holdingToutnamentForm.Show();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }
    }
}

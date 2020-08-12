using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataViewer_D_v._001
{
    public partial class DataViewerSecretary : Form
    {
        public string folderName;
        private secretaryForm secretaryForm = new secretaryForm();

        public DataViewerSecretary()
        {
            InitializeComponent();
        }

        public DataViewerSecretary(secretaryForm secretaryForm)
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = @"C:\Users\Кирилл\source\repos\DataViewer_D_v.001\DataViewer_D_v.001\bin\x86\Debug\Tournirs";

            this.secretaryForm = secretaryForm;
            this.secretaryForm.Enabled = false;
        }

        public DataViewerSecretary(secretaryForm secretaryForm, string path)
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = @"C:\Users\Кирилл\source\repos\DataViewer_D_v.001\DataViewer_D_v.001\bin\x86\Debug\Tournirs";

            this.secretaryForm = secretaryForm;
            this.Path_textBox.Text = path;
            this.secretaryForm.Enabled = false;
        }
        private void Path_textBox_TextChanged(object sender, EventArgs e)
        {
            this.secretaryForm.Path_textBox.Text = Path_textBox.Text;
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = openFileDialog1.FileName;
            }
            Path_textBox.Text = openFileDialog1.FileName;
        }

        private void DataViewerSecretary_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.secretaryForm.Enabled = true;
        }

        private void DataViewerSecretary_Load(object sender, EventArgs e)
        {

        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                try
                {
                    OleDbConnection aConn1 = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0; Data Source ={Path_textBox.Text}");
                    MessageBox.Show(Path_textBox.Text);
                    aConn1.Open();
                    OleDbDataAdapter dbAdapter1 = new OleDbDataAdapter("SELECT * FROM [tournir]", aConn1);
                    DataTable dataTable1 = new DataTable();
                    dbAdapter1.Fill(dataTable1);
                    dataGridView_Tournir.DataSource = dataTable1;
                    //aConn1.Close();

                    //OleDbConnection aConn2 = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0; Data Source ={Path_textBox.Text}");
                    //MessageBox.Show(Path_textBox.Text);
                    //aConn2.Open();
                    OleDbDataAdapter dbAdapter2 = new OleDbDataAdapter("SELECT * FROM [judges]", aConn1);
                    DataTable dataTable2 = new DataTable();
                    dbAdapter2.Fill(dataTable2);
                    dataGridView_Judge.DataSource = dataTable2;
                    //aConn2.Close();

                    //OleDbConnection aConn3 = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0; Data Source ={Path_textBox.Text}");
                    //MessageBox.Show(Path_textBox.Text);
                    //aConn3.Open();
                    OleDbDataAdapter dbAdapter3 = new OleDbDataAdapter("SELECT * FROM [participants]", aConn1);
                    DataTable dataTable3 = new DataTable();
                    dbAdapter3.Fill(dataTable3);
                    dataGridView_Participant.DataSource = dataTable3;
                   
                    aConn1.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Необходимо выбрать базу даных!");
        }

        private void showTournir_button_Click(object sender, EventArgs e)
        {
            dataGridView_Participant.Visible = false;
            dataGridView_Judge.Visible = false;
            dataGridView_Tournir.Visible = true;

            showTournir_button.BackColor = Color.Empty;
            showJudge_button.BackColor = Color.Gray;
            showParticipant_button.BackColor = Color.Gray;

           // this.sportsmansTableAdapter1.Fill(this.peopleDataSetLastLast.Sportsmans);
        }

        private void showJudge_button_Click(object sender, EventArgs e)
        {
            dataGridView_Participant.Visible = false;
            dataGridView_Judge.Visible = true;
            dataGridView_Tournir.Visible = false;

            showTournir_button.BackColor = Color.Gray;
            showJudge_button.BackColor = Color.Empty;
            showParticipant_button.BackColor = Color.Gray;
        }

        private void showParticipant_button_Click(object sender, EventArgs e)
        {
            dataGridView_Participant.Visible = true;
            dataGridView_Judge.Visible = false;
            dataGridView_Tournir.Visible = false;

            showTournir_button.BackColor = Color.Gray;
            showJudge_button.BackColor = Color.Gray;
            showParticipant_button.BackColor = Color.Empty;
        }
    }
}

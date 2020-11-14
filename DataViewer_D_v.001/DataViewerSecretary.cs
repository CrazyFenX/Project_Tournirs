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

        public OleDbDataAdapter dbAdapter;

        public DataTable dataTable;

        public OleDbConnection aConn1;

        private secretaryForm secretaryForm = new secretaryForm();

        public DataViewerSecretary()
        {
            InitializeComponent();

            showSets_button.Visible = false;
        }

        public DataViewerSecretary(secretaryForm secretaryForm)
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = @"C:\Users\Кирилл\source\repos\DataViewer_D_v.001\DataViewer_D_v.001\bin\x86\Debug\Tournirs";

            this.secretaryForm = secretaryForm;
            this.secretaryForm.Enabled = false;

            showSets_button.Visible = false;
        }

        public DataViewerSecretary(secretaryForm secretaryForm, string path)
        {
            InitializeComponent();

            openFileDialog1.InitialDirectory = @"C:\Users\Кирилл\source\repos\DataViewer_D_v.001\DataViewer_D_v.001\bin\x86\Debug\Tournirs";

            this.secretaryForm = secretaryForm;
            this.Path_textBox.Text = path;
            this.secretaryForm.Enabled = false;

            showSets_button.Visible = false;
        }

        private void Path_textBox_TextChanged(object sender, EventArgs e)
        {
            this.secretaryForm.Path_textBox.Text = Path_textBox.Text;
            try
            {
                aConn1 = new OleDbConnection($"Provider=Microsoft.Jet.OLEDB.4.0; Data Source ={Path_textBox.Text}");
                aConn1.Open();
                aConn1.Close();
                MessageBox.Show("База успешно открыта!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Упс...Кажется, при открытии базы произошла ошибка\n" + ex.Message);
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
                    //dbAdapter = new OleDbDataAdapter("SELECT * FROM [tournir]", aConn1);
                    //dataTable = new DataTable();
                    //dbAdapter.Fill(dataTable);
                    //mainDataGridView.DataSource = dataTable;

                    /*
                    OleDbDataAdapter dbAdapter2 = new OleDbDataAdapter("SELECT * FROM [judges]", aConn1);
                    DataTable dataTable2 = new DataTable();
                    dbAdapter2.Fill(dataTable2);
                    dataGridView_Judge.DataSource = dataTable2;

                    OleDbDataAdapter dbAdapter3 = new OleDbDataAdapter("SELECT * FROM [participants]", aConn1);
                    DataTable dataTable3 = new DataTable();
                    dbAdapter3.Fill(dataTable3);
                    dataGridView_Participant.DataSource = dataTable3;

                    OleDbDataAdapter dbAdapter4 = new OleDbDataAdapter("SELECT * FROM [participants]", aConn1);
                    DataTable dataTable4 = new DataTable();
                    dbAdapter3.Fill(dataTable3);
                    dataGridView_Participant.DataSource = dataTable3;
                    */

                    //aConn1.Close();
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
            if (Path_textBox.Text != "")
            {
                aConn1.Open();
                dbAdapter = new OleDbDataAdapter("SELECT * FROM [tournir]", aConn1);
                dataTable = new DataTable();
                dbAdapter.Fill(dataTable);
                mainDataGridView.DataSource = dataTable;

                showTournir_button.BackColor = Color.Empty;
                showJudge_button.BackColor = Color.Gray;
                showParticipant_button.BackColor = Color.Gray;
                showCategories_button.BackColor = Color.Gray;
                showGroup_button.BackColor = Color.Gray;
                showSets_button.BackColor = Color.Gray;
                aConn1.Close();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        private void showJudge_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                aConn1.Open();
                dbAdapter = new OleDbDataAdapter("SELECT * FROM [judges]", aConn1);
                dataTable = new DataTable();
                dbAdapter.Fill(dataTable);
                mainDataGridView.DataSource = dataTable;

                showTournir_button.BackColor = Color.Gray;
                showJudge_button.BackColor = Color.Empty;
                showParticipant_button.BackColor = Color.Gray;
                showCategories_button.BackColor = Color.Gray;
                showGroup_button.BackColor = Color.Gray;
                showSets_button.BackColor = Color.Gray;
                aConn1.Close();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        private void showParticipant_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                aConn1.Open();
                dbAdapter = new OleDbDataAdapter("SELECT * FROM [participants]", aConn1);
                dataTable = new DataTable();
                dbAdapter.Fill(dataTable);
                mainDataGridView.DataSource = dataTable;

                showTournir_button.BackColor = Color.Gray;
                showJudge_button.BackColor = Color.Gray;
                showParticipant_button.BackColor = Color.Empty;
                showCategories_button.BackColor = Color.Gray;
                showGroup_button.BackColor = Color.Gray;
                showSets_button.BackColor = Color.Gray;
                aConn1.Close();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        private void showGroup_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                aConn1.Open();
                dbAdapter = new OleDbDataAdapter("SELECT * FROM [groups]", aConn1);
                dataTable = new DataTable();
                dbAdapter.Fill(dataTable);
                mainDataGridView.DataSource = dataTable;

                showTournir_button.BackColor = Color.Gray;
                showJudge_button.BackColor = Color.Gray;
                showParticipant_button.BackColor = Color.Gray;
                showCategories_button.BackColor = Color.Gray;
                showGroup_button.BackColor = Color.Empty;
                showSets_button.BackColor = Color.Gray;
                aConn1.Close();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        private void showCategories_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                aConn1.Open();
                dbAdapter = new OleDbDataAdapter("SELECT * FROM [categories]", aConn1);
                dataTable = new DataTable();
                dbAdapter.Fill(dataTable);
                mainDataGridView.DataSource = dataTable;

                showTournir_button.BackColor = Color.Gray;
                showJudge_button.BackColor = Color.Gray;
                showParticipant_button.BackColor = Color.Gray;
                showCategories_button.BackColor = Color.Empty;
                showGroup_button.BackColor = Color.Gray;
                showSets_button.BackColor = Color.Gray;
                aConn1.Close();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        //private void showSets_button_Click(object sender, EventArgs e)
        //{
        //    if (Path_textBox.Text != "")
        //    {

        //            aConn1.Open();
        //        dbAdapter = new OleDbDataAdapter("SELECT * FROM [sets]", aConn1);
        //        dataTable = new DataTable();
        //        dbAdapter.Fill(dataTable);
        //        mainDataGridView.DataSource = dataTable;

        //        showTournir_button.BackColor = Color.Gray;
        //        showJudge_button.BackColor = Color.Gray;
        //        showParticipant_button.BackColor = Color.Gray;
        //        showCategories_button.BackColor = Color.Gray;
        //        showGroup_button.BackColor = Color.Gray;
        //        showSets_button.BackColor = Color.Empty;
        //        aConn1.Close();
        //    }
        //    else
        //        MessageBox.Show("Сперва нужно выбрать базу турнира!");
        //}
    }
}

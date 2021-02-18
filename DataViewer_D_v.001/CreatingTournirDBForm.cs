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
            if (Name_textBox.Text != "" && Path_textBox.Text != "" && DayOfTournir_comboBox.SelectedIndex != -1 && MounthOfTournir_comboBox.SelectedIndex != -1 &&
                HourTournirStart_comboBox.SelectedIndex != -1 && MinutesTournirStart_comboBox.SelectedIndex != -1 && CityOfTournir_textBox.Text != "" && OrganisationOfTournir_textBox.Text != "")
            {
                folderName = "";
                folderName = Path_textBox.Text;

                SecretaryController.createTournirFolderNDataBase(folderName, this);
           
            this.previousForm.Path_textBox.Text = folderName + '\\' + Name_textBox.Text + '\\' + Name_textBox.Text + ".mdb";
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

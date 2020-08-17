using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001
{
    public partial class CreatingGroup : Form
    {
        public secretaryForm SecretaryForm;
        public CreatingGroup()
        {
            InitializeComponent();
        }

        public CreatingGroup(secretaryForm secretaryForm)
        {
            InitializeComponent();
            this.SecretaryForm = secretaryForm;
        }

        private void Create_button_Click(object sender, EventArgs e)
        {
           /* if (Name_textBox.Text != "" && Path_textBox.Text != "")
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
            }*/

        }

        private void Back_button_Click(object sender, EventArgs e)
        {
            this.SecretaryForm.Enabled = true;
            this.Hide();
        }

        private void CreatingGroup_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.SecretaryForm.Enabled = true;
            this.Hide();
        }
    }
}

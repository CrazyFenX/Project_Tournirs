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
    public partial class startWindow : Form
    {
        public startWindow()
        {
            InitializeComponent();
            backButton.Visible = false;
            solistButton.Visible = false;
            duetButton.Visible = false;
            sekwayButton.Visible = false;
            ansamblButton.Visible = false;
        }

        private void startForm_Load(object sender, EventArgs e)
        {

        }

        private void registratorButton_Click(object sender, EventArgs e)
        {
            registratorButton.Visible = false;
            secretaryButton.Visible = false;
            Exit_button.Visible = false;

            backButton.Visible = true;
            solistButton.Visible = true;
            duetButton.Visible = true;
            sekwayButton.Visible = true;
            ansamblButton.Visible = true;
        }

        private void startWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            try
            {
                Controller.myConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            registratorButton.Visible = true;
            secretaryButton.Visible = true;
            Exit_button.Visible = true;

            backButton.Visible = false;
            solistButton.Visible = false;
            duetButton.Visible = false;
            sekwayButton.Visible = false;
            ansamblButton.Visible = false;
        }

        private void solistButton_Click(object sender, EventArgs e)
        {
            registrFormSolo regFsolo = new registrFormSolo();
            this.Hide();
            regFsolo.Show();
            Controller.myConnection.Open();//////////////
        }

        private void duetButton_Click(object sender, EventArgs e)
        {
            registrFormDuet regFduet = new registrFormDuet();
            this.Hide();
            regFduet.Show();
            Controller.myConnection.Open();//////////////
        }

        private void Exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

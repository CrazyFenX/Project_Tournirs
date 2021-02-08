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
    public partial class DataBasaViewer : Form
    {
        public DataBasaViewer()
        {
            InitializeComponent();
        }

        private void DataBasaViewer_Load(object sender, EventArgs e)
        {
            dataGridView_trainers.Visible = false;

            showSports_button.BackColor = Color.Empty;
            showTrainers_button.BackColor = Color.Gray;
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Вызвано непредиденное исключение!\n Сообщение: {ex.Message}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void showSports_button_Click(object sender, EventArgs e)
        {
            dataGridView_trainers.Visible = false;
            dataGridView_sportsmen.Visible = true;

            showSports_button.BackColor = Color.Empty;
            showTrainers_button.BackColor = Color.Gray;

        }

        private void showTrainers_button_Click(object sender, EventArgs e)
        {
            dataGridView_trainers.Visible = true;
            dataGridView_sportsmen.Visible = false;

            showSports_button.BackColor = Color.Gray;
            showTrainers_button.BackColor = Color.Empty;
        }

        private void dataGridView_sportsmen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

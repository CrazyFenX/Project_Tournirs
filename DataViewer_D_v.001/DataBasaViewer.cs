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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "peopleDataSet2.Trainers". При необходимости она может быть перемещена или удалена.
            this.trainersTableAdapter2.Fill(this.peopleDataSet2.Trainers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "peopleDataSet2.Sportsmans". При необходимости она может быть перемещена или удалена.
            this.sportsmansTableAdapter3.Fill(this.peopleDataSet2.Sportsmans);
            
            dataGridView_trainers.Visible = false;

            showSports_button.BackColor = Color.Empty;
            showTrainers_button.BackColor = Color.Gray;
        }

        private void Update_button_Click(object sender, EventArgs e)
        {
            try
            {
                this.trainersTableAdapter2.Update(this.peopleDataSet2.Trainers);
                // TODO: данная строка кода позволяет загрузить данные в таблицу "peopleDataSetLastLast.Sportsmans". При необходимости она может быть перемещена или удалена.
                this.sportsmansTableAdapter3.Update(this.peopleDataSet2.Sportsmans);
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

            this.sportsmansTableAdapter3.Fill(this.peopleDataSet2.Sportsmans);
        }

        private void showTrainers_button_Click(object sender, EventArgs e)
        {
            dataGridView_trainers.Visible = true;
            dataGridView_sportsmen.Visible = false;

            showSports_button.BackColor = Color.Gray;
            showTrainers_button.BackColor = Color.Empty;

            this.trainersTableAdapter2.Fill(this.peopleDataSet2.Trainers);
        }
    }
}

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
    public partial class formationReglament : Form
    {
        public secretaryMainForm previousForm;
        TournirClass tournir = null;

        public formationReglament()
        {
            InitializeComponent();
        }

        public formationReglament(secretaryMainForm secretaryPreviousForm)
        {
            InitializeComponent();
            this.previousForm = secretaryPreviousForm;
            this.tournir = this.previousForm.tournir;
        }

        private void formationReglament_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.previousForm.Enabled = true;
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.previousForm.Enabled = true;
            this.Hide();
        }

        private void formationReglament_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < this.tournir.groups.Count; i++)
            {
                formation_groupBox.Controls["panelOfElements"].Controls.Add(new GroupBox() { Name = "groupbox" + (i).ToString(), Location = new Point(5, 50 * (i)), Size = new Size(450, 50)});
                //this.Controls.Add(new GroupBox() { Name = "groupbox" + i.ToString(), Location = new Point(50, 50 * i), Size = new Size(200, 50), Text = i.ToString() });
                formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(new Label() { Name = "groupLabel" + (i).ToString(), Location = new Point(5, 15), Text = "Группа номер " + (i + 1).ToString() });
                formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(new ComboBox() { Name = "HourOfTournir_comboBox" + (i).ToString(), Location = new Point(330, 18), Size = new Size(40, 24) });
                formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(new ComboBox() { Name = "MinutesOfTournir_comboBox" + (i).ToString(), Location = new Point(384, 18), Size = new Size(60, 24) });
                formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(new Label() { Name = "doublePointLabel" + (i).ToString(), Location = new Point(370, 18), Text = ":", Size = new Size(14, 24) });
            }
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            this.tournir.Show();
        }

    }
}

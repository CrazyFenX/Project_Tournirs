using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataViewer_D_v._001.Forms
{
    public partial class registrFormAnsambl : Form
    {
        List<DancerControl> danceControlList = new List<DancerControl>(2);
        DancerControl tmpControl = new DancerControl();
        int height = 0;

        startWindow previousForm = new startWindow();

        string path;

        public registrFormAnsambl()
        {
            InitializeComponent();
        }
        public registrFormAnsambl(string Path): this()
        {
            path = Path;
        }

        public registrFormAnsambl(string Path, startWindow stWin) : this(Path)
        {
            previousForm = stWin;
        }

        private void registrFormAnsambl_Load(object sender, EventArgs e)
        {
            danceControlList.Add(dancerControl1);
            danceControlList.Add(dancerControl2);
            dancerControl1.Text.Text += " 1";
            dancerControl2.Text.Text += " 2";
            height = 331;
            ParticipantsDataGridView.Visible = false;
        }

        private void addDancerButton_Click(object sender, EventArgs e)
        {
            panelOfDancers.Controls.Add(tmpControl = new DancerControl()
            {
                Name = "dancerControl" + (danceControlList.Count + 1).ToString(),
                Location = new Point(3, danceControlList[danceControlList.Count - 1].Location.Y + 187),
                Size = new Size(627, 181),
            });
            tmpControl.Text.Text = "Танцор " + (danceControlList.Count + 1).ToString();
            danceControlList.Add(tmpControl);

            string testStr = "";
            foreach (DancerControl item in danceControlList)
                testStr += item.Name + "\n";
            //MessageBox.Show(testStr);
        }

        private void registrFormAnsambl_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 1083)
                this.Size = new Size(1083, this.Size.Height);
            if (this.Size.Height < 637)
                this.Size = new Size(this.Size.Width, 637);
        }

        private void registrFormAnsambl_FormClosing(object sender, FormClosingEventArgs e)
        {
            hiding();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            hiding();
        }

        private void hiding()
        {
            this.Hide();
            previousForm.Show();
            previousForm.path = Path_textBox.Text;
            Controller.myConnection.Close();///////////

            previousForm.registratorButton.Visible = false;
            previousForm.secretaryButton.Visible = false;
            previousForm.Exit_button.Visible = false;

            previousForm.backButton.Visible = true;
            previousForm.solistButton.Visible = true;
            previousForm.duetButton.Visible = true;
            previousForm.sekwayButton.Visible = true;
            previousForm.ansamblButton.Visible = true;
        }

        private void openDataBasaButton_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (Path_textBox.Text != "")
                if (ParticipantsDataGridView.Visible)
                {
                    ParticipantsDataGridView.Visible = false;
                    btn.Text = "Открыть базу";
                }
                else
                {
                    ParticipantsDataGridView.Visible = true;
                    btn.Text = "Закрыть базу";
                    SecretaryController.FillParticipantsDataViewer(ParticipantsDataGridView, Path_textBox.Text);
                }
            else
                MessageBox.Show("Не подключена база турнира!");
        }
    }
}

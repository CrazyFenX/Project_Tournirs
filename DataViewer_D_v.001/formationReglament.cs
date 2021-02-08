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
    public partial class formationReglament : Form
    {
        public secretaryMainForm previousForm;
        TournirClass tournir = null;
        List<ComboBox> times_Comboboxes;
        ComboBox HourOfTournir_comboBox;
        ComboBox MinutesOfTournir_comboBox;
        List<ComboBox> groupComboBoxList = new List<ComboBox>();

        public static string connectString;

        public static OleDbConnection con;

        public static OleDbCommand command;

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
            Label groupLabel = new Label();
            HourOfTournir_comboBox = new ComboBox();
            MinutesOfTournir_comboBox = new ComboBox();
            Label doublePointLabel = new Label();

            ComboBox groupComboBox = new ComboBox();
            groupComboBoxList = new List<ComboBox>();

            List<ComboBox.ObjectCollection> comboCollection = new List<ComboBox.ObjectCollection>();

            times_Comboboxes = new List<ComboBox>();
            try
            {
                for (int i = 0; i < this.tournir.groups.Count; i++)
                {
                    panelOfElements.Controls.Add(groupComboBox = new ComboBox()
                    {
                        Name = "comboBox" + (i).ToString(),
                        Location = new Point(5, 50 * (i)),
                        Size = new Size(450, 50)
                    });
                    for (int j = 0; j < tournir.groups.Count; j++)
                        groupComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name);
                    groupComboBoxList.Add(groupComboBox);
                    //times_Comboboxes.Add(HourOfTournir_comboBox);
                    //times_Comboboxes.Add(MinutesOfTournir_comboBox);
                }
                //MessageBox.Show($"{times_Comboboxes.Count}");

                timeTournirLabel.Text = "Время начала турнира: " + tournir.time.ToString();

                //for (int i = 0; i < this.tournir.groups.Count; i++)
                //{
                //    formation_groupBox.Controls["panelOfElements"].Controls.Add(new GroupBox() { Name = "groupbox" + (i).ToString(), Location = new Point(5, 50 * (i)), Size = new Size(450, 50) });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(groupLabel = new Label() { Name = "groupLabel" + (i).ToString(), Location = new Point(5, 15), Text = "Группа номер " + (i + 1).ToString() });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(HourOfTournir_comboBox = new ComboBox() { Name = "HourOfTournir_comboBox" + (i).ToString(), Location = new Point(330, 18), Size = new Size(40, 24), Text = "Часы" ,Items = { "00", "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23" } });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(MinutesOfTournir_comboBox = new ComboBox() { Name = "MinutesOfTournir_comboBox" + (i).ToString(), Location = new Point(384, 18), Size = new Size(60, 24), Text = "Минуты", Items = { "00", "05", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55" } });
                //    formation_groupBox.Controls["panelOfElements"].Controls["groupbox" + (i).ToString()].Controls.Add(doublePointLabel = new Label() { Name = "doublePointLabel" + (i).ToString(), Location = new Point(370, 18), Text = ":", Size = new Size(14, 24) });

                //    times_Comboboxes.Add(HourOfTournir_comboBox);
                //    times_Comboboxes.Add(MinutesOfTournir_comboBox);

                //}
                //MessageBox.Show($"{times_Comboboxes.Count}");

                //timeTournirLabel.Text = "Время начала турнира: " + tournir.time.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            this.tournir.info();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < groupComboBoxList.Count; i++)
            {
                if (groupComboBoxList[i].SelectedIndex == -1)
                {
                    MessageBox.Show("Не все поля заполнены!");
                    return;
                }
                for (int j = i + 1; j < groupComboBoxList.Count; j++)
                {
                    if (groupComboBoxList[i].SelectedIndex == groupComboBoxList[j].SelectedIndex)
                    {
                        MessageBox.Show("Недопустимо выбирать одну группу несколько раз!");
                        return;
                    }
                }
            }
            try
            {
                ushort[] positionsList = new ushort[tournir.groups.Count];
                string retstr = "";
                for (int i = 0; i < groupComboBoxList.Count; i++)
                {
                    positionsList[i] = (ushort)(groupComboBoxList[i].SelectedIndex + 1);
                    retstr += (groupComboBoxList[i].SelectedIndex + 1).ToString() + ";";
                }
                MessageBox.Show(retstr);
                tournir.groupsOrder = positionsList;
                SecretaryController.UpdateGroupsOrder(retstr, previousForm.Path_textBox.Text);
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            //con.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace DataViewer_D_v._001
{
    public partial class secretaryMainForm : Form
    {
        startWindow startWindow = new startWindow();

        public string folderName;

        public string connectString;

        public TournirClass tournir = new TournirClass();

        public secretaryMainForm()
        {
            InitializeComponent();
            stage1_button.Visible = false;
            stage2_button.Visible = false;

            gradingButton.Visible = true;
            massSportButton.Visible = false;
            sportSystemButton.Visible = false;
            backGradingButton.Visible = false;

            setCountTextBox.Visible = false;
            setCountLabel.Visible = false;

            //duetCountTextBox.Visible = false;
            //duetCountLabel.Visible = false;
            //startToutnamentButton.Visible = false;
            //formSetsButton.Visible = false;
            getSets_groupBox.Visible = false;

            printButton.Visible = false;
            resultsButton.Visible = false;

            label_printerName.Visible = false;
            printerName_TextBox.Visible = false;

            printDiplomsButton.Visible = true;
            printDiplButton.Visible = false;
            printTestButton.Visible = false;
        }

        private void secretaryMainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void tournirPreparingButton_Click(object sender, EventArgs e)
        {
            secretaryForm secretaryForm = new secretaryForm(this);

            this.Enabled = false;
            secretaryForm.Show();
            //Открытие коннекта
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            this.Hide();
            startWindow.Show();

            startWindow.registratorButton.Visible = true;
            startWindow.secretaryButton.Visible = true;
            startWindow.Exit_button.Visible = true;

            startWindow.backButton.Visible = false;
            startWindow.solistButton.Visible = false;
            startWindow.duetButton.Visible = false;
            startWindow.sekwayButton.Visible = false;
            startWindow.ansamblButton.Visible = false;

            massSportButton.Visible = false;
            sportSystemButton.Visible = false;
        }

        private void secretaryMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            startWindow.Show();

            startWindow.registratorButton.Visible = true;
            startWindow.secretaryButton.Visible = true;
            startWindow.Exit_button.Visible = true;

            startWindow.backButton.Visible = false;
            startWindow.solistButton.Visible = false;
            startWindow.duetButton.Visible = false;
            startWindow.sekwayButton.Visible = false;
            startWindow.ansamblButton.Visible = false;
        }

        private void reglament_button_Click(object sender, EventArgs e)
        {
            if (this.tournir.name != "" && Path_textBox.Text != "")
            {
                reglament_Button.Visible = false;
                stage1_button.Visible = true;
                stage2_button.Visible = true;

                //formationReglament formRegform = new formationReglament(this);
                //this.Enabled = false;
                //formRegform.Show();
            }
            else
            {
                MessageBox.Show("База данных не выбрана!");
            }
        }

        private void configButton_Click(object sender, EventArgs e)
        {
            this.tournir.info2();
        }

        private void formingSets_button_Click(object sender, EventArgs e)
        {
            //try
            //{
                if (Path_textBox.Text != "" && setCountTextBox.Text != "" && groupComboBox.SelectedIndex > -1)
                {
                    ushort setCount = (ushort)Convert.ToInt32(setCountTextBox.Text);
                    SecretaryController.splitGroupForSets(tournir.groups[groupComboBox.SelectedIndex], setCount);
                    pdf_controller.getBlankForJudgePDF(tournir, tournir.groups[groupComboBox.SelectedIndex]);
                    MessageBox.Show("Заходы успешно сформированы!");
                }
                else
                    MessageBox.Show("Не все поля заполнены!");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void randomSort(List<Duet> tempList)
        {
            Random rnd = new Random();
            for (int i = tempList.Count - 1; i > 0; i--)
            {
                int j = rnd.Next(i + 1);
                var t = tempList[i];
                tempList[i] = tempList[j];
                tempList[j] = t;
            }
        }

        private void Path_textBox_TextChanged(object sender, EventArgs e)
        {
            folderName = Path_textBox.Text;
            try
            {
                tournir = SecretaryController.TakeTournir(folderName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при работе с базой турнира!\n" + ex.Message);
            }
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Tournirs\"; // this is the path that you are checking.
            if (Directory.Exists(path))
            {
                openFileDialog1.InitialDirectory = path;
            }
            else
            {
                openFileDialog1.InitialDirectory = @"C:\";
            }
            DialogResult result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                folderName = openFileDialog1.FileName;
                Path_textBox.Text = folderName;
            }
        }

        private void startToutnamentButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                this.Enabled = false;
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        private void stage1_button_Click(object sender, EventArgs e)
        {
            getSets_groupBox.Visible = true;
            setCountTextBox.Visible = true;
            setCountLabel.Visible = true;

            for (int j = 0; j < tournir.groups.Count; j++)
                groupComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name);
        }

        private void stage2_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0)
            {
                reglament_Button.Visible = true;
                stage1_button.Visible = false;
                stage2_button.Visible = false;

                formationReglament formRegform = new formationReglament(this);
                this.Enabled = false;
                formRegform.Show();
            }
            else
                MessageBox.Show("Не выбрана база турнира или не зарегистрировано ни одного судьи!");
        }

        private void gradingButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0)
            {
                //gradingButton.Visible = false;
                massSportButton.Visible = true;
                sportSystemButton.Visible = true;
                backGradingButton.Visible = true;
            }
            else
                MessageBox.Show("Не выбрана база турнира или не зарегистрировано ни одного судьи!");
        }

        private void backGradingButton_Click(object sender, EventArgs e)
        {
            gradingButton.Visible = true;
            massSportButton.Visible = false;
            sportSystemButton.Visible = false;
            backGradingButton.Visible = false;
        }

        private void massSportButton_Click(object sender, EventArgs e)
        {
            if (tournir.groupsOrder.Length > 0)
            {
                GradingForm holdingToutnamentForm = new GradingForm(this);

                this.Enabled = false;
                holdingToutnamentForm.Show();
            }
            else
                MessageBox.Show("Сперва сформируйте регламент");
        }

        private void resultsButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "")
            {
                foreach (GroupClass groupItem in tournir.groups)
                {
                    try
                    {
                        pdf_controller.getResultsPDF(tournir, groupItem);
                        printButton.Visible = true;
                        label_printerName.Visible = true;
                        printerName_TextBox.Visible = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
                MessageBox.Show("Выберите базу турнира");
        }

        private void printDiplomsButton_Click(object sender, EventArgs e)
        {
            printDiplomsButton.Visible = false;
            printDiplButton.Visible = true;
            printTestButton.Visible = true;
        }

        private void printButton_Click(object sender, EventArgs e)
        {
            if (printerName_TextBox.Text != "")
                foreach (GroupClass groupitem in this.tournir.groups)
                {
                    string folderName = tournir.path.Remove(tournir.path.LastIndexOf('\\'), tournir.path.Length - tournir.path.LastIndexOf('\\'));

                    string filePath = folderName + $@"\Results\{"Group " + groupitem.number.ToString() + " " + groupitem.tournir_name.Replace(" ", "")}.pdf";
                    printing_controller.PrintPDF(printerName_TextBox.Text, filePath, filePath);
                }
            else MessageBox.Show("Укажите название принтера!");
        }

        private void closePart1Button_Click(object sender, EventArgs e)
        {
            getSets_groupBox.Visible = false;
        }

        private void printTestButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string patternPath = Application.StartupPath + @"\Tournirs\"; // this is the path that you are checking.
                //if (Directory.Exists(patternPath))
                //{
                //    getDiplomPatternOpenFileDialog.InitialDirectory = patternPath;
                //}
                //else
                //{
                    getDiplomPatternOpenFileDialog.InitialDirectory = @"C:\";
                //}
                string patternPath = "";
                DialogResult result = getDiplomPatternOpenFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    patternPath = getDiplomPatternOpenFileDialog.FileName;
                    Word_Controller.OpenAndAddTextToWordDocument(patternPath, tournir);
                }

                //pdf_controller.getDiplomsPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDiplButton_Click(object sender, EventArgs e)
        {

        }
    }
}
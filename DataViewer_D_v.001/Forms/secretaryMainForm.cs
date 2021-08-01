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

        public int currentGroup = 0;
        List<Button> resultButtonFirstList = new List<Button>();
        List<Button> resultButtonSecondList = new List<Button>();
        List<Button> resultButtonFirstListPrint = new List<Button>();
        List<Button> resultButtonSecondListPrint = new List<Button>();

        ToolTip t = new ToolTip();

        public secretaryMainForm()
        {
            InitializeComponent();
            stage1_button.Visible = false;
            stage2_button.Visible = false;
            formationMassSportButton.Visible = false;
            formationSportSystemButton.Visible = false;

            gradingButton.Visible = true;
            massSportButton.Visible = false;
            sportSystemButton.Visible = false;
            backGradingButton.Visible = false;

            //setCountTextBox.Visible = false;
            //setCountLabel.Visible = false;

            //duetCountTextBox.Visible = false;
            //duetCountLabel.Visible = false;
            //startToutnamentButton.Visible = false;
            //formSetsButton.Visible = false;

            getSets_groupBox.Visible = false;

            printButton.Visible = false;
            //resultsButton.Visible = false;

            //label_printerName.Visible = false;
            //printerName_TextBox.Visible = false;

            printDiplomsButton.Visible = true;
            //printDiplButton.Visible = false;
            //printTestButton.Visible = false;
            resultsGroupBox.Visible = false;
            printDiplomsGroupBox.Visible = false;
        }

        public secretaryMainForm(String Path):this()
        {
            Path_textBox.Text = Path;
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
            if (this.Path_textBox.Text != "")
                startWindow.path = this.Path_textBox.Text;
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
                //stage1_button.Visible = true;
                //stage2_button.Visible = true;
                formationMassSportButton.Visible = true;
                formationSportSystemButton.Visible = true;
                backFormationButton.Visible = true;
                //formationReglament formRegform = new formationReglament(this, 0);
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
            try
            {
                if (Path_textBox.Text != "" && setCountTextBox.Text != "" && groupComboBox.SelectedIndex > -1)
                {
                    ushort setCount = (ushort)Convert.ToInt32(setCountTextBox.Text);
                    tournir.groups[groupComboBox.SelectedIndex].SetList.Clear();
                    SecretaryController.splitGroupForSets(tournir.groups[groupComboBox.SelectedIndex], setCount);

                    SecretaryController.clearSet(tournir.groups[groupComboBox.SelectedIndex], Path_textBox.Text);
                    for (int i = 0; i < tournir.groups[groupComboBox.SelectedIndex].SetList.Count; i++)
                        SecretaryController.insertSet(tournir.groups[groupComboBox.SelectedIndex].SetList[i], Path_textBox.Text);
                    
                    pdf_controller.getBlankForJudgePDF(tournir, tournir.groups[groupComboBox.SelectedIndex]);
                    MessageBox.Show("Заходы успешно сформированы!");
                    DialogResult res = MessageBox.Show("Распечатать бланки для судей?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string folderName = tournir.path.Remove(tournir.path.LastIndexOf('\\'), tournir.path.Length - tournir.path.LastIndexOf('\\'));
                        foreach (Judge judgeItem in tournir.judges)
                            foreach (string danceItem in tournir.groups[groupComboBox.SelectedIndex].DancesList)
                                printing_controller.PrintPDF(printerName_TextBox.Text, folderName + $@"\MarkBlanks\{"Group " + tournir.groups[groupComboBox.SelectedIndex].number.ToString() + " " + danceItem + " " + tournir.groups[groupComboBox.SelectedIndex].tournir_name.Replace(" ", "") + " " + judgeItem.Name + "_" + judgeItem.Surname[0] + "_" + judgeItem.Patronymic[0]}.pdf", folderName);
                    }
                }
                else
                    MessageBox.Show("Не все поля заполнены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            //setCountTextBox.Visible = true;
            //setCountLabel.Visible = true;
            groupComboBox.Items.Clear();
            for (int j = 0; j < tournir.groups.Count; j++)
                groupComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name + " " + tournir.groups[j].duetList.Count + " пар");
        }

        private void stage2_button_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0)
            {
                reglament_Button.Visible = true;
                stage1_button.Visible = false;
                stage2_button.Visible = false;
                backFormationButton.Visible = false;

                //formationReglament formRegform = new formationReglament(this, 0);
                formationReglament formRegform = new formationReglament(this);
                this.Enabled = false;
                formRegform.Show();
            }
            else
                MessageBox.Show("Не выбрана база турнира или не зарегистрировано ни одного судьи!");
        }

        private void gradingButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0 && tournir.Branches.Count > 0)
            {
                //gradingButton.Visible = false;
                massSportButton.Visible = true;
                sportSystemButton.Visible = true;
                backGradingButton.Visible = true;
            }
            else
                MessageBox.Show("Не выбрана база турнира, не сформирован регламент или не зарегистрировано ни одного судьи!");
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
            //if (tournir.groupsBranchOrder.Count > 0)
            if (tournir.groupsOrder.Count > 0)
            {
                GradingForm holdingToutnamentForm = new GradingForm(this, false);

                this.Enabled = false;
                holdingToutnamentForm.Show();
            }
            else
                MessageBox.Show("Сперва сформируйте регламент");
        }

        private void resultsButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0 && tournir.groupsOrder.Count > 0)
            {
                if (!resultsGroupBox.Visible)
                {
                    resultsGroupBox.Visible = true;
                    Button buttonGroupNewFirstReport;
                    Button buttonGroupNewSecondReport;
                    Button buttonGroupNewFirstReportPrint;
                    Button buttonGroupNewSecondReportPrint;
                    Label resultLabel;
                    resultButtonFirstList.Clear();
                    resultButtonSecondList.Clear();
                    resultButtonFirstList.Clear();
                    resultButtonSecondList.Clear();
                    Color backCol = Color.LightGray;

                    int heigh = 0;
                    //foreach (GroupClass item in this.tournir.groups)
                    try
                    {
                        resultsPanel.Controls.Clear();
                        //for (int i = 0; i < tournir.groupsBranchOrder.Count; i++)
                        //{
                        heigh += 15;
                        int cutter = 15;
                        backCol = Color.LightGray;
                        bool accessFlag = false;
                        for (int j = 0; j < tournir.groupsOrder.Count; j++)
                        {
                            if (tournir.groups[tournir.groupsOrder[j] - 1].markered)
                            {
                                backCol = Color.YellowGreen;
                                accessFlag = true;
                            }

                            if (tournir.groups[tournir.groupsOrder[j] - 1].name.Length <= 15) cutter = tournir.groups[tournir.groupsOrder[j] - 1].name.Length;
                            resultsPanel.Controls.Add(resultLabel = new Label()
                            {
                                Name = "resultLabel" + tournir.groups[tournir.groupsOrder[j] - 1].number.ToString(),
                                //Text = tournir.groups[tournir.groupsOrder[j] - 1].name.Substring(0, cutter) + "... (" + tournir.groups[tournir.groupsOrder[j] - 1].number.ToString() + ")",
                                Text = tournir.groups[tournir.groupsOrder[j] - 1].name,
                                Location = new Point(10, heigh + 5),
                                Size = new Size(80, 20)
                            });

                            resultsPanel.Controls.Add(buttonGroupNewFirstReport = new Button()
                            {
                                Name = "groupButton" + (tournir.groups[tournir.groupsOrder[j] - 1].number),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Location = new Point(200, heigh),
                                Size = new Size(90, 35),
                                Text = "Оценки",
                                //Image = ,
                                BackColor = backCol,
                                Enabled = accessFlag,
                                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                                System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                            });

                            resultsPanel.Controls.Add(buttonGroupNewFirstReportPrint = new Button()
                            {
                                Name = "groupButtonPrint" + (tournir.groups[tournir.groupsOrder[j] - 1].number),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Location = new Point(280, heigh),
                                Size = new Size(50, 35),
                                Text = " П",
                                BackColor = Color.LightGray,
                                Enabled = accessFlag,
                                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                               System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                            });

                            resultsPanel.Controls.Add(buttonGroupNewSecondReport = new Button()
                            {
                                Name = "groupButton" + (tournir.groups[tournir.groupsOrder[j] - 1].number),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Location = new Point(320, heigh),
                                Size = new Size(100, 35),
                                Text = "Инфо",
                                BackColor = backCol,
                                Enabled = accessFlag,
                                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                                System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                            });

                            resultsPanel.Controls.Add(buttonGroupNewSecondReportPrint = new Button()
                            {
                                Name = "groupButtonPrint" + (tournir.groups[tournir.groupsOrder[j] - 1].number),
                                TextAlign = ContentAlignment.MiddleLeft,
                                Location = new Point(415, heigh),
                                Size = new Size(50, 35),
                                Text = " П",
                                BackColor = Color.LightGray,
                                Enabled = accessFlag,
                                Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left |
                               System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Top)))
                            });

                            heigh += 40;
                            resultButtonFirstList.Add(buttonGroupNewFirstReport);
                            buttonGroupNewFirstReport.Click += ResultButtonsFirstEvent;
                            t.SetToolTip(buttonGroupNewFirstReport, tournir.groups[tournir.groupsOrder[j] - 1].name);

                            resultButtonSecondList.Add(buttonGroupNewSecondReport);
                            buttonGroupNewSecondReport.Click += ResultButtonsSecondEvent;
                            t.SetToolTip(buttonGroupNewSecondReport, tournir.groups[tournir.groupsOrder[j] - 1].name);

                            resultButtonFirstListPrint.Add(buttonGroupNewFirstReportPrint);
                            buttonGroupNewFirstReportPrint.Click += ResultButtonsFirstEventPrint;
                            t.SetToolTip(buttonGroupNewFirstReportPrint, "Печать " + tournir.groups[tournir.groupsOrder[j] - 1].name);

                            resultButtonSecondListPrint.Add(buttonGroupNewSecondReportPrint);
                            buttonGroupNewSecondReportPrint.Click += ResultButtonsSecondEventPrint;
                            t.SetToolTip(buttonGroupNewSecondReportPrint, "Печать " + tournir.groups[tournir.groupsOrder[j] - 1].name);
                        }
                        //}
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    resultsGroupBox.Visible = false;
            }
            else
                MessageBox.Show("Не выбрана база турнира, не сформирован регламент или не зарегистрировано ни одного судьи!");

        }

        public void ResultButtonsFirstEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tmpPath = folderName.Remove(folderName.LastIndexOf('\\'));
            tournir.groups[tournir.groupsOrder[resultButtonFirstList.IndexOf(btn)] - 1].sortDuetList = sortController.QuickSort(tournir.groups[tournir.groupsOrder[resultButtonFirstList.IndexOf(btn)] - 1].duetList.ToArray(), 0);
            pdf_controller.getResultsPDF(tournir, tournir.groups[tournir.groupsOrder[resultButtonFirstList.IndexOf(btn)] - 1]);
            System.Diagnostics.Process.Start(tmpPath + $@"\Results\{tournir.groups[tournir.groupsOrder[resultButtonFirstList.IndexOf(btn)] - 1].number + ") " + tournir.groups[tournir.groupsOrder[resultButtonFirstList.IndexOf(btn)] - 1].name}.pdf");
            MessageBox.Show("Выбрана группа " + resultButtonFirstList.IndexOf(btn));
        }
        public void ResultButtonsSecondEvent(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tmpPath = folderName.Remove(folderName.LastIndexOf('\\'));
            tournir.groups[tournir.groupsOrder[resultButtonSecondList.IndexOf(btn)] - 1].sortDuetList = sortController.QuickSort(tournir.groups[tournir.groupsOrder[resultButtonSecondList.IndexOf(btn)] - 1].duetList.ToArray(), 0);
            pdf_controller.getInfoReportPDF(tournir, tournir.groups[tournir.groupsOrder[resultButtonSecondList.IndexOf(btn)] - 1]);
            //MessageBox.Show(tmpPath + $@"\InfoReports\{tournir.groups[tournir.groupsOrder[resultButtonSecondList.IndexOf(btn)] - 1].name}.pdf");
            System.Diagnostics.Process.Start(tmpPath + $@"\InfoReports\{tournir.groups[tournir.groupsOrder[resultButtonSecondList.IndexOf(btn)] - 1].number + ") " + tournir.groups[tournir.groupsOrder[resultButtonSecondList.IndexOf(btn)] - 1].name}.pdf");
        }

        public void ResultButtonsFirstEventPrint(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tmpPath = folderName.Remove(folderName.LastIndexOf('\\'));
            printing_controller.PrintPDF(printerName_TextBox.Text, tmpPath + $@"\Results\{tournir.groups[tournir.groupsOrder[resultButtonFirstListPrint.IndexOf(btn)] - 1].number + ") " + tournir.groups[tournir.groupsOrder[resultButtonFirstListPrint.IndexOf(btn)] - 1].name}.pdf", "");
        }
        public void ResultButtonsSecondEventPrint(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string tmpPath = folderName.Remove(folderName.LastIndexOf('\\'));
            printing_controller.PrintPDF(printerName_TextBox.Text, tmpPath + $@"\InfoReports\{tournir.groups[tournir.groupsOrder[resultButtonSecondListPrint.IndexOf(btn)] - 1].number + ") " + tournir.groups[tournir.groupsOrder[resultButtonSecondListPrint.IndexOf(btn)] - 1].name}.pdf", "");
        }
        private void printDiplomsButton_Click(object sender, EventArgs e)
        {
            try
            {
                choseGroupComboBox.Items.Clear();
                system_ComboBox.SelectedIndex = 0;
                printDiplomsGroupBox.Visible = true;
                string patternPath = "";
                patternPath = Path_textBox.Text.Remove(Path_textBox.Text.LastIndexOf('\\') + 1) + "Diploms\\pattern.docx";
                systemChanged(patternPath);
                for (int j = 0; j < tournir.groups.Count; j++)
                    choseGroupComboBox.Items.Add((j + 1).ToString() + ")  " + tournir.groups[j].name + " " + tournir.groups[j].duetList.Count + " пар");

                //pdf_controller.getDiplomsPDF();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void systemChanged(String patternPath)
        {
            if (System.IO.File.Exists(patternPath))
            {
                wordPatternTextBox.Text = patternPath;
            }
            else
            {
                getDiplomPatternOpenFileDialog.InitialDirectory = Path_textBox.Text.Remove(Path_textBox.Text.LastIndexOf('\\') + 1) + "Diploms\\";

                DialogResult result = getDiplomPatternOpenFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    patternPath = getDiplomPatternOpenFileDialog.FileName;
                    //Word_Controller.OpenAndAddTextToWordDocument(patternPath, tournir);
                    wordPatternTextBox.Text = patternPath;
                }
            }
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

        private void secretaryMainForm_Resize(object sender, EventArgs e)
        {
            if (this.Size.Width < 944)
                this.Size = new Size(944, this.Size.Height);
            if (this.Size.Height < 570)
                this.Size = new Size(this.Size.Width, 570);
        }

        private void closeResultButton_Click(object sender, EventArgs e)
        {
            resultsGroupBox.Visible = false;
        }

        private void ChoosePrinterButton_Click(object sender, EventArgs e)
        {
            try
            {
                printerName_TextBox.Text = printing_controller.GetDefaultPrinterName();
            }
            catch
            {
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void startPrintingDiplomsBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (choseGroupComboBox.SelectedIndex > -1 && wordPatternTextBox.Text != "")
                {
                    Word_Controller.OpenAndAddTextToWordDocument(wordPatternTextBox.Text, tournir, choseGroupComboBox.SelectedIndex, printerName_TextBox.Text, system_ComboBox.SelectedIndex);
                    MessageBox.Show("Дипломы успешно сформированы!");
                    DialogResult res = MessageBox.Show("Распечатать дипломы сейчас?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string folderName = tournir.path.Remove(tournir.path.LastIndexOf('\\'), tournir.path.Length - tournir.path.LastIndexOf('\\'));
                        foreach (Duet duetItem in tournir.groups[choseGroupComboBox.SelectedIndex].duetList)
                        {
                            //MessageBox.Show(folderName + $@"\Diploms\{(choseGroupComboBox.SelectedIndex + 1).ToString() + ") " + tournir.groups[choseGroupComboBox.SelectedIndex].name}\" + duetItem.number.ToString() + " " + duetItem.sportsman1.ToString() + ".docx");
                            printing_controller.PrintWord(printerName_TextBox.Text, folderName + $@"\Diploms\{(choseGroupComboBox.SelectedIndex + 1).ToString() + ") " + tournir.groups[choseGroupComboBox.SelectedIndex].name}\" + duetItem.number.ToString() + " " + duetItem.sportsman1.ToString() + ".docx");
                            if(duetItem.type == "Пара")
                                printing_controller.PrintWord(printerName_TextBox.Text, folderName + $@"\Diploms\{(choseGroupComboBox.SelectedIndex + 1).ToString() + ") " + tournir.groups[choseGroupComboBox.SelectedIndex].name}\" + duetItem.number.ToString() + " " + duetItem.sportsman2.ToString() + ".docx");
                        }
                    }
                }
                else
                    MessageBox.Show("Не все необходимые поля заполнены!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDiplomsCloseButton_Click(object sender, EventArgs e)
        {
            printDiplomsGroupBox.Visible = false;
        }

        private void sportSystemButton_Click(object sender, EventArgs e)
        {
            if (tournir.groupsOrder.Count > 0)
            {
                GradingForm holdingToutnamentForm = new GradingForm(this, true);

                this.Enabled = false;
                holdingToutnamentForm.Show();
            }
            else
                MessageBox.Show("Сперва сформируйте регламент");
        }

        private void tryPrintButton_Click(object sender, EventArgs e)
        {
            if (wordPatternTextBox.Text != "")
                Word_Controller.writeInTryPattern(wordPatternTextBox.Text, tournir);
            else
                MessageBox.Show("Не все необходимые поля заполнены!");
        }

        private void backFormationButton_Click(object sender, EventArgs e)
        {
            reglament_Button.Visible = true;
            formationMassSportButton.Visible = false;
            stage1_button.Visible = false;
            stage2_button.Visible = false;
            formationSportSystemButton.Visible = false;
            backFormationButton.Visible = false;
        }

        private void formationMassSportButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0)
            {
                reglament_Button.Visible = true;
                stage1_button.Visible = true;
                stage2_button.Visible = true;
                backFormationButton.Visible = true;
                formationMassSportButton.Visible = false;
                formationSportSystemButton.Visible = false;
                //formationReglament formRegform = new formationReglament(this, 0);
                //formationReglament formRegform = new formationReglament(this);
                //this.Enabled = false;
                //formRegform.Show();
            }
            else
                MessageBox.Show("Не выбрана база турнира или не зарегистрировано ни одного судьи!");
        }

        private void formationSportSystemButton_Click(object sender, EventArgs e)
        {
            if (Path_textBox.Text != "" && tournir.groups.Count != 0 && tournir.judges.Count != 0)
            {
                //reglament_Button.Visible = true;
                //stage1_button.Visible = false;
                //stage2_button.Visible = false;
                //backFormationButton.Visible = false;

                formationReglament formRegform = new formationReglament(this, 1);
                //formationReglament formRegform = new formationReglament(this);
                this.Enabled = false;
                formRegform.Show();
            }
            else
                MessageBox.Show("Не выбрана база турнира или не зарегистрировано ни одного судьи!");
        }

        private void utton_Click(object sender, EventArgs e)
        {
            try
            {
                pdf_controller.getReglamentReport(tournir);
                MessageBox.Show("Документ регламента успешно сформирован!\nНайти его можно в папке Reglament");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void getSets_groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void system_ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string patternPath = "";
            if (system_ComboBox.SelectedIndex == 0)
                patternPath = Path_textBox.Text.Remove(Path_textBox.Text.LastIndexOf('\\') + 1) + "Diploms\\pattern.docx";
            else
                patternPath = Path_textBox.Text.Remove(Path_textBox.Text.LastIndexOf('\\') + 1) + "Diploms\\patternScating.docx";

            systemChanged(patternPath);
        }
    }
}
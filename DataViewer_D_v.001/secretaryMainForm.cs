using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
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
            this.tournir.Show();
        }

        private void formingSets_button_Click(object sender, EventArgs e)
        {
            if (this.tournir.name != "" && Path_textBox.Text != "" && duetCountTextBox.Text != "")
            {
                //Constants
                //int setCountInGroup = Convert.ToInt32(setCountTextBox.Text);
                int duetCountInSet = Convert.ToInt32(duetCountTextBox.Text);

                //задать количество участников в каждом заходе
                connectString = $"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={folderName}";
                OleDbConnection con = new OleDbConnection(connectString);
                con.Open();

                List<Duet> DuetList_New = new List<Duet>();
                List<Duet> SoloList_New = new List<Duet>();
                //Sportsman sportsman1 = new Sportsman();
                //Sportsman sportsman2 = new Sportsman();

                int countOfElements = 0;
                Random rnd = new Random();

                Controller.myConnection.Open();

                for (int i = 0; i < tournir.groups.Count; i++)
                {
                    DuetList_New.Clear();
                    SoloList_New.Clear();
                    int index = 0;
                    OleDbCommand command = new OleDbCommand("SELECT COUNT(Номер_Книжки1) From duets WHERE Номер_Группы = @id", con);

                    command.Parameters.AddWithValue("id", i + 1);
                    countOfElements = Convert.ToInt32(command.ExecuteScalar().ToString());
                    //MessageBox.Show(Convert.ToString(countOfElements));

                    //List<Duet> newDuetList = new List<Duet>();
                    //List<int> newBookNumDuetList = new List<int>();
                    //List<int> newBookNumSoloList = new List<int>();

                    string outStr = "Пары группы номер" + (i + 1).ToString() + "\n";
                    string outStr1 = "Солисты группы номер" + (i + 1).ToString() + "\n";

                    OleDbCommand command1 = new OleDbCommand("SELECT Номер, Номер_Книжки1, Номер_Книжки2 From duets WHERE Номер_Группы = @id", con);

                    command1.Parameters.AddWithValue("id", i + 1);
                    OleDbDataReader reader = command1.ExecuteReader();
                    int j = 0;
                    int j1 = 0;

                    int Num1 = 0, Num2 = 0;

                    while (reader.Read())
                    {
                        if (reader["Номер_Книжки2"].ToString() != "")
                        {
                            Sportsman sportsman1 = new Sportsman();
                            Sportsman sportsman2 = new Sportsman();
                            outStr += " ";
                            Num1 = (Convert.ToInt32(reader["Номер_Книжки1"]));
                            Num2 = (Convert.ToInt32(reader["Номер_Книжки2"]));

                            sportsman1 = Controller.SearchByBookNumberShort(Num1);
                            sportsman1.BookNumber = Num1;
                            sportsman1.GroupNumber = i + 1;
                            sportsman2 = Controller.SearchByBookNumberShort(Num2);
                            sportsman2.BookNumber = Num2;
                            sportsman2.GroupNumber = i + 1;
                            DuetList_New.Add(new Duet(Convert.ToInt32(reader["Номер"]) - 1, i, sportsman1, sportsman2));
                            
                            outStr += DuetList_New[j1].ToString() + "\n";
                            j1++;
                        }
                        else
                        {
                            Sportsman sportsman1 = new Sportsman();
                            //newBookNumSoloList.Add(Convert.ToInt32(reader["Номер_Книжки1"]));
                            Num1 = (Convert.ToInt32(reader["Номер_Книжки1"]));

                            sportsman1 = Controller.SearchByBookNumberShort(Num1);
                            sportsman1.BookNumber = Num1;
                            sportsman1.GroupNumber = i + 1;
                            SoloList_New.Add(new Duet(Convert.ToInt32(reader["Номер"]) - 1, i, sportsman1));

                            outStr1 += SoloList_New[j].ToString() + "\n";
                            j++;
                        }
                        outStr += "\n";
                        outStr1 += "\n";
                    }
                    //MessageBox.Show(outStr);
                    outStr = "(Пара)Сортировка\n";
                    //DuetList_New.OrderBy(x => rnd.Next());
                    randomSort(DuetList_New);
                    foreach (Duet duetItem in DuetList_New)
                    {
                        outStr += duetItem.ToString();
                    }
                    //MessageBox.Show(outStr);

                    //MessageBox.Show(outStr1);
                    outStr1 = "(Соло)Сортировка\n";
                    //SoloList_New.OrderBy(x => rnd.Next());
                    randomSort(SoloList_New);
                    foreach (Duet soloItem in SoloList_New)
                    {
                        outStr1 += soloItem.ToString();
                    }
                    //MessageBox.Show(outStr1);

                    outStr = "";
                    tournir.groups[i].SetList.Clear();

                    //Заходы для пар
                    int setCountInGroup = DuetList_New.Count / duetCountInSet;
                    int remainder = DuetList_New.Count % duetCountInSet;
                    int h = 0;

                    outStr += "Группа " + (i + 1).ToString() + "\n";
                    for (h = 0; h < setCountInGroup; h++)
                    {
                        tournir.groups[i].SetList.Add(new SetClass(i, h + 1/*Добавить категорию*/));
                        outStr += "Заход " + (tournir.groups[i].SetList.Count).ToString() + "\n";
                        for (int h1 = 0; h1 < duetCountInSet; h1++)
                        {
                            if (index <= DuetList_New.Count - 1)
                            {
                                tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Add(DuetList_New[index]);
                                outStr += "Пара " + (tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Count).ToString() + "\n";
                                outStr += DuetList_New[index].ToString() + "\n";
                                index++;
                            }
                            else
                                break;
                        }
                    }

                    tournir.groups[i].SetList.Add(new SetClass(i, h + 1/*Добавить категорию*/));
                    outStr += "Заход " + (tournir.groups[i].SetList.Count).ToString() + "\n";
                    for (int h1 = 0; h1 < remainder; h1++)
                    {
                        if (index <= DuetList_New.Count - 1)
                        {
                            tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Add(DuetList_New[index]);
                            outStr += "Пара " + (tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Count).ToString() + "\n";
                            outStr += DuetList_New[index].ToString() + "\n";
                            index++;
                        }
                        else
                            break;
                    }

                    ////Заходы для солистов
                    //setCountInGroup = DuetList_New.Count / duetCountInSet;
                    //remainder = DuetList_New.Count % duetCountInSet;
                    //int g = h;
                    
                    //outStr += "Группа " + (i + 1).ToString() + "\n";
                    //for (h = 0; h < setCountInGroup; h++)
                    //{
                    //    tournir.groups[i].SetList.Add(new SetClass(i, g + h/*Добавить категорию*/));
                    //    outStr += "Заход " + (tournir.groups[i].SetList.Count).ToString() + "\n";
                    //    for (int h1 = 0; h1 < duetCountInSet; h1++)
                    //    {
                    //        if (index <= SoloList_New.Count - 1)
                    //        {
                    //            tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Add(SoloList_New[index]);
                    //            outStr += "Пара " + (tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Count).ToString() + "\n";
                    //            outStr += SoloList_New[index].ToString() + "\n";
                    //            index++;
                    //        }
                    //        else
                    //            break;
                    //    }
                    //}

                    //tournir.groups[i].SetList.Add(new SetClass(i, g + h + 1/*Добавить категорию*/));
                    //outStr += "Заход " + (tournir.groups[i].SetList.Count).ToString() + "\n";
                    //for (int h1 = 0; h1 < remainder; h1++)
                    //{
                    //    if (index <= DuetList_New.Count - 1)
                    //    {
                    //        tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Add(SoloList_New[index]);
                    //        outStr += "Пара " + (tournir.groups[i].SetList[tournir.groups[i].SetList.Count - 1].DuetList.Count).ToString() + "\n";
                    //        outStr += SoloList_New[index].ToString() + "\n";
                    //        index++;
                    //    }
                    //    else
                    //        break;
                    //}

                    MessageBox.Show(outStr);
                    //for (int i1 = 0; i1 < DuetList_New.Count; i1++)
                    //{
                    //    if(index % duetCountInSet)
                    //    tournir.groups[i].SetList[index];
                    //    if ()
                    //}
                }
                con.Close();
                Controller.myConnection.Close();
            }
            else
                MessageBox.Show("Не все поля заполнены!");
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
            //try
            //{
                tournir = SecretaryController.TakeTournir(folderName);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void Browse_button_Click(object sender, EventArgs e)
        {
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
                HoldingTournament holdingToutnamentForm = new HoldingTournament(this);

                this.Enabled = false;
                holdingToutnamentForm.Show();
            }
            else
                MessageBox.Show("Сперва нужно выбрать базу турнира!");
        }

        private void stage1_button_Click(object sender, EventArgs e)
        {
            //reglament_Button.Visible = false;
            //stage1_button.Visible = true;
            //stage2_button.Visible = true;

            //formationReglament formRegform = new formationReglament(this);
            //this.Enabled = false;
            //formRegform.Show();
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
            GradingForm holdingToutnamentForm = new GradingForm(this);

            this.Enabled = false;
            holdingToutnamentForm.Show();
        }
    }
}

namespace DataViewer_D_v._001
{
    partial class CreatingTournirDBForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Browse_button = new System.Windows.Forms.Button();
            this.Path_textBox = new System.Windows.Forms.TextBox();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.Label_name = new System.Windows.Forms.Label();
            this.Label_path = new System.Windows.Forms.Label();
            this.Create_button = new System.Windows.Forms.Button();
            this.Back_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.CityOfTournir_textBox = new System.Windows.Forms.TextBox();
            this.YearOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.MounthOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.DayOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.MinutesOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.HourOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OrganisationOfTournir_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Browse_button
            // 
            this.Browse_button.Location = new System.Drawing.Point(438, 17);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(92, 49);
            this.Browse_button.TabIndex = 0;
            this.Browse_button.Text = "Browse...";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // Path_textBox
            // 
            this.Path_textBox.Location = new System.Drawing.Point(68, 17);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(364, 22);
            this.Path_textBox.TabIndex = 1;
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(127, 54);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(281, 22);
            this.Name_textBox.TabIndex = 2;
            // 
            // Label_name
            // 
            this.Label_name.AutoSize = true;
            this.Label_name.Location = new System.Drawing.Point(23, 57);
            this.Label_name.Name = "Label_name";
            this.Label_name.Size = new System.Drawing.Size(72, 17);
            this.Label_name.TabIndex = 4;
            this.Label_name.Text = "Название";
            // 
            // Label_path
            // 
            this.Label_path.AutoSize = true;
            this.Label_path.Location = new System.Drawing.Point(23, 20);
            this.Label_path.Name = "Label_path";
            this.Label_path.Size = new System.Drawing.Size(39, 17);
            this.Label_path.TabIndex = 5;
            this.Label_path.Text = "Путь";
            // 
            // Create_button
            // 
            this.Create_button.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Create_button.Location = new System.Drawing.Point(438, 72);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(92, 49);
            this.Create_button.TabIndex = 6;
            this.Create_button.Text = "Createe!";
            this.Create_button.UseVisualStyleBackColor = false;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click);
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(438, 140);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(92, 49);
            this.Back_button.TabIndex = 7;
            this.Back_button.Text = "Back";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Дата проведения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Время проведения";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Город";
            // 
            // CityOfTournir_textBox
            // 
            this.CityOfTournir_textBox.Location = new System.Drawing.Point(77, 141);
            this.CityOfTournir_textBox.Name = "CityOfTournir_textBox";
            this.CityOfTournir_textBox.Size = new System.Drawing.Size(331, 22);
            this.CityOfTournir_textBox.TabIndex = 12;
            // 
            // YearOfTournir_comboBox
            // 
            this.YearOfTournir_comboBox.FormattingEnabled = true;
            this.YearOfTournir_comboBox.Items.AddRange(new object[] {
            "2020",
            "2019",
            "2018",
            "2017",
            "2016",
            "2015",
            "2014",
            "2013",
            "2012",
            "2011",
            "2010",
            "2009",
            "2008",
            "2007",
            "2006",
            "2005",
            "2004",
            "2003",
            "2002",
            "2001",
            "2000",
            "1999",
            "1998",
            "1997",
            "1996",
            "1995",
            "1994",
            "1993",
            "1992",
            "1991",
            "1990",
            "1989",
            "1988",
            "1987",
            "1986",
            "1985",
            "1984",
            "1983",
            "1982",
            "1981",
            "1980"});
            this.YearOfTournir_comboBox.Location = new System.Drawing.Point(331, 81);
            this.YearOfTournir_comboBox.Name = "YearOfTournir_comboBox";
            this.YearOfTournir_comboBox.Size = new System.Drawing.Size(77, 24);
            this.YearOfTournir_comboBox.TabIndex = 18;
            this.YearOfTournir_comboBox.Text = "год";
            // 
            // MounthOfTournir_comboBox
            // 
            this.MounthOfTournir_comboBox.FormattingEnabled = true;
            this.MounthOfTournir_comboBox.Items.AddRange(new object[] {
            "январь",
            "февраль",
            "март",
            "апрель",
            "май",
            "июнь",
            "июль",
            "август",
            "сентябрь",
            "октябрь",
            "ноябрь",
            "декабрь"});
            this.MounthOfTournir_comboBox.Location = new System.Drawing.Point(239, 81);
            this.MounthOfTournir_comboBox.Name = "MounthOfTournir_comboBox";
            this.MounthOfTournir_comboBox.Size = new System.Drawing.Size(86, 24);
            this.MounthOfTournir_comboBox.TabIndex = 17;
            this.MounthOfTournir_comboBox.Text = "месяц";
            // 
            // DayOfTournir_comboBox
            // 
            this.DayOfTournir_comboBox.FormattingEnabled = true;
            this.DayOfTournir_comboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.DayOfTournir_comboBox.Location = new System.Drawing.Point(168, 81);
            this.DayOfTournir_comboBox.Name = "DayOfTournir_comboBox";
            this.DayOfTournir_comboBox.Size = new System.Drawing.Size(65, 24);
            this.DayOfTournir_comboBox.TabIndex = 16;
            this.DayOfTournir_comboBox.Text = "день";
            // 
            // MinutesOfTournir_comboBox
            // 
            this.MinutesOfTournir_comboBox.FormattingEnabled = true;
            this.MinutesOfTournir_comboBox.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.MinutesOfTournir_comboBox.Location = new System.Drawing.Point(248, 111);
            this.MinutesOfTournir_comboBox.Name = "MinutesOfTournir_comboBox";
            this.MinutesOfTournir_comboBox.Size = new System.Drawing.Size(86, 24);
            this.MinutesOfTournir_comboBox.TabIndex = 20;
            this.MinutesOfTournir_comboBox.Text = "минуты";
            // 
            // HourOfTournir_comboBox
            // 
            this.HourOfTournir_comboBox.FormattingEnabled = true;
            this.HourOfTournir_comboBox.Items.AddRange(new object[] {
            "00",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HourOfTournir_comboBox.Location = new System.Drawing.Point(168, 111);
            this.HourOfTournir_comboBox.Name = "HourOfTournir_comboBox";
            this.HourOfTournir_comboBox.Size = new System.Drawing.Size(54, 24);
            this.HourOfTournir_comboBox.TabIndex = 19;
            this.HourOfTournir_comboBox.Text = "час";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(228, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(14, 20);
            this.label4.TabIndex = 21;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Организация";
            // 
            // OrganisationOfTournir_textBox
            // 
            this.OrganisationOfTournir_textBox.Location = new System.Drawing.Point(127, 169);
            this.OrganisationOfTournir_textBox.Name = "OrganisationOfTournir_textBox";
            this.OrganisationOfTournir_textBox.Size = new System.Drawing.Size(281, 22);
            this.OrganisationOfTournir_textBox.TabIndex = 22;
            // 
            // CreatingTournirDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 203);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OrganisationOfTournir_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MinutesOfTournir_comboBox);
            this.Controls.Add(this.HourOfTournir_comboBox);
            this.Controls.Add(this.YearOfTournir_comboBox);
            this.Controls.Add(this.MounthOfTournir_comboBox);
            this.Controls.Add(this.DayOfTournir_comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CityOfTournir_textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Back_button);
            this.Controls.Add(this.Create_button);
            this.Controls.Add(this.Label_path);
            this.Controls.Add(this.Label_name);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.Path_textBox);
            this.Controls.Add(this.Browse_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CreatingTournirDBForm";
            this.Text = "CreatingTournirDBForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreatingTournirDBForm_FormClosing);
            this.Load += new System.EventHandler(this.CreatingTournirDBForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.TextBox Path_textBox;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.Label Label_name;
        private System.Windows.Forms.Label Label_path;
        private System.Windows.Forms.Button Create_button;
        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox CityOfTournir_textBox;
        private System.Windows.Forms.ComboBox YearOfTournir_comboBox;
        private System.Windows.Forms.ComboBox MounthOfTournir_comboBox;
        private System.Windows.Forms.ComboBox DayOfTournir_comboBox;
        private System.Windows.Forms.ComboBox MinutesOfTournir_comboBox;
        private System.Windows.Forms.ComboBox HourOfTournir_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox OrganisationOfTournir_textBox;
    }
}
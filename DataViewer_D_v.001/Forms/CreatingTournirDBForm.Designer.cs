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
            this.MounthOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.DayOfTournir_comboBox = new System.Windows.Forms.ComboBox();
            this.MinutesTournirStart_comboBox = new System.Windows.Forms.ComboBox();
            this.HourTournirStart_comboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.OrganisationOfTournir_textBox = new System.Windows.Forms.TextBox();
            this.YearOfTournir_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Browse_button
            // 
            this.Browse_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Browse_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Browse_button.Location = new System.Drawing.Point(488, 10);
            this.Browse_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(79, 50);
            this.Browse_button.TabIndex = 9;
            this.Browse_button.Text = "Browse";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // Path_textBox
            // 
            this.Path_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Path_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Path_textBox.Location = new System.Drawing.Point(141, 10);
            this.Path_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(343, 26);
            this.Path_textBox.TabIndex = 0;
            // 
            // Name_textBox
            // 
            this.Name_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name_textBox.Location = new System.Drawing.Point(154, 44);
            this.Name_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(330, 26);
            this.Name_textBox.TabIndex = 1;
            this.Name_textBox.Text = "Турнир4";
            // 
            // Label_name
            // 
            this.Label_name.AutoSize = true;
            this.Label_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_name.Location = new System.Drawing.Point(11, 47);
            this.Label_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_name.Name = "Label_name";
            this.Label_name.Size = new System.Drawing.Size(83, 20);
            this.Label_name.TabIndex = 13;
            this.Label_name.Text = "Название";
            // 
            // Label_path
            // 
            this.Label_path.AutoSize = true;
            this.Label_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_path.Location = new System.Drawing.Point(11, 13);
            this.Label_path.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_path.Name = "Label_path";
            this.Label_path.Size = new System.Drawing.Size(120, 20);
            this.Label_path.TabIndex = 12;
            this.Label_path.Text = "Расположение";
            // 
            // Create_button
            // 
            this.Create_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Create_button.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Create_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Create_button.Location = new System.Drawing.Point(488, 66);
            this.Create_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(79, 50);
            this.Create_button.TabIndex = 10;
            this.Create_button.Text = "Create";
            this.Create_button.UseVisualStyleBackColor = false;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click);
            // 
            // Back_button
            // 
            this.Back_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Back_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Back_button.Location = new System.Drawing.Point(488, 264);
            this.Back_button.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(79, 38);
            this.Back_button.TabIndex = 11;
            this.Back_button.Text = "Back";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "Дата проведения";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(11, 128);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 20);
            this.label2.TabIndex = 15;
            this.label2.Text = "Время проведения";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(11, 174);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 20);
            this.label3.TabIndex = 16;
            this.label3.Text = "Место проведения";
            // 
            // CityOfTournir_textBox
            // 
            this.CityOfTournir_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CityOfTournir_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CityOfTournir_textBox.Location = new System.Drawing.Point(15, 196);
            this.CityOfTournir_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CityOfTournir_textBox.Multiline = true;
            this.CityOfTournir_textBox.Name = "CityOfTournir_textBox";
            this.CityOfTournir_textBox.Size = new System.Drawing.Size(469, 54);
            this.CityOfTournir_textBox.TabIndex = 2;
            this.CityOfTournir_textBox.Text = "Новосибирск";
            // 
            // MounthOfTournir_comboBox
            // 
            this.MounthOfTournir_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MounthOfTournir_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.MounthOfTournir_comboBox.Location = new System.Drawing.Point(246, 89);
            this.MounthOfTournir_comboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MounthOfTournir_comboBox.Name = "MounthOfTournir_comboBox";
            this.MounthOfTournir_comboBox.Size = new System.Drawing.Size(74, 28);
            this.MounthOfTournir_comboBox.TabIndex = 5;
            this.MounthOfTournir_comboBox.Text = "месяц";
            // 
            // DayOfTournir_comboBox
            // 
            this.DayOfTournir_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.DayOfTournir_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
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
            this.DayOfTournir_comboBox.Location = new System.Drawing.Point(170, 90);
            this.DayOfTournir_comboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.DayOfTournir_comboBox.Name = "DayOfTournir_comboBox";
            this.DayOfTournir_comboBox.Size = new System.Drawing.Size(59, 28);
            this.DayOfTournir_comboBox.TabIndex = 4;
            this.DayOfTournir_comboBox.Text = "день";
            // 
            // MinutesTournirStart_comboBox
            // 
            this.MinutesTournirStart_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.MinutesTournirStart_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinutesTournirStart_comboBox.FormattingEnabled = true;
            this.MinutesTournirStart_comboBox.Items.AddRange(new object[] {
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
            this.MinutesTournirStart_comboBox.Location = new System.Drawing.Point(261, 125);
            this.MinutesTournirStart_comboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinutesTournirStart_comboBox.Name = "MinutesTournirStart_comboBox";
            this.MinutesTournirStart_comboBox.Size = new System.Drawing.Size(80, 28);
            this.MinutesTournirStart_comboBox.TabIndex = 8;
            this.MinutesTournirStart_comboBox.Text = "минуты";
            // 
            // HourTournirStart_comboBox
            // 
            this.HourTournirStart_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.HourTournirStart_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.HourTournirStart_comboBox.FormattingEnabled = true;
            this.HourTournirStart_comboBox.Items.AddRange(new object[] {
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
            this.HourTournirStart_comboBox.Location = new System.Drawing.Point(188, 125);
            this.HourTournirStart_comboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.HourTournirStart_comboBox.Name = "HourTournirStart_comboBox";
            this.HourTournirStart_comboBox.Size = new System.Drawing.Size(54, 28);
            this.HourTournirStart_comboBox.TabIndex = 7;
            this.HourTournirStart_comboBox.Text = "час";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(245, 128);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 18);
            this.label4.TabIndex = 21;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(11, 274);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 20);
            this.label5.TabIndex = 17;
            this.label5.Text = "Организация";
            // 
            // OrganisationOfTournir_textBox
            // 
            this.OrganisationOfTournir_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OrganisationOfTournir_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OrganisationOfTournir_textBox.Location = new System.Drawing.Point(146, 271);
            this.OrganisationOfTournir_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OrganisationOfTournir_textBox.Name = "OrganisationOfTournir_textBox";
            this.OrganisationOfTournir_textBox.Size = new System.Drawing.Size(338, 26);
            this.OrganisationOfTournir_textBox.TabIndex = 3;
            this.OrganisationOfTournir_textBox.Text = "ООО СтройГаз";
            // 
            // YearOfTournir_textBox
            // 
            this.YearOfTournir_textBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.YearOfTournir_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearOfTournir_textBox.Location = new System.Drawing.Point(335, 90);
            this.YearOfTournir_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.YearOfTournir_textBox.Name = "YearOfTournir_textBox";
            this.YearOfTournir_textBox.Size = new System.Drawing.Size(75, 27);
            this.YearOfTournir_textBox.TabIndex = 6;
            this.YearOfTournir_textBox.Text = "2020";
            // 
            // CreatingTournirDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 312);
            this.Controls.Add(this.YearOfTournir_textBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OrganisationOfTournir_textBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.MinutesTournirStart_comboBox);
            this.Controls.Add(this.HourTournirStart_comboBox);
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
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "CreatingTournirDBForm";
            this.Text = "Создание базы нового турнира";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CreatingTournirDBForm_FormClosing);
            this.Load += new System.EventHandler(this.CreatingTournirDBForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.TextBox Path_textBox;
        public System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.Label Label_name;
        private System.Windows.Forms.Label Label_path;
        private System.Windows.Forms.Button Create_button;
        private System.Windows.Forms.Button Back_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox CityOfTournir_textBox;
        public System.Windows.Forms.ComboBox MounthOfTournir_comboBox;
        public System.Windows.Forms.ComboBox DayOfTournir_comboBox;
        public System.Windows.Forms.ComboBox MinutesTournirStart_comboBox;
        public System.Windows.Forms.ComboBox HourTournirStart_comboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox OrganisationOfTournir_textBox;
        public System.Windows.Forms.TextBox YearOfTournir_textBox;
    }
}
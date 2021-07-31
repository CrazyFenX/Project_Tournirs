
namespace DataViewer_D_v._001
{
    partial class DancerControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Label_Patronymic = new System.Windows.Forms.Label();
            this.Patronymic_textBox = new System.Windows.Forms.TextBox();
            this.Label_SportCategory = new System.Windows.Forms.Label();
            this.SportCategory_comboBox = new System.Windows.Forms.ComboBox();
            this.SportClass_comboBox = new System.Windows.Forms.ComboBox();
            this.Label_SportClass = new System.Windows.Forms.Label();
            this.YearOfBirth_comboBox = new System.Windows.Forms.ComboBox();
            this.MounthOfBirth_comboBox = new System.Windows.Forms.ComboBox();
            this.DayOfBirth_comboBox = new System.Windows.Forms.ComboBox();
            this.Label_BurthDate = new System.Windows.Forms.Label();
            this.Label_Surname = new System.Windows.Forms.Label();
            this.Label_Name = new System.Windows.Forms.Label();
            this.Surname_textBox = new System.Windows.Forms.TextBox();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Label_Patronymic
            // 
            this.Label_Patronymic.AutoSize = true;
            this.Label_Patronymic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Patronymic.Location = new System.Drawing.Point(8, 71);
            this.Label_Patronymic.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Patronymic.Name = "Label_Patronymic";
            this.Label_Patronymic.Size = new System.Drawing.Size(71, 17);
            this.Label_Patronymic.TabIndex = 78;
            this.Label_Patronymic.Text = "Отчество";
            // 
            // Patronymic_textBox
            // 
            this.Patronymic_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Patronymic_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Patronymic_textBox.Location = new System.Drawing.Point(104, 71);
            this.Patronymic_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Patronymic_textBox.Name = "Patronymic_textBox";
            this.Patronymic_textBox.Size = new System.Drawing.Size(276, 23);
            this.Patronymic_textBox.TabIndex = 67;
            this.Patronymic_textBox.Text = "Иванович";
            // 
            // Label_SportCategory
            // 
            this.Label_SportCategory.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label_SportCategory.AutoSize = true;
            this.Label_SportCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_SportCategory.Location = new System.Drawing.Point(11, 143);
            this.Label_SportCategory.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_SportCategory.Name = "Label_SportCategory";
            this.Label_SportCategory.Size = new System.Drawing.Size(56, 17);
            this.Label_SportCategory.TabIndex = 77;
            this.Label_SportCategory.Text = "Разряд";
            // 
            // SportCategory_comboBox
            // 
            this.SportCategory_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SportCategory_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SportCategory_comboBox.FormattingEnabled = true;
            this.SportCategory_comboBox.Items.AddRange(new object[] {
            "Ю-I",
            "Ю-II",
            "Ю-III",
            "Вз-I",
            "Вз-II",
            "Вз-III",
            "КМС",
            "МС",
            "МСМК",
            "-"});
            this.SportCategory_comboBox.Location = new System.Drawing.Point(72, 143);
            this.SportCategory_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.SportCategory_comboBox.Name = "SportCategory_comboBox";
            this.SportCategory_comboBox.Size = new System.Drawing.Size(61, 24);
            this.SportCategory_comboBox.TabIndex = 71;
            // 
            // SportClass_comboBox
            // 
            this.SportClass_comboBox.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.SportClass_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SportClass_comboBox.FormattingEnabled = true;
            this.SportClass_comboBox.Items.AddRange(new object[] {
            "Н",
            "Е",
            "Д",
            "С",
            "В",
            "А",
            "S",
            "М",
            "-"});
            this.SportClass_comboBox.Location = new System.Drawing.Point(212, 143);
            this.SportClass_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.SportClass_comboBox.Name = "SportClass_comboBox";
            this.SportClass_comboBox.Size = new System.Drawing.Size(57, 24);
            this.SportClass_comboBox.TabIndex = 72;
            // 
            // Label_SportClass
            // 
            this.Label_SportClass.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label_SportClass.AutoSize = true;
            this.Label_SportClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_SportClass.Location = new System.Drawing.Point(156, 146);
            this.Label_SportClass.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_SportClass.Name = "Label_SportClass";
            this.Label_SportClass.Size = new System.Drawing.Size(47, 17);
            this.Label_SportClass.TabIndex = 76;
            this.Label_SportClass.Text = "Класс";
            // 
            // YearOfBirth_comboBox
            // 
            this.YearOfBirth_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.YearOfBirth_comboBox.FormattingEnabled = true;
            this.YearOfBirth_comboBox.Items.AddRange(new object[] {
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
            this.YearOfBirth_comboBox.Location = new System.Drawing.Point(272, 107);
            this.YearOfBirth_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.YearOfBirth_comboBox.Name = "YearOfBirth_comboBox";
            this.YearOfBirth_comboBox.Size = new System.Drawing.Size(66, 24);
            this.YearOfBirth_comboBox.TabIndex = 70;
            this.YearOfBirth_comboBox.Text = "год";
            // 
            // MounthOfBirth_comboBox
            // 
            this.MounthOfBirth_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MounthOfBirth_comboBox.FormattingEnabled = true;
            this.MounthOfBirth_comboBox.Items.AddRange(new object[] {
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
            this.MounthOfBirth_comboBox.Location = new System.Drawing.Point(192, 107);
            this.MounthOfBirth_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.MounthOfBirth_comboBox.Name = "MounthOfBirth_comboBox";
            this.MounthOfBirth_comboBox.Size = new System.Drawing.Size(77, 24);
            this.MounthOfBirth_comboBox.TabIndex = 69;
            this.MounthOfBirth_comboBox.Text = "месяц";
            // 
            // DayOfBirth_comboBox
            // 
            this.DayOfBirth_comboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DayOfBirth_comboBox.FormattingEnabled = true;
            this.DayOfBirth_comboBox.Items.AddRange(new object[] {
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
            this.DayOfBirth_comboBox.Location = new System.Drawing.Point(127, 107);
            this.DayOfBirth_comboBox.Margin = new System.Windows.Forms.Padding(2);
            this.DayOfBirth_comboBox.Name = "DayOfBirth_comboBox";
            this.DayOfBirth_comboBox.Size = new System.Drawing.Size(62, 24);
            this.DayOfBirth_comboBox.TabIndex = 68;
            this.DayOfBirth_comboBox.Text = "день";
            // 
            // Label_BurthDate
            // 
            this.Label_BurthDate.AutoSize = true;
            this.Label_BurthDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_BurthDate.Location = new System.Drawing.Point(8, 107);
            this.Label_BurthDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_BurthDate.Name = "Label_BurthDate";
            this.Label_BurthDate.Size = new System.Drawing.Size(111, 17);
            this.Label_BurthDate.TabIndex = 75;
            this.Label_BurthDate.Text = "Дата рождения";
            // 
            // Label_Surname
            // 
            this.Label_Surname.AutoSize = true;
            this.Label_Surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Surname.Location = new System.Drawing.Point(8, 26);
            this.Label_Surname.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Surname.Name = "Label_Surname";
            this.Label_Surname.Size = new System.Drawing.Size(70, 17);
            this.Label_Surname.TabIndex = 73;
            this.Label_Surname.Text = "Фамилия";
            // 
            // Label_Name
            // 
            this.Label_Name.AutoSize = true;
            this.Label_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Name.Location = new System.Drawing.Point(8, 49);
            this.Label_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label_Name.Name = "Label_Name";
            this.Label_Name.Size = new System.Drawing.Size(35, 17);
            this.Label_Name.TabIndex = 74;
            this.Label_Name.Text = "Имя";
            // 
            // Surname_textBox
            // 
            this.Surname_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Surname_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Surname_textBox.Location = new System.Drawing.Point(104, 26);
            this.Surname_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Surname_textBox.Name = "Surname_textBox";
            this.Surname_textBox.Size = new System.Drawing.Size(276, 23);
            this.Surname_textBox.TabIndex = 65;
            this.Surname_textBox.Text = "Иванов";
            // 
            // Name_textBox
            // 
            this.Name_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Name_textBox.Location = new System.Drawing.Point(104, 49);
            this.Name_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(276, 23);
            this.Name_textBox.TabIndex = 66;
            this.Name_textBox.Text = "Иван";
            // 
            // Text
            // 
            this.Text.AutoSize = true;
            this.Text.Location = new System.Drawing.Point(8, 0);
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(44, 13);
            this.Text.TabIndex = 79;
            this.Text.Text = "Танцор";
            // 
            // DancerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Text);
            this.Controls.Add(this.Label_Patronymic);
            this.Controls.Add(this.Patronymic_textBox);
            this.Controls.Add(this.Label_SportCategory);
            this.Controls.Add(this.SportCategory_comboBox);
            this.Controls.Add(this.SportClass_comboBox);
            this.Controls.Add(this.Label_SportClass);
            this.Controls.Add(this.YearOfBirth_comboBox);
            this.Controls.Add(this.MounthOfBirth_comboBox);
            this.Controls.Add(this.DayOfBirth_comboBox);
            this.Controls.Add(this.Label_BurthDate);
            this.Controls.Add(this.Label_Surname);
            this.Controls.Add(this.Label_Name);
            this.Controls.Add(this.Surname_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Name = "DancerControl";
            this.Size = new System.Drawing.Size(418, 181);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_Patronymic;
        private System.Windows.Forms.Label Label_SportCategory;
        private System.Windows.Forms.Label Label_SportClass;
        private System.Windows.Forms.Label Label_BurthDate;
        private System.Windows.Forms.Label Label_Surname;
        private System.Windows.Forms.Label Label_Name;
        public System.Windows.Forms.TextBox Patronymic_textBox;
        public System.Windows.Forms.ComboBox SportCategory_comboBox;
        public System.Windows.Forms.ComboBox SportClass_comboBox;
        public System.Windows.Forms.ComboBox YearOfBirth_comboBox;
        public System.Windows.Forms.ComboBox MounthOfBirth_comboBox;
        public System.Windows.Forms.ComboBox DayOfBirth_comboBox;
        public System.Windows.Forms.TextBox Surname_textBox;
        public System.Windows.Forms.TextBox Name_textBox;
        public System.Windows.Forms.Label Text;
    }
}

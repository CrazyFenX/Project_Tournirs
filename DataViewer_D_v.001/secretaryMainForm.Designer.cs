namespace DataViewer_D_v._001
{
    partial class secretaryMainForm
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
            this.Browse_button = new System.Windows.Forms.Button();
            this.Path_textBox = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.printDiplButton = new System.Windows.Forms.Button();
            this.printTestButton = new System.Windows.Forms.Button();
            this.stage2_button = new System.Windows.Forms.Button();
            this.stage1_button = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.reglament_Button = new System.Windows.Forms.Button();
            this.printDiplomsButton = new System.Windows.Forms.Button();
            this.tournirPreparingButton = new System.Windows.Forms.Button();
            this.configButton = new System.Windows.Forms.Button();
            this.formSetsButton = new System.Windows.Forms.Button();
            this.startToutnamentButton = new System.Windows.Forms.Button();
            this.setCountTextBox = new System.Windows.Forms.TextBox();
            this.setCountLabel = new System.Windows.Forms.Label();
            this.gradingButton = new System.Windows.Forms.Button();
            this.massSportButton = new System.Windows.Forms.Button();
            this.sportSystemButton = new System.Windows.Forms.Button();
            this.backGradingButton = new System.Windows.Forms.Button();
            this.resultsButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_printerName = new System.Windows.Forms.Label();
            this.getSets_groupBox = new System.Windows.Forms.GroupBox();
            this.closePart1Button = new System.Windows.Forms.Button();
            this.groupComboBox = new System.Windows.Forms.ComboBox();
            this.printerName_TextBox = new System.Windows.Forms.TextBox();
            this.printButton = new System.Windows.Forms.Button();
            this.getDiplomPatternOpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.getSets_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Browse_button
            // 
            this.Browse_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Browse_button.BackColor = System.Drawing.Color.Tomato;
            this.Browse_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Browse_button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Browse_button.Location = new System.Drawing.Point(723, 461);
            this.Browse_button.Margin = new System.Windows.Forms.Padding(2);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(190, 26);
            this.Browse_button.TabIndex = 44;
            this.Browse_button.Text = "Browse";
            this.Browse_button.UseVisualStyleBackColor = false;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // Path_textBox
            // 
            this.Path_textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Path_textBox.AutoCompleteCustomSource.AddRange(new string[] {
            "$@\"\\Tournirs\\"});
            this.Path_textBox.Enabled = false;
            this.Path_textBox.Location = new System.Drawing.Point(23, 465);
            this.Path_textBox.Margin = new System.Windows.Forms.Padding(2);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(695, 20);
            this.Path_textBox.TabIndex = 43;
            this.Path_textBox.TextChanged += new System.EventHandler(this.Path_textBox_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.printDiplButton);
            this.groupBox4.Controls.Add(this.printTestButton);
            this.groupBox4.Controls.Add(this.stage2_button);
            this.groupBox4.Controls.Add(this.stage1_button);
            this.groupBox4.Controls.Add(this.backButton);
            this.groupBox4.Controls.Add(this.reglament_Button);
            this.groupBox4.Controls.Add(this.printDiplomsButton);
            this.groupBox4.Controls.Add(this.tournirPreparingButton);
            this.groupBox4.Location = new System.Drawing.Point(723, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(189, 437);
            this.groupBox4.TabIndex = 42;
            this.groupBox4.TabStop = false;
            // 
            // printDiplButton
            // 
            this.printDiplButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printDiplButton.BackColor = System.Drawing.Color.Tomato;
            this.printDiplButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printDiplButton.ForeColor = System.Drawing.Color.White;
            this.printDiplButton.Location = new System.Drawing.Point(6, 284);
            this.printDiplButton.Name = "printDiplButton";
            this.printDiplButton.Size = new System.Drawing.Size(176, 52);
            this.printDiplButton.TabIndex = 47;
            this.printDiplButton.Text = "Печать";
            this.printDiplButton.UseVisualStyleBackColor = false;
            this.printDiplButton.Click += new System.EventHandler(this.printDiplButton_Click);
            // 
            // printTestButton
            // 
            this.printTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printTestButton.BackColor = System.Drawing.Color.Tomato;
            this.printTestButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printTestButton.ForeColor = System.Drawing.Color.White;
            this.printTestButton.Location = new System.Drawing.Point(6, 332);
            this.printTestButton.Name = "printTestButton";
            this.printTestButton.Size = new System.Drawing.Size(176, 41);
            this.printTestButton.TabIndex = 46;
            this.printTestButton.Text = "Тест";
            this.printTestButton.UseVisualStyleBackColor = false;
            this.printTestButton.Click += new System.EventHandler(this.printTestButton_Click);
            // 
            // stage2_button
            // 
            this.stage2_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stage2_button.BackColor = System.Drawing.Color.Tomato;
            this.stage2_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stage2_button.ForeColor = System.Drawing.Color.White;
            this.stage2_button.Location = new System.Drawing.Point(98, 18);
            this.stage2_button.Name = "stage2_button";
            this.stage2_button.Size = new System.Drawing.Size(86, 89);
            this.stage2_button.TabIndex = 45;
            this.stage2_button.Text = "Этап 2";
            this.stage2_button.UseVisualStyleBackColor = false;
            this.stage2_button.Click += new System.EventHandler(this.stage2_button_Click);
            // 
            // stage1_button
            // 
            this.stage1_button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stage1_button.BackColor = System.Drawing.Color.Tomato;
            this.stage1_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.stage1_button.ForeColor = System.Drawing.Color.White;
            this.stage1_button.Location = new System.Drawing.Point(8, 18);
            this.stage1_button.Name = "stage1_button";
            this.stage1_button.Size = new System.Drawing.Size(92, 89);
            this.stage1_button.TabIndex = 44;
            this.stage1_button.Text = "Этап 1";
            this.stage1_button.UseVisualStyleBackColor = false;
            this.stage1_button.Click += new System.EventHandler(this.stage1_button_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.ForeColor = System.Drawing.Color.White;
            this.backButton.Location = new System.Drawing.Point(8, 378);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(174, 50);
            this.backButton.TabIndex = 43;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // reglament_Button
            // 
            this.reglament_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reglament_Button.BackColor = System.Drawing.Color.Tomato;
            this.reglament_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reglament_Button.ForeColor = System.Drawing.Color.White;
            this.reglament_Button.Location = new System.Drawing.Point(8, 17);
            this.reglament_Button.Name = "reglament_Button";
            this.reglament_Button.Size = new System.Drawing.Size(176, 89);
            this.reglament_Button.TabIndex = 0;
            this.reglament_Button.Text = "Формирование регламента";
            this.reglament_Button.UseVisualStyleBackColor = false;
            this.reglament_Button.Click += new System.EventHandler(this.reglament_button_Click);
            // 
            // printDiplomsButton
            // 
            this.printDiplomsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.printDiplomsButton.BackColor = System.Drawing.Color.Tomato;
            this.printDiplomsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printDiplomsButton.ForeColor = System.Drawing.Color.White;
            this.printDiplomsButton.Location = new System.Drawing.Point(8, 284);
            this.printDiplomsButton.Name = "printDiplomsButton";
            this.printDiplomsButton.Size = new System.Drawing.Size(176, 89);
            this.printDiplomsButton.TabIndex = 1;
            this.printDiplomsButton.Text = "Печать дипломов";
            this.printDiplomsButton.UseVisualStyleBackColor = false;
            this.printDiplomsButton.Click += new System.EventHandler(this.printDiplomsButton_Click);
            // 
            // tournirPreparingButton
            // 
            this.tournirPreparingButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tournirPreparingButton.BackColor = System.Drawing.Color.Tomato;
            this.tournirPreparingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tournirPreparingButton.ForeColor = System.Drawing.Color.White;
            this.tournirPreparingButton.Location = new System.Drawing.Point(10, 117);
            this.tournirPreparingButton.Name = "tournirPreparingButton";
            this.tournirPreparingButton.Size = new System.Drawing.Size(174, 89);
            this.tournirPreparingButton.TabIndex = 2;
            this.tournirPreparingButton.Text = "Подготовка к турниру";
            this.tournirPreparingButton.UseVisualStyleBackColor = false;
            this.tournirPreparingButton.Click += new System.EventHandler(this.tournirPreparingButton_Click);
            // 
            // configButton
            // 
            this.configButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.configButton.BackColor = System.Drawing.Color.Tomato;
            this.configButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configButton.ForeColor = System.Drawing.Color.White;
            this.configButton.Location = new System.Drawing.Point(541, 386);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(152, 50);
            this.configButton.TabIndex = 43;
            this.configButton.Text = "config";
            this.configButton.UseVisualStyleBackColor = false;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // formSetsButton
            // 
            this.formSetsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.formSetsButton.BackColor = System.Drawing.Color.Tomato;
            this.formSetsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formSetsButton.ForeColor = System.Drawing.Color.White;
            this.formSetsButton.Location = new System.Drawing.Point(216, 48);
            this.formSetsButton.Name = "formSetsButton";
            this.formSetsButton.Size = new System.Drawing.Size(175, 66);
            this.formSetsButton.TabIndex = 45;
            this.formSetsButton.Text = "Сформировать заходы";
            this.formSetsButton.UseVisualStyleBackColor = false;
            this.formSetsButton.Click += new System.EventHandler(this.formingSets_button_Click);
            // 
            // startToutnamentButton
            // 
            this.startToutnamentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startToutnamentButton.BackColor = System.Drawing.Color.Tomato;
            this.startToutnamentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startToutnamentButton.ForeColor = System.Drawing.Color.White;
            this.startToutnamentButton.Location = new System.Drawing.Point(4, 407);
            this.startToutnamentButton.Name = "startToutnamentButton";
            this.startToutnamentButton.Size = new System.Drawing.Size(30, 29);
            this.startToutnamentButton.TabIndex = 46;
            this.startToutnamentButton.Text = "Запуск турнира!";
            this.startToutnamentButton.UseVisualStyleBackColor = false;
            this.startToutnamentButton.Click += new System.EventHandler(this.startToutnamentButton_Click);
            // 
            // setCountTextBox
            // 
            this.setCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setCountTextBox.Location = new System.Drawing.Point(144, 48);
            this.setCountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.setCountTextBox.Name = "setCountTextBox";
            this.setCountTextBox.Size = new System.Drawing.Size(70, 29);
            this.setCountTextBox.TabIndex = 47;
            // 
            // setCountLabel
            // 
            this.setCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setCountLabel.AutoSize = true;
            this.setCountLabel.BackColor = System.Drawing.Color.White;
            this.setCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setCountLabel.Location = new System.Drawing.Point(19, 57);
            this.setCountLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.setCountLabel.Name = "setCountLabel";
            this.setCountLabel.Size = new System.Drawing.Size(121, 17);
            this.setCountLabel.TabIndex = 49;
            this.setCountLabel.Text = "Заходов в группе";
            // 
            // gradingButton
            // 
            this.gradingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gradingButton.BackColor = System.Drawing.Color.Tomato;
            this.gradingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.gradingButton.ForeColor = System.Drawing.Color.White;
            this.gradingButton.Location = new System.Drawing.Point(469, 37);
            this.gradingButton.Name = "gradingButton";
            this.gradingButton.Size = new System.Drawing.Size(218, 122);
            this.gradingButton.TabIndex = 51;
            this.gradingButton.Text = "Выставление оценок";
            this.gradingButton.UseVisualStyleBackColor = false;
            this.gradingButton.Click += new System.EventHandler(this.gradingButton_Click);
            // 
            // massSportButton
            // 
            this.massSportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.massSportButton.BackColor = System.Drawing.Color.Tomato;
            this.massSportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.massSportButton.ForeColor = System.Drawing.Color.White;
            this.massSportButton.Location = new System.Drawing.Point(469, 37);
            this.massSportButton.Name = "massSportButton";
            this.massSportButton.Size = new System.Drawing.Size(113, 92);
            this.massSportButton.TabIndex = 46;
            this.massSportButton.Text = "массовый спорт";
            this.massSportButton.UseVisualStyleBackColor = false;
            this.massSportButton.Click += new System.EventHandler(this.massSportButton_Click);
            // 
            // sportSystemButton
            // 
            this.sportSystemButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sportSystemButton.BackColor = System.Drawing.Color.Tomato;
            this.sportSystemButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sportSystemButton.ForeColor = System.Drawing.Color.White;
            this.sportSystemButton.Location = new System.Drawing.Point(572, 37);
            this.sportSystemButton.Name = "sportSystemButton";
            this.sportSystemButton.Size = new System.Drawing.Size(115, 92);
            this.sportSystemButton.TabIndex = 47;
            this.sportSystemButton.Text = "спортивная система";
            this.sportSystemButton.UseVisualStyleBackColor = false;
            // 
            // backGradingButton
            // 
            this.backGradingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.backGradingButton.BackColor = System.Drawing.Color.Tomato;
            this.backGradingButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backGradingButton.ForeColor = System.Drawing.Color.White;
            this.backGradingButton.Location = new System.Drawing.Point(469, 125);
            this.backGradingButton.Name = "backGradingButton";
            this.backGradingButton.Size = new System.Drawing.Size(218, 33);
            this.backGradingButton.TabIndex = 52;
            this.backGradingButton.Text = "назад";
            this.backGradingButton.UseVisualStyleBackColor = false;
            this.backGradingButton.Click += new System.EventHandler(this.backGradingButton_Click);
            // 
            // resultsButton
            // 
            this.resultsButton.BackColor = System.Drawing.Color.LimeGreen;
            this.resultsButton.Location = new System.Drawing.Point(13, 25);
            this.resultsButton.Name = "resultsButton";
            this.resultsButton.Size = new System.Drawing.Size(190, 28);
            this.resultsButton.TabIndex = 45;
            this.resultsButton.Text = "Результаты";
            this.resultsButton.UseVisualStyleBackColor = false;
            this.resultsButton.Click += new System.EventHandler(this.resultsButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.BackColor = System.Drawing.Color.Brown;
            this.groupBox3.Location = new System.Drawing.Point(585, 37);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(121, 109);
            this.groupBox3.TabIndex = 41;
            this.groupBox3.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label_printerName);
            this.panel1.Controls.Add(this.getSets_groupBox);
            this.panel1.Controls.Add(this.printerName_TextBox);
            this.panel1.Controls.Add(this.printButton);
            this.panel1.Controls.Add(this.sportSystemButton);
            this.panel1.Controls.Add(this.startToutnamentButton);
            this.panel1.Controls.Add(this.backGradingButton);
            this.panel1.Controls.Add(this.massSportButton);
            this.panel1.Controls.Add(this.gradingButton);
            this.panel1.Controls.Add(this.configButton);
            this.panel1.Controls.Add(this.resultsButton);
            this.panel1.Location = new System.Drawing.Point(19, 11);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(698, 445);
            this.panel1.TabIndex = 53;
            // 
            // label_printerName
            // 
            this.label_printerName.AutoSize = true;
            this.label_printerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_printerName.Location = new System.Drawing.Point(15, 70);
            this.label_printerName.Name = "label_printerName";
            this.label_printerName.Size = new System.Drawing.Size(188, 24);
            this.label_printerName.TabIndex = 55;
            this.label_printerName.Text = "Название принтера";
            // 
            // getSets_groupBox
            // 
            this.getSets_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.getSets_groupBox.Controls.Add(this.closePart1Button);
            this.getSets_groupBox.Controls.Add(this.groupComboBox);
            this.getSets_groupBox.Controls.Add(this.setCountTextBox);
            this.getSets_groupBox.Controls.Add(this.formSetsButton);
            this.getSets_groupBox.Controls.Add(this.setCountLabel);
            this.getSets_groupBox.Location = new System.Drawing.Point(286, 170);
            this.getSets_groupBox.Name = "getSets_groupBox";
            this.getSets_groupBox.Size = new System.Drawing.Size(397, 131);
            this.getSets_groupBox.TabIndex = 54;
            this.getSets_groupBox.TabStop = false;
            this.getSets_groupBox.Text = "Этап1";
            // 
            // closePart1Button
            // 
            this.closePart1Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closePart1Button.BackColor = System.Drawing.Color.Tomato;
            this.closePart1Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.closePart1Button.ForeColor = System.Drawing.Color.White;
            this.closePart1Button.Location = new System.Drawing.Point(361, 15);
            this.closePart1Button.Name = "closePart1Button";
            this.closePart1Button.Size = new System.Drawing.Size(30, 29);
            this.closePart1Button.TabIndex = 56;
            this.closePart1Button.Text = "X";
            this.closePart1Button.UseVisualStyleBackColor = false;
            this.closePart1Button.Click += new System.EventHandler(this.closePart1Button_Click);
            // 
            // groupComboBox
            // 
            this.groupComboBox.FormattingEnabled = true;
            this.groupComboBox.Location = new System.Drawing.Point(22, 93);
            this.groupComboBox.Name = "groupComboBox";
            this.groupComboBox.Size = new System.Drawing.Size(192, 21);
            this.groupComboBox.TabIndex = 50;
            // 
            // printerName_TextBox
            // 
            this.printerName_TextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printerName_TextBox.Location = new System.Drawing.Point(13, 97);
            this.printerName_TextBox.Name = "printerName_TextBox";
            this.printerName_TextBox.Size = new System.Drawing.Size(190, 23);
            this.printerName_TextBox.TabIndex = 54;
            this.printerName_TextBox.Text = "Epson Stylus Photo T50";
            // 
            // printButton
            // 
            this.printButton.BackColor = System.Drawing.Color.ForestGreen;
            this.printButton.Location = new System.Drawing.Point(13, 128);
            this.printButton.Name = "printButton";
            this.printButton.Size = new System.Drawing.Size(190, 28);
            this.printButton.TabIndex = 53;
            this.printButton.Text = "Печать";
            this.printButton.UseVisualStyleBackColor = false;
            this.printButton.Click += new System.EventHandler(this.printButton_Click);
            // 
            // getDiplomPatternOpenFileDialog
            // 
            this.getDiplomPatternOpenFileDialog.FileName = "openFileDialog2";
            // 
            // secretaryMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(928, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.Path_textBox);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "secretaryMainForm";
            this.Text = "secretaryMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.secretaryMainForm_FormClosing);
            this.Load += new System.EventHandler(this.secretaryMainForm_Load);
            this.groupBox4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.getSets_groupBox.ResumeLayout(false);
            this.getSets_groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Browse_button;
        public System.Windows.Forms.TextBox Path_textBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button reglament_Button;
        private System.Windows.Forms.Button printDiplomsButton;
        private System.Windows.Forms.Button tournirPreparingButton;
        private System.Windows.Forms.Button stage2_button;
        private System.Windows.Forms.Button stage1_button;
        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Button formSetsButton;
        private System.Windows.Forms.Button startToutnamentButton;
        private System.Windows.Forms.TextBox setCountTextBox;
        private System.Windows.Forms.Label setCountLabel;
        private System.Windows.Forms.Button gradingButton;
        private System.Windows.Forms.Button massSportButton;
        private System.Windows.Forms.Button sportSystemButton;
        private System.Windows.Forms.Button backGradingButton;
        public System.Windows.Forms.Button resultsButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button printButton;
        private System.Windows.Forms.GroupBox getSets_groupBox;
        private System.Windows.Forms.Label label_printerName;
        private System.Windows.Forms.TextBox printerName_TextBox;
        private System.Windows.Forms.ComboBox groupComboBox;
        private System.Windows.Forms.Button closePart1Button;
        private System.Windows.Forms.OpenFileDialog getDiplomPatternOpenFileDialog;
        private System.Windows.Forms.Button printDiplButton;
        private System.Windows.Forms.Button printTestButton;
    }
}
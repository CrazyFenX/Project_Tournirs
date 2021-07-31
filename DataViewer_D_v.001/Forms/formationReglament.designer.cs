namespace DataViewer_D_v._001
{
    partial class formationReglament
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
            this.panelOfElements = new System.Windows.Forms.Panel();
            this.tabControlOfElements = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.backButton = new System.Windows.Forms.Button();
            this.formation_groupBox = new System.Windows.Forms.GroupBox();
            this.formatingToursPanel = new System.Windows.Forms.Panel();
            this.configButton = new System.Windows.Forms.Button();
            this.timeTournirLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.controlTourGroupBox = new System.Windows.Forms.GroupBox();
            this.numOfDuetNextTourTextBox = new System.Windows.Forms.TextBox();
            this.startTourComboBox = new System.Windows.Forms.ComboBox();
            this.formSetsInTourButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.formatingToursButton = new System.Windows.Forms.Button();
            this.panelOfElements.SuspendLayout();
            this.tabControlOfElements.SuspendLayout();
            this.formation_groupBox.SuspendLayout();
            this.controlTourGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOfElements
            // 
            this.panelOfElements.AutoScroll = true;
            this.panelOfElements.Controls.Add(this.tabControlOfElements);
            this.panelOfElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOfElements.Location = new System.Drawing.Point(2, 15);
            this.panelOfElements.Margin = new System.Windows.Forms.Padding(2);
            this.panelOfElements.Name = "panelOfElements";
            this.panelOfElements.Size = new System.Drawing.Size(509, 363);
            this.panelOfElements.TabIndex = 12;
            // 
            // tabControlOfElements
            // 
            this.tabControlOfElements.Controls.Add(this.tabPage1);
            this.tabControlOfElements.Controls.Add(this.tabPage2);
            this.tabControlOfElements.Location = new System.Drawing.Point(-2, 0);
            this.tabControlOfElements.Name = "tabControlOfElements";
            this.tabControlOfElements.SelectedIndex = 0;
            this.tabControlOfElements.Size = new System.Drawing.Size(490, 337);
            this.tabControlOfElements.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(482, 311);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(482, 311);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(662, 409);
            this.backButton.Margin = new System.Windows.Forms.Padding(2);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(101, 28);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // formation_groupBox
            // 
            this.formation_groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formation_groupBox.Controls.Add(this.formatingToursPanel);
            this.formation_groupBox.Controls.Add(this.panelOfElements);
            this.formation_groupBox.Location = new System.Drawing.Point(14, 36);
            this.formation_groupBox.Margin = new System.Windows.Forms.Padding(2);
            this.formation_groupBox.Name = "formation_groupBox";
            this.formation_groupBox.Padding = new System.Windows.Forms.Padding(2);
            this.formation_groupBox.Size = new System.Drawing.Size(513, 380);
            this.formation_groupBox.TabIndex = 13;
            this.formation_groupBox.TabStop = false;
            // 
            // formatingToursPanel
            // 
            this.formatingToursPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.formatingToursPanel.AutoScroll = true;
            this.formatingToursPanel.Location = new System.Drawing.Point(2, 4);
            this.formatingToursPanel.Name = "formatingToursPanel";
            this.formatingToursPanel.Size = new System.Drawing.Size(509, 374);
            this.formatingToursPanel.TabIndex = 21;
            this.formatingToursPanel.Visible = false;
            this.formatingToursPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.formatingToursPanel_Paint);
            // 
            // configButton
            // 
            this.configButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.configButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.configButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configButton.ForeColor = System.Drawing.Color.White;
            this.configButton.Location = new System.Drawing.Point(533, 407);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(124, 30);
            this.configButton.TabIndex = 14;
            this.configButton.Text = "Печать";
            this.configButton.UseVisualStyleBackColor = false;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // timeTournirLabel
            // 
            this.timeTournirLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeTournirLabel.AutoSize = true;
            this.timeTournirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeTournirLabel.Location = new System.Drawing.Point(553, 11);
            this.timeTournirLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.timeTournirLabel.Name = "timeTournirLabel";
            this.timeTournirLabel.Size = new System.Drawing.Size(164, 17);
            this.timeTournirLabel.TabIndex = 15;
            this.timeTournirLabel.Text = "Время начала турнира:";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(533, 364);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(227, 39);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Задайте порядок групп:";
            // 
            // controlTourGroupBox
            // 
            this.controlTourGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.controlTourGroupBox.Controls.Add(this.numOfDuetNextTourTextBox);
            this.controlTourGroupBox.Controls.Add(this.startTourComboBox);
            this.controlTourGroupBox.Controls.Add(this.formSetsInTourButton);
            this.controlTourGroupBox.Controls.Add(this.label3);
            this.controlTourGroupBox.Controls.Add(this.label2);
            this.controlTourGroupBox.Location = new System.Drawing.Point(532, 43);
            this.controlTourGroupBox.Name = "controlTourGroupBox";
            this.controlTourGroupBox.Size = new System.Drawing.Size(230, 311);
            this.controlTourGroupBox.TabIndex = 18;
            this.controlTourGroupBox.TabStop = false;
            this.controlTourGroupBox.Visible = false;
            // 
            // numOfDuetNextTourTextBox
            // 
            this.numOfDuetNextTourTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numOfDuetNextTourTextBox.Location = new System.Drawing.Point(158, 81);
            this.numOfDuetNextTourTextBox.Name = "numOfDuetNextTourTextBox";
            this.numOfDuetNextTourTextBox.Size = new System.Drawing.Size(55, 24);
            this.numOfDuetNextTourTextBox.TabIndex = 21;
            // 
            // startTourComboBox
            // 
            this.startTourComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startTourComboBox.FormattingEnabled = true;
            this.startTourComboBox.Location = new System.Drawing.Point(158, 40);
            this.startTourComboBox.Name = "startTourComboBox";
            this.startTourComboBox.Size = new System.Drawing.Size(55, 26);
            this.startTourComboBox.TabIndex = 20;
            // 
            // formSetsInTourButton
            // 
            this.formSetsInTourButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.formSetsInTourButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.formSetsInTourButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formSetsInTourButton.ForeColor = System.Drawing.Color.White;
            this.formSetsInTourButton.Location = new System.Drawing.Point(9, 145);
            this.formSetsInTourButton.Name = "formSetsInTourButton";
            this.formSetsInTourButton.Size = new System.Drawing.Size(215, 36);
            this.formSetsInTourButton.TabIndex = 19;
            this.formSetsInTourButton.Text = "Формирование заходов";
            this.formSetsInTourButton.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(10, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Кол-во пар в сл.тур";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(10, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Стартовый тур";
            // 
            // formatingToursButton
            // 
            this.formatingToursButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.formatingToursButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.formatingToursButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formatingToursButton.ForeColor = System.Drawing.Color.White;
            this.formatingToursButton.Location = new System.Drawing.Point(532, 345);
            this.formatingToursButton.Name = "formatingToursButton";
            this.formatingToursButton.Size = new System.Drawing.Size(228, 39);
            this.formatingToursButton.TabIndex = 20;
            this.formatingToursButton.Text = "Задать порядок туров";
            this.formatingToursButton.UseVisualStyleBackColor = false;
            this.formatingToursButton.Click += new System.EventHandler(this.formatingToursButton_Click);
            // 
            // formationReglament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 449);
            this.Controls.Add(this.formatingToursButton);
            this.Controls.Add(this.controlTourGroupBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.timeTournirLabel);
            this.Controls.Add(this.configButton);
            this.Controls.Add(this.formation_groupBox);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "formationReglament";
            this.Text = "Формирование регламента";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formationReglament_FormClosing);
            this.Load += new System.EventHandler(this.formationReglament_Load);
            this.panelOfElements.ResumeLayout(false);
            this.tabControlOfElements.ResumeLayout(false);
            this.formation_groupBox.ResumeLayout(false);
            this.controlTourGroupBox.ResumeLayout(false);
            this.controlTourGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel panelOfElements;
        private System.Windows.Forms.GroupBox formation_groupBox;
        private System.Windows.Forms.Button configButton;
        private System.Windows.Forms.Label timeTournirLabel;
        private System.Windows.Forms.Button saveButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControlOfElements;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox controlTourGroupBox;
        private System.Windows.Forms.ComboBox startTourComboBox;
        private System.Windows.Forms.Button formSetsInTourButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.TextBox numOfDuetNextTourTextBox;
        private System.Windows.Forms.Button formatingToursButton;
        private System.Windows.Forms.Panel formatingToursPanel;
    }
}
namespace DataViewer_D_v._001
{
    partial class HoldingTournament
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
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.ControlPanel = new System.Windows.Forms.Panel();
            this.showTableButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.prevButton = new System.Windows.Forms.Button();
            this.tournamentNamelabel = new System.Windows.Forms.Label();
            this.time1label = new System.Windows.Forms.Label();
            this.timelabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.nowTimelabel1 = new System.Windows.Forms.Label();
            this.nowTimelabel = new System.Windows.Forms.Label();
            this.nextTournirButton = new System.Windows.Forms.Button();
            this.pushStartLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.acceptButton = new System.Windows.Forms.Button();
            this.backPanelButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.countsOfPositionsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.countOfTourNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.countsOfPositionsNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfTourNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(837, 146);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(163, 67);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(837, 494);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(163, 47);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlPanel.AutoScroll = true;
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Location = new System.Drawing.Point(27, 95);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(792, 359);
            this.ControlPanel.TabIndex = 2;
            // 
            // showTableButton
            // 
            this.showTableButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.showTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showTableButton.Location = new System.Drawing.Point(837, 219);
            this.showTableButton.Name = "showTableButton";
            this.showTableButton.Size = new System.Drawing.Size(163, 67);
            this.showTableButton.TabIndex = 3;
            this.showTableButton.Text = "Турнирная таблица";
            this.showTableButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextButton.Location = new System.Drawing.Point(837, 357);
            this.nextButton.Name = "nextButton";
            this.nextButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nextButton.Size = new System.Drawing.Size(45, 45);
            this.nextButton.TabIndex = 4;
            this.nextButton.Text = "▼";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // prevButton
            // 
            this.prevButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prevButton.Location = new System.Drawing.Point(837, 306);
            this.prevButton.Name = "prevButton";
            this.prevButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.prevButton.Size = new System.Drawing.Size(45, 45);
            this.prevButton.TabIndex = 5;
            this.prevButton.Text = "▲";
            this.prevButton.UseVisualStyleBackColor = true;
            this.prevButton.Click += new System.EventHandler(this.prevButton_Click);
            // 
            // tournamentNamelabel
            // 
            this.tournamentNamelabel.AutoSize = true;
            this.tournamentNamelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tournamentNamelabel.Location = new System.Drawing.Point(23, 15);
            this.tournamentNamelabel.Name = "tournamentNamelabel";
            this.tournamentNamelabel.Size = new System.Drawing.Size(0, 20);
            this.tournamentNamelabel.TabIndex = 6;
            // 
            // time1label
            // 
            this.time1label.AutoSize = true;
            this.time1label.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.time1label.Location = new System.Drawing.Point(332, 15);
            this.time1label.Name = "time1label";
            this.time1label.Size = new System.Drawing.Size(133, 20);
            this.time1label.TabIndex = 7;
            this.time1label.Text = "Время начала:";
            // 
            // timelabel
            // 
            this.timelabel.AutoSize = true;
            this.timelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timelabel.Location = new System.Drawing.Point(471, 15);
            this.timelabel.Name = "timelabel";
            this.timelabel.Size = new System.Drawing.Size(0, 20);
            this.timelabel.TabIndex = 8;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // nowTimelabel1
            // 
            this.nowTimelabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nowTimelabel1.AutoSize = true;
            this.nowTimelabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowTimelabel1.Location = new System.Drawing.Point(19, 554);
            this.nowTimelabel1.Name = "nowTimelabel1";
            this.nowTimelabel1.Size = new System.Drawing.Size(190, 20);
            this.nowTimelabel1.TabIndex = 9;
            this.nowTimelabel1.Text = "Продолжительность:";
            // 
            // nowTimelabel
            // 
            this.nowTimelabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nowTimelabel.AutoSize = true;
            this.nowTimelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowTimelabel.Location = new System.Drawing.Point(215, 554);
            this.nowTimelabel.Name = "nowTimelabel";
            this.nowTimelabel.Size = new System.Drawing.Size(61, 20);
            this.nowTimelabel.TabIndex = 10;
            this.nowTimelabel.Text = "время";
            // 
            // nextTournirButton
            // 
            this.nextTournirButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextTournirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextTournirButton.Location = new System.Drawing.Point(837, 418);
            this.nextTournirButton.Name = "nextTournirButton";
            this.nextTournirButton.Size = new System.Drawing.Size(163, 68);
            this.nextTournirButton.TabIndex = 11;
            this.nextTournirButton.Text = "Следующий тур";
            this.nextTournirButton.UseVisualStyleBackColor = true;
            this.nextTournirButton.Click += new System.EventHandler(this.nextTournirButton_Click);
            // 
            // pushStartLabel
            // 
            this.pushStartLabel.AutoSize = true;
            this.pushStartLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pushStartLabel.Location = new System.Drawing.Point(136, 202);
            this.pushStartLabel.Name = "pushStartLabel";
            this.pushStartLabel.Size = new System.Drawing.Size(453, 29);
            this.pushStartLabel.TabIndex = 0;
            this.pushStartLabel.Text = "Нажмите \"Start\", чтобы начать турнир!";
            // 
            // buttonPanel
            // 
            this.buttonPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPanel.AutoScroll = true;
            this.buttonPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonPanel.Controls.Add(this.acceptButton);
            this.buttonPanel.Controls.Add(this.backPanelButton);
            this.buttonPanel.Location = new System.Drawing.Point(27, 460);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(792, 64);
            this.buttonPanel.TabIndex = 16;
            // 
            // acceptButton
            // 
            this.acceptButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.acceptButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.acceptButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.acceptButton.Location = new System.Drawing.Point(478, 7);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(170, 47);
            this.acceptButton.TabIndex = 15;
            this.acceptButton.Text = "Принять";
            this.acceptButton.UseVisualStyleBackColor = false;
            this.acceptButton.Click += new System.EventHandler(this.acceptButton_Click);
            // 
            // backPanelButton
            // 
            this.backPanelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backPanelButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.backPanelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backPanelButton.Location = new System.Drawing.Point(680, 7);
            this.backPanelButton.Name = "backPanelButton";
            this.backPanelButton.Size = new System.Drawing.Size(99, 47);
            this.backPanelButton.TabIndex = 14;
            this.backPanelButton.Text = "Назад";
            this.backPanelButton.UseVisualStyleBackColor = false;
            this.backPanelButton.Click += new System.EventHandler(this.backPanelButton_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(832, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 25);
            this.label3.TabIndex = 18;
            this.label3.Text = "Туров";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(832, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Мест";
            // 
            // countsOfPositionsNumericUpDown
            // 
            this.countsOfPositionsNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countsOfPositionsNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countsOfPositionsNumericUpDown.Location = new System.Drawing.Point(927, 50);
            this.countsOfPositionsNumericUpDown.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.countsOfPositionsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countsOfPositionsNumericUpDown.Name = "countsOfPositionsNumericUpDown";
            this.countsOfPositionsNumericUpDown.Size = new System.Drawing.Size(61, 30);
            this.countsOfPositionsNumericUpDown.TabIndex = 20;
            this.countsOfPositionsNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // countOfTourNumericUpDown
            // 
            this.countOfTourNumericUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.countOfTourNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countOfTourNumericUpDown.Location = new System.Drawing.Point(927, 96);
            this.countOfTourNumericUpDown.Maximum = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.countOfTourNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.countOfTourNumericUpDown.Name = "countOfTourNumericUpDown";
            this.countOfTourNumericUpDown.Size = new System.Drawing.Size(61, 30);
            this.countOfTourNumericUpDown.TabIndex = 21;
            this.countOfTourNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // HoldingTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 593);
            this.Controls.Add(this.countOfTourNumericUpDown);
            this.Controls.Add(this.countsOfPositionsNumericUpDown);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.pushStartLabel);
            this.Controls.Add(this.nextTournirButton);
            this.Controls.Add(this.nowTimelabel);
            this.Controls.Add(this.nowTimelabel1);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.time1label);
            this.Controls.Add(this.tournamentNamelabel);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.showTableButton);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.startButton);
            this.Name = "HoldingTournament";
            this.Text = "HoldingTournament";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HoldingTournament_FormClosing);
            this.Load += new System.EventHandler(this.HoldingTournament_Load);
            this.buttonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.countsOfPositionsNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countOfTourNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel ControlPanel;
        private System.Windows.Forms.Button showTableButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button prevButton;
        private System.Windows.Forms.Label tournamentNamelabel;
        private System.Windows.Forms.Label time1label;
        private System.Windows.Forms.Label timelabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label nowTimelabel1;
        private System.Windows.Forms.Label nowTimelabel;
        private System.Windows.Forms.Button nextTournirButton;
        private System.Windows.Forms.Label pushStartLabel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button backPanelButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown countsOfPositionsNumericUpDown;
        private System.Windows.Forms.NumericUpDown countOfTourNumericUpDown;
    }
}
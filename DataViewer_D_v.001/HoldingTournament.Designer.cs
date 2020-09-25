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
            this.TourOneButton = new System.Windows.Forms.Button();
            this.countOfTourTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.startButton.Location = new System.Drawing.Point(743, 129);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(163, 67);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start!";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // backButton
            // 
            this.backButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backButton.Location = new System.Drawing.Point(743, 477);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(163, 47);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // ControlPanel
            // 
            this.ControlPanel.AutoScroll = true;
            this.ControlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ControlPanel.Location = new System.Drawing.Point(25, 78);
            this.ControlPanel.Name = "ControlPanel";
            this.ControlPanel.Size = new System.Drawing.Size(700, 450);
            this.ControlPanel.TabIndex = 2;
            // 
            // showTableButton
            // 
            this.showTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.showTableButton.Location = new System.Drawing.Point(743, 202);
            this.showTableButton.Name = "showTableButton";
            this.showTableButton.Size = new System.Drawing.Size(163, 67);
            this.showTableButton.TabIndex = 3;
            this.showTableButton.Text = "Турнирная таблица";
            this.showTableButton.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextButton.Location = new System.Drawing.Point(743, 340);
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
            this.prevButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prevButton.Location = new System.Drawing.Point(743, 289);
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
            // nowTimelabel1
            // 
            this.nowTimelabel1.AutoSize = true;
            this.nowTimelabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowTimelabel1.Location = new System.Drawing.Point(21, 540);
            this.nowTimelabel1.Name = "nowTimelabel1";
            this.nowTimelabel1.Size = new System.Drawing.Size(190, 20);
            this.nowTimelabel1.TabIndex = 9;
            this.nowTimelabel1.Text = "Продолжительность:";
            // 
            // nowTimelabel
            // 
            this.nowTimelabel.AutoSize = true;
            this.nowTimelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nowTimelabel.Location = new System.Drawing.Point(217, 540);
            this.nowTimelabel.Name = "nowTimelabel";
            this.nowTimelabel.Size = new System.Drawing.Size(61, 20);
            this.nowTimelabel.TabIndex = 10;
            this.nowTimelabel.Text = "время";
            // 
            // nextTournirButton
            // 
            this.nextTournirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextTournirButton.Location = new System.Drawing.Point(743, 401);
            this.nextTournirButton.Name = "nextTournirButton";
            this.nextTournirButton.Size = new System.Drawing.Size(163, 68);
            this.nextTournirButton.TabIndex = 11;
            this.nextTournirButton.Text = "Следующий тур";
            this.nextTournirButton.UseVisualStyleBackColor = true;
            // 
            // TourOneButton
            // 
            this.TourOneButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TourOneButton.Location = new System.Drawing.Point(25, 45);
            this.TourOneButton.Name = "TourOneButton";
            this.TourOneButton.Size = new System.Drawing.Size(105, 35);
            this.TourOneButton.TabIndex = 12;
            this.TourOneButton.Text = "Тур1";
            this.TourOneButton.UseVisualStyleBackColor = true;
            // 
            // countOfTourTextBox
            // 
            this.countOfTourTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.countOfTourTextBox.Location = new System.Drawing.Point(743, 78);
            this.countOfTourTextBox.Name = "countOfTourTextBox";
            this.countOfTourTextBox.Size = new System.Drawing.Size(73, 30);
            this.countOfTourTextBox.TabIndex = 13;
            this.countOfTourTextBox.Text = "2";
            // 
            // HoldingTournament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 580);
            this.Controls.Add(this.countOfTourTextBox);
            this.Controls.Add(this.TourOneButton);
            this.Controls.Add(this.nextTournirButton);
            this.Controls.Add(this.nowTimelabel);
            this.Controls.Add(this.nowTimelabel1);
            this.Controls.Add(this.timelabel);
            this.Controls.Add(this.time1label);
            this.Controls.Add(this.tournamentNamelabel);
            this.Controls.Add(this.prevButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.showTableButton);
            this.Controls.Add(this.ControlPanel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.startButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "HoldingTournament";
            this.Text = "HoldingTournament";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HoldingTournament_FormClosing);
            this.Load += new System.EventHandler(this.HoldingTournament_Load);
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
        private System.Windows.Forms.Button TourOneButton;
        private System.Windows.Forms.TextBox countOfTourTextBox;
    }
}
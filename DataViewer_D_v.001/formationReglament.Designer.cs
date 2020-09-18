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
            this.backButton = new System.Windows.Forms.Button();
            this.formation_groupBox = new System.Windows.Forms.GroupBox();
            this.configButton = new System.Windows.Forms.Button();
            this.timeTournirLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.formation_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOfElements
            // 
            this.panelOfElements.AutoScroll = true;
            this.panelOfElements.Location = new System.Drawing.Point(0, 11);
            this.panelOfElements.Name = "panelOfElements";
            this.panelOfElements.Size = new System.Drawing.Size(639, 385);
            this.panelOfElements.TabIndex = 12;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(792, 377);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(104, 37);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Назад";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // formation_groupBox
            // 
            this.formation_groupBox.Controls.Add(this.panelOfElements);
            this.formation_groupBox.Location = new System.Drawing.Point(12, 12);
            this.formation_groupBox.Name = "formation_groupBox";
            this.formation_groupBox.Size = new System.Drawing.Size(639, 402);
            this.formation_groupBox.TabIndex = 13;
            this.formation_groupBox.TabStop = false;
            // 
            // configButton
            // 
            this.configButton.BackColor = System.Drawing.Color.Tomato;
            this.configButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configButton.ForeColor = System.Drawing.Color.White;
            this.configButton.Location = new System.Drawing.Point(668, 377);
            this.configButton.Margin = new System.Windows.Forms.Padding(4);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(117, 37);
            this.configButton.TabIndex = 14;
            this.configButton.Text = "Инфо";
            this.configButton.UseVisualStyleBackColor = false;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // timeTournirLabel
            // 
            this.timeTournirLabel.AutoSize = true;
            this.timeTournirLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeTournirLabel.Location = new System.Drawing.Point(665, 46);
            this.timeTournirLabel.Name = "timeTournirLabel";
            this.timeTournirLabel.Size = new System.Drawing.Size(168, 18);
            this.timeTournirLabel.TabIndex = 15;
            this.timeTournirLabel.Text = "Время начала турнира:";
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Tomato;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.ForeColor = System.Drawing.Color.White;
            this.saveButton.Location = new System.Drawing.Point(668, 322);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(228, 48);
            this.saveButton.TabIndex = 16;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // formationReglament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 427);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.timeTournirLabel);
            this.Controls.Add(this.configButton);
            this.Controls.Add(this.formation_groupBox);
            this.Controls.Add(this.backButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "formationReglament";
            this.Text = "formationReglament";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formationReglament_FormClosing);
            this.Load += new System.EventHandler(this.formationReglament_Load);
            this.formation_groupBox.ResumeLayout(false);
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
    }
}
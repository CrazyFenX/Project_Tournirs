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
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.comboBox8 = new System.Windows.Forms.ComboBox();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.comboBox11 = new System.Windows.Forms.ComboBox();
            this.comboBox10 = new System.Windows.Forms.ComboBox();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.backButton = new System.Windows.Forms.Button();
            this.formation_groupBox = new System.Windows.Forms.GroupBox();
            this.configButton = new System.Windows.Forms.Button();
            this.panelOfElements.SuspendLayout();
            this.formation_groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelOfElements
            // 
            this.panelOfElements.AutoScroll = true;
            this.panelOfElements.Controls.Add(this.comboBox7);
            this.panelOfElements.Controls.Add(this.comboBox8);
            this.panelOfElements.Controls.Add(this.comboBox9);
            this.panelOfElements.Controls.Add(this.comboBox11);
            this.panelOfElements.Controls.Add(this.comboBox10);
            this.panelOfElements.Controls.Add(this.comboBox5);
            this.panelOfElements.Location = new System.Drawing.Point(0, 11);
            this.panelOfElements.Name = "panelOfElements";
            this.panelOfElements.Size = new System.Drawing.Size(645, 385);
            this.panelOfElements.TabIndex = 12;
            // 
            // comboBox7
            // 
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.Location = new System.Drawing.Point(17, 389);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(121, 24);
            this.comboBox7.TabIndex = 9;
            // 
            // comboBox8
            // 
            this.comboBox8.FormattingEnabled = true;
            this.comboBox8.Location = new System.Drawing.Point(17, 445);
            this.comboBox8.Name = "comboBox8";
            this.comboBox8.Size = new System.Drawing.Size(121, 24);
            this.comboBox8.TabIndex = 10;
            // 
            // comboBox9
            // 
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.Location = new System.Drawing.Point(17, 500);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(121, 24);
            this.comboBox9.TabIndex = 11;
            // 
            // comboBox11
            // 
            this.comboBox11.FormattingEnabled = true;
            this.comboBox11.Location = new System.Drawing.Point(17, 556);
            this.comboBox11.Name = "comboBox11";
            this.comboBox11.Size = new System.Drawing.Size(121, 24);
            this.comboBox11.TabIndex = 12;
            // 
            // comboBox10
            // 
            this.comboBox10.FormattingEnabled = true;
            this.comboBox10.Location = new System.Drawing.Point(17, 337);
            this.comboBox10.Name = "comboBox10";
            this.comboBox10.Size = new System.Drawing.Size(121, 24);
            this.comboBox10.TabIndex = 8;
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(17, 289);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(121, 24);
            this.comboBox5.TabIndex = 7;
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(664, 377);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(125, 37);
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
            this.configButton.Location = new System.Drawing.Point(664, 322);
            this.configButton.Margin = new System.Windows.Forms.Padding(4);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(124, 48);
            this.configButton.TabIndex = 14;
            this.configButton.Text = "config";
            this.configButton.UseVisualStyleBackColor = false;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // formationReglament
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 474);
            this.Controls.Add(this.configButton);
            this.Controls.Add(this.formation_groupBox);
            this.Controls.Add(this.backButton);
            this.Name = "formationReglament";
            this.Text = "formationReglament";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formationReglament_FormClosing);
            this.Load += new System.EventHandler(this.formationReglament_Load);
            this.panelOfElements.ResumeLayout(false);
            this.formation_groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Panel panelOfElements;
        private System.Windows.Forms.ComboBox comboBox8;
        private System.Windows.Forms.ComboBox comboBox9;
        private System.Windows.Forms.ComboBox comboBox11;
        private System.Windows.Forms.GroupBox formation_groupBox;
        private System.Windows.Forms.ComboBox comboBox7;
        private System.Windows.Forms.ComboBox comboBox10;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Button configButton;
    }
}
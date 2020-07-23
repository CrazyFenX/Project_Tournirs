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
            this.Path_textBox.Location = new System.Drawing.Point(80, 17);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(352, 22);
            this.Path_textBox.TabIndex = 1;
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(113, 45);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(319, 22);
            this.Name_textBox.TabIndex = 2;
            // 
            // Label_name
            // 
            this.Label_name.AutoSize = true;
            this.Label_name.Location = new System.Drawing.Point(35, 48);
            this.Label_name.Name = "Label_name";
            this.Label_name.Size = new System.Drawing.Size(72, 17);
            this.Label_name.TabIndex = 4;
            this.Label_name.Text = "Название";
            // 
            // Label_path
            // 
            this.Label_path.AutoSize = true;
            this.Label_path.Location = new System.Drawing.Point(35, 20);
            this.Label_path.Name = "Label_path";
            this.Label_path.Size = new System.Drawing.Size(39, 17);
            this.Label_path.TabIndex = 5;
            this.Label_path.Text = "Путь";
            // 
            // Create_button
            // 
            this.Create_button.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.Create_button.Location = new System.Drawing.Point(340, 72);
            this.Create_button.Name = "Create_button";
            this.Create_button.Size = new System.Drawing.Size(92, 49);
            this.Create_button.TabIndex = 6;
            this.Create_button.Text = "Createe!";
            this.Create_button.UseVisualStyleBackColor = false;
            this.Create_button.Click += new System.EventHandler(this.Create_button_Click);
            // 
            // Back_button
            // 
            this.Back_button.Location = new System.Drawing.Point(438, 72);
            this.Back_button.Name = "Back_button";
            this.Back_button.Size = new System.Drawing.Size(92, 49);
            this.Back_button.TabIndex = 7;
            this.Back_button.Text = "Back";
            this.Back_button.UseVisualStyleBackColor = true;
            this.Back_button.Click += new System.EventHandler(this.Back_button_Click);
            // 
            // CreatingTournirDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 139);
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
    }
}
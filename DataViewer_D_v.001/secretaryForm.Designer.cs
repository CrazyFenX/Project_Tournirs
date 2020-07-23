namespace DataViewer_D_v._001
{
    partial class secretaryForm
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
            this.CreateNewTournirButton = new System.Windows.Forms.Button();
            this.backbutton = new System.Windows.Forms.Button();
            this.Path_textBox = new System.Windows.Forms.TextBox();
            this.OpenBase_button = new System.Windows.Forms.Button();
            this.Delete_button = new System.Windows.Forms.Button();
            this.Browse_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // CreateNewTournirButton
            // 
            this.CreateNewTournirButton.Location = new System.Drawing.Point(623, 17);
            this.CreateNewTournirButton.Name = "CreateNewTournirButton";
            this.CreateNewTournirButton.Size = new System.Drawing.Size(165, 60);
            this.CreateNewTournirButton.TabIndex = 0;
            this.CreateNewTournirButton.Text = "Создать Турнир";
            this.CreateNewTournirButton.UseVisualStyleBackColor = true;
            this.CreateNewTournirButton.Click += new System.EventHandler(this.CreateNewTournirButton_Click);
            // 
            // backbutton
            // 
            this.backbutton.Location = new System.Drawing.Point(623, 358);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(165, 60);
            this.backbutton.TabIndex = 1;
            this.backbutton.Text = "Назад";
            this.backbutton.UseVisualStyleBackColor = true;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // Path_textBox
            // 
            this.Path_textBox.Location = new System.Drawing.Point(25, 324);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(592, 22);
            this.Path_textBox.TabIndex = 2;
            // 
            // OpenBase_button
            // 
            this.OpenBase_button.Location = new System.Drawing.Point(623, 83);
            this.OpenBase_button.Name = "OpenBase_button";
            this.OpenBase_button.Size = new System.Drawing.Size(165, 60);
            this.OpenBase_button.TabIndex = 3;
            this.OpenBase_button.Text = "Открыть базу";
            this.OpenBase_button.UseVisualStyleBackColor = true;
            this.OpenBase_button.Click += new System.EventHandler(this.OpenBase_button_Click);
            // 
            // Delete_button
            // 
            this.Delete_button.Location = new System.Drawing.Point(623, 149);
            this.Delete_button.Name = "Delete_button";
            this.Delete_button.Size = new System.Drawing.Size(165, 60);
            this.Delete_button.TabIndex = 4;
            this.Delete_button.Text = "Удалить Турнир";
            this.Delete_button.UseVisualStyleBackColor = true;
            this.Delete_button.Click += new System.EventHandler(this.Delete_button_Click);
            // 
            // Browse_button
            // 
            this.Browse_button.Location = new System.Drawing.Point(623, 319);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(165, 33);
            this.Browse_button.TabIndex = 5;
            this.Browse_button.Text = "Browse";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // secretaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 430);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.Delete_button);
            this.Controls.Add(this.OpenBase_button);
            this.Controls.Add(this.Path_textBox);
            this.Controls.Add(this.backbutton);
            this.Controls.Add(this.CreateNewTournirButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "secretaryForm";
            this.Text = "secretaryForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.secretaryForm_FormClosing);
            this.Load += new System.EventHandler(this.secretaryForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CreateNewTournirButton;
        private System.Windows.Forms.Button backbutton;
        public System.Windows.Forms.TextBox Path_textBox;
        private System.Windows.Forms.Button OpenBase_button;
        private System.Windows.Forms.Button Delete_button;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
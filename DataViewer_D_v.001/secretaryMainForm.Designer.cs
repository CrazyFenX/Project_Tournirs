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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backbutton = new System.Windows.Forms.Button();
            this.reglament_button = new System.Windows.Forms.Button();
            this.printDiplom_button = new System.Windows.Forms.Button();
            this.prepareTournir_button = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.configButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.backbutton);
            this.groupBox2.Controls.Add(this.reglament_button);
            this.groupBox2.Controls.Add(this.printDiplom_button);
            this.groupBox2.Controls.Add(this.prepareTournir_button);
            this.groupBox2.Location = new System.Drawing.Point(751, 36);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(227, 449);
            this.groupBox2.TabIndex = 42;
            this.groupBox2.TabStop = false;
            // 
            // backbutton
            // 
            this.backbutton.BackColor = System.Drawing.Color.Tomato;
            this.backbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backbutton.ForeColor = System.Drawing.Color.White;
            this.backbutton.Location = new System.Drawing.Point(12, 374);
            this.backbutton.Name = "backbutton";
            this.backbutton.Size = new System.Drawing.Size(207, 62);
            this.backbutton.TabIndex = 43;
            this.backbutton.Text = "Назад";
            this.backbutton.UseVisualStyleBackColor = false;
            this.backbutton.Click += new System.EventHandler(this.backbutton_Click);
            // 
            // reglament_button
            // 
            this.reglament_button.BackColor = System.Drawing.Color.Tomato;
            this.reglament_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reglament_button.ForeColor = System.Drawing.Color.White;
            this.reglament_button.Location = new System.Drawing.Point(10, 21);
            this.reglament_button.Margin = new System.Windows.Forms.Padding(4);
            this.reglament_button.Name = "reglament_button";
            this.reglament_button.Size = new System.Drawing.Size(209, 110);
            this.reglament_button.TabIndex = 0;
            this.reglament_button.Text = "Формирование регламента";
            this.reglament_button.UseVisualStyleBackColor = false;
            this.reglament_button.Click += new System.EventHandler(this.reglament_button_Click);
            // 
            // printDiplom_button
            // 
            this.printDiplom_button.BackColor = System.Drawing.Color.Tomato;
            this.printDiplom_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.printDiplom_button.ForeColor = System.Drawing.Color.White;
            this.printDiplom_button.Location = new System.Drawing.Point(10, 139);
            this.printDiplom_button.Margin = new System.Windows.Forms.Padding(4);
            this.printDiplom_button.Name = "printDiplom_button";
            this.printDiplom_button.Size = new System.Drawing.Size(209, 110);
            this.printDiplom_button.TabIndex = 1;
            this.printDiplom_button.Text = "Печать дипломов";
            this.printDiplom_button.UseVisualStyleBackColor = false;
            // 
            // prepareTournir_button
            // 
            this.prepareTournir_button.BackColor = System.Drawing.Color.Tomato;
            this.prepareTournir_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.prepareTournir_button.ForeColor = System.Drawing.Color.White;
            this.prepareTournir_button.Location = new System.Drawing.Point(12, 257);
            this.prepareTournir_button.Margin = new System.Windows.Forms.Padding(4);
            this.prepareTournir_button.Name = "prepareTournir_button";
            this.prepareTournir_button.Size = new System.Drawing.Size(207, 110);
            this.prepareTournir_button.TabIndex = 2;
            this.prepareTournir_button.Text = "Подготовка к турниру";
            this.prepareTournir_button.UseVisualStyleBackColor = false;
            this.prepareTournir_button.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Brown;
            this.groupBox1.Controls.Add(this.configButton);
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(31, 36);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(694, 449);
            this.groupBox1.TabIndex = 41;
            this.groupBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.MistyRose;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(651, 406);
            this.dataGridView1.TabIndex = 0;
            // 
            // configButton
            // 
            this.configButton.BackColor = System.Drawing.Color.Tomato;
            this.configButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.configButton.ForeColor = System.Drawing.Color.White;
            this.configButton.Location = new System.Drawing.Point(533, 385);
            this.configButton.Margin = new System.Windows.Forms.Padding(4);
            this.configButton.Name = "configButton";
            this.configButton.Size = new System.Drawing.Size(161, 64);
            this.configButton.TabIndex = 43;
            this.configButton.Text = "config";
            this.configButton.UseVisualStyleBackColor = false;
            this.configButton.Click += new System.EventHandler(this.configButton_Click);
            // 
            // secretaryMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSalmon;
            this.ClientSize = new System.Drawing.Size(999, 510);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "secretaryMainForm";
            this.Text = "secretaryMainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.secretaryMainForm_FormClosing);
            this.Load += new System.EventHandler(this.secretaryMainForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button reglament_button;
        private System.Windows.Forms.Button printDiplom_button;
        private System.Windows.Forms.Button prepareTournir_button;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button backbutton;
        private System.Windows.Forms.Button configButton;
    }
}
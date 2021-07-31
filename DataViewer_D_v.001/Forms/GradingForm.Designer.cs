namespace DataViewer_D_v._001
{
    partial class GradingForm
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
            this.controlPanel = new System.Windows.Forms.Panel();
            this.testButton = new System.Windows.Forms.Button();
            this.graduatePanel = new System.Windows.Forms.Panel();
            this.backToGroupButton = new System.Windows.Forms.Button();
            this.toSumUpButton = new System.Windows.Forms.Button();
            this.panelOfElements = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.nextTourTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.setCountTextBox = new System.Windows.Forms.TextBox();
            this.controlPanel.SuspendLayout();
            this.panelOfElements.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.testButton);
            this.controlPanel.Controls.Add(this.graduatePanel);
            this.controlPanel.Controls.Add(this.backToGroupButton);
            this.controlPanel.Controls.Add(this.toSumUpButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 358);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(649, 80);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.controlPanel_Paint);
            // 
            // testButton
            // 
            this.testButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.testButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.testButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.testButton.Location = new System.Drawing.Point(316, 26);
            this.testButton.Margin = new System.Windows.Forms.Padding(2);
            this.testButton.Name = "testButton";
            this.testButton.Size = new System.Drawing.Size(94, 35);
            this.testButton.TabIndex = 2;
            this.testButton.Text = "тест";
            this.testButton.UseVisualStyleBackColor = false;
            this.testButton.Visible = false;
            this.testButton.Click += new System.EventHandler(this.testButton_Click);
            // 
            // graduatePanel
            // 
            this.graduatePanel.AutoScroll = true;
            this.graduatePanel.Location = new System.Drawing.Point(280, 34);
            this.graduatePanel.Margin = new System.Windows.Forms.Padding(2);
            this.graduatePanel.Name = "graduatePanel";
            this.graduatePanel.Size = new System.Drawing.Size(25, 29);
            this.graduatePanel.TabIndex = 2;
            this.graduatePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graduatePanel_Paint);
            // 
            // backToGroupButton
            // 
            this.backToGroupButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.backToGroupButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.backToGroupButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.backToGroupButton.Location = new System.Drawing.Point(11, 16);
            this.backToGroupButton.Margin = new System.Windows.Forms.Padding(2);
            this.backToGroupButton.Name = "backToGroupButton";
            this.backToGroupButton.Size = new System.Drawing.Size(164, 47);
            this.backToGroupButton.TabIndex = 3;
            this.backToGroupButton.Text = "Выбор группы";
            this.backToGroupButton.UseVisualStyleBackColor = false;
            this.backToGroupButton.Click += new System.EventHandler(this.backToGroupButton_Click);
            // 
            // toSumUpButton
            // 
            this.toSumUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toSumUpButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toSumUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toSumUpButton.Location = new System.Drawing.Point(414, 17);
            this.toSumUpButton.Margin = new System.Windows.Forms.Padding(2);
            this.toSumUpButton.Name = "toSumUpButton";
            this.toSumUpButton.Size = new System.Drawing.Size(226, 52);
            this.toSumUpButton.TabIndex = 0;
            this.toSumUpButton.Text = "Подвести итоги группы";
            this.toSumUpButton.UseVisualStyleBackColor = false;
            this.toSumUpButton.Click += new System.EventHandler(this.toSumUpButton_Click);
            // 
            // panelOfElements
            // 
            this.panelOfElements.AutoScroll = true;
            this.panelOfElements.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelOfElements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOfElements.Controls.Add(this.label2);
            this.panelOfElements.Controls.Add(this.setCountTextBox);
            this.panelOfElements.Controls.Add(this.label1);
            this.panelOfElements.Controls.Add(this.nextTourTextBox);
            this.panelOfElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOfElements.Location = new System.Drawing.Point(0, 0);
            this.panelOfElements.Margin = new System.Windows.Forms.Padding(2);
            this.panelOfElements.Name = "panelOfElements";
            this.panelOfElements.Size = new System.Drawing.Size(649, 358);
            this.panelOfElements.TabIndex = 1;
            this.panelOfElements.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOfElements_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(509, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "В след.тур";
            // 
            // nextTourTextBox
            // 
            this.nextTourTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nextTourTextBox.Location = new System.Drawing.Point(588, 20);
            this.nextTourTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.nextTourTextBox.Name = "nextTourTextBox";
            this.nextTourTextBox.Size = new System.Drawing.Size(38, 23);
            this.nextTourTextBox.TabIndex = 0;
            this.nextTourTextBox.TextChanged += new System.EventHandler(this.nextTourTextBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(509, 47);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Заходов";
            // 
            // setCountTextBox
            // 
            this.setCountTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.setCountTextBox.Location = new System.Drawing.Point(588, 47);
            this.setCountTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.setCountTextBox.Name = "setCountTextBox";
            this.setCountTextBox.Size = new System.Drawing.Size(38, 23);
            this.setCountTextBox.TabIndex = 2;
            // 
            // GradingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 438);
            this.Controls.Add(this.panelOfElements);
            this.Controls.Add(this.controlPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GradingForm";
            this.Text = "Ввод судейских оценок";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GradingForm_FormClosing);
            this.Load += new System.EventHandler(this.GradingForm_Load);
            this.controlPanel.ResumeLayout(false);
            this.panelOfElements.ResumeLayout(false);
            this.panelOfElements.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button toSumUpButton;
        private System.Windows.Forms.Panel panelOfElements;
        private System.Windows.Forms.Panel graduatePanel;
        private System.Windows.Forms.Button backToGroupButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox nextTourTextBox;
        private System.Windows.Forms.Button testButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox setCountTextBox;
    }
}
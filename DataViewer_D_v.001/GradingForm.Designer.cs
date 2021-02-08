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
            this.graduatePanel = new System.Windows.Forms.Panel();
            this.toSumUpButton = new System.Windows.Forms.Button();
            this.panelOfElements = new System.Windows.Forms.Panel();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.graduatePanel);
            this.controlPanel.Controls.Add(this.toSumUpButton);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlPanel.Location = new System.Drawing.Point(0, 441);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(865, 98);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.controlPanel_Paint);
            // 
            // graduatePanel
            // 
            this.graduatePanel.AutoScroll = true;
            this.graduatePanel.Location = new System.Drawing.Point(15, 39);
            this.graduatePanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.graduatePanel.Name = "graduatePanel";
            this.graduatePanel.Size = new System.Drawing.Size(79, 45);
            this.graduatePanel.TabIndex = 2;
            this.graduatePanel.Paint += new System.Windows.Forms.PaintEventHandler(this.graduatePanel_Paint);
            // 
            // toSumUpButton
            // 
            this.toSumUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.toSumUpButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.toSumUpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toSumUpButton.Location = new System.Drawing.Point(627, 21);
            this.toSumUpButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.toSumUpButton.Name = "toSumUpButton";
            this.toSumUpButton.Size = new System.Drawing.Size(227, 57);
            this.toSumUpButton.TabIndex = 0;
            this.toSumUpButton.Text = "Подвести итоги";
            this.toSumUpButton.UseVisualStyleBackColor = false;
            this.toSumUpButton.Click += new System.EventHandler(this.toSumUpButton_Click);
            // 
            // panelOfElements
            // 
            this.panelOfElements.AutoScroll = true;
            this.panelOfElements.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panelOfElements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelOfElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOfElements.Location = new System.Drawing.Point(0, 0);
            this.panelOfElements.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelOfElements.Name = "panelOfElements";
            this.panelOfElements.Size = new System.Drawing.Size(865, 441);
            this.panelOfElements.TabIndex = 1;
            // 
            // GradingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 539);
            this.Controls.Add(this.panelOfElements);
            this.Controls.Add(this.controlPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "GradingForm";
            this.Text = "GradingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GradingForm_FormClosing);
            this.Load += new System.EventHandler(this.GradingForm_Load);
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button toSumUpButton;
        private System.Windows.Forms.Panel panelOfElements;
        private System.Windows.Forms.Panel graduatePanel;
    }
}
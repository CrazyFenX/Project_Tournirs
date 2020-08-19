namespace DataViewer_D_v._001
{
    partial class DataViewerSecretary
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataViewerSecretary));
            this.mainDataGridView = new System.Windows.Forms.DataGridView();
            this.showJudge_button = new System.Windows.Forms.Button();
            this.showTournir_button = new System.Windows.Forms.Button();
            this.Update_button = new System.Windows.Forms.Button();
            this.DataView_bindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.showParticipant_button = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.Path_textBox = new System.Windows.Forms.TextBox();
            this.Browse_button = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.showGroup_button = new System.Windows.Forms.Button();
            this.showCategories_button = new System.Windows.Forms.Button();
            this.showSets_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView_bindingNavigator)).BeginInit();
            this.DataView_bindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainDataGridView
            // 
            this.mainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.mainDataGridView.Location = new System.Drawing.Point(13, 30);
            this.mainDataGridView.Name = "mainDataGridView";
            this.mainDataGridView.RowHeadersWidth = 51;
            this.mainDataGridView.RowTemplate.Height = 24;
            this.mainDataGridView.Size = new System.Drawing.Size(789, 216);
            this.mainDataGridView.TabIndex = 5;
            // 
            // showJudge_button
            // 
            this.showJudge_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.showJudge_button.Location = new System.Drawing.Point(107, 252);
            this.showJudge_button.Name = "showJudge_button";
            this.showJudge_button.Size = new System.Drawing.Size(96, 26);
            this.showJudge_button.TabIndex = 9;
            this.showJudge_button.Text = "Judges";
            this.showJudge_button.UseVisualStyleBackColor = false;
            this.showJudge_button.Click += new System.EventHandler(this.showJudge_button_Click);
            // 
            // showTournir_button
            // 
            this.showTournir_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.showTournir_button.Location = new System.Drawing.Point(12, 252);
            this.showTournir_button.Name = "showTournir_button";
            this.showTournir_button.Size = new System.Drawing.Size(96, 26);
            this.showTournir_button.TabIndex = 8;
            this.showTournir_button.Text = "Tournir";
            this.showTournir_button.UseVisualStyleBackColor = false;
            this.showTournir_button.Click += new System.EventHandler(this.showTournir_button_Click);
            // 
            // Update_button
            // 
            this.Update_button.Location = new System.Drawing.Point(669, 258);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(133, 31);
            this.Update_button.TabIndex = 7;
            this.Update_button.Text = "Update";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // DataView_bindingNavigator
            // 
            this.DataView_bindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.DataView_bindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.DataView_bindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.DataView_bindingNavigator.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.DataView_bindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.DataView_bindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.DataView_bindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.DataView_bindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.DataView_bindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.DataView_bindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.DataView_bindingNavigator.Name = "DataView_bindingNavigator";
            this.DataView_bindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.DataView_bindingNavigator.Size = new System.Drawing.Size(815, 27);
            this.DataView_bindingNavigator.TabIndex = 6;
            this.DataView_bindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorAddNewItem.Text = "Добавить";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 24);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 24);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // showParticipant_button
            // 
            this.showParticipant_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.showParticipant_button.Location = new System.Drawing.Point(200, 252);
            this.showParticipant_button.Name = "showParticipant_button";
            this.showParticipant_button.Size = new System.Drawing.Size(95, 26);
            this.showParticipant_button.TabIndex = 10;
            this.showParticipant_button.Text = "Participants";
            this.showParticipant_button.UseVisualStyleBackColor = false;
            this.showParticipant_button.Click += new System.EventHandler(this.showParticipant_button_Click);
            // 
            // Path_textBox
            // 
            this.Path_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Path_textBox.Location = new System.Drawing.Point(13, 296);
            this.Path_textBox.Name = "Path_textBox";
            this.Path_textBox.Size = new System.Drawing.Size(651, 26);
            this.Path_textBox.TabIndex = 11;
            this.Path_textBox.TextChanged += new System.EventHandler(this.Path_textBox_TextChanged);
            // 
            // Browse_button
            // 
            this.Browse_button.Location = new System.Drawing.Point(670, 295);
            this.Browse_button.Name = "Browse_button";
            this.Browse_button.Size = new System.Drawing.Size(133, 31);
            this.Browse_button.TabIndex = 12;
            this.Browse_button.Text = "Browse";
            this.Browse_button.UseVisualStyleBackColor = true;
            this.Browse_button.Click += new System.EventHandler(this.Browse_button_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // showGroup_button
            // 
            this.showGroup_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.showGroup_button.Location = new System.Drawing.Point(291, 252);
            this.showGroup_button.Name = "showGroup_button";
            this.showGroup_button.Size = new System.Drawing.Size(95, 26);
            this.showGroup_button.TabIndex = 15;
            this.showGroup_button.Text = "Groups";
            this.showGroup_button.UseVisualStyleBackColor = false;
            this.showGroup_button.Click += new System.EventHandler(this.showGroup_button_Click);
            // 
            // showCategories_button
            // 
            this.showCategories_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.showCategories_button.Location = new System.Drawing.Point(383, 252);
            this.showCategories_button.Name = "showCategories_button";
            this.showCategories_button.Size = new System.Drawing.Size(95, 26);
            this.showCategories_button.TabIndex = 16;
            this.showCategories_button.Text = "Categories";
            this.showCategories_button.UseVisualStyleBackColor = false;
            this.showCategories_button.Click += new System.EventHandler(this.showCategories_button_Click);
            // 
            // showSets_button
            // 
            this.showSets_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.showSets_button.Location = new System.Drawing.Point(475, 252);
            this.showSets_button.Name = "showSets_button";
            this.showSets_button.Size = new System.Drawing.Size(95, 26);
            this.showSets_button.TabIndex = 17;
            this.showSets_button.Text = "Sets";
            this.showSets_button.UseVisualStyleBackColor = false;
            this.showSets_button.Click += new System.EventHandler(this.showSets_button_Click);
            // 
            // DataViewerSecretary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 358);
            this.Controls.Add(this.showSets_button);
            this.Controls.Add(this.showCategories_button);
            this.Controls.Add(this.showGroup_button);
            this.Controls.Add(this.mainDataGridView);
            this.Controls.Add(this.Browse_button);
            this.Controls.Add(this.Path_textBox);
            this.Controls.Add(this.showParticipant_button);
            this.Controls.Add(this.showJudge_button);
            this.Controls.Add(this.showTournir_button);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.DataView_bindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataViewerSecretary";
            this.Text = "DataViewerSecretary";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DataViewerSecretary_FormClosing);
            this.Load += new System.EventHandler(this.DataViewerSecretary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mainDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView_bindingNavigator)).EndInit();
            this.DataView_bindingNavigator.ResumeLayout(false);
            this.DataView_bindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView mainDataGridView;
        private System.Windows.Forms.Button showJudge_button;
        private System.Windows.Forms.Button showTournir_button;
        private System.Windows.Forms.Button Update_button;
        private System.Windows.Forms.BindingNavigator DataView_bindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.Button showParticipant_button;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox Path_textBox;
        private System.Windows.Forms.Button Browse_button;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button showGroup_button;
        private System.Windows.Forms.Button showCategories_button;
        private System.Windows.Forms.Button showSets_button;
    }
}
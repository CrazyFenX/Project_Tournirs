namespace DataViewer_D_v._001
{
    partial class DataBasaViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataBasaViewer));
            this.dataGridView_sportsmen = new System.Windows.Forms.DataGridView();
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
            this.Update_button = new System.Windows.Forms.Button();
            this.sportmansTableAdapter = new DataViewer_D_v._001.BD1DataSetTableAdapters.SportmansTableAdapter();
            this.sportsmansTableAdapter = new DataViewer_D_v._001.PeopleDataSetTableAdapters.SportsmansTableAdapter();
            this.showSports_button = new System.Windows.Forms.Button();
            this.showTrainers_button = new System.Windows.Forms.Button();
            this.dataGridView_trainers = new System.Windows.Forms.DataGridView();
            this.trainersTableAdapter = new DataViewer_D_v._001.PeopleDataSetLastTableAdapters.TrainersTableAdapter();
            this.sportsmansTableAdapter1 = new DataViewer_D_v._001.PeopleDataSetLastLastTableAdapters.SportsmansTableAdapter();
            this.trainersTableAdapter1 = new DataViewer_D_v._001.PeopleDataSetLastLastTableAdapters.TrainersTableAdapter();
            this.sportsmansTableAdapter2 = new DataViewer_D_v._001.PeopleDataSetLastTableAdapters.SportsmansTableAdapter();
            this.peopleDataSetLastLast = new DataViewer_D_v._001.PeopleDataSetLastLast();
            this.sportsmansBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.номерКнижкиDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчествоDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.названиеКлубаDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.городDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.датаРожденияDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.спортивныйКлассDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.разрядDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.тренераDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trainersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.номерКнижкиDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.кодDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.фамилияDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.имяDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.отчествоDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sportsmen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView_bindingNavigator)).BeginInit();
            this.DataView_bindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_trainers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleDataSetLastLast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportsmansBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_sportsmen
            // 
            this.dataGridView_sportsmen.AutoGenerateColumns = false;
            this.dataGridView_sportsmen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_sportsmen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерКнижкиDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn,
            this.имяDataGridViewTextBoxColumn,
            this.отчествоDataGridViewTextBoxColumn,
            this.названиеКлубаDataGridViewTextBoxColumn,
            this.городDataGridViewTextBoxColumn,
            this.датаРожденияDataGridViewTextBoxColumn,
            this.спортивныйКлассDataGridViewTextBoxColumn,
            this.разрядDataGridViewTextBoxColumn,
            this.тренераDataGridViewTextBoxColumn});
            this.dataGridView_sportsmen.DataSource = this.sportsmansBindingSource;
            this.dataGridView_sportsmen.Location = new System.Drawing.Point(24, 30);
            this.dataGridView_sportsmen.Name = "dataGridView_sportsmen";
            this.dataGridView_sportsmen.RowHeadersWidth = 51;
            this.dataGridView_sportsmen.RowTemplate.Height = 24;
            this.dataGridView_sportsmen.Size = new System.Drawing.Size(790, 222);
            this.dataGridView_sportsmen.TabIndex = 0;
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
            this.DataView_bindingNavigator.Size = new System.Drawing.Size(839, 27);
            this.DataView_bindingNavigator.TabIndex = 1;
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
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(55, 28);
            this.bindingNavigatorCountItem.Text = "для {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorDeleteItem.Text = "Удалить";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Положение";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 27);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 31);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(29, 28);
            this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 31);
            // 
            // Update_button
            // 
            this.Update_button.Location = new System.Drawing.Point(681, 258);
            this.Update_button.Name = "Update_button";
            this.Update_button.Size = new System.Drawing.Size(133, 31);
            this.Update_button.TabIndex = 2;
            this.Update_button.Text = "Update";
            this.Update_button.UseVisualStyleBackColor = true;
            this.Update_button.Click += new System.EventHandler(this.Update_button_Click);
            // 
            // sportmansTableAdapter
            // 
            this.sportmansTableAdapter.ClearBeforeFill = true;
            // 
            // sportsmansTableAdapter
            // 
            this.sportsmansTableAdapter.ClearBeforeFill = true;
            // 
            // showSports_button
            // 
            this.showSports_button.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.showSports_button.Location = new System.Drawing.Point(24, 252);
            this.showSports_button.Name = "showSports_button";
            this.showSports_button.Size = new System.Drawing.Size(96, 26);
            this.showSports_button.TabIndex = 3;
            this.showSports_button.Text = "Sportsmen";
            this.showSports_button.UseVisualStyleBackColor = false;
            this.showSports_button.Click += new System.EventHandler(this.showSports_button_Click);
            // 
            // showTrainers_button
            // 
            this.showTrainers_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.showTrainers_button.Location = new System.Drawing.Point(119, 252);
            this.showTrainers_button.Name = "showTrainers_button";
            this.showTrainers_button.Size = new System.Drawing.Size(96, 26);
            this.showTrainers_button.TabIndex = 4;
            this.showTrainers_button.Text = "Trainers";
            this.showTrainers_button.UseVisualStyleBackColor = false;
            this.showTrainers_button.Click += new System.EventHandler(this.showTrainers_button_Click);
            // 
            // dataGridView_trainers
            // 
            this.dataGridView_trainers.AutoGenerateColumns = false;
            this.dataGridView_trainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_trainers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.номерКнижкиDataGridViewTextBoxColumn1,
            this.кодDataGridViewTextBoxColumn,
            this.фамилияDataGridViewTextBoxColumn1,
            this.имяDataGridViewTextBoxColumn1,
            this.отчествоDataGridViewTextBoxColumn1});
            this.dataGridView_trainers.DataSource = this.trainersBindingSource;
            this.dataGridView_trainers.Location = new System.Drawing.Point(24, 30);
            this.dataGridView_trainers.Name = "dataGridView_trainers";
            this.dataGridView_trainers.RowHeadersWidth = 51;
            this.dataGridView_trainers.RowTemplate.Height = 24;
            this.dataGridView_trainers.Size = new System.Drawing.Size(790, 222);
            this.dataGridView_trainers.TabIndex = 5;
            // 
            // trainersTableAdapter
            // 
            this.trainersTableAdapter.ClearBeforeFill = true;
            // 
            // sportsmansTableAdapter1
            // 
            this.sportsmansTableAdapter1.ClearBeforeFill = true;
            // 
            // trainersTableAdapter1
            // 
            this.trainersTableAdapter1.ClearBeforeFill = true;
            // 
            // sportsmansTableAdapter2
            // 
            this.sportsmansTableAdapter2.ClearBeforeFill = true;
            // 
            // peopleDataSetLastLast
            // 
            this.peopleDataSetLastLast.DataSetName = "PeopleDataSetLastLast";
            this.peopleDataSetLastLast.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sportsmansBindingSource
            // 
            this.sportsmansBindingSource.DataMember = "Sportsmans";
            this.sportsmansBindingSource.DataSource = this.peopleDataSetLastLast;
            // 
            // номерКнижкиDataGridViewTextBoxColumn
            // 
            this.номерКнижкиDataGridViewTextBoxColumn.DataPropertyName = "НомерКнижки";
            this.номерКнижкиDataGridViewTextBoxColumn.HeaderText = "НомерКнижки";
            this.номерКнижкиDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.номерКнижкиDataGridViewTextBoxColumn.Name = "номерКнижкиDataGridViewTextBoxColumn";
            this.номерКнижкиDataGridViewTextBoxColumn.Width = 125;
            // 
            // фамилияDataGridViewTextBoxColumn
            // 
            this.фамилияDataGridViewTextBoxColumn.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.фамилияDataGridViewTextBoxColumn.Name = "фамилияDataGridViewTextBoxColumn";
            this.фамилияDataGridViewTextBoxColumn.Width = 125;
            // 
            // имяDataGridViewTextBoxColumn
            // 
            this.имяDataGridViewTextBoxColumn.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.имяDataGridViewTextBoxColumn.Name = "имяDataGridViewTextBoxColumn";
            this.имяDataGridViewTextBoxColumn.Width = 125;
            // 
            // отчествоDataGridViewTextBoxColumn
            // 
            this.отчествоDataGridViewTextBoxColumn.DataPropertyName = "Отчество";
            this.отчествоDataGridViewTextBoxColumn.HeaderText = "Отчество";
            this.отчествоDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.отчествоDataGridViewTextBoxColumn.Name = "отчествоDataGridViewTextBoxColumn";
            this.отчествоDataGridViewTextBoxColumn.Width = 125;
            // 
            // названиеКлубаDataGridViewTextBoxColumn
            // 
            this.названиеКлубаDataGridViewTextBoxColumn.DataPropertyName = "НазваниеКлуба";
            this.названиеКлубаDataGridViewTextBoxColumn.HeaderText = "НазваниеКлуба";
            this.названиеКлубаDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.названиеКлубаDataGridViewTextBoxColumn.Name = "названиеКлубаDataGridViewTextBoxColumn";
            this.названиеКлубаDataGridViewTextBoxColumn.Width = 125;
            // 
            // городDataGridViewTextBoxColumn
            // 
            this.городDataGridViewTextBoxColumn.DataPropertyName = "Город";
            this.городDataGridViewTextBoxColumn.HeaderText = "Город";
            this.городDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.городDataGridViewTextBoxColumn.Name = "городDataGridViewTextBoxColumn";
            this.городDataGridViewTextBoxColumn.Width = 125;
            // 
            // датаРожденияDataGridViewTextBoxColumn
            // 
            this.датаРожденияDataGridViewTextBoxColumn.DataPropertyName = "ДатаРождения";
            this.датаРожденияDataGridViewTextBoxColumn.HeaderText = "ДатаРождения";
            this.датаРожденияDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.датаРожденияDataGridViewTextBoxColumn.Name = "датаРожденияDataGridViewTextBoxColumn";
            this.датаРожденияDataGridViewTextBoxColumn.Width = 125;
            // 
            // спортивныйКлассDataGridViewTextBoxColumn
            // 
            this.спортивныйКлассDataGridViewTextBoxColumn.DataPropertyName = "СпортивныйКласс";
            this.спортивныйКлассDataGridViewTextBoxColumn.HeaderText = "СпортивныйКласс";
            this.спортивныйКлассDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.спортивныйКлассDataGridViewTextBoxColumn.Name = "спортивныйКлассDataGridViewTextBoxColumn";
            this.спортивныйКлассDataGridViewTextBoxColumn.Width = 125;
            // 
            // разрядDataGridViewTextBoxColumn
            // 
            this.разрядDataGridViewTextBoxColumn.DataPropertyName = "Разряд";
            this.разрядDataGridViewTextBoxColumn.HeaderText = "Разряд";
            this.разрядDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.разрядDataGridViewTextBoxColumn.Name = "разрядDataGridViewTextBoxColumn";
            this.разрядDataGridViewTextBoxColumn.Width = 125;
            // 
            // тренераDataGridViewTextBoxColumn
            // 
            this.тренераDataGridViewTextBoxColumn.DataPropertyName = "Тренера";
            this.тренераDataGridViewTextBoxColumn.HeaderText = "Тренера";
            this.тренераDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.тренераDataGridViewTextBoxColumn.Name = "тренераDataGridViewTextBoxColumn";
            this.тренераDataGridViewTextBoxColumn.Width = 125;
            // 
            // trainersBindingSource
            // 
            this.trainersBindingSource.DataMember = "Trainers";
            this.trainersBindingSource.DataSource = this.peopleDataSetLastLast;
            // 
            // номерКнижкиDataGridViewTextBoxColumn1
            // 
            this.номерКнижкиDataGridViewTextBoxColumn1.DataPropertyName = "НомерКнижки";
            this.номерКнижкиDataGridViewTextBoxColumn1.HeaderText = "НомерКнижки";
            this.номерКнижкиDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.номерКнижкиDataGridViewTextBoxColumn1.Name = "номерКнижкиDataGridViewTextBoxColumn1";
            this.номерКнижкиDataGridViewTextBoxColumn1.Width = 125;
            // 
            // кодDataGridViewTextBoxColumn
            // 
            this.кодDataGridViewTextBoxColumn.DataPropertyName = "Код";
            this.кодDataGridViewTextBoxColumn.HeaderText = "Код";
            this.кодDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.кодDataGridViewTextBoxColumn.Name = "кодDataGridViewTextBoxColumn";
            this.кодDataGridViewTextBoxColumn.Width = 125;
            // 
            // фамилияDataGridViewTextBoxColumn1
            // 
            this.фамилияDataGridViewTextBoxColumn1.DataPropertyName = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn1.HeaderText = "Фамилия";
            this.фамилияDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.фамилияDataGridViewTextBoxColumn1.Name = "фамилияDataGridViewTextBoxColumn1";
            this.фамилияDataGridViewTextBoxColumn1.Width = 125;
            // 
            // имяDataGridViewTextBoxColumn1
            // 
            this.имяDataGridViewTextBoxColumn1.DataPropertyName = "Имя";
            this.имяDataGridViewTextBoxColumn1.HeaderText = "Имя";
            this.имяDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.имяDataGridViewTextBoxColumn1.Name = "имяDataGridViewTextBoxColumn1";
            this.имяDataGridViewTextBoxColumn1.Width = 125;
            // 
            // отчествоDataGridViewTextBoxColumn1
            // 
            this.отчествоDataGridViewTextBoxColumn1.DataPropertyName = "Отчество";
            this.отчествоDataGridViewTextBoxColumn1.HeaderText = "Отчество";
            this.отчествоDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.отчествоDataGridViewTextBoxColumn1.Name = "отчествоDataGridViewTextBoxColumn1";
            this.отчествоDataGridViewTextBoxColumn1.Width = 125;
            // 
            // DataBasaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 463);
            this.Controls.Add(this.dataGridView_sportsmen);
            this.Controls.Add(this.dataGridView_trainers);
            this.Controls.Add(this.showTrainers_button);
            this.Controls.Add(this.showSports_button);
            this.Controls.Add(this.Update_button);
            this.Controls.Add(this.DataView_bindingNavigator);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DataBasaViewer";
            this.Text = "DataBasaViewer";
            this.Load += new System.EventHandler(this.DataBasaViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_sportsmen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataView_bindingNavigator)).EndInit();
            this.DataView_bindingNavigator.ResumeLayout(false);
            this.DataView_bindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_trainers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.peopleDataSetLastLast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sportsmansBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trainersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_sportsmen;
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
        private System.Windows.Forms.Button Update_button;
        private BD1DataSetTableAdapters.SportmansTableAdapter sportmansTableAdapter;
        private PeopleDataSetTableAdapters.SportsmansTableAdapter sportsmansTableAdapter;
        private System.Windows.Forms.Button showSports_button;
        private System.Windows.Forms.Button showTrainers_button;
        private System.Windows.Forms.DataGridView dataGridView_trainers;
        private PeopleDataSetLastTableAdapters.TrainersTableAdapter trainersTableAdapter;
        private PeopleDataSetLastLastTableAdapters.SportsmansTableAdapter sportsmansTableAdapter1;
        private PeopleDataSetLastLastTableAdapters.TrainersTableAdapter trainersTableAdapter1;
        private PeopleDataSetLastTableAdapters.SportsmansTableAdapter sportsmansTableAdapter2;
        private PeopleDataSetLastLast peopleDataSetLastLast;
        private System.Windows.Forms.BindingSource sportsmansBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерКнижкиDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn отчествоDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn названиеКлубаDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn городDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn датаРожденияDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn спортивныйКлассDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn разрядDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn тренераDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource trainersBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn номерКнижкиDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn кодDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn фамилияDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn имяDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn отчествоDataGridViewTextBoxColumn1;
    }
}
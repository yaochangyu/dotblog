namespace Simple.BindingSourceEF.UI
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Account_DataGridView = new System.Windows.Forms.DataGridView();
            this.AccountLog_DataGridView = new System.Windows.Forms.DataGridView();
            this.AccountLog_BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem1 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem1 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem1 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.Account_BindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.Account_BindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Account_BindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.Account_BindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lastLoginTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountLog_BindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Account_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLog_DataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLog_BindingNavigator)).BeginInit();
            this.AccountLog_BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Account_BindingNavigator)).BeginInit();
            this.Account_BindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Account_BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLog_BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.Controls.Add(this.Account_DataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.AccountLog_DataGridView);
            this.splitContainer1.Panel2.Controls.Add(this.AccountLog_BindingNavigator);
            this.splitContainer1.Size = new System.Drawing.Size(561, 375);
            this.splitContainer1.SplitterDistance = 187;
            this.splitContainer1.TabIndex = 1;
            // 
            // Account_DataGridView
            // 
            this.Account_DataGridView.AllowUserToAddRows = false;
            this.Account_DataGridView.AutoGenerateColumns = false;
            this.Account_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Account_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.Account_DataGridView.DataSource = this.Account_BindingSource;
            this.Account_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Account_DataGridView.Location = new System.Drawing.Point(0, 0);
            this.Account_DataGridView.Name = "Account_DataGridView";
            this.Account_DataGridView.Size = new System.Drawing.Size(561, 187);
            this.Account_DataGridView.TabIndex = 2;
            // 
            // AccountLog_DataGridView
            // 
            this.AccountLog_DataGridView.AllowUserToAddRows = false;
            this.AccountLog_DataGridView.AutoGenerateColumns = false;
            this.AccountLog_DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountLog_DataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lastLoginTimeDataGridViewTextBoxColumn});
            this.AccountLog_DataGridView.DataSource = this.AccountLog_BindingSource;
            this.AccountLog_DataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccountLog_DataGridView.Location = new System.Drawing.Point(0, 25);
            this.AccountLog_DataGridView.Name = "AccountLog_DataGridView";
            this.AccountLog_DataGridView.Size = new System.Drawing.Size(561, 159);
            this.AccountLog_DataGridView.TabIndex = 2;
            // 
            // AccountLog_BindingNavigator
            // 
            this.AccountLog_BindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.AccountLog_BindingNavigator.BindingSource = this.AccountLog_BindingSource;
            this.AccountLog_BindingNavigator.CountItem = this.bindingNavigatorCountItem1;
            this.AccountLog_BindingNavigator.DeleteItem = null;
            this.AccountLog_BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem1,
            this.bindingNavigatorMovePreviousItem1,
            this.bindingNavigatorSeparator3,
            this.bindingNavigatorPositionItem1,
            this.bindingNavigatorCountItem1,
            this.bindingNavigatorSeparator4,
            this.bindingNavigatorMoveNextItem1,
            this.bindingNavigatorMoveLastItem1,
            this.bindingNavigatorSeparator5,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem});
            this.AccountLog_BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.AccountLog_BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem1;
            this.AccountLog_BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem1;
            this.AccountLog_BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem1;
            this.AccountLog_BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem1;
            this.AccountLog_BindingNavigator.Name = "AccountLog_BindingNavigator";
            this.AccountLog_BindingNavigator.PositionItem = this.bindingNavigatorPositionItem1;
            this.AccountLog_BindingNavigator.Size = new System.Drawing.Size(561, 25);
            this.AccountLog_BindingNavigator.TabIndex = 1;
            this.AccountLog_BindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem1
            // 
            this.bindingNavigatorCountItem1.Name = "bindingNavigatorCountItem1";
            this.bindingNavigatorCountItem1.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem1.Text = "of {0}";
            this.bindingNavigatorCountItem1.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem1
            // 
            this.bindingNavigatorMoveFirstItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem1.Image")));
            this.bindingNavigatorMoveFirstItem1.Name = "bindingNavigatorMoveFirstItem1";
            this.bindingNavigatorMoveFirstItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem1.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem1
            // 
            this.bindingNavigatorMovePreviousItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem1.Image")));
            this.bindingNavigatorMovePreviousItem1.Name = "bindingNavigatorMovePreviousItem1";
            this.bindingNavigatorMovePreviousItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem1.Text = "Move previous";
            // 
            // bindingNavigatorSeparator3
            // 
            this.bindingNavigatorSeparator3.Name = "bindingNavigatorSeparator3";
            this.bindingNavigatorSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem1
            // 
            this.bindingNavigatorPositionItem1.AccessibleName = "Position";
            this.bindingNavigatorPositionItem1.AutoSize = false;
            this.bindingNavigatorPositionItem1.Name = "bindingNavigatorPositionItem1";
            this.bindingNavigatorPositionItem1.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem1.Text = "0";
            this.bindingNavigatorPositionItem1.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator4
            // 
            this.bindingNavigatorSeparator4.Name = "bindingNavigatorSeparator4";
            this.bindingNavigatorSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem1
            // 
            this.bindingNavigatorMoveNextItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem1.Image")));
            this.bindingNavigatorMoveNextItem1.Name = "bindingNavigatorMoveNextItem1";
            this.bindingNavigatorMoveNextItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem1.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem1
            // 
            this.bindingNavigatorMoveLastItem1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem1.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem1.Image")));
            this.bindingNavigatorMoveLastItem1.Name = "bindingNavigatorMoveLastItem1";
            this.bindingNavigatorMoveLastItem1.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem1.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem1.Text = "Move last";
            // 
            // bindingNavigatorSeparator5
            // 
            this.bindingNavigatorSeparator5.Name = "bindingNavigatorSeparator5";
            this.bindingNavigatorSeparator5.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // Account_BindingNavigator
            // 
            this.Account_BindingNavigator.AddNewItem = this.Account_BindingNavigatorAddNewItem;
            this.Account_BindingNavigator.BindingSource = this.Account_BindingSource;
            this.Account_BindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.Account_BindingNavigator.DeleteItem = null;
            this.Account_BindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.Account_BindingNavigatorAddNewItem,
            this.Account_BindingNavigatorDeleteItem,
            this.Account_BindingNavigatorSaveItem});
            this.Account_BindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.Account_BindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.Account_BindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.Account_BindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.Account_BindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.Account_BindingNavigator.Name = "Account_BindingNavigator";
            this.Account_BindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.Account_BindingNavigator.Size = new System.Drawing.Size(561, 25);
            this.Account_BindingNavigator.TabIndex = 3;
            this.Account_BindingNavigator.Text = "bindingNavigator1";
            // 
            // Account_BindingNavigatorAddNewItem
            // 
            this.Account_BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Account_BindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("Account_BindingNavigatorAddNewItem.Image")));
            this.Account_BindingNavigatorAddNewItem.Name = "Account_BindingNavigatorAddNewItem";
            this.Account_BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.Account_BindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.Account_BindingNavigatorAddNewItem.Text = "Add new";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // Account_BindingNavigatorDeleteItem
            // 
            this.Account_BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Account_BindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("Account_BindingNavigatorDeleteItem.Image")));
            this.Account_BindingNavigatorDeleteItem.Name = "Account_BindingNavigatorDeleteItem";
            this.Account_BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.Account_BindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.Account_BindingNavigatorDeleteItem.Text = "Delete";
            this.Account_BindingNavigatorDeleteItem.Click += new System.EventHandler(this.Account_BindingNavigatorDeleteItem_Click);
            // 
            // Account_BindingNavigatorSaveItem
            // 
            this.Account_BindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Account_BindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("Account_BindingNavigatorSaveItem.Image")));
            this.Account_BindingNavigatorSaveItem.Name = "Account_BindingNavigatorSaveItem";
            this.Account_BindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.Account_BindingNavigatorSaveItem.Text = "Save Data";
            this.Account_BindingNavigatorSaveItem.Click += new System.EventHandler(this.Account_BindingNavigatorSaveItem_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "UserId";
            this.dataGridViewTextBoxColumn1.HeaderText = "UserId";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Password";
            this.dataGridViewTextBoxColumn2.HeaderText = "Password";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Account_BindingSource
            // 
            this.Account_BindingSource.DataSource = typeof(Simple.BindingSourceEF.DAL.Model.Account);
            this.Account_BindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.Account_BindingSource_AddingNew);
            // 
            // lastLoginTimeDataGridViewTextBoxColumn
            // 
            this.lastLoginTimeDataGridViewTextBoxColumn.DataPropertyName = "LastLoginTime";
            this.lastLoginTimeDataGridViewTextBoxColumn.HeaderText = "LastLoginTime";
            this.lastLoginTimeDataGridViewTextBoxColumn.Name = "lastLoginTimeDataGridViewTextBoxColumn";
            // 
            // AccountLog_BindingSource
            // 
            this.AccountLog_BindingSource.DataSource = typeof(Simple.BindingSourceEF.DAL.Model.AccountLog);
            this.AccountLog_BindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.AccountLog_BindingSource_AddingNew);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 400);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.Account_BindingNavigator);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Account_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLog_DataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLog_BindingNavigator)).EndInit();
            this.AccountLog_BindingNavigator.ResumeLayout(false);
            this.AccountLog_BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Account_BindingNavigator)).EndInit();
            this.Account_BindingNavigator.ResumeLayout(false);
            this.Account_BindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Account_BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccountLog_BindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountLogsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource Account_BindingSource;
        private System.Windows.Forms.DataGridView Account_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.BindingNavigator Account_BindingNavigator;
        private System.Windows.Forms.ToolStripButton Account_BindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton Account_BindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton Account_BindingNavigatorSaveItem;
        private System.Windows.Forms.DataGridView AccountLog_DataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource AccountLog_BindingSource;
        private System.Windows.Forms.BindingNavigator AccountLog_BindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator3;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator4;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem1;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator5;
        private System.Windows.Forms.DataGridViewTextBoxColumn lastLoginTimeDataGridViewTextBoxColumn;
    }
}


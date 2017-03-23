using UI.Extension;

namespace UI
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.Detail_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAge2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthday2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.QueryResult_GridControl = new DevExpress.XtraGrid.GridControl();
            this.memberViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            //this.Master_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Master_GridView = new GridViewEx();

            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAge = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthday = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSequentialId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMemberId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAge1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBirthday1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserId1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.PagingControl = new UI.Extension.PagingControl();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_GridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryResult_GridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Master_GridView)).BeginInit();
            this.SuspendLayout();
            //
            // Detail_GridView
            //
            this.Detail_GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId2,
            this.colMemberId1,
            this.colAge2,
            this.colName2,
            this.colBirthday2,
            this.colUserId2});
            this.Detail_GridView.GridControl = this.QueryResult_GridControl;
            this.Detail_GridView.Name = "Detail_GridView";
            //
            // colId2
            //
            this.colId2.FieldName = "Id";
            this.colId2.Name = "colId2";
            this.colId2.Visible = true;
            this.colId2.VisibleIndex = 0;
            //
            // colMemberId1
            //
            this.colMemberId1.FieldName = "MemberId";
            this.colMemberId1.Name = "colMemberId1";
            this.colMemberId1.Visible = true;
            this.colMemberId1.VisibleIndex = 1;
            //
            // colAge2
            //
            this.colAge2.FieldName = "Age";
            this.colAge2.Name = "colAge2";
            this.colAge2.Visible = true;
            this.colAge2.VisibleIndex = 2;
            //
            // colName2
            //
            this.colName2.FieldName = "Name";
            this.colName2.Name = "colName2";
            this.colName2.Visible = true;
            this.colName2.VisibleIndex = 3;
            //
            // colBirthday2
            //
            this.colBirthday2.FieldName = "Birthday";
            this.colBirthday2.Name = "colBirthday2";
            this.colBirthday2.Visible = true;
            this.colBirthday2.VisibleIndex = 4;
            //
            // colUserId2
            //
            this.colUserId2.FieldName = "UserId";
            this.colUserId2.Name = "colUserId2";
            this.colUserId2.Visible = true;
            this.colUserId2.VisibleIndex = 5;
            //
            // QueryResult_GridControl
            //
            this.QueryResult_GridControl.DataSource = this.memberViewModelBindingSource;
            this.QueryResult_GridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.Detail_GridView;
            gridLevelNode1.RelationName = "MemberLogs";
            this.QueryResult_GridControl.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.QueryResult_GridControl.Location = new System.Drawing.Point(0, 0);
            this.QueryResult_GridControl.MainView = this.Master_GridView;
            this.QueryResult_GridControl.Name = "QueryResult_GridControl";
            this.QueryResult_GridControl.Size = new System.Drawing.Size(712, 405);
            this.QueryResult_GridControl.TabIndex = 0;
            this.QueryResult_GridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Master_GridView,
            this.Detail_GridView});
            //
            // memberViewModelBindingSource
            //
            this.memberViewModelBindingSource.DataSource = typeof(Infrastructure.MemberViewModel);
            //
            // Master_GridView
            //
            this.Master_GridView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colAge,
            this.colName,
            this.colBirthday,
            this.colUserId,
            this.colSequentialId});
            this.Master_GridView.GridControl = this.QueryResult_GridControl;
            this.Master_GridView.Name = "Master_GridView";
            //
            // colId
            //
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            //
            // colAge
            //
            this.colAge.FieldName = "Age";
            this.colAge.Name = "colAge";
            this.colAge.Visible = true;
            this.colAge.VisibleIndex = 1;
            //
            // colName
            //
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 2;
            //
            // colBirthday
            //
            this.colBirthday.FieldName = "Birthday";
            this.colBirthday.Name = "colBirthday";
            this.colBirthday.Visible = true;
            this.colBirthday.VisibleIndex = 3;
            //
            // colUserId
            //
            this.colUserId.FieldName = "UserId";
            this.colUserId.Name = "colUserId";
            this.colUserId.Visible = true;
            this.colUserId.VisibleIndex = 4;
            //
            // colSequentialId
            //
            this.colSequentialId.FieldName = "SequentialId";
            this.colSequentialId.Name = "colSequentialId";
            this.colSequentialId.Visible = true;
            this.colSequentialId.VisibleIndex = 5;
            //
            // colId1
            //
            this.colId1.FieldName = "Id";
            this.colId1.Name = "colId1";
            this.colId1.Visible = true;
            this.colId1.VisibleIndex = 0;
            //
            // colMemberId
            //
            this.colMemberId.FieldName = "MemberId";
            this.colMemberId.Name = "colMemberId";
            this.colMemberId.Visible = true;
            this.colMemberId.VisibleIndex = 1;
            //
            // colAge1
            //
            this.colAge1.FieldName = "Age";
            this.colAge1.Name = "colAge1";
            this.colAge1.Visible = true;
            this.colAge1.VisibleIndex = 2;
            //
            // colName1
            //
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 3;
            //
            // colBirthday1
            //
            this.colBirthday1.FieldName = "Birthday";
            this.colBirthday1.Name = "colBirthday1";
            this.colBirthday1.Visible = true;
            this.colBirthday1.VisibleIndex = 4;
            //
            // colUserId1
            //
            this.colUserId1.FieldName = "UserId";
            this.colUserId1.Name = "colUserId1";
            this.colUserId1.Visible = true;
            this.colUserId1.VisibleIndex = 5;
            //
            // PagingControl
            //
            this.PagingControl.AutoSize = true;
            this.PagingControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PagingControl.Location = new System.Drawing.Point(0, 405);
            this.PagingControl.Name = "PagingControl";
            this.PagingControl.Page = null;
            this.PagingControl.Size = new System.Drawing.Size(712, 25);
            this.PagingControl.TabIndex = 1;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 430);
            this.Controls.Add(this.QueryResult_GridControl);
            this.Controls.Add(this.PagingControl);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Detail_GridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QueryResult_GridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.memberViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Master_GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl QueryResult_GridControl;
        //private DevExpress.XtraGrid.Views.Grid.GridView Master_GridView;
        private UI.Extension.GridViewEx Master_GridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId1;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberId;
        private DevExpress.XtraGrid.Columns.GridColumn colAge1;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthday1;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId1;
        private Extension.PagingControl PagingControl;
        private System.Windows.Forms.BindingSource memberViewModelBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView Detail_GridView;
        private DevExpress.XtraGrid.Columns.GridColumn colId2;
        private DevExpress.XtraGrid.Columns.GridColumn colMemberId1;
        private DevExpress.XtraGrid.Columns.GridColumn colAge2;
        private DevExpress.XtraGrid.Columns.GridColumn colName2;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthday2;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId2;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colAge;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colBirthday;
        private DevExpress.XtraGrid.Columns.GridColumn colUserId;
        private DevExpress.XtraGrid.Columns.GridColumn colSequentialId;
    }
}


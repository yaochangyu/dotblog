namespace UI.Extension
{
    partial class PagingControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PagingControl_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.FirstPage_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PreviousPage_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PageIndex_ToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.NextPage_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.LastPage_ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.PagingControl_ToolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // PagingControl_ToolStrip
            // 
            this.PagingControl_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FirstPage_ToolStripButton,
            this.PreviousPage_ToolStripButton,
            this.PageIndex_ToolStripLabel,
            this.NextPage_ToolStripButton,
            this.LastPage_ToolStripButton});
            this.PagingControl_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.PagingControl_ToolStrip.Name = "PagingControl_ToolStrip";
            this.PagingControl_ToolStrip.Size = new System.Drawing.Size(469, 25);
            this.PagingControl_ToolStrip.TabIndex = 2;
            this.PagingControl_ToolStrip.Text = "toolStrip1";
            // 
            // FirstPage_ToolStripButton
            // 
            this.FirstPage_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FirstPage_ToolStripButton.Name = "FirstPage_ToolStripButton";
            this.FirstPage_ToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.FirstPage_ToolStripButton.Text = "第一頁";
            this.FirstPage_ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.FirstPage_ToolStripButton.Click += new System.EventHandler(this.FirstPage_ToolStripButton_Click);
            // 
            // PreviousPage_ToolStripButton
            // 
            this.PreviousPage_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.PreviousPage_ToolStripButton.Name = "PreviousPage_ToolStripButton";
            this.PreviousPage_ToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.PreviousPage_ToolStripButton.Text = "上一頁";
            this.PreviousPage_ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.PreviousPage_ToolStripButton.Click += new System.EventHandler(this.PreviousPage_ToolStripButton_Click);
            // 
            // PageIndex_ToolStripLabel
            // 
            this.PageIndex_ToolStripLabel.Name = "PageIndex_ToolStripLabel";
            this.PageIndex_ToolStripLabel.Size = new System.Drawing.Size(46, 22);
            this.PageIndex_ToolStripLabel.Text = "{0}/{1}..";
            // 
            // NextPage_ToolStripButton
            // 
            this.NextPage_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextPage_ToolStripButton.Name = "NextPage_ToolStripButton";
            this.NextPage_ToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.NextPage_ToolStripButton.Text = "下一頁";
            this.NextPage_ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NextPage_ToolStripButton.Click += new System.EventHandler(this.NextPage_ToolStripButton_Click);
            // 
            // LastPage_ToolStripButton
            // 
            this.LastPage_ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LastPage_ToolStripButton.Name = "LastPage_ToolStripButton";
            this.LastPage_ToolStripButton.Size = new System.Drawing.Size(63, 22);
            this.LastPage_ToolStripButton.Text = "最後一頁";
            this.LastPage_ToolStripButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.LastPage_ToolStripButton.Click += new System.EventHandler(this.LastPage_ToolStripButton_Click);
            // 
            // PagingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.PagingControl_ToolStrip);
            this.DoubleBuffered = true;
            this.Name = "PagingControl";
            this.Size = new System.Drawing.Size(469, 80);
            this.PagingControl_ToolStrip.ResumeLayout(false);
            this.PagingControl_ToolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip PagingControl_ToolStrip;
        private System.Windows.Forms.ToolStripButton FirstPage_ToolStripButton;
        private System.Windows.Forms.ToolStripButton PreviousPage_ToolStripButton;
        private System.Windows.Forms.ToolStripLabel PageIndex_ToolStripLabel;
        private System.Windows.Forms.ToolStripButton NextPage_ToolStripButton;
        private System.Windows.Forms.ToolStripButton LastPage_ToolStripButton;
    }

}

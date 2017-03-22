using System;
using System.ComponentModel;
using System.Windows.Forms;
using Infrastructure;

namespace UI.Extension
{
    public partial class PagingControl : UserControl
    {
        public PagingControl()
        {
            this.InitializeComponent();
        }

        [Browsable(false)]
        public Page Page { get; set; }

        public event EventHandler<PagingChangedEventArgs> PagingChanged;

        public void UpdateControl()
        {
            var page = this.Page;
            var toolStrip = this.PagingControl_ToolStrip;

            toolStrip.Items["PageIndex_ToolStripLabel"].Text = page.PageIndexInfo;
            toolStrip.Items["LastPage_ToolStripButton"].Enabled = !page.IsLastPage;
            toolStrip.Items["NextPage_ToolStripButton"].Enabled = !page.IsLastPage;

            toolStrip.Items["PreviousPage_ToolStripButton"].Enabled = !page.IsFirstPage;
            toolStrip.Items["FirstPage_ToolStripButton"].Enabled = !page.IsFirstPage;
        }

        private void Execute(EnumPageMode pageType, EventHandler<PagingChangedEventArgs> eventHandler)
        {
            var paging = this.Page;

            this.MoveIndex(paging, pageType);
            this.NotifySubscriber(paging, pageType, eventHandler);
            this.UpdateControl();
        }

        private void FirstPage_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Execute(EnumPageMode.FirstPage, this.PagingChanged);
        }

        private void LastPage_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Execute(EnumPageMode.LastPage, this.PagingChanged);
        }

        private void MoveIndex(Page page, EnumPageMode pageMode)
        {
            switch (pageMode)
            {
                case EnumPageMode.NextPage:
                    page.NextPageIndex();
                    break;

                case EnumPageMode.PreviousPage:
                    page.PreviousPageIndex();
                    break;

                case EnumPageMode.FirstPage:
                    page.FirstPageIndex();
                    break;

                case EnumPageMode.LastPage:
                    page.LastPageIndex();
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(pageMode), pageMode, null);
            }
        }

        private void NextPage_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Execute(EnumPageMode.NextPage, this.PagingChanged);
        }

        private void NotifySubscriber(Page page,
                                      EnumPageMode pageMode,
                                      EventHandler<PagingChangedEventArgs> eventHandler)
        {
            if (eventHandler != null)
            {
                eventHandler.Invoke(this, new PagingChangedEventArgs
                {
                    Page = page,
                    PagingMode = pageMode
                });
            }
        }

        private void PreviousPage_ToolStripButton_Click(object sender, EventArgs e)
        {
            this.Execute(EnumPageMode.PreviousPage, this.PagingChanged);
        }
    }
}
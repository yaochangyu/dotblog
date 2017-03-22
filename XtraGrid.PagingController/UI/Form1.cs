using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using Infrastructure;
using UI.Extension;

namespace UI
{
    public partial class Form1 : Form
    {
        private MemberBLL _bll;

        private BindingSource _queryResultBindingSource;
        private List<MemberViewModel> _queryResults;

        public Form1()
        {
            this.InitializeComponent();
            this.InitializeInstance();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this._queryResults = new List<MemberViewModel>(this._bll.GetMasters(this.PagingControl.Page).ToList());
            this._queryResultBindingSource.DataSource = this._queryResults;
            this.PagingControl.UpdateControl();
        }

        private void InitializeInstance()
        {
            this.PagingControl.Page = new Page
            {
                PageIndex = 0,
                RowSize = 10,
                SortExpression = "SequentialId Asc"
            };

            if (this._bll == null)
            {
                this._bll = new MemberBLL();
            }

            if (this._queryResultBindingSource == null)
            {
                this._queryResultBindingSource = new BindingSource();
            }

            this.QueryResult_GridControl.DataSource = this._queryResultBindingSource;
            this._queryResultBindingSource.PositionChanged += this.QueryResult_BindingSource_PositionChanged;

            this.PagingControl.PagingChanged += this.PagingControl_PagingChanged;
        }

        private void PagingControl_PagingChanged(object sender, PagingChangedEventArgs e)
        {
            this._queryResults = new List<MemberViewModel>(this._bll.GetMasters(this.PagingControl.Page).ToList());
            this._queryResultBindingSource.DataSource = this._queryResults;
            this.PagingControl.UpdateControl();
        }

        private void QueryResult_BindingSource_PositionChanged(object sender, EventArgs e)
        {
            var source = (BindingSource) sender;
            if (source.Position != this._queryResults.Count - 1)
            {
                return;
            }

            if (this.PagingControl.Page.TotalCount == this._queryResults.Count)
            {
                return;
            }

            this.PagingControl.Page.PageIndex++;
            var queryResult = this._bll.GetMasters(this.PagingControl.Page);
            foreach (var item in queryResult)
            {
                this._queryResults.Add(item);
            }

            this.Master_GridView.RefreshData();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.Data;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpressEx;
using Infrastructure;
using UI.Extension;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly string _defaultField = "SequentialId";
        private MemberBLL _bll;
        private bool _isRebind;

        private BindingSource _queryResultBindingSource;
        private List<MemberViewModel> _queryResults;

        public Form1()
        {
            this.InitializeComponent();
            this.InitializeInstance();

            //this.Master_GridView.EndSorting += this.Master_GridView_EndSorting;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.GetMasters();

            this.SetSortOnGridView();

            this.Master_GridView.StartSorting += this.Master_GridView_StartSorting;
        }

        private void SetSortOnGridView()
        {
            var sortInfo = new GridColumnSortInfo(this.Master_GridView.Columns[this._defaultField],
                                                  ColumnSortOrder.Ascending);
            this.Master_GridView.SortInfo.Add(sortInfo);
        }

        private void GetMasters()
        {
            if (string.IsNullOrWhiteSpace(this.PagingControl.Page.SortExpression))
            {
                var defaultFiledAndSort = this._defaultField + " Asc";
                this.PagingControl.Page.SortExpression = this.Master_GridView.GetSortExpression(defaultFiledAndSort);
            }
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

            this.Master_GridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.PagingControl.PagingChanged += this.PagingControl_PagingChanged;
            this.Master_GridView.MasterRowExpanding += this.Master_GridView_MasterRowExpanding;
        }

        private void Master_GridView_StartSorting(object sender, EventArgs e)
        {
            if (this._isRebind)
            {
                return;
            }

            this._isRebind = true;
            this.GetMasters();
            this._isRebind = false;
        }

        

        private void Master_GridView_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var master = this._queryResultBindingSource.Current as MemberViewModel;
            var details = this._bll.GetDetails(master.Id).ToList();
            master.MemberLogs = details;
        }

        private void PagingControl_PagingChanged(object sender, PagingChangedEventArgs e)
        {
            if (this._isRebind)
            {
                return;
            }

            this._isRebind = true;
            this.GetMasters();
            this._isRebind = false;
        }
    }
}
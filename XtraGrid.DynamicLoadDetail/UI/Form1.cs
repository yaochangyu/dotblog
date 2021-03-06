﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.XtraGrid.Views.Grid;
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
            this.PagingControl.PagingChanged += this.PagingControl_PagingChanged;

            this.Master_GridView.OptionsDetail.AllowExpandEmptyDetails = true;
            this.Master_GridView.MasterRowExpanding += this.Master_GridView_MasterRowExpanding;

        }

        private void Master_GridView_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var master = this._queryResultBindingSource.Current as MemberViewModel;
            var details = this._bll.GetDetails(master.Id).ToList();
            master.MemberLogs = details;
        }

        private void PagingControl_PagingChanged(object sender, PagingChangedEventArgs e)
        {
            this._queryResults = new List<MemberViewModel>(this._bll.GetMasters(this.PagingControl.Page).ToList());
            this._queryResultBindingSource.DataSource = this._queryResults;
            this.PagingControl.UpdateControl();
        }
    }
}
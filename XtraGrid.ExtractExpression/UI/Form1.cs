﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using BLL;
using DevExpress.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpressEx;
using Infrastructure;
using UI.Extension;
using PopupMenuShowingEventArgs = DevExpress.XtraEditors.Filtering.PopupMenuShowingEventArgs;

namespace UI
{
    public partial class Form1 : Form
    {
        private readonly string _defaultField = "SequentialId";
        private MemberBLL _bll;
        private bool _isBinding;

        private BindingSource _queryResultBindingSource;
        private List<MemberViewModel> _queryResults;

        public Form1()
        {
            this.InitializeComponent();
            this.InitializeInstance();
        }

        private void BindingOnMasterView()
        {
            if (this._isBinding)
            {
                return;
            }

            this._isBinding = true;

            var defaultFiledAndSort = this._defaultField + " Asc";
            this.PagingControl.Page.SortExpression = this.Master_GridView.GetSortExpression(defaultFiledAndSort);

            this.PagingControl.Page.FilterExpression = this.Master_GridView.GetFilterExpression();

            this._queryResults = new List<MemberViewModel>(this._bll.GetMasters(this.PagingControl.Page).ToList());
            this._queryResultBindingSource.DataSource = this._queryResults;
            this.PagingControl.UpdateControl();

            this._isBinding = false;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            //this.Master_GridView.Columns["Name"].OptionsFilter.FilterPopupMode = FilterPopupMode.Excel;

            foreach (var column in this.Master_GridView.Columns.Cast<GridColumn>())
            {
                column.OptionsFilter.FilterPopupMode = FilterPopupMode.Excel;
            }
        }

        private void FilterControl_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.MenuType == FilterControlMenuType.Clause)
            {
                for (var i = e.Menu.Items.Count - 1; i >= 0; i--)
                {
                    if (e.Menu.Items[i].Caption == Localizer.Active.GetLocalizedString(StringId.FilterClauseLike) ||
                        e.Menu.Items[i].Caption == Localizer.Active.GetLocalizedString(StringId.FilterClauseNotLike))
                    {
                        e.Menu.Items.RemoveAt(i);
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BindingOnMasterView();
            this.SetSortOnMasterView();
            this.Master_GridView.ColumnFilterChanged += this.Master_GridView_ColumnFilterChanged;

            this.Master_GridView.ColumnSortInfoCollectionChanged += this.Master_GridView_ColumnSortInfoCollectionChanged;
        }

        private void Master_GridView_ColumnSortInfoCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            this.BindingOnMasterView();
        }

        private void InitializeInstance()
        {
            this.PagingControl.Page = new Page
            {
                PageIndex = 0,
                RowSize = 10
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

            this.Master_GridView.MasterRowExpanding += this.Master_GridView_MasterRowExpanding;
            this.Master_GridView.CustomFilterDialog += this.Master_GridView_CustomFilterDialog;
            this.Master_GridView.FilterEditorCreated += this.Master_GridView_FilterEditorCreated;

            this.PagingControl.PagingChanged += this.PagingControl_PagingChanged;
        }

        private void Master_GridView_ColumnFilterChanged(object sender, EventArgs e)
        {
            this.BindingOnMasterView();
        }

        private void Master_GridView_CustomFilterDialog(object sender, CustomFilterDialogEventArgs e)
        {
            var view = (GridView) sender;
            e.Handled = true;
            view.ShowFilterEditor(e.Column);
        }

        private void Master_GridView_FilterEditorCreated(object sender, FilterControlEventArgs e)
        {
            e.FilterControl.PopupMenuShowing += this.FilterControl_PopupMenuShowing;
        }

        private void Master_GridView_MasterRowExpanding(object sender, MasterRowCanExpandEventArgs e)
        {
            var master = this._queryResultBindingSource.Current as MemberViewModel;
            var details = this._bll.GetDetails(master.Id).ToList();
            master.MemberLogs = details;
        }

        private void PagingControl_PagingChanged(object sender, PagingChangedEventArgs e)
        {
            this.BindingOnMasterView();
        }

        private void SetSortOnMasterView()
        {
            var sortInfo = new GridColumnSortInfo(this.Master_GridView.Columns[this._defaultField],
                                                  ColumnSortOrder.Ascending);
            this.Master_GridView.SortInfo.Add(sortInfo);
        }
    }
}
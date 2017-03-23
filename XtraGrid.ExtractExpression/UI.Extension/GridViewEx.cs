using System;
using System.ComponentModel;
using DevExpress.XtraGrid.Views.Grid;

namespace UI.Extension
{
    public class GridViewEx : GridView
    {
        public event EventHandler<CollectionChangeEventArgs> ColumnSortInfoCollectionChanged;

        protected override void OnColumnSortInfoCollectionChanged(CollectionChangeEventArgs e)
        {
            base.OnColumnSortInfoCollectionChanged(e);
            if (this.ColumnSortInfoCollectionChanged == null)
            {
                return;
            }

            this.ColumnSortInfoCollectionChanged(this, e);
        }
    }
}
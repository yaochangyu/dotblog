using Simple.RadGridSortAndPaging.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Simple.RadGridSortAndPaging.Views
{
    public partial class RadGridCommandArgument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            if (!e.IsFromDetailTable)
            {
                var radGrid = (RadGrid)sender;

                var where1 = RadGridHelper.GetFilterExpression(radGrid.MasterTableView, null);
                var orderBy1 = RadGridHelper.GetOrderBy(radGrid.MasterTableView);
                var filter = radGrid.MasterTableView.FilterExpression;
                var orderBy = radGrid.MasterTableView.SortExpressions.GetSortString();

                var skip = radGrid.MasterTableView.CurrentPageIndex * radGrid.MasterTableView.PageSize;
                var take = radGrid.MasterTableView.PageSize;
                var totalRowCount = 0;
                radGrid.DataSource = GetAllOrders(skip, take, orderBy, filter, out totalRowCount);

                if (e.RebindReason == GridRebindReason.InitialLoad
                     || e.RebindReason == GridRebindReason.ExplicitRebind)
                {
                    radGrid.VirtualItemCount = totalRowCount;
                }
            }
        }

        public IEnumerable<Orders> GetAllOrders(
           int startRowIndex, int maximumRows, string sortExpression, string filterExpression, out int totalRowCount)
        {
            if (string.IsNullOrWhiteSpace(sortExpression))
            {
                sortExpression = "OrderID ASC";
            }
            NorthwindDbContext dbContext = new NorthwindDbContext();

            var query = dbContext.Orders.OrderBy(sortExpression);

            if (!string.IsNullOrWhiteSpace(filterExpression))
            {
                query = query.Where(filterExpression);
            }

            totalRowCount = query.Count();

            query = query.Skip(startRowIndex);
            query = query.Take(maximumRows);

            return query.AsNoTracking().ToList();
        }

        protected void RadGrid1_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "ReadCommand":

                    var args = e.CommandArgument;
                    var msg = string.Format("朕知道，你傳了參數:{0} 了", args);
                    this.RadAjaxManager1.Alert(msg);
                    break;
            }
        }

        private bool isAdd;

        protected void RadGrid1_ItemCreated(object sender, GridItemEventArgs e)
        {
            //if (e.Item is GridDataItem)
            //{
            //    GridDataItem item = (GridDataItem)e.Item;
            //    RadButton button = (RadButton)item.FindControl("ReadRecord_RadButton");
            //    //button.Attributes.Add("onblur", string.Format("Read({0},{1},{2})", button, null, e.Item.ItemIndex));
            //    if (!isAdd)
            //    {
            //        button.Attributes.Add("onblur", string.Format("Read({0})", e.Item.ItemIndex));
            //        isAdd = true;
            //    }
            //}
        }
    }
}
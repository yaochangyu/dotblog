using Simple.RadGridPaging.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Web.UI;
using Telerik.Web.UI;

public partial class Default : System.Web.UI.Page
{
    private NorthwindDbContext _db = null;

    private static string[] chars = new[] { "DateTime.Parse(\"", "\")" };

    public Default()
    {
        if (this._db == null)
        {
            this._db = new NorthwindDbContext();
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void RadGrid1_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
    {
        if (!e.IsFromDetailTable)
        {
            var radGrid = (RadGrid)sender;

            //var where = RadGridHelper.GetFilterExpression(radGrid.MasterTableView, null);
            //var orderBy = RadGridHelper.GetOrderBy(radGrid.MasterTableView);
            var filter = radGrid.MasterTableView.FilterExpression;
            var orderBy = radGrid.MasterTableView.SortExpressions.GetSortString();

            var skip = radGrid.MasterTableView.CurrentPageIndex * radGrid.MasterTableView.PageSize;
            var take = radGrid.MasterTableView.PageSize;
            var totalRowCount = 0;
            radGrid.DataSource = this.GetAllOrders(skip, take, orderBy, filter, out totalRowCount);

            if (e.RebindReason == GridRebindReason.InitialLoad
                 || e.RebindReason == GridRebindReason.ExplicitRebind)
            {
                radGrid.VirtualItemCount = totalRowCount;
            }
        }
    }

    public IEnumerable<Order> GetAllOrders(
        int startRowIndex, int maximumRows, string sortExpression, string filterExpression, out int totalRowCount)
    {
        if (string.IsNullOrWhiteSpace(sortExpression))
        {
            sortExpression = "OrderID ASC";
        }

        var query = this._db.Orders.OrderBy(sortExpression);

        if (!string.IsNullOrWhiteSpace(filterExpression))
        {
            filterExpression = GetNewDateExpression(filterExpression);
            query = query.Where(filterExpression);
        }

        totalRowCount = query.Count();
        var result = query
            .Skip(startRowIndex)
            .Take(maximumRows)
            .AsNoTracking()
            .ToList();

        return result;
    }

    private static string GetNewDateExpression(string predicate)
    {
        var split = predicate.Split(chars, StringSplitOptions.RemoveEmptyEntries);
        if (split.Count() > 1)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var element in split)
            {
                DateTime result;
                if (DateTime.TryParse(element, out result))
                {
                    var format = string.Format("DateTime({0},{1},{2},{3},{4},{5})",
                        result.Year,
                        result.Month,
                        result.Day,
                        result.Hour,
                        result.Minute,
                        result.Millisecond);
                    sb.Append(format);
                }
                else
                {
                    sb.Append(element);
                }
            }

            predicate = sb.ToString();
        }
        return predicate;
    }

    private string[] _dateFields = new string[] { "RequiredDate", "OrderDate", "ShippedDate" };

    protected void RadGrid1_ItemCommand(object source, Telerik.Web.UI.GridCommandEventArgs e)
    {
        var pair = (Pair)e.CommandArgument;
        var fieldName = pair.Second.ToString();
        var filterOption = pair.First.ToString();
        if (e.CommandName == RadGrid.FilterCommandName &&
           this._dateFields.Any(p => p == fieldName) &&
           filterOption != "NoFilter")
        {
            e.Canceled = true;
            GridFilteringItem filterItem = (GridFilteringItem)e.Item;

            var aa = ((Pair)e.CommandArgument).Second.ToString();
            var bb = filterItem[aa];
            var cc = bb.Controls[0];
            var dd = ((Telerik.Web.UI.RadDatePicker)cc).SelectedDate;
            //var currentPattern = (filterItem[((Pair)e.CommandArgument).Second.ToString()].Controls[0] as TextBox).Text;
            var currentPattern = dd.ToString();
            string filterPattern = "";
            string filterPatternAssist = "";
            if (currentPattern.IndexOf(" ") != -1)
            {
                currentPattern = currentPattern.Replace(" ", "/");
            }
            string[] vals = currentPattern.Split("/".ToCharArray());
            if (filterOption != "IsNull" && filterOption != "NotIsNull")
            {
                //if (vals.Length > 3)
                //{
                //    filterPatternAssist = vals[4] + "/" + vals[3] + "/" + vals[5];
                //}

                filterPattern = string.Format("DateTime({0},{1},{2})", vals[2], vals[0], vals[1]);
            }
            GridBoundColumn dateColumn = (GridBoundColumn)e.Item.OwnerTableView.GetColumnSafe(fieldName);
            switch (filterOption)
            {
                case "EqualTo":
                    filterPattern = string.Format("({0} = {1})", fieldName, filterPattern);
                    dateColumn.CurrentFilterFunction = GridKnownFunction.EqualTo;
                    break;

                case "NotEqualTo":
                    filterPattern = string.Format("({0} <> {1})", fieldName, filterPattern);
                    //filterPattern = "Not [RequiredDate] = '" + filterPattern + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.NotEqualTo;
                    break;

                case "GreaterThan":
                    filterPattern = string.Format("({0} > {1})", fieldName, filterPattern);

                    //filterPattern = "[RequiredDate] > '" + filterPattern + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.GreaterThan;
                    break;

                case "LessThan":
                    filterPattern = string.Format("({0} < {1})", fieldName, filterPattern);
                    //filterPattern = "[RequiredDate] < '" + filterPattern + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.LessThan;
                    break;

                case "GreaterThanOrEqualTo":
                    filterPattern = string.Format("({0} >= {1})", fieldName, filterPattern);
                    //filterPattern = "[RequiredDate] >= '" + filterPattern + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.GreaterThanOrEqualTo;
                    break;

                case "LessThanOrEqualTo":
                    filterPattern = string.Format("({0} <= {1})", fieldName, filterPattern);
                    //filterPattern = "[RequiredDate] <= '" + filterPattern + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.LessThanOrEqualTo;
                    break;

                case "Between":
                    filterPattern = "'" + filterPattern + "' <= [RequiredDate] AND [RequiredDate] <= '" + filterPatternAssist + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.Between;
                    break;

                case "NotBetween":
                    filterPattern = "[RequiredDate] <= '" + filterPattern + "' OR [RequiredDate] >= '" + filterPatternAssist + "'";
                    dateColumn.CurrentFilterFunction = GridKnownFunction.NotBetween;
                    break;

                case "IsNull":
                    break;

                case "NotIsNull":
                    break;
            }

            if (Visible)
            {
            }
            Session["filterPattern"] = filterPattern;
            //dateColumn.CurrentFilterValue = dd.ToString();
            filterItem.OwnerTableView.Rebind();
        }
        //Add more conditional checks for commands here if necessary
        else if (e.CommandName != RadGrid.SortCommandName && e.CommandName != RadGrid.PageCommandName)
        {
            var filterExpression = "";
            if (Session["filterPattern"] != null)
            {
                //filterExpression += filterExpression + "And";
            }
            //Session["filterPattern"] = null;
            //GridBoundColumn dateColumn = (GridBoundColumn)e.Item.OwnerTableView.GetColumnSafe("OrderDate");
            //dateColumn.CurrentFilterFunction = GridKnownFunction.NoFilter;
            //dateColumn.CurrentFilterValue = string.Empty;
        }
    }
}
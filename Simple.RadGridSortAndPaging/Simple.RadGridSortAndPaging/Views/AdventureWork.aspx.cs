using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Web.UI;
using System.Web.UI.WebControls;
using Simple.RadGridSortAndPaging;
using Simple.RadGridSortAndPaging.Models;
using Telerik.Web.UI;

namespace Simple.RadGridSortAndPaging.Views
{
    public partial class AdventureWork : System.Web.UI.Page
    {
        Utility _utility = new Utility();
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

        //public int? InsertPerson(Employees person)
        //{
        //    NorthwindDbContext dbContext = new NorthwindDbContext();
        //    var max = dbContext.Persons.Max(p => p.BusinessEntityID);
        //    person.BusinessEntityID = max + 1;
        //    person.rowguid = Guid.NewGuid();

        //    person.ModifiedDate = DateTime.Now;
        //    person.PersonType = "IN";
        //    dbContext.Persons.Add(person);
        //    var result = 0;
        //    try
        //    {
        //        result = dbContext.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //    return result;
        //}
        //public int? UpdatePerson(Person person)
        //{
        //    AdventureWorkDbContext dbContext = new AdventureWorkDbContext();
        //    var query = dbContext.Persons.FirstOrDefault(p => p.BusinessEntityID == person.BusinessEntityID);
        //    if (query == null)
        //    {
        //        return null;
        //    }

        //    dbContext.Entry(query).CurrentValues.SetValues(person);
        //    var result = dbContext.SaveChanges();
        //    return result;
        //}

        //public int? DeletePerson(Person person)
        //{
        //    AdventureWorkDbContext dbContext = new AdventureWorkDbContext();
        //    var query = dbContext.Persons.FirstOrDefault(p => p.BusinessEntityID == person.BusinessEntityID);
        //    if (query == null)
        //    {
        //        return null;
        //    }

        //    dbContext.Persons.Remove(query);
        //    var result = dbContext.SaveChanges();
        //    return result;
        //}



        //protected void RadGrid1_UpdateCommand(object sender, GridCommandEventArgs e)
        //{
        //    if (!(e.Item is GridEditableItem))
        //    {
        //        return;
        //    }
        //    var editedItem = (GridEditableItem)e.Item;
        //    var target = this._utility.CreateInstance<Person>(editedItem);
        //    this.UpdatePerson(target);
        //}

        //protected void RadGrid1_InsertCommand(object sender, GridCommandEventArgs e)
        //{
        //    if (!(e.Item is GridEditableItem))
        //    {
        //        return;
        //    }
        //    var editedItem = (GridEditableItem)e.Item;
        //    var target = this._utility.CreateInstance<Person>(editedItem);

        //    this.InsertPerson(target);
        //}

        protected void RadGrid1_DeleteCommand(object sender, GridCommandEventArgs e)
        {
            //if (!(e.Item is GridEditableItem))
            //{
            //    return;
            //}
            //var editedItem = (GridEditableItem)e.Item;
            //var target = this._utility.CreateInstance<Person>(e.Item);
            //this.DeletePerson(target);
        }

        //private TTarget GridItemTo<TTarget>(GridEditableItem item)
        //{

        //    var source = new Hashtable();
        //    item.OwnerTableView.ExtractValuesFromItem(source, item);
        //    var target = this._utility.CreateInstance<TTarget>(source);
        //    return target;
        //}

        private string gridMessage = null;

        protected void ImageButton1_Click(object sender, EventArgs e)
        {

        }

    }
}